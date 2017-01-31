using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.Reflection;
using System.ComponentModel;
using System.Windows.Forms;
using Oop.Tasks.Paint.Interface;


namespace Oop.Tasks.Paint.Engine
{
  public class PaintMainForm: Form
  {
    public const int DefaultImageWidth=320,
                     DefaultImageHeight=200;
    public const string PluginsRelativeDir="\\Plugins",
                        AssemblySearchPattern="*.dll";

    private static readonly Type pluginType=typeof(IPaintPlugin),
                                 attrType=typeof(PluginForLoadAttribute);

    private Bitmap bitmap=null;
    private IDictionary actionPlugins=null, // индексироваться будут MenuItem'ами
                        toolPlugins=null;   // индексироваться будут ToolBarButton'ами
    private IList allPlugins=null;
    private EventHandler SelectActionPluginEventHandler=null;
    private ToolBarButtonClickEventHandler SelectToolPluginEventHandler=null;    
    private IToolPaintPlugin activeToolPlugin=null;
    private IActionPaintPlugin activeActionPlugin=null;  
    private Control optionsControl;
    private ToolBarButton pushedButton=null;
    private String imageFileName=null;


    private System.Windows.Forms.ToolBarButton cancelPluginToolBarButton;
    private System.Windows.Forms.ToolBarButton separatorToolBarButton;
    private System.Windows.Forms.ToolBar toolsToolBar;
    private System.Windows.Forms.MainMenu mainMenu;
    private System.Windows.Forms.MenuItem fileMenuItem;
    private System.Windows.Forms.MenuItem newMenuItem;
    private System.Windows.Forms.MenuItem openMenuItem;
    private System.Windows.Forms.MenuItem saveMenuItem;
    private System.Windows.Forms.MenuItem saveAsMenuItem;
    private System.Windows.Forms.MenuItem exitMenuItem;
    private System.Windows.Forms.MenuItem actionsMenuItem;
    private System.Windows.Forms.MenuItem helpMenuItem;
    private System.Windows.Forms.MenuItem aboutMenuItem;
    private System.Windows.Forms.ImageList toolsImageList;
    private System.Windows.Forms.StatusBarPanel toolNameStatusBarPanel;
    private System.Windows.Forms.StatusBarPanel coordsStatusBarPanel;
    private System.Windows.Forms.StatusBarPanel tempStatusBarPanel;
    private System.Windows.Forms.MenuItem separatorMenuItem;
    private System.Windows.Forms.StatusBar statusBar;
    private System.Windows.Forms.GroupBox imageGroupBox;
    private System.Windows.Forms.Splitter splitter;
    private System.Windows.Forms.Panel imagePanel;
    private System.Windows.Forms.PictureBox imagePictureBox;
    private System.Windows.Forms.Panel bottomPanel;
    private System.Windows.Forms.GroupBox colorsGroupBox;
    private System.ComponentModel.IContainer components;
    private System.Windows.Forms.GroupBox optionsControlGroupBox;
    private Oop.Tasks.Paint.Controls.ColorGrid colorGrid;
    private System.Windows.Forms.Panel rightPanel;
    private System.Windows.Forms.Panel leftPanel;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.SaveFileDialog saveFileDialog;
    private System.Windows.Forms.Panel optionsControlPanel;


    public PaintMainForm() {
      InitializeComponent();
      
      CreateNewBitmap();
      actionPlugins=new Hashtable();
      toolPlugins=new Hashtable();
      allPlugins=new ArrayList();
      SelectActionPluginEventHandler=new EventHandler(OnSelectActionPlugin);
      SelectToolPluginEventHandler=new ToolBarButtonClickEventHandler(OnSelectToolPlugin);
      toolsToolBar.ButtonClick+=SelectToolPluginEventHandler;
      imagePictureBox.KeyDown+=new KeyEventHandler(OnPictureBoxKeyEvent);

      LoadPlugins();
    }


    protected void LoadPlugins() {
      UnselectPlugins();
      // полный путь к директории плагинов
      string pluginsDir=StartupPath+PluginsRelativeDir;
      // плагины (сборки) должны располагаться в поддиректориях
      string[] pluginDirs=Directory.GetDirectories(pluginsDir);

      actionPlugins.Clear();
      toolPlugins.Clear();

      foreach(string pluginDir in pluginDirs) {        
        string[] assemblyFiles=Directory.GetFiles(pluginDir,
                                                  AssemblySearchPattern);
        foreach(string assemblyFile in assemblyFiles) {
          try {
            Assembly assembly=Assembly.LoadFile(assemblyFile);
            // загрузка всех типов из сборки и поиск среди них плагинов
            Type[] types=assembly.GetTypes();
            foreach(Type type in types) {
              // проверка, что найденный тип - класс, но не абстрактный, и
              // реализует интерфейс IPaintPlugin
              // (т.е. плагин, который можно загрузить)
              if(type.GetInterface(pluginType.Name)!=null &&
                 type.IsClass && !type.IsAbstract)
                try {
                  // проверка, что данный класс предназначен для загрузки,
                  // т.е. для него определен атрибут [PluginForLoad(true)]
                  object[] attrs=type.GetCustomAttributes(attrType, false);
                  if(attrs.Length!=0 &&
                     (attrs[0] as PluginForLoadAttribute).ForLoad) {
                    // создаем экземпляр плагина
                    object obj=Activator.CreateInstance(type);
                    IPaintPlugin plugin=obj as IPaintPlugin;

                    IPaintApplicationContext applicationContext=
                          new PaintApplicationContext(this, plugin);
                    IPaintPluginContext pluginContext=
                          new PaintPluginContext(applicationContext, pluginDir);
                    plugin.AfterCreate(pluginContext);

                    if(plugin is IActionPaintPlugin) {
                      IActionPaintPlugin actionPlugin=plugin as IActionPaintPlugin;
                      MenuItem menuItem=
                            new MenuItem(actionPlugin.CommandName,
                                         SelectActionPluginEventHandler);
                      actionPlugins.Add(menuItem, actionPlugin);
                      actionsMenuItem.MenuItems.Add(menuItem);
                    }

                    if(plugin is IToolPaintPlugin) {
                      IToolPaintPlugin toolPlugin=plugin as IToolPaintPlugin;
                      ToolBarButton toolBarButton=new ToolBarButton();
                      toolBarButton.ToolTipText=toolPlugin.CommandName;

                      Image image=toolPlugin.Icon;
                      if(image!=null)
                        try {
                          // получение цвета, который принимается за прозрачный
                          Bitmap bitmap=new Bitmap(image);
                          image.Dispose();
                          Color transparentColor=bitmap.GetPixel(0, 0);
                          // добавление пиктограммы инструмента в ImageList
                          int imageIndex=toolsImageList.Images.Add(bitmap, transparentColor);
                          toolBarButton.ImageIndex=imageIndex;
                        }
                        catch(Exception e) {
                          // не удалось правильно загрузить пиктограмму плагина,
                          MessageBox.Show(e.Message,
                            "Ошибка загрузки пиктограммы плагина "+type.Name);
                        }

                      toolPlugins.Add(toolBarButton, toolPlugin);
                      toolsToolBar.Buttons.Add(toolBarButton);
                    }
                  }
                }
                catch(Exception e) {
                  // не удалось правильно загрузить плагин,
                  MessageBox.Show(e.Message,
                                  "Ошибка загрузки плагина "+type.Name,
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
          }
          catch(Exception e) {
            // не удалось правильно загрузить сборку
              MessageBox.Show(e.ToString(),
                              string.Format("Error load assembly \"{0}\"", assemblyFile));
          }
        }
      }
    }


    internal void CreateNewBitmap(int width, int height) {
      if(width<=0 || height<=0)
        return;

      imageFileName=null;
      Bitmap bitmap=new Bitmap(width, height, PixelFormat.Format24bppRgb);
      Graphics graphics=Graphics.FromImage(bitmap);
      graphics.Clear(Color.White);
      graphics.Dispose();
      
      Image=bitmap;
    }


    private void CreateNewBitmap() {
      CreateNewBitmap(DefaultImageWidth, DefaultImageHeight);
    }


    internal Bitmap Image {
      get {
        return bitmap;
      }
      set {
        if(value==null)
          return;

        if(bitmap!=null)
          bitmap.Dispose();
        bitmap=value;
        imagePictureBox.Image=bitmap;
        imagePictureBox.Width=bitmap.Width;
        imagePictureBox.Height=bitmap.Height;

        if(ActiveToolPlugin!=null)
          ActiveToolPlugin.ImageChange();
      }
    }


    internal void UnselectPlugins() {
      if(pushedButton!=null)
        pushedButton.Pushed=false;
      pushedButton=null;
      cancelPluginToolBarButton.Pushed=true;
      activeActionPlugin=null;
      ActiveToolPlugin=null;
    }


    protected override void Dispose(bool disposing) {
      UnselectPlugins();

      foreach(IPaintPlugin plugin in allPlugins)
        plugin.BeforeDestroy();
      allPlugins.Clear();
      actionPlugins.Clear();
      toolPlugins.Clear();

      if(disposing) {
        if (components!=null) {
          components.Dispose();
        }
      }
      base.Dispose(disposing);      
    }


    private string StartupPath {
      get {
        return Application.StartupPath;
      }
    }


    internal Control OptionsControl {
      get {
        return optionsControl;
      }
      set {
        if(object.Equals(OptionsControl, value))
          return;

        if(OptionsControl!=null)
          OptionsControl.Parent=null;

        optionsControl=value;

        if(OptionsControl!=null) {
          OptionsControl.Dock=DockStyle.Fill;
          OptionsControl.Parent=optionsControlPanel;
        }
        
        splitter.Visible=OptionsControl!=null;
        rightPanel.Visible=OptionsControl!=null;        
      }
    }


    private IToolPaintPlugin ActiveToolPlugin {
      get {
        return activeToolPlugin;
      }
      set {
        IToolPaintPlugin oldActiveToolPlugin=ActiveToolPlugin;
        if(object.Equals(oldActiveToolPlugin, value)) {
          // будем считать, что равносильно изменению изображения
          if(oldActiveToolPlugin!=null)
            oldActiveToolPlugin.ImageChange();
          return;
        }
        
        if(oldActiveToolPlugin!=null) {
          oldActiveToolPlugin.Select(false);
          activeToolPlugin=null;
          OptionsControl=null;
          Cursor=null;
          toolNameStatusBarPanel.Text="";
        }

        activeToolPlugin=value;

        if(value!=null) {
          value.Select(true);
          toolNameStatusBarPanel.Text="Выбран инструмент: "+value.ToolName;
        }
      }
    }


    internal IPaintPlugin ActivePlugin {
      get {
        if(activeActionPlugin!=null)
          return activeActionPlugin;
        else
          return ActiveToolPlugin;
      }
    }


    private void OnSelectActionPlugin(object sender, EventArgs e) {
      try {
        IActionPaintPlugin actionPlugin=
              actionPlugins[sender] as IActionPaintPlugin;
        activeActionPlugin=actionPlugin;
        actionPlugin.Select(true);
        actionPlugin.Select(false);
        activeActionPlugin=null;

        IToolPaintPlugin oldActiveToolPlugin=ActiveToolPlugin;
        if(oldActiveToolPlugin!=null)
          oldActiveToolPlugin.ImageChange();
      }
      finally {
        // подавление ошибок
        activeActionPlugin=null;
      }
    }


    private void OnSelectToolPlugin(object sender, ToolBarButtonClickEventArgs e) {
      try {
        if(object.Equals(e.Button, cancelPluginToolBarButton)) {
          UnselectPlugins();
          return;
        }

        IToolPaintPlugin toolPlugin=
          toolPlugins[e.Button] as IToolPaintPlugin;
        if(!object.Equals(ActiveToolPlugin, toolPlugin)) {
          ActiveToolPlugin=toolPlugin;
          if(pushedButton!=null)
            pushedButton.Pushed=false;
          pushedButton=e.Button;
          pushedButton.Pushed=true;
          cancelPluginToolBarButton.Pushed=false;
        }
      }
      catch {
        // подавление ошибок
      }
    }


    private void OnPictureBoxKeyEvent(object sender, KeyEventArgs ke) {
      if(ActiveToolPlugin==null)
        return;

      switch(ke.KeyCode) {
        case Keys.Enter:
          ActiveToolPlugin.Enter();
          break;
        case Keys.Escape:
          ActiveToolPlugin.Escape();
          break;
      }
    }


    internal void ImageInvalidate() {
      imagePictureBox.Invalidate();
    }


    internal Color ForegroundColor {
      get {
        return colorGrid.ForegroundColor;
      }
      set {
        colorGrid.ForegroundColor=value;
      }
    }


    internal Color BackgroundColor {
      get {
        return colorGrid.BackgroundColor;
      }
      set {
        colorGrid.BackgroundColor=value;
      }
    }


    internal Cursor ImageCursor {
      get {
        return imagePictureBox.Cursor;
      }
      set {
        imagePictureBox.Cursor=value;
      }
    }


    private void imagePictureBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
      imagePictureBox.Focus();

      if(ActiveToolPlugin==null)
        return;

      try {
        ActiveToolPlugin.MouseDown(e, Control.ModifierKeys);
      }
      catch {
        // подавление исключения
      }
    }


    private void imagePictureBox_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e) {
      coordsStatusBarPanel.Text=e.X+", "+e.Y;

      if(ActiveToolPlugin==null)
        return;

      try {
        ActiveToolPlugin.MouseMove(e, Control.ModifierKeys);
      }
      catch {
        // подавление исключения
      }
    }


    private void imagePictureBox_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e) {
      if(ActiveToolPlugin==null)
        return;

      try {
        ActiveToolPlugin.MouseUp(e, Control.ModifierKeys);
      }
      catch {
        // подавление исключения
      }
    }


    private void imagePictureBox_MouseLeave(object sender, System.EventArgs e) {
      coordsStatusBarPanel.Text="";
    }


    private void colorGrid_ColorsChanged(object sender, System.EventArgs e) {
      if(ActiveToolPlugin==null)
        return;

      try {
        ActiveToolPlugin.ColorChange();
      }
      catch {
        // подавление исключения
      }
    }


    private void aboutMenuItem_Click(object sender, System.EventArgs e) {
      string msg=this.Text+
                 "\nпростейший графический редактор с поддержкой плагинов"+
                 "\n"+
                 "\nавтор: Соломатин Дмитрий (solomatin@cs.vsu.ru)"+
                 ",\nспециально для практических занятий по ООП";
      MessageBox.Show(msg, "О программе",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
    }


    private void newMenuItem_Click(object sender, System.EventArgs e) {
      CreateNewBitmap();
    }


    private void LoadImage() {
      if(openFileDialog.ShowDialog()==DialogResult.OK)
        try {
          Image image=System.Drawing.Image.FromFile(openFileDialog.FileName);
          Bitmap bitmap=null;
          
          bitmap=new Bitmap(image.Width, image.Height,
                            PixelFormat.Format24bppRgb);
          Graphics graphics=Graphics.FromImage(bitmap);
          graphics.DrawImage(image, 0, 0);
          graphics.Dispose();

          if(image is Bitmap &&
             openFileDialog.FileName.ToLower().EndsWith("bmp"))
            imageFileName=openFileDialog.FileName;
          else
            imageFileName=null;
                  
          image.Dispose();

          Image=bitmap;
        }
        catch {
          // подавление исключения
          MessageBox.Show("Не удалось загрузить изображение из файла:\n"+
                          openFileDialog.FileName,
                          "Ошибка загрузки изображения",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Warning);
        }
    }


    private bool SaveImageIntoFile(String fileName) {
      try {
        Image.Save(fileName);
        return true;
      }
      catch(Exception e) {
        // подавление исключения
        MessageBox.Show("Не удалось сохранить изображение в файл:\n"+
                        fileName+"\n\n"+e.Message,
                        "Ошибка сохранения изображения",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
        return false;
      }
    }


    private void SaveAsImage() {
      if(saveFileDialog.ShowDialog()==DialogResult.OK) {
        if(File.Exists(saveFileDialog.FileName)) {
          DialogResult dialogResult=
                MessageBox.Show("Файл с именем:\n"+
                                saveFileDialog.FileName+
                                "\nсуществует. Заменить?",
                                "Сохранение изображения",
                                MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Question);
          if(dialogResult!=DialogResult.Yes)
            return;
        }
        if(SaveImageIntoFile(saveFileDialog.FileName))
          imageFileName=saveFileDialog.FileName;
      }
    }


    private void openMenuItem_Click(object sender, System.EventArgs e) {
      LoadImage();
    }


    private void saveMenuItem_Click(object sender, System.EventArgs e) {
      if(imageFileName!=null)
        SaveImageIntoFile(imageFileName);
      else
        SaveAsImage();
    }


    private void saveAsMenuItem_Click(object sender, System.EventArgs e) {
      SaveAsImage();
    }


    private void exitMenuItem_Click(object sender, System.EventArgs e) {
      Application.Exit();
    }


    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaintMainForm));
            this.toolsToolBar = new System.Windows.Forms.ToolBar();
            this.cancelPluginToolBarButton = new System.Windows.Forms.ToolBarButton();
            this.separatorToolBarButton = new System.Windows.Forms.ToolBarButton();
            this.toolsImageList = new System.Windows.Forms.ImageList(this.components);
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.fileMenuItem = new System.Windows.Forms.MenuItem();
            this.newMenuItem = new System.Windows.Forms.MenuItem();
            this.openMenuItem = new System.Windows.Forms.MenuItem();
            this.saveMenuItem = new System.Windows.Forms.MenuItem();
            this.saveAsMenuItem = new System.Windows.Forms.MenuItem();
            this.separatorMenuItem = new System.Windows.Forms.MenuItem();
            this.exitMenuItem = new System.Windows.Forms.MenuItem();
            this.actionsMenuItem = new System.Windows.Forms.MenuItem();
            this.helpMenuItem = new System.Windows.Forms.MenuItem();
            this.aboutMenuItem = new System.Windows.Forms.MenuItem();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.colorsGroupBox = new System.Windows.Forms.GroupBox();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.toolNameStatusBarPanel = new System.Windows.Forms.StatusBarPanel();
            this.coordsStatusBarPanel = new System.Windows.Forms.StatusBarPanel();
            this.tempStatusBarPanel = new System.Windows.Forms.StatusBarPanel();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.optionsControlGroupBox = new System.Windows.Forms.GroupBox();
            this.optionsControlPanel = new System.Windows.Forms.Panel();
            this.splitter = new System.Windows.Forms.Splitter();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.imageGroupBox = new System.Windows.Forms.GroupBox();
            this.imagePanel = new System.Windows.Forms.Panel();
            this.imagePictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.colorGrid = new Oop.Tasks.Paint.Controls.ColorGrid();
            this.bottomPanel.SuspendLayout();
            this.colorsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolNameStatusBarPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coordsStatusBarPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempStatusBarPanel)).BeginInit();
            this.rightPanel.SuspendLayout();
            this.optionsControlGroupBox.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.imageGroupBox.SuspendLayout();
            this.imagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // toolsToolBar
            // 
            this.toolsToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.cancelPluginToolBarButton,
            this.separatorToolBarButton});
            this.toolsToolBar.ButtonSize = new System.Drawing.Size(30, 29);
            this.toolsToolBar.DropDownArrows = true;
            this.toolsToolBar.ImageList = this.toolsImageList;
            this.toolsToolBar.Location = new System.Drawing.Point(0, 0);
            this.toolsToolBar.Name = "toolsToolBar";
            this.toolsToolBar.ShowToolTips = true;
            this.toolsToolBar.Size = new System.Drawing.Size(532, 36);
            this.toolsToolBar.TabIndex = 0;
            // 
            // cancelPluginToolBarButton
            // 
            this.cancelPluginToolBarButton.ImageIndex = 0;
            this.cancelPluginToolBarButton.Name = "cancelPluginToolBarButton";
            this.cancelPluginToolBarButton.Pushed = true;
            this.cancelPluginToolBarButton.ToolTipText = "Отменить инструмент";
            // 
            // separatorToolBarButton
            // 
            this.separatorToolBarButton.Name = "separatorToolBarButton";
            this.separatorToolBarButton.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolsImageList
            // 
            this.toolsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("toolsImageList.ImageStream")));
            this.toolsImageList.TransparentColor = System.Drawing.Color.Magenta;
            this.toolsImageList.Images.SetKeyName(0, "");
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.fileMenuItem,
            this.actionsMenuItem,
            this.helpMenuItem});
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.Index = 0;
            this.fileMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.newMenuItem,
            this.openMenuItem,
            this.saveMenuItem,
            this.saveAsMenuItem,
            this.separatorMenuItem,
            this.exitMenuItem});
            this.fileMenuItem.Text = "Файл";
            // 
            // newMenuItem
            // 
            this.newMenuItem.Index = 0;
            this.newMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.newMenuItem.Text = "Создать";
            this.newMenuItem.Click += new System.EventHandler(this.newMenuItem_Click);
            // 
            // openMenuItem
            // 
            this.openMenuItem.Index = 1;
            this.openMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.openMenuItem.Text = "Открыть";
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Index = 2;
            this.saveMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.saveMenuItem.Text = "Сохранить";
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.Index = 3;
            this.saveAsMenuItem.Text = "Сохранить как...";
            this.saveAsMenuItem.Click += new System.EventHandler(this.saveAsMenuItem_Click);
            // 
            // separatorMenuItem
            // 
            this.separatorMenuItem.Index = 4;
            this.separatorMenuItem.Text = "-";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Index = 5;
            this.exitMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.exitMenuItem.Text = "Выход";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // actionsMenuItem
            // 
            this.actionsMenuItem.Index = 1;
            this.actionsMenuItem.Text = "Действия";
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.Index = 2;
            this.helpMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.aboutMenuItem});
            this.helpMenuItem.Text = "Справка";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Index = 0;
            this.aboutMenuItem.Text = "О программе...";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.colorsGroupBox);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 262);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(532, 48);
            this.bottomPanel.TabIndex = 5;
            // 
            // colorsGroupBox
            // 
            this.colorsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorsGroupBox.Controls.Add(this.colorGrid);
            this.colorsGroupBox.Location = new System.Drawing.Point(0, -5);
            this.colorsGroupBox.Name = "colorsGroupBox";
            this.colorsGroupBox.Size = new System.Drawing.Size(532, 53);
            this.colorsGroupBox.TabIndex = 0;
            this.colorsGroupBox.TabStop = false;
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 310);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.toolNameStatusBarPanel,
            this.coordsStatusBarPanel,
            this.tempStatusBarPanel});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(532, 22);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusBar";
            // 
            // toolNameStatusBarPanel
            // 
            this.toolNameStatusBarPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.toolNameStatusBarPanel.Name = "toolNameStatusBarPanel";
            this.toolNameStatusBarPanel.Width = 415;
            // 
            // coordsStatusBarPanel
            // 
            this.coordsStatusBarPanel.Name = "coordsStatusBarPanel";
            this.coordsStatusBarPanel.Width = 70;
            // 
            // tempStatusBarPanel
            // 
            this.tempStatusBarPanel.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.tempStatusBarPanel.Name = "tempStatusBarPanel";
            this.tempStatusBarPanel.Width = 30;
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.optionsControlGroupBox);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rightPanel.Location = new System.Drawing.Point(352, 36);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(180, 226);
            this.rightPanel.TabIndex = 2;
            this.rightPanel.Visible = false;
            // 
            // optionsControlGroupBox
            // 
            this.optionsControlGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsControlGroupBox.Controls.Add(this.optionsControlPanel);
            this.optionsControlGroupBox.Location = new System.Drawing.Point(0, -4);
            this.optionsControlGroupBox.Name = "optionsControlGroupBox";
            this.optionsControlGroupBox.Size = new System.Drawing.Size(180, 228);
            this.optionsControlGroupBox.TabIndex = 3;
            this.optionsControlGroupBox.TabStop = false;
            // 
            // optionsControlPanel
            // 
            this.optionsControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsControlPanel.AutoScroll = true;
            this.optionsControlPanel.AutoScrollMargin = new System.Drawing.Size(8, 8);
            this.optionsControlPanel.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.optionsControlPanel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.optionsControlPanel.Location = new System.Drawing.Point(2, 7);
            this.optionsControlPanel.Name = "optionsControlPanel";
            this.optionsControlPanel.Padding = new System.Windows.Forms.Padding(8);
            this.optionsControlPanel.Size = new System.Drawing.Size(176, 219);
            this.optionsControlPanel.TabIndex = 3;
            this.optionsControlPanel.TabStop = true;
            // 
            // splitter
            // 
            this.splitter.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter.Location = new System.Drawing.Point(350, 36);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(2, 226);
            this.splitter.TabIndex = 3;
            this.splitter.TabStop = false;
            this.splitter.Visible = false;
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.imageGroupBox);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPanel.Location = new System.Drawing.Point(0, 36);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(350, 226);
            this.leftPanel.TabIndex = 4;
            // 
            // imageGroupBox
            // 
            this.imageGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageGroupBox.Controls.Add(this.imagePanel);
            this.imageGroupBox.Location = new System.Drawing.Point(0, -4);
            this.imageGroupBox.Name = "imageGroupBox";
            this.imageGroupBox.Size = new System.Drawing.Size(350, 228);
            this.imageGroupBox.TabIndex = 0;
            this.imageGroupBox.TabStop = false;
            // 
            // imagePanel
            // 
            this.imagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imagePanel.AutoScroll = true;
            this.imagePanel.AutoScrollMargin = new System.Drawing.Size(8, 8);
            this.imagePanel.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.imagePanel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.imagePanel.Controls.Add(this.imagePictureBox);
            this.imagePanel.Location = new System.Drawing.Point(2, 7);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(346, 219);
            this.imagePanel.TabIndex = 0;
            // 
            // imagePictureBox
            // 
            this.imagePictureBox.BackColor = System.Drawing.Color.White;
            this.imagePictureBox.Location = new System.Drawing.Point(8, 8);
            this.imagePictureBox.Name = "imagePictureBox";
            this.imagePictureBox.Size = new System.Drawing.Size(320, 240);
            this.imagePictureBox.TabIndex = 0;
            this.imagePictureBox.TabStop = false;
            this.imagePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imagePictureBox_MouseDown);
            this.imagePictureBox.MouseLeave += new System.EventHandler(this.imagePictureBox_MouseLeave);
            this.imagePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imagePictureBox_MouseMove);
            this.imagePictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imagePictureBox_MouseUp);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "bmp";
            this.openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.gif;*.png;*.tiff)|*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tif" +
    "f|MetaImage Files (*.wmf;*.emf)|*.wmf;*.emf|All files (*.*)|*.*";
            this.openFileDialog.Title = "Загрузка изображения";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "bmp";
            this.saveFileDialog.Filter = "Bitmap Image Files (*.bmp)|*.bmp|All Files (*.*)|*.*";
            this.saveFileDialog.OverwritePrompt = false;
            this.saveFileDialog.Title = "Сохранение изображения";
            // 
            // colorGrid
            // 
            this.colorGrid.BackgroundColor = System.Drawing.Color.White;
            this.colorGrid.ColorBoxSize = ((byte)(16));
            this.colorGrid.ColorsCount = ((byte)(32));
            this.colorGrid.ForegroundColor = System.Drawing.Color.Black;
            this.colorGrid.FromColor = System.Drawing.Color.Black;
            this.colorGrid.Location = new System.Drawing.Point(8, 12);
            this.colorGrid.Name = "colorGrid";
            this.colorGrid.Size = new System.Drawing.Size(322, 34);
            this.colorGrid.TabIndex = 0;
            this.colorGrid.ForegroundColorChanged += new System.EventHandler(this.colorGrid_ColorsChanged);
            this.colorGrid.BackgroundColorChanged += new System.EventHandler(this.colorGrid_ColorsChanged);
            // 
            // PaintMainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(532, 332);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.toolsToolBar);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.statusBar);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Menu = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(345, 236);
            this.Name = "PaintMainForm";
            this.Text = "ФКН Paint, .NET-версия :-)";
            this.bottomPanel.ResumeLayout(false);
            this.colorsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toolNameStatusBarPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coordsStatusBarPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempStatusBarPanel)).EndInit();
            this.rightPanel.ResumeLayout(false);
            this.optionsControlGroupBox.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.imageGroupBox.ResumeLayout(false);
            this.imagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
    #endregion        
  }
}

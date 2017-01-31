using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Oop.Tasks.Paint.Controls {
  public class ColorGrid : Control {
    // минимальное количество доступных для выбора цветов
    public const byte MinColorsCount=2;
    // максимальное количество доступных для выбора цветов
    public const byte MaxColorsCount=256-4;
    // минимальный размер "квадратика" для представления цвета
    public const byte MinColorBoxSize=8;
    // максимальный размер "квадратика" для представления цвета
    public const byte MaxColorBoxSize=80;


    // foreColorPanel и backColorPanel - последние 2
    private Panel[] colorPanels=null;
    // обработчик нажатий клавиш мыши над любой из colorPanels
    private MouseEventHandler colorPanelMouseDown=null;
    // диалог выбора цвета
    private ColorDialog colorDialog=null;

    // цвет по умолчанию
    private static Color defaultColor=Color.Black;
    // количество различных цветов на панели
    private byte colorsCount=32;
    // размер "квадратика" для представления цвета
    private byte colorBoxSize=16;
    // цвет, начиная с которого отображаются цвета из KnownColor
    private Color fromColor=Color.Black;


    // события изменения ForegroundColor и BackgroundColor
    public event EventHandler ForegroundColorChanged=null;
    public event EventHandler BackgroundColorChanged=null;


    public static Color DefaultColor {
      get {
        return defaultColor;
      }
    }
    

    [Bindable(true), Category("Appearance"), DefaultValue("32")]
    public byte ColorsCount {
      get {
        return colorsCount;
      }
      set {
        colorsCount=Math.Min(Math.Max(value, MinColorsCount), MaxColorsCount);
        recreateColorPanels();        
      }
    }


    [Bindable(true), Category("Appearance"), DefaultValue("16")]
    public byte ColorBoxSize {
      get {
        return colorBoxSize;
      }
      set {        
        colorBoxSize=Math.Min(Math.Max(value, MinColorBoxSize), MaxColorBoxSize);
        refreshSizes();
      }
    }


    [Bindable(true), Category("Appearance"), DefaultValue("Black")]
    public Color FromColor {
      get {
        return fromColor;
      }
      set {
        fromColor=value;
        selectColors();
      }
    }


    [Bindable(true), Category("Appearance")]
    public Color ForegroundColor {
      get {
        return colorPanels[ColorsCount].BackColor;
      }
      set {
        colorPanels[ColorsCount].BackColor=value;
      }
    }


    [Bindable(true), Category("Appearance")]
    public Color BackgroundColor {
      get {
        return colorPanels[ColorsCount+1].BackColor;
      }
      set {
        colorPanels[ColorsCount+1].BackColor=value;
      }
    }    


    protected void recreateColorPanels() {
      byte oldCount=0;
      if(colorPanels!=null)
        oldCount=(byte)(colorPanels.Length-2);
      if(oldCount==ColorsCount)
        return;

      this.SuspendLayout();
      Panel[] oldColorPanels=colorPanels;
      colorPanels=new Panel[ColorsCount+2];
      if(oldColorPanels!=null) {
        int length=Math.Min(ColorsCount, oldCount);
        Array.Copy(oldColorPanels, 0, colorPanels, 0, length);
        for(byte i=0; i<2; i++)
          colorPanels[ColorsCount+i]=oldColorPanels[oldCount+i];        
        for(byte i=ColorsCount; i<oldCount; i++)
          oldColorPanels[i].Dispose();
      }      
      for(byte i=oldCount; i<ColorsCount+2-Math.Min(oldCount, (byte)2); i++) {
        colorPanels[i]=new Panel();
        colorPanels[i].Parent=this;
        if(i<ColorsCount)
          colorPanels[i].MouseDown+=colorPanelMouseDown;
      }
      this.ResumeLayout();

      refreshSizes();
      selectColors();
    }


    protected void refreshSizes() {
      for(byte i=0; i<ColorsCount+2; i++) {
        colorPanels[i].Width=ColorBoxSize;
        colorPanels[i].Height=ColorBoxSize;
        if(i<ColorsCount) {
          colorPanels[i].Left=(2+i/2)*(ColorBoxSize+2);
          colorPanels[i].Top=i%2*(ColorBoxSize+2);
          colorPanels[i].BorderStyle=BorderStyle.Fixed3D;
        }
        else {
          byte num=(byte)(i-colorPanels.Length+2);
          colorPanels[i].Left=(1+2*num)*ColorBoxSize/4+1;
          colorPanels[i].Top=(1+2*num)*ColorBoxSize/4+1;
          colorPanels[i].BorderStyle=BorderStyle.FixedSingle;
        }
      }
      OnResize(EventArgs.Empty);
    }

    
    protected virtual void selectColors() {
      KnownColor known=fromColor.ToKnownColor();
      for(byte i=0; i<colorPanels.Length; i++) {
        if(i<colorPanels.Length-2) {
          int color=(int)known+i;
          color=color%((int)KnownColor.YellowGreen+1);
          colorPanels[i].BackColor=Color.FromKnownColor((KnownColor)color);
        }
        else          
          if(colorPanels.Length-i-2==0)
            colorPanels[i].BackColor=Color.Black;
          else
            colorPanels[i].BackColor=Color.White;
      }      
    }


    public ColorGrid() {
      colorDialog=new ColorDialog();
      colorPanelMouseDown=new MouseEventHandler(OnColorPanelMouseDown);

      this.SuspendLayout();

      ColorsCount=32;
      ColorBoxSize=16;
      FromColor=DefaultColor;

      this.ResumeLayout();
    }


    protected override void Dispose(bool disposing) {
      if(disposing) {
        for(byte i=0; i<colorPanels.Length; i++)
          colorPanels[i].Dispose();
      }
      base.Dispose(disposing);
    }


    protected override void OnPaint(PaintEventArgs pe) {
      base.OnPaint(pe);
    }


    protected override void OnResize(EventArgs e) {
      int width=((ColorsCount+1)/2+2)*(ColorBoxSize+2)-2,
          height=ColorBoxSize*2+2;
      bool isChange=width!=Width || height!=Height;
      Width=width; Height=height;
      if(isChange)
        base.OnResize(e);
    }


    private void OnColorPanelMouseDown(object sender, MouseEventArgs e) {
      if(e.Button!=MouseButtons.Left && e.Button!=MouseButtons.Right)
        return;

      Panel panel=sender as Panel;
      if(e.Clicks>1) {
        colorDialog.Color=panel.BackColor;
        if(colorDialog.ShowDialog()==DialogResult.OK)
          panel.BackColor=colorDialog.Color;
      }
      Color color=panel.BackColor;
      
      if(e.Button==MouseButtons.Left) {
        bool colorChanged=ForegroundColor!=color;
        ForegroundColor=color;
        if(colorChanged && ForegroundColorChanged!=null)
          ForegroundColorChanged(this, EventArgs.Empty);
      }
      else {
        bool colorChanged=BackgroundColor!=color;
        BackgroundColor=color;
        if(colorChanged && BackgroundColorChanged!=null)
          BackgroundColorChanged(this, EventArgs.Empty);
      }
    }
  }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using Oop.Tasks.Paint.Interface;


namespace Oop.Tasks.Paint.Engine
{
	internal class PaintApplicationContext: IPaintApplicationContext
	{
    private PaintMainForm mainForm=null;
    // каждый контекст приложения специфицирован для конкретного плагина
    private IPaintPlugin paintPlugin=null;


		internal PaintApplicationContext(PaintMainForm mainForm,
                                     IPaintPlugin paintPlugin) {
      if(mainForm==null)
        throw new PaintException("PaintApplicationContext: "+
                                 "MainForm isn't defined");
      if(paintPlugin==null)
        throw new PaintException("PaintApplicationContext: "+
                                 "PaintPlugin isn't defined");

      this.mainForm=mainForm;
      this.paintPlugin=paintPlugin;
		}


    private PaintMainForm MainForm {
      get {
        return mainForm;
      }
    }


    public void Invalidate() {
      mainForm.ImageInvalidate();
    }


    public Bitmap Image {
      get{
        return MainForm.Image;
      }
    }


    public void CreateNewImage(int width, int height) {
      if(!paintPlugin.Equals(ActivePlugin))
        return;
      if(width<=0 || height<=0)
        throw new PaintException("PaintApplicationContext: "+
                                 "new image size is incorrect");

      MainForm.CreateNewBitmap(width, height);
    }


    public Color ForegroundColor {
      get {
        return MainForm.ForegroundColor;
      }
      set {
        if(!paintPlugin.Equals(ActivePlugin))
          return;

        MainForm.ForegroundColor=value;
      }
    }


    public Color BackgroundColor {
      get {
        return MainForm.BackgroundColor;
      }
      set {
        if(!paintPlugin.Equals(ActivePlugin))
          return;

        MainForm.BackgroundColor=value;
      }
    }


    public IPaintPlugin ActivePlugin {
      get {
        return MainForm.ActivePlugin;
      }
    }

    
    public void UnselectPlugin() {
      if(!paintPlugin.Equals(ActivePlugin))
        return;

      MainForm.UnselectPlugins();
    }


    public Control OptionsControl {
      get {
        return MainForm.OptionsControl;
      }
      set {
        if(!paintPlugin.Equals(ActivePlugin))
          return;

        MainForm.OptionsControl=value;
      }
    }


    public Cursor Cursor {
      get {
        return MainForm.ImageCursor;
      }
      set {
        if(!paintPlugin.Equals(ActivePlugin))
          return;

        MainForm.ImageCursor=value;
      }
    }
	}
}

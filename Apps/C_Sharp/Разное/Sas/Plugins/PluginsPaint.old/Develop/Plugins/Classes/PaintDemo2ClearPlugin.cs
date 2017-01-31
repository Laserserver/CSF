using System;
using System.Drawing;
using Oop.Tasks.Paint.Interface;


namespace Oop.Tasks.Paint.Plugins {
  [PluginForLoad(true)]
  public class PaintDemo2ClearPlugin: IActionPaintPlugin {
    private IPaintPluginContext pluginContext=null;


    private IPaintApplicationContext ApplicationContext {
      get {
        if(pluginContext==null)
          return null;
        else
          return pluginContext.ApplicationContext;
      }
    }


    public void AfterCreate(IPaintPluginContext pluginContext) {
      this.pluginContext=pluginContext;      
    }


    public void BeforeDestroy() {
    }


    public void Select(bool selection) {
      if(!selection)
        return;

      Graphics graphics=Graphics.FromImage(ApplicationContext.Image);
      graphics.Clear(Color.White);
      graphics.Dispose();

      ApplicationContext.Invalidate();
    }


    public string Name {
      get {
        return this.GetType().Name;
      }
    }


    public string CommandName {
      get {
        return "Очистить";
      }
    }
  }
}

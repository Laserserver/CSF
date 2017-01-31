using System;
using Oop.Tasks.Paint.Interface;


namespace Oop.Tasks.Paint.Engine
{
	internal class PaintPluginContext: IPaintPluginContext
	{    
    private IPaintApplicationContext applicationContext=null;
    private string pluginDir=null;


		internal PaintPluginContext(IPaintApplicationContext applicationContext,
                                string pluginDir) {
      if(applicationContext==null)
        throw new PaintException("ApplicationContext isn't defined");
      if(pluginDir==null)
        throw new PaintException("PluginDir isn't defined");

      this.applicationContext=applicationContext;
      this.pluginDir=pluginDir;
		}


    public string PluginDir {
      get {
        return pluginDir;
      }
    }


    public IPaintApplicationContext ApplicationContext {
      get {
        return applicationContext;
      }
    }
	}
}

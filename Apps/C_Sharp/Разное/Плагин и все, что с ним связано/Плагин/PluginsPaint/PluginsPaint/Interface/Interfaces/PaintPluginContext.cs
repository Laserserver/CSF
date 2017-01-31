using System;


namespace Oop.Tasks.Paint.Interface
{
  // Интерфейс, описывающий контекст плагина
  //
	public interface IPaintPluginContext
	{
    // полный путь к директории плагина
    string PluginDir { get; }

    // контекст приложения
    IPaintApplicationContext ApplicationContext { get; }
	}
}

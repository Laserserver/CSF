using System;


namespace Oop.Tasks.Paint.Interface
{
  // Ѕазовый интерфейс плагина
  //
  public interface IPaintPlugin
  {
    // вызываетс€ после создани€ плагина
    // (экземпл€ра класса плагина)
    void AfterCreate(IPaintPluginContext
                     pluginContext);

    // вызываетс€ перед уничтожением плагина
    void BeforeDestroy();

    // вызываетс€ при выборе плагина на панели
    // инструментов и при отмене выбора
    // (например, выбираетс€ другой плагин);
    // selection - показывает, выбран ли
    //     плагин (true) или же, наоборот,
    //     работа с плагиноим прекратилась
    void Select(bool selection);


    // название плагина
    string Name { get; }

    // действие, которое выполн€ет данный плагин
    // (например, "ќчистка изображани€")
    string CommandName { get; }
  }
}

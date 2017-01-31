using System;


namespace Oop.Tasks.Paint.Interface
{
  // »нтерфейс плагина-действи€
  // (т.е. выполн€ющегос€ один раз над изображение);
  // у класса, реализующего данный интерфейс, об€зательно
  // должен быть конструктор по умолчанию (т.е. без аргументов)
  //
  public interface IActionPaintPlugin: IPaintPlugin                   
  {		
  }
}

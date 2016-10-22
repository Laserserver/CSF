using System;
using System.Collections.Generic;
/*Объектное представление текстового документа
 * (секции, колонки) с форматирование текста в
 * консоле по ширине. Т.е. необходимо создать
 * документ как набор объектов (секции, колонки,
 * заголовки, списки и т.п.). Затем вызываем метод
 * string Format(int width) и получаем красивое текстовое
 * представление документа (в консоле).*/
namespace YAISP1._8
{
  class MainProgram
  {
    private static void Main(string[] args)
    {
      ConHandler Cons = new ConHandler();
      Cons.ConsoleStart();
    }
  }
}
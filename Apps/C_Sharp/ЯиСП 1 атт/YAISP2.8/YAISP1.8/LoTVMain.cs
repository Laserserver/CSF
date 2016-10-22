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
  //КОНСОЛЬ В МАКС РАСШИРЕНИИ 80 СИМВОЛОВ -> колонки 3*k + 2*j символов?
  class LoTVMain
  {
    private static List<LoTVDoc> DataBase;
    private static LoTVDoc CurrentDoc;
    private static void Main(string[] args)
    {
      DataBase = new List<LoTVDoc>();
      char Sw = ' ';
      bool Exit = false;  //Флаг выхода из программы
      bool DoNotShowMenu = false;
      do
      {
        if (!DoNotShowMenu)
          LoTVLogics.ColorText("1. Создать новый текст.\n2. Выбрать существующий текст.\n3. Отформатировать активный текст.\n4. Закончить работу.", 'a');
        Console.Write(">> ");
        try
        {
          Sw = Console.ReadLine()[0];
          switch (Sw)
          {
            case '1':
            case '2':
            case '3':
              DoNotShowMenu = false;
              DocOptions(Sw);
              break;
            case '4':
              Exit = true;
              break;
            default:
              LoTVLogics.ColorText("Введен недопустимый символ: " + Sw, 'e');
              DoNotShowMenu = true;
              break;
          }
        }
        catch
        {
          LoTVLogics.ColorText("Введен недопустимый символ.", 'e');
        }
      } while (!Exit);
      LoTVLogics.ColorText("Работа закончена. Нажмите любую клавишу для выхода.", 'i');
      Console.ReadKey();
    }
    //============================================== Выбор действия
    private static void DocOptions(char Op)
    {
      switch (Op)
      {
        case '1':
          CreateDocument();
          break;
        case '2':
          SetCurrentDocument();
          break;
        case '3':
          if (CurrentDoc != null)
          {
            LoTVLogics.ColorText("Введите ширину форматирования (от 1 до 80):", 'a');
            int Width = 0;
            Console.Write(">> ");
            if (int.TryParse(Console.ReadLine(), out Width))
              if (Width < 1 || Width > 80)
                LoTVLogics.ColorText("Недопустимая ширина: " + Width, 'e');
              else
                LoTVLogics.ColorText(CurrentDoc.Format(Width), 'o');
            else
              LoTVLogics.ColorText("Введены недопустимые символы", 'e');
          }
          else
            LoTVLogics.ColorText("Создайте хотя бы один текст для его форматирования", 'e');
          break;
      }
    }
    //============================================== Выбор текста
    private static void SetCurrentDocument()
    {
      if (DataBase.Count == 0)
        LoTVLogics.ColorText("Вам необходимо создать хотя бы один документ.\n", 'e');
      else
      {
        LoTVLogics.ColorText("Выберите текст: ", 'i');
        int Length = DataBase.Count;   //Получаем количество текстов
        GetTexts(Length);
        do
          Console.Write(">> ");
        while (!SetText(Length));
      }
    }
    private static void GetTexts(int Length)  //Получаем список текстов
    {
      LoTVLogics.ColorText("Список текстов: ", 'i');
      for (int i = 0; i < Length; i++)
        LoTVLogics.ColorText((i + 1) + ". " + DataBase[i].Header, 'h');
    }
    private static bool SetText(int Length)
    {
      int TextNum = -1;
      if (int.TryParse(Console.ReadLine(), out TextNum))    //Проверка на численность
      {
        if (TextNum < 1 || TextNum > Length)   //Проверка на вхождение в интервал номеров
        {
          LoTVLogics.ColorText("Неподходящий номер: " + TextNum + '.', 'e');
          return false;
        }
        else
        {
          CurrentDoc = DataBase[TextNum - 1]; //Т.к. TextNum отображается увеличенным на 1
          LoTVLogics.ColorText("Активный текст: " + CurrentDoc.Header, 'h');
          return true;
        }
      }
      else
      {
        LoTVLogics.ColorText("Введено недопустимое значение", 'e');
        return false;
      }
    }
    //============================================== Создание нового текста
    private static void CreateDocument()
    {
      LoTVLogics.ColorText("Создание текста", 'i');
      LoTVLogics.ColorText("Назовите текст: ", 'a');
      Console.Write(">> ");
      LoTVDoc Lst = new LoTVDoc(Console.ReadLine());
      Lst.LoTVDocAddText();
      DataBase.Add(Lst);
      CurrentDoc = Lst;
      LoTVLogics.ColorText("Активный текст: " + CurrentDoc.Header, 'h');
    }
  }
}
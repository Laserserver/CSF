using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YAISP1._8
{
  class ConHandler
  {
    List<LoTVDoc> DataBase;
    LoTVDoc CurrentDoc;

    public ConHandler()
    {
      DataBase = new List<LoTVDoc>();
    }
    public void ConsoleStart()
    {
      bool Exit = false;  //Флаг выхода из программы
      do
      {
        Exit = MainMenu();
      } while (!Exit);
      ColorText("Работа закончена. Нажмите любую клавишу для выхода.", 'i');
      Console.ReadKey();
    }

    public bool MainMenu()
    {
      char Sw = ' ';
      bool DoNotShowMenu = false;
      if (!DoNotShowMenu)
        ColorText("1. Создать новый текст.\n2. Выбрать существующий текст.\n3. Отформатировать активный текст.\n4. Закончить работу.", 'a');
      Console.Write(">> ");
      try
      {
        Sw = Console.ReadLine()[0];
        switch (Sw)
        {
          case '1':
            DoNotShowMenu = false;
            CreateNewDoc();
            break;
          case '2':
            DoNotShowMenu = false;
            SetCurrDocMenu();
            break;
          case '3':
            DoNotShowMenu = false;
            PrintText();
            break;
          case '4':
            return true;
          default:
            ColorText("Введен недопустимый символ: " + Sw, 'e');
            DoNotShowMenu = true;
            break;
        }
      }
      catch
      {
        ColorText("Введен недопустимый символ.", 'e');
      }
      return false;
    }

    public void CreateNewDoc()
    {
      ColorText("Создание текста", 'i');
      ColorText("Назовите текст:", 'a');
      Console.Write(">> ");
      LoTVDoc Lst = new LoTVDoc(Console.ReadLine());
      DataBase.Add(Lst);
      CurrentDoc = Lst;
      bool GoodToGo = false;
      do
      {
        GoodToGo = AddTypeMenu();
      } while (GoodToGo);
      ColorText("Активный текст: " + CurrentDoc.Header, 'h');
    }

    public bool AddTypeMenu()
    {
      char Sw = ' ';
      ColorText("1. Добавить заголовок\n2. Добавить абзац.\n3. Добавить список.\n4. Закончить работу с текстом", 'a');
      try
      {
        Console.Write(">> ");
        Sw = Console.ReadLine().ToLower()[0];
        switch (Sw)
        {
          case '1':
            _AddText(1);
            break;
          case '2':
            _AddText(2);
            break;
          case '3':
            _AddList();
            break;
          case '4':
            return false;
          default:
            ColorText("Введен недопустимый символ: " + Sw, 'e');
            break;
        }
        return true;
      }
      catch
      {
        ColorText("Введен недопустимый символ.", 'e');
        return true;
      }
    }
    private void _AddText(int Type)
    {
      ColorText("Введите текст: ", 'i');
      CurrentDoc.AddDiv(Type, Console.ReadLine());
    }
    private void _AddList()
    {
      ColorText("Введите количество строк списка: ", 'i');
      int Num = 0;
      Console.Write(">> ");
      if (int.TryParse(Console.ReadLine(), out Num))
      {
        if (Num < 1)
          ColorText("Неподходящее количество элементов: " + Num, 'e');
        else
        {
          string[] Arr = new string[Num];
          for (int i = 0; i < Num; i++)
          {
            ColorText("Введите " + (i + 1) + " элемент списка: ", 'i');
            Console.Write(">> ");
            Arr[i] = Console.ReadLine();
          }
          CurrentDoc.AddDiv(3, Arr);
        }
      }
      else
        ColorText("Введен недопустимый символ", 'e');
    }

    public void SetCurrDocMenu()
    {
      if (DataBase.Count == 0)
        ColorText("Вам необходимо создать хотя бы один документ.\n", 'e');
      else
      {
        ColorText("Выберите текст: ", 'i');
        int Length = DataBase.Count;   //Получаем количество текстов
        ColorText("Список текстов: ", 'i');
        for (int i = 0; i < Length; i++)
          ColorText((i + 1) + ". " + DataBase[i].Header, 'h');
        do
          Console.Write(">> ");
        while (!_SetText(Length));
      }
    }
    private bool _SetText(int Length)
    {
      int TextNum = -1;
      if (int.TryParse(Console.ReadLine(), out TextNum))    //Проверка на численность
      {
        if (TextNum < 1 || TextNum > Length)   //Проверка на вхождение в интервал номеров
        {
          ColorText("Неподходящий номер: " + TextNum + '.', 'e');
          return false;
        }
        else
        {
          CurrentDoc = DataBase[TextNum - 1]; //Т.к. TextNum отображается увеличенным на 1
          ColorText("Активный текст: " + CurrentDoc.Header, 'h');
          return true;
        }
      }
      else
      {
        ColorText("Введено недопустимое значение", 'e');
        return false;
      }
    }
    public void PrintText()
    {
      if (CurrentDoc != null)
      {
        ColorText("Введите ширину форматирования (от 1 до 80):", 'a');
        int Width = 0, cols = 0;
        Console.Write(">> ");
        if (int.TryParse(Console.ReadLine(), out Width) && Width < 81 && Width > 0)
        {
          ColorText("На сколько колонок поделить текст?", 'a');
          Console.Write(">> ");
          if (int.TryParse(Console.ReadLine(), out cols) && cols < 4 && cols > 0)
            ColorText(CurrentDoc.Format(Width, cols), 'o');
        }
        else
          ColorText("Недопустимые значения: Ширина - " + Width + ", Колонки - " + cols, 'e');
      }
      else
        ColorText("Создайте хотя бы один текст для его форматирования", 'e');
    }
    public void ColorText(string Text, char color)
    {
      switch (color)
      {
        case 'a':
          Console.ForegroundColor = ConsoleColor.Cyan;
          break;
        case 'e':
          Console.ForegroundColor = ConsoleColor.Red;
          break;
        case 'i':
          Console.ForegroundColor = ConsoleColor.Yellow;
          break;
        case 'h':
          Console.ForegroundColor = ConsoleColor.Green;
          break;
        case 'o':
          Console.ForegroundColor = ConsoleColor.White;
          break;
      }
      Console.WriteLine(Text);
      Console.ResetColor();
    }
  }
}

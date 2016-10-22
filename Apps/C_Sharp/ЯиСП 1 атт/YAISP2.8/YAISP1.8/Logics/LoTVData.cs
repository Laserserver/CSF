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
  class LoTVDoc
  {
    private List<LoTVDiv> Divs;
    private bool _HasMultipleColumns = false;
    private int _ColumnsCount = 0;
    //======Открытые методы и поле
    public string Header;
    public LoTVDoc(string Header)
    {
      this.Header = Header;
      Divs = new List<LoTVDiv>();
    }
    public void LoTVDocAddText()
    {
      bool GoodToGo = false;
      char Sw = ' ';
      do
      {
        LoTVLogics.ColorText("1. Добавить заголовок\n2. Добавить абзац.\n3. Добавить колонку.\n4. Добавить список.", 'a');
        try
        {
          Console.Write(">> ");
          Sw = Console.ReadLine().ToLower()[0];
          LoTVDiv Div;
          switch (Sw)
          {
            case '1':
            case '2':
              LoTVLogics.ColorText("Введите текст: ", 'i');
              Div = new LoTVDiv(Console.ReadLine(), (Sw == 1 ? 1 : 2));
              Divs.Add(Div);
              GoodToGo = !AnotherDiv();
              break;
            case '3':
            case '4':
              GetInMultiple(Sw, out Div);
              GoodToGo = !AnotherDiv();
              break;
            default:
              LoTVLogics.ColorText("Введен недопустимый символ: " + Sw, 'e');
              break;
          }
        }
        catch
        {
          LoTVLogics.ColorText("Введен недопустимый символ.", 'e');
        }
      } while (!GoodToGo);
    }
    public string Format(int width) //==========Вот оно
    {
      if (_HasMultipleColumns && ((_ColumnsCount == 2 && width <= 2) || (_ColumnsCount == 3 && width <= 4)))  //Нужно проверку такую сложную
        return "Неподходящая ширина форматирования";
      else
      {
        string Out = "";
        int Length = Divs.Count;
        for (int i = 0; i < Length; i++)
        {
          int Type = Divs[i].LoTVDivReturnType();
          switch (Type)
          {
            case 1:
              Out += '\n' + __FormatText((string)Divs[i].LoTVDivReturnData(), width) + "\n\n";
              break;
            case 2:
              Out += _FormatArticle(width, Divs[i]) + "\n\n";
              break;
            case 3:
              Out += _FormatColumns(width, Divs[i]);
              break;
            case 4:
              Out += _FormatList(width, Divs[i]);
              break;
          }
        }
        return Out;
      }
    }
    //======Закрытые методы
    private bool AnotherDiv()
    {
      for (;;)  //=============Вечный цикл, да. Можно и while (true) do
      {
        LoTVLogics.ColorText("1. Добавить дополнительный элемент\n2. Закончить работу с этим текстом", 'a');
        try
        {
          Console.Write(">> ");
          char Ans = Console.ReadLine()[0];
          if (Ans == '1')
            return true;
          else if (Ans == '2')
            return false;
          else
            LoTVLogics.ColorText("Введен недопустимый символ: " + Ans, 'e');
        }
        catch
        {
          LoTVLogics.ColorText("Введен недопустимый символ.", 'e');
        }
      }
    }
    private void GetInMultiple(char Type, out LoTVDiv Div)
    {
      LoTVLogics.ColorText((Type == '3') ? "Введите количество колонок (от 1 до 3): " : "Введите количество строк списка: ", 'i');
      Div = null;
      int Num = 0; //Количество строк списка или количество колонок
      if (Type == '3')
      {
        if (Num > 1)
          _HasMultipleColumns = true;
        if (Num > _ColumnsCount)
          _ColumnsCount = Num;   //У документа максимальное число колонок должно быть прописано
      }
      Console.Write(">> ");
      if (int.TryParse(Console.ReadLine(), out Num))
      {
        if (Num < 1 || (Type == '3' && Num > 3))  //Обобщение интервала
          LoTVLogics.ColorText("Неподходящее количество элементов: " + Num, 'e');
        else
        {
          string[] Arr = new string[Num];
          for (int i = 0; i < Num; i++)
          {
            LoTVLogics.ColorText("Введите " + (i + 1) + (Type == '3' ? " колонку: " : " элемент списка: "), 'i');
            Console.Write(">> ");
            Arr[i] = Console.ReadLine();
          }
          Div = new LoTVDiv(Arr, Type == '3' ? 3 : 4);
          Divs.Add(Div);
        }
      }
      else
        LoTVLogics.ColorText("Введен недопустимый символ", 'e');
    }
    private string _FormatArticle(int width, LoTVDiv Article)
    {
      string Out = "   ";
      Out = __FormatText(Out + Article.LoTVDivReturnData(), width);
      return Out;
    }
    private string __FormatText(string Text, int width)
    {
      int Mult = Text.Length / width + 1;
      for (int i = 1; i < Mult; i++)
        Text = Text.Insert(width * i + i - 1, "\n");
      return Text;
    }
    private string _FormatColumns(int width, LoTVDiv Columns)
    {
      string Out = "";
      string[] Arr = (string[])Columns.LoTVDivReturnData();
      int Cols = Arr.Length; //Количество колонок
      int MaxLength = 0;  //Макс длина колонки
      int MaxCol = 0;
      if (Cols != 1)
        for (int i = 0; i < Cols; i++)
        {
          int Length = Arr[i].Length;
          if (Length >= MaxLength)     //Так сложно чтобы обращаться к методу N раз, а не 2N
          {
            MaxLength = Length;
            MaxCol = i;
          }
        }
      switch (Cols)
      {
        case 1:
          return __FormatText(Arr[0], width);
        case 2:
        case 3:
          int Text1 = 0, SpaceCount = 0, Text2 = 0;
          __GetTextSpaceRatio(out Text1, out Text2, out SpaceCount, width, Cols);  //========================Здесь творится самая главная магия
          int Mult; //Кол-во строк
          string Arr0, Arr1;
          string Spaces = "";
          for (int i = 0; i < SpaceCount; i++)
            Spaces += ' ';
          Arr0 = Arr[0];
          Arr1 = Arr[1];   //Тут чорная магия для неизменения блоков данных
          //MaxCol = Arr0.Length >= Arr1.Length ? 0 : 1;
          if (Cols == 2)
          {
            int Text2Length = 0;
            int MinCol = 1 - MaxCol;
            bool Flag = MaxCol == 0;
            if (Flag)
              while (Arr0.Length % Text1 != 0)    //Добиваем с самой большой длиной до кратного TextN
                Arr0 += ' ';
            else
              while (Arr1.Length % Text2 != 0)
                Arr1 += ' ';
            MaxLength = (Flag ? Arr0 : Arr1).Length; //Чорная магия
            Mult = MaxLength / (MaxCol == 0 ? Text1 : Text2);  //Получает мультипликатор кратности
            Text2Length = Mult * (MaxCol == 0 ? Text2 : Text1);     //Путем хитрых вычислений получаем кратную длину для второго текста, зависящую от ширины формата
            if (Flag)
              while (Arr1.Length != Text2Length)    //Добиваем в другую сторону
                Arr1 += ' ';
            else
              while (Arr0.Length != Text2Length)
                Arr0 += ' ';
            for (int i = 0; i < Mult; i++)
              Out += Arr0.Substring(i * Text1, Text1) + Spaces + Arr1.Substring(i * Text2, Text2) + '\n';  //Ну тутай опять же магия
          }
          else
          {
            string[] NewArr = new string[] {Arr0, Arr1, Arr[2] };
            while (NewArr[MaxCol].Length % ((MaxCol == 0 || MaxCol == 2) ? Text1 : Text2) != 0) //Брррррррррр
            {
              NewArr[MaxCol] += ' ';
              MaxLength++;
            }
            Mult = MaxLength / ((MaxCol == 0 || MaxCol == 2) ? Text1 : Text2);  //Получает мультипликатор кратности
            int Text2Length = Mult * ((MaxCol == 0 || MaxCol == 2) ? Text2 : Text1);
            if (MaxCol == 1)
            {
              while (NewArr[0].Length != Text2Length)
                NewArr[0] += ' ';
              while (NewArr[2].Length != Text2Length)
                NewArr[2] += ' ';
            }
            else
            {
              while (NewArr[1].Length != Text2Length)
                NewArr[1] += ' ';
              if (MaxCol == 0)
                while (NewArr[2].Length != MaxLength)
                  NewArr[2] += ' ';
              else
                while (NewArr[0].Length != MaxLength)
                  NewArr[0] += ' ';
            }
            for (int i = 0; i < Mult; i++)
              Out += NewArr[0].Substring(i * Text1, Text1) +
                Spaces + NewArr[1].Substring(i * Text2, Text2) +
                Spaces + NewArr[2].Substring(i * Text1, Text1) + '\n';  //Ну тутай опять же магия
          }
          return Out;
      }
      return Out;
    }
    private void __GetTextSpaceRatio(out int Text1, out int Text2, out int Space, int Width, int Columns)
    {
      Text1 = Text2 = 0;
      Space = 0;
      switch (Columns)
      {
        case 2:
          if (Width < 16)
          {
            int NumTr = (Width + 1) / 3 * 11;
            switch (Width % 3)
            {
              case 1:
                NumTr++;
                break;
              case 2:
                NumTr--;
                break;
            }
            Text1 = Text2 = NumTr / 10;
            Space = NumTr % 10;
          }
          else
          {
            Space = 5;  //С 16 элемента он остается постоянным
            int NDi = (Width - 4) / 2;
            Text1 = NDi;
            NDi = NDi * (NDi > 9 ? 1001 : 101) + (Width - 4) % NDi - 1;   //Сложный перерасчет
            Text2 = NDi % (Text1 < 10 ? 10 : 100);
          }
          break;
        case 3:
          if (Width < 10)
          {
            Text1 = 1;
            Space = Width / 7 == 1 ? 2 : 1;
            Text2 = Width - Width / 7 == 1 ? 6 : 4;
          }
          else
          {
            if (Width < 19)
            {
              Text1 = 2;
              Space = (Width - 4) / 3;
              Text2 = Width - 2 * ((Width + 1) / 3);   //Это полная ж с законами изменения
            }
            else
            {
              Text1 = (Width + 2) / 3 - 3;     //Возьми черновики чтобы объяснить
              Space = 4;
              Text2 = Width - 2 * (Width / 3);
            }
          }
          break;
      }

    }
    private string _FormatList(int width, LoTVDiv List)
    {
      string Out = "";
      string[] Arr = (string[])List.LoTVDivReturnData();
      int Cols = Arr.Length;
      for (int i = 0; i < Cols; i++)
      {
        if (Arr[i].Length + 3 < width)
          Out += i + 1 + ". " + Arr[i] + '\n';
        else
        {
          string Row = i + 1 + ". " + Arr[i];
          int Mult = Row.Length / width + 1;
          for (int k = 1; k < Mult; k++)
          {
            Row = Row.Insert(width * k + k - 1, "\n"); //k добавляется как дополнительные \n, поэтому -1
            Mult = Row.Length / width + (Row.Length % Mult == 0 ? 0 : 1);
          }
          Out += Row + '\n';
        }
      }
      return Out;
    }

    private class LoTVDiv
    {
      private object Data;
      private int Type;
      public LoTVDiv(object Data, int Type)
      {
        this.Type = Type; //1 - абзац, 2 - колонки, 3 - список
        this.Data = Data;
      }
      public int LoTVDivReturnType()
      {
        return Type;
      }
      public object LoTVDivReturnData()
      {
        return Data;
      }
    }
  }
}
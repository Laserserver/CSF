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
    //======Открытые методы и название текста
    public string Header;
    public LoTVDoc(string Header)
    {
      this.Header = Header;
      Divs = new List<LoTVDiv>();
    }
    public void AddDiv(int Type, object Data)
    {
      Divs.Add(new LoTVDiv(Data, Type));
    }
    public string Format(int width, int cols)
    {
      if ((cols == 2 && width <= 2) || (cols == 3 && width <= 4))
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
            case 2:
              Out += "   " + (string)Divs[i].LoTVDivReturnData();// + '\n';
              break;
            case 3:
              Out += _FormatList(Divs[i]);
              break;
          }
        }
        switch (cols)
        {
          case 1:
            return _FormatText(Out, width);
          default:
            int Text1 = 0, Text2 = 0, Space = 0;
            __GetTextSpaceRatio(out Text1, out Text2, out Space, width, cols);
            Length = Out.Length;
            string[] Cols = new string[cols];
            if (cols == 2)
            {
              Cols[0] = /*RemoveNullEntries(*/Out.Substring(0, Length / cols);//, Text1);
              Cols[1] = /*RemoveNullEntries(*/Out.Substring(Length / cols, Length / cols - 1);//, Text2);
              return _FormatTwoColumns(Text1, Space, Text2, Cols);
            }
            else
            {
              int Rows = Length / (Text1 + Text2 + 1);  //Параметрический закон доступности формата
              int Mult1 = (Rows + 1) * Text1, Mult2 = Rows * Text2;

              if (Length >= Rows * (Text2 + Text1) + 1 && Length <= Rows * (Text2 + Text1 + Text1))
              {
                Cols[0] = /*RemoveNullEntries(*/Out.Substring(0, Mult1);//, Text1);
                Cols[1] = /*RemoveNullEntries(*/Out.Substring(Mult1, Mult2 + 2);//, Text2);
                Cols[2] = /*RemoveNullEntries(*/Out.Substring(Mult1 + Mult2 + 2, Length - Mult1 - Mult2 - 2);//, Text1);
                return _FormatThreeColumns(Text1, Space, Text2, Cols);
              }
              else
                return "Неподходящая ширина форматирования";
            }
        }
      }
    }
    //======Закрытые методы
    private string _FormatText(string Text, int width)
    {
      int Mult = Text.Length / width + 1;
      for (int i = 1; i < Mult; i++)
        Text = Text.Insert(width * i + i - 1, "\n");
      return Text;
    }    //Форматирует именно простую строку
  /*  private string RemoveNullEntries(string Input, int Step)
    {
      string Spaces = "";
      bool flag = true;
      for (int k = 0; k < Step; k++)
        Spaces += ' ';
      Input = Input.Replace("\u0000", Spaces);
      while (Input.Length % Step != 0)    //Добиваем с самой большой длиной до кратного
        Input += ' ';
      string Output = "";
      int Length = Input.Length;
      string Substr = "";
      int DrawBack = 0;
      for (int i = 0; i < Length; i += Step - DrawBack)
      {
        DrawBack = 0;
        Substr = Input.Substring(i - DrawBack, Step);
        if (!flag)
        {
          if (Substr[0] == ' ')
          {
            int k = 0;
            while (Substr.Length != k && Substr[k++] == ' ')
              DrawBack++;
          }
          Substr = Substr.TrimStart();
        }
        flag = false;
        Output += Substr;
      }
      return Output;
    }*/
    private string _FormatTwoColumns(int Text1, int SpaceCount, int Text2, string[] Columns)
    {
      string Out = "";
      int MaxLength = 0;  //Макс длина колонки
      int MaxCol = 0;
      for (int i = 0; i < 2; i++)
      {
        int Length = Columns[i].Length;
        if (Length >= MaxLength)
        {
          MaxLength = Length;
          MaxCol = i;
        }
      }
      int Mult; //Кол-во строк
      string Spaces = "";
      for (int i = 0; i < SpaceCount; i++)
        Spaces += ' ';
      int Text2Length = 0;
      int MinCol = 1 - MaxCol;   //Определение макс колонки
                                 //===================
      bool Flag = MaxCol == 0;
      if (Flag)
        while (Columns[0].Length % Text1 != 0)    //Добиваем с самой большой длиной до кратного TextN
          Columns[0] += ' ';
      else
        while (Columns[1].Length % Text2 != 0)
          Columns[1] += ' ';
      //===================
      MaxLength = (Flag ? Columns[0] : Columns[1]).Length;
      Mult = MaxLength / (MaxCol == 0 ? Text1 : Text2);  //Получает мультипликатор кратности
      Text2Length = Mult * (MaxCol == 0 ? Text2 : Text1);     //Получаем кратную длину для второго текста, зависящую от ширины формата
      if (Flag)
        while (Columns[1].Length != Text2Length)    //Добиваем в другую сторону
          Columns[1] += ' ';
      else
        while (Columns[0].Length != Text2Length)
          Columns[0] += ' ';
      for (int i = 0; i < Mult; i++)
        Out += Columns[0].Substring(i * Text1, Text1) + Spaces + Columns[1].Substring(i * Text2, Text2) + '\n';
      return Out;
    }
    private string _FormatThreeColumns(int Text1, int SpaceCount, int Text2, string[] Columns)
    {
      string Out = "";
      string Spaces = "";
      for (int i = 0; i < SpaceCount; i++)
        Spaces += ' ';
      int MaxRows = 0;
      for (int i = 0; i < 3; i++)
      {
        while (Columns[i].Length % (i == 1 ? Text2 : Text1) != 0)    //Добиваем до кратного TextN
          Columns[i] += ' ';                                         //Обойтись без постоянных вызовов .Length нельзя
        int Rows = Columns[i].Length / (i == 1 ? Text2 : Text1);
        if (Rows >= MaxRows)
          MaxRows = Rows;
      }
      for (int i = 0; i < 3; i++)

        while (Columns[i].Length / (i == 1 ? Text2 : Text1) != MaxRows)    //Добиваем до кратного TextN
          Columns[i] += ' ';

      for (int i = 0; i < MaxRows; i++)
        Out += Columns[0].Substring(i * Text1, Text1) +
          Spaces + Columns[1].Substring(i * Text2, Text2) +
          Spaces + Columns[2].Substring(i * Text1, Text1) + '\n';
      return Out;
    }
    /* private string _FormatColumns(int width, string[] Columns)
     {
       string Out = "";
       int Cols = Columns.Length; //Количество колонок
       int MaxLength = 0;  //Макс длина колонки
       int MaxCol = 0;
       if (Cols != 1)
         for (int i = 0; i < Cols; i++)
         {
           int Length = Columns[i].Length;
           if (Length >= MaxLength)
           {
             MaxLength = Length;
             MaxCol = i;
           }
         }
       switch (Cols)
       {
         case 2:
         case 3:
           int Text1 = 0, SpaceCount = 0, Text2 = 0;
           __GetTextSpaceRatio(out Text1, out Text2, out SpaceCount, width, Cols);  //Получение соотношения текста и пробелов
           int Mult; //Кол-во строк
           string Spaces = "";
           for (int i = 0; i < SpaceCount; i++)
             Spaces += ' ';
           if (Cols == 2)
           {
             int Text2Length = 0;
             int MinCol = 1 - MaxCol;
             bool Flag = MaxCol == 0;
             if (Flag)
               while (Columns[0].Length % Text1 != 0)    //Добиваем с самой большой длиной до кратного TextN
                 Columns[0] += ' ';
             else
               while (Columns[1].Length % Text2 != 0)
                 Columns[1] += ' ';
             MaxLength = (Flag ? Columns[0] : Columns[1]).Length;
             Mult = MaxLength / (MaxCol == 0 ? Text1 : Text2);  //Получает мультипликатор кратности
             Text2Length = Mult * (MaxCol == 0 ? Text2 : Text1);     //Получаем кратную длину для второго текста, зависящую от ширины формата
             if (Flag)
               while (Columns[1].Length != Text2Length)    //Добиваем в другую сторону
                 Columns[1] += ' ';
             else
               while (Columns[0].Length != Text2Length)
                 Columns[0] += ' ';
             for (int i = 0; i < Mult; i++)
               Out += Columns[0].Substring(i * Text1, Text1) + Spaces + Columns[1].Substring(i * Text2, Text2) + '\n';
           }
           else
           {
             while (Columns[MaxCol].Length % ((MaxCol == 0 || MaxCol == 2) ? Text1 : Text2) != 0)
             {
               Columns[MaxCol] += ' ';
               MaxLength++;
             }
             Mult = MaxLength / ((MaxCol == 0 || MaxCol == 2) ? Text1 : Text2);  //Получает мультипликатор кратности
             int Text2Length = Mult * ((MaxCol == 0 || MaxCol == 2) ? Text2 : Text1); //!!!!!!!!!!!!!!!!!!!
             if (MaxCol == 1)
             {
               while (Columns[0].Length < Text2Length)
                 Columns[0] += ' ';
               while (Columns[2].Length < Text2Length)
                 Columns[2] += ' ';
             }
             else
             {
               while (Columns[1].Length != Text2Length)
                 Columns[1] += ' ';
               if (MaxCol == 0)
                 while (Columns[2].Length != MaxLength)
                   Columns[2] += ' ';
               else
                 while (Columns[0].Length != MaxLength)
                   Columns[0] += ' ';
             }
             for (int i = 0; i < Mult; i++)
               Out += Columns[0].Substring(i * Text1, Text1) +
                 Spaces + Columns[1].Substring(i * Text2, Text2) +
                 Spaces + Columns[2].Substring(i * Text1, Text1) + '\n';
           }
           return Out;
       }
       return Out;
     }*/
    private void __GetTextSpaceRatio(out int Text1, out int Text2, out int Space, int Width, int Columns)
    {
      Text1 = Text2 = 0;
      Space = 0;
      switch (Columns)   //Параметрические законы изменения ширин текстов
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
            Space = 5;
            int NDi = (Width - 4) / 2;
            Text1 = NDi;
            NDi = NDi * (NDi > 9 ? 1001 : 101) + (Width - 4) % NDi - 1;
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
              Text2 = Width - 2 * ((Width + 1) / 3);
            }
            else
            {
              Text1 = (Width + 2) / 3 - 3;
              Space = 4;
              switch ((Width + 2) % 3)
              {
                case 0:
                  Text2 = Text1 - 1;
                  break;
                case 1:
                  Text2 = Text1;
                  break;
                case 2:
                  Text2 = Text1 + 1;
                  break;
              }
            }
          }
          break;
      }

    }  //Параметрические законы ширины
    private string _FormatList(LoTVDiv List)
    {
      string Out = "   ";
      string[] Arr = (string[])List.LoTVDivReturnData();
      int Cols = Arr.Length;
      for (int i = 0; i < Cols; i++)
        Out += i + 1 + ". " + Arr[i] + "   ";  //!!!!!
      return Out;
    }

    private class LoTVDiv
    {
      private object Data;
      private int Type;
      public LoTVDiv(object Data, int Type)
      {
        this.Type = Type; //1 - заголовок, 2 - абзац, 3 - список
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
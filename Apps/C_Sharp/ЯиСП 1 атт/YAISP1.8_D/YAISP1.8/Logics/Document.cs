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
    public bool _HasMultipleColumns = false;
    public int _ColumnsCount = 0;
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
    public string Format(int width)
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
              Out += _FormatColumns(width, Divs[i]) + '\n';
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
          if (Length >= MaxLength)
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
          __GetTextSpaceRatio(out Text1, out Text2, out SpaceCount, width, Cols);  //Получение соотношения текста и пробелов
          int Mult; //Кол-во строк
          string Arr0, Arr1;
          string Spaces = "";
          for (int i = 0; i < SpaceCount; i++)
            Spaces += ' ';
          Arr0 = Arr[0];
          Arr1 = Arr[1];   
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
            MaxLength = (Flag ? Arr0 : Arr1).Length; 
            Mult = MaxLength / (MaxCol == 0 ? Text1 : Text2);  //Получает мультипликатор кратности
            Text2Length = Mult * (MaxCol == 0 ? Text2 : Text1);     //Получаем кратную длину для второго текста, зависящую от ширины формата
            if (Flag)
              while (Arr1.Length != Text2Length)    //Добиваем в другую сторону
                Arr1 += ' ';
            else
              while (Arr0.Length != Text2Length)
                Arr0 += ' ';
            for (int i = 0; i < Mult; i++)
              Out += Arr0.Substring(i * Text1, Text1) + Spaces + Arr1.Substring(i * Text2, Text2) + '\n';  
          }
          else
          {
            string[] NewArr = new string[] { Arr0, Arr1, Arr[2] };
            while (NewArr[MaxCol].Length % ((MaxCol == 0 || MaxCol == 2) ? Text1 : Text2) != 0) 
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
                Spaces + NewArr[2].Substring(i * Text1, Text1) + '\n';  
          }
          return Out;
      }
      return Out;
    }   
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
              switch((Width + 2)%3)
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
            Mult = Row.Length / width + 1;
          }
          Out += Row + '\n';
        }
      }
      return Out + '\n';
    }

    private class LoTVDiv
    {
      private object Data;
      private int Type;
      public LoTVDiv(object Data, int Type)
      {
        this.Type = Type; //1 - заголовок, 2 - абзац, 3 - колонки, 4 - список
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
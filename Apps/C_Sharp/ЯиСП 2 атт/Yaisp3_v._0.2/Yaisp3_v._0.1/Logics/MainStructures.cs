using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3_v._0._1
{
  class MainStructures
  {
    public enum Strategies
    {
      Conservative = 1,
      Normal,
      Aggressive
    }
    public class Agency
    {
      Strategies agencyStrategy;
      string agencyName;
      int agencyDeposit;
      int agencyBillboardsCount;

      public Agency(string Name, int Money, int Billboards, Strategies Strategy)
      {
        agencyName = Name;
        agencyDeposit = Money;
        agencyBillboardsCount = Billboards;
        agencyStrategy = Strategy;
      }

      public void GetData(out string Name, out int Money, out int Billboards, out Strategies Strategy)
      {
        Name = agencyName;
        Money = agencyDeposit;
        Billboards = agencyBillboardsCount;
        Strategy = agencyStrategy;
      }
      public void ChangeMainData(string Name, Strategies Strategy)
      {
        agencyName = Name;
        agencyStrategy = Strategy;
      }

    }
    public class City
    {
      private string cityName;
      private int[,] cityMatrix;

      public City(string Name, int[,] Matrix)
      {
        cityMatrix = Matrix;
        cityName = Name;
      }
      public int[,] GetDrawingData()
      {
        return cityMatrix;
      }
      public string GetName()
      {
        return cityName;
      }
      public void PlaceHouse(int X00, int Y00, int RightWidth, int DownDepth)
      {
        for (int i = Y00; i <= RightWidth; i++)
          for (int j = X00; j <= DownDepth; j++)
            cityMatrix[i, j] = 1;
      }
      public bool TryToPlaceHouse(int X00, int Y00, int RightWidth, int DownDepth)
      {  //Проверка на доступность постройки здания
        for (int i = Y00; i <= RightWidth; i++)
          for (int j = X00; j <= DownDepth; j++)
            if (cityMatrix[i, j] != 0)
              return false;
        return true;
      }
    }
    protected class Client
    {
      protected Client()
      {

      }
    }

  }
}

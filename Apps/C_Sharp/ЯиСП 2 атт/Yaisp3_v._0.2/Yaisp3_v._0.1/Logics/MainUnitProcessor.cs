using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3_v._0._1
{
  public static class MainUnitProcessor
  {
    private static MainStructures.Agency Agency = null;
    private static MainStructures.City City = null;
    private static DateTime CurrentDate = new DateTime(1970, 1, 1);

    public static void MainReset()
    {
      Agency = null;
      City = null;
      CurrentDate = new DateTime(1970, 1, 1);
    }

    public static bool CityIsPresent()
    {
      return City != null;
    }
    public static void CityCreate(int[,] Matrix, string Name)
    {
      City = new MainStructures.City(Name, Matrix);
    }
    public static int[,] CityGetDrawingData()
    {
      return City.GetDrawingData();
    }
    public static bool CityIsHouseCanBePlaced(int X00, int Y00, int RightWidth, int DownDepth)
    {
      return City.TryToPlaceHouse(X00, Y00, RightWidth, DownDepth);
    }
    public static string CityGetName()
    {
      return City.GetName();
    }

    public static bool AgencyCreate(string Name, string Money, string Billboards, int Strategy)
    {
      int Mon = 0, Bb = 0;
      if (Name != null && Name != "")
        if (int.TryParse(Money, out Mon) && int.TryParse(Billboards, out Bb) && Mon > 0 && Bb > 0)
        {
          Agency = new MainStructures.Agency(Name, Mon, Bb, (MainStructures.Strategies)Strategy);
          return true;
        }
        else
          return false;
      return false;
    }
    public static bool AgencyIsPresent()
    {
      return Agency != null;
    }
    public static void AgencyDestroy()
    {
      Agency = null;
    }
    public static void AgencyGetData(out string Name, out int Money, out int Billboards, out int Strategy)
    {
      MainStructures.Strategies Strat;
      Agency.GetData(out Name, out Money, out Billboards, out Strat);
      Strategy = (int)Strat;
    }
    public static void AgencyChangeData(string Name, int Strategy)
    {
      Agency.ChangeMainData(Name, (MainStructures.Strategies)Strategy);
    }

    public static void DateNewDay()
    {
      CurrentDate.AddDays(1);
    }
    public static string DateGetAsString()
    {
      return CurrentDate.ToShortDateString();
    }
  }
}

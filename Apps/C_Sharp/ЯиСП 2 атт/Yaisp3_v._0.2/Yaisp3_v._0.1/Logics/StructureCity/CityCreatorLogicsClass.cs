using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3_v._0._1
{
  class CityCreatorLogicsClass
  {
    private int[,] cityMatrix;
    private string cityName;
    private DrawingClassCityCreator cityDrawingKit;

    public CityCreatorLogicsClass(int Height, int Width, string Name, System.Windows.Forms.Control Control)
    {
      cityMatrix = new int[Height, Width];
      cityName = Name;
      cityDrawingKit = new DrawingClassCityCreator(Control, Width, Height);
      ClearImage();
      MainDraw();
    }
    public CityCreatorLogicsClass(System.Windows.Forms.Control Control)
    {
      cityMatrix = MainUnitProcessor.CityGetDrawingData();
      cityName = MainUnitProcessor.CityGetName();
      cityDrawingKit = new DrawingClassCityCreator(Control, cityMatrix.GetLength(1), cityMatrix.GetLength(0));
      ClearImage();
      MainDraw();
    }

    public void DrawHousi()
    {
      int Rows = cityMatrix.GetLength(0), Cols = cityMatrix.GetLength(1);
      for (int i = 0; i < Rows; i++)
        for (int j = 0; j < Cols; j++)
          if (cityMatrix[i, j] == 1)
            cityDrawingKit.DrawCityElement(i, j);
    }
    public void DrawGrid()
    {
      cityDrawingKit.DrawGrid();
    }
    public void DrawOverallImage()
    {
      cityDrawingKit.DrawImage();
    }

    private void ClearImage()
    {
      cityDrawingKit.ClearCanvas();
    }

    public void DestroyCreator()
    {
      cityDrawingKit.ClearCanvas();
      cityDrawingKit.DrawImage();
      cityDrawingKit.DropBitm();
    }
    public void DrawCurrentObject(int X, int Y, int Width, int Height)
    {
      cityDrawingKit.ClearCanvas();
      DrawHousi();
      cityDrawingKit.DrawCurrentObject(X, Y, Width, Height);
      DrawGrid();
      DrawOverallImage();
    }
    public void MoveImage(int XN, int YN, int XO, int YO)
    {
      cityDrawingKit.ClearCanvas();
      cityDrawingKit.Move(XN, YN, XO, YO);
      MainDraw();
    }
    public void ZoomImage(int X, int Y, int Delta)
    {
      cityDrawingKit.ClearCanvas();
      cityDrawingKit.Zoom(X, Y, Delta);
      MainDraw();
    }
    public void MainDraw()
    {
      DrawHousi();
      DrawGrid();
      DrawOverallImage();
    }

    public void AddElementToMatrix(int X, int Y, int Width, int Height)
    {
      int Row, Col;
      if (cityDrawingKit.FindPlaceInMatrix(X, Y, out Row, out Col))
        if (CanElementBePlaced(Row, Col, Width, Height))
          for (int i = Row; i < Row + Height; i++)
            for (int j = Col; j < Width + Col; j++)
              cityMatrix[i, j] = 1;
      ClearImage();
      MainDraw();
    }
    public bool CanElementBePlaced(int Row, int Col, int Width, int Height)
    {
      for (int i = Row; i < Row + Height; i++)
        for (int j = Col; j < Width + Col; j++)
          if (cityMatrix[i, j] == 1)
            return false;
      return true;
    }
    public void LoadMatrix()
    {
      cityMatrix = MainUnitProcessor.CityGetDrawingData();
    }
    public void CreateCity()
    {
      MainUnitProcessor.CityCreate(cityMatrix, cityName);
    }
    public int[,] GetDrawData()
    {
      return cityMatrix;
    }
  }
}

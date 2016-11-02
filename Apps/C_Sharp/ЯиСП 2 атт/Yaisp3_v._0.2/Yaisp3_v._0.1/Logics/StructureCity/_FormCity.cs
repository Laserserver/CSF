using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yaisp3_v._0._1
{
  public partial class _FormCity : Form
  {
    bool moving = false;
    bool drawing = false;
    bool loaded = true;
    MouseEventArgs e0;
    CityCreatorLogicsClass CityCreationKit;
    public _FormCity()
    {
      InitializeComponent();
      MouseWheel += new MouseEventHandler(_ctrlPicBxMap_MouseScroll);
    }
    private void _ctrlPicBxMap_MouseScroll(object sender, MouseEventArgs e)
    {
      if (CityCreationKit != null)
      {
        CityCreationKit.ZoomImage(e.X, e.Y, e.Delta);
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      /*CityDrawingKit = new DrawingClassCityCreator(_ctrlPicBxCity, (int)(_ctrlNumCityWidth.Value), (int)(_ctrlNumCityHeight.Value));
      CityDrawingKit.ClearCanvas();*/
      CityCreationKit = new CityCreatorLogicsClass((int)(_ctrlNumCityWidth.Value), (int)(_ctrlNumCityHeight.Value), _ctrlTxbCityName.Text, _ctrlPicBxCity);
      //CityCreationKit.MainDraw();
    }
    /*private void MainDraw()
    {
      int[,] Matrix = CityCreationKit.GetDrawData();
      int Rows = Matrix.GetLength(0), Cols = Matrix.GetLength(1);
      for (int i = 0; i < Rows; i++)
        for (int j = 0; j < Cols; j++)
          if (Matrix[i, j] == 1)
            CityDrawingKit.DrawCityElement(i, j);
      CityDrawingKit.DrawGrid();
      CityDrawingKit.DrawImage();
    }*/

    private void _ctrlPicBxCity_MouseDown(object sender, MouseEventArgs e)
    {
      if (CityCreationKit != null)
      {
        if (e.Button == MouseButtons.Right)
        {
          moving = true;
          e0 = e;
        }
        if (e.Button == MouseButtons.Left && drawing)
        {
          //int i, j;
          //if (CityDrawingKit.FindPlaceInMatrix(e.X, e.Y, out i, out j))
          //  if (CityCreationKit.CanElementBePlaced(i, j, (int)_ctrlNumHouseWidth.Value, (int)_ctrlNumHouseHeigth.Value))
          //    CityCreationKit.AddElementToMatrix(i, j, (int)_ctrlNumHouseWidth.Value, (int)_ctrlNumHouseHeigth.Value);
          CityCreationKit.AddElementToMatrix(e.X, e.Y, (int)(_ctrlNumHouseWidth.Value), (int)(_ctrlNumHouseHeigth.Value));
          drawing = false;
        }
      }
    }
    private void _ctrlPicBxCity_MouseUp(object sender, MouseEventArgs e)
    {
      moving = false;
    }
    private void _ctrlPicBxCity_MouseMove(object sender, MouseEventArgs e)
    {
      if (CityCreationKit != null)
      {
        if (moving)
        {
          CityCreationKit.MoveImage(e.X, e.Y, e0.X, e0.Y);
          e0 = e;
        }
        if (drawing)
        {
          CityCreationKit.DrawCurrentObject(e.X, e.Y, (int)_ctrlNumHouseWidth.Value, (int)_ctrlNumHouseHeigth.Value);
          //if (e.X > 447 || e.Y > 447 || e.X < 5 || e.Y < 5)
          //{
          //  drawing = false;
          //  CityCreationKit.ClearCanvas();
          //}
        }
      }
    }

    private void _ctrlButHouse_Click(object sender, EventArgs e)
    {
      drawing = true;
    }

    private void _ctrlReset_Click(object sender, EventArgs e)
    {
      CityCreationKit.DestroyCreator();
    }

    private void _ctrlButReady_Click(object sender, EventArgs e)
    {
      CityCreationKit.CreateCity();
      CityCreationKit.DestroyCreator();
      CityCreationKit = null;
      bool a = MainUnitProcessor.CityIsPresent();
      loaded = false;
      Close();
    }

    private void _FormCity_Load(object sender, EventArgs e)
    {
      if (MainUnitProcessor.CityIsPresent())
      {
        if (!loaded)
        {
          CityCreationKit = new CityCreatorLogicsClass(_ctrlPicBxCity);
          loaded = true;
        }
      }
    }
  }
}

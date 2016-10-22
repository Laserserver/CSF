using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WPFGraphics
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    LoTVModel Mdl;
    int RadSpeed = 1;

    public MainWindow()
    {
      InitializeComponent();
      
    }

    private void TakeObject()
    {
      OpenFileDialog ofd = new OpenFileDialog();
      if (ofd.ShowDialog() == true)
        Mdl.Parse(File.ReadAllText(ofd.FileName));
    }
    public Point3D getPositionTor(double R, double r, double a, double v)
    {

      double sinB = Math.Sin(Math.PI / 180);
      double cosB = Math.Cos(Math.PI / 180);
      double sinA = Math.Sin(Math.PI / 180);
      double cosA = Math.Cos(Math.PI / 180);

      Point3D point = new Point3D();
      point.X = (R + r * cosA) * cosB;
      point.Y = r * sinA;
      point.Z = -(R + r * cosA) * sinB;

      return point;
    }
    public static void drawTriangle(
            Point3D p0, Point3D p1, Point3D p2, Color color, Viewport3D viewport)
    {
      MeshGeometry3D mesh = new MeshGeometry3D();

      mesh.Positions.Add(p0);
      mesh.Positions.Add(p1);
      mesh.Positions.Add(p2);

      mesh.TriangleIndices.Add(0);
      mesh.TriangleIndices.Add(1);
      mesh.TriangleIndices.Add(2);

      SolidColorBrush brush = new SolidColorBrush();
      brush.Color = color;
      Material material = new DiffuseMaterial(brush);

      GeometryModel3D geometry = new GeometryModel3D(mesh, material);
      ModelUIElement3D model = new ModelUIElement3D();
      model.Model = geometry;

      viewport.Children.Add(model);
    }
    public void drawTor(Point3D center, double R, double r, int N, int n, Color color)
    {
      if (n < 2 || N < 2)
      {
        return;
      }

      Model3DGroup tor = new Model3DGroup();
      Point3D[,] points = new Point3D[N, n];

      for (int i = 0; i < N; i++)
      {
        for (int j = 0; j < n; j++)
        {
          points[i, j] = getPositionTor(R, r, i * 360 / (N - 1), j * 360 / (n - 1));
          points[i, j] += (Vector3D)center;
        }
      }

      Point3D[] p = new Point3D[4];
      for (int i = 0; i < N - 1; i++)
      {
        for (int j = 0; j < n - 1; j++)
        {
          p[0] = points[i, j];
          p[1] = points[i + 1, j];
          p[2] = points[i + 1, j + 1];
          p[3] = points[i, j + 1];
          drawTriangle(p[0], p[1], p[2], color, mainViewport);
          drawTriangle(p[2], p[3], p[0], color, mainViewport);

        }
      }
    }
    private void _ctrlBaton_Click(object sender, RoutedEventArgs e)
    {
     drawTor(new Point3D(0, 0, 0), 1.0, 0.3, 20, 15, Colors.Tomato);
      /*Mdl = new LoTVModel();
      TakeObject();
      
      Mdl.I2 = (int)_ctrlCanvas.Width;
      Mdl.J2 = (int)_ctrlCanvas.Height;
      MyDraw();
    }
    private void MyDraw()
    {
      /*_ctrlCanvas.Children.Clear();
      Mdl.Draw();
      for (int i = 0; i < Mdl.LLength; i++)
        _ctrlCanvas.Children.Add(Mdl.Lines[i]);*/
    }

    private void _ctrlRadX_Checked(object sender, RoutedEventArgs e)
    {
      if (Mdl != null)
        Mdl.AxisTurn = Convert.ToByte((sender as RadioButton).Tag);
    }
    private void _ctrlSlider_DragLeave(object sender, DragEventArgs e)
    {
      RadSpeed = (int)_ctrlSlider.Value;
    }

    private void _ctrlCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
    {
      /*if (Mdl != null)
      {
        //Mdl.ChangeWindowXY(e.X,e.Y, e.Delta);
        double Rad = RadSpeed * Math.PI / 180;
        Mdl.Angle = e.Delta > 0 ? -Rad : Rad;
        MyDraw();
      }*/
    }
  }
}

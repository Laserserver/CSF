using System;
using System.Drawing;

namespace Render
{
  public class ModelClass
  {
    public double xRotation = 0.0;
    public double yRotation = 0.0;
    public double zRotation = 0.0;
    private byte AxisTurning;
    public Bitmap Canv;
    public double[] LightVector;
    public double Zoom;
    public double ZoomCoeff;
    public byte ZoomAxis;

    public double[] _camera;
    public Structures.MyPoint[] points;
    public Structures.MyEdge[] edges;
    public Structures.MyPolygon[] polygons;
    public Structures.MyPoint[] normals;
    public int normLength;
    public int pointsLength;
    public int edgeLength;
    public int polygonLength;

    public ModelClass()
    {
      points = new Structures.MyPoint[0];
      pointsLength = 0;
      edges = new Structures.MyEdge[0];
      edgeLength = 0;
      polygons = new Structures.MyPolygon[0];
      LightVector = new double[3] { 0, 0, 1 };
      polygonLength = 0;
      normals = new Structures.MyPoint[0];
      normLength = 0;
      _camera = new double[3] { 0, 0, 100 };
      ZoomCoeff = 1;
      AxisTurning = 1;
      ZoomAxis = 1;
    }
    public void SetTurning(double Angle)
    {
      switch (AxisTurning)
      {
        case 1:
          xRotation = Angle;
          yRotation = zRotation = 0;
          break;
        case 2:
          yRotation = Angle;
          xRotation = zRotation = 0;
          break;
        case 3:
          zRotation = Angle;
          yRotation = xRotation = 0;
          break;
      }
    }
    public void SetAxisTurn(byte Axis)
    {
      AxisTurning = Axis;
    }
    public void SendData()
    {
      MyDrawing.GetData(new Tuple<Structures.MyPoint[], Structures.MyPolygon[], Structures.MyEdge[]>(points, polygons, edges));
    }
    public void Parse(string Input)
    {
      double X, Y, Z;
      string[] Arr = Input.Split(new string[] { "\n\r", "\n" }, StringSplitOptions.None);
      int Length = Arr.Length;
      string[] Row;
      bool flag = true;
      int FType = 1;  //1 - _ 2 - _/_ 3 - _/_/_ 4 - _//_
      for (int i = 0; i < Length; i++)
      {
        if (Arr[i] != "" && Arr[i][0] != '#')
          switch (Arr[i].Substring(0, 2))
          {
            case "v ":
              Row = Arr[i].Split(null as string[], StringSplitOptions.RemoveEmptyEntries);
              Array.Resize(ref points, ++pointsLength);
              X = double.Parse(Row[1], System.Globalization.CultureInfo.InvariantCulture);
              Y = double.Parse(Row[2], System.Globalization.CultureInfo.InvariantCulture);
              Z = double.Parse(Row[3], System.Globalization.CultureInfo.InvariantCulture);
              points[pointsLength - 1] = new Structures.MyPoint(X, Y, Z);
              break;
            case "vn":
              Row = Arr[i].Split(null as string[], StringSplitOptions.RemoveEmptyEntries);
              X = double.Parse(Row[1], System.Globalization.CultureInfo.InvariantCulture);
              Y = double.Parse(Row[2], System.Globalization.CultureInfo.InvariantCulture);
              Z = double.Parse(Row[3], System.Globalization.CultureInfo.InvariantCulture);
              Array.Resize(ref normals, ++normLength);
              normals[normLength - 1] = new Structures.MyPoint(X, Y, Z);
              break;
            case "f ":
              if (flag)
              {
                if (Arr[i].IndexOf('/') != -1)
                {
                string[] tmp = Arr[i].Split(' ');
                int Leng = tmp[1].Length;
                
                tmp = tmp[1].Split('/');
                
                  if (tmp[1][0] != '/')
                    FType = tmp.Length;
                  else
                    FType = 4;
                }
                else
                  FType = 5;
                flag = false;
              }
              Row = Arr[i].Split(null as string[], StringSplitOptions.RemoveEmptyEntries);
              int RowLength = Row.Length - 1;
              string[] Temp;
              int[] F = new int[Row.Length - 1];
              int[] N = new int[Row.Length - 1];
              switch (FType)
              {
                case 1:
                  for (int k = 1; k <= RowLength; k++)
                    F[k - 1] = int.Parse(Row[k]);
                  break;
                case 2:
                  for (int k = 1; k <= RowLength; k++)
                  {
                    Temp = Row[k].Split('/');
                    F[k - 1] = int.Parse(Temp[0]);
                    //Здесь воткнуть массив для текстуры
                  }
                  break;
                case 3:
                  for (int k = 1; k <= RowLength; k++)
                  {
                    Temp = Row[k].Split('/');
                    F[k - 1] = int.Parse(Temp[0]);
                    //Здесь воткнуть массив для текстуры
                    N[k - 1] = int.Parse(Temp[2]);
                  }
                  break;
                case 4:
                  //Кек
                  break;
                case 5:
                  for (int k = 1; k <= RowLength; k++)
                    F[k - 1] = int.Parse(Row[k]);
                  break;
              }
              Array.Resize(ref polygons, ++polygonLength);
              if (RowLength == 3)
                polygons[polygonLength - 1] = new Structures.MyPolygon(F[0], F[1], F[2]);
              else
                polygons[polygonLength - 1] = new Structures.MyPolygon(F[0], F[1], F[2], F[3]);

              
              switch (FType)
              {
                case 4:
                  Array.Resize(ref edges, edgeLength + 4);
                  edgeLength += 4;
                  edges[edgeLength - 4] = new Structures.MyEdge(F[0], F[1]);
                  edges[edgeLength - 3] = new Structures.MyEdge(F[1], F[2]);
                  edges[edgeLength - 2] = new Structures.MyEdge(F[2], F[3]);
                  edges[edgeLength - 1] = new Structures.MyEdge(F[3], F[0]);
                  break;
                default:
                  Array.Resize(ref edges, edgeLength + 3);
                  edgeLength += 3;
                  edges[edgeLength - 3] = new Structures.MyEdge(F[0], F[1]);
                  edges[edgeLength - 2] = new Structures.MyEdge(F[1], F[2]);
                  edges[edgeLength - 1] = new Structures.MyEdge(F[2], F[0]);
                  break;
              }
              break;
          }
      }
      _GetVectorNormals();
    }
    public void InvokeAlgorithms()
    {
      _RotatePoints();
      _GetVectorNormals();
      _GetEquations();
      _GetCoeffs();
      _SortPolygons();
    }
    private void _GetCoeffs()
    {
      for (int i = 0; i < polygonLength; i++)
      {
        polygons[i].LightCoeff = VectorOperations.GetCosBetweenVectors(
          LightVector, polygons[i].Vector);
        polygons[i].cameraCoeff = VectorOperations.VectorGetLength(
          _camera, polygons[i].Vector);
       /* double[] TempVector = MatricesAndVectors.Normalize(_camera);
        polygons[i].CameraDist = Math.Abs(
          polygons[i].Equation[0] * TempVector[0] +
          polygons[i].Equation[1] * TempVector[1] +
          polygons[i].Equation[2] * TempVector[2] +
          polygons[i].Equation[3]) / Math.Sqrt(
            polygons[i].Equation[0] * polygons[i].Equation[0] +
            polygons[i].Equation[1] * polygons[i].Equation[1] +
            polygons[i].Equation[2] * polygons[i].Equation[2]);
       // while (polygons[i].CameraDist > 1)
            polygons[i].CameraDist *= 0.5;*/
      }
    }
    private void _RotatePoints()
    {
      Matrices.MatrixRotation RotX = new Matrices.MatrixRotation(xRotation, 1);
      Matrices.MatrixRotation RotY = new Matrices.MatrixRotation(yRotation, 2);
      Matrices.MatrixRotation RotZ = new Matrices.MatrixRotation(zRotation, 3);
      for (int i = 0; i < pointsLength; i++)
      {
        points[i] = VectorOperations.VectorMultiply(points[i], RotX);
        points[i] = VectorOperations.VectorMultiply(points[i], RotY);
        points[i] = VectorOperations.VectorMultiply(points[i], RotZ);
      }
    }
    public void SetLightVector(double X, double Y, double Z)
    {
      LightVector = new double[3] { X, Y, Z };
    }
    private void _GetVectorNormals()
    {
      for (int i = 0; i < polygonLength; i++)
      {
        polygons[i].Vector = VectorOperations.VectorCrossProduct(new double[] {
          points[polygons[i].secondPoint - 1].x - points[polygons[i].firstPoint - 1].x,
          points[polygons[i].secondPoint - 1].y - points[polygons[i].firstPoint - 1].y,
          points[polygons[i].secondPoint - 1].z - points[polygons[i].firstPoint - 1].z}, new double[] {
          points[polygons[i].thirdPoint - 1].x - points[polygons[i].firstPoint - 1].x,
          points[polygons[i].thirdPoint - 1].y - points[polygons[i].firstPoint - 1].y,
          points[polygons[i].thirdPoint - 1].z - points[polygons[i].firstPoint - 1].z});
        polygons[i].Vector = VectorOperations.Normalize(polygons[i].Vector);
      }
    }
    private void _SortPolygons()
    {
      int j;
      int step = polygonLength / 2;
      while (step > 0)
      {
        for (int i = 0; i < (polygonLength - step); i++)
        {
          j = i;
          while ((j >= 0) && (polygons[j].MaxZ >= polygons[j+step].MaxZ))//(points[polygons[j].MaxZ-1].Z/*CameraDist*/ <= polygons[j + step].CameraDist))
          {
            Structures.MyPolygon tmp = polygons[j];
            polygons[j] = polygons[j + step];
            polygons[j + step] = tmp;
            j -= step;
          }
        }
        step /= 2;
      }
    }
    private void _GetEquations()
    {
      for (int i = 0; i < polygonLength; i++)
      {
        //polygons[i].Equation = _GetEquation(polygons[i]);
        GetMaxZ(polygons[i]);
      }
    }
    private double[] _GetEquation(Structures.MyPolygon Pol)
    {
      Structures.MyPoint Z1 = points[Pol.firstPoint - 1];
      Structures.MyPoint Z2 = points[Pol.secondPoint - 1];
      Structures.MyPoint Z3 = points[Pol.thirdPoint - 1];

      double x1 = Convert.ToDouble(Z1.x);
      double y1 = Convert.ToDouble(Z1.y);
      double z1 = Convert.ToDouble(Z1.z);
      double x2 = Convert.ToDouble(Z2.x);
      double y2 = Convert.ToDouble(Z2.y);
      double z2 = Convert.ToDouble(Z2.z);
      double x3 = Convert.ToDouble(Z3.x);
      double y3 = Convert.ToDouble(Z3.y);
      double z3 = Convert.ToDouble(Z3.z);

      double a = y1 * (z2 - z3) + y2 * (z3 - z1) + y3 * (z1 - z2);
      double b = z1 * (x2 - x3) + z2 * (x3 - x1) + z3 * (x1 - x2);
      double c = x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2);
      double d = -(x1 * (y2 * z3 - y3 * z2) + x2 * (y3 * z1 - y1 * z3) + x3 * (y1 * z2 - y2 * z1));
     /* while (Math.Abs(a) < 0.1 && Math.Abs(b) < 0.1 && Math.Abs(c) < 0.1 && Math.Abs(d) < 0.1)
      {
          a *= 10;
          b *= 10;
          c *= 10;
          d *= 10;
      }*/
      double[] Equation = new double[4] { a, b, c, d };
      return Equation;
    }
    public void ZoomWithCoeffs(int Delta, double X, double Y, double Z)
    {
      Matrices.MatrixResizing Rez;
      Rez = new Matrices.MatrixResizing(Delta < 0, X, Y, Z);
      for (int i = 0; i < pointsLength; i++)
      {
        points[i] = VectorOperations.VectorMultiply(points[i], Rez);
      }
    }
    public void MoveWithCoeffs(int Delta, double X, double Y, double Z)
    {
      int mult = Delta < 0 ? 1 : -1;
      Matrices.MatrixTranslation Rez = new Matrices.MatrixTranslation(mult * X, mult * Y, mult * Z);
      for (int i = 0; i < pointsLength; i++)
      {
        points[i] = VectorOperations.VectorMultiply(points[i], Rez);
      }
    }
    private void GetMaxZ(Structures.MyPolygon Pol)
    {
      double Z1 = points[Pol.firstPoint - 1].z;
      double Z2 = points[Pol.secondPoint - 1].z;
      double Z3 = points[Pol.thirdPoint - 1].z;
      double[] Arr = new double[] { Z1, Z2, Z3 };
      if (Pol.Type == 4)
      {
        double Z4 = points[Pol.fourthPoint - 1].z;
        Arr = new double[] { Z1, Z2, Z3, Z4 };
      }
      Array.Sort(Arr);
      Pol.MaxZ = Pol.Type == 4 ? Arr[3] : Arr[2];
    }
  }
}

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

    double[] Camera;
    Structures.MyPoint Center;
    public Structures.MyPoint[] Points;
    public Structures.MyEdge[] Edges;
    public Structures.MyPolygon[] Polygons;
    public Structures.MyPoint[] Normals;
    public int NLength;
    public int PLength;
    public int ELength;
    public int RLength;

    public ModelClass()
    {
      Points = new Structures.MyPoint[0];
      PLength = 0;
      Edges = new Structures.MyEdge[0];
      ELength = 0;
      Polygons = new Structures.MyPolygon[0];
      LightVector = new double[3] { 0, 0, 1 };
      RLength = 0;
      Normals = new Structures.MyPoint[0];
      NLength = 0;
      Camera = new double[3] { 0, 0, 20 };
      ZoomCoeff = 1;
      AxisTurning = 1;
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
      MyDrawing.GetData(new Tuple<Structures.MyPoint[], Structures.MyPolygon[], Structures.MyEdge[]>(Points, Polygons, Edges));
    }
    public void Parse(string Input)
    {
      double AllX = 0, AllY = 0, AllZ = 0;
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
              Array.Resize(ref Points, ++PLength);
              X = double.Parse(Row[1], System.Globalization.CultureInfo.InvariantCulture);
              Y = double.Parse(Row[2], System.Globalization.CultureInfo.InvariantCulture);
              Z = double.Parse(Row[3], System.Globalization.CultureInfo.InvariantCulture);
              AllX += X;
              AllY += Y;
              AllZ += Z;
              Points[PLength - 1] = new Structures.MyPoint(X, Y, Z);
              break;
            case "vn":
              Row = Arr[i].Split(null as string[], StringSplitOptions.RemoveEmptyEntries);
              X = double.Parse(Row[1], System.Globalization.CultureInfo.InvariantCulture);
              Y = double.Parse(Row[2], System.Globalization.CultureInfo.InvariantCulture);
              Z = double.Parse(Row[3], System.Globalization.CultureInfo.InvariantCulture);
              Array.Resize(ref Normals, ++NLength);
              Normals[NLength - 1] = new Structures.MyPoint(X, Y, Z);
              break;
            case "f ":
              if (flag)
              {
                string[] tmp = Arr[i].Split(' ');
                int Leng = tmp[1].Length;
                tmp = tmp[1].Split('/');
                if (tmp[1][0] != '/')
                  FType = tmp.Length;
                else
                  FType = 4;
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
              }
              Array.Resize(ref Polygons, ++RLength);
              if (RowLength == 3)
                Polygons[RLength - 1] = new Structures.MyPolygon(F[0], F[1], F[2]);
              else
                Polygons[RLength - 1] = new Structures.MyPolygon(F[0], F[1], F[2], F[3]);

              if (FType > 2)
              {
                Polygons[RLength - 1].NF = N[0];
                Polygons[RLength - 1].NS = N[1];
                Polygons[RLength - 1].NT = N[2];
                if (FType == 4)
                  Polygons[RLength - 1].NFr = N[3];
              }
              switch (FType)
              {

                case 4:
                  Array.Resize(ref Edges, ELength + 4);
                  ELength += 4;
                  Edges[ELength - 4] = new Structures.MyEdge(F[0], F[1]);
                  Edges[ELength - 3] = new Structures.MyEdge(F[1], F[2]);
                  Edges[ELength - 2] = new Structures.MyEdge(F[2], F[3]);
                  Edges[ELength - 1] = new Structures.MyEdge(F[3], F[0]);
                  break;
                default:
                  Array.Resize(ref Edges, ELength + 3);
                  ELength += 3;
                  Edges[ELength - 3] = new Structures.MyEdge(F[0], F[1]);
                  Edges[ELength - 2] = new Structures.MyEdge(F[1], F[2]);
                  Edges[ELength - 1] = new Structures.MyEdge(F[2], F[0]);
                  break;
              }
              break;
          }
      }
      GetVectorNormals();
      Center = new Structures.MyPoint(AllX / PLength, AllY / PLength, AllZ / PLength);
    }
    public void InvokeAlgorithms()
    {
      RotatePoints();
      GetVectorNormals();
      GetMinZs();
      GetCoeffs();
      SortPolygons();
    }
    private void GetCoeffs()
    {
      for (int i = 0; i < RLength; i++)
      {
        Polygons[i].LightCoeff = MatrixesAndVectors.GetCosBetweenVectors(
          LightVector, Polygons[i].Vector);
        Polygons[i].CameraCoeff = MatrixesAndVectors.VectorGetLength(
          LightVector, Polygons[i].Vector);
        Polygons[i].CameraDist = MatrixesAndVectors.VectorGetLength(new double[3] {  //Camera.X, Polygons[i].Vector[1] - Camera.Y, Polygons[i].Vector[2] - Camera.Z }));
          /*Camera.X/**/Camera[0] - Points[Polygons[i].MaxZ - 1].X,
          /*Camera.Y/**/Camera[1] - Points[Polygons[i].MaxZ - 1].Y,
          /*Camera.Z/**/Camera[2] - Points[Polygons[i].MaxZ - 1].Z});
      }
    }
    private void RotatePoints()
    {
      MatrixesAndVectors.MatrixRotation RotX = new MatrixesAndVectors.MatrixRotation(xRotation, 1);
      MatrixesAndVectors.MatrixRotation RotY = new MatrixesAndVectors.MatrixRotation(yRotation, 2);
      MatrixesAndVectors.MatrixRotation RotZ = new MatrixesAndVectors.MatrixRotation(zRotation, 3);
      for (int i = 0; i < PLength; i++)
      {
        Points[i] = MatrixesAndVectors.VectorMultiply(Points[i], RotX);
        Points[i] = MatrixesAndVectors.VectorMultiply(Points[i], RotY);
        Points[i] = MatrixesAndVectors.VectorMultiply(Points[i], RotZ);
      }
    }
    public void SetLightVector(double X, double Y, double Z)
    {
      LightVector = new double[3] { X, Y, Z };
    }
    private void GetVectorNormals()
    {
      for (int i = 0; i < RLength; i++)
      {
        Polygons[i].Vector = MatrixesAndVectors.VectorCrossProduct(new double[] {
          Points[Polygons[i].SP - 1].X - Points[Polygons[i].FP - 1].X,
          Points[Polygons[i].SP - 1].Y - Points[Polygons[i].FP - 1].Y,
          Points[Polygons[i].SP - 1].Z - Points[Polygons[i].FP - 1].Z}, new double[] {
          Points[Polygons[i].TP - 1].X - Points[Polygons[i].FP - 1].X,
          Points[Polygons[i].TP - 1].Y - Points[Polygons[i].FP - 1].Y,
          Points[Polygons[i].TP - 1].Z - Points[Polygons[i].FP - 1].Z});
        Polygons[i].Vector = MatrixesAndVectors.Normalize(Polygons[i].Vector);
      }
    }
    private void SortPolygons()
    {
      int j;
      int step = RLength / 2;
      while (step > 0)
      {
        for (int i = 0; i < (RLength - step); i++)
        {
          j = i;
          while ((j >= 0) && (Polygons[j].CameraDist <= Polygons[j + step].CameraDist))
          {
            Structures.MyPolygon tmp = Polygons[j];
            Polygons[j] = Polygons[j + step];
            Polygons[j + step] = tmp;
            j -= step;
          }
        }
        step /= 2;
      }
    }
    private void GetMinZs()
    {
      for (int i = 0; i < RLength; i++)
      {
        Polygons[i].MaxZ = ReturnMaxZ(Polygons[i]);
      }
    }
    private int ReturnMaxZ(Structures.MyPolygon Pol)
    {
      double Z1 = Points[Pol.FP - 1].Z;
      double Z2 = Points[Pol.SP - 1].Z;
      double Z3 = Points[Pol.TP - 1].Z;

        int ZMax;
      if (Pol.Type == 3)
      {
        if (Z1 > Z2 && Z1 > Z3)
          ZMax = Pol.FP;
        else
          if (Z2 > Z3)
          ZMax = Pol.SP;
        else
          ZMax = Pol.TP;
        return ZMax;
      }
      else
      {
        double Z4 = Points[Pol.FrP - 1].Z;
        double[] Arr = { Z1, Z2, Z3, Z4 };
        Array.Sort(Arr);
        if (Points[Pol.FP - 1].Z == Arr[3]) return Pol.FP;
        if (Points[Pol.SP - 1].Z == Arr[3]) return Pol.SP;
        if (Points[Pol.TP - 1].Z == Arr[3]) return Pol.TP;
        return Pol.FrP;
      }
    }
  }
}

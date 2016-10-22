using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
  public partial class Form1 : Form
  {
    int x_mouse, y_mouse;
    double x_start;
    double y_start;
    double x_now;
    double y_now;
    bool pr;
    PointF[][] Pointt;
    float[,,] old = new float[11, 4, 3];
    private void Form1_Load(object sender, EventArgs e)
    {
      x_start = (polygons[1].points[1].x + polygons[1].points[3].x) / 2;
      y_start = (polygons[1].points[1].y + polygons[1].points[3].y) / 2;
      x_now = x_start;
      y_now = y_start;

    }

    polygon[] polygons; //полигоны объекта
    polygon[] trn;
    polygon[] tp; // буфер для сортировки полигонов по z-координате
    public Form1()
    {
      InitializeComponent();
      this.MouseWheel += new MouseEventHandler(this_MouseWheel);
      InitializeComponent();
      this.tp = new polygon[1];
      this.trn = new polygon[1];
      InitializeComponent();
      this.polygons = new polygon[20];
      //Вертикальная палка спереди слева
      polygons[0] = new polygon();
      polygons[0].color = Brushes.Gray;
      polygons[0].points = new point3d[] { new point3d(300, 150, 0), new point3d(320, 150, 0), new point3d(320, 250, 0), new point3d(300, 250, 0) };

      //Вертикальная палка спереди справа
      polygons[1] = new polygon();
      polygons[1].color = Brushes.Gray;
      polygons[1].points = new point3d[] { new point3d(440, 150, 0), new point3d(460, 150, 0), new point3d(460, 250, 0), new point3d(440, 250, 0) };

      //Наклонная палка спереди слева
      polygons[2] = new polygon();
      polygons[2].color = Brushes.Gray;
      polygons[2].points = new point3d[] { new point3d(320, 150, 0), new point3d(380, 200, 0), new point3d(380, 220, 0), new point3d(320, 170, 0) };

      //Наклонная палка спереди справа
      polygons[3] = new polygon();
      polygons[3].color = Brushes.Gray;
      polygons[3].points = new point3d[] { new point3d(440, 150, 0), new point3d(380, 200, 0), new point3d(380, 220, 0), new point3d(440, 170, 0) };

      //Вертикальная палка слева сбоку
      polygons[4] = new polygon();
      polygons[4].color = Brushes.Brown;
      polygons[4].points = new point3d[] { new point3d(300, 150, 0), new point3d(300, 150, -20), new point3d(300, 250, -20), new point3d(300, 250, 0) };
      trn[0] = polygons[1];

      //Вертикальная палка слева сбоку
      polygons[5] = new polygon();
      polygons[5].color = Brushes.Brown;
      polygons[5].points = new point3d[] { new point3d(320, 150, 0), new point3d(320, 150, -20), new point3d(320, 250, -20), new point3d(320, 250, 0) };
      trn[0] = polygons[1];

      //Вертикальная палка справа сбоку
      polygons[6] = new polygon();
      polygons[6].color = Brushes.Brown;
      polygons[6].points = new point3d[] { new point3d(440, 150, 0), new point3d(440, 150, -20), new point3d(440, 250, -20), new point3d(440, 250, 0) };
      trn[0] = polygons[1];

      //Вертикальная палка справа сбоку
      polygons[7] = new polygon();
      polygons[7].color = Brushes.Brown;
      polygons[7].points = new point3d[] { new point3d(460, 150, 0), new point3d(460, 150, -20), new point3d(460, 250, -20), new point3d(460, 250, 0) };
      trn[0] = polygons[1];

      //Вертикальная палка сзади
      polygons[8] = new polygon();
      polygons[8].color = Brushes.Red;
      polygons[8].points = new point3d[] { new point3d(300, 150, -20), new point3d(320, 150, -20), new point3d(320, 250, -20), new point3d(300, 250, -20) };

      //Вертикальная палка сзади
      polygons[9] = new polygon();
      polygons[9].color = Brushes.Red;
      polygons[9].points = new point3d[] { new point3d(440, 150, -20), new point3d(460, 150, -20), new point3d(460, 250, -20), new point3d(440, 250, -20) };

      //Наклонная палка спереди слева
      polygons[10] = new polygon();
      polygons[10].color = Brushes.Red;
      polygons[10].points = new point3d[] { new point3d(320, 150, -20), new point3d(380, 200, -20), new point3d(380, 220, -20), new point3d(320, 170, -20) };

      //Наклонная палка спереди справа
      polygons[11] = new polygon();
      polygons[11].color = Brushes.Red;
      polygons[11].points = new point3d[] { new point3d(440, 150, -20), new point3d(380, 200, -20), new point3d(380, 220, -20), new point3d(440, 170, -20) };

      // Горизонт. шапка сверху
      polygons[12] = new polygon();
      polygons[12].color = Brushes.Pink;
      polygons[12].points = new point3d[] { new point3d(300, 150, -20), new point3d(320, 150, -20), new point3d(320, 150, 0), new point3d(300, 150, 0) };

      // Горизонт. шапка сверху
      polygons[13] = new polygon();
      polygons[13].color = Brushes.Pink;
      polygons[13].points = new point3d[] { new point3d(440, 150, -20), new point3d(460, 150, -20), new point3d(460, 150, 0), new point3d(440, 150, 0) };

      //Нижняя часть
      polygons[14] = new polygon();
      polygons[14].color = Brushes.Blue;
      polygons[14].points = new point3d[] { new point3d(300, 250, 0), new point3d(300, 250, -20), new point3d(320, 250, -20), new point3d(320, 250, 0) };

      //Нижняя часть
      polygons[15] = new polygon();
      polygons[15].color = Brushes.Blue;
      polygons[15].points = new point3d[] { new point3d(460, 250, 0), new point3d(460, 250, -20), new point3d(440, 250, -20), new point3d(440, 250, 0) };

      // Наклон сверху
      polygons[16] = new polygon();
      polygons[16].color = Brushes.Pink;
      polygons[16].points = new point3d[] { new point3d(320, 150, -20), new point3d(380, 200, -20), new point3d(380, 200, 0), new point3d(320, 150, 0) };

      // Наклон сверху
      polygons[17] = new polygon();
      polygons[17].color = Brushes.Pink;
      polygons[17].points = new point3d[] { new point3d(440, 150, -20), new point3d(380, 200, -20), new point3d(380, 200, 0), new point3d(440, 150, 0) };

      // Наклон снизу
      polygons[18] = new polygon();
      polygons[18].color = Brushes.Blue;
      polygons[18].points = new point3d[] { new point3d(320, 170, -20), new point3d(380, 220, -20), new point3d(380, 220, 0), new point3d(320, 170, 0) };

      // Наклон снизу
      polygons[18] = new polygon();
      polygons[18].color = Brushes.Blue;
      polygons[18].points = new point3d[] { new point3d(320, 170, -20), new point3d(380, 220, -20), new point3d(380, 220, 0), new point3d(320, 170, 0) };

      // Наклон снизу
      polygons[19] = new polygon();
      polygons[19].color = Brushes.Blue;
      polygons[19].points = new point3d[] { new point3d(440, 170, -20), new point3d(380, 220, -20), new point3d(380, 220, 0), new point3d(440, 170, 0) };


      trn[0] = polygons[1];

      for (int i = 0; i < 20; i++)
        polygons[i].oldpoints = new oldpoint3d[4] { new oldpoint3d(0, 0, 0), new oldpoint3d(0, 0, 0), new oldpoint3d(0, 0, 0), new oldpoint3d(0, 0, 0) };
    }

    //-------------------------------------------------------------------
    //Преобразуем в двухмерное пространство
    PointF[][] twod()
    {
      PointF[][] result = new PointF[polygons.Length][];
      for (int i = 0; i < polygons.Length; i++)
      {
        result[i] = new PointF[polygons[i].points.Length];
        for (int j = 0; j < polygons[i].points.Length; j++)
        {

          double x = polygons[i].points[j].x;
          double y = polygons[i].points[j].y;
          result[i][j] = new PointF((float)x, (float)y);
        }
      }
      return result;
    }
    //-------------------------------------------------------------------
    //Прорисовываем
    private void Form1_Paint(object sender, PaintEventArgs e)
    {



      //запоминаем координаты без проецирования
      for (int i = 0; i < polygons.Length; i++)
      {
        for (int j = 0; j < polygons[i].points.Length; j++)
        {
          polygons[i].oldpoints[j].x = polygons[i].points[j].x;
          polygons[i].oldpoints[j].y = polygons[i].points[j].y;
          polygons[i].oldpoints[j].z = polygons[i].points[j].z;
        }
      }

      if (pr == true)
      {
        operations(move((int)-x_start, (int)-y_start, 10));
        operations(proection()); //проецируем
        operations(move((int)x_start, (int)y_start, -10));
      }


      int mininpol;
      //определяем новые координаты полигона-дублера
      // создаем массив глубин всех полигонов по z-координате
      for (int i = 0; i < polygons.Length; i++)
      {
        mininpol = 140;
        for (int j = 0; j < polygons[i].points.Length; j++)
        {
          mininpol = (int)polygons[i].points[j].z;
          polygons[i].minz = polygons[i].minz + mininpol;


        }
        polygons[i].minz /= 4;
      }
      //сортируем полигоны согласно глубине от меньшего к большему
      for (int i = 0; i < polygons.Length; i++)
      {
        for (int j = polygons.Length - 1; j > i; --j)
        {
          if (polygons[j].minz < polygons[j - 1].minz)
          {
            tp[0] = polygons[j - 1];
            polygons[j - 1] = polygons[j];
            polygons[j] = tp[0];

          }
        }
      }

      //преобразуем картинку в двумерное пространство
      Pointt = twod();
      PointF[] back = new PointF[] { new PointF(0, 0), new PointF(0, 600), new PointF(960, 600), new PointF(960, 0) };
      e.Graphics.FillPolygon(Brushes.LightGray, back);
      e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
      for (int i = 0; i < Pointt.Length; i++)
        e.Graphics.FillPolygon(polygons[i].color, Pointt[i]);

      //возвращаем координаты к непроекционному виду, чтобы работать дальше
      for (int i = 0; i < polygons.Length; i++)
      {
        for (int j = 0; j < polygons[i].points.Length; j++)
        {
          polygons[i].points[j].x = polygons[i].oldpoints[j].x;
          polygons[i].points[j].y = polygons[i].oldpoints[j].y;
          polygons[i].points[j].z = polygons[i].oldpoints[j].z;
        }
      }
    }
    //-------------------------------------------------------------------
    //Поворачиваем
    double[,] turnit(double a, char s)
    {
      double[,] matrix = new double[4, 4];

      if (s == 'x')
      {
        matrix = new double[,] {
                {1,0,0,0},
                { 0, (double)Math.Cos(a), (double)-Math.Sin(a), 0},
                { 0,(double)Math.Sin(a), (double)Math.Cos(a),0 },
                {0,0,0,1},
                };
      }
      if (s == 'y')
      {
        matrix = new double[,] {
                { (double)Math.Cos(a), 0, (double)Math.Sin(a), 0},
              {0,1,0,0},
                { (double)-Math.Sin(a), 0, (double)Math.Cos(a),0 },
                {0,0,0,1},
                };
      }
      if (s == 'z')
      {
        matrix = new double[,] {
                { (double)Math.Cos(a), -(double)Math.Sin(a), 0, 0},
                { (double)Math.Sin(a), (double)Math.Cos(a),0, 0 },
                {0,0,1,0},
                {0,0,0,1},
                };
      }

      return matrix;

    }
    //-------------------------------------------------------------------
    //Изменение размера
    double[,] rsz(double x)
    {
      double[,] matrix = new double[,] {
                {x,0,0,0},
                { 0, x, 0, 0},
                { 0,0, x,0 },
                {0,0,0,1},
                };

      return matrix;
    }
    //-------------------------------------------------------------------
    //проекция
    double[,] proection()
    {
      double x = (double)0.001 * 3;
      double[,] matrix = new double[,] {

                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0 },
                { 0, 0, -x, 1},

                };
      return matrix;
    }
    //-------------------------------------------------------------------
    //Перемножение матриц
    static double[,] Multiplication(double[,] a, double[,] b)
    {
      double[,] r = new double[a.GetLength(0), b.GetLength(1)];
      for (int i = 0; i < a.GetLength(0); i++)
      {
        for (int j = 0; j < b.GetLength(1); j++)
        {
          for (int k = 0; k < b.GetLength(0); k++)
          {
            r[i, j] += a[i, k] * b[k, j];
          }
        }
      }
      return r;
    }
    //-------------------------------------------------------------------
    //Умножаем матрицы
    double[] MakeResArr(double[,] matrix, double[] bArr, double[] cArr)
    {

      for (int l = 0; l < 4; l++)
      {
        cArr[l] = 0;
      }
      for (int i = 0; i < 4; i++)
      {
        for (int j = 0; j < 4; j++)
        {

          cArr[i] = cArr[i] + matrix[i, j] * bArr[j];
        }
      }
      return cArr;
    }
    //-------------------------------------------------------------------
    //Отразить
    double[,] mirror(char s)
    {
      double[,] matrix = new double[4, 4];
      if (s == 'u')
      {
        matrix = new double[,] {
                { -(double)1, 0, 0, 0 },
                { 0, (double)1, 0 , 0},
                { 0, 0, (double)1 , 0},
                { 0, 0, 0, 1 } };
      }
      else
      {
        if (s == 'd')
        {
          matrix = new double[,] {
                { (double)1, 0, 0, 0 },
                { 0, (double)-1, 0 , 0},
                { 0, 0, (double)1 , 0},
                { 0, 0, 0, 1 } };
        }
        else
        {
          matrix = new double[,] {
                { (double)1, 0, 0, 0 },
                { 0, (double)1, 0 , 0},
                { 0, 0, (double)-1 , 0},
                { 0, 0, 0, 1 } };
        }
      }

      return matrix;
    }
    //-------------------------------------------------------------------
    //Сдвиг
    double[,] move(int x, int y, int z)
    {
      double[,] matrix = new double[,] {
            { 1, 0, 0,(double)x },
            { 0, 1, 0,(double)y },
            { 0, 0, 1, (double)z },
            { 0, 0, 0, 1, } };
      return matrix;
    }
    //-------------------------------------------------------------------
    //Применяем операции над точками
    void operations(double[,] change)
    {
      double[] bArr = new double[4];
      double[] cArr = new double[4];

      for (int i = 0; i < polygons.Length; i++)
      {
        for (int j = 0; j < polygons[i].points.Length; j++)
        {
          bArr[0] = polygons[i].points[j].x;
          bArr[1] = polygons[i].points[j].y;
          bArr[2] = polygons[i].points[j].z;
          bArr[3] = 1;

          MakeResArr(change, bArr, cArr);


          polygons[i].points[j].x = (float)cArr[0] / (float)cArr[3];
          polygons[i].points[j].y = (float)cArr[1] / (float)cArr[3];
          polygons[i].points[j].z = (float)cArr[2] / (float)cArr[3];
        }
      };
    }
    //-------------------------------------------------------------------
    //Обрабатываем движение мыши
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {

        operations(move(e.X - x_mouse, e.Y - y_mouse, 0));

        x_mouse = e.X;
        y_mouse = e.Y;
        this.Invalidate();
        x_start = (trn[0].points[1].x + trn[0].points[3].x) / 2;
        y_start = (trn[0].points[1].y + trn[0].points[3].y) / 2;
      }
      if (e.Button == MouseButtons.Right)
      {
        operations(turnit((double)0.01, 'x'));
        operations(turnit((double)0.01, 'y'));

        x_mouse = e.X;
        y_mouse = e.Y;

        this.Invalidate();
        x_start = (trn[0].points[1].x + trn[0].points[3].x) / 2;
        y_start = (trn[0].points[1].y + trn[0].points[3].y) / 2;
      }
    }
    //-------------------------------------------------------------------
    //Событие колесика мышки
    void this_MouseWheel(object sender, MouseEventArgs e)
    {
      if (e.Delta > 0)
      {
        operations(move((int)-x_start, (int)-y_start, 10));
        operations(rsz(1.1F));
        operations(move((int)x_start, (int)y_start, -10));
        this.Invalidate();
      }
      else
      {
        operations(move((int)-x_start, (int)-y_start, 10));
        operations(rsz(0.9F));
        operations(move((int)x_start, (int)y_start, -10));
        this.Invalidate();
      }
    }
    //-------------------------------------------------------------------
    //Захват координат для операций
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
      x_mouse = e.X;
      y_mouse = e.Y;
      this.Invalidate();

    }
    private void x_ref_Click(object sender, EventArgs e)
    {
      operations(move((int)-x_start, (int)-y_start, 10));
      operations(mirror('u'));
      operations(move((int)x_start, (int)y_start, -10));
      this.Invalidate();
    }
    private void y_ref_Click(object sender, EventArgs e)
    {
      operations(move((int)-x_start, (int)-y_start, 10));
      operations(mirror('d'));
      operations(move((int)x_start, (int)y_start, -10));
      this.Invalidate();
    }
    private void z_ref_Click(object sender, EventArgs e)
    {
      operations(move((int)-x_start, (int)-y_start, 10));
      operations(mirror('z'));
      operations(move((int)x_start, (int)y_start, -10));
      this.Invalidate();
    }
    private void makebig_Click(object sender, EventArgs e)
    {
      operations(move((int)-x_start, (int)-y_start, 10));
      operations(rsz(1.1F));
      operations(move((int)x_start, (int)y_start, -10));
      this.Invalidate();
    }
    private void makesmall_Click(object sender, EventArgs e)
    {
      operations(move((int)-x_start, (int)-y_start, 10));
      operations(rsz(0.9F));
      operations(move((int)x_start, (int)y_start, -10));
      this.Invalidate();
    }
    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (timer1.Enabled)
        timer1.Enabled = false;
      else
        timer1.Enabled = true;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
      operations(turnit((double)0.01, 'y'));
      operations(turnit((double)0.01, 'x'));
      x_start = (trn[0].points[1].x + trn[0].points[3].x) / 2;
      y_start = (trn[0].points[1].y + trn[0].points[3].y) / 2;

      this.Invalidate();
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
      if (pr == true)
        pr = false;
      else
        pr = true;
      this.Invalidate();
    }
  }
}

using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DrawingHelp
{
  public partial class Form1 : Form
  {
    private GraphicsPath path;
    private Matrix matrix = new Matrix();

    public Form1()
    {
      InitializeComponent();
      SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserMouse | ControlStyles.ResizeRedraw, true);

      //create graph path
      path = new GraphicsPath();
      path.AddCurve(new Point[] { new Point(10, 20), new Point(102, 203), new Point(150, 20) });
      path.AddEllipse(new Rectangle(100, 200, 300, 300));
      path.AddRectangle(new Rectangle(150, 100, 240, 50));
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      var p = (GraphicsPath)path.Clone();
      p.Transform(matrix);
      e.Graphics.DrawPath(Pens.Black, p);
    }

    private Point lastMousePos;

    protected override void OnMouseMove(MouseEventArgs e)
    {
      if (MouseButtons == MouseButtons.Left)
      {
        var p1 = ToClientPoint(lastMousePos);
        var p2 = ToClientPoint(e.Location);
        matrix.Translate(p2.X - p1.X, p2.Y - p1.Y);
        Invalidate();
      }
      lastMousePos = e.Location;
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
      var k = e.Delta > 0 ? 0.98f : 1.02f;
      var p = ToClientPoint(e.Location);

      matrix.Translate(p.X, p.Y);
      matrix.Scale(k, k);
      matrix.Translate(-p.X, -p.Y);

      Invalidate();
    }

    /// <summary>
    /// Переводит экранные координаты в координаты path
    /// </summary>
    PointF ToClientPoint(PointF p)
    {
      var temp = new PointF[] { p };
      var invert = matrix.Clone();
      invert.Invert();
      invert.TransformPoints(temp);

      return temp[0];
    }
  }
}
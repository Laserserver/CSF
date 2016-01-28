using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrawingTry
{
  public partial class DrawTry : Form
  {
    Line line1;
    Line line2;
    Graphics graph;
    Pen pen;
    Bitmap bmp;

    public DrawTry()
    {
      InitializeComponent();
      Init();
    }
    private void Init()
    {
      bmp = new Bitmap(picbx.Width, picbx.Height);
      pen = new Pen(Color.Black);
      graph = Graphics.FromImage(bmp);
      line1 = new Line(10, 10, 40, 40);
      line2 = new Line(40, 40, 70, 10);
    }
    private void btnSob_Click(object sender, EventArgs e)
    {
      Draw(line1);
      Draw(line2);
      picbx.Image = bmp;
    }
    private void Draw(Line line)
    {
      graph.DrawLine(pen, line.x1, line.y1, line.x2, line.y2);
    }
  }
}

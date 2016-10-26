using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Morphing
{
  public partial class FormMain : Form
  {
    Graphics g0;
    Bitmap bitmap;

    bool drawing = false;
    MouseEventArgs e0;
    int t;

    public FormMain()
    {
      InitializeComponent();
      TLines.I2 = _ctrlPicBx.Width; TLines.J2 = _ctrlPicBx.Height;
      bitmap = new Bitmap(_ctrlPicBx.Width, _ctrlPicBx.Height);
      g0 = _ctrlPicBx.CreateGraphics();
    }
    private void FormMain_Load(object sender, EventArgs e)
    {
      MouseWheel += new MouseEventHandler(FormMain_MouseWheel);
      saveFileDialog1.Filter = "Dat (*.dat)|*.dat|All Files (*.*)|*.*";
      openFileDialog1.Filter = "Dat (*.dat)|*.dat|All Files (*.*)|*.*";
    }
    void FormMain_MouseWheel(object sender, MouseEventArgs e)
    {
      double coeff;
      double x = TLines.XX(e.X);
      double y = TLines.YY(e.Y);
      if (e.Delta < 0)
        coeff = 1.03;
      else
        coeff = 0.97;
      TLines.xMin = x - (x - TLines.xMin) * coeff;
      TLines.xMax = x + (TLines.xMax - x) * coeff;
      TLines.yMin = y - (y - TLines.yMin) * coeff;
      TLines.yMax = y + (TLines.yMax - y) * coeff;
      Draw();
    }
    private void FormMain_Paint(object sender, PaintEventArgs e)
    {
      Draw();
    }

    public void Draw()
    {
      using (Graphics g = Graphics.FromImage(bitmap))
      {
        g.Clear(Color.White);
        TLines.Draw(g, timer1.Enabled);
      }
      g0.DrawImage(bitmap, _ctrlPicBx.ClientRectangle);
    }

    private void FormMain_MouseDown(object sender, MouseEventArgs e)
    {
      drawing = true;
      e0 = e;
    }
    private void FormMain_MouseMove(object sender, MouseEventArgs e)
    {
      if (drawing)
      {
        double dx = TLines.XX(e.X) - TLines.XX(e0.X);
        double dy = TLines.YY(e.Y) - TLines.YY(e0.Y);
        e0 = e;
        TLines.xMin -= dx; TLines.yMin -= dy; TLines.xMax -= dx; TLines.yMax -= dy;
        Draw();
      }
    }
    private void FormMain_MouseUp(object sender, MouseEventArgs e)
    {
      drawing = false;
    }

    public void Start()
    {
      timer1.Enabled = true;
      t = 0;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      ++t;
      timer1.Enabled = t < TLines.n20;
      _ctrlTxb1.Enabled = 
        _ctrlTxb2.Enabled =
        _ctrlTxbX2.Enabled =
        _ctrlTxbX1.Enabled =
        _ctrlTxbXX2.Enabled =
        _ctrlTxbXX1.Enabled =
        _ctrlTxbSteps.Enabled =
        _ctrlTxbArgMax.Enabled = 
        _ctrlTxbArgMin.Enabled = t == 0 || t == TLines.n20;
      Draw();
      TLines.Change(t);
      if (t == TLines.n20)
        TLines.tmpLines = null;
    }

    private void _ctrlButView_Click(object sender, EventArgs e)
    {
      if (!TLines.ParseGraph(new string[] {
      _ctrlTxbXX1.Text,
      _ctrlTxbXX2.Text,
      _ctrlTxbX1.Text,
      _ctrlTxbX2.Text,
      _ctrlTxb1.Text,
      _ctrlTxb2.Text,
      _ctrlTxbSteps.Text,
      _ctrlTxbArgMin.Text,
      _ctrlTxbArgMax.Text}))
      {
        MessageBox.Show("Неверные коэффициенты");
      }
      else
      {
        TLines.Init();
        _ctrlButMorph.Enabled = true;
        Draw();
      }
    }

    private void _ctrlButMorph_Click(object sender, EventArgs e)
    {
      Start();
    }
  }
}

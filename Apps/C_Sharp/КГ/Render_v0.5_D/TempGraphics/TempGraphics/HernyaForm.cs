using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TempGraphics
{
  public partial class MainForm : Form
  {
    LoTVModel Mdl;
    Graphics Canvas;
    MouseEventArgs e0;
    bool Drawing = false;
    int RadSpeed = 1;
    public MainForm()
    {
      InitializeComponent();
      Canvas = _ctrlCanvas.CreateGraphics();
      MouseWheel += new MouseEventHandler(_ctrlCanvas_MouseWheel);
    }
    private void TakeObject()
    {
      //try
      // {
      if (openFileDialog1.ShowDialog() == DialogResult.OK)
        using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
          Mdl.Parse(sr.ReadToEnd());
      // }
      //catch
      //{
      // MessageBox.Show("Hello.jpg");
      //}
    }
    private void _ctrlBaton_Click(object sender, EventArgs e)
    {
      //Model = new Model3D();
      Mdl = new LoTVModel();
      Mdl.Zoom = _ctrlCanvas.Width / 1.5;
      TakeObject();
      Mdl.Canv = new Bitmap(_ctrlCanvas.ClientRectangle.Width, _ctrlCanvas.ClientRectangle.Height);
      Mdl.I2 = _ctrlCanvas.Width;
      Mdl.J2 = _ctrlCanvas.Height;
      DrawImg();
      //render();
    }
    private void DrawImg()
    {
      // Mdl.xRotation = tX.Value;
      // Mdl.yRotation = tY.Value;
      // Mdl.zRotation = tZ.Value;
      Mdl.Draw();
      Canvas.DrawImage(Mdl.Canv, _ctrlCanvas.ClientRectangle);
    }
    private void _ctrlCanvas_MouseWheel(object sender, MouseEventArgs e)
    {
      if (Mdl != null)
      {
        if (_ctrlRBR.Checked)
        {
          double Angle = 0;
          double Rad = RadSpeed * Math.PI / 180;
          Angle = e.Delta > 0 ? -Rad : Rad;
          switch (Mdl.AxisTurn)
          {
            case 1:
              Mdl.xRotation = Angle;
              Mdl.yRotation = 0;
              Mdl.zRotation = 0;
              break;
            case 2:
              Mdl.xRotation = 0;
              Mdl.yRotation = Angle;
              Mdl.zRotation = 0;
              break;
            case 3:
              Mdl.xRotation = 0;
              Mdl.yRotation = 0;
              Mdl.zRotation = Angle;
              break;
          }
        }
        else
          {
            ResetRotation();
            Mdl.ChangeWindowXY(e.X, e.Y, e.Delta);
          }
        DrawImg();
      }
    }
    private void ResetRotation()
    {
      if (Mdl != null)
      {
        Mdl.xRotation = 0;
        Mdl.yRotation = 0;
        Mdl.zRotation = 0;
      }
    }
    private void _ctrlCanvas_MouseDown(object sender, MouseEventArgs e)
    {
      Drawing = true;
      ResetRotation();
      e0 = e;
    }
    private void _ctrlCanvas_MouseMove(object sender, MouseEventArgs e)
    {
       if (Mdl != null && Drawing)
       {
         /*if (e.Button == MouseButtons.Left)
         {
           double x = e.X - ClientRectangle.Width / 2;
           double y = e.Y - ClientRectangle.Height / 2;
           Mdl.SetAngle(x, y);
         }
         else
         {*/
           Mdl.SetDelta(e0, e);
           e0 = e;
        ResetRotation();
        //}
        DrawImg();
       }
    }
    private void _ctrlCanvas_MouseUp(object sender, MouseEventArgs e)
    {
      Drawing = false;
    }

    private void _ctrlRadX_CheckedChanged(object sender, EventArgs e)
    {
      if (Mdl != null)
        Mdl.AxisTurn = Convert.ToByte((sender as RadioButton).Tag);
    }

    private void _ctrlNumRadSpeed_ValueChanged(object sender, EventArgs e)
    {
      RadSpeed = (int)_ctrlNumRadSpeed.Value;
    }

    private void numericUpDown2_ValueChanged(object sender, EventArgs e)
    {
      if (Mdl != null)
      {
        Mdl.LightVector[2] = (int)_ctrlNumLigZ.Value;
        ResetRotation();
        DrawImg();
      }
    }

    private void _ctrlNumLigY_ValueChanged(object sender, EventArgs e)
    {
      if (Mdl != null)
      {

        Mdl.LightVector[1] = (int)_ctrlNumLigY.Value;
        ResetRotation();
        DrawImg();
      }
    }

    private void _ctrlNumLigX_ValueChanged(object sender, EventArgs e)
    {
      if (Mdl != null)
      {
        Mdl.LightVector[0] = (int)_ctrlNumLigX.Value;
        ResetRotation();
        DrawImg();
      }
    }

    private void _ctrlNumZoom_ValueChanged(object sender, EventArgs e)
    {
      if (Mdl != null)
      {
        Mdl.ZoomCoeff = (int)_ctrlNumZoom.Value / 10;
        ResetRotation();
        DrawImg();
      }
    }

    private void _ctrlChBModelZoom_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void _ctrlGrbAxis_Enter(object sender, EventArgs e)
    {

    }
  }
}

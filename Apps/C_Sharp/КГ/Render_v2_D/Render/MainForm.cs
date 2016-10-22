using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Render
{
  public partial class MainForm : Form
  {
    static Graphics Canvas;
    public static Graphics LogicsCanvas;
    MouseEventArgs e0;
    bool Drawing;
    public MainForm()
    {
      InitializeComponent();
      MouseWheel += new MouseEventHandler(_ctrlCanvas_MouseWheel);
      Canvas = _ctrlCanvas.CreateGraphics();
      MyDrawing.Canvas = new Bitmap(_ctrlCanvas.Width, _ctrlCanvas.Height);
      Drawing = false;
    }

    private void _ctrlCanvas_MouseWheel(object sender, MouseEventArgs e)
    {

      if (MainUnitProcessor.Model != null)
      {
        if (_ctrlRBR.Checked)
          MainUnitProcessor.Model.SetTurning((Math.PI * (int)_ctrlNumRadSpeed.Value / (e.Delta < 0 ? 180 : -180)));
        else
        {
          MainUnitProcessor.Model.SetTurning(0);
          MyDrawing.ChangeWindowXY(e.X, e.Y, e.Delta);
        }
      }
      DrawImage();
    }

    private void _ctrlRadX_CheckedChanged(object sender, EventArgs e)
    {
      if (MainUnitProcessor.Model != null)
        MainUnitProcessor.Model.SetAxisTurn(Convert.ToByte((sender as RadioButton).Tag));
    }

    private void _ctrlBaton_Click(object sender, EventArgs e)
    {
      MainUnitProcessor.Model = new ModelClass();
      ParseFile();
      MyDrawing.SetMonitor(_ctrlCanvas.Width, _ctrlCanvas.Height);
      DrawImage();
    }
    public static void DrawImage()
    {
      //LogicsCanvas.Clear(Color.Black);
      MyDrawing.Draw();
      Canvas.DrawImage(MyDrawing.Canvas, 0, 0);
    }
    private void ParseFile()
    {
      if (openFileDialog1.ShowDialog() == DialogResult.OK)
        using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
          MainUnitProcessor.ParseModel(sr.ReadToEnd());
    }

    private void _ctrlRadNotEdges_CheckedChanged(object sender, EventArgs e)
    {
      MyDrawing.SetState(_ctrlRadEdges.Checked);
      MainUnitProcessor.Model.SetTurning(0);
      DrawImage();
    }

    private void _ctrlCanvas_MouseDown(object sender, MouseEventArgs e)
    {
      Drawing = true;
      if (MainUnitProcessor.Model != null)
        MainUnitProcessor.Model.SetTurning(0);
      e0 = e;
    }

    private void _ctrlCanvas_MouseMove(object sender, MouseEventArgs e)
    {
      if (MainUnitProcessor.Model != null && Drawing)
      {
        MyDrawing.SetDelta(e0, e);
        e0 = e;
        MainUnitProcessor.Model.SetTurning(0);
        DrawImage();
      }
    }

    private void _ctrlCanvas_MouseUp(object sender, MouseEventArgs e)
    {
      Drawing = false;
    }

    private void _ctrlNumLigX_ValueChanged(object sender, EventArgs e)
    {
      MainUnitProcessor.Model.SetLightVector(
        (double)_ctrlNumLigX.Value,
        (double)_ctrlNumLigY.Value,
        (double)_ctrlNumLigZ.Value);
      MainUnitProcessor.Model.SetTurning(0);
      DrawImage();
    }

    private void _ctrlChBModelZoom_CheckedChanged(object sender, EventArgs e)
    {
      MyDrawing.Normasl = _ctrlChBModelZoom.Checked;
      MainUnitProcessor.Model.SetTurning(0);
      DrawImage();
    }

    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
      if (MainUnitProcessor.Model != null)
      {
        MyDrawing.Alf = (double)(numericUpDown1.Value / 10);
        DrawImage();

      }
    }

    private void numericUpDown2_ValueChanged(object sender, EventArgs e)
    {
      if (MainUnitProcessor.Model != null)
      {
        MyDrawing.Bet = (double)(numericUpDown2.Value / 10);
        DrawImage();
      }
    }
  }
}

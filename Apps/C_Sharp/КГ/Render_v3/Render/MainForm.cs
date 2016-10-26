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
    private static Graphics _Canvas;
    public static Graphics LogicsCanvas;
    private MouseEventArgs _e0;
    private bool _drawing;
    public MainForm()
    {
      InitializeComponent();
      MouseWheel += new MouseEventHandler(_ctrlCanvas_MouseWheel);
      _Canvas = _ctrlCanvas.CreateGraphics();
      MyDrawing.Canvas = new Bitmap(_ctrlCanvas.Width, _ctrlCanvas.Height);
      _drawing = false;
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
          if (_ctrlRBGrZ.Checked)
            MyDrawing.ChangeWindowXY(e.X, e.Y, e.Delta);
          else if (_ctrlRBZoom.Checked)
            MainUnitProcessor.Model.ZoomWithCoeffs(e.Delta, (double)_ctrlNumZoomX.Value, (double)_ctrlNumZoomY.Value, (double)_ctrlNumZoomZ.Value);
          else
            MainUnitProcessor.Model.MoveWithCoeffs(e.Delta, (double)_ctrlNumMoveX.Value, (double)_ctrlNumMoveY.Value, (double)_ctrlNumMoveZ.Value);
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
      _ParseFile();
      MyDrawing.SetMonitor(_ctrlCanvas.Width, _ctrlCanvas.Height);
      DrawImage();
    }
    public static void DrawImage()
    {
      //LogicsCanvas.Clear(Color.Black);
      MyDrawing.Draw();
      _Canvas.DrawImage(MyDrawing.Canvas, 0, 0);
    }
    private void _ParseFile()
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
      _drawing = true;
      if (MainUnitProcessor.Model != null)
        MainUnitProcessor.Model.SetTurning(0);
      _e0 = e;
    }

    private void _ctrlCanvas_MouseMove(object sender, MouseEventArgs e)
    {
      if (MainUnitProcessor.Model != null && _drawing)
      {
        MyDrawing.SetDelta(_e0, e);
        _e0 = e;
        MainUnitProcessor.Model.SetTurning(0);
        DrawImage();
      }
    }

    private void _ctrlCanvas_MouseUp(object sender, MouseEventArgs e)
    {
      _drawing = false;
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
      MyDrawing.hasNormalsVisible = _ctrlChBNormals.Checked;
      MainUnitProcessor.Model.SetTurning(0);
      DrawImage();
    }
    private void Numeric_ValueChanged(object sender, EventArgs e)
    {
      if (MainUnitProcessor.Model != null)
      {
        MyDrawing.alphaAngle = (double)_ctrlNumAngleAlf.Value;
        MyDrawing.betaAngle = (double)_ctrlNumAngleBet.Value;
        MyDrawing.leftXViewingBoundary = (double)_ctrlNumXLef.Value;
        MyDrawing.rightXViewingBoundary = (double)_ctrlNumXRig.Value;
        MyDrawing.upperYViewingBoundary = (double)_ctrlNumYHig.Value;
        MyDrawing.lowerYViewingBoundary = (double)_ctrlNumYLow.Value;
        MyDrawing.fxc = (double)_ctrlNumFXC.Value;
        MyDrawing.fyc = (double)_ctrlNumFYC.Value;
        MyDrawing.fzc = (double)_ctrlNumFZC.Value;
        DrawImage();
      }
    }

    private void _ctrlChBDebug_CheckedChanged(object sender, EventArgs e)
    {
      _ctrlGrBDebug.Enabled = _ctrlChBDebug.Checked;
      if (_ctrlChBDebug.Checked)
      {
        Width = 1390;
      }
      else
      {
        Width = 1230;
      }
    }

    private void numericColorValue(object sender, EventArgs e)
    {
      MyDrawing.redOne = (int)_ctrlNumRed.Value;
      MyDrawing.greenOne = (int)_ctrlNumGreen.Value;
      MyDrawing.blueOne = (int)_ctrlNumBlue.Value;
      if (MainUnitProcessor.Model != null)
        DrawImage();
    }

    private void MainFormReloadDrawEvent(object sender, EventArgs e)
    {
      if (MainUnitProcessor.Model != null)
        DrawImage();
    }

    private void _ctrlRBGrZ_CheckedChanged(object sender, EventArgs e)
    {
      _ctrlGrBAxis.Enabled = _ctrlGrBModelZoom.Enabled = _ctrlGrBMove.Enabled = false;
    }

    private void _ctrlRBR_CheckedChanged(object sender, EventArgs e)
    {
      _ctrlGrBAxis.Enabled = true;
      _ctrlGrBModelZoom.Enabled = false;
      _ctrlGrBMove.Enabled = false;
    }

    private void _ctrlRadButZoom_CheckedChanged(object sender, EventArgs e)
    {
      _ctrlGrBAxis.Enabled = false;
      _ctrlGrBModelZoom.Enabled = true;
      _ctrlGrBMove.Enabled = false;
    }

    private void _ctrlRBZoomX_CheckedChanged(object sender, EventArgs e)
    {
      if (MainUnitProcessor.Model != null)
        Convert.ToByte((sender as RadioButton).Tag);
    }
   
    private void _ctrlSetQuality(object sender, EventArgs e)
    {
      if (MainUnitProcessor.Model != null)
      {
        MyDrawing.HD = (System.Drawing.Drawing2D.SmoothingMode)Convert.ToInt32((sender as RadioButton).Tag);
        MainUnitProcessor.Model.SetTurning(0);
        DrawImage();
      }
    }

    private void _ctrlRBMove_CheckedChanged(object sender, EventArgs e)
    {
      _ctrlGrBAxis.Enabled = false;
      _ctrlGrBModelZoom.Enabled = false;
      _ctrlGrBMove.Enabled = true;
    }
  }
}

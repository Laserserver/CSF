using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _19_6
{
  public partial class LoTVHelpForm : Form
  {
    public LoTVHelpForm()
    {
      InitializeComponent();
    }

    private void LoTVHelpForm_Load(object sender, EventArgs e)
    {
      int w = Screen.PrimaryScreen.Bounds.Width;
      Location = new Point(w - Width, 30);
      Height = 150;
      _ctrlGRBSelecter.Enabled = true;
      _ctrlGRBSelecter.Visible = true;
      _ctrlGSelect_Move.Checked = true;
    }

    private void _ctrlRad1_CheckedChanged(object sender, EventArgs e)
    {
      ResetVisibleAndArgsSender(_ctrlGRBSelecter, _ctrlGRBRoads, sender, e, "Выбор действия");
      _ctrlGSelect_Move.Checked = true;
    }
    private void _ctrlRad3_CheckedChanged(object sender, EventArgs e)
    {
      ResetVisibleAndArgsSender(_ctrlGRBRoads, _ctrlGRBSelecter, sender, e, "Редактор путей");
      _ctrlGRoads_Street.Checked = true;
    }
    void ResetVisibleAndArgsSender(Control Vis, Control Hide, object Sender, EventArgs Event, string Text)
    {
      this.Text = Text;
      LoTVMainForm.ToolsType = Convert.ToByte((Sender as RadioButton).Tag);
      Height = 150;
      Hide.Enabled = Hide.Visible = false;
      Vis.Enabled = Vis.Visible = true;
    }

    private void _ctrlGRoads_Street_CheckedChanged(object sender, EventArgs e)
    {
      LoTVMainForm.RoadType = Convert.ToByte((sender as RadioButton).Tag);
        switch (Convert.ToByte((sender as RadioButton).Tag))
        {
            case 0:
                _ctrlRoadCount.Maximum = 2;
                _ctrlRoadCount.Minimum = 1;
                _ctrlRoadCount.Value = 1;
            break;
          case 1:
                _ctrlRoadCount.Maximum = 4;
                _ctrlRoadCount.Minimum = 3;
                _ctrlRoadCount.Value = 3;
            break;
          case 2:
                _ctrlRoadCount.Maximum = 6;
                _ctrlRoadCount.Minimum = 5;
                _ctrlRoadCount.Value = 5;
            break;
        }
    }
    private void _ctrlGSelect_Move_CheckedChanged(object sender, EventArgs e)
    {
      LoTVMainForm.SelecterType = Convert.ToByte((sender as RadioButton).Tag);
    }

    private void _ctrlRad2_CheckedChanged(object sender, EventArgs e)
    {
      SendArgs(sender, e, "Добавление узла");
    }
    private void _ctrlRad4_CheckedChanged(object sender, EventArgs e)
    {
      SendArgs(sender, e, "Удаление пути");
    }
    private void _ctrlRad5_CheckedChanged(object sender, EventArgs e)
    {
      SendArgs(sender, e, "Удаление узла");
    }
    private void _ctrlRad6_CheckedChanged(object sender, EventArgs e)
    {
      SendArgs(sender, e, "Передвижение по графу");
    }
    void SendArgs(object sender, EventArgs e, string Text)
    {
      this.Text = Text;
      LoTVMainForm.ToolsType = Convert.ToByte((sender as RadioButton).Tag);
      _ctrlGRBRoads.Enabled = _ctrlGRBRoads.Visible = _ctrlGRBSelecter.Enabled = _ctrlGRBSelecter.Visible = false;
      Height = 75;
    }

    private void _ctrlRoadCount_ValueChanged(object sender, EventArgs e)
    {
      LoTVMainForm.RoadCount = Convert.ToByte(_ctrlRoadCount.Value);
    }
  }
}

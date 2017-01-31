using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Oop.Tasks.Paint.Interface;


namespace Oop.Tasks.Paint.Plugins
{
    public partial class PaintEllipsePluginOptionsControl : UserControl
    {
        private IPaintApplicationContext applicationContext = null;

        private string[] brushStyleNames = null;

        private HatchStyle[] brushStyleValues = null;

        private int En = 0;
        public PaintEllipsePluginOptionsControl(IPaintApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;

            InitializeComponent();

            Type brushStyleType = typeof(HatchStyle);
            brushStyleNames = Enum.GetNames(brushStyleType);
            brushStyleValues = (HatchStyle[])Enum.GetValues(brushStyleType);

            brushStyleListBox.Items.Add("Solid");
            brushStyleListBox.Items.AddRange(brushStyleNames);
            brushStyleListBox.SelectedIndex = 0;

        }
        internal Brush GetBrush()
        {
            if (applicationContext == null)
                return null;

            Brush result = null;
            int index = brushStyleListBox.SelectedIndex;
            if (index == 0)
                result = new SolidBrush(applicationContext.BackgroundColor);
            else
            {
                HatchStyle brushStyle = brushStyleValues[index - 1];
                result = new HatchBrush(brushStyle,
                                      applicationContext.ForegroundColor,
                                      applicationContext.BackgroundColor);
            }

            return result;
        }

        internal Pen GetPen()
        {
            if (applicationContext == null)
                return null;

            Pen result = new Pen(applicationContext.ForegroundColor, (int)numericUpDownForPen.Value);
            return result;
        }

        internal int GetEn()
        {
            return En;
        }


        internal void InvalidateResult()
        {
        }

        private void withEdge_CheckedChanged(object sender, EventArgs e)
        {
            if (withEdge.Checked)
                En = 0;
        }

        private void withEdgeAndSmth_CheckedChanged(object sender, EventArgs e)
        {
            if (withEdgeAndSmth.Checked)
                En = 1;
        }

        private void withoutEdge_CheckedChanged(object sender, EventArgs e)
        {
            if (withoutEdge.Checked)
                En = 2;
        }
    }
}

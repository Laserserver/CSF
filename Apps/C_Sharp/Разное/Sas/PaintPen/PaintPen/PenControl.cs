using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oop.Tasks.Paint.Interface;

namespace PaintPen
{
    public partial class PenControl : UserControl
    {
        private IPaintApplicationContext applicationContext = null;

        public PenControl(IPaintApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
            InitializeComponent();
        }
        internal Pen GetPen()
        {
            if (applicationContext == null)
                return null;

            Pen result = new Pen(applicationContext.ForegroundColor, (int)numericUpDown1.Value);
            return result;
        }
        internal void InvalidateResult()
        {
        }
        public PenControl()
        {
            InitializeComponent();
        }
    }
}

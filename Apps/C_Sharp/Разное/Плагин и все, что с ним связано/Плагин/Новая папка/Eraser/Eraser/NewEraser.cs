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

namespace Eraser
{
    public partial class NewEraser : UserControl
    {
        private IPaintApplicationContext applicationContext = null;
        public NewEraser(IPaintApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
            InitializeComponent();
        }
        internal int GetPen()
        {
            if (applicationContext == null)
                return 0;

            int result = Convert.ToInt32(B.Text);
            return result;
        }

        internal void InvalidateResult()
        {
        }
    }
}

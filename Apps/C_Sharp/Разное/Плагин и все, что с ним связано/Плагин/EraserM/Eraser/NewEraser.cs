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
            int result=0; 
            if (applicationContext == null)
                return 0;

            try
            {
                result = Convert.ToInt32(B.Text);
                
            }
            catch
            {
                MessageBox.Show("Введите размер ластика!");
            }
            return result;
        }

        internal void InvalidateResult()
        {
        }
    }
}

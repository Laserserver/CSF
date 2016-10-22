using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D ; 


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            //SetStyle(ControlStyles.Opaque, true); 
            
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //SystemColors 
            //Graphics g = e.Graphics;
            Graphics g = this.CreateGraphics();

            MyClass c = new MyClass();
            c.Draw(g);

            g.Dispose();
        }
    }
}

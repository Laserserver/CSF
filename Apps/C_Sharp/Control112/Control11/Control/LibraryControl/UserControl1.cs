using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;



namespace LibraryControl
{

    public partial class Diagram : UserControl
    {
        Graphics g;
        int CursorX, CursorY;
        double Sum = 0;
        float fAngle = 0;
        float fSweep;
        float Procent;
        double[] mas;
        Pen pen = new Pen(Color.Black, 3);
        Rectangle rect = new Rectangle(10, 10,300, 300);

        Operation op;// =  Operation.None;

        public enum Operation
        {
            [Description ("None")]
            None =0,
            [Description ("Number")]
            Number=1,
            [Description ("Procent")]
            Procent=2,
        [Description ("Number with Procent")]
            NumberWithProcent=3,
          
        }

        [Category("The print of values")]
        [DefaultValue(Operation.Number)]
        public Operation Print
        {
            get { return op; }
            set {
                var z = panel1.Controls.OfType<RadioButton>();
                var b = z.First((x) => x.Tag.ToString() == ((int)value).ToString());
                b.Checked = true;
                }
        }
       
    
       
    
        public Diagram()
        {
          
            InitializeComponent();

           
          
            
            radioButton1.CheckedChanged+=new EventHandler(radioNum_CheckedChanged);
            radioButton2.CheckedChanged+=new EventHandler(radioNum_CheckedChanged);
            radioButton3.CheckedChanged+=new EventHandler(radioNum_CheckedChanged);
            radioButton4.CheckedChanged += new EventHandler(radioNum_CheckedChanged);
            
        }
    
        private void UserControl1_Load(object sender, EventArgs e)
        {

              Generate();
              pictureBox1.Invalidate();
            
        }

        private void Draw(Graphics gr, int w, int h)
        {


            Bitmap bt = new Bitmap(w, h);
            g = Graphics.FromImage(bt);
            g.Clear(Color.White);

            Sum = 0;
            foreach (int iValue in mas)
                Sum += iValue;
            fSweep = 0;
            Random rd = new Random();
            foreach (int iValue in mas)
            {

                fSweep = 360.0F * iValue / (float)Sum;

                g.DrawPie(pen, rect, fAngle, fSweep);
                g.FillPie(new SolidBrush(Color.FromArgb(rd.Next(255), rd.Next(255), rd.Next(255))), rect, fAngle, fSweep);
                fAngle += fSweep;


            }
            gr.DrawImage(bt,0,0);
            bt.Dispose();
        }
        public void Generate()
        {
           
            string s1 = MyNumbers;
            string[] arrstring = new string[100];
            if (s1 != "")
            {
                arrstring = s1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
            mas = new double[arrstring.Length];
            for (int i = 0; i < arrstring.Length; i++)
            {
                mas[i] = Convert.ToInt32(arrstring[i]);
            }
          
        
           
        }

        public delegate void MyEventHandler(object sender, EventArgs e);

        public event MyEventHandler MyNumberChanged;

        protected  void OnMyNumberChangedEvent()
        {
            if (MyNumberChanged != null)
                MyNumberChanged(this, EventArgs.Empty);
        }
        [Category("The numbers in the array")]
        public string MyNumbers
        {
            get
            {
                return Numbers.Text;
            }
            set
            {
                Numbers.Text = value;
                Generate();
                if (Numbers.Text != null)
                {
                    OnMyNumberChangedEvent();
   

                }
            }
        }
    
      
       
      
      
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            bool s = panel1.Visible;
            panel1.Visible = false;
            
            Draw(e.Graphics, e.ClipRectangle.Width, e.ClipRectangle.Height);
            
            panel1.Visible = s;
           
        }

      


 

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
        
           
            CursorX = e.X-160 ;
            CursorY = e.Y-160 ;
           float realAngle = -((float)(Math.Atan2(CursorY, -CursorX)*180F/Math.PI)-180);

           Sum = 0;
         
           foreach (float iValue in mas)
           {
               Sum += iValue;
               
           }
           
         
            fSweep = 0;
            foreach (float iValue in mas)
            {
                Procent = (float)Math.Round((iValue / Sum) * 100);
               
                fSweep += 360.0F * iValue / (float)Sum;
             
                    if ( realAngle< fSweep)
                    {
                        
                        switch (op)
                        {

                            case Operation.Number:
                           
                        toolTip1.Show("Значение: " + iValue.ToString(), pictureBox1,e.X+10,e.Y+15);
                        
                        break;
                            case Operation.NumberWithProcent:
                        string str = "Значение: " + iValue.ToString() + "\n " + "Процент: "+ Procent.ToString() + "%";
                                toolTip1.Show(str,pictureBox1,e.X+10,e.Y+15);
                        break; 
                            case Operation.Procent:
                        toolTip1.Show("Процент: " + Procent.ToString() + "%", pictureBox1, e.X + 10, e.Y + 15);
                        break; 


                        }

                      
                        break;

                    }
            }
        }


        private void radioNum_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                int tag = int.Parse(((RadioButton)sender).Tag.ToString());
                op = (LibraryControl.Diagram.Operation)tag;
               
                pictureBox1.Invalidate();
                //panel1.Visible = false;
            
                
             
            }
        }

      
        private void Numbers_TextChanged(object sender, EventArgs e)
        {
           Generate();
            pictureBox1.Invalidate();
            OnMyNumberChangedEvent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
            //pictureBox1.Invalidate();
        }

        private Point lastLocation = new Point(0, 0);

        //private void panel1_MouseMove(object sender, MouseEventArgs e)
        //{
      
        //    if (e.Button == System.Windows.Forms.MouseButtons.Left)
        //    {
             
        //     panel1.Location = new Point(panel1.Location.X + e.Location.X- lastLocation.X, panel1.Location.Y + e.Location.Y - lastLocation.Y);
              
        //     panel1.Invalidate();
        //    }
        //    lastLocation = e.Location;
          
        //}

   
       
        }
    
    
    }

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Render
{
    public partial class Form1 : Form
    {
        int Angl;
        double zoomConst;
        int CenterX = 0;
        int CenterY = 0;
        int[] LightV =  new int [3];
        Bitmap DrawOn;
        public Form1()
        {
            InitializeComponent();
        }
        FIleVoid f;
        Graphics g;
        private void button1_Click(object sender, EventArgs e)
        {
            if (fileName.Text == "")
                return;
            g = panel1.CreateGraphics();

            DrawOn = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            f = new FIleVoid();
            string[] arr = fileName.Text.Split('|');
            f.Parse0(arr[0], "texture/" + arr[1]);
            Angl = 201;
            double.TryParse(zoomBox.Text, out zoomConst);

            //f.currModel.quickSortPol(f.currModel.polygons, 0, f.currModel.polygons.Length - 1);
            f.currModel.SortPolygons();
            Draw0();

        }
        public void Draw0()
        {
            string[] str = light.Text.Split(';');
            for (int i = 0; i < 3; i++)
                LightV[i] = Int32.Parse(str[i]);
            Const.deepCoef = Int32.Parse(deepCoef.Text);
            Const.soft = softLightning.Checked;
            Const.LightV = LightV;
            Const.coefControl = coefControl.Text;
            Const.CenterX = CenterX;
            Const.CenterY = CenterY;
            Const.zoomConst = zoomConst;
            Const.Angl = Angl;
            Const.isNormal = normalsOn.Checked;
            f.currModel.Draw(DrawOn, coefControl.Text, isFill.Checked, edgeMod.Checked, pointsOn.Checked);
            //Draw(DrawOn);
            g.DrawImage(DrawOn, ClientRectangle);


        }
        //private void Draw(Bitmap DrawOn)
        //{


        //    using (Graphics G = Graphics.FromImage(DrawOn))
        //    {
        //        double x;
        //        double y;
        //        double z;
        //        int x_fin;
        //        int y_fin;
        //        string[] str = light.Text.Split(';');
        //        for (int i = 0; i < 3; i++)
        //            LightV[i] = Int32.Parse(str[i]);
        //        G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //        G.Clear(Color.Black);
        //        int xx = Convert.ToInt32(CenterX + (LightV[0] - (LightV[2]) * Math.Cos(Angl / 180.0 * Math.PI) / 2.0) * zoomConst);
        //        int yy = Convert.ToInt32(CenterY - (LightV[1] + (LightV[2]) * Math.Sin(Angl / 180.0 * Math.PI) / 2.0) * zoomConst);
        //        x = f.currModel.polygons[0].X;
        //        z = f.currModel.polygons[0].Z;
        //        G.DrawLine(new Pen(Color.Red), Convert.ToInt32(CenterX - (x + (z) * Math.Sin(Angl / 180.0 * Math.PI) / 2.0) * zoomConst), 1, 1 + xx, 1 + yy);
        //        if (f.currModel.polygons != null)
        //        {
                    
        //            if (isFill.Checked)
        //                for (int i = 0; i < f.currModel.polygons.Length; i++)
        //                {
        //                    x = f.currModel.polygons[i].X;
        //                    y = f.currModel.polygons[i].Y;
        //                    z = f.currModel.polygons[i].Z;
        //                    x_fin = Convert.ToInt32(CenterX + (x - (z) * Math.Cos(Angl / 180.0 * Math.PI) / 2.0) * zoomConst);
        //                    y_fin = Convert.ToInt32(CenterY - (y + (z) * Math.Sin(Angl / 180.0 * Math.PI) / 2.0) * zoomConst);
        //                    //double ang = Math.Acos((x_fin * xx + y_fin * yy) / (Math.Sqrt(xx*xx + yy*yy) * Math.Sqrt(x_fin*x_fin + y_fin* y_fin)));
        //                    //arccos((x1x2 + y1y2 + z1z2)/(длина1 + длина2))
        //                    double ang = Math.Acos((LightV[0] * f.currModel.polygons[i].X + LightV[1] * f.currModel.polygons[i].Y + LightV[2] * f.currModel.polygons[i].Z)/(
        //                        Math.Sqrt(LightV[0]* LightV[0] + LightV[1]* LightV[1] + LightV[2]* LightV[2]) * 
        //                        Math.Sqrt(f.currModel.polygons[i].X * f.currModel.polygons[i].X + f.currModel.polygons[i].Y * f.currModel.polygons[i].Y + f.currModel.polygons[i].Z * f.currModel.polygons[i].Z)));
        //                    ang = ang * 180 / Math.PI;
        //                    double aS = Math.Asin((LightV[0] * f.currModel.polygons[i].X + LightV[1] * f.currModel.polygons[i].Y + LightV[2] * f.currModel.polygons[i].Z) / (
        //                        Math.Sqrt(LightV[0] * LightV[0] + LightV[1] * LightV[1] + LightV[2] * LightV[2]) *
        //                        Math.Sqrt(f.currModel.polygons[i].X * f.currModel.polygons[i].X + f.currModel.polygons[i].Y * f.currModel.polygons[i].Y + f.currModel.polygons[i].Z * f.currModel.polygons[i].Z)));
        //                    double coef;
        //                    if (aS > 0)
        //                        coef = (ang) / 180;
        //                    else
        //                        coef = (ang) / 180 * (-1);
        //                    double coefC = 0;
        //                    double.TryParse(coefControl.Text, out coefC);
        //                    if (coef > coefC)
        //                        G.FillPolygon(new SolidBrush(Color.FromArgb(Convert.ToInt32(140*(1-coef)), Convert.ToInt32(255* (1 - coef)), Convert.ToInt32(140* (1 - coef)))), toArr(i));
        //                    else
        //                        G.FillPolygon(new SolidBrush(Color.FromArgb(Convert.ToInt32(140 *  0.00001), Convert.ToInt32(255 * 0.00001), Convert.ToInt32(140 * 0.00001))), toArr(i));

        //                }
        //            else
        //                if (edgeMod.Checked)
        //                for (int i = 0; i < f.currModel.polygons.Length; i++)
        //                {
        //                    G.DrawPolygon(new Pen(Color.AliceBlue), toArr(i));
        //                }


        //        }


                
                

        //        if (pointsOn.Checked)
        //        for (int i = 0; i < f.currModel.points.Length; i++)
        //        {
        //            x = f.currModel.points[i].X ;
        //            y = f.currModel.points[i].Y ;
        //            z = f.currModel.points[i].Z ;
        //            x_fin = Convert.ToInt32(CenterX + (x - (z) * Math.Cos(Angl / 180.0 * Math.PI) / 2.0) * zoomConst);
        //            y_fin = Convert.ToInt32(CenterY - (y + (z) * Math.Sin(Angl / 180.0 * Math.PI) / 2.0) * zoomConst);
        //            //G.FillEllipse(new SolidBrush(Color.Aquamarine), x_fin, y_fin, 1, 1);
        //            G.DrawEllipse(new Pen(Color.SlateGray), x_fin, y_fin, 1, 1);
        //        }

        //        if (normalsOn.Checked)
        //        for (int i = 0; i < f.currModel.polygons.Length; i++)
        //        {
        //            int x_fin1 = 0;
        //            int y_fin1 = 0;
        //            int x_fin2 = 0;
        //            int y_fin2 = 0;
        //            DrawNormals(out x_fin1, out y_fin1, out x_fin2, out y_fin2, i);
        //            G.DrawLine(new Pen(Color.Pink), x_fin1, y_fin1, x_fin2, y_fin2);
        //        }
        //        //if (f.currModel.polygons != null)
        //        //{
        //        //    G.DrawPolygon(new Pen(Color.AliceBlue), );
        //        //}

        //    }

        //}
        
       
        //private void DrawNormals(out int x_fin1, out int y_fin1, out int x_fin2, out int y_fin2, int i)
        //{
            
        //    double x2 = f.currModel.polygons[i].X * 10 + f.currModel.polygons[i].center[0] ;
        //    double y2 = f.currModel.polygons[i].Y * 10 + f.currModel.polygons[i].center[1] ;
        //    double z2 = f.currModel.polygons[i].Z * 10 + f.currModel.polygons[i].center[2] ;
        //    x_fin1 = Convert.ToInt32(CenterX + (f.currModel.polygons[i].center[0] - (f.currModel.polygons[i].center[2]) * Math.Cos(Angl / 180.0 * Math.PI) / 2.0) * zoomConst);
        //    y_fin1 = Convert.ToInt32(CenterY - (f.currModel.polygons[i].center[1] + (f.currModel.polygons[i].center[2]) * Math.Sin(Angl / 180.0 * Math.PI) / 2.0) * zoomConst);
        //    x_fin2 = Convert.ToInt32(CenterX + (x2  - (z2 ) * Math.Cos(Angl / 180.0 * Math.PI) / 2.0) * zoomConst);
        //    y_fin2 = Convert.ToInt32(CenterY - (y2   + (z2 ) * Math.Sin(Angl / 180.0 * Math.PI) / 2.0) * zoomConst);
        //}
        //private Point[] toArr(int t)
        //{
        //    double x;
        //    double y;
        //    double z;


        //    Point[] p = new Point[0];
        //    for (int i = 0; i < f.currModel.polygons[t].dots.Length; i++)
        //    {
        //        Array.Resize<Point>(ref p, p.Length + 1);
        //        x = (f.currModel.points[f.currModel.polygons[t].dots[i] - 1].X);
        //        y = (f.currModel.points[f.currModel.polygons[t].dots[i] - 1].Y);
        //        z = (f.currModel.points[f.currModel.polygons[t].dots[i] - 1].Z);
        //        p[p.Length - 1].X = Convert.ToInt32(CenterX + (x - (z) * Math.Cos(Angl / 180.0 * Math.PI) / 2.0) * zoomConst);
        //        p[p.Length - 1].Y = Convert.ToInt32(CenterY - (y + (z) * Math.Sin(Angl / 180.0 * Math.PI) / 2.0) * zoomConst);

        //    }
        //    return p;
        //}












        private void button3_Click(object sender, EventArgs e)
        {
            Angl -= 2;
            Draw0();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Angl += 2;
            Draw0();
        }

        private void zoomBut_Click(object sender, EventArgs e)
        {
            double step = 0;
            if (Double.TryParse(zoomConstT.Text, out step))
            {
                f.currModel.Zoom(step);
            }
            //if (zoomConst > 20)
            //    zoomConst = 2;
            //zoomConst += 10;
            Draw0();
        }

        private void yMinus_Click(object sender, EventArgs e)
        {
            CenterY -= 50;
            Draw0();
        }

        private void yPlus_Click(object sender, EventArgs e)
        {
            CenterY += 50;
            Draw0();
        }

        private void xMinus_Click(object sender, EventArgs e)
        {
            CenterX -= 50;
            Draw0();
        }

        private void xPlus_Click(object sender, EventArgs e)
        {
            CenterX += 50;
            Draw0();
        }

        private void zoomMinus_Click(object sender, EventArgs e)
        {
            double step = 0;
            if (Double.TryParse(zoomConstT.Text, out step))
            {
                f.currModel.Zoom(1/step);
            }
            //zoomConst -= 10;
            Draw0();
        }

        private void turnPlus_Click(object sender, EventArgs e)
        {
            using (Graphics G = Graphics.FromImage(DrawOn))
            {
                int x, y, z;
                double angl;
                string[] str = turnV.Text.Split(';');
                if (
                Int32.TryParse(str[0], out x) &&
                Int32.TryParse(str[1], out y) &&
                Int32.TryParse(str[2], out z) &&
                Double.TryParse(str[3], out angl))
                {
                    
                    //   f.currModel.quickSortPol(f.currModel.polygons, 0, f.currModel.polygons.Length - 1);
                    //double z = f.currModel.polygons[0].center[2];
                   // x_fin = Convert.ToInt32(CenterX + (f.currModel.polygons[0].center[0] - (z) * Math.Cos(Angl / 180.0 * Math.PI) / 2.0) * zoomConst);
                    //y_fin = Convert.ToInt32(CenterY - (f.currModel.polygons[0].center[1] + (z) * Math.Sin(Angl / 180.0 * Math.PI) / 2.0) * zoomConst);
                   // x_fin1 = Convert.ToInt32(CenterX + (x - (z) * Math.Cos(Angl / 180.0 * Math.PI) / 2.0) * zoomConst);
                   // y_fin1 = Convert.ToInt32(CenterX + (y - (z) * Math.Cos(Angl / 180.0 * Math.PI) / 2.0) * zoomConst);
                   // G.DrawLine(new Pen(Color.Chocolate), x_fin, y_fin, x_fin1, y_fin1);
                    f.currModel.TurnDownForWhat(angl, x, y, z);
                    f.currModel.SortPolygons();
                    f.currModel.PushNormal();
                    //currModel.quickSortPol(f.currModel.polygons, 0, f.currModel.polygons.Length - 1);
                    
                }
            }
            //g.DrawImage(DrawOn, ClientRectangle);
            Draw0();
        }

        private void turnMinus_Click(object sender, EventArgs e)
        {
            using (Graphics G = Graphics.FromImage(DrawOn))
            {
                int x, y, z;
                double angl;
                string[] str = turnV.Text.Split(';');
                if (
                Int32.TryParse(str[0], out x) &&
                Int32.TryParse(str[1], out y) &&
                Int32.TryParse(str[2], out z) &&
                Double.TryParse(str[3], out angl))
                {
                    
                    // f.currModel.quickSortPol(f.currModel.polygons, 0, f.currModel.polygons.Length - 1);
                    angl = angl * (-1);
                    //double z = f.currModel.polygons[0].center[2];
                    //x_fin = Convert.ToInt32(CenterX + (f.currModel.polygons[0].center[0] - (z) * Math.Cos(Angl / 180.0 * Math.PI) / 2.0) * zoomConst);
                    //y_fin = Convert.ToInt32(CenterY - (f.currModel.polygons[0].center[1] + (z) * Math.Sin(Angl / 180.0 * Math.PI) / 2.0) * zoomConst);
                    //x_fin1 = Convert.ToInt32(CenterX + (x - (z) * Math.Cos(Angl / 180.0 * Math.PI) / 2.0) * zoomConst);
                    //y_fin1 = Convert.ToInt32(CenterX + (y - (z) * Math.Cos(Angl / 180.0 * Math.PI) / 2.0) * zoomConst);
                   // G.DrawLine(new Pen(Color.Chocolate), x_fin, y_fin, x_fin1, y_fin1);
                    f.currModel.TurnDownForWhat(angl, x, y, z);
                    f.currModel.PushNormal();
                    //f.currModel.quickSortPol(f.currModel.polygons, 0, f.currModel.polygons.Length - 1);
                    f.currModel.SortPolygons();
                }
            }
            //g.DrawImage(DrawOn, ClientRectangle);
            Draw0();
        }
        int X;
        int Y;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;
            //turn = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (!turn) return;
            //int 
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            double angle = 0;
            if (e.OldValue < e.NewValue)
                angle = -0.1;
            else
                angle = 0.1;
            if (turnOX.Checked)
                f.currModel.TurnDownForWhat(angle, 1, 0, 0);
            else
                f.currModel.TurnDownForWhat(angle, 0, 1, 0);
            f.currModel.PushNormal();
            
            f.currModel.SortPolygons();
            Draw0();
        }
    }
}

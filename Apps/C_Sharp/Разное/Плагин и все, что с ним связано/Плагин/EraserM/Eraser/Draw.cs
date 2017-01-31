using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Text;
using Oop.Tasks.Paint.Interface;
using System.Windows.Forms;

namespace Eraser
{
    [PluginForLoad(true)]
    public class MyEraser :
                 IToolPaintPlugin
    {
        private IPaintPluginContext pluginContext = null;
        private NewEraser optionsControl = null;


        private Image icon = null;
        private Cursor cursor = null;
        private Image img;
        private MouseEventArgs m0 = null;
        private bool flag = false;
        private IPaintApplicationContext ApplicationContext
        {
            get
            {
                if (pluginContext == null)
                    return null;
                else return pluginContext.ApplicationContext;
            }
        }

        public void AfterCreate(IPaintPluginContext pluginContext)
        {
            this.pluginContext = pluginContext;
            optionsControl = new NewEraser(ApplicationContext);
            string imageDir = pluginContext.PluginDir;
            if (imageDir != null)
            {
                imageDir += @"\Images\";

                try
                {
                    icon = Image.FromFile(imageDir + "kst.png");
                }
                catch { }
                try
                {
                    cursor = new Cursor(imageDir + "kst.png");
                }
                catch { }
            }
        }

        public void BeforeDestroy()
        {
            optionsControl.Dispose();
            optionsControl = null;
            if (icon != null)
                icon.Dispose();
            if (cursor != null)
                cursor.Dispose();
        }

        public void Select(bool selection)
        {
            if (selection)
            {
                ApplicationContext.OptionsControl = optionsControl;
                ApplicationContext.Cursor = cursor;
            }
            else
            {
                ApplicationContext.OptionsControl = null;
                ApplicationContext.Cursor = null;
            }
        }

        public string Name { get { return this.GetType().Name; } }
        public string CommandName
        {
            get
            {
                return "Градиент";
            }
        }
        
        int x0, y0; 
        public void MouseDown(MouseEventArgs me, Keys modifierKeys)
        {


            m0 = me;
            flag = true;
            if (img != null)
                img.Dispose();
            img = (Image)ApplicationContext.Image.Clone();

        }

        public void MouseUp(MouseEventArgs me, Keys modifierKeys)
        {
            flag = false;
        }

        Point P(MouseEventArgs e)
        {
            return new Point(e.X, e.Y);
        }

        public void MouseMove(MouseEventArgs me, Keys modifierKeys)
        {
           if (flag)
            {
                Graphics graphics = Graphics.FromImage(ApplicationContext.Image);
                int p = optionsControl.GetPen();
              
                LinearGradientBrush linGrBrush = new LinearGradientBrush(
   new Point(P(me).X, P(me).Y),
   new Point(100, 100),
   Color.FromArgb(255, 255, 0, 0),   // Opaque red
   Color.FromArgb(255, 0, 0, 255));  // Opaque blue

                Pen pen = new Pen(linGrBrush);       
             
graphics.DrawLine(pen, P(me).X, P(me).Y, 100, 100);

                pen.Dispose();
                ApplicationContext.Invalidate();
            
            }
           

        }

        public void Escape() { }

        public void Enter() { }

        public void ColorChange()
        {
            optionsControl.InvalidateResult();
        }

        public void ImageChange()
        {
            optionsControl.InvalidateResult();
        }

        public string ToolName
        {
            get { return "Градиент "; }
        }

        public Image Icon
        {
            get { return icon; }
        }
    }
}

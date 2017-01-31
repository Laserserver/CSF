using System;
using System.Drawing;
using System.Windows.Forms;
using Oop.Tasks.Paint.Interface;


namespace Oop.Tasks.Paint.Plugins
{
    [PluginForLoad(true)]
    public class PaintDemoLyginLinePlagin : IToolPaintPlugin
    {
        private IPaintPluginContext pluginContext = null;
        private PaintDemo1CirclePluginOptionsControl optionsControl = null;
        private Cursor cursor = null;
        private Image icon = null;


        private IPaintApplicationContext ApplicationContext
        {
            get
            {
                if (pluginContext == null)
                    return null;
                else
                    return pluginContext.ApplicationContext;
            }
        }


        public void AfterCreate(IPaintPluginContext pluginContext)
        {
            this.pluginContext = pluginContext;

            optionsControl = new PaintDemo1CirclePluginOptionsControl(
                                   ApplicationContext);

            string imageDir = pluginContext.PluginDir;
            if (imageDir != null)
            {
                imageDir += @"\Images\";

                try
                {
                    icon = Image.FromFile(imageDir + "Icon.bmp");
                }
                catch
                {
                    // подавление исключения
                }

                try
                {
                    cursor = new Cursor(imageDir + "Cursor.cur");
                }
                catch
                {
                    // подавление исключения
                }
            }
        }


        public void BeforeDestroy()
        {
            optionsControl.Dispose();
            optionsControl = null;
            if (cursor != null)
                cursor.Dispose();
            if (icon != null)
                icon.Dispose();
        }


        public void Select(bool selection)
        {
            if (selection)
            {
                ApplicationContext.OptionsControl = optionsControl;
                ApplicationContext.Cursor = cursor;
            }
            else {
                ApplicationContext.OptionsControl = null;
                ApplicationContext.Cursor = null;
            }
        }


        public string Name
        {
            get
            {
                return this.GetType().Name;
            }
        }


        public string CommandName
        {
            get
            {
                return "Линия";
            }
        }

        int x0, y0;
        public void MouseDown(MouseEventArgs me, Keys modifierKeys)
        {
            Graphics graphics = Graphics.FromImage(ApplicationContext.Image);

            Pen pen = optionsControl.GetPen();
            Brush brush = optionsControl.GetBrush();

            int x = me.X;
            int y = me.Y;
            x0 = x;
            y0 = x;
            graphics.DrawLine(pen, x, y,x0,y0);

            pen.Dispose();
            brush.Dispose();

            ApplicationContext.Invalidate();
        }


        public void MouseUp(MouseEventArgs me, Keys modifierKeys)
        {
        }


        public void MouseMove(MouseEventArgs me, Keys modifierKeys)
        {
            Graphics graphics = Graphics.FromImage(ApplicationContext.Image);

            Pen pen = optionsControl.GetPen();
            Brush brush = optionsControl.GetBrush();

            int x = me.X;
            int y = me.Y;
            graphics.DrawLine(pen, x, y, x0, y0);

            pen.Dispose();
            brush.Dispose();

            ApplicationContext.Invalidate();
        }


        public void Escape()
        {
        }


        public void Enter()
        {
        }


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
            get
            {
                return "ЛИНИЯ";
            }
        }


        public Image Icon
        {
            get
            {
                return icon;
            }
        }
    }
}


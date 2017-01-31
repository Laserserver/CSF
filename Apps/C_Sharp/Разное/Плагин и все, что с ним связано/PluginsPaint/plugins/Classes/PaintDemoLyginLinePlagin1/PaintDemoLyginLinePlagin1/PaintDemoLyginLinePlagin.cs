using System.Drawing;
using System.Windows.Forms;
using Oop.Tasks.Paint.Interface;

namespace Oop.Tasks.Paint.Plugins
{
    [PluginForLoad(true)]
    public class PaintDemoLyginLinePlagin : IToolPaintPlugin
    {
        private IPaintPluginContext pluginContext = null;
        private PaintDemoLyginLinePluginOptionsControl optionsControl = null;
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

            optionsControl = new PaintDemoLyginLinePluginOptionsControl(
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
        bool drawing;
        int x0, y0;
        public void MouseDown(MouseEventArgs me, Keys modifierKeys)
        {
            drawing = true;

            bm = (Bitmap)ApplicationContext.Image.Clone();
            x0 = me.X;
            y0 = me.Y;
            

            ApplicationContext.Invalidate();
        }


        public void MouseUp(MouseEventArgs me, Keys modifierKeys)
        {
            drawing = false;
        }

        Bitmap bm;
        public void MouseMove(MouseEventArgs me, Keys modifierKeys)
        {
            if (drawing)
            {
                Graphics graphics = Graphics.FromImage(ApplicationContext.Image);
                Bitmap bm2 = (Bitmap)ApplicationContext.Image.Clone();
                Graphics g2 = Graphics.FromImage(bm2);
                Pen pen = optionsControl.GetPen();
                Brush brush = optionsControl.GetBrush();

                int x = me.X;
                int y = me.Y;
                g2.Clear(Color.White);
                g2.DrawImage(bm, 0, 0);
                g2.DrawLine(pen, x0, y0, x, y);
                graphics.DrawImage(bm2, 0, 0);
                //Bitmap temp = ApplicationContext.Image;
                //graphics.Clear(Color.White);
                //graphics.DrawImage(temp as Image, 0, 0);
                //graphics.DrawLine(pen, x, y, x0, y0);
                

                pen.Dispose();
                brush.Dispose();

                ApplicationContext.Invalidate();
            }
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


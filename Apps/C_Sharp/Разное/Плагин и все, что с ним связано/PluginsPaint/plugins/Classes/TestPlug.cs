using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using Oop.Tasks.Paint.Interface;

namespace Oop.Tasks.Paint.Plugins.Classes
{
    [PluginForLoad(true)]
    public class TestPlug : IToolPaintPlugin
    {
        //---------------------------------------Реализация интерфейса---------------------------//
        public string CommandName
        {
            get
            {
                return "Pen";
            }
        }

        public Image Icon
        {
            get
            {
                return icon;
            }
        }

        public string Name
        {
            get
            {
                return this.GetType().Name;
            }
        }

        public string ToolName
        {
            get { return "PenPlugin"; }
        }

        public void AfterCreate(IPaintPluginContext pluginContext)
        {
            this.pluginContext = pluginContext;

            // создание панели свойств плагина
            // (пользовательского элемента управления)
            optionsControl =
                new PaintDemo1CirclePluginOptionsControl(
                        ApplicationContext);

            // загрузка из директории плагина пиктограммы и
            // курсора
            string imageDir = pluginContext.PluginDir;
            if (imageDir != null)
            {
                imageDir += @"\Images\";

                try
                {
                    icon = Image.FromFile(imageDir + "PenIcon.jpg");
                }
                catch { } // подавление исключения

                try
                {
                    cursor = new Cursor(imageDir + "PenCursor.cur");
                }
                catch { } // подавление исключения
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
            brush.Dispose();
            graphForm.Dispose();
        }

        public void ColorChange()
        {
            throw new NotImplementedException();
        }
        public void Enter()
        {
            throw new NotImplementedException();
        }
        public void Escape()
        {
            throw new NotImplementedException();
        }
        public void ImageChange()
        {
            throw new NotImplementedException();
        }

        public void MouseDown(MouseEventArgs me, Keys modifierKeys)
        {
            graphForm = Graphics.FromImage(ApplicationContext.Image);
            graphForm.SmoothingMode = SmoothingMode.HighQuality;
            brush = new SolidBrush(penColor);
            mouseMemoryPoint = me.Location;
            isDraw = true;
        }

        public void MouseMove(MouseEventArgs me, Keys modifierKeys)
        {
            if (isDraw)
            {
                brush.Color = penColor;
                graphForm.FillRectangle(brush, me.X - 3, me.Y - 3, 6, 6);
                graphForm.DrawLine(new Pen(penColor,6),mouseMemoryPoint,me.Location);
                mouseMemoryPoint = me.Location;
                ApplicationContext.Invalidate();
            }
        }

        public void MouseUp(MouseEventArgs me, Keys modifierKeys)
        {
            isDraw = false;
        }

        public void Select(bool selection)
        {
            if (selection)
            {
                ApplicationContext.OptionsControl =
                    optionsControl;
                ApplicationContext.Cursor = cursor;
            }
            else
            {
                ApplicationContext.OptionsControl = null;
                ApplicationContext.Cursor = null;
            }
        }
        //----------------------------------Закончили объявлять интерфейс---------------------//

        private IPaintPluginContext pluginContext = null;
        private PaintDemo1CirclePluginOptionsControl optionsControl = null;
        private Cursor cursor = null;
        private Image icon = null;

        private Point mouseMemoryPoint;
        private Color penColor = Color.Black;
        private Graphics graphForm;
        private SolidBrush brush;
        private bool isDraw = false;

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

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oop.Tasks.Paint.Interface;
using System.Drawing;
using System.Windows.Forms;

namespace PaintPen
{
    [PluginForLoad(true)]
    public class PenPlugin : IToolPaintPlugin
    {
        private IPaintPluginContext pluginContext = null;
        private PenControl optionsControl = null;
        private Cursor cursor = null;
        private Image icon = null;
        private bool flag;

        private IPaintApplicationContext ApplicationContext
        {
            get
            {
                if (pluginContext == null)
                    return null;
                return pluginContext.ApplicationContext;
            }
        }

        //После создания плагина подгружаем ресурсы.
        public void AfterCreate(IPaintPluginContext pluginContext)
        {
            this.pluginContext = pluginContext;
            optionsControl = new PenControl(ApplicationContext);
            string str = pluginContext.PluginDir;
            if (str != null)
            {
                str = str + @"\Images\";
                try
                {
                    icon = Image.FromFile(str + "Icon.ico");
                }
                catch
                {
                    //подавление исключения 
                }
                try
                {
                    cursor = new Cursor(str + "Cursor.cur");
                }
                catch { }
            }

        }

        //Перед переключением на другой плагин удаляем юзерконтрол и очищаем иконки с курсором.
        public void BeforeDestroy()
        {
            optionsControl.Dispose();
            optionsControl = null;
            if (cursor != null)
            {
                cursor.Dispose();
            }
            if (icon != null)
            {
                icon.Dispose();
            }
        }

        //При выборе инструмента выбираем контрол и курсор.
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
        
        public string Name
        {
            get
            {
                return GetType().Name;
            }
        }

        //Название инструмента.
        public string CommandName
        {
            get
            {
                return "Карандаш";
            }
        }

        //По нажатию мыши начинаем рисовать.
        public void MouseDown(MouseEventArgs me, Keys modifierKeys)
        {
            flag = true;
            Graphics graphics = Graphics.FromImage(ApplicationContext.Image);
            Pen pen = optionsControl.GetPen();
            Brush brush = new SolidBrush(pen.Color);
            graphics.FillRectangle(brush, me.X, me.Y, 1, 1);
            pen.Dispose();
        }

        //При движении мыши рисуем и т.д.
        public void MouseMove(MouseEventArgs me, Keys modifierKeys)
        {
            if (flag)
            {
                Graphics graphics = Graphics.FromImage(ApplicationContext.Image);
                Pen pen = optionsControl.GetPen();
                Brush brush = new SolidBrush(pen.Color);
                graphics.FillRectangle(brush, me.X, me.Y, pen.Width + 1, pen.Width + 1);
                pen.Dispose();
                ApplicationContext.Invalidate();
            }
        }

        //При отжатии ЛКМ.
        public void MouseUp(MouseEventArgs me, Keys modifierKeys)
        {
            flag = false;
        }

        //Реализация для клавиш?
        public void Escape()
        {

        }
        public void Enter()
        {

        }

        //Смена выбранного цвета.
        public void ColorChange()
        {
            optionsControl.InvalidateResult();
        }

        //Смена картинки заливки
        public void ImageChange()
        {
            optionsControl.InvalidateResult();
        }

        public string ToolName
        {
            get
            {
                return "Карандаш";
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

        

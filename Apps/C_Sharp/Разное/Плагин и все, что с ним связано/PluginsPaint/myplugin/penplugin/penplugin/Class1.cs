using System;
using System.Drawing;
using System.Windows.Forms;
using Oop.Tasks.Paint.Interface;

namespace PenPlugin {
    [PluginForLoad(true)]
    public class TestPlug : IToolPaintPlugin {
        private SolidBrush _brush;
        private Cursor _cursor;
        private Graphics _graphForm;
        private bool _isDraw;
        private Pen _linePen;
        private Point _mouseMemoryPoint;

        private IPaintPluginContext _pluginContext;

        private UIPenControl UIelementControl;

        private IPaintApplicationContext ApplicationContext {
            get {
                if (this._pluginContext == null)
                    return null;
                return this._pluginContext.ApplicationContext;
            }
        }
        public string CommandName {
            get { return "Pen"; }
        }

        public Image Icon { get; private set; }

        public string Name {
            get { return this.GetType().Name; }
        }

        public string ToolName {
            get { return "PenPlugin"; }
        }

        public void AfterCreate(IPaintPluginContext pluginContext) {
            this._pluginContext = pluginContext;
            this.UIelementControl = new UIPenControl();
            var imageDir = pluginContext.PluginDir;
            if (imageDir != null) {
                imageDir += @"\Images\";

                try {
                    this.Icon = Image.FromFile(imageDir + "PenIcon.jpg");
                }
                catch {
                } // подавление исключения

                try {
                    this._cursor = new Cursor(imageDir + "PenCur.cur");
                }
                catch {
                } // подавление исключения
            }
        }

        public void BeforeDestroy() {
            if (this._cursor != null)
                this._cursor.Dispose();
            if (this.Icon != null)
                this.Icon.Dispose();
            this._brush.Dispose();
            this._graphForm.Dispose();
            this.UIelementControl.Dispose();
        }
        #region NoUsing
        public void ColorChange() {
        }

        public void Enter() {
            throw new NotImplementedException();
        }

        public void Escape() {
            throw new NotImplementedException();
        }

        public void ImageChange() {
            throw new NotImplementedException();
        }
        #endregion
        #region MouseEvents
        public void MouseDown(MouseEventArgs me, Keys modifierKeys) {
            this._graphForm = Graphics.FromImage(this.ApplicationContext.Image);
            if (me.Button == MouseButtons.Left) {
                this._brush = new SolidBrush(this.ApplicationContext.ForegroundColor);
            }
            else {
                this._brush = new SolidBrush(this.ApplicationContext.BackgroundColor);
            }
            this._linePen = new Pen(this._brush.Color,this.UIelementControl.GetPenSize);
            this._mouseMemoryPoint = me.Location;
            this._isDraw = true;
        }
        public void MouseMove(MouseEventArgs me, Keys modifierKeys) {
            if (this._isDraw) {
                this._graphForm.FillRectangle(this._brush, me.Location.X - this.UIelementControl.GetPenSize/2,
                    me.Location.Y - this.UIelementControl.GetPenSize/2, this.UIelementControl.GetPenSize,
                    this.UIelementControl.GetPenSize);
                this._graphForm.DrawLine(this._linePen, this._mouseMemoryPoint,me.Location);
                this._mouseMemoryPoint = me.Location;
                this.ApplicationContext.Invalidate();
            }
        }

        public void MouseUp(MouseEventArgs me, Keys modifierKeys) {
            this._isDraw = false;
        }
        #endregion
        public void Select(bool selection) {
            if (selection) {
                this.ApplicationContext.OptionsControl = this.UIelementControl;
                this.ApplicationContext.Cursor = this._cursor;
            }
            else {
                this.ApplicationContext.OptionsControl = null;
                this.ApplicationContext.Cursor = null;
            }
        }
    }
}
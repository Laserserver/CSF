namespace GalaxyWars
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerMoving = new System.Windows.Forms.Timer(this.components);
            this.timerState = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerMoving
            // 
            this.timerMoving.Interval = 1;
            this.timerMoving.Tick += new System.EventHandler(this.timerMoving_Tick);
            // 
            // timerState
            // 
            this.timerState.Interval = 5000;
            this.timerState.Tick += new System.EventHandler(this.timerState_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 462);
            this.Name = "FormMain";
            this.Text = "Galaxy";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ClientSizeChanged += new System.EventHandler(this.FormMain_ClientSizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Timer timerMoving;
        public System.Windows.Forms.Timer timerState;
    }
}


namespace TOR
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pic = new System.Windows.Forms.PictureBox();
            this.goG = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.goS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // pic
            // 
            this.pic.Dock = System.Windows.Forms.DockStyle.Left;
            this.pic.Location = new System.Drawing.Point(0, 0);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(602, 532);
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            // 
            // goG
            // 
            this.goG.Location = new System.Drawing.Point(608, 26);
            this.goG.Name = "goG";
            this.goG.Size = new System.Drawing.Size(75, 33);
            this.goG.TabIndex = 1;
            this.goG.Text = "Greed";
            this.goG.UseVisualStyleBackColor = true;
            this.goG.Click += new System.EventHandler(this.goF_Click);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(608, 199);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 33);
            this.stop.TabIndex = 2;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // goS
            // 
            this.goS.AutoSize = true;
            this.goS.Location = new System.Drawing.Point(608, 65);
            this.goS.Name = "goS";
            this.goS.Size = new System.Drawing.Size(75, 33);
            this.goS.TabIndex = 3;
            this.goS.Text = "Solid";
            this.goS.UseVisualStyleBackColor = true;
            this.goS.Click += new System.EventHandler(this.goS_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 532);
            this.Controls.Add(this.goS);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.goG);
            this.Controls.Add(this.pic);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Button goG;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button goS;
    }
}


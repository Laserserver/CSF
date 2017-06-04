namespace Control
{
    partial class Diagr
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// 
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
        /// Прога Миловановой (2.4.1 -2016)
        /// Внесение изменений в прогу и ее сдача преподу - на ваш страх и риск
        /// </summary>
        private void InitializeComponent()
        {
            this.userControl11 = new LibraryControl.Diagram();
            this.Diagram = new LibraryControl.Diagram();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userControl11
            // 
            this.userControl11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControl11.Location = new System.Drawing.Point(0, 12);
            this.userControl11.MyNumbers = "44 87 35 77";
            this.userControl11.Name = "userControl11";
            this.userControl11.Print = LibraryControl.Diagram.Operation.None;
            this.userControl11.Size = new System.Drawing.Size(1167, 661);
            this.userControl11.TabIndex = 0;
            this.userControl11.MyNumberChanged += new LibraryControl.Diagram.MyEventHandler(this.userControl11_MyNumberChanged);
            this.userControl11.Load += new System.EventHandler(this.userControl11_Load_1);
            // 
            // Diagram
            // 
            this.Diagram.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Diagram.Location = new System.Drawing.Point(13, 13);
            this.Diagram.MyNumbers = "2 3 4 7";
            this.Diagram.Name = "Diagram";
            this.Diagram.Print = LibraryControl.Diagram.Operation.None;
            this.Diagram.Size = new System.Drawing.Size(488, 335);
            this.Diagram.TabIndex = 0;
            this.Diagram.Load += new System.EventHandler(this.userControl11_Load);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(931, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Diagr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 685);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.userControl11);
            this.Name = "Diagr";
            this.Text = "Диаграмма";
            this.Load += new System.EventHandler(this.Diagr_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private LibraryControl.Diagram Diagram;
        private LibraryControl.Diagram userControl11;
        private System.Windows.Forms.Button button1;
    }
}


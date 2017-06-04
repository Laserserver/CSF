namespace TextBoxTestingProgram
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.regExpBox = new TextBoxTestingProgram.RegExpBox();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(254, 17);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(100, 20);
            this.textBox.TabIndex = 4;
            // 
            // regExpBox
            // 
            this.regExpBox.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.regExpBox.ColorErr = System.Drawing.Color.Red;
            this.regExpBox.Location = new System.Drawing.Point(59, 17);
            this.regExpBox.Name = "regExpBox";
            this.regExpBox.RegularExpression = "^([0-9a-zA-Z]+)@{1,1}([0-9a-zA-Z]+)\\.{1,1}[a-z]{1,4}$";
            this.regExpBox.Size = new System.Drawing.Size(100, 20);
            this.regExpBox.TabIndex = 0;
            this.regExpBox.TextChanged += new System.EventHandler(this.regExpBox1_TextChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 78);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.regExpBox);
            this.Name = "FormMain";
            this.Text = "Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RegExpBox regExpBox;
        private System.Windows.Forms.TextBox textBox;
    }
}


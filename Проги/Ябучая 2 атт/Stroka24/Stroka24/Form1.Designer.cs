namespace Stroka24
{
    partial class MainFormStroka24
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
          this.lblTask = new System.Windows.Forms.Label();
          this.txbIn = new System.Windows.Forms.TextBox();
          this.btnFndr = new System.Windows.Forms.Button();
          this.txbSymb = new System.Windows.Forms.TextBox();
          this.lblSymb = new System.Windows.Forms.Label();
          this.lblPhrase = new System.Windows.Forms.Label();
          this.txbOut = new System.Windows.Forms.TextBox();
          this.lblOut = new System.Windows.Forms.Label();
          this.lblTxtOut = new System.Windows.Forms.Label();
          this.SuspendLayout();
          // 
          // lblTask
          // 
          this.lblTask.Location = new System.Drawing.Point(12, 9);
          this.lblTask.Name = "lblTask";
          this.lblTask.Size = new System.Drawing.Size(280, 32);
          this.lblTask.TabIndex = 0;
          this.lblTask.Text = "24.\tДана строка. Найти слова, которые имеют четную длину и начинаются с заданного" +
              " символа.";
          // 
          // txbIn
          // 
          this.txbIn.Location = new System.Drawing.Point(12, 69);
          this.txbIn.Multiline = true;
          this.txbIn.Name = "txbIn";
          this.txbIn.Size = new System.Drawing.Size(280, 120);
          this.txbIn.TabIndex = 6;
          // 
          // btnFndr
          // 
          this.btnFndr.Location = new System.Drawing.Point(12, 335);
          this.btnFndr.Name = "btnFndr";
          this.btnFndr.Size = new System.Drawing.Size(280, 23);
          this.btnFndr.TabIndex = 2;
          this.btnFndr.Text = "Найти слова!";
          this.btnFndr.UseVisualStyleBackColor = true;
          this.btnFndr.Click += new System.EventHandler(this.buttonWordFinder_Click);
          // 
          // txbSymb
          // 
          this.txbSymb.Location = new System.Drawing.Point(229, 41);
          this.txbSymb.Name = "txbSymb";
          this.txbSymb.Size = new System.Drawing.Size(63, 20);
          this.txbSymb.TabIndex = 3;
          // 
          // lblSymb
          // 
          this.lblSymb.AutoSize = true;
          this.lblSymb.Location = new System.Drawing.Point(130, 44);
          this.lblSymb.Name = "lblSymb";
          this.lblSymb.Size = new System.Drawing.Size(93, 13);
          this.lblSymb.TabIndex = 4;
          this.lblSymb.Text = "Введите символ:";
          // 
          // lblPhrase
          // 
          this.lblPhrase.AutoSize = true;
          this.lblPhrase.Location = new System.Drawing.Point(12, 44);
          this.lblPhrase.Name = "lblPhrase";
          this.lblPhrase.Size = new System.Drawing.Size(89, 13);
          this.lblPhrase.TabIndex = 5;
          this.lblPhrase.Text = "Введите строку:";
          // 
          // txbOut
          // 
          this.txbOut.Location = new System.Drawing.Point(12, 209);
          this.txbOut.Multiline = true;
          this.txbOut.Name = "txbOut";
          this.txbOut.Size = new System.Drawing.Size(280, 120);
          this.txbOut.TabIndex = 7;
          // 
          // lblOut
          // 
          this.lblOut.AutoSize = true;
          this.lblOut.Location = new System.Drawing.Point(12, 206);
          this.lblOut.Name = "lblOut";
          this.lblOut.Size = new System.Drawing.Size(0, 13);
          this.lblOut.TabIndex = 8;
          // 
          // lblTxtOut
          // 
          this.lblTxtOut.AutoSize = true;
          this.lblTxtOut.Location = new System.Drawing.Point(12, 192);
          this.lblTxtOut.Name = "lblTxtOut";
          this.lblTxtOut.Size = new System.Drawing.Size(153, 13);
          this.lblTxtOut.TabIndex = 9;
          this.lblTxtOut.Text = "Слова с заданного символа:";
          // 
          // MainFormStroka24
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(302, 369);
          this.Controls.Add(this.lblTxtOut);
          this.Controls.Add(this.lblOut);
          this.Controls.Add(this.txbOut);
          this.Controls.Add(this.lblPhrase);
          this.Controls.Add(this.lblSymb);
          this.Controls.Add(this.txbSymb);
          this.Controls.Add(this.btnFndr);
          this.Controls.Add(this.txbIn);
          this.Controls.Add(this.lblTask);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
          this.Name = "MainFormStroka24";
          this.Text = "Добрый день! (Строки - 24)";
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.TextBox txbIn;
        private System.Windows.Forms.Button btnFndr;
        private System.Windows.Forms.TextBox txbSymb;
        private System.Windows.Forms.Label lblSymb;
        private System.Windows.Forms.Label lblPhrase;
        private System.Windows.Forms.TextBox txbOut;
        private System.Windows.Forms.Label lblOut;
        private System.Windows.Forms.Label lblTxtOut;
    }
}


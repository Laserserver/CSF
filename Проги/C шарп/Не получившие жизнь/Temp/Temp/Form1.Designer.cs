namespace Temp
{
    partial class MyString7
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
            this.MyButton = new System.Windows.Forms.Button();
            this.InputStringBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // MyButton
            // 
            this.MyButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MyButton.Location = new System.Drawing.Point(33, 300);
            this.MyButton.Name = "MyButton";
            this.MyButton.Size = new System.Drawing.Size(250, 36);
            this.MyButton.TabIndex = 0;
            this.MyButton.Text = "Большая серая кнопка";
            this.MyButton.UseVisualStyleBackColor = false;
            // 
            // InputStringBox
            // 
            this.InputStringBox.Location = new System.Drawing.Point(33, 253);
            this.InputStringBox.Name = "InputStringBox";
            this.InputStringBox.Size = new System.Drawing.Size(250, 20);
            this.InputStringBox.TabIndex = 1;
            // 
            // MyString7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(316, 348);
            this.Controls.Add(this.InputStringBox);
            this.Controls.Add(this.MyButton);
            this.Name = "MyString7";
            this.Text = "Строки - 7";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MyButton;
        private System.Windows.Forms.TextBox InputStringBox;
    }
}


namespace Stroka7
{
    partial class MyMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyMainForm));
            this.ButtonFinder = new System.Windows.Forms.Button();
            this.InputStringBox = new System.Windows.Forms.TextBox();
            this.TaskLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonFinder
            // 
            this.ButtonFinder.BackColor = System.Drawing.SystemColors.Menu;
            this.ButtonFinder.Location = new System.Drawing.Point(41, 202);
            this.ButtonFinder.Name = "ButtonFinder";
            this.ButtonFinder.Size = new System.Drawing.Size(200, 36);
            this.ButtonFinder.TabIndex = 0;
            this.ButtonFinder.Text = "Найти не-букву!";
            this.ButtonFinder.UseVisualStyleBackColor = false;
            this.ButtonFinder.Click += new System.EventHandler(this.ButtonFinder_Click);
            // 
            // InputStringBox
            // 
            this.InputStringBox.Location = new System.Drawing.Point(26, 151);
            this.InputStringBox.Name = "InputStringBox";
            this.InputStringBox.Size = new System.Drawing.Size(230, 20);
            this.InputStringBox.TabIndex = 1;
            // 
            // TaskLabel
            // 
            this.TaskLabel.Location = new System.Drawing.Point(26, 9);
            this.TaskLabel.Name = "TaskLabel";
            this.TaskLabel.Size = new System.Drawing.Size(230, 108);
            this.TaskLabel.TabIndex = 2;
            this.TaskLabel.Text = resources.GetString("TaskLabel.Text");
            // 
            // MyMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.TaskLabel);
            this.Controls.Add(this.InputStringBox);
            this.Controls.Add(this.ButtonFinder);
            this.Name = "MyMainForm";
            this.Text = "Строки - 7";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonFinder;
        private System.Windows.Forms.TextBox InputStringBox;
        private System.Windows.Forms.Label TaskLabel;
    }
}


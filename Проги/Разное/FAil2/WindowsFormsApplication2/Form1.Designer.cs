namespace WindowsFormsApplication2
{
    partial class Fail1
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
            this.FinBt = new System.Windows.Forms.Button();
            this.FinBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FinBt
            // 
            this.FinBt.Location = new System.Drawing.Point(97, 93);
            this.FinBt.Name = "FinBt";
            this.FinBt.Size = new System.Drawing.Size(75, 23);
            this.FinBt.TabIndex = 0;
            this.FinBt.Text = "Find";
            this.FinBt.UseVisualStyleBackColor = true;
            this.FinBt.Click += new System.EventHandler(this.FinBt_Click);
            // 
            // FinBox
            // 
            this.FinBox.Location = new System.Drawing.Point(84, 67);
            this.FinBox.Name = "FinBox";
            this.FinBox.Size = new System.Drawing.Size(100, 20);
            this.FinBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter k";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 52);
            this.label2.TabIndex = 3;
            this.label2.Text = "Дано число k и файл, содержащий ненулевые\r\n целые числа. Вывести элемент файла\r\n " +
    "с номером k (элементы файла нумеруются от нуля).\r\n Если такой элемент отсутствуе" +
    "т, то вывести 0. ";
            // 
            // Fail1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 139);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FinBox);
            this.Controls.Add(this.FinBt);
            this.Name = "Fail1";
            this.Text = "Fail1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FinBt;
        private System.Windows.Forms.TextBox FinBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}


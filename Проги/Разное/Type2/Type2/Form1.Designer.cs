namespace Type2
{
    partial class Form1
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
            this.AcceptBt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chisl1 = new System.Windows.Forms.TextBox();
            this.znam1 = new System.Windows.Forms.TextBox();
            this.znam2 = new System.Windows.Forms.TextBox();
            this.chisl2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AcceptBt
            // 
            this.AcceptBt.Location = new System.Drawing.Point(87, 108);
            this.AcceptBt.Name = "AcceptBt";
            this.AcceptBt.Size = new System.Drawing.Size(75, 23);
            this.AcceptBt.TabIndex = 0;
            this.AcceptBt.Text = "Accept";
            this.AcceptBt.UseVisualStyleBackColor = true;
            this.AcceptBt.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите числитель и знаменатель 2 числа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Введите числитель и знаменатель 1 числа";
            // 
            // chisl1
            // 
            this.chisl1.Location = new System.Drawing.Point(15, 82);
            this.chisl1.Name = "chisl1";
            this.chisl1.Size = new System.Drawing.Size(100, 20);
            this.chisl1.TabIndex = 4;
            // 
            // znam1
            // 
            this.znam1.Location = new System.Drawing.Point(121, 82);
            this.znam1.Name = "znam1";
            this.znam1.Size = new System.Drawing.Size(100, 20);
            this.znam1.TabIndex = 5;
            // 
            // znam2
            // 
            this.znam2.Location = new System.Drawing.Point(121, 150);
            this.znam2.Name = "znam2";
            this.znam2.Size = new System.Drawing.Size(100, 20);
            this.znam2.TabIndex = 6;
            // 
            // chisl2
            // 
            this.chisl2.Location = new System.Drawing.Point(15, 150);
            this.chisl2.Name = "chisl2";
            this.chisl2.Size = new System.Drawing.Size(100, 20);
            this.chisl2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 26);
            this.label3.TabIndex = 9;
            this.label3.Text = "Описать логическую функцию Равно(a, b),\r\n сравнивающую два рациональных числа a и" +
    " b.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 198);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chisl2);
            this.Controls.Add(this.znam2);
            this.Controls.Add(this.znam1);
            this.Controls.Add(this.chisl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AcceptBt);
            this.Name = "Form1";
            this.Text = "Type2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AcceptBt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox chisl1;
        private System.Windows.Forms.TextBox znam1;
        private System.Windows.Forms.TextBox znam2;
        private System.Windows.Forms.TextBox chisl2;
        private System.Windows.Forms.Label label3;
    }
}


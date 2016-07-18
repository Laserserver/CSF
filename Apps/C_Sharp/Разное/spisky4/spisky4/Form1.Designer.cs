namespace spisky4
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
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.ctrlDgv = new System.Windows.Forms.DataGridView();
      this.ctrlDgvout = new System.Windows.Forms.DataGridView();
      ((System.ComponentModel.ISupportInitialize)(this.ctrlDgv)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ctrlDgvout)).BeginInit();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(157, 78);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 2;
      this.button1.Text = "delete";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(157, 125);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 23);
      this.button2.TabIndex = 3;
      this.button2.Text = "clear";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(154, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(143, 52);
      this.label1.TabIndex = 4;
      this.label1.Text = "4.Дан список слов.\r\n Из каждой группы подряд\r\n идущих одинаковых слов \r\nоставить " +
    "только одно.";
      // 
      // ctrlDgv
      // 
      this.ctrlDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.ctrlDgv.ColumnHeadersVisible = false;
      this.ctrlDgv.Location = new System.Drawing.Point(12, 12);
      this.ctrlDgv.Name = "ctrlDgv";
      this.ctrlDgv.RowHeadersVisible = false;
      this.ctrlDgv.Size = new System.Drawing.Size(122, 394);
      this.ctrlDgv.TabIndex = 5;
      // 
      // ctrlDgvout
      // 
      this.ctrlDgvout.AllowUserToAddRows = false;
      this.ctrlDgvout.AllowUserToDeleteRows = false;
      this.ctrlDgvout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.ctrlDgvout.ColumnHeadersVisible = false;
      this.ctrlDgvout.Location = new System.Drawing.Point(444, 12);
      this.ctrlDgvout.Name = "ctrlDgvout";
      this.ctrlDgvout.ReadOnly = true;
      this.ctrlDgvout.RowHeadersVisible = false;
      this.ctrlDgvout.Size = new System.Drawing.Size(128, 394);
      this.ctrlDgvout.TabIndex = 6;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(763, 433);
      this.Controls.Add(this.ctrlDgvout);
      this.Controls.Add(this.ctrlDgv);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.ctrlDgv)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ctrlDgvout)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DataGridView ctrlDgv;
    private System.Windows.Forms.DataGridView ctrlDgvout;
  }
}


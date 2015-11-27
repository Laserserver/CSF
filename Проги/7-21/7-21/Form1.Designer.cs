namespace _7_21
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
      this.labelZad = new System.Windows.Forms.Label();
      this.dataIn = new System.Windows.Forms.DataGridView();
      this.dataOut = new System.Windows.Forms.DataGridView();
      this.butMake = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.dataIn)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataOut)).BeginInit();
      this.SuspendLayout();
      // 
      // labelZad
      // 
      this.labelZad.AutoSize = true;
      this.labelZad.Location = new System.Drawing.Point(16, 9);
      this.labelZad.Name = "labelZad";
      this.labelZad.Size = new System.Drawing.Size(375, 13);
      this.labelZad.TabIndex = 0;
      this.labelZad.Text = "21.\tДан массив размера N. Вывести его элементы в обратном порядке.";
      // 
      // dataIn
      // 
      this.dataIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataIn.ColumnHeadersVisible = false;
      this.dataIn.Location = new System.Drawing.Point(19, 79);
      this.dataIn.Name = "dataIn";
      this.dataIn.RowHeadersVisible = false;
      this.dataIn.Size = new System.Drawing.Size(157, 322);
      this.dataIn.TabIndex = 1;
      // 
      // dataOut
      // 
      this.dataOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataOut.ColumnHeadersVisible = false;
      this.dataOut.Location = new System.Drawing.Point(227, 79);
      this.dataOut.Name = "dataOut";
      this.dataOut.RowHeadersVisible = false;
      this.dataOut.Size = new System.Drawing.Size(159, 322);
      this.dataOut.TabIndex = 2;
      // 
      // butMake
      // 
      this.butMake.Location = new System.Drawing.Point(19, 40);
      this.butMake.Name = "butMake";
      this.butMake.Size = new System.Drawing.Size(156, 24);
      this.butMake.TabIndex = 3;
      this.butMake.Text = "Поменять";
      this.butMake.UseVisualStyleBackColor = true;
      this.butMake.Click += new System.EventHandler(this.butMake_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(401, 411);
      this.Controls.Add(this.butMake);
      this.Controls.Add(this.dataOut);
      this.Controls.Add(this.dataIn);
      this.Controls.Add(this.labelZad);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.dataIn)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataOut)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label labelZad;
    private System.Windows.Forms.DataGridView dataIn;
    private System.Windows.Forms.DataGridView dataOut;
    private System.Windows.Forms.Button butMake;
  }
}


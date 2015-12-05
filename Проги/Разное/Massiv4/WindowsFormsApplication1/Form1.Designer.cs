namespace WindowsFormsApplication1
{
  partial class MyForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyForm));
      this.dataIn = new System.Windows.Forms.DataGridView();
      this.butFind = new System.Windows.Forms.Button();
      this.labelTask = new System.Windows.Forms.Label();
      this.dataOut = new System.Windows.Forms.DataGridView();
      ((System.ComponentModel.ISupportInitialize)(this.dataIn)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataOut)).BeginInit();
      this.SuspendLayout();
      // 
      // dataIn
      // 
      this.dataIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataIn.ColumnHeadersVisible = false;
      this.dataIn.Location = new System.Drawing.Point(45, 106);
      this.dataIn.Name = "dataIn";
      this.dataIn.RowHeadersVisible = false;
      this.dataIn.Size = new System.Drawing.Size(151, 252);
      this.dataIn.TabIndex = 0;
      // 
      // butFind
      // 
      this.butFind.Location = new System.Drawing.Point(233, 106);
      this.butFind.Name = "butFind";
      this.butFind.Size = new System.Drawing.Size(86, 52);
      this.butFind.TabIndex = 1;
      this.butFind.Text = "Найти";
      this.butFind.UseVisualStyleBackColor = true;
      this.butFind.Click += new System.EventHandler(this.button1_Click);
      // 
      // labelTask
      // 
      this.labelTask.Location = new System.Drawing.Point(15, 18);
      this.labelTask.Name = "labelTask";
      this.labelTask.Size = new System.Drawing.Size(477, 56);
      this.labelTask.TabIndex = 2;
      this.labelTask.Text = resources.GetString("labelTask.Text");
      // 
      // dataOut
      // 
      this.dataOut.AllowUserToAddRows = false;
      this.dataOut.AllowUserToDeleteRows = false;
      this.dataOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataOut.ColumnHeadersVisible = false;
      this.dataOut.Location = new System.Drawing.Point(339, 101);
      this.dataOut.Name = "dataOut";
      this.dataOut.RowHeadersVisible = false;
      this.dataOut.Size = new System.Drawing.Size(152, 256);
      this.dataOut.TabIndex = 4;
      // 
      // MyForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(521, 380);
      this.Controls.Add(this.dataOut);
      this.Controls.Add(this.labelTask);
      this.Controls.Add(this.butFind);
      this.Controls.Add(this.dataIn);
      this.Name = "MyForm";
      this.Text = "7-4";
      ((System.ComponentModel.ISupportInitialize)(this.dataIn)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataOut)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView dataIn;
    private System.Windows.Forms.Button butFind;
    private System.Windows.Forms.Label labelTask;
    private System.Windows.Forms.DataGridView dataOut;
  }
}


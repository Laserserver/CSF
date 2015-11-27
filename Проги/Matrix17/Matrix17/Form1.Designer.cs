namespace Matrix17
{
  partial class Matrix17
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
      this.dgv = new System.Windows.Forms.DataGridView();
      this.txbIn = new System.Windows.Forms.TextBox();
      this.lblN = new System.Windows.Forms.Label();
      this.btnMake = new System.Windows.Forms.Button();
      this.btnDel = new System.Windows.Forms.Button();
      this.btnFind = new System.Windows.Forms.Button();
      this.lblOut = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
      this.SuspendLayout();
      // 
      // lblTask
      // 
      this.lblTask.Location = new System.Drawing.Point(19, 9);
      this.lblTask.Name = "lblTask";
      this.lblTask.Size = new System.Drawing.Size(241, 45);
      this.lblTask.TabIndex = 0;
      this.lblTask.Text = "17.\tВ заданной матрице А(nn) найти максимум из всех минимальных элементов матриц" +
          "ы по столбцам.";
      // 
      // dgv
      // 
      this.dgv.AllowUserToAddRows = false;
      this.dgv.AllowUserToDeleteRows = false;
      this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgv.ColumnHeadersVisible = false;
      this.dgv.Location = new System.Drawing.Point(22, 148);
      this.dgv.Name = "dgv";
      this.dgv.RowHeadersVisible = false;
      this.dgv.Size = new System.Drawing.Size(238, 196);
      this.dgv.TabIndex = 1;
      // 
      // txbIn
      // 
      this.txbIn.Location = new System.Drawing.Point(85, 51);
      this.txbIn.Name = "txbIn";
      this.txbIn.Size = new System.Drawing.Size(73, 20);
      this.txbIn.TabIndex = 2;
      this.txbIn.Text = "2";
      // 
      // lblN
      // 
      this.lblN.AutoSize = true;
      this.lblN.Location = new System.Drawing.Point(19, 54);
      this.lblN.Name = "lblN";
      this.lblN.Size = new System.Drawing.Size(60, 13);
      this.lblN.TabIndex = 4;
      this.lblN.Text = "Введите N";
      // 
      // btnMake
      // 
      this.btnMake.Location = new System.Drawing.Point(22, 79);
      this.btnMake.Name = "btnMake";
      this.btnMake.Size = new System.Drawing.Size(113, 23);
      this.btnMake.TabIndex = 5;
      this.btnMake.Text = "Создать матрицу";
      this.btnMake.UseVisualStyleBackColor = true;
      this.btnMake.Click += new System.EventHandler(this.btnMake_Click);
      // 
      // btnDel
      // 
      this.btnDel.Location = new System.Drawing.Point(22, 108);
      this.btnDel.Name = "btnDel";
      this.btnDel.Size = new System.Drawing.Size(113, 23);
      this.btnDel.TabIndex = 6;
      this.btnDel.Text = "Удалить матрицу";
      this.btnDel.UseVisualStyleBackColor = true;
      this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
      // 
      // btnFind
      // 
      this.btnFind.Location = new System.Drawing.Point(149, 79);
      this.btnFind.Name = "btnFind";
      this.btnFind.Size = new System.Drawing.Size(111, 23);
      this.btnFind.TabIndex = 7;
      this.btnFind.Text = "Найти максимум";
      this.btnFind.UseVisualStyleBackColor = true;
      this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
      // 
      // lblOut
      // 
      this.lblOut.Location = new System.Drawing.Point(152, 108);
      this.lblOut.Name = "lblOut";
      this.lblOut.Size = new System.Drawing.Size(108, 27);
      this.lblOut.TabIndex = 8;
      this.lblOut.Text = "Здесь будет число";
      // 
      // Matrix17
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(282, 370);
      this.Controls.Add(this.lblOut);
      this.Controls.Add(this.btnFind);
      this.Controls.Add(this.btnDel);
      this.Controls.Add(this.btnMake);
      this.Controls.Add(this.lblN);
      this.Controls.Add(this.txbIn);
      this.Controls.Add(this.dgv);
      this.Controls.Add(this.lblTask);
      this.Name = "Matrix17";
      this.Text = "Матрицы - 17";
      ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblTask;
    private System.Windows.Forms.DataGridView dgv;
    private System.Windows.Forms.TextBox txbIn;
    private System.Windows.Forms.Label lblN;
    private System.Windows.Forms.Button btnMake;
    private System.Windows.Forms.Button btnDel;
    private System.Windows.Forms.Button btnFind;
    private System.Windows.Forms.Label lblOut;
  }
}


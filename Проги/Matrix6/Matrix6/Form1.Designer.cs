namespace Matrix6
{
  partial class Matrix6
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
      this.dgvIn = new System.Windows.Forms.DataGridView();
      this.txbN = new System.Windows.Forms.TextBox();
      this.txbM = new System.Windows.Forms.TextBox();
      this.lblN = new System.Windows.Forms.Label();
      this.lblM = new System.Windows.Forms.Label();
      this.dgvOut = new System.Windows.Forms.DataGridView();
      this.btnMake = new System.Windows.Forms.Button();
      this.btnDel = new System.Windows.Forms.Button();
      this.btnGet = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.dgvIn)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).BeginInit();
      this.SuspendLayout();
      // 
      // lblTask
      // 
      this.lblTask.Location = new System.Drawing.Point(15, 9);
      this.lblTask.Name = "lblTask";
      this.lblTask.Size = new System.Drawing.Size(557, 37);
      this.lblTask.TabIndex = 0;
      this.lblTask.Text = "6. Дана действительная матрица размера nm, в которой не все элементы равны нулю." +
          " Получить новую матрицу путем деления всех элементов данной матрицы на ее наибол" +
          "ьший по модулю элемент.";
      // 
      // dgvIn
      // 
      this.dgvIn.AllowUserToAddRows = false;
      this.dgvIn.AllowUserToDeleteRows = false;
      this.dgvIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvIn.ColumnHeadersVisible = false;
      this.dgvIn.Location = new System.Drawing.Point(15, 117);
      this.dgvIn.Name = "dgvIn";
      this.dgvIn.RowHeadersVisible = false;
      this.dgvIn.Size = new System.Drawing.Size(268, 246);
      this.dgvIn.TabIndex = 1;
      // 
      // txbN
      // 
      this.txbN.Location = new System.Drawing.Point(15, 60);
      this.txbN.Name = "txbN";
      this.txbN.Size = new System.Drawing.Size(87, 20);
      this.txbN.TabIndex = 2;
      this.txbN.Text = "1";
      // 
      // txbM
      // 
      this.txbM.Location = new System.Drawing.Point(15, 86);
      this.txbM.Name = "txbM";
      this.txbM.Size = new System.Drawing.Size(87, 20);
      this.txbM.TabIndex = 3;
      this.txbM.Text = "1";
      // 
      // lblN
      // 
      this.lblN.AutoSize = true;
      this.lblN.Location = new System.Drawing.Point(108, 63);
      this.lblN.Name = "lblN";
      this.lblN.Size = new System.Drawing.Size(60, 13);
      this.lblN.TabIndex = 4;
      this.lblN.Text = "Введите N";
      // 
      // lblM
      // 
      this.lblM.AutoSize = true;
      this.lblM.Location = new System.Drawing.Point(108, 89);
      this.lblM.Name = "lblM";
      this.lblM.Size = new System.Drawing.Size(61, 13);
      this.lblM.TabIndex = 5;
      this.lblM.Text = "Введите М";
      // 
      // dgvOut
      // 
      this.dgvOut.AllowUserToAddRows = false;
      this.dgvOut.AllowUserToDeleteRows = false;
      this.dgvOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvOut.ColumnHeadersVisible = false;
      this.dgvOut.Location = new System.Drawing.Point(307, 117);
      this.dgvOut.Name = "dgvOut";
      this.dgvOut.RowHeadersVisible = false;
      this.dgvOut.Size = new System.Drawing.Size(265, 246);
      this.dgvOut.TabIndex = 6;
      // 
      // btnMake
      // 
      this.btnMake.Location = new System.Drawing.Point(174, 58);
      this.btnMake.Name = "btnMake";
      this.btnMake.Size = new System.Drawing.Size(109, 23);
      this.btnMake.TabIndex = 7;
      this.btnMake.Text = "Создать матрицу";
      this.btnMake.UseVisualStyleBackColor = true;
      this.btnMake.Click += new System.EventHandler(this.btnMake_Click);
      // 
      // btnDel
      // 
      this.btnDel.Location = new System.Drawing.Point(174, 84);
      this.btnDel.Name = "btnDel";
      this.btnDel.Size = new System.Drawing.Size(109, 23);
      this.btnDel.TabIndex = 8;
      this.btnDel.Text = "Удалить матрицу";
      this.btnDel.UseVisualStyleBackColor = true;
      this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
      // 
      // btnGet
      // 
      this.btnGet.Location = new System.Drawing.Point(307, 58);
      this.btnGet.Name = "btnGet";
      this.btnGet.Size = new System.Drawing.Size(81, 49);
      this.btnGet.TabIndex = 9;
      this.btnGet.Text = "Получить матрицу";
      this.btnGet.UseVisualStyleBackColor = true;
      this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
      // 
      // Matrix6
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(590, 375);
      this.Controls.Add(this.btnGet);
      this.Controls.Add(this.btnDel);
      this.Controls.Add(this.btnMake);
      this.Controls.Add(this.dgvOut);
      this.Controls.Add(this.lblM);
      this.Controls.Add(this.lblN);
      this.Controls.Add(this.txbM);
      this.Controls.Add(this.txbN);
      this.Controls.Add(this.dgvIn);
      this.Controls.Add(this.lblTask);
      this.Name = "Matrix6";
      this.Text = "Матрицы - 6";
      ((System.ComponentModel.ISupportInitialize)(this.dgvIn)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblTask;
    private System.Windows.Forms.DataGridView dgvIn;
    private System.Windows.Forms.TextBox txbN;
    private System.Windows.Forms.TextBox txbM;
    private System.Windows.Forms.Label lblN;
    private System.Windows.Forms.Label lblM;
    private System.Windows.Forms.DataGridView dgvOut;
    private System.Windows.Forms.Button btnMake;
    private System.Windows.Forms.Button btnDel;
    private System.Windows.Forms.Button btnGet;
  }
}


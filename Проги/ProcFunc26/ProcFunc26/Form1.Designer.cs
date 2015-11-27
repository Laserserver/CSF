namespace ProcFunc26
{
  partial class ProcFunc26
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
      this.dgvOut = new System.Windows.Forms.DataGridView();
      this.grbFirlast = new System.Windows.Forms.GroupBox();
      this.radbtnColumn = new System.Windows.Forms.RadioButton();
      this.radbtnRow = new System.Windows.Forms.RadioButton();
      this.grbMinmax = new System.Windows.Forms.GroupBox();
      this.radbtnMax = new System.Windows.Forms.RadioButton();
      this.radbtnMin = new System.Windows.Forms.RadioButton();
      this.txbN = new System.Windows.Forms.TextBox();
      this.txbM = new System.Windows.Forms.TextBox();
      this.lblN = new System.Windows.Forms.Label();
      this.lblM = new System.Windows.Forms.Label();
      this.btnMak = new System.Windows.Forms.Button();
      this.btnDel = new System.Windows.Forms.Button();
      this.btnFind = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.dgvIn)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).BeginInit();
      this.grbFirlast.SuspendLayout();
      this.grbMinmax.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblTask
      // 
      this.lblTask.Location = new System.Drawing.Point(23, 12);
      this.lblTask.Name = "lblTask";
      this.lblTask.Size = new System.Drawing.Size(520, 31);
      this.lblTask.TabIndex = 0;
      this.lblTask.Text = "26.\tДана матрица размера N×M. Удалить строку (1) | столбец (2), содержащий минима" +
          "льный (3) | максимальный (4) элемент матрицы. ";
      // 
      // dgvIn
      // 
      this.dgvIn.AllowUserToAddRows = false;
      this.dgvIn.AllowUserToDeleteRows = false;
      this.dgvIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvIn.ColumnHeadersVisible = false;
      this.dgvIn.Location = new System.Drawing.Point(23, 138);
      this.dgvIn.Name = "dgvIn";
      this.dgvIn.RowHeadersVisible = false;
      this.dgvIn.Size = new System.Drawing.Size(248, 246);
      this.dgvIn.TabIndex = 1;
      // 
      // dgvOut
      // 
      this.dgvOut.AllowUserToAddRows = false;
      this.dgvOut.AllowUserToDeleteRows = false;
      this.dgvOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvOut.ColumnHeadersVisible = false;
      this.dgvOut.Location = new System.Drawing.Point(299, 138);
      this.dgvOut.Name = "dgvOut";
      this.dgvOut.ReadOnly = true;
      this.dgvOut.RowHeadersVisible = false;
      this.dgvOut.Size = new System.Drawing.Size(244, 246);
      this.dgvOut.TabIndex = 2;
      // 
      // grbFirlast
      // 
      this.grbFirlast.Controls.Add(this.radbtnColumn);
      this.grbFirlast.Controls.Add(this.radbtnRow);
      this.grbFirlast.Location = new System.Drawing.Point(299, 46);
      this.grbFirlast.Name = "grbFirlast";
      this.grbFirlast.Size = new System.Drawing.Size(82, 80);
      this.grbFirlast.TabIndex = 3;
      this.grbFirlast.TabStop = false;
      this.grbFirlast.Text = "Удалить";
      // 
      // radbtnColumn
      // 
      this.radbtnColumn.AutoSize = true;
      this.radbtnColumn.Location = new System.Drawing.Point(6, 42);
      this.radbtnColumn.Name = "radbtnColumn";
      this.radbtnColumn.Size = new System.Drawing.Size(67, 17);
      this.radbtnColumn.TabIndex = 1;
      this.radbtnColumn.Text = "Столбец";
      this.radbtnColumn.UseVisualStyleBackColor = true;
      // 
      // radbtnRow
      // 
      this.radbtnRow.AutoSize = true;
      this.radbtnRow.Checked = true;
      this.radbtnRow.Location = new System.Drawing.Point(6, 19);
      this.radbtnRow.Name = "radbtnRow";
      this.radbtnRow.Size = new System.Drawing.Size(60, 17);
      this.radbtnRow.TabIndex = 0;
      this.radbtnRow.TabStop = true;
      this.radbtnRow.Text = "Строку";
      this.radbtnRow.UseVisualStyleBackColor = true;
      // 
      // grbMinmax
      // 
      this.grbMinmax.Controls.Add(this.radbtnMax);
      this.grbMinmax.Controls.Add(this.radbtnMin);
      this.grbMinmax.Location = new System.Drawing.Point(387, 46);
      this.grbMinmax.Name = "grbMinmax";
      this.grbMinmax.Size = new System.Drawing.Size(156, 80);
      this.grbMinmax.TabIndex = 4;
      this.grbMinmax.TabStop = false;
      this.grbMinmax.Text = "Содержащий";
      // 
      // radbtnMax
      // 
      this.radbtnMax.AutoSize = true;
      this.radbtnMax.Location = new System.Drawing.Point(6, 42);
      this.radbtnMax.Name = "radbtnMax";
      this.radbtnMax.Size = new System.Drawing.Size(150, 17);
      this.radbtnMax.TabIndex = 1;
      this.radbtnMax.Text = "Максимальный элемент";
      this.radbtnMax.UseVisualStyleBackColor = true;
      // 
      // radbtnMin
      // 
      this.radbtnMin.AutoSize = true;
      this.radbtnMin.Checked = true;
      this.radbtnMin.Location = new System.Drawing.Point(6, 19);
      this.radbtnMin.Name = "radbtnMin";
      this.radbtnMin.Size = new System.Drawing.Size(144, 17);
      this.radbtnMin.TabIndex = 0;
      this.radbtnMin.TabStop = true;
      this.radbtnMin.Text = "Минимальный элемент";
      this.radbtnMin.UseVisualStyleBackColor = true;
      // 
      // txbN
      // 
      this.txbN.Location = new System.Drawing.Point(86, 49);
      this.txbN.Name = "txbN";
      this.txbN.Size = new System.Drawing.Size(59, 20);
      this.txbN.TabIndex = 5;
      this.txbN.Text = "1";
      // 
      // txbM
      // 
      this.txbM.Location = new System.Drawing.Point(86, 75);
      this.txbM.Name = "txbM";
      this.txbM.Size = new System.Drawing.Size(59, 20);
      this.txbM.TabIndex = 6;
      this.txbM.Text = "1";
      // 
      // lblN
      // 
      this.lblN.AutoSize = true;
      this.lblN.Location = new System.Drawing.Point(20, 52);
      this.lblN.Name = "lblN";
      this.lblN.Size = new System.Drawing.Size(60, 13);
      this.lblN.TabIndex = 7;
      this.lblN.Text = "Введите N";
      // 
      // lblM
      // 
      this.lblM.AutoSize = true;
      this.lblM.Location = new System.Drawing.Point(20, 78);
      this.lblM.Name = "lblM";
      this.lblM.Size = new System.Drawing.Size(61, 13);
      this.lblM.TabIndex = 8;
      this.lblM.Text = "Введите М";
      // 
      // btnMak
      // 
      this.btnMak.Location = new System.Drawing.Point(151, 46);
      this.btnMak.Name = "btnMak";
      this.btnMak.Size = new System.Drawing.Size(116, 23);
      this.btnMak.TabIndex = 9;
      this.btnMak.Text = "Создать матрицу";
      this.btnMak.UseVisualStyleBackColor = true;
      this.btnMak.Click += new System.EventHandler(this.btnMak_Click);
      // 
      // btnDel
      // 
      this.btnDel.Location = new System.Drawing.Point(151, 73);
      this.btnDel.Name = "btnDel";
      this.btnDel.Size = new System.Drawing.Size(116, 23);
      this.btnDel.TabIndex = 10;
      this.btnDel.Text = "Удалить матрицу";
      this.btnDel.UseVisualStyleBackColor = true;
      this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
      // 
      // btnFind
      // 
      this.btnFind.Location = new System.Drawing.Point(23, 101);
      this.btnFind.Name = "btnFind";
      this.btnFind.Size = new System.Drawing.Size(244, 25);
      this.btnFind.TabIndex = 11;
      this.btnFind.Text = "Удалить";
      this.btnFind.UseVisualStyleBackColor = true;
      this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
      // 
      // ProcFunc26
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(566, 401);
      this.Controls.Add(this.btnFind);
      this.Controls.Add(this.btnDel);
      this.Controls.Add(this.btnMak);
      this.Controls.Add(this.lblM);
      this.Controls.Add(this.lblN);
      this.Controls.Add(this.txbM);
      this.Controls.Add(this.txbN);
      this.Controls.Add(this.grbMinmax);
      this.Controls.Add(this.grbFirlast);
      this.Controls.Add(this.dgvOut);
      this.Controls.Add(this.dgvIn);
      this.Controls.Add(this.lblTask);
      this.Name = "ProcFunc26";
      this.Text = "Процедуры и функции 26";
      ((System.ComponentModel.ISupportInitialize)(this.dgvIn)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).EndInit();
      this.grbFirlast.ResumeLayout(false);
      this.grbFirlast.PerformLayout();
      this.grbMinmax.ResumeLayout(false);
      this.grbMinmax.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblTask;
    private System.Windows.Forms.DataGridView dgvIn;
    private System.Windows.Forms.DataGridView dgvOut;
    private System.Windows.Forms.GroupBox grbFirlast;
    private System.Windows.Forms.RadioButton radbtnColumn;
    private System.Windows.Forms.RadioButton radbtnRow;
    private System.Windows.Forms.GroupBox grbMinmax;
    private System.Windows.Forms.RadioButton radbtnMax;
    private System.Windows.Forms.RadioButton radbtnMin;
    private System.Windows.Forms.TextBox txbN;
    private System.Windows.Forms.TextBox txbM;
    private System.Windows.Forms.Label lblN;
    private System.Windows.Forms.Label lblM;
    private System.Windows.Forms.Button btnMak;
    private System.Windows.Forms.Button btnDel;
    private System.Windows.Forms.Button btnFind;
  }
}


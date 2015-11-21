namespace ProcFunc7
{
  partial class FuncProc7
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
      this.txbNIn = new System.Windows.Forms.TextBox();
      this.txbMIn = new System.Windows.Forms.TextBox();
      this.btnMaker = new System.Windows.Forms.Button();
      this.lblHelpN = new System.Windows.Forms.Label();
      this.lblHelpM = new System.Windows.Forms.Label();
      this.grbxDisp = new System.Windows.Forms.GroupBox();
      this.radbtnColumn = new System.Windows.Forms.RadioButton();
      this.radbtnRow = new System.Windows.Forms.RadioButton();
      this.lblAnswer = new System.Windows.Forms.Label();
      this.grbType = new System.Windows.Forms.GroupBox();
      this.radbtnMinInMax = new System.Windows.Forms.RadioButton();
      this.radbtnMaxInMin = new System.Windows.Forms.RadioButton();
      this.dgv = new System.Windows.Forms.DataGridView();
      this.btnFinder = new System.Windows.Forms.Button();
      this.grbxDisp.SuspendLayout();
      this.grbType.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
      this.SuspendLayout();
      // 
      // lblTask
      // 
      this.lblTask.Location = new System.Drawing.Point(13, 8);
      this.lblTask.Name = "lblTask";
      this.lblTask.Size = new System.Drawing.Size(329, 47);
      this.lblTask.TabIndex = 0;
      this.lblTask.Text = "7. Дана матрица размера n×m. Найти минимальный (1) или максимальный (2) среди мак" +
          "симальных (1) или минимальных (2) элементов каждой строки (3) или столбца (4). ";
      // 
      // txbNIn
      // 
      this.txbNIn.Location = new System.Drawing.Point(134, 58);
      this.txbNIn.Name = "txbNIn";
      this.txbNIn.Size = new System.Drawing.Size(45, 20);
      this.txbNIn.TabIndex = 1;
      this.txbNIn.Text = "3";
      // 
      // txbMIn
      // 
      this.txbMIn.Location = new System.Drawing.Point(134, 84);
      this.txbMIn.Name = "txbMIn";
      this.txbMIn.Size = new System.Drawing.Size(45, 20);
      this.txbMIn.TabIndex = 2;
      this.txbMIn.Text = "2";
      // 
      // btnMaker
      // 
      this.btnMaker.Location = new System.Drawing.Point(192, 57);
      this.btnMaker.Name = "btnMaker";
      this.btnMaker.Size = new System.Drawing.Size(151, 20);
      this.btnMaker.TabIndex = 4;
      this.btnMaker.Text = "Создать матрицу";
      this.btnMaker.UseVisualStyleBackColor = true;
      this.btnMaker.Click += new System.EventHandler(this.btnMaker_Click);
      // 
      // lblHelpN
      // 
      this.lblHelpN.AutoSize = true;
      this.lblHelpN.Location = new System.Drawing.Point(13, 61);
      this.lblHelpN.Name = "lblHelpN";
      this.lblHelpN.Size = new System.Drawing.Size(107, 13);
      this.lblHelpN.TabIndex = 8;
      this.lblHelpN.Text = "Введите N (строки):";
      // 
      // lblHelpM
      // 
      this.lblHelpM.AutoSize = true;
      this.lblHelpM.Location = new System.Drawing.Point(12, 88);
      this.lblHelpM.Name = "lblHelpM";
      this.lblHelpM.Size = new System.Drawing.Size(116, 13);
      this.lblHelpM.TabIndex = 9;
      this.lblHelpM.Text = "Введите M (столбцы):";
      // 
      // grbxDisp
      // 
      this.grbxDisp.Controls.Add(this.radbtnColumn);
      this.grbxDisp.Controls.Add(this.radbtnRow);
      this.grbxDisp.Location = new System.Drawing.Point(257, 110);
      this.grbxDisp.Name = "grbxDisp";
      this.grbxDisp.Size = new System.Drawing.Size(85, 65);
      this.grbxDisp.TabIndex = 11;
      this.grbxDisp.TabStop = false;
      this.grbxDisp.Text = "В:";
      // 
      // radbtnColumn
      // 
      this.radbtnColumn.AutoSize = true;
      this.radbtnColumn.Location = new System.Drawing.Point(12, 41);
      this.radbtnColumn.Name = "radbtnColumn";
      this.radbtnColumn.Size = new System.Drawing.Size(67, 17);
      this.radbtnColumn.TabIndex = 1;
      this.radbtnColumn.Text = "Столбце";
      this.radbtnColumn.UseVisualStyleBackColor = true;
      // 
      // radbtnRow
      // 
      this.radbtnRow.AutoSize = true;
      this.radbtnRow.Checked = true;
      this.radbtnRow.Location = new System.Drawing.Point(12, 19);
      this.radbtnRow.Name = "radbtnRow";
      this.radbtnRow.Size = new System.Drawing.Size(61, 17);
      this.radbtnRow.TabIndex = 0;
      this.radbtnRow.TabStop = true;
      this.radbtnRow.Text = "Строке";
      this.radbtnRow.UseVisualStyleBackColor = true;
      // 
      // lblAnswer
      // 
      this.lblAnswer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblAnswer.Location = new System.Drawing.Point(15, 316);
      this.lblAnswer.Name = "lblAnswer";
      this.lblAnswer.Size = new System.Drawing.Size(327, 47);
      this.lblAnswer.TabIndex = 12;
      this.lblAnswer.Text = "Ответ: ";
      // 
      // grbType
      // 
      this.grbType.Controls.Add(this.radbtnMinInMax);
      this.grbType.Controls.Add(this.radbtnMaxInMin);
      this.grbType.Location = new System.Drawing.Point(15, 110);
      this.grbType.Name = "grbType";
      this.grbType.Size = new System.Drawing.Size(228, 65);
      this.grbType.TabIndex = 13;
      this.grbType.TabStop = false;
      this.grbType.Text = "Элемент массива:";
      // 
      // radbtnMinInMax
      // 
      this.radbtnMinInMax.AutoSize = true;
      this.radbtnMinInMax.Location = new System.Drawing.Point(12, 41);
      this.radbtnMinInMax.Name = "radbtnMinInMax";
      this.radbtnMinInMax.Size = new System.Drawing.Size(211, 17);
      this.radbtnMinInMax.TabIndex = 1;
      this.radbtnMinInMax.Text = "Минимальный среди максимальных";
      this.radbtnMinInMax.UseVisualStyleBackColor = true;
      // 
      // radbtnMaxInMin
      // 
      this.radbtnMaxInMin.AutoSize = true;
      this.radbtnMaxInMin.Checked = true;
      this.radbtnMaxInMin.Location = new System.Drawing.Point(12, 18);
      this.radbtnMaxInMin.Name = "radbtnMaxInMin";
      this.radbtnMaxInMin.Size = new System.Drawing.Size(211, 17);
      this.radbtnMaxInMin.TabIndex = 0;
      this.radbtnMaxInMin.TabStop = true;
      this.radbtnMaxInMin.Text = "Максимальный среди минимальных";
      this.radbtnMaxInMin.UseVisualStyleBackColor = true;
      // 
      // dgv
      // 
      this.dgv.AllowUserToAddRows = false;
      this.dgv.AllowUserToDeleteRows = false;
      this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgv.ColumnHeadersVisible = false;
      this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
      this.dgv.Location = new System.Drawing.Point(15, 187);
      this.dgv.Name = "dgv";
      this.dgv.RowHeadersVisible = false;
      this.dgv.Size = new System.Drawing.Size(327, 115);
      this.dgv.TabIndex = 14;
      // 
      // btnFinder
      // 
      this.btnFinder.Location = new System.Drawing.Point(192, 83);
      this.btnFinder.Name = "btnFinder";
      this.btnFinder.Size = new System.Drawing.Size(150, 20);
      this.btnFinder.TabIndex = 15;
      this.btnFinder.Text = "Найти элемент";
      this.btnFinder.UseVisualStyleBackColor = true;
      this.btnFinder.Click += new System.EventHandler(this.btnFinder_Click);
      // 
      // FuncProc7
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(355, 379);
      this.Controls.Add(this.btnFinder);
      this.Controls.Add(this.dgv);
      this.Controls.Add(this.grbType);
      this.Controls.Add(this.lblAnswer);
      this.Controls.Add(this.grbxDisp);
      this.Controls.Add(this.lblHelpM);
      this.Controls.Add(this.lblHelpN);
      this.Controls.Add(this.btnMaker);
      this.Controls.Add(this.txbMIn);
      this.Controls.Add(this.txbNIn);
      this.Controls.Add(this.lblTask);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Name = "FuncProc7";
      this.Text = "Добрый день!  (Функции и процедуры - 7)";
      this.grbxDisp.ResumeLayout(false);
      this.grbxDisp.PerformLayout();
      this.grbType.ResumeLayout(false);
      this.grbType.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblTask;
    private System.Windows.Forms.TextBox txbNIn;
    private System.Windows.Forms.TextBox txbMIn;
    private System.Windows.Forms.Button btnMaker;
    private System.Windows.Forms.Label lblHelpN;
    private System.Windows.Forms.Label lblHelpM;
    private System.Windows.Forms.GroupBox grbxDisp;
    private System.Windows.Forms.RadioButton radbtnColumn;
    private System.Windows.Forms.RadioButton radbtnRow;
    private System.Windows.Forms.Label lblAnswer;
    private System.Windows.Forms.GroupBox grbType;
    private System.Windows.Forms.RadioButton radbtnMinInMax;
    private System.Windows.Forms.RadioButton radbtnMaxInMin;
    private System.Windows.Forms.DataGridView dgv;
    private System.Windows.Forms.Button btnFinder;
  }
}


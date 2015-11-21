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
      this.btnFinder = new System.Windows.Forms.Button();
      this.radbtnInMax = new System.Windows.Forms.RadioButton();
      this.radbtnInMin = new System.Windows.Forms.RadioButton();
      this.lblHelpN = new System.Windows.Forms.Label();
      this.lblHelpM = new System.Windows.Forms.Label();
      this.grbxWhat = new System.Windows.Forms.GroupBox();
      this.grbxDisp = new System.Windows.Forms.GroupBox();
      this.radbtnColumn = new System.Windows.Forms.RadioButton();
      this.radbtnRow = new System.Windows.Forms.RadioButton();
      this.lblAnswer = new System.Windows.Forms.Label();
      this.grbType = new System.Windows.Forms.GroupBox();
      this.radbtnElMax = new System.Windows.Forms.RadioButton();
      this.radbtnElMin = new System.Windows.Forms.RadioButton();
      this.txbOutVis = new System.Windows.Forms.TextBox();
      this.grbxWhat.SuspendLayout();
      this.grbxDisp.SuspendLayout();
      this.grbType.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblTask
      // 
      this.lblTask.Location = new System.Drawing.Point(12, 9);
      this.lblTask.Name = "lblTask";
      this.lblTask.Size = new System.Drawing.Size(333, 47);
      this.lblTask.TabIndex = 0;
      this.lblTask.Text = "7. Добрый день! Дана матрица размера n×m. Найти минимальный (1) или максимальный " +
          "(2) среди максимальных (1) или минимальных (2) элементов каждой строки (3) или с" +
          "толбца (4). ";
      // 
      // txbNIn
      // 
      this.txbNIn.Location = new System.Drawing.Point(87, 58);
      this.txbNIn.Name = "txbNIn";
      this.txbNIn.Size = new System.Drawing.Size(45, 20);
      this.txbNIn.TabIndex = 1;
      this.txbNIn.Text = "1";
      // 
      // txbMIn
      // 
      this.txbMIn.Location = new System.Drawing.Point(87, 94);
      this.txbMIn.Name = "txbMIn";
      this.txbMIn.Size = new System.Drawing.Size(45, 20);
      this.txbMIn.TabIndex = 2;
      this.txbMIn.Text = "1";
      // 
      // btnFinder
      // 
      this.btnFinder.Location = new System.Drawing.Point(15, 127);
      this.btnFinder.Name = "btnFinder";
      this.btnFinder.Size = new System.Drawing.Size(77, 30);
      this.btnFinder.TabIndex = 4;
      this.btnFinder.Text = "Найти";
      this.btnFinder.UseVisualStyleBackColor = true;
      this.btnFinder.Click += new System.EventHandler(this.btnFinder_Click);
      // 
      // radbtnInMax
      // 
      this.radbtnInMax.AutoSize = true;
      this.radbtnInMax.Checked = true;
      this.radbtnInMax.Location = new System.Drawing.Point(4, 15);
      this.radbtnInMax.Name = "radbtnInMax";
      this.radbtnInMax.Size = new System.Drawing.Size(103, 17);
      this.radbtnInMax.TabIndex = 6;
      this.radbtnInMax.TabStop = true;
      this.radbtnInMax.Text = "Максимальных";
      this.radbtnInMax.UseVisualStyleBackColor = true;
      // 
      // radbtnInMin
      // 
      this.radbtnInMin.AutoSize = true;
      this.radbtnInMin.Location = new System.Drawing.Point(4, 33);
      this.radbtnInMin.Name = "radbtnInMin";
      this.radbtnInMin.Size = new System.Drawing.Size(97, 17);
      this.radbtnInMin.TabIndex = 7;
      this.radbtnInMin.Text = "Минимальных";
      this.radbtnInMin.UseVisualStyleBackColor = true;
      // 
      // lblHelpN
      // 
      this.lblHelpN.AutoSize = true;
      this.lblHelpN.Location = new System.Drawing.Point(12, 61);
      this.lblHelpN.Name = "lblHelpN";
      this.lblHelpN.Size = new System.Drawing.Size(63, 13);
      this.lblHelpN.TabIndex = 8;
      this.lblHelpN.Text = "Введите N:";
      // 
      // lblHelpM
      // 
      this.lblHelpM.AutoSize = true;
      this.lblHelpM.Location = new System.Drawing.Point(12, 97);
      this.lblHelpM.Name = "lblHelpM";
      this.lblHelpM.Size = new System.Drawing.Size(64, 13);
      this.lblHelpM.TabIndex = 9;
      this.lblHelpM.Text = "Введите M:";
      // 
      // grbxWhat
      // 
      this.grbxWhat.Controls.Add(this.radbtnInMax);
      this.grbxWhat.Controls.Add(this.radbtnInMin);
      this.grbxWhat.Location = new System.Drawing.Point(147, 58);
      this.grbxWhat.Name = "grbxWhat";
      this.grbxWhat.Size = new System.Drawing.Size(106, 56);
      this.grbxWhat.TabIndex = 10;
      this.grbxWhat.TabStop = false;
      this.grbxWhat.Text = "Среди:";
      // 
      // grbxDisp
      // 
      this.grbxDisp.Controls.Add(this.radbtnColumn);
      this.grbxDisp.Controls.Add(this.radbtnRow);
      this.grbxDisp.Location = new System.Drawing.Point(260, 58);
      this.grbxDisp.Name = "grbxDisp";
      this.grbxDisp.Size = new System.Drawing.Size(85, 56);
      this.grbxDisp.TabIndex = 11;
      this.grbxDisp.TabStop = false;
      this.grbxDisp.Text = "В:";
      // 
      // radbtnColumn
      // 
      this.radbtnColumn.AutoSize = true;
      this.radbtnColumn.Location = new System.Drawing.Point(12, 33);
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
      this.radbtnRow.Location = new System.Drawing.Point(12, 15);
      this.radbtnRow.Name = "radbtnRow";
      this.radbtnRow.Size = new System.Drawing.Size(61, 17);
      this.radbtnRow.TabIndex = 0;
      this.radbtnRow.TabStop = true;
      this.radbtnRow.Text = "Строке";
      this.radbtnRow.UseVisualStyleBackColor = true;
      // 
      // lblAnswer
      // 
      this.lblAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblAnswer.Location = new System.Drawing.Point(12, 329);
      this.lblAnswer.Name = "lblAnswer";
      this.lblAnswer.Size = new System.Drawing.Size(333, 47);
      this.lblAnswer.TabIndex = 12;
      // 
      // grbType
      // 
      this.grbType.Controls.Add(this.radbtnElMin);
      this.grbType.Controls.Add(this.radbtnElMax);
      this.grbType.Location = new System.Drawing.Point(115, 121);
      this.grbType.Name = "grbType";
      this.grbType.Size = new System.Drawing.Size(229, 41);
      this.grbType.TabIndex = 13;
      this.grbType.TabStop = false;
      this.grbType.Text = "Элемент массива:";
      // 
      // radbtnElMax
      // 
      this.radbtnElMax.AutoSize = true;
      this.radbtnElMax.Checked = true;
      this.radbtnElMax.Location = new System.Drawing.Point(12, 18);
      this.radbtnElMax.Name = "radbtnElMax";
      this.radbtnElMax.Size = new System.Drawing.Size(104, 17);
      this.radbtnElMax.TabIndex = 0;
      this.radbtnElMax.TabStop = true;
      this.radbtnElMax.Text = "Максимальный";
      this.radbtnElMax.UseVisualStyleBackColor = true;
      // 
      // radbtnElMin
      // 
      this.radbtnElMin.AutoSize = true;
      this.radbtnElMin.Location = new System.Drawing.Point(122, 19);
      this.radbtnElMin.Name = "radbtnElMin";
      this.radbtnElMin.Size = new System.Drawing.Size(98, 17);
      this.radbtnElMin.TabIndex = 1;
      this.radbtnElMin.Text = "Минимальный";
      this.radbtnElMin.UseVisualStyleBackColor = true;
      // 
      // txbOutVis
      // 
      this.txbOutVis.Location = new System.Drawing.Point(15, 182);
      this.txbOutVis.Multiline = true;
      this.txbOutVis.Name = "txbOutVis";
      this.txbOutVis.Size = new System.Drawing.Size(330, 132);
      this.txbOutVis.TabIndex = 14;
      // 
      // FuncProc7
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(358, 385);
      this.Controls.Add(this.txbOutVis);
      this.Controls.Add(this.grbType);
      this.Controls.Add(this.lblAnswer);
      this.Controls.Add(this.grbxDisp);
      this.Controls.Add(this.grbxWhat);
      this.Controls.Add(this.lblHelpM);
      this.Controls.Add(this.lblHelpN);
      this.Controls.Add(this.btnFinder);
      this.Controls.Add(this.txbMIn);
      this.Controls.Add(this.txbNIn);
      this.Controls.Add(this.lblTask);
      this.Name = "FuncProc7";
      this.Text = "Функции и процедуры 7";
      this.grbxWhat.ResumeLayout(false);
      this.grbxWhat.PerformLayout();
      this.grbxDisp.ResumeLayout(false);
      this.grbxDisp.PerformLayout();
      this.grbType.ResumeLayout(false);
      this.grbType.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblTask;
    private System.Windows.Forms.TextBox txbNIn;
    private System.Windows.Forms.TextBox txbMIn;
    private System.Windows.Forms.Button btnFinder;
    private System.Windows.Forms.RadioButton radbtnInMax;
    private System.Windows.Forms.RadioButton radbtnInMin;
    private System.Windows.Forms.Label lblHelpN;
    private System.Windows.Forms.Label lblHelpM;
    private System.Windows.Forms.GroupBox grbxWhat;
    private System.Windows.Forms.GroupBox grbxDisp;
    private System.Windows.Forms.RadioButton radbtnColumn;
    private System.Windows.Forms.RadioButton radbtnRow;
    private System.Windows.Forms.Label lblAnswer;
    private System.Windows.Forms.GroupBox grbType;
    private System.Windows.Forms.RadioButton radbtnElMin;
    private System.Windows.Forms.RadioButton radbtnElMax;
    private System.Windows.Forms.TextBox txbOutVis;
  }
}


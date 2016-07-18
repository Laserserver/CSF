namespace FuncProc24
{
  partial class FP24
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
      this.lblHelpN = new System.Windows.Forms.Label();
      this.lblHelpM = new System.Windows.Forms.Label();
      this.txbN = new System.Windows.Forms.TextBox();
      this.txbM = new System.Windows.Forms.TextBox();
      this.btnMaker = new System.Windows.Forms.Button();
      this.btnFinder = new System.Windows.Forms.Button();
      this.btnRes = new System.Windows.Forms.Button();
      this.btnDel = new System.Windows.Forms.Button();
      this.grbAbsFoL = new System.Windows.Forms.GroupBox();
      this.radbtnM = new System.Windows.Forms.RadioButton();
      this.radbtnFirst = new System.Windows.Forms.RadioButton();
      this.grbPosFoL = new System.Windows.Forms.GroupBox();
      this.radbtnToLast = new System.Windows.Forms.RadioButton();
      this.radbtnToFirst = new System.Windows.Forms.RadioButton();
      this.dgv = new System.Windows.Forms.DataGridView();
      this.dgv2 = new System.Windows.Forms.DataGridView();
      this.grbAbsFoL.SuspendLayout();
      this.grbPosFoL.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
      this.SuspendLayout();
      // 
      // lblTask
      // 
      this.lblTask.Location = new System.Drawing.Point(21, 6);
      this.lblTask.Name = "lblTask";
      this.lblTask.Size = new System.Drawing.Size(369, 45);
      this.lblTask.TabIndex = 0;
      this.lblTask.Text = "24. Дана матрица размера N×M. Поменять местами столбец с номером 1 (1) | M (2) и " +
          "первый (3) | последний (4) из столбцов, содержащих только положительные элементы" +
          ".";
      // 
      // lblHelpN
      // 
      this.lblHelpN.AutoSize = true;
      this.lblHelpN.Location = new System.Drawing.Point(18, 59);
      this.lblHelpN.Name = "lblHelpN";
      this.lblHelpN.Size = new System.Drawing.Size(63, 13);
      this.lblHelpN.TabIndex = 1;
      this.lblHelpN.Text = "Введите N:";
      // 
      // lblHelpM
      // 
      this.lblHelpM.AutoSize = true;
      this.lblHelpM.Location = new System.Drawing.Point(18, 85);
      this.lblHelpM.Name = "lblHelpM";
      this.lblHelpM.Size = new System.Drawing.Size(64, 13);
      this.lblHelpM.TabIndex = 2;
      this.lblHelpM.Text = "Введите М:";
      // 
      // txbN
      // 
      this.txbN.Location = new System.Drawing.Point(84, 54);
      this.txbN.Multiline = true;
      this.txbN.Name = "txbN";
      this.txbN.Size = new System.Drawing.Size(53, 23);
      this.txbN.TabIndex = 3;
      this.txbN.Text = "1";
      // 
      // txbM
      // 
      this.txbM.Location = new System.Drawing.Point(84, 82);
      this.txbM.Multiline = true;
      this.txbM.Name = "txbM";
      this.txbM.Size = new System.Drawing.Size(53, 23);
      this.txbM.TabIndex = 4;
      this.txbM.Text = "1";
      // 
      // btnMaker
      // 
      this.btnMaker.Location = new System.Drawing.Point(143, 54);
      this.btnMaker.Name = "btnMaker";
      this.btnMaker.Size = new System.Drawing.Size(112, 23);
      this.btnMaker.TabIndex = 5;
      this.btnMaker.Text = "Создать матрицу";
      this.btnMaker.UseVisualStyleBackColor = true;
      this.btnMaker.Click += new System.EventHandler(this.btnMaker_Click);
      // 
      // btnFinder
      // 
      this.btnFinder.Location = new System.Drawing.Point(143, 82);
      this.btnFinder.Name = "btnFinder";
      this.btnFinder.Size = new System.Drawing.Size(112, 23);
      this.btnFinder.TabIndex = 6;
      this.btnFinder.Text = "Поменять столбцы";
      this.btnFinder.UseVisualStyleBackColor = true;
      this.btnFinder.Click += new System.EventHandler(this.btnFinder_Click);
      // 
      // btnRes
      // 
      this.btnRes.Location = new System.Drawing.Point(261, 54);
      this.btnRes.Name = "btnRes";
      this.btnRes.Size = new System.Drawing.Size(111, 23);
      this.btnRes.TabIndex = 7;
      this.btnRes.Text = "Очистить матрицу";
      this.btnRes.UseVisualStyleBackColor = true;
      this.btnRes.Click += new System.EventHandler(this.btnRes_Click);
      // 
      // btnDel
      // 
      this.btnDel.Location = new System.Drawing.Point(261, 82);
      this.btnDel.Name = "btnDel";
      this.btnDel.Size = new System.Drawing.Size(111, 23);
      this.btnDel.TabIndex = 8;
      this.btnDel.Text = "Удалить матрицу";
      this.btnDel.UseVisualStyleBackColor = true;
      this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
      // 
      // grbAbsFoL
      // 
      this.grbAbsFoL.Controls.Add(this.radbtnM);
      this.grbAbsFoL.Controls.Add(this.radbtnFirst);
      this.grbAbsFoL.Location = new System.Drawing.Point(21, 120);
      this.grbAbsFoL.Name = "grbAbsFoL";
      this.grbAbsFoL.Size = new System.Drawing.Size(143, 66);
      this.grbAbsFoL.TabIndex = 9;
      this.grbAbsFoL.TabStop = false;
      this.grbAbsFoL.Text = "Менять";
      // 
      // radbtnM
      // 
      this.radbtnM.AutoSize = true;
      this.radbtnM.Location = new System.Drawing.Point(6, 42);
      this.radbtnM.Name = "radbtnM";
      this.radbtnM.Size = new System.Drawing.Size(114, 17);
      this.radbtnM.TabIndex = 1;
      this.radbtnM.TabStop = true;
      this.radbtnM.Text = "Столбец номер М";
      this.radbtnM.UseVisualStyleBackColor = true;
      // 
      // radbtnFirst
      // 
      this.radbtnFirst.AutoSize = true;
      this.radbtnFirst.Checked = true;
      this.radbtnFirst.Location = new System.Drawing.Point(6, 19);
      this.radbtnFirst.Name = "radbtnFirst";
      this.radbtnFirst.Size = new System.Drawing.Size(111, 17);
      this.radbtnFirst.TabIndex = 0;
      this.radbtnFirst.TabStop = true;
      this.radbtnFirst.Text = "Стоблец номер 1";
      this.radbtnFirst.UseVisualStyleBackColor = true;
      // 
      // grbPosFoL
      // 
      this.grbPosFoL.Controls.Add(this.radbtnToLast);
      this.grbPosFoL.Controls.Add(this.radbtnToFirst);
      this.grbPosFoL.Location = new System.Drawing.Point(170, 120);
      this.grbPosFoL.Name = "grbPosFoL";
      this.grbPosFoL.Size = new System.Drawing.Size(220, 66);
      this.grbPosFoL.TabIndex = 10;
      this.grbPosFoL.TabStop = false;
      this.grbPosFoL.Text = "На";
      // 
      // radbtnToLast
      // 
      this.radbtnToLast.AutoSize = true;
      this.radbtnToLast.Location = new System.Drawing.Point(6, 42);
      this.radbtnToLast.Name = "radbtnToLast";
      this.radbtnToLast.Size = new System.Drawing.Size(209, 17);
      this.radbtnToLast.TabIndex = 1;
      this.radbtnToLast.Text = "Последний положительный столбец";
      this.radbtnToLast.UseVisualStyleBackColor = true;
      // 
      // radbtnToFirst
      // 
      this.radbtnToFirst.AutoSize = true;
      this.radbtnToFirst.Checked = true;
      this.radbtnToFirst.Location = new System.Drawing.Point(6, 19);
      this.radbtnToFirst.Name = "radbtnToFirst";
      this.radbtnToFirst.Size = new System.Drawing.Size(193, 17);
      this.radbtnToFirst.TabIndex = 0;
      this.radbtnToFirst.TabStop = true;
      this.radbtnToFirst.Text = "Первый положительный столбец";
      this.radbtnToFirst.UseVisualStyleBackColor = true;
      // 
      // dgv
      // 
      this.dgv.AllowUserToAddRows = false;
      this.dgv.AllowUserToDeleteRows = false;
      this.dgv.AllowUserToResizeColumns = false;
      this.dgv.AllowUserToResizeRows = false;
      this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgv.ColumnHeadersVisible = false;
      this.dgv.Location = new System.Drawing.Point(21, 203);
      this.dgv.Name = "dgv";
      this.dgv.RowHeadersVisible = false;
      this.dgv.Size = new System.Drawing.Size(189, 231);
      this.dgv.TabIndex = 11;
      // 
      // dgv2
      // 
      this.dgv2.AllowUserToAddRows = false;
      this.dgv2.AllowUserToDeleteRows = false;
      this.dgv2.AllowUserToResizeColumns = false;
      this.dgv2.AllowUserToResizeRows = false;
      this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgv2.ColumnHeadersVisible = false;
      this.dgv2.Location = new System.Drawing.Point(222, 203);
      this.dgv2.Name = "dgv2";
      this.dgv2.RowHeadersVisible = false;
      this.dgv2.Size = new System.Drawing.Size(189, 231);
      this.dgv2.TabIndex = 12;
      // 
      // FP24
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(423, 448);
      this.Controls.Add(this.dgv2);
      this.Controls.Add(this.dgv);
      this.Controls.Add(this.grbPosFoL);
      this.Controls.Add(this.grbAbsFoL);
      this.Controls.Add(this.btnDel);
      this.Controls.Add(this.btnRes);
      this.Controls.Add(this.btnFinder);
      this.Controls.Add(this.btnMaker);
      this.Controls.Add(this.txbM);
      this.Controls.Add(this.txbN);
      this.Controls.Add(this.lblHelpM);
      this.Controls.Add(this.lblHelpN);
      this.Controls.Add(this.lblTask);
      this.Name = "FP24";
      this.Text = "Функции и процедуры 24";
      this.grbAbsFoL.ResumeLayout(false);
      this.grbAbsFoL.PerformLayout();
      this.grbPosFoL.ResumeLayout(false);
      this.grbPosFoL.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblTask;
    private System.Windows.Forms.Label lblHelpN;
    private System.Windows.Forms.Label lblHelpM;
    private System.Windows.Forms.TextBox txbN;
    private System.Windows.Forms.TextBox txbM;
    private System.Windows.Forms.Button btnMaker;
    private System.Windows.Forms.Button btnFinder;
    private System.Windows.Forms.Button btnRes;
    private System.Windows.Forms.Button btnDel;
    private System.Windows.Forms.GroupBox grbAbsFoL;
    private System.Windows.Forms.RadioButton radbtnM;
    private System.Windows.Forms.RadioButton radbtnFirst;
    private System.Windows.Forms.GroupBox grbPosFoL;
    private System.Windows.Forms.RadioButton radbtnToLast;
    private System.Windows.Forms.RadioButton radbtnToFirst;
    private System.Windows.Forms.DataGridView dgv;
    private System.Windows.Forms.DataGridView dgv2;
  }
}


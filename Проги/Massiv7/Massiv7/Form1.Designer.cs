namespace Massiv7
{
  partial class frmMass7
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
      this.btnTorf = new System.Windows.Forms.Button();
      this.txbNumIn = new System.Windows.Forms.TextBox();
      this.lblNumIn = new System.Windows.Forms.Label();
      this.btnAddEl = new System.Windows.Forms.Button();
      this.txbVisArr = new System.Windows.Forms.TextBox();
      this.lblAns = new System.Windows.Forms.Label();
      this.lblMass = new System.Windows.Forms.Label();
      this.btnClean = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lblTask
      // 
      this.lblTask.Location = new System.Drawing.Point(12, 9);
      this.lblTask.Name = "lblTask";
      this.lblTask.Size = new System.Drawing.Size(333, 58);
      this.lblTask.TabIndex = 0;
      this.lblTask.Text = "7.\tПеременной t присвоить значение true, если в массиве нет нулевых элементов и п" +
          "ри этом положительные элементы чередуются с отрицательными и значение false в пр" +
          "отивном случае.";
      // 
      // btnTorf
      // 
      this.btnTorf.Location = new System.Drawing.Point(12, 210);
      this.btnTorf.Name = "btnTorf";
      this.btnTorf.Size = new System.Drawing.Size(163, 34);
      this.btnTorf.TabIndex = 1;
      this.btnTorf.Text = "Присвоить значение";
      this.btnTorf.UseVisualStyleBackColor = true;
      this.btnTorf.Click += new System.EventHandler(this.btnTorf_Click);
      // 
      // txbNumIn
      // 
      this.txbNumIn.Location = new System.Drawing.Point(313, 70);
      this.txbNumIn.Name = "txbNumIn";
      this.txbNumIn.Size = new System.Drawing.Size(31, 20);
      this.txbNumIn.TabIndex = 2;
      // 
      // lblNumIn
      // 
      this.lblNumIn.AutoSize = true;
      this.lblNumIn.Location = new System.Drawing.Point(12, 73);
      this.lblNumIn.Name = "lblNumIn";
      this.lblNumIn.Size = new System.Drawing.Size(185, 13);
      this.lblNumIn.TabIndex = 3;
      this.lblNumIn.Text = "Введите число и нажмите кнопку - ";
      // 
      // btnAddEl
      // 
      this.btnAddEl.Location = new System.Drawing.Point(203, 62);
      this.btnAddEl.Name = "btnAddEl";
      this.btnAddEl.Size = new System.Drawing.Size(104, 34);
      this.btnAddEl.TabIndex = 4;
      this.btnAddEl.Text = "Добавить элемент";
      this.btnAddEl.UseVisualStyleBackColor = true;
      this.btnAddEl.Click += new System.EventHandler(this.btnAddEl_Click);
      // 
      // txbVisArr
      // 
      this.txbVisArr.BackColor = System.Drawing.SystemColors.HighlightText;
      this.txbVisArr.Location = new System.Drawing.Point(12, 135);
      this.txbVisArr.Multiline = true;
      this.txbVisArr.Name = "txbVisArr";
      this.txbVisArr.ReadOnly = true;
      this.txbVisArr.Size = new System.Drawing.Size(236, 69);
      this.txbVisArr.TabIndex = 5;
      // 
      // lblAns
      // 
      this.lblAns.AutoSize = true;
      this.lblAns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblAns.Location = new System.Drawing.Point(254, 219);
      this.lblAns.Name = "lblAns";
      this.lblAns.Size = new System.Drawing.Size(57, 16);
      this.lblAns.TabIndex = 6;
      this.lblAns.Text = "Ответ:";
      // 
      // lblMass
      // 
      this.lblMass.Location = new System.Drawing.Point(254, 156);
      this.lblMass.Name = "lblMass";
      this.lblMass.Size = new System.Drawing.Size(90, 29);
      this.lblMass.TabIndex = 7;
      this.lblMass.Text = "Массив элементов";
      // 
      // btnClean
      // 
      this.btnClean.Location = new System.Drawing.Point(12, 102);
      this.btnClean.Name = "btnClean";
      this.btnClean.Size = new System.Drawing.Size(123, 23);
      this.btnClean.TabIndex = 8;
      this.btnClean.Text = "Очистить";
      this.btnClean.UseVisualStyleBackColor = true;
      this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
      // 
      // frmMass7
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(357, 256);
      this.Controls.Add(this.btnClean);
      this.Controls.Add(this.lblMass);
      this.Controls.Add(this.lblAns);
      this.Controls.Add(this.txbVisArr);
      this.Controls.Add(this.btnAddEl);
      this.Controls.Add(this.lblNumIn);
      this.Controls.Add(this.txbNumIn);
      this.Controls.Add(this.btnTorf);
      this.Controls.Add(this.lblTask);
      this.Name = "frmMass7";
      this.Text = "Массивы 7";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblTask;
    private System.Windows.Forms.Button btnTorf;
    private System.Windows.Forms.TextBox txbNumIn;
    private System.Windows.Forms.Label lblNumIn;
    private System.Windows.Forms.Button btnAddEl;
    private System.Windows.Forms.TextBox txbVisArr;
    private System.Windows.Forms.Label lblAns;
    private System.Windows.Forms.Label lblMass;
    private System.Windows.Forms.Button btnClean;
  }
}


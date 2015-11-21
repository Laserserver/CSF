namespace Massiv24
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
      this.lblMass24Task = new System.Windows.Forms.Label();
      this.txbVis = new System.Windows.Forms.TextBox();
      this.btnRes = new System.Windows.Forms.Button();
      this.btnAdd = new System.Windows.Forms.Button();
      this.txbIn = new System.Windows.Forms.TextBox();
      this.lblAns = new System.Windows.Forms.Label();
      this.lblHelp = new System.Windows.Forms.Label();
      this.btnClean = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lblMass24Task
      // 
      this.lblMass24Task.Location = new System.Drawing.Point(15, 13);
      this.lblMass24Task.Name = "lblMass24Task";
      this.lblMass24Task.Size = new System.Drawing.Size(257, 34);
      this.lblMass24Task.TabIndex = 0;
      this.lblMass24Task.Text = "24.\tНайти максимальный элемент в массиве. Найти индекс максимального элемента.";
      // 
      // txbVis
      // 
      this.txbVis.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.txbVis.Location = new System.Drawing.Point(0, 165);
      this.txbVis.Multiline = true;
      this.txbVis.Name = "txbVis";
      this.txbVis.Size = new System.Drawing.Size(284, 97);
      this.txbVis.TabIndex = 1;
      // 
      // btnRes
      // 
      this.btnRes.Location = new System.Drawing.Point(18, 88);
      this.btnRes.Name = "btnRes";
      this.btnRes.Size = new System.Drawing.Size(194, 32);
      this.btnRes.TabIndex = 2;
      this.btnRes.Text = "Найти макс. элемент и его номер";
      this.btnRes.UseVisualStyleBackColor = true;
      this.btnRes.Click += new System.EventHandler(this.btnRes_Click);
      // 
      // btnAdd
      // 
      this.btnAdd.Location = new System.Drawing.Point(18, 50);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(120, 32);
      this.btnAdd.TabIndex = 3;
      this.btnAdd.Text = "Добавить элемент";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // txbIn
      // 
      this.txbIn.Location = new System.Drawing.Point(160, 50);
      this.txbIn.Multiline = true;
      this.txbIn.Name = "txbIn";
      this.txbIn.Size = new System.Drawing.Size(36, 32);
      this.txbIn.TabIndex = 4;
      // 
      // lblAns
      // 
      this.lblAns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblAns.Location = new System.Drawing.Point(18, 130);
      this.lblAns.Name = "lblAns";
      this.lblAns.Size = new System.Drawing.Size(173, 32);
      this.lblAns.TabIndex = 5;
      // 
      // lblHelp
      // 
      this.lblHelp.Location = new System.Drawing.Point(215, 53);
      this.lblHelp.Name = "lblHelp";
      this.lblHelp.Size = new System.Drawing.Size(57, 29);
      this.lblHelp.TabIndex = 6;
      this.lblHelp.Text = "Введите элемент";
      // 
      // btnClean
      // 
      this.btnClean.Location = new System.Drawing.Point(197, 136);
      this.btnClean.Name = "btnClean";
      this.btnClean.Size = new System.Drawing.Size(75, 23);
      this.btnClean.TabIndex = 7;
      this.btnClean.Text = "Очистить";
      this.btnClean.UseVisualStyleBackColor = true;
      this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 262);
      this.Controls.Add(this.btnClean);
      this.Controls.Add(this.lblHelp);
      this.Controls.Add(this.lblAns);
      this.Controls.Add(this.txbIn);
      this.Controls.Add(this.btnAdd);
      this.Controls.Add(this.btnRes);
      this.Controls.Add(this.txbVis);
      this.Controls.Add(this.lblMass24Task);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblMass24Task;
    private System.Windows.Forms.TextBox txbVis;
    private System.Windows.Forms.Button btnRes;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.TextBox txbIn;
    private System.Windows.Forms.Label lblAns;
    private System.Windows.Forms.Label lblHelp;
    private System.Windows.Forms.Button btnClean;
  }
}


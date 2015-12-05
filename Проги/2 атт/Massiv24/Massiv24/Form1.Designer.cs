namespace Massiv24
{
  partial class StrMainForm
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
      this.btnRes = new System.Windows.Forms.Button();
      this.lblAns = new System.Windows.Forms.Label();
      this.btnClean = new System.Windows.Forms.Button();
      this.dgv = new System.Windows.Forms.DataGridView();
      ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
      this.SuspendLayout();
      // 
      // lblMass24Task
      // 
      this.lblMass24Task.Location = new System.Drawing.Point(15, 13);
      this.lblMass24Task.Name = "lblMass24Task";
      this.lblMass24Task.Size = new System.Drawing.Size(265, 30);
      this.lblMass24Task.TabIndex = 0;
      this.lblMass24Task.Text = "24.Найти максимальный элемент в массиве. Найти индекс максимального элемента.";
      // 
      // btnRes
      // 
      this.btnRes.Location = new System.Drawing.Point(164, 46);
      this.btnRes.Name = "btnRes";
      this.btnRes.Size = new System.Drawing.Size(116, 50);
      this.btnRes.TabIndex = 2;
      this.btnRes.Text = "Найти макс. элемент и его индекс";
      this.btnRes.UseVisualStyleBackColor = true;
      this.btnRes.Click += new System.EventHandler(this.btnRes_Click);
      // 
      // lblAns
      // 
      this.lblAns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblAns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblAns.Location = new System.Drawing.Point(18, 128);
      this.lblAns.Name = "lblAns";
      this.lblAns.Size = new System.Drawing.Size(262, 44);
      this.lblAns.TabIndex = 5;
      // 
      // btnClean
      // 
      this.btnClean.Location = new System.Drawing.Point(164, 102);
      this.btnClean.Name = "btnClean";
      this.btnClean.Size = new System.Drawing.Size(116, 23);
      this.btnClean.TabIndex = 7;
      this.btnClean.Text = "Очистить";
      this.btnClean.UseVisualStyleBackColor = true;
      this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
      // 
      // dgv
      // 
      this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgv.ColumnHeadersVisible = false;
      this.dgv.Location = new System.Drawing.Point(18, 46);
      this.dgv.MultiSelect = false;
      this.dgv.Name = "dgv";
      this.dgv.RowHeadersVisible = false;
      this.dgv.Size = new System.Drawing.Size(140, 79);
      this.dgv.TabIndex = 8;
      // 
      // StrMainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 191);
      this.Controls.Add(this.dgv);
      this.Controls.Add(this.btnClean);
      this.Controls.Add(this.lblAns);
      this.Controls.Add(this.btnRes);
      this.Controls.Add(this.lblMass24Task);
      this.Name = "StrMainForm";
      this.Text = "Массив - 24";
      ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblMass24Task;
    private System.Windows.Forms.Button btnRes;
    private System.Windows.Forms.Label lblAns;
    private System.Windows.Forms.Button btnClean;
    private System.Windows.Forms.DataGridView dgv;
  }
}


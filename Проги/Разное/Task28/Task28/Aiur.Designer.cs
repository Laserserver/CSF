namespace WindowsFormsApplication1
{
  partial class Aiur
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
      this.gridMass = new System.Windows.Forms.DataGridView();
      this.baton = new System.Windows.Forms.Button();
      this.lblMin = new System.Windows.Forms.Label();
      this.lblInd = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.gridMass)).BeginInit();
      this.SuspendLayout();
      // 
      // gridMass
      // 
      this.gridMass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gridMass.ColumnHeadersVisible = false;
      this.gridMass.Location = new System.Drawing.Point(25, 39);
      this.gridMass.Name = "gridMass";
      this.gridMass.RowHeadersVisible = false;
      this.gridMass.Size = new System.Drawing.Size(90, 304);
      this.gridMass.TabIndex = 0;
      // 
      // baton
      // 
      this.baton.Location = new System.Drawing.Point(287, 78);
      this.baton.Name = "baton";
      this.baton.Size = new System.Drawing.Size(75, 23);
      this.baton.TabIndex = 1;
      this.baton.Text = "Найти";
      this.baton.UseVisualStyleBackColor = true;
      this.baton.Click += new System.EventHandler(this.baton_Click);
      // 
      // lblMin
      // 
      this.lblMin.AutoSize = true;
      this.lblMin.Location = new System.Drawing.Point(161, 79);
      this.lblMin.Name = "lblMin";
      this.lblMin.Size = new System.Drawing.Size(57, 13);
      this.lblMin.TabIndex = 2;
      this.lblMin.Text = "Мин эл-т: ";
      // 
      // lblInd
      // 
      this.lblInd.AutoSize = true;
      this.lblInd.Location = new System.Drawing.Point(161, 103);
      this.lblInd.Name = "lblInd";
      this.lblInd.Size = new System.Drawing.Size(51, 13);
      this.lblInd.TabIndex = 3;
      this.lblInd.Text = "Индекс: ";
      // 
      // Aiur
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(441, 376);
      this.Controls.Add(this.lblInd);
      this.Controls.Add(this.lblMin);
      this.Controls.Add(this.baton);
      this.Controls.Add(this.gridMass);
      this.Name = "Aiur";
      this.Text = "Задача 28";
      ((System.ComponentModel.ISupportInitialize)(this.gridMass)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataGridView gridMass;
    private System.Windows.Forms.Button baton;
    private System.Windows.Forms.Label lblMin;
    private System.Windows.Forms.Label lblInd;
  }
}


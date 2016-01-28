namespace MyLifeForAiur
{
  partial class MyLifeForAiur
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyLifeForAiur));
      this.lblLol = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // lblLol
      // 
      this.lblLol.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblLol.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblLol.Location = new System.Drawing.Point(0, 0);
      this.lblLol.Name = "lblLol";
      this.lblLol.Size = new System.Drawing.Size(225, 63);
      this.lblLol.TabIndex = 0;
      this.lblLol.Text = "ЖИЗНЬ ЗА АЙУР!";
      this.lblLol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // MyLifeForAiur
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(225, 63);
      this.Controls.Add(this.lblLol);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MyLifeForAiur";
      this.Opacity = 0.01D;
      this.Text = "Chrome";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblLol;
  }
}


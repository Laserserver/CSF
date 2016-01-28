namespace DrawingTry
{
  partial class DrawTry
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
      this.picbx = new System.Windows.Forms.PictureBox();
      this.btnSob = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.picbx)).BeginInit();
      this.SuspendLayout();
      // 
      // picbx
      // 
      this.picbx.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.picbx.Dock = System.Windows.Forms.DockStyle.Fill;
      this.picbx.Location = new System.Drawing.Point(0, 0);
      this.picbx.Name = "picbx";
      this.picbx.Size = new System.Drawing.Size(846, 564);
      this.picbx.TabIndex = 0;
      this.picbx.TabStop = false;
      // 
      // btnSob
      // 
      this.btnSob.Location = new System.Drawing.Point(771, 0);
      this.btnSob.Name = "btnSob";
      this.btnSob.Size = new System.Drawing.Size(75, 23);
      this.btnSob.TabIndex = 1;
      this.btnSob.Text = "Событие";
      this.btnSob.UseVisualStyleBackColor = true;
      this.btnSob.Click += new System.EventHandler(this.btnSob_Click);
      // 
      // DrawTry
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(846, 564);
      this.Controls.Add(this.btnSob);
      this.Controls.Add(this.picbx);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Name = "DrawTry";
      this.Text = "Попытка рисования";
      ((System.ComponentModel.ISupportInitialize)(this.picbx)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox picbx;
    private System.Windows.Forms.Button btnSob;
  }
}


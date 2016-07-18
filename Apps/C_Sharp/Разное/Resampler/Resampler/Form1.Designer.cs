namespace Resampler
{
  partial class Form1
  {
    /// <summary>
    /// Обязательная переменная конструктора.
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
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this._ctrlLblOutY = new System.Windows.Forms.Label();
      this._ctrlLblOutX = new System.Windows.Forms.Label();
      this._ctrlTxbInY = new System.Windows.Forms.TextBox();
      this._ctrlTxbInX = new System.Windows.Forms.TextBox();
      this._ctrlBaton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // _ctrlLblOutY
      // 
      this._ctrlLblOutY.AutoSize = true;
      this._ctrlLblOutY.Location = new System.Drawing.Point(9, 79);
      this._ctrlLblOutY.Name = "_ctrlLblOutY";
      this._ctrlLblOutY.Size = new System.Drawing.Size(20, 13);
      this._ctrlLblOutY.TabIndex = 0;
      this._ctrlLblOutY.Text = "Y: ";
      // 
      // _ctrlLblOutX
      // 
      this._ctrlLblOutX.AutoSize = true;
      this._ctrlLblOutX.Location = new System.Drawing.Point(94, 15);
      this._ctrlLblOutX.Name = "_ctrlLblOutX";
      this._ctrlLblOutX.Size = new System.Drawing.Size(20, 13);
      this._ctrlLblOutX.TabIndex = 1;
      this._ctrlLblOutX.Text = "Х: ";
      // 
      // _ctrlTxbInY
      // 
      this._ctrlTxbInY.Location = new System.Drawing.Point(12, 45);
      this._ctrlTxbInY.Name = "_ctrlTxbInY";
      this._ctrlTxbInY.Size = new System.Drawing.Size(32, 20);
      this._ctrlTxbInY.TabIndex = 2;
      // 
      // _ctrlTxbInX
      // 
      this._ctrlTxbInX.Location = new System.Drawing.Point(56, 12);
      this._ctrlTxbInX.Name = "_ctrlTxbInX";
      this._ctrlTxbInX.Size = new System.Drawing.Size(32, 20);
      this._ctrlTxbInX.TabIndex = 3;
      // 
      // _ctrlBaton
      // 
      this._ctrlBaton.Location = new System.Drawing.Point(56, 45);
      this._ctrlBaton.Name = "_ctrlBaton";
      this._ctrlBaton.Size = new System.Drawing.Size(60, 23);
      this._ctrlBaton.TabIndex = 4;
      this._ctrlBaton.Text = "Херак";
      this._ctrlBaton.UseVisualStyleBackColor = true;
      this._ctrlBaton.Click += new System.EventHandler(this._ctrlBaton_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(143, 108);
      this.Controls.Add(this._ctrlBaton);
      this.Controls.Add(this._ctrlTxbInX);
      this.Controls.Add(this._ctrlTxbInY);
      this.Controls.Add(this._ctrlLblOutX);
      this.Controls.Add(this._ctrlLblOutY);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.Text = "Resampler";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label _ctrlLblOutY;
    private System.Windows.Forms.Label _ctrlLblOutX;
    private System.Windows.Forms.TextBox _ctrlTxbInY;
    private System.Windows.Forms.TextBox _ctrlTxbInX;
    private System.Windows.Forms.Button _ctrlBaton;
  }
}


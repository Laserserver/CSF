namespace YaispTwoEight
{
  partial class MainForm
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
      this._ctrlCanvasPicBx = new System.Windows.Forms.PictureBox();
      this._ctrlNumLower = new System.Windows.Forms.NumericUpDown();
      this._ctrlNumUpper = new System.Windows.Forms.NumericUpDown();
      this._ctrlLblMisc1 = new System.Windows.Forms.Label();
      this._ctrlLblMisc2 = new System.Windows.Forms.Label();
      this._ctrlButDrawCashBox = new System.Windows.Forms.Button();
      this._ctrlButRefill = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this._ctrlButThrAbort = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this._ctrlButThrPause = new System.Windows.Forms.Button();
      this._ctrlButThrPlay = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlCanvasPicBx)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumLower)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumUpper)).BeginInit();
      this.SuspendLayout();
      // 
      // _ctrlCanvasPicBx
      // 
      this._ctrlCanvasPicBx.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this._ctrlCanvasPicBx.Location = new System.Drawing.Point(12, 12);
      this._ctrlCanvasPicBx.Name = "_ctrlCanvasPicBx";
      this._ctrlCanvasPicBx.Size = new System.Drawing.Size(740, 530);
      this._ctrlCanvasPicBx.TabIndex = 0;
      this._ctrlCanvasPicBx.TabStop = false;
      // 
      // _ctrlNumLower
      // 
      this._ctrlNumLower.Enabled = false;
      this._ctrlNumLower.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this._ctrlNumLower.Location = new System.Drawing.Point(852, 30);
      this._ctrlNumLower.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this._ctrlNumLower.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this._ctrlNumLower.Name = "_ctrlNumLower";
      this._ctrlNumLower.Size = new System.Drawing.Size(120, 20);
      this._ctrlNumLower.TabIndex = 1;
      this._ctrlNumLower.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this._ctrlNumLower.ValueChanged += new System.EventHandler(this._ctrlNumLower_ValueChanged);
      // 
      // _ctrlNumUpper
      // 
      this._ctrlNumUpper.Enabled = false;
      this._ctrlNumUpper.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this._ctrlNumUpper.Location = new System.Drawing.Point(852, 69);
      this._ctrlNumUpper.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
      this._ctrlNumUpper.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this._ctrlNumUpper.Name = "_ctrlNumUpper";
      this._ctrlNumUpper.Size = new System.Drawing.Size(120, 20);
      this._ctrlNumUpper.TabIndex = 2;
      this._ctrlNumUpper.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this._ctrlNumUpper.ValueChanged += new System.EventHandler(this._ctrlNumUpper_ValueChanged);
      // 
      // _ctrlLblMisc1
      // 
      this._ctrlLblMisc1.AutoSize = true;
      this._ctrlLblMisc1.Location = new System.Drawing.Point(839, 12);
      this._ctrlLblMisc1.Name = "_ctrlLblMisc1";
      this._ctrlLblMisc1.Size = new System.Drawing.Size(138, 13);
      this._ctrlLblMisc1.TabIndex = 3;
      this._ctrlLblMisc1.Text = "Запрашиваемые цены от:";
      // 
      // _ctrlLblMisc2
      // 
      this._ctrlLblMisc2.AutoSize = true;
      this._ctrlLblMisc2.Location = new System.Drawing.Point(839, 53);
      this._ctrlLblMisc2.Name = "_ctrlLblMisc2";
      this._ctrlLblMisc2.Size = new System.Drawing.Size(28, 13);
      this._ctrlLblMisc2.TabIndex = 4;
      this._ctrlLblMisc2.Text = "До: ";
      // 
      // _ctrlButDrawCashBox
      // 
      this._ctrlButDrawCashBox.Location = new System.Drawing.Point(758, 12);
      this._ctrlButDrawCashBox.Name = "_ctrlButDrawCashBox";
      this._ctrlButDrawCashBox.Size = new System.Drawing.Size(75, 38);
      this._ctrlButDrawCashBox.TabIndex = 5;
      this._ctrlButDrawCashBox.Text = "Установить банкомат";
      this._ctrlButDrawCashBox.UseVisualStyleBackColor = true;
      this._ctrlButDrawCashBox.Click += new System.EventHandler(this._ctrlButDrawCashBox_Click);
      // 
      // _ctrlButRefill
      // 
      this._ctrlButRefill.Enabled = false;
      this._ctrlButRefill.Location = new System.Drawing.Point(758, 67);
      this._ctrlButRefill.Name = "_ctrlButRefill";
      this._ctrlButRefill.Size = new System.Drawing.Size(75, 21);
      this._ctrlButRefill.TabIndex = 6;
      this._ctrlButRefill.Text = "Заполнить";
      this._ctrlButRefill.UseVisualStyleBackColor = true;
      this._ctrlButRefill.Click += new System.EventHandler(this._ctrlButRefill_Click);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(758, 124);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 7;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click_1);
      // 
      // _ctrlButThrAbort
      // 
      this._ctrlButThrAbort.Location = new System.Drawing.Point(870, 124);
      this._ctrlButThrAbort.Name = "_ctrlButThrAbort";
      this._ctrlButThrAbort.Size = new System.Drawing.Size(85, 23);
      this._ctrlButThrAbort.TabIndex = 8;
      this._ctrlButThrAbort.Text = "Стоп";
      this._ctrlButThrAbort.UseVisualStyleBackColor = true;
      this._ctrlButThrAbort.Click += new System.EventHandler(this._ctrlButAbortThreads_Click);
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(805, 250);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(126, 222);
      this.textBox1.TabIndex = 9;
      // 
      // _ctrlButThrPause
      // 
      this._ctrlButThrPause.Location = new System.Drawing.Point(870, 153);
      this._ctrlButThrPause.Name = "_ctrlButThrPause";
      this._ctrlButThrPause.Size = new System.Drawing.Size(85, 23);
      this._ctrlButThrPause.TabIndex = 10;
      this._ctrlButThrPause.Text = "Пауза";
      this._ctrlButThrPause.UseVisualStyleBackColor = true;
      this._ctrlButThrPause.Click += new System.EventHandler(this._ctrlButThrPause_Click);
      // 
      // _ctrlButThrPlay
      // 
      this._ctrlButThrPlay.Location = new System.Drawing.Point(870, 182);
      this._ctrlButThrPlay.Name = "_ctrlButThrPlay";
      this._ctrlButThrPlay.Size = new System.Drawing.Size(85, 23);
      this._ctrlButThrPlay.TabIndex = 11;
      this._ctrlButThrPlay.Text = "Продолжить";
      this._ctrlButThrPlay.UseVisualStyleBackColor = true;
      this._ctrlButThrPlay.Click += new System.EventHandler(this._ctrlButThrPlay_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(984, 556);
      this.Controls.Add(this._ctrlButThrPlay);
      this.Controls.Add(this._ctrlButThrPause);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this._ctrlButThrAbort);
      this.Controls.Add(this.button1);
      this.Controls.Add(this._ctrlButRefill);
      this.Controls.Add(this._ctrlButDrawCashBox);
      this.Controls.Add(this._ctrlLblMisc2);
      this.Controls.Add(this._ctrlLblMisc1);
      this.Controls.Add(this._ctrlNumUpper);
      this.Controls.Add(this._ctrlNumLower);
      this.Controls.Add(this._ctrlCanvasPicBx);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MainForm";
      this.Text = "Банкомат";
      ((System.ComponentModel.ISupportInitialize)(this._ctrlCanvasPicBx)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumLower)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumUpper)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox _ctrlCanvasPicBx;
    private System.Windows.Forms.NumericUpDown _ctrlNumLower;
    private System.Windows.Forms.NumericUpDown _ctrlNumUpper;
    private System.Windows.Forms.Label _ctrlLblMisc1;
    private System.Windows.Forms.Label _ctrlLblMisc2;
    private System.Windows.Forms.Button _ctrlButDrawCashBox;
    private System.Windows.Forms.Button _ctrlButRefill;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button _ctrlButThrAbort;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button _ctrlButThrPause;
    private System.Windows.Forms.Button _ctrlButThrPlay;
  }
}


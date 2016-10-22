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
      this.components = new System.ComponentModel.Container();
      this._ctrlCanvasPicBx = new System.Windows.Forms.PictureBox();
      this._ctrlNumLower = new System.Windows.Forms.NumericUpDown();
      this._ctrlNumUpper = new System.Windows.Forms.NumericUpDown();
      this._ctrlLblMisc1 = new System.Windows.Forms.Label();
      this._ctrlLblMisc2 = new System.Windows.Forms.Label();
      this._ctrlButDrawCashBox = new System.Windows.Forms.Button();
      this._ctrlButRefill = new System.Windows.Forms.Button();
      this._ctrlButThrPause = new System.Windows.Forms.Button();
      this._ctrlButThrPlay = new System.Windows.Forms.Button();
      this._ctrlTimer = new System.Windows.Forms.Timer(this.components);
      this._ctrlButStartShow = new System.Windows.Forms.Button();
      this._ctrlDGV = new System.Windows.Forms.DataGridView();
      this._ctrlTxb = new System.Windows.Forms.TextBox();
      this._ctrlLblMisc3 = new System.Windows.Forms.Label();
      this._ctrlLblMisc4 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlCanvasPicBx)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumLower)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumUpper)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlDGV)).BeginInit();
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
      this._ctrlButRefill.Location = new System.Drawing.Point(758, 56);
      this._ctrlButRefill.Name = "_ctrlButRefill";
      this._ctrlButRefill.Size = new System.Drawing.Size(75, 21);
      this._ctrlButRefill.TabIndex = 6;
      this._ctrlButRefill.Text = "Заполнить";
      this._ctrlButRefill.UseVisualStyleBackColor = true;
      this._ctrlButRefill.Click += new System.EventHandler(this._ctrlButRefill_Click);
      // 
      // _ctrlButThrPause
      // 
      this._ctrlButThrPause.Location = new System.Drawing.Point(852, 95);
      this._ctrlButThrPause.Name = "_ctrlButThrPause";
      this._ctrlButThrPause.Size = new System.Drawing.Size(85, 23);
      this._ctrlButThrPause.TabIndex = 10;
      this._ctrlButThrPause.Text = "Пауза";
      this._ctrlButThrPause.UseVisualStyleBackColor = true;
      this._ctrlButThrPause.Click += new System.EventHandler(this._ctrlButThrPause_Click);
      // 
      // _ctrlButThrPlay
      // 
      this._ctrlButThrPlay.Location = new System.Drawing.Point(852, 124);
      this._ctrlButThrPlay.Name = "_ctrlButThrPlay";
      this._ctrlButThrPlay.Size = new System.Drawing.Size(85, 23);
      this._ctrlButThrPlay.TabIndex = 11;
      this._ctrlButThrPlay.Text = "Продолжить";
      this._ctrlButThrPlay.UseVisualStyleBackColor = true;
      this._ctrlButThrPlay.Click += new System.EventHandler(this._ctrlButThrPlay_Click);
      // 
      // _ctrlTimer
      // 
      this._ctrlTimer.Tick += new System.EventHandler(this._ctrlTimer_Tick);
      // 
      // _ctrlButStartShow
      // 
      this._ctrlButStartShow.Location = new System.Drawing.Point(758, 124);
      this._ctrlButStartShow.Name = "_ctrlButStartShow";
      this._ctrlButStartShow.Size = new System.Drawing.Size(75, 23);
      this._ctrlButStartShow.TabIndex = 12;
      this._ctrlButStartShow.Text = "Начать";
      this._ctrlButStartShow.UseVisualStyleBackColor = true;
      this._ctrlButStartShow.Click += new System.EventHandler(this._ctrlButStartShow_Click);
      // 
      // _ctrlDGV
      // 
      this._ctrlDGV.AllowUserToAddRows = false;
      this._ctrlDGV.AllowUserToDeleteRows = false;
      this._ctrlDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this._ctrlDGV.ColumnHeadersVisible = false;
      this._ctrlDGV.Location = new System.Drawing.Point(758, 268);
      this._ctrlDGV.Name = "_ctrlDGV";
      this._ctrlDGV.ReadOnly = true;
      this._ctrlDGV.RowHeadersVisible = false;
      this._ctrlDGV.Size = new System.Drawing.Size(214, 274);
      this._ctrlDGV.TabIndex = 13;
      // 
      // _ctrlTxb
      // 
      this._ctrlTxb.Location = new System.Drawing.Point(758, 180);
      this._ctrlTxb.Multiline = true;
      this._ctrlTxb.Name = "_ctrlTxb";
      this._ctrlTxb.Size = new System.Drawing.Size(214, 56);
      this._ctrlTxb.TabIndex = 14;
      this._ctrlTxb.Text = "10,50,100,500,1000,5000";
      // 
      // _ctrlLblMisc3
      // 
      this._ctrlLblMisc3.AutoSize = true;
      this._ctrlLblMisc3.Location = new System.Drawing.Point(758, 164);
      this._ctrlLblMisc3.Name = "_ctrlLblMisc3";
      this._ctrlLblMisc3.Size = new System.Drawing.Size(130, 13);
      this._ctrlLblMisc3.TabIndex = 15;
      this._ctrlLblMisc3.Text = "Допустимые номиналы:";
      // 
      // _ctrlLblMisc4
      // 
      this._ctrlLblMisc4.AutoSize = true;
      this._ctrlLblMisc4.Location = new System.Drawing.Point(758, 252);
      this._ctrlLblMisc4.Name = "_ctrlLblMisc4";
      this._ctrlLblMisc4.Size = new System.Drawing.Size(103, 13);
      this._ctrlLblMisc4.TabIndex = 16;
      this._ctrlLblMisc4.Text = "Количество купюр:";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(984, 556);
      this.Controls.Add(this._ctrlLblMisc4);
      this.Controls.Add(this._ctrlLblMisc3);
      this.Controls.Add(this._ctrlTxb);
      this.Controls.Add(this._ctrlDGV);
      this.Controls.Add(this._ctrlButStartShow);
      this.Controls.Add(this._ctrlButThrPlay);
      this.Controls.Add(this._ctrlButThrPause);
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
      ((System.ComponentModel.ISupportInitialize)(this._ctrlDGV)).EndInit();
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
    private System.Windows.Forms.Button _ctrlButThrPause;
    private System.Windows.Forms.Button _ctrlButThrPlay;
    private System.Windows.Forms.Timer _ctrlTimer;
    private System.Windows.Forms.Button _ctrlButStartShow;
    private System.Windows.Forms.DataGridView _ctrlDGV;
    private System.Windows.Forms.TextBox _ctrlTxb;
    private System.Windows.Forms.Label _ctrlLblMisc3;
    private System.Windows.Forms.Label _ctrlLblMisc4;
  }
}


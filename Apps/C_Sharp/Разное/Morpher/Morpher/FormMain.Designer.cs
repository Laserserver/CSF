namespace Morphing
{
    partial class FormMain
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
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this._ctrlPicBx = new System.Windows.Forms.PictureBox();
      this._ctrlTxbXX1 = new System.Windows.Forms.TextBox();
      this._ctrlTxbX1 = new System.Windows.Forms.TextBox();
      this._ctrlTxb1 = new System.Windows.Forms.TextBox();
      this._ctrlTxb2 = new System.Windows.Forms.TextBox();
      this._ctrlTxbX2 = new System.Windows.Forms.TextBox();
      this._ctrlTxbXX2 = new System.Windows.Forms.TextBox();
      this._ctrlLblMisc1 = new System.Windows.Forms.Label();
      this._ctrlLblMisc2 = new System.Windows.Forms.Label();
      this._ctrlLblMisc3 = new System.Windows.Forms.Label();
      this._ctrlLblMisc4 = new System.Windows.Forms.Label();
      this._ctrlLblMisc7 = new System.Windows.Forms.Label();
      this._ctrlLblMisc8 = new System.Windows.Forms.Label();
      this._ctrlLblMisc6 = new System.Windows.Forms.Label();
      this._ctrlLblMisc5 = new System.Windows.Forms.Label();
      this._ctrlButView = new System.Windows.Forms.Button();
      this._ctrlButMorph = new System.Windows.Forms.Button();
      this._ctrlTxbSteps = new System.Windows.Forms.TextBox();
      this._ctrlLblMisc9 = new System.Windows.Forms.Label();
      this._ctrlTxbArgMin = new System.Windows.Forms.TextBox();
      this._ctrlTxbArgMax = new System.Windows.Forms.TextBox();
      this._ctrlLblMisc10 = new System.Windows.Forms.Label();
      this._ctrlLblMisc11 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlPicBx)).BeginInit();
      this.SuspendLayout();
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // timer1
      // 
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // _ctrlPicBx
      // 
      this._ctrlPicBx.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this._ctrlPicBx.Location = new System.Drawing.Point(12, 12);
      this._ctrlPicBx.Name = "_ctrlPicBx";
      this._ctrlPicBx.Size = new System.Drawing.Size(660, 465);
      this._ctrlPicBx.TabIndex = 1;
      this._ctrlPicBx.TabStop = false;
      this._ctrlPicBx.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
      this._ctrlPicBx.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
      this._ctrlPicBx.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
      this._ctrlPicBx.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp);
      // 
      // _ctrlTxbXX1
      // 
      this._ctrlTxbXX1.BackColor = System.Drawing.SystemColors.Window;
      this._ctrlTxbXX1.Location = new System.Drawing.Point(697, 28);
      this._ctrlTxbXX1.Name = "_ctrlTxbXX1";
      this._ctrlTxbXX1.Size = new System.Drawing.Size(22, 20);
      this._ctrlTxbXX1.TabIndex = 2;
      this._ctrlTxbXX1.Text = "0";
      // 
      // _ctrlTxbX1
      // 
      this._ctrlTxbX1.Location = new System.Drawing.Point(753, 28);
      this._ctrlTxbX1.Name = "_ctrlTxbX1";
      this._ctrlTxbX1.Size = new System.Drawing.Size(22, 20);
      this._ctrlTxbX1.TabIndex = 3;
      this._ctrlTxbX1.Text = "0";
      // 
      // _ctrlTxb1
      // 
      this._ctrlTxb1.Location = new System.Drawing.Point(797, 28);
      this._ctrlTxb1.Name = "_ctrlTxb1";
      this._ctrlTxb1.Size = new System.Drawing.Size(22, 20);
      this._ctrlTxb1.TabIndex = 4;
      this._ctrlTxb1.Text = "0";
      // 
      // _ctrlTxb2
      // 
      this._ctrlTxb2.Location = new System.Drawing.Point(797, 84);
      this._ctrlTxb2.Name = "_ctrlTxb2";
      this._ctrlTxb2.Size = new System.Drawing.Size(22, 20);
      this._ctrlTxb2.TabIndex = 7;
      this._ctrlTxb2.Text = "0";
      // 
      // _ctrlTxbX2
      // 
      this._ctrlTxbX2.Location = new System.Drawing.Point(753, 84);
      this._ctrlTxbX2.Name = "_ctrlTxbX2";
      this._ctrlTxbX2.Size = new System.Drawing.Size(22, 20);
      this._ctrlTxbX2.TabIndex = 6;
      this._ctrlTxbX2.Text = "0";
      // 
      // _ctrlTxbXX2
      // 
      this._ctrlTxbXX2.Location = new System.Drawing.Point(697, 84);
      this._ctrlTxbXX2.Name = "_ctrlTxbXX2";
      this._ctrlTxbXX2.Size = new System.Drawing.Size(22, 20);
      this._ctrlTxbXX2.TabIndex = 5;
      this._ctrlTxbXX2.Text = "0";
      // 
      // _ctrlLblMisc1
      // 
      this._ctrlLblMisc1.AutoSize = true;
      this._ctrlLblMisc1.Location = new System.Drawing.Point(676, 12);
      this._ctrlLblMisc1.Name = "_ctrlLblMisc1";
      this._ctrlLblMisc1.Size = new System.Drawing.Size(87, 13);
      this._ctrlLblMisc1.TabIndex = 8;
      this._ctrlLblMisc1.Text = "Первый график";
      // 
      // _ctrlLblMisc2
      // 
      this._ctrlLblMisc2.AutoSize = true;
      this._ctrlLblMisc2.Location = new System.Drawing.Point(676, 68);
      this._ctrlLblMisc2.Name = "_ctrlLblMisc2";
      this._ctrlLblMisc2.Size = new System.Drawing.Size(83, 13);
      this._ctrlLblMisc2.TabIndex = 9;
      this._ctrlLblMisc2.Text = "Второй график";
      // 
      // _ctrlLblMisc3
      // 
      this._ctrlLblMisc3.AutoSize = true;
      this._ctrlLblMisc3.BackColor = System.Drawing.Color.Transparent;
      this._ctrlLblMisc3.Location = new System.Drawing.Point(676, 31);
      this._ctrlLblMisc3.Name = "_ctrlLblMisc3";
      this._ctrlLblMisc3.Size = new System.Drawing.Size(21, 13);
      this._ctrlLblMisc3.TabIndex = 10;
      this._ctrlLblMisc3.Text = "y =";
      // 
      // _ctrlLblMisc4
      // 
      this._ctrlLblMisc4.AutoSize = true;
      this._ctrlLblMisc4.BackColor = System.Drawing.Color.Transparent;
      this._ctrlLblMisc4.Location = new System.Drawing.Point(676, 87);
      this._ctrlLblMisc4.Name = "_ctrlLblMisc4";
      this._ctrlLblMisc4.Size = new System.Drawing.Size(21, 13);
      this._ctrlLblMisc4.TabIndex = 12;
      this._ctrlLblMisc4.Text = "y =";
      // 
      // _ctrlLblMisc7
      // 
      this._ctrlLblMisc7.AutoSize = true;
      this._ctrlLblMisc7.BackColor = System.Drawing.Color.Transparent;
      this._ctrlLblMisc7.Location = new System.Drawing.Point(721, 31);
      this._ctrlLblMisc7.Name = "_ctrlLblMisc7";
      this._ctrlLblMisc7.Size = new System.Drawing.Size(30, 13);
      this._ctrlLblMisc7.TabIndex = 13;
      this._ctrlLblMisc7.Text = "x*x +";
      // 
      // _ctrlLblMisc8
      // 
      this._ctrlLblMisc8.AutoSize = true;
      this._ctrlLblMisc8.BackColor = System.Drawing.Color.Transparent;
      this._ctrlLblMisc8.Location = new System.Drawing.Point(776, 31);
      this._ctrlLblMisc8.Name = "_ctrlLblMisc8";
      this._ctrlLblMisc8.Size = new System.Drawing.Size(21, 13);
      this._ctrlLblMisc8.TabIndex = 14;
      this._ctrlLblMisc8.Text = "x +";
      // 
      // _ctrlLblMisc6
      // 
      this._ctrlLblMisc6.AutoSize = true;
      this._ctrlLblMisc6.BackColor = System.Drawing.Color.Transparent;
      this._ctrlLblMisc6.Location = new System.Drawing.Point(776, 87);
      this._ctrlLblMisc6.Name = "_ctrlLblMisc6";
      this._ctrlLblMisc6.Size = new System.Drawing.Size(21, 13);
      this._ctrlLblMisc6.TabIndex = 16;
      this._ctrlLblMisc6.Text = "x +";
      // 
      // _ctrlLblMisc5
      // 
      this._ctrlLblMisc5.AutoSize = true;
      this._ctrlLblMisc5.BackColor = System.Drawing.Color.Transparent;
      this._ctrlLblMisc5.Location = new System.Drawing.Point(721, 87);
      this._ctrlLblMisc5.Name = "_ctrlLblMisc5";
      this._ctrlLblMisc5.Size = new System.Drawing.Size(30, 13);
      this._ctrlLblMisc5.TabIndex = 15;
      this._ctrlLblMisc5.Text = "x*x +";
      // 
      // _ctrlButView
      // 
      this._ctrlButView.Location = new System.Drawing.Point(679, 120);
      this._ctrlButView.Name = "_ctrlButView";
      this._ctrlButView.Size = new System.Drawing.Size(75, 24);
      this._ctrlButView.TabIndex = 17;
      this._ctrlButView.Text = "Построить";
      this._ctrlButView.UseVisualStyleBackColor = true;
      this._ctrlButView.Click += new System.EventHandler(this._ctrlButView_Click);
      // 
      // _ctrlButMorph
      // 
      this._ctrlButMorph.Enabled = false;
      this._ctrlButMorph.Location = new System.Drawing.Point(679, 160);
      this._ctrlButMorph.Name = "_ctrlButMorph";
      this._ctrlButMorph.Size = new System.Drawing.Size(75, 23);
      this._ctrlButMorph.TabIndex = 18;
      this._ctrlButMorph.Text = "Заменить";
      this._ctrlButMorph.UseVisualStyleBackColor = true;
      this._ctrlButMorph.Click += new System.EventHandler(this._ctrlButMorph_Click);
      // 
      // _ctrlTxbSteps
      // 
      this._ctrlTxbSteps.Location = new System.Drawing.Point(779, 160);
      this._ctrlTxbSteps.Name = "_ctrlTxbSteps";
      this._ctrlTxbSteps.Size = new System.Drawing.Size(40, 20);
      this._ctrlTxbSteps.TabIndex = 19;
      this._ctrlTxbSteps.Text = "20";
      // 
      // _ctrlLblMisc9
      // 
      this._ctrlLblMisc9.AutoSize = true;
      this._ctrlLblMisc9.Location = new System.Drawing.Point(776, 144);
      this._ctrlLblMisc9.Name = "_ctrlLblMisc9";
      this._ctrlLblMisc9.Size = new System.Drawing.Size(40, 13);
      this._ctrlLblMisc9.TabIndex = 20;
      this._ctrlLblMisc9.Text = "Точек:";
      // 
      // _ctrlTxbArgMin
      // 
      this._ctrlTxbArgMin.Location = new System.Drawing.Point(705, 202);
      this._ctrlTxbArgMin.Name = "_ctrlTxbArgMin";
      this._ctrlTxbArgMin.Size = new System.Drawing.Size(22, 20);
      this._ctrlTxbArgMin.TabIndex = 21;
      this._ctrlTxbArgMin.Text = "-10";
      // 
      // _ctrlTxbArgMax
      // 
      this._ctrlTxbArgMax.Location = new System.Drawing.Point(753, 202);
      this._ctrlTxbArgMax.Name = "_ctrlTxbArgMax";
      this._ctrlTxbArgMax.Size = new System.Drawing.Size(22, 20);
      this._ctrlTxbArgMax.TabIndex = 22;
      this._ctrlTxbArgMax.Text = "10";
      // 
      // _ctrlLblMisc10
      // 
      this._ctrlLblMisc10.AutoSize = true;
      this._ctrlLblMisc10.Location = new System.Drawing.Point(676, 205);
      this._ctrlLblMisc10.Name = "_ctrlLblMisc10";
      this._ctrlLblMisc10.Size = new System.Drawing.Size(26, 13);
      this._ctrlLblMisc10.TabIndex = 23;
      this._ctrlLblMisc10.Text = "x от";
      // 
      // _ctrlLblMisc11
      // 
      this._ctrlLblMisc11.AutoSize = true;
      this._ctrlLblMisc11.Location = new System.Drawing.Point(733, 205);
      this._ctrlLblMisc11.Name = "_ctrlLblMisc11";
      this._ctrlLblMisc11.Size = new System.Drawing.Size(19, 13);
      this._ctrlLblMisc11.TabIndex = 24;
      this._ctrlLblMisc11.Text = "до";
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(860, 489);
      this.Controls.Add(this._ctrlLblMisc11);
      this.Controls.Add(this._ctrlLblMisc10);
      this.Controls.Add(this._ctrlTxbArgMax);
      this.Controls.Add(this._ctrlTxbArgMin);
      this.Controls.Add(this._ctrlLblMisc9);
      this.Controls.Add(this._ctrlTxbSteps);
      this.Controls.Add(this._ctrlButMorph);
      this.Controls.Add(this._ctrlButView);
      this.Controls.Add(this._ctrlLblMisc6);
      this.Controls.Add(this._ctrlLblMisc5);
      this.Controls.Add(this._ctrlLblMisc8);
      this.Controls.Add(this._ctrlLblMisc7);
      this.Controls.Add(this._ctrlLblMisc4);
      this.Controls.Add(this._ctrlLblMisc3);
      this.Controls.Add(this._ctrlLblMisc2);
      this.Controls.Add(this._ctrlLblMisc1);
      this.Controls.Add(this._ctrlTxb2);
      this.Controls.Add(this._ctrlTxbX2);
      this.Controls.Add(this._ctrlTxbXX2);
      this.Controls.Add(this._ctrlTxb1);
      this.Controls.Add(this._ctrlTxbX1);
      this.Controls.Add(this._ctrlTxbXX1);
      this.Controls.Add(this._ctrlPicBx);
      this.Name = "FormMain";
      this.Text = "Смена одного графика другим";
      this.Load += new System.EventHandler(this.FormMain_Load);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
      this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp);
      ((System.ComponentModel.ISupportInitialize)(this._ctrlPicBx)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.PictureBox _ctrlPicBx;
    private System.Windows.Forms.TextBox _ctrlTxbXX1;
    private System.Windows.Forms.TextBox _ctrlTxbX1;
    private System.Windows.Forms.TextBox _ctrlTxb1;
    private System.Windows.Forms.TextBox _ctrlTxb2;
    private System.Windows.Forms.TextBox _ctrlTxbX2;
    private System.Windows.Forms.TextBox _ctrlTxbXX2;
    private System.Windows.Forms.Label _ctrlLblMisc1;
    private System.Windows.Forms.Label _ctrlLblMisc2;
    private System.Windows.Forms.Label _ctrlLblMisc3;
    private System.Windows.Forms.Label _ctrlLblMisc4;
    private System.Windows.Forms.Label _ctrlLblMisc7;
    private System.Windows.Forms.Label _ctrlLblMisc8;
    private System.Windows.Forms.Label _ctrlLblMisc6;
    private System.Windows.Forms.Label _ctrlLblMisc5;
    private System.Windows.Forms.Button _ctrlButView;
    private System.Windows.Forms.Button _ctrlButMorph;
    private System.Windows.Forms.TextBox _ctrlTxbSteps;
    private System.Windows.Forms.Label _ctrlLblMisc9;
    private System.Windows.Forms.TextBox _ctrlTxbArgMin;
    private System.Windows.Forms.TextBox _ctrlTxbArgMax;
    private System.Windows.Forms.Label _ctrlLblMisc10;
    private System.Windows.Forms.Label _ctrlLblMisc11;
  }
}


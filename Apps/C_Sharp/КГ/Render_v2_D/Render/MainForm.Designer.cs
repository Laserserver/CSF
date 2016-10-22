namespace Render
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
      this._ctrlCanvas = new System.Windows.Forms.PictureBox();
      this._ctrlGrbAxis = new System.Windows.Forms.GroupBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this._ctrlRadNotEdges = new System.Windows.Forms.RadioButton();
      this._ctrlRadEdges = new System.Windows.Forms.RadioButton();
      this._ctrlBaton = new System.Windows.Forms.Button();
      this._ctrlChBModelZoom = new System.Windows.Forms.CheckBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this._ctrlRBR = new System.Windows.Forms.RadioButton();
      this._ctrlRBGrZ = new System.Windows.Forms.RadioButton();
      this._ctrlNumZoom = new System.Windows.Forms.NumericUpDown();
      this._ctrlNumLigZ = new System.Windows.Forms.NumericUpDown();
      this._ctrlNumLigY = new System.Windows.Forms.NumericUpDown();
      this._ctrlNumLigX = new System.Windows.Forms.NumericUpDown();
      this._ctrlLblMisc = new System.Windows.Forms.Label();
      this._ctrlNumRadSpeed = new System.Windows.Forms.NumericUpDown();
      this._ctrlRadZ = new System.Windows.Forms.RadioButton();
      this._ctrlRadX = new System.Windows.Forms.RadioButton();
      this._ctrlRadY = new System.Windows.Forms.RadioButton();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlCanvas)).BeginInit();
      this._ctrlGrbAxis.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumZoom)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumLigZ)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumLigY)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumLigX)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumRadSpeed)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
      this.SuspendLayout();
      // 
      // _ctrlCanvas
      // 
      this._ctrlCanvas.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
      this._ctrlCanvas.Location = new System.Drawing.Point(12, 12);
      this._ctrlCanvas.Name = "_ctrlCanvas";
      this._ctrlCanvas.Size = new System.Drawing.Size(1000, 1000);
      this._ctrlCanvas.TabIndex = 0;
      this._ctrlCanvas.TabStop = false;
      this._ctrlCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this._ctrlCanvas_MouseDown);
      this._ctrlCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this._ctrlCanvas_MouseMove);
      this._ctrlCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this._ctrlCanvas_MouseUp);
      // 
      // _ctrlGrbAxis
      // 
      this._ctrlGrbAxis.Controls.Add(this.numericUpDown2);
      this._ctrlGrbAxis.Controls.Add(this.numericUpDown1);
      this._ctrlGrbAxis.Controls.Add(this.groupBox2);
      this._ctrlGrbAxis.Controls.Add(this._ctrlBaton);
      this._ctrlGrbAxis.Controls.Add(this._ctrlChBModelZoom);
      this._ctrlGrbAxis.Controls.Add(this.groupBox1);
      this._ctrlGrbAxis.Controls.Add(this._ctrlNumZoom);
      this._ctrlGrbAxis.Controls.Add(this._ctrlNumLigZ);
      this._ctrlGrbAxis.Controls.Add(this._ctrlNumLigY);
      this._ctrlGrbAxis.Controls.Add(this._ctrlNumLigX);
      this._ctrlGrbAxis.Controls.Add(this._ctrlLblMisc);
      this._ctrlGrbAxis.Controls.Add(this._ctrlNumRadSpeed);
      this._ctrlGrbAxis.Controls.Add(this._ctrlRadZ);
      this._ctrlGrbAxis.Controls.Add(this._ctrlRadX);
      this._ctrlGrbAxis.Controls.Add(this._ctrlRadY);
      this._ctrlGrbAxis.Location = new System.Drawing.Point(1018, 12);
      this._ctrlGrbAxis.Name = "_ctrlGrbAxis";
      this._ctrlGrbAxis.Size = new System.Drawing.Size(193, 344);
      this._ctrlGrbAxis.TabIndex = 28;
      this._ctrlGrbAxis.TabStop = false;
      this._ctrlGrbAxis.Text = "Оси епта";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this._ctrlRadNotEdges);
      this.groupBox2.Controls.Add(this._ctrlRadEdges);
      this.groupBox2.Location = new System.Drawing.Point(9, 165);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(84, 100);
      this.groupBox2.TabIndex = 29;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "groupBox2";
      // 
      // _ctrlRadNotEdges
      // 
      this._ctrlRadNotEdges.AutoSize = true;
      this._ctrlRadNotEdges.Checked = true;
      this._ctrlRadNotEdges.Location = new System.Drawing.Point(6, 19);
      this._ctrlRadNotEdges.Name = "_ctrlRadNotEdges";
      this._ctrlRadNotEdges.Size = new System.Drawing.Size(76, 17);
      this._ctrlRadNotEdges.TabIndex = 1;
      this._ctrlRadNotEdges.TabStop = true;
      this._ctrlRadNotEdges.Text = "Полигоны";
      this._ctrlRadNotEdges.UseVisualStyleBackColor = true;
      this._ctrlRadNotEdges.CheckedChanged += new System.EventHandler(this._ctrlRadNotEdges_CheckedChanged);
      // 
      // _ctrlRadEdges
      // 
      this._ctrlRadEdges.AutoSize = true;
      this._ctrlRadEdges.Location = new System.Drawing.Point(6, 42);
      this._ctrlRadEdges.Name = "_ctrlRadEdges";
      this._ctrlRadEdges.Size = new System.Drawing.Size(56, 17);
      this._ctrlRadEdges.TabIndex = 0;
      this._ctrlRadEdges.Text = "Ребра";
      this._ctrlRadEdges.UseVisualStyleBackColor = true;
      this._ctrlRadEdges.CheckedChanged += new System.EventHandler(this._ctrlRadNotEdges_CheckedChanged);
      // 
      // _ctrlBaton
      // 
      this._ctrlBaton.Location = new System.Drawing.Point(108, 224);
      this._ctrlBaton.Name = "_ctrlBaton";
      this._ctrlBaton.Size = new System.Drawing.Size(75, 23);
      this._ctrlBaton.TabIndex = 27;
      this._ctrlBaton.Text = "Батон";
      this._ctrlBaton.UseVisualStyleBackColor = true;
      this._ctrlBaton.Click += new System.EventHandler(this._ctrlBaton_Click);
      // 
      // _ctrlChBModelZoom
      // 
      this._ctrlChBModelZoom.AutoSize = true;
      this._ctrlChBModelZoom.Location = new System.Drawing.Point(97, 184);
      this._ctrlChBModelZoom.Name = "_ctrlChBModelZoom";
      this._ctrlChBModelZoom.Size = new System.Drawing.Size(94, 17);
      this._ctrlChBModelZoom.TabIndex = 29;
      this._ctrlChBModelZoom.Text = "Зумирование";
      this._ctrlChBModelZoom.UseVisualStyleBackColor = true;
      this._ctrlChBModelZoom.CheckedChanged += new System.EventHandler(this._ctrlChBModelZoom_CheckedChanged);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this._ctrlRBR);
      this.groupBox1.Controls.Add(this._ctrlRBGrZ);
      this.groupBox1.Location = new System.Drawing.Point(108, 93);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(79, 66);
      this.groupBox1.TabIndex = 28;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "groupBox1";
      // 
      // _ctrlRBR
      // 
      this._ctrlRBR.AutoSize = true;
      this._ctrlRBR.Location = new System.Drawing.Point(6, 42);
      this._ctrlRBR.Name = "_ctrlRBR";
      this._ctrlRBR.Size = new System.Drawing.Size(53, 17);
      this._ctrlRBR.TabIndex = 1;
      this._ctrlRBR.Text = "Вращ";
      this._ctrlRBR.UseVisualStyleBackColor = true;
      // 
      // _ctrlRBGrZ
      // 
      this._ctrlRBGrZ.AutoSize = true;
      this._ctrlRBGrZ.Checked = true;
      this._ctrlRBGrZ.Location = new System.Drawing.Point(6, 19);
      this._ctrlRBGrZ.Name = "_ctrlRBGrZ";
      this._ctrlRBGrZ.Size = new System.Drawing.Size(67, 17);
      this._ctrlRBGrZ.TabIndex = 0;
      this._ctrlRBGrZ.TabStop = true;
      this._ctrlRBGrZ.Text = "Зум грф";
      this._ctrlRBGrZ.UseVisualStyleBackColor = true;
      // 
      // _ctrlNumZoom
      // 
      this._ctrlNumZoom.Location = new System.Drawing.Point(6, 139);
      this._ctrlNumZoom.Name = "_ctrlNumZoom";
      this._ctrlNumZoom.Size = new System.Drawing.Size(50, 20);
      this._ctrlNumZoom.TabIndex = 27;
      this._ctrlNumZoom.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      // 
      // _ctrlNumLigZ
      // 
      this._ctrlNumLigZ.Location = new System.Drawing.Point(138, 68);
      this._ctrlNumLigZ.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
      this._ctrlNumLigZ.Name = "_ctrlNumLigZ";
      this._ctrlNumLigZ.Size = new System.Drawing.Size(49, 20);
      this._ctrlNumLigZ.TabIndex = 24;
      this._ctrlNumLigZ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this._ctrlNumLigZ.ValueChanged += new System.EventHandler(this._ctrlNumLigX_ValueChanged);
      // 
      // _ctrlNumLigY
      // 
      this._ctrlNumLigY.Location = new System.Drawing.Point(138, 42);
      this._ctrlNumLigY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
      this._ctrlNumLigY.Name = "_ctrlNumLigY";
      this._ctrlNumLigY.Size = new System.Drawing.Size(49, 20);
      this._ctrlNumLigY.TabIndex = 23;
      this._ctrlNumLigY.ValueChanged += new System.EventHandler(this._ctrlNumLigX_ValueChanged);
      // 
      // _ctrlNumLigX
      // 
      this._ctrlNumLigX.Location = new System.Drawing.Point(138, 16);
      this._ctrlNumLigX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
      this._ctrlNumLigX.Name = "_ctrlNumLigX";
      this._ctrlNumLigX.Size = new System.Drawing.Size(49, 20);
      this._ctrlNumLigX.TabIndex = 22;
      this._ctrlNumLigX.ValueChanged += new System.EventHandler(this._ctrlNumLigX_ValueChanged);
      // 
      // _ctrlLblMisc
      // 
      this._ctrlLblMisc.AutoSize = true;
      this._ctrlLblMisc.Location = new System.Drawing.Point(6, 93);
      this._ctrlLblMisc.Name = "_ctrlLblMisc";
      this._ctrlLblMisc.Size = new System.Drawing.Size(87, 13);
      this._ctrlLblMisc.TabIndex = 6;
      this._ctrlLblMisc.Text = "Скорость (град)";
      // 
      // _ctrlNumRadSpeed
      // 
      this._ctrlNumRadSpeed.Location = new System.Drawing.Point(6, 109);
      this._ctrlNumRadSpeed.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
      this._ctrlNumRadSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this._ctrlNumRadSpeed.Name = "_ctrlNumRadSpeed";
      this._ctrlNumRadSpeed.Size = new System.Drawing.Size(50, 20);
      this._ctrlNumRadSpeed.TabIndex = 5;
      this._ctrlNumRadSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // _ctrlRadZ
      // 
      this._ctrlRadZ.AutoSize = true;
      this._ctrlRadZ.Location = new System.Drawing.Point(6, 65);
      this._ctrlRadZ.Name = "_ctrlRadZ";
      this._ctrlRadZ.Size = new System.Drawing.Size(85, 17);
      this._ctrlRadZ.TabIndex = 4;
      this._ctrlRadZ.Tag = "3";
      this._ctrlRadZ.Text = "Крути бля Z";
      this._ctrlRadZ.UseVisualStyleBackColor = true;
      this._ctrlRadZ.CheckedChanged += new System.EventHandler(this._ctrlRadX_CheckedChanged);
      // 
      // _ctrlRadX
      // 
      this._ctrlRadX.AutoSize = true;
      this._ctrlRadX.Checked = true;
      this._ctrlRadX.Location = new System.Drawing.Point(6, 19);
      this._ctrlRadX.Name = "_ctrlRadX";
      this._ctrlRadX.Size = new System.Drawing.Size(85, 17);
      this._ctrlRadX.TabIndex = 2;
      this._ctrlRadX.TabStop = true;
      this._ctrlRadX.Tag = "1";
      this._ctrlRadX.Text = "Крути бля Х";
      this._ctrlRadX.UseVisualStyleBackColor = true;
      this._ctrlRadX.CheckedChanged += new System.EventHandler(this._ctrlRadX_CheckedChanged);
      // 
      // _ctrlRadY
      // 
      this._ctrlRadY.AutoSize = true;
      this._ctrlRadY.Location = new System.Drawing.Point(6, 42);
      this._ctrlRadY.Name = "_ctrlRadY";
      this._ctrlRadY.Size = new System.Drawing.Size(85, 17);
      this._ctrlRadY.TabIndex = 3;
      this._ctrlRadY.Tag = "2";
      this._ctrlRadY.Text = "Крути бля Y";
      this._ctrlRadY.UseVisualStyleBackColor = true;
      this._ctrlRadY.CheckedChanged += new System.EventHandler(this._ctrlRadX_CheckedChanged);
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // numericUpDown1
      // 
      this.numericUpDown1.Location = new System.Drawing.Point(9, 281);
      this.numericUpDown1.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
      this.numericUpDown1.Minimum = new decimal(new int[] {
            1001,
            0,
            0,
            -2147483648});
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new System.Drawing.Size(50, 20);
      this.numericUpDown1.TabIndex = 30;
      this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
      // 
      // numericUpDown2
      // 
      this.numericUpDown2.Location = new System.Drawing.Point(9, 307);
      this.numericUpDown2.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
      this.numericUpDown2.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
      this.numericUpDown2.Name = "numericUpDown2";
      this.numericUpDown2.Size = new System.Drawing.Size(50, 20);
      this.numericUpDown2.TabIndex = 31;
      this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1219, 1021);
      this.Controls.Add(this._ctrlGrbAxis);
      this.Controls.Add(this._ctrlCanvas);
      this.DoubleBuffered = true;
      this.Name = "MainForm";
      this.Text = "Херня";
      ((System.ComponentModel.ISupportInitialize)(this._ctrlCanvas)).EndInit();
      this._ctrlGrbAxis.ResumeLayout(false);
      this._ctrlGrbAxis.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumZoom)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumLigZ)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumLigY)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumLigX)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumRadSpeed)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
      this.ResumeLayout(false);

        }

    #endregion

    private System.Windows.Forms.PictureBox _ctrlCanvas;
    private System.Windows.Forms.GroupBox _ctrlGrbAxis;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.RadioButton _ctrlRBR;
    private System.Windows.Forms.RadioButton _ctrlRBGrZ;
    private System.Windows.Forms.NumericUpDown _ctrlNumZoom;
    private System.Windows.Forms.NumericUpDown _ctrlNumLigZ;
    private System.Windows.Forms.NumericUpDown _ctrlNumLigY;
    private System.Windows.Forms.NumericUpDown _ctrlNumLigX;
    private System.Windows.Forms.Label _ctrlLblMisc;
    private System.Windows.Forms.NumericUpDown _ctrlNumRadSpeed;
    private System.Windows.Forms.RadioButton _ctrlRadZ;
    private System.Windows.Forms.RadioButton _ctrlRadX;
    private System.Windows.Forms.RadioButton _ctrlRadY;
    private System.Windows.Forms.CheckBox _ctrlChBModelZoom;
    private System.Windows.Forms.Button _ctrlBaton;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.RadioButton _ctrlRadNotEdges;
    private System.Windows.Forms.RadioButton _ctrlRadEdges;
    private System.Windows.Forms.NumericUpDown numericUpDown2;
    private System.Windows.Forms.NumericUpDown numericUpDown1;
  }
}


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
      this._ctrlNumAngleBet = new System.Windows.Forms.NumericUpDown();
      this._ctrlNumAngleAlf = new System.Windows.Forms.NumericUpDown();
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
      this._ctrlLblMisc1 = new System.Windows.Forms.Label();
      this._ctrlLblMisc2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this._ctrlNumXLef = new System.Windows.Forms.NumericUpDown();
      this._ctrlNumXRig = new System.Windows.Forms.NumericUpDown();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this._ctrlNumYLow = new System.Windows.Forms.NumericUpDown();
      this._ctrlNumYHig = new System.Windows.Forms.NumericUpDown();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this._ctrlNumFYC = new System.Windows.Forms.NumericUpDown();
      this._ctrlNumFXC = new System.Windows.Forms.NumericUpDown();
      this.label7 = new System.Windows.Forms.Label();
      this._ctrlNumFZC = new System.Windows.Forms.NumericUpDown();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlCanvas)).BeginInit();
      this._ctrlGrbAxis.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumAngleBet)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumAngleAlf)).BeginInit();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumZoom)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumLigZ)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumLigY)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumLigX)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumRadSpeed)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumXLef)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumXRig)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumYLow)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumYHig)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumFYC)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumFXC)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumFZC)).BeginInit();
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
      this._ctrlGrbAxis.Controls.Add(this.label7);
      this._ctrlGrbAxis.Controls.Add(this._ctrlNumFZC);
      this._ctrlGrbAxis.Controls.Add(this.label5);
      this._ctrlGrbAxis.Controls.Add(this.label6);
      this._ctrlGrbAxis.Controls.Add(this._ctrlNumFYC);
      this._ctrlGrbAxis.Controls.Add(this._ctrlNumFXC);
      this._ctrlGrbAxis.Controls.Add(this.label3);
      this._ctrlGrbAxis.Controls.Add(this.label4);
      this._ctrlGrbAxis.Controls.Add(this._ctrlNumYLow);
      this._ctrlGrbAxis.Controls.Add(this._ctrlNumYHig);
      this._ctrlGrbAxis.Controls.Add(this.label1);
      this._ctrlGrbAxis.Controls.Add(this.label2);
      this._ctrlGrbAxis.Controls.Add(this._ctrlNumXLef);
      this._ctrlGrbAxis.Controls.Add(this._ctrlNumXRig);
      this._ctrlGrbAxis.Controls.Add(this._ctrlLblMisc2);
      this._ctrlGrbAxis.Controls.Add(this._ctrlLblMisc1);
      this._ctrlGrbAxis.Controls.Add(this._ctrlNumAngleBet);
      this._ctrlGrbAxis.Controls.Add(this._ctrlNumAngleAlf);
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
      this._ctrlGrbAxis.Size = new System.Drawing.Size(193, 542);
      this._ctrlGrbAxis.TabIndex = 28;
      this._ctrlGrbAxis.TabStop = false;
      this._ctrlGrbAxis.Text = "Оси";
      // 
      // _ctrlNumAngleBet
      // 
      this._ctrlNumAngleBet.DecimalPlaces = 2;
      this._ctrlNumAngleBet.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this._ctrlNumAngleBet.Location = new System.Drawing.Point(9, 307);
      this._ctrlNumAngleBet.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
      this._ctrlNumAngleBet.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
      this._ctrlNumAngleBet.Name = "_ctrlNumAngleBet";
      this._ctrlNumAngleBet.Size = new System.Drawing.Size(50, 20);
      this._ctrlNumAngleBet.TabIndex = 31;
      this._ctrlNumAngleBet.ValueChanged += new System.EventHandler(this.Numeric_ValueChanged);
      // 
      // _ctrlNumAngleAlf
      // 
      this._ctrlNumAngleAlf.DecimalPlaces = 2;
      this._ctrlNumAngleAlf.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this._ctrlNumAngleAlf.Location = new System.Drawing.Point(9, 281);
      this._ctrlNumAngleAlf.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
      this._ctrlNumAngleAlf.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
      this._ctrlNumAngleAlf.Name = "_ctrlNumAngleAlf";
      this._ctrlNumAngleAlf.Size = new System.Drawing.Size(50, 20);
      this._ctrlNumAngleAlf.TabIndex = 30;
      this._ctrlNumAngleAlf.ValueChanged += new System.EventHandler(this.Numeric_ValueChanged);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this._ctrlRadNotEdges);
      this.groupBox2.Controls.Add(this._ctrlRadEdges);
      this.groupBox2.Location = new System.Drawing.Point(9, 165);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(84, 65);
      this.groupBox2.TabIndex = 29;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Отображ";
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
      this.groupBox1.Text = "Че делать";
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
      this._ctrlRadZ.Size = new System.Drawing.Size(32, 17);
      this._ctrlRadZ.TabIndex = 4;
      this._ctrlRadZ.Tag = "3";
      this._ctrlRadZ.Text = "Z";
      this._ctrlRadZ.UseVisualStyleBackColor = true;
      this._ctrlRadZ.CheckedChanged += new System.EventHandler(this._ctrlRadX_CheckedChanged);
      // 
      // _ctrlRadX
      // 
      this._ctrlRadX.AutoSize = true;
      this._ctrlRadX.Checked = true;
      this._ctrlRadX.Location = new System.Drawing.Point(6, 19);
      this._ctrlRadX.Name = "_ctrlRadX";
      this._ctrlRadX.Size = new System.Drawing.Size(32, 17);
      this._ctrlRadX.TabIndex = 2;
      this._ctrlRadX.TabStop = true;
      this._ctrlRadX.Tag = "1";
      this._ctrlRadX.Text = "Х";
      this._ctrlRadX.UseVisualStyleBackColor = true;
      this._ctrlRadX.CheckedChanged += new System.EventHandler(this._ctrlRadX_CheckedChanged);
      // 
      // _ctrlRadY
      // 
      this._ctrlRadY.AutoSize = true;
      this._ctrlRadY.Location = new System.Drawing.Point(6, 42);
      this._ctrlRadY.Name = "_ctrlRadY";
      this._ctrlRadY.Size = new System.Drawing.Size(32, 17);
      this._ctrlRadY.TabIndex = 3;
      this._ctrlRadY.Tag = "2";
      this._ctrlRadY.Text = "Y";
      this._ctrlRadY.UseVisualStyleBackColor = true;
      this._ctrlRadY.CheckedChanged += new System.EventHandler(this._ctrlRadX_CheckedChanged);
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // _ctrlLblMisc1
      // 
      this._ctrlLblMisc1.AutoSize = true;
      this._ctrlLblMisc1.Location = new System.Drawing.Point(65, 283);
      this._ctrlLblMisc1.Name = "_ctrlLblMisc1";
      this._ctrlLblMisc1.Size = new System.Drawing.Size(40, 13);
      this._ctrlLblMisc1.TabIndex = 32;
      this._ctrlLblMisc1.Text = "Альфа";
      // 
      // _ctrlLblMisc2
      // 
      this._ctrlLblMisc2.AutoSize = true;
      this._ctrlLblMisc2.Location = new System.Drawing.Point(65, 309);
      this._ctrlLblMisc2.Name = "_ctrlLblMisc2";
      this._ctrlLblMisc2.Size = new System.Drawing.Size(31, 13);
      this._ctrlLblMisc2.TabIndex = 33;
      this._ctrlLblMisc2.Text = "Бета";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(65, 371);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 37;
      this.label1.Text = "Х лев";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(65, 345);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 13);
      this.label2.TabIndex = 36;
      this.label2.Text = "X прав";
      // 
      // _ctrlNumXLef
      // 
      this._ctrlNumXLef.DecimalPlaces = 2;
      this._ctrlNumXLef.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this._ctrlNumXLef.Location = new System.Drawing.Point(9, 369);
      this._ctrlNumXLef.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
      this._ctrlNumXLef.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
      this._ctrlNumXLef.Name = "_ctrlNumXLef";
      this._ctrlNumXLef.Size = new System.Drawing.Size(50, 20);
      this._ctrlNumXLef.TabIndex = 35;
      this._ctrlNumXLef.Value = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
      this._ctrlNumXLef.ValueChanged += new System.EventHandler(this.Numeric_ValueChanged);
      // 
      // _ctrlNumXRig
      // 
      this._ctrlNumXRig.DecimalPlaces = 2;
      this._ctrlNumXRig.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this._ctrlNumXRig.Location = new System.Drawing.Point(9, 343);
      this._ctrlNumXRig.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
      this._ctrlNumXRig.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
      this._ctrlNumXRig.Name = "_ctrlNumXRig";
      this._ctrlNumXRig.Size = new System.Drawing.Size(50, 20);
      this._ctrlNumXRig.TabIndex = 34;
      this._ctrlNumXRig.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
      this._ctrlNumXRig.ValueChanged += new System.EventHandler(this.Numeric_ValueChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(65, 423);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(37, 13);
      this.label3.TabIndex = 41;
      this.label3.Text = "Y ниж";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(65, 397);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(40, 13);
      this.label4.TabIndex = 40;
      this.label4.Text = "Y верх";
      // 
      // _ctrlNumYLow
      // 
      this._ctrlNumYLow.DecimalPlaces = 2;
      this._ctrlNumYLow.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this._ctrlNumYLow.Location = new System.Drawing.Point(9, 421);
      this._ctrlNumYLow.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
      this._ctrlNumYLow.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
      this._ctrlNumYLow.Name = "_ctrlNumYLow";
      this._ctrlNumYLow.Size = new System.Drawing.Size(50, 20);
      this._ctrlNumYLow.TabIndex = 39;
      this._ctrlNumYLow.Value = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
      this._ctrlNumYLow.ValueChanged += new System.EventHandler(this.Numeric_ValueChanged);
      // 
      // _ctrlNumYHig
      // 
      this._ctrlNumYHig.DecimalPlaces = 2;
      this._ctrlNumYHig.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this._ctrlNumYHig.Location = new System.Drawing.Point(9, 395);
      this._ctrlNumYHig.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
      this._ctrlNumYHig.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
      this._ctrlNumYHig.Name = "_ctrlNumYHig";
      this._ctrlNumYHig.Size = new System.Drawing.Size(50, 20);
      this._ctrlNumYHig.TabIndex = 38;
      this._ctrlNumYHig.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
      this._ctrlNumYHig.ValueChanged += new System.EventHandler(this.Numeric_ValueChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(65, 485);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(21, 13);
      this.label5.TabIndex = 45;
      this.label5.Text = "fyc";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(65, 459);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(21, 13);
      this.label6.TabIndex = 44;
      this.label6.Text = "fxc";
      // 
      // _ctrlNumFYC
      // 
      this._ctrlNumFYC.DecimalPlaces = 2;
      this._ctrlNumFYC.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this._ctrlNumFYC.Location = new System.Drawing.Point(9, 483);
      this._ctrlNumFYC.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
      this._ctrlNumFYC.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
      this._ctrlNumFYC.Name = "_ctrlNumFYC";
      this._ctrlNumFYC.Size = new System.Drawing.Size(50, 20);
      this._ctrlNumFYC.TabIndex = 43;
      this._ctrlNumFYC.ValueChanged += new System.EventHandler(this.Numeric_ValueChanged);
      // 
      // _ctrlNumFXC
      // 
      this._ctrlNumFXC.DecimalPlaces = 2;
      this._ctrlNumFXC.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this._ctrlNumFXC.Location = new System.Drawing.Point(9, 457);
      this._ctrlNumFXC.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
      this._ctrlNumFXC.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
      this._ctrlNumFXC.Name = "_ctrlNumFXC";
      this._ctrlNumFXC.Size = new System.Drawing.Size(50, 20);
      this._ctrlNumFXC.TabIndex = 42;
      this._ctrlNumFXC.ValueChanged += new System.EventHandler(this.Numeric_ValueChanged);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(65, 511);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(21, 13);
      this.label7.TabIndex = 47;
      this.label7.Text = "fzc";
      // 
      // _ctrlNumFZC
      // 
      this._ctrlNumFZC.DecimalPlaces = 2;
      this._ctrlNumFZC.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this._ctrlNumFZC.Location = new System.Drawing.Point(9, 509);
      this._ctrlNumFZC.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
      this._ctrlNumFZC.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
      this._ctrlNumFZC.Name = "_ctrlNumFZC";
      this._ctrlNumFZC.Size = new System.Drawing.Size(50, 20);
      this._ctrlNumFZC.TabIndex = 46;
      this._ctrlNumFZC.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
      this._ctrlNumFZC.ValueChanged += new System.EventHandler(this.Numeric_ValueChanged);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1219, 1006);
      this.Controls.Add(this._ctrlGrbAxis);
      this.Controls.Add(this._ctrlCanvas);
      this.DoubleBuffered = true;
      this.Name = "MainForm";
      this.Text = "Рендер";
      ((System.ComponentModel.ISupportInitialize)(this._ctrlCanvas)).EndInit();
      this._ctrlGrbAxis.ResumeLayout(false);
      this._ctrlGrbAxis.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumAngleBet)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumAngleAlf)).EndInit();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumZoom)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumLigZ)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumLigY)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumLigX)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumRadSpeed)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumXLef)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumXRig)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumYLow)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumYHig)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumFYC)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumFXC)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumFZC)).EndInit();
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
    private System.Windows.Forms.NumericUpDown _ctrlNumAngleBet;
    private System.Windows.Forms.NumericUpDown _ctrlNumAngleAlf;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.NumericUpDown _ctrlNumFZC;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.NumericUpDown _ctrlNumFYC;
    private System.Windows.Forms.NumericUpDown _ctrlNumFXC;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.NumericUpDown _ctrlNumYLow;
    private System.Windows.Forms.NumericUpDown _ctrlNumYHig;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown _ctrlNumXLef;
    private System.Windows.Forms.NumericUpDown _ctrlNumXRig;
    private System.Windows.Forms.Label _ctrlLblMisc2;
    private System.Windows.Forms.Label _ctrlLblMisc1;
  }
}


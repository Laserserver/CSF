using System.Windows.Forms;

namespace TempGraphics
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this._ctrlBaton = new System.Windows.Forms.Button();
      this._ctrlCanvas = new System.Windows.Forms.Panel();
      this._ctrlRadX = new System.Windows.Forms.RadioButton();
      this._ctrlRadY = new System.Windows.Forms.RadioButton();
      this._ctrlRadZ = new System.Windows.Forms.RadioButton();
      this._ctrlGrbAxis = new System.Windows.Forms.GroupBox();
      this._ctrlNumLigZ = new System.Windows.Forms.NumericUpDown();
      this._ctrlNumLigY = new System.Windows.Forms.NumericUpDown();
      this._ctrlNumLigX = new System.Windows.Forms.NumericUpDown();
      this._ctrlLblMisc = new System.Windows.Forms.Label();
      this._ctrlNumRadSpeed = new System.Windows.Forms.NumericUpDown();
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this._ctrlGrbAxis.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumLigZ)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumLigY)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumLigX)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumRadSpeed)).BeginInit();
      this.SuspendLayout();
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // _ctrlBaton
      // 
      this._ctrlBaton.Location = new System.Drawing.Point(1006, 12);
      this._ctrlBaton.Name = "_ctrlBaton";
      this._ctrlBaton.Size = new System.Drawing.Size(75, 23);
      this._ctrlBaton.TabIndex = 0;
      this._ctrlBaton.Text = "Батон";
      this._ctrlBaton.UseVisualStyleBackColor = true;
      this._ctrlBaton.Click += new System.EventHandler(this._ctrlBaton_Click);
      // 
      // _ctrlCanvas
      // 
      this._ctrlCanvas.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
      this._ctrlCanvas.Location = new System.Drawing.Point(0, 0);
      this._ctrlCanvas.Name = "_ctrlCanvas";
      this._ctrlCanvas.Size = new System.Drawing.Size(1000, 1000);
      this._ctrlCanvas.TabIndex = 1;
      this._ctrlCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this._ctrlCanvas_MouseDown);
      this._ctrlCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this._ctrlCanvas_MouseMove);
      this._ctrlCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this._ctrlCanvas_MouseUp);
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
      // _ctrlGrbAxis
      // 
      this._ctrlGrbAxis.Controls.Add(this.checkBox1);
      this._ctrlGrbAxis.Controls.Add(this._ctrlNumLigZ);
      this._ctrlGrbAxis.Controls.Add(this._ctrlNumLigY);
      this._ctrlGrbAxis.Controls.Add(this._ctrlNumLigX);
      this._ctrlGrbAxis.Controls.Add(this._ctrlLblMisc);
      this._ctrlGrbAxis.Controls.Add(this._ctrlNumRadSpeed);
      this._ctrlGrbAxis.Controls.Add(this._ctrlRadZ);
      this._ctrlGrbAxis.Controls.Add(this._ctrlRadX);
      this._ctrlGrbAxis.Controls.Add(this._ctrlRadY);
      this._ctrlGrbAxis.Location = new System.Drawing.Point(1006, 57);
      this._ctrlGrbAxis.Name = "_ctrlGrbAxis";
      this._ctrlGrbAxis.Size = new System.Drawing.Size(193, 135);
      this._ctrlGrbAxis.TabIndex = 5;
      this._ctrlGrbAxis.TabStop = false;
      this._ctrlGrbAxis.Text = "Оси епта";
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
      this._ctrlNumLigZ.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
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
      this._ctrlNumLigY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this._ctrlNumLigY.ValueChanged += new System.EventHandler(this._ctrlNumLigY_ValueChanged);
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
      this._ctrlNumLigX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
      this._ctrlNumRadSpeed.ValueChanged += new System.EventHandler(this._ctrlNumRadSpeed_ValueChanged);
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new System.Drawing.Point(107, 110);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(80, 17);
      this.checkBox1.TabIndex = 25;
      this.checkBox1.Text = "checkBox1";
      this.checkBox1.UseVisualStyleBackColor = true;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1217, 1002);
      this.Controls.Add(this._ctrlGrbAxis);
      this.Controls.Add(this._ctrlCanvas);
      this.Controls.Add(this._ctrlBaton);
      this.Name = "MainForm";
      this.Text = "Херня";
      this._ctrlGrbAxis.ResumeLayout(false);
      this._ctrlGrbAxis.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumLigZ)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumLigY)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumLigX)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumRadSpeed)).EndInit();
      this.ResumeLayout(false);

        }



    #endregion

    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.Button _ctrlBaton;
    private System.Windows.Forms.Panel _ctrlCanvas;
    private RadioButton _ctrlRadX;
    private RadioButton _ctrlRadY;
    private RadioButton _ctrlRadZ;
    private GroupBox _ctrlGrbAxis;
    private Label _ctrlLblMisc;
    private NumericUpDown _ctrlNumRadSpeed;
    private NumericUpDown _ctrlNumLigZ;
    private NumericUpDown _ctrlNumLigY;
    private NumericUpDown _ctrlNumLigX;
    private CheckBox checkBox1;
  }
}


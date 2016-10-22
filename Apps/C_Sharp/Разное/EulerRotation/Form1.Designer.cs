namespace EulerRotation
{
    partial class Form1
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
            this.btnReset = new System.Windows.Forms.Button();
            this.tZ = new System.Windows.Forms.TrackBar();
            this.tY = new System.Windows.Forms.TrackBar();
            this.tX = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picCube = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCube)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(558, 192);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(47, 21);
            this.btnReset.TabIndex = 21;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tZ
            // 
            this.tZ.AutoSize = false;
            this.tZ.Location = new System.Drawing.Point(308, 170);
            this.tZ.Maximum = 360;
            this.tZ.Minimum = -360;
            this.tZ.Name = "tZ";
            this.tZ.Size = new System.Drawing.Size(306, 19);
            this.tZ.TabIndex = 20;
            this.tZ.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tZ.Scroll += new System.EventHandler(this.tZ_Scroll);
            // 
            // tY
            // 
            this.tY.AutoSize = false;
            this.tY.Location = new System.Drawing.Point(308, 145);
            this.tY.Maximum = 360;
            this.tY.Minimum = -360;
            this.tY.Name = "tY";
            this.tY.Size = new System.Drawing.Size(306, 19);
            this.tY.TabIndex = 19;
            this.tY.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tY.Scroll += new System.EventHandler(this.tY_Scroll);
            // 
            // tX
            // 
            this.tX.AutoSize = false;
            this.tX.Location = new System.Drawing.Point(308, 120);
            this.tX.Maximum = 360;
            this.tX.Minimum = -360;
            this.tX.Name = "tX";
            this.tX.Size = new System.Drawing.Size(306, 19);
            this.tX.TabIndex = 18;
            this.tX.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tX.Scroll += new System.EventHandler(this.tX_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Z:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "X:";
            // 
            // picCube
            // 
            this.picCube.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCube.Location = new System.Drawing.Point(12, 25);
            this.picCube.Name = "picCube";
            this.picCube.Size = new System.Drawing.Size(275, 275);
            this.picCube.TabIndex = 14;
            this.picCube.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 332);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.tZ);
            this.Controls.Add(this.tY);
            this.Controls.Add(this.tX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picCube);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3D Drawing";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCube)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TrackBar tZ;
        private System.Windows.Forms.TrackBar tY;
        private System.Windows.Forms.TrackBar tX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picCube;
    }
}


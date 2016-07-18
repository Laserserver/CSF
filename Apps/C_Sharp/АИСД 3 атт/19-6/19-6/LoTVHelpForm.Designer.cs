namespace _19_6
{
    partial class LoTVHelpForm
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
      this._ctrlRad3 = new System.Windows.Forms.RadioButton();
      this._ctrlRad4 = new System.Windows.Forms.RadioButton();
      this._ctrlRad5 = new System.Windows.Forms.RadioButton();
      this._ctrlRad2 = new System.Windows.Forms.RadioButton();
      this._ctrlRad1 = new System.Windows.Forms.RadioButton();
      this.SuspendLayout();
      // 
      // _ctrlRad3
      // 
      this._ctrlRad3.Appearance = System.Windows.Forms.Appearance.Button;
      this._ctrlRad3.Image = global::_19_6.Properties.Resources.LinePlus;
      this._ctrlRad3.Location = new System.Drawing.Point(63, 12);
      this._ctrlRad3.Name = "_ctrlRad3";
      this._ctrlRad3.Size = new System.Drawing.Size(21, 19);
      this._ctrlRad3.TabIndex = 2;
      this._ctrlRad3.Tag = "2";
      this._ctrlRad3.UseVisualStyleBackColor = true;
      this._ctrlRad3.CheckedChanged += new System.EventHandler(this._ctrlRad1_CheckedChanged);
      // 
      // _ctrlRad4
      // 
      this._ctrlRad4.Appearance = System.Windows.Forms.Appearance.Button;
      this._ctrlRad4.Image = global::_19_6.Properties.Resources.LineMinus;
      this._ctrlRad4.Location = new System.Drawing.Point(90, 12);
      this._ctrlRad4.Name = "_ctrlRad4";
      this._ctrlRad4.Size = new System.Drawing.Size(22, 19);
      this._ctrlRad4.TabIndex = 3;
      this._ctrlRad4.Tag = "3";
      this._ctrlRad4.UseVisualStyleBackColor = true;
      this._ctrlRad4.CheckedChanged += new System.EventHandler(this._ctrlRad1_CheckedChanged);
      // 
      // _ctrlRad5
      // 
      this._ctrlRad5.Appearance = System.Windows.Forms.Appearance.Button;
      this._ctrlRad5.Image = global::_19_6.Properties.Resources.DeleteNode_0;
      this._ctrlRad5.Location = new System.Drawing.Point(118, 12);
      this._ctrlRad5.Name = "_ctrlRad5";
      this._ctrlRad5.Size = new System.Drawing.Size(21, 19);
      this._ctrlRad5.TabIndex = 4;
      this._ctrlRad5.Tag = "4";
      this._ctrlRad5.UseVisualStyleBackColor = true;
      this._ctrlRad5.CheckedChanged += new System.EventHandler(this._ctrlRad1_CheckedChanged);
      // 
      // _ctrlRad2
      // 
      this._ctrlRad2.Appearance = System.Windows.Forms.Appearance.Button;
      this._ctrlRad2.Image = global::_19_6.Properties.Resources.AddNode;
      this._ctrlRad2.Location = new System.Drawing.Point(37, 12);
      this._ctrlRad2.Name = "_ctrlRad2";
      this._ctrlRad2.Size = new System.Drawing.Size(20, 19);
      this._ctrlRad2.TabIndex = 1;
      this._ctrlRad2.Tag = "1";
      this._ctrlRad2.UseVisualStyleBackColor = true;
      this._ctrlRad2.CheckedChanged += new System.EventHandler(this._ctrlRad1_CheckedChanged);
      // 
      // _ctrlRad1
      // 
      this._ctrlRad1.Appearance = System.Windows.Forms.Appearance.Button;
      this._ctrlRad1.Checked = true;
      this._ctrlRad1.Image = global::_19_6.Properties.Resources.MoveNode_0;
      this._ctrlRad1.Location = new System.Drawing.Point(12, 12);
      this._ctrlRad1.Name = "_ctrlRad1";
      this._ctrlRad1.Size = new System.Drawing.Size(19, 19);
      this._ctrlRad1.TabIndex = 0;
      this._ctrlRad1.TabStop = true;
      this._ctrlRad1.Tag = "0";
      this._ctrlRad1.UseVisualStyleBackColor = true;
      this._ctrlRad1.CheckedChanged += new System.EventHandler(this._ctrlRad1_CheckedChanged);
      // 
      // LoTVHelpForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(160, 37);
      this.Controls.Add(this._ctrlRad5);
      this.Controls.Add(this._ctrlRad4);
      this.Controls.Add(this._ctrlRad3);
      this.Controls.Add(this._ctrlRad2);
      this.Controls.Add(this._ctrlRad1);
      this.Name = "LoTVHelpForm";
      this.Text = "Инструменты";
      this.TopMost = true;
      this.Load += new System.EventHandler(this.LoTVHelpForm_Load);
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton _ctrlRad1;
        private System.Windows.Forms.RadioButton _ctrlRad2;
        private System.Windows.Forms.RadioButton _ctrlRad3;
        private System.Windows.Forms.RadioButton _ctrlRad4;
        private System.Windows.Forms.RadioButton _ctrlRad5;
    }
}
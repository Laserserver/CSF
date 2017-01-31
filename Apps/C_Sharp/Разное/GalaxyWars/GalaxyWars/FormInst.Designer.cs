namespace GalaxyWars
{
    partial class FormInst
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.numericTeam = new System.Windows.Forms.NumericUpDown();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.trackBarStrategy = new System.Windows.Forms.TrackBar();
            this.labelStrategy = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStrategy)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(148, 179);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(48, 179);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(75, 23);
            this.buttonNew.TabIndex = 2;
            this.buttonNew.Text = "New";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(FormMain.New);
            // 
            // numericTeam
            // 
            this.numericTeam.Location = new System.Drawing.Point(48, 23);
            this.numericTeam.Name = "numericTeam";
            this.numericTeam.Size = new System.Drawing.Size(46, 20);
            this.numericTeam.TabIndex = 3;
            this.numericTeam.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTeam.ValueChanged += new System.EventHandler(this.numericTeam_ValueChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(100, 20);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Add Civ";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // trackBarStrategy
            // 
            this.trackBarStrategy.Location = new System.Drawing.Point(48, 49);
            this.trackBarStrategy.Name = "trackBarStrategy";
            this.trackBarStrategy.Size = new System.Drawing.Size(127, 45);
            this.trackBarStrategy.SmallChange = 5;
            this.trackBarStrategy.TabIndex = 5;
            this.trackBarStrategy.TickFrequency = 5;
            this.trackBarStrategy.Scroll += new System.EventHandler(this.trackBarStrategy_Scroll);
            // 
            // labelStrategy
            // 
            this.labelStrategy.AutoSize = true;
            this.labelStrategy.Location = new System.Drawing.Point(181, 49);
            this.labelStrategy.Name = "labelStrategy";
            this.labelStrategy.Size = new System.Drawing.Size(46, 13);
            this.labelStrategy.TabIndex = 6;
            this.labelStrategy.Text = "colonise";
            // 
            // FormInst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 231);
            this.Controls.Add(this.labelStrategy);
            this.Controls.Add(this.trackBarStrategy);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.numericTeam);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.buttonStart);
            this.Name = "FormInst";
            this.Text = "Options";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.numericTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStrategy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.NumericUpDown numericTeam;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TrackBar trackBarStrategy;
        private System.Windows.Forms.Label labelStrategy;
    }
}
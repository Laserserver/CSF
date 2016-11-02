namespace Yaisp3_v._0._1
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
            this._ctrlPicBxMap = new System.Windows.Forms.PictureBox();
            this._ctrlPicBxGraph = new System.Windows.Forms.PictureBox();
            this._ctrlLblMisc1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._ctrlPicBxMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ctrlPicBxGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // _ctrlPicBxMap
            // 
            this._ctrlPicBxMap.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._ctrlPicBxMap.Location = new System.Drawing.Point(12, 25);
            this._ctrlPicBxMap.Name = "_ctrlPicBxMap";
            this._ctrlPicBxMap.Size = new System.Drawing.Size(568, 365);
            this._ctrlPicBxMap.TabIndex = 0;
            this._ctrlPicBxMap.TabStop = false;
            this._ctrlPicBxMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this._ctrlPicBxMap_MouseDown);
            this._ctrlPicBxMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this._ctrlPicBxMap_MouseMove);
            this._ctrlPicBxMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this._ctrlPicBxMap_MouseUp);
            // 
            // _ctrlPicBxGraph
            // 
            this._ctrlPicBxGraph.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._ctrlPicBxGraph.Location = new System.Drawing.Point(653, 439);
            this._ctrlPicBxGraph.Name = "_ctrlPicBxGraph";
            this._ctrlPicBxGraph.Size = new System.Drawing.Size(100, 50);
            this._ctrlPicBxGraph.TabIndex = 1;
            this._ctrlPicBxGraph.TabStop = false;
            // 
            // _ctrlLblMisc1
            // 
            this._ctrlLblMisc1.AutoSize = true;
            this._ctrlLblMisc1.Location = new System.Drawing.Point(12, 9);
            this._ctrlLblMisc1.Name = "_ctrlLblMisc1";
            this._ctrlLblMisc1.Size = new System.Drawing.Size(75, 13);
            this._ctrlLblMisc1.TabIndex = 2;
            this._ctrlLblMisc1.Text = "Карта города";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 501);
            this.Controls.Add(this._ctrlLblMisc1);
            this.Controls.Add(this._ctrlPicBxGraph);
            this.Controls.Add(this._ctrlPicBxMap);
            this.Name = "MainForm";
            this.Text = "Рекламное баннерное агентство";
            ((System.ComponentModel.ISupportInitialize)(this._ctrlPicBxMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ctrlPicBxGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _ctrlPicBxMap;
        private System.Windows.Forms.PictureBox _ctrlPicBxGraph;
        private System.Windows.Forms.Label _ctrlLblMisc1;
    }
}


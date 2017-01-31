namespace Steganography
{
    partial class FormPreview
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
            this.CtrlPicBx = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlPicBx)).BeginInit();
            this.SuspendLayout();
            // 
            // CtrlPicBx
            // 
            this.CtrlPicBx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtrlPicBx.Location = new System.Drawing.Point(0, 0);
            this.CtrlPicBx.Name = "CtrlPicBx";
            this.CtrlPicBx.Size = new System.Drawing.Size(284, 261);
            this.CtrlPicBx.TabIndex = 0;
            this.CtrlPicBx.TabStop = false;
            // 
            // FormPreview
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.CtrlPicBx);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPreview";
            this.Text = "Превью";
            ((System.ComponentModel.ISupportInitialize)(this.CtrlPicBx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox CtrlPicBx;
    }
}
namespace MyPlugin
{
    partial class MyPlugForm
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
            this.Info = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Info
            // 
            this.Info.Location = new System.Drawing.Point(0, -2);
            this.Info.Multiline = true;
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(256, 231);
            this.Info.TabIndex = 0;
            // 
            // MyPlugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(244, 207);
            this.Controls.Add(this.Info);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyPlugForm";
            this.Text = "MyPlugForm";
            this.Load += new System.EventHandler(this.MyPlugForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Info;
    }
}
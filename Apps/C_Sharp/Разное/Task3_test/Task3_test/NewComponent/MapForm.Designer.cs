namespace Task3_test.NewComponent
{
    partial class MapForm
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
            this.components = new System.ComponentModel.Container();
            this.coordinate = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // coordinate
            // 
            this.coordinate.AutoSize = true;
            this.coordinate.BackColor = System.Drawing.Color.Transparent;
            this.coordinate.Location = new System.Drawing.Point(253, 42);
            this.coordinate.Name = "coordinate";
            this.coordinate.Size = new System.Drawing.Size(0, 13);
            this.coordinate.TabIndex = 0;
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.Color.NavajoWhite;
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Task3_test.Properties.Resources.travel_map;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.coordinate);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MapForm";
            this.Text = "MapForm";
            this.Load += new System.EventHandler(this.MapForm_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapForm_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MapForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label coordinate;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
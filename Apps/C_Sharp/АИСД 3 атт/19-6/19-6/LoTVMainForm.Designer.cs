namespace _19_6
{
    partial class LoTVMainForm
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
      this._ctrlMenu = new System.Windows.Forms.MenuStrip();
      this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.построитьОстовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this._ctrlPanel = new System.Windows.Forms.Panel();
      this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this._ctrlMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // _ctrlMenu
      // 
      this._ctrlMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.помощьToolStripMenuItem,
            this.построитьОстовToolStripMenuItem,
            this.clearToolStripMenuItem});
      this._ctrlMenu.Location = new System.Drawing.Point(0, 0);
      this._ctrlMenu.Name = "_ctrlMenu";
      this._ctrlMenu.Size = new System.Drawing.Size(1177, 24);
      this._ctrlMenu.TabIndex = 2;
      this._ctrlMenu.Text = "menuStrip1";
      // 
      // файлToolStripMenuItem
      // 
      this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
      this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
      this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
      this.файлToolStripMenuItem.Text = "Файл";
      // 
      // newToolStripMenuItem
      // 
      this.newToolStripMenuItem.Name = "newToolStripMenuItem";
      this.newToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
      this.newToolStripMenuItem.Text = "New";
      this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
      // 
      // loadToolStripMenuItem
      // 
      this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
      this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
      this.loadToolStripMenuItem.Text = "Load";
      this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
      this.saveToolStripMenuItem.Text = "Save";
      this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
      // 
      // помощьToolStripMenuItem
      // 
      this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
      this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
      this.помощьToolStripMenuItem.Text = "Помощь";
      this.помощьToolStripMenuItem.Click += new System.EventHandler(this.помощьToolStripMenuItem_Click);
      // 
      // построитьОстовToolStripMenuItem
      // 
      this.построитьОстовToolStripMenuItem.Name = "построитьОстовToolStripMenuItem";
      this.построитьОстовToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
      this.построитьОстовToolStripMenuItem.Text = "Построить остов";
      this.построитьОстовToolStripMenuItem.Click += new System.EventHandler(this.построитьОстовToolStripMenuItem_Click);
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // _ctrlPanel
      // 
      this._ctrlPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this._ctrlPanel.BackColor = System.Drawing.SystemColors.Window;
      this._ctrlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this._ctrlPanel.Location = new System.Drawing.Point(0, 24);
      this._ctrlPanel.Name = "_ctrlPanel";
      this._ctrlPanel.Size = new System.Drawing.Size(1177, 613);
      this._ctrlPanel.TabIndex = 1;
      this._ctrlPanel.Paint += new System.Windows.Forms.PaintEventHandler(this._ctrlPanel_Paint);
      this._ctrlPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this._ctrlPanel_MouseDown);
      this._ctrlPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this._ctrlPanel_MouseMove);
      this._ctrlPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this._ctrlPanel_MouseUp);
      // 
      // clearToolStripMenuItem
      // 
      this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
      this.clearToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
      this.clearToolStripMenuItem.Text = "Вернуть цвета";
      this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
      // 
      // LoTVMainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1177, 637);
      this.Controls.Add(this._ctrlPanel);
      this.Controls.Add(this._ctrlMenu);
      this.MainMenuStrip = this._ctrlMenu;
      this.Name = "LoTVMainForm";
      this.Text = "19-6";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.Load += new System.EventHandler(this.LoTVMainForm_Load);
      this.Resize += new System.EventHandler(this.LoTVMainForm_Resize);
      this._ctrlMenu.ResumeLayout(false);
      this._ctrlMenu.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip _ctrlMenu;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.ToolStripMenuItem построитьОстовToolStripMenuItem;
    private System.Windows.Forms.Panel _ctrlPanel;
    private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
  }
}


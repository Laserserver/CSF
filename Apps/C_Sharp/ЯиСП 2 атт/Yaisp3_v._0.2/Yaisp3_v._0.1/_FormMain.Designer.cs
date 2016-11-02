namespace Yaisp3_v._0._1
{
    partial class _FormMain
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
      this._ctrlLblMisc2 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this._ctrlMainStrip = new System.Windows.Forms.ToolStrip();
      this._ctrlTSMIDrop = new System.Windows.Forms.ToolStripDropDownButton();
      this._ctrlTSMICreateCity = new System.Windows.Forms.ToolStripMenuItem();
      this._ctrlTSMIAgencyMenu = new System.Windows.Forms.ToolStripMenuItem();
      this._ctrlTSMIAgencyDelete = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlPicBxMap)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlPicBxGraph)).BeginInit();
      this._ctrlMainStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // _ctrlPicBxMap
      // 
      this._ctrlPicBxMap.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this._ctrlPicBxMap.Location = new System.Drawing.Point(12, 76);
      this._ctrlPicBxMap.Name = "_ctrlPicBxMap";
      this._ctrlPicBxMap.Size = new System.Drawing.Size(635, 464);
      this._ctrlPicBxMap.TabIndex = 0;
      this._ctrlPicBxMap.TabStop = false;
      this._ctrlPicBxMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartMouseDrawing);
      this._ctrlPicBxMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMovingEvent);
      this._ctrlPicBxMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StopMouseDrawing);
      // 
      // _ctrlPicBxGraph
      // 
      this._ctrlPicBxGraph.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this._ctrlPicBxGraph.Location = new System.Drawing.Point(678, 490);
      this._ctrlPicBxGraph.Name = "_ctrlPicBxGraph";
      this._ctrlPicBxGraph.Size = new System.Drawing.Size(100, 50);
      this._ctrlPicBxGraph.TabIndex = 1;
      this._ctrlPicBxGraph.TabStop = false;
      // 
      // _ctrlLblMisc1
      // 
      this._ctrlLblMisc1.AutoSize = true;
      this._ctrlLblMisc1.Location = new System.Drawing.Point(12, 50);
      this._ctrlLblMisc1.Name = "_ctrlLblMisc1";
      this._ctrlLblMisc1.Size = new System.Drawing.Size(75, 13);
      this._ctrlLblMisc1.TabIndex = 2;
      this._ctrlLblMisc1.Text = "Карта города";
      // 
      // _ctrlLblMisc2
      // 
      this._ctrlLblMisc2.AutoSize = true;
      this._ctrlLblMisc2.Location = new System.Drawing.Point(9, 561);
      this._ctrlLblMisc2.Name = "_ctrlLblMisc2";
      this._ctrlLblMisc2.Size = new System.Drawing.Size(35, 13);
      this._ctrlLblMisc2.TabIndex = 3;
      this._ctrlLblMisc2.Text = "label1";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(663, 240);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 4;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(818, 270);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(100, 20);
      this.textBox1.TabIndex = 5;
      // 
      // _ctrlMainStrip
      // 
      this._ctrlMainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ctrlTSMIDrop});
      this._ctrlMainStrip.Location = new System.Drawing.Point(0, 0);
      this._ctrlMainStrip.Name = "_ctrlMainStrip";
      this._ctrlMainStrip.Size = new System.Drawing.Size(1222, 25);
      this._ctrlMainStrip.TabIndex = 6;
      this._ctrlMainStrip.Text = "toolStrip1";
      // 
      // _ctrlTSMIDrop
      // 
      this._ctrlTSMIDrop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this._ctrlTSMIDrop.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ctrlTSMICreateCity,
            this._ctrlTSMIAgencyMenu,
            this._ctrlTSMIAgencyDelete});
      this._ctrlTSMIDrop.Name = "_ctrlTSMIDrop";
      this._ctrlTSMIDrop.Size = new System.Drawing.Size(54, 22);
      this._ctrlTSMIDrop.Text = "Меню";
      this._ctrlTSMIDrop.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
      // 
      // _ctrlTSMICreateCity
      // 
      this._ctrlTSMICreateCity.Name = "_ctrlTSMICreateCity";
      this._ctrlTSMICreateCity.Size = new System.Drawing.Size(174, 22);
      this._ctrlTSMICreateCity.Text = "Создать город";
      this._ctrlTSMICreateCity.Click += new System.EventHandler(this._ctrlTSMICreateCity_Click);
      // 
      // _ctrlTSMIAgencyMenu
      // 
      this._ctrlTSMIAgencyMenu.Name = "_ctrlTSMIAgencyMenu";
      this._ctrlTSMIAgencyMenu.Size = new System.Drawing.Size(174, 22);
      this._ctrlTSMIAgencyMenu.Text = "Меню агентства";
      this._ctrlTSMIAgencyMenu.Click += new System.EventHandler(this._ctrlTSMIAgencyMenu_Click);
      // 
      // _ctrlTSMIAgencyDelete
      // 
      this._ctrlTSMIAgencyDelete.Name = "_ctrlTSMIAgencyDelete";
      this._ctrlTSMIAgencyDelete.Size = new System.Drawing.Size(174, 22);
      this._ctrlTSMIAgencyDelete.Text = "Удалить агентство";
      this._ctrlTSMIAgencyDelete.Click += new System.EventHandler(this._ctrlTSMIAgencyDelete_Click);
      // 
      // _FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1222, 646);
      this.Controls.Add(this._ctrlMainStrip);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.button1);
      this.Controls.Add(this._ctrlLblMisc2);
      this.Controls.Add(this._ctrlLblMisc1);
      this.Controls.Add(this._ctrlPicBxGraph);
      this.Controls.Add(this._ctrlPicBxMap);
      this.Name = "_FormMain";
      this.Text = "Рекламное баннерное агентство";
      ((System.ComponentModel.ISupportInitialize)(this._ctrlPicBxMap)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlPicBxGraph)).EndInit();
      this._ctrlMainStrip.ResumeLayout(false);
      this._ctrlMainStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _ctrlPicBxMap;
        private System.Windows.Forms.PictureBox _ctrlPicBxGraph;
        private System.Windows.Forms.Label _ctrlLblMisc1;
    private System.Windows.Forms.Label _ctrlLblMisc2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.ToolStrip _ctrlMainStrip;
    private System.Windows.Forms.ToolStripDropDownButton _ctrlTSMIDrop;
    private System.Windows.Forms.ToolStripMenuItem _ctrlTSMIAgencyMenu;
    private System.Windows.Forms.ToolStripMenuItem _ctrlTSMIAgencyDelete;
    private System.Windows.Forms.ToolStripMenuItem _ctrlTSMICreateCity;
  }
}


namespace _18_21
{
    partial class HoTS
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
      this._ctrlLblTask = new System.Windows.Forms.Label();
      this._ctrlBaton = new System.Windows.Forms.Button();
      this._ctrlPanel = new System.Windows.Forms.Panel();
      this._ctrlNumsVis = new System.Windows.Forms.TextBox();
      this._ctrlBatonRand = new System.Windows.Forms.Button();
      this._ctrlTxbNumR = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // _ctrlLblTask
      // 
      this._ctrlLblTask.Location = new System.Drawing.Point(12, 9);
      this._ctrlLblTask.Name = "_ctrlLblTask";
      this._ctrlLblTask.Size = new System.Drawing.Size(478, 35);
      this._ctrlLblTask.TabIndex = 0;
      this._ctrlLblTask.Text = "18. Описать логическую функцию, определяющую, есть ли в заданном двоичном дереве " +
    "хотя бы два одинаковых элемента.";
      // 
      // _ctrlBaton
      // 
      this._ctrlBaton.Location = new System.Drawing.Point(12, 48);
      this._ctrlBaton.Name = "_ctrlBaton";
      this._ctrlBaton.Size = new System.Drawing.Size(75, 23);
      this._ctrlBaton.TabIndex = 1;
      this._ctrlBaton.Text = "Батон";
      this._ctrlBaton.UseVisualStyleBackColor = true;
      this._ctrlBaton.Click += new System.EventHandler(this._ctrlBaton_Click);
      // 
      // _ctrlPanel
      // 
      this._ctrlPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this._ctrlPanel.Location = new System.Drawing.Point(12, 87);
      this._ctrlPanel.Name = "_ctrlPanel";
      this._ctrlPanel.Size = new System.Drawing.Size(429, 365);
      this._ctrlPanel.TabIndex = 3;
      this._ctrlPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this._ctrlPanel_MouseDown);
      this._ctrlPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this._ctrlPanel_MouseMove);
      this._ctrlPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this._ctrlPanel_MouseUp);
      // 
      // _ctrlNumsVis
      // 
      this._ctrlNumsVis.Location = new System.Drawing.Point(455, 47);
      this._ctrlNumsVis.Multiline = true;
      this._ctrlNumsVis.Name = "_ctrlNumsVis";
      this._ctrlNumsVis.Size = new System.Drawing.Size(35, 405);
      this._ctrlNumsVis.TabIndex = 4;
      // 
      // _ctrlBatonRand
      // 
      this._ctrlBatonRand.Location = new System.Drawing.Point(239, 48);
      this._ctrlBatonRand.Name = "_ctrlBatonRand";
      this._ctrlBatonRand.Size = new System.Drawing.Size(75, 23);
      this._ctrlBatonRand.TabIndex = 5;
      this._ctrlBatonRand.Text = "Собрать";
      this._ctrlBatonRand.UseVisualStyleBackColor = true;
      this._ctrlBatonRand.Click += new System.EventHandler(this._ctrlBatonRand_Click);
      // 
      // _ctrlTxbNumR
      // 
      this._ctrlTxbNumR.Location = new System.Drawing.Point(320, 50);
      this._ctrlTxbNumR.Name = "_ctrlTxbNumR";
      this._ctrlTxbNumR.Size = new System.Drawing.Size(69, 20);
      this._ctrlTxbNumR.TabIndex = 6;
      // 
      // HoTS
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(502, 465);
      this.Controls.Add(this._ctrlTxbNumR);
      this.Controls.Add(this._ctrlBatonRand);
      this.Controls.Add(this._ctrlNumsVis);
      this.Controls.Add(this._ctrlPanel);
      this.Controls.Add(this._ctrlBaton);
      this.Controls.Add(this._ctrlLblTask);
      this.Name = "HoTS";
      this.Text = "18-18";
      this.Load += new System.EventHandler(this.HoTS_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _ctrlLblTask;
        private System.Windows.Forms.Button _ctrlBaton;
        private System.Windows.Forms.Panel _ctrlPanel;
        private System.Windows.Forms.TextBox _ctrlNumsVis;
        private System.Windows.Forms.Button _ctrlBatonRand;
        private System.Windows.Forms.TextBox _ctrlTxbNumR;
    }
}


namespace _15_30
{
    partial class LoTVForm
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
      this._ctrlTxB = new System.Windows.Forms.TextBox();
      this._ctrlBaton = new System.Windows.Forms.Button();
      this._ctrlLbl = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // _ctrlTxB
      // 
      this._ctrlTxB.Location = new System.Drawing.Point(12, 50);
      this._ctrlTxB.Name = "_ctrlTxB";
      this._ctrlTxB.Size = new System.Drawing.Size(239, 20);
      this._ctrlTxB.TabIndex = 0;
      this._ctrlTxB.Text = "6 8 + 2 / 11 +";
      // 
      // _ctrlBaton
      // 
      this._ctrlBaton.Location = new System.Drawing.Point(12, 12);
      this._ctrlBaton.Name = "_ctrlBaton";
      this._ctrlBaton.Size = new System.Drawing.Size(75, 23);
      this._ctrlBaton.TabIndex = 1;
      this._ctrlBaton.Text = "Батон";
      this._ctrlBaton.UseVisualStyleBackColor = true;
      this._ctrlBaton.Click += new System.EventHandler(this._ctrlBaton_Click);
      // 
      // _ctrlLbl
      // 
      this._ctrlLbl.Location = new System.Drawing.Point(93, 14);
      this._ctrlLbl.Name = "_ctrlLbl";
      this._ctrlLbl.Size = new System.Drawing.Size(158, 21);
      this._ctrlLbl.TabIndex = 2;
      this._ctrlLbl.Text = "Ответ: ";
      // 
      // LoTVForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(260, 80);
      this.Controls.Add(this._ctrlLbl);
      this.Controls.Add(this._ctrlBaton);
      this.Controls.Add(this._ctrlTxB);
      this.Name = "LoTVForm";
      this.Text = "15-30";
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _ctrlTxB;
        private System.Windows.Forms.Button _ctrlBaton;
        private System.Windows.Forms.Label _ctrlLbl;
    }
}


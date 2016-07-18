namespace _17_6
{
    partial class WoL
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
      this._ctrlBaton = new System.Windows.Forms.Button();
      this._ctrlTxb = new System.Windows.Forms.TextBox();
      this._ctrlPanel = new System.Windows.Forms.Panel();
      this._ctrlLblTask = new System.Windows.Forms.Label();
      this._ctrlLblAns = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // _ctrlBaton
      // 
      this._ctrlBaton.Location = new System.Drawing.Point(227, 57);
      this._ctrlBaton.Name = "_ctrlBaton";
      this._ctrlBaton.Size = new System.Drawing.Size(92, 23);
      this._ctrlBaton.TabIndex = 0;
      this._ctrlBaton.Text = "Go impulse 101";
      this._ctrlBaton.UseVisualStyleBackColor = true;
      this._ctrlBaton.Click += new System.EventHandler(this._ctrlBaton_Click);
      // 
      // _ctrlTxb
      // 
      this._ctrlTxb.Location = new System.Drawing.Point(12, 59);
      this._ctrlTxb.Name = "_ctrlTxb";
      this._ctrlTxb.Size = new System.Drawing.Size(189, 20);
      this._ctrlTxb.TabIndex = 1;
      this._ctrlTxb.Text = "T & (T | F) & T &(T | (T | F))";
      // 
      // _ctrlPanel
      // 
      this._ctrlPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this._ctrlPanel.Location = new System.Drawing.Point(12, 97);
      this._ctrlPanel.Name = "_ctrlPanel";
      this._ctrlPanel.Size = new System.Drawing.Size(520, 374);
      this._ctrlPanel.TabIndex = 2;
      this._ctrlPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this._ctrlPanel_MouseDown);
      this._ctrlPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this._ctrlPanel_MouseMove);
      this._ctrlPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this._ctrlPanel_MouseUp);
      // 
      // _ctrlLblTask
      // 
      this._ctrlLblTask.Location = new System.Drawing.Point(12, 9);
      this._ctrlLblTask.Name = "_ctrlLblTask";
      this._ctrlLblTask.Size = new System.Drawing.Size(520, 47);
      this._ctrlLblTask.TabIndex = 3;
      this._ctrlLblTask.Text = "6. Вывести значение логического выражения, заданного в виде строки S. Выражение о" +
    "пределяется следующим образом \n(\"T\" — True, \"F\" — False): <выражение>  ::= T | F" +
    " | And (<операнды>) | Or (<операнды>)";
      // 
      // _ctrlLblAns
      // 
      this._ctrlLblAns.AutoSize = true;
      this._ctrlLblAns.Location = new System.Drawing.Point(348, 62);
      this._ctrlLblAns.Name = "_ctrlLblAns";
      this._ctrlLblAns.Size = new System.Drawing.Size(69, 13);
      this._ctrlLblAns.TabIndex = 4;
      this._ctrlLblAns.Text = "Здесь ответ";
      // 
      // WoL
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(544, 485);
      this.Controls.Add(this._ctrlLblAns);
      this.Controls.Add(this._ctrlLblTask);
      this.Controls.Add(this._ctrlPanel);
      this.Controls.Add(this._ctrlTxb);
      this.Controls.Add(this._ctrlBaton);
      this.Name = "WoL";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.WoL_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _ctrlBaton;
        private System.Windows.Forms.TextBox _ctrlTxb;
        private System.Windows.Forms.Panel _ctrlPanel;
        private System.Windows.Forms.Label _ctrlLblTask;
        private System.Windows.Forms.Label _ctrlLblAns;
    }
}


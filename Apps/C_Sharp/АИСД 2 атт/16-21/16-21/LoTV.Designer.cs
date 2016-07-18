namespace _16_21
{
    partial class LoTV
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
      this._ctrlBaton = new System.Windows.Forms.Button();
      this._ctrlLblTask = new System.Windows.Forms.Label();
      this._ctrlRadBatonLog3 = new System.Windows.Forms.RadioButton();
      this._ctrlRadBatonLog2 = new System.Windows.Forms.RadioButton();
      this._ctrlRadBatonFibo = new System.Windows.Forms.RadioButton();
      this._ctrlTimer = new System.Windows.Forms.Timer(this.components);
      this._ctrlPanel = new System.Windows.Forms.Panel();
      this._ctrlFill = new System.Windows.Forms.Button();
      this._ctrlTxb = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // _ctrlBaton
      // 
      this._ctrlBaton.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this._ctrlBaton.Location = new System.Drawing.Point(424, 180);
      this._ctrlBaton.Name = "_ctrlBaton";
      this._ctrlBaton.Size = new System.Drawing.Size(204, 119);
      this._ctrlBaton.TabIndex = 1;
      this._ctrlBaton.Text = "Батон";
      this._ctrlBaton.UseVisualStyleBackColor = true;
      this._ctrlBaton.Click += new System.EventHandler(this._ctrlBaton_Click);
      // 
      // _ctrlLblTask
      // 
      this._ctrlLblTask.Location = new System.Drawing.Point(422, 0);
      this._ctrlLblTask.Name = "_ctrlLblTask";
      this._ctrlLblTask.Size = new System.Drawing.Size(207, 53);
      this._ctrlLblTask.TabIndex = 2;
      this._ctrlLblTask.Text = "21. Написать программу, которая иллюстрирует работу метода Шелла с одной из форму" +
    "л вычисления шага сортировки:";
      // 
      // _ctrlRadBatonLog3
      // 
      this._ctrlRadBatonLog3.AutoSize = true;
      this._ctrlRadBatonLog3.Checked = true;
      this._ctrlRadBatonLog3.Location = new System.Drawing.Point(424, 56);
      this._ctrlRadBatonLog3.Name = "_ctrlRadBatonLog3";
      this._ctrlRadBatonLog3.Size = new System.Drawing.Size(205, 17);
      this._ctrlRadBatonLog3.TabIndex = 3;
      this._ctrlRadBatonLog3.TabStop = true;
      this._ctrlRadBatonLog3.Text = "h[k–1] = 3h[k] + 1, h[t]=1, t = [log3n]–1";
      this._ctrlRadBatonLog3.UseVisualStyleBackColor = true;
      // 
      // _ctrlRadBatonLog2
      // 
      this._ctrlRadBatonLog2.AutoSize = true;
      this._ctrlRadBatonLog2.Location = new System.Drawing.Point(424, 79);
      this._ctrlRadBatonLog2.Name = "_ctrlRadBatonLog2";
      this._ctrlRadBatonLog2.Size = new System.Drawing.Size(205, 17);
      this._ctrlRadBatonLog2.TabIndex = 4;
      this._ctrlRadBatonLog2.Text = "h[k–1] = 2h[k] + 1, h[t]=1, t = [log2n]–1";
      this._ctrlRadBatonLog2.UseVisualStyleBackColor = true;
      // 
      // _ctrlRadBatonFibo
      // 
      this._ctrlRadBatonFibo.AutoSize = true;
      this._ctrlRadBatonFibo.Location = new System.Drawing.Point(424, 102);
      this._ctrlRadBatonFibo.Name = "_ctrlRadBatonFibo";
      this._ctrlRadBatonFibo.Size = new System.Drawing.Size(117, 17);
      this._ctrlRadBatonFibo.TabIndex = 5;
      this._ctrlRadBatonFibo.Text = "Числа Фибоначчи";
      this._ctrlRadBatonFibo.UseVisualStyleBackColor = true;
      // 
      // _ctrlPanel
      // 
      this._ctrlPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this._ctrlPanel.Location = new System.Drawing.Point(0, 0);
      this._ctrlPanel.Name = "_ctrlPanel";
      this._ctrlPanel.Size = new System.Drawing.Size(410, 670);
      this._ctrlPanel.TabIndex = 6;
      // 
      // _ctrlFill
      // 
      this._ctrlFill.Location = new System.Drawing.Point(424, 125);
      this._ctrlFill.Name = "_ctrlFill";
      this._ctrlFill.Size = new System.Drawing.Size(201, 23);
      this._ctrlFill.TabIndex = 7;
      this._ctrlFill.Text = "Заполнить массив";
      this._ctrlFill.UseVisualStyleBackColor = true;
      this._ctrlFill.Click += new System.EventHandler(this._ctrlFill_Click);
      // 
      // _ctrlTxb
      // 
      this._ctrlTxb.Location = new System.Drawing.Point(424, 154);
      this._ctrlTxb.Name = "_ctrlTxb";
      this._ctrlTxb.Size = new System.Drawing.Size(83, 20);
      this._ctrlTxb.TabIndex = 8;
      this._ctrlTxb.Text = "200";
      // 
      // LoTV
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(634, 670);
      this.Controls.Add(this._ctrlTxb);
      this.Controls.Add(this._ctrlFill);
      this.Controls.Add(this._ctrlPanel);
      this.Controls.Add(this._ctrlRadBatonFibo);
      this.Controls.Add(this._ctrlRadBatonLog2);
      this.Controls.Add(this._ctrlRadBatonLog3);
      this.Controls.Add(this._ctrlLblTask);
      this.Controls.Add(this._ctrlBaton);
      this.Name = "LoTV";
      this.Text = "16-21";
      this.Load += new System.EventHandler(this.LoTV_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _ctrlBaton;
        private System.Windows.Forms.Label _ctrlLblTask;
        private System.Windows.Forms.RadioButton _ctrlRadBatonLog3;
        private System.Windows.Forms.RadioButton _ctrlRadBatonLog2;
        private System.Windows.Forms.RadioButton _ctrlRadBatonFibo;
        private System.Windows.Forms.Timer _ctrlTimer;
        private System.Windows.Forms.Panel _ctrlPanel;
    private System.Windows.Forms.Button _ctrlFill;
    private System.Windows.Forms.TextBox _ctrlTxb;
  }
}


namespace WinFormForTests
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.CtrlPanel = new System.Windows.Forms.Panel();
            this.CtrlLbl = new System.Windows.Forms.Label();
            this.CtrlButStart = new System.Windows.Forms.Button();
            this.CtrlLb = new System.Windows.Forms.ListBox();
            this.CtrlWeb = new System.Windows.Forms.WebBrowser();
            this.CtrlGrB = new System.Windows.Forms.GroupBox();
            this.CtrlRb1 = new System.Windows.Forms.RadioButton();
            this.CtrlRb2 = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CtrlGrB.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtrlPanel
            // 
            this.CtrlPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CtrlPanel.Location = new System.Drawing.Point(493, 12);
            this.CtrlPanel.Name = "CtrlPanel";
            this.CtrlPanel.Size = new System.Drawing.Size(175, 41);
            this.CtrlPanel.TabIndex = 0;
            // 
            // CtrlLbl
            // 
            this.CtrlLbl.Location = new System.Drawing.Point(328, 70);
            this.CtrlLbl.Name = "CtrlLbl";
            this.CtrlLbl.Size = new System.Drawing.Size(112, 41);
            this.CtrlLbl.TabIndex = 1;
            this.CtrlLbl.Text = "Купи дилдо и получи второй в подарок";
            // 
            // CtrlButStart
            // 
            this.CtrlButStart.Location = new System.Drawing.Point(512, 426);
            this.CtrlButStart.Name = "CtrlButStart";
            this.CtrlButStart.Size = new System.Drawing.Size(156, 23);
            this.CtrlButStart.TabIndex = 3;
            this.CtrlButStart.Text = "Запустить";
            this.CtrlButStart.UseVisualStyleBackColor = true;
            this.CtrlButStart.Click += new System.EventHandler(this.CtrlButStart_Click);
            // 
            // CtrlLb
            // 
            this.CtrlLb.FormattingEnabled = true;
            this.CtrlLb.Location = new System.Drawing.Point(12, 146);
            this.CtrlLb.Name = "CtrlLb";
            this.CtrlLb.Size = new System.Drawing.Size(131, 303);
            this.CtrlLb.TabIndex = 4;
            // 
            // CtrlWeb
            // 
            this.CtrlWeb.Location = new System.Drawing.Point(170, 114);
            this.CtrlWeb.MinimumSize = new System.Drawing.Size(20, 20);
            this.CtrlWeb.Name = "CtrlWeb";
            this.CtrlWeb.Size = new System.Drawing.Size(336, 335);
            this.CtrlWeb.TabIndex = 5;
            // 
            // CtrlGrB
            // 
            this.CtrlGrB.Controls.Add(this.CtrlRb2);
            this.CtrlGrB.Controls.Add(this.CtrlRb1);
            this.CtrlGrB.Location = new System.Drawing.Point(512, 219);
            this.CtrlGrB.Name = "CtrlGrB";
            this.CtrlGrB.Size = new System.Drawing.Size(156, 201);
            this.CtrlGrB.TabIndex = 6;
            this.CtrlGrB.TabStop = false;
            this.CtrlGrB.Text = "Настройки";
            // 
            // CtrlRb1
            // 
            this.CtrlRb1.AutoSize = true;
            this.CtrlRb1.Location = new System.Drawing.Point(6, 19);
            this.CtrlRb1.Name = "CtrlRb1";
            this.CtrlRb1.Size = new System.Drawing.Size(83, 17);
            this.CtrlRb1.TabIndex = 0;
            this.CtrlRb1.TabStop = true;
            this.CtrlRb1.Text = "Фуллскрин";
            this.CtrlRb1.UseVisualStyleBackColor = true;
            // 
            // CtrlRb2
            // 
            this.CtrlRb2.AutoSize = true;
            this.CtrlRb2.Location = new System.Drawing.Point(6, 42);
            this.CtrlRb2.Name = "CtrlRb2";
            this.CtrlRb2.Size = new System.Drawing.Size(59, 17);
            this.CtrlRb2.TabIndex = 1;
            this.CtrlRb2.TabStop = true;
            this.CtrlRb2.Text = "В окне";
            this.CtrlRb2.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(26, 21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(275, 45);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(267, 19);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(0, 0);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 461);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.CtrlGrB);
            this.Controls.Add(this.CtrlWeb);
            this.Controls.Add(this.CtrlLbl);
            this.Controls.Add(this.CtrlLb);
            this.Controls.Add(this.CtrlButStart);
            this.Controls.Add(this.CtrlPanel);
            this.Name = "Form1";
            this.Text = "Говноклиент_нейм";
            this.CtrlGrB.ResumeLayout(false);
            this.CtrlGrB.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CtrlPanel;
        private System.Windows.Forms.Label CtrlLbl;
        private System.Windows.Forms.Button CtrlButStart;
        private System.Windows.Forms.ListBox CtrlLb;
        private System.Windows.Forms.WebBrowser CtrlWeb;
        private System.Windows.Forms.GroupBox CtrlGrB;
        private System.Windows.Forms.RadioButton CtrlRb2;
        private System.Windows.Forms.RadioButton CtrlRb1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}


namespace COMports
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.CtrlLBPorts = new System.Windows.Forms.ListBox();
            this.CtrlButReset = new System.Windows.Forms.Button();
            this.CtrlRTB = new System.Windows.Forms.RichTextBox();
            this.CtrlSP = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // CtrlLBPorts
            // 
            this.CtrlLBPorts.FormattingEnabled = true;
            this.CtrlLBPorts.Location = new System.Drawing.Point(12, 12);
            this.CtrlLBPorts.Name = "CtrlLBPorts";
            this.CtrlLBPorts.Size = new System.Drawing.Size(120, 95);
            this.CtrlLBPorts.TabIndex = 0;
            this.CtrlLBPorts.SelectedIndexChanged += new System.EventHandler(this.CtrlLBPorts_SelectedIndexChanged);
            // 
            // CtrlButReset
            // 
            this.CtrlButReset.Location = new System.Drawing.Point(138, 12);
            this.CtrlButReset.Name = "CtrlButReset";
            this.CtrlButReset.Size = new System.Drawing.Size(75, 23);
            this.CtrlButReset.TabIndex = 1;
            this.CtrlButReset.Text = "Обновить";
            this.CtrlButReset.UseVisualStyleBackColor = true;
            this.CtrlButReset.Click += new System.EventHandler(this.CtrlButReset_Click);
            // 
            // CtrlRTB
            // 
            this.CtrlRTB.Location = new System.Drawing.Point(290, 11);
            this.CtrlRTB.Name = "CtrlRTB";
            this.CtrlRTB.Size = new System.Drawing.Size(317, 249);
            this.CtrlRTB.TabIndex = 2;
            this.CtrlRTB.Text = "";
            // 
            // CtrlSP
            // 
            this.CtrlSP.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.CtrlSP_DataReceived);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 434);
            this.Controls.Add(this.CtrlRTB);
            this.Controls.Add(this.CtrlButReset);
            this.Controls.Add(this.CtrlLBPorts);
            this.Name = "FormMain";
            this.Text = "Порты";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox CtrlLBPorts;
        private System.Windows.Forms.Button CtrlButReset;
        private System.Windows.Forms.RichTextBox CtrlRTB;
        private System.IO.Ports.SerialPort CtrlSP;
    }
}


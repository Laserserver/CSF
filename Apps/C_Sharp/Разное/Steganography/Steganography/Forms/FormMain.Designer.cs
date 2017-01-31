namespace Steganography
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.CtrlTS = new System.Windows.Forms.ToolStrip();
            this.CtrlTSButtonShow = new System.Windows.Forms.ToolStripButton();
            this.CtrlTSButReady = new System.Windows.Forms.ToolStripButton();
            this.CtrlOFD = new System.Windows.Forms.OpenFileDialog();
            this.CtrlButLoad = new System.Windows.Forms.Button();
            this.CtrlLblSize = new System.Windows.Forms.Label();
            this.CtrlLblString = new System.Windows.Forms.Label();
            this.CtrlButTest = new System.Windows.Forms.Button();
            this.CtrlTxb = new System.Windows.Forms.TextBox();
            this.CtrlTxbOut = new System.Windows.Forms.TextBox();
            this.CtrlButDecode = new System.Windows.Forms.Button();
            this.CtrlTS.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtrlTS
            // 
            this.CtrlTS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtrlTSButtonShow,
            this.CtrlTSButReady});
            this.CtrlTS.Location = new System.Drawing.Point(0, 0);
            this.CtrlTS.Name = "CtrlTS";
            this.CtrlTS.Size = new System.Drawing.Size(577, 25);
            this.CtrlTS.TabIndex = 0;
            this.CtrlTS.Text = "toolStrip1";
            // 
            // CtrlTSButtonShow
            // 
            this.CtrlTSButtonShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CtrlTSButtonShow.Image = ((System.Drawing.Image)(resources.GetObject("CtrlTSButtonShow.Image")));
            this.CtrlTSButtonShow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CtrlTSButtonShow.Name = "CtrlTSButtonShow";
            this.CtrlTSButtonShow.Size = new System.Drawing.Size(23, 22);
            this.CtrlTSButtonShow.Text = "Превью";
            this.CtrlTSButtonShow.Click += new System.EventHandler(this.CtrlTSButtonShow_Click);
            // 
            // CtrlTSButReady
            // 
            this.CtrlTSButReady.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CtrlTSButReady.Image = ((System.Drawing.Image)(resources.GetObject("CtrlTSButReady.Image")));
            this.CtrlTSButReady.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CtrlTSButReady.Name = "CtrlTSButReady";
            this.CtrlTSButReady.Size = new System.Drawing.Size(23, 22);
            this.CtrlTSButReady.Text = "Готовое изображение";
            this.CtrlTSButReady.Click += new System.EventHandler(this.CtrlTSButReady_Click);
            // 
            // CtrlOFD
            // 
            this.CtrlOFD.FileName = "openFileDialog1";
            // 
            // CtrlButLoad
            // 
            this.CtrlButLoad.Location = new System.Drawing.Point(12, 37);
            this.CtrlButLoad.Name = "CtrlButLoad";
            this.CtrlButLoad.Size = new System.Drawing.Size(119, 29);
            this.CtrlButLoad.TabIndex = 1;
            this.CtrlButLoad.Text = "Загрузить";
            this.CtrlButLoad.UseVisualStyleBackColor = true;
            this.CtrlButLoad.Click += new System.EventHandler(this.CtrlButLoad_Click);
            // 
            // CtrlLblSize
            // 
            this.CtrlLblSize.AutoSize = true;
            this.CtrlLblSize.Location = new System.Drawing.Point(12, 78);
            this.CtrlLblSize.Name = "CtrlLblSize";
            this.CtrlLblSize.Size = new System.Drawing.Size(159, 13);
            this.CtrlLblSize.TabIndex = 2;
            this.CtrlLblSize.Text = "Допустимый размер данных: ";
            // 
            // CtrlLblString
            // 
            this.CtrlLblString.AutoSize = true;
            this.CtrlLblString.Location = new System.Drawing.Point(248, 78);
            this.CtrlLblString.Name = "CtrlLblString";
            this.CtrlLblString.Size = new System.Drawing.Size(88, 13);
            this.CtrlLblString.TabIndex = 3;
            this.CtrlLblString.Text = "Строка длиной: ";
            // 
            // CtrlButTest
            // 
            this.CtrlButTest.Location = new System.Drawing.Point(15, 125);
            this.CtrlButTest.Name = "CtrlButTest";
            this.CtrlButTest.Size = new System.Drawing.Size(119, 29);
            this.CtrlButTest.TabIndex = 4;
            this.CtrlButTest.Text = "Test encode";
            this.CtrlButTest.UseVisualStyleBackColor = true;
            this.CtrlButTest.Click += new System.EventHandler(this.CtrlButTest_Click);
            // 
            // CtrlTxb
            // 
            this.CtrlTxb.Location = new System.Drawing.Point(353, 145);
            this.CtrlTxb.Multiline = true;
            this.CtrlTxb.Name = "CtrlTxb";
            this.CtrlTxb.Size = new System.Drawing.Size(183, 188);
            this.CtrlTxb.TabIndex = 5;
            this.CtrlTxb.Text = "Строка";
            // 
            // CtrlTxbOut
            // 
            this.CtrlTxbOut.Location = new System.Drawing.Point(12, 238);
            this.CtrlTxbOut.Multiline = true;
            this.CtrlTxbOut.Name = "CtrlTxbOut";
            this.CtrlTxbOut.Size = new System.Drawing.Size(183, 188);
            this.CtrlTxbOut.TabIndex = 6;
            // 
            // CtrlButDecode
            // 
            this.CtrlButDecode.Location = new System.Drawing.Point(201, 397);
            this.CtrlButDecode.Name = "CtrlButDecode";
            this.CtrlButDecode.Size = new System.Drawing.Size(119, 29);
            this.CtrlButDecode.TabIndex = 7;
            this.CtrlButDecode.Text = "Test decode";
            this.CtrlButDecode.UseVisualStyleBackColor = true;
            this.CtrlButDecode.Click += new System.EventHandler(this.CtrlButDecode_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 438);
            this.Controls.Add(this.CtrlButDecode);
            this.Controls.Add(this.CtrlTxbOut);
            this.Controls.Add(this.CtrlTxb);
            this.Controls.Add(this.CtrlButTest);
            this.Controls.Add(this.CtrlLblString);
            this.Controls.Add(this.CtrlLblSize);
            this.Controls.Add(this.CtrlButLoad);
            this.Controls.Add(this.CtrlTS);
            this.Name = "FormMain";
            this.Text = "Стеганография";
            this.CtrlTS.ResumeLayout(false);
            this.CtrlTS.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip CtrlTS;
        private System.Windows.Forms.ToolStripButton CtrlTSButtonShow;
        private System.Windows.Forms.OpenFileDialog CtrlOFD;
        private System.Windows.Forms.Button CtrlButLoad;
        private System.Windows.Forms.Label CtrlLblSize;
        private System.Windows.Forms.ToolStripButton CtrlTSButReady;
        private System.Windows.Forms.Label CtrlLblString;
        private System.Windows.Forms.Button CtrlButTest;
        private System.Windows.Forms.TextBox CtrlTxb;
        private System.Windows.Forms.TextBox CtrlTxbOut;
        private System.Windows.Forms.Button CtrlButDecode;
    }
}


namespace WindowsFormsApplication13._2
{
    partial class MainForm
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
            this.CtrlButLoad = new System.Windows.Forms.Button();
            this.CtrlOFD = new System.Windows.Forms.OpenFileDialog();
            this.CtrlLblAns = new System.Windows.Forms.Label();
            this.CtrlButSave = new System.Windows.Forms.Button();
            this.CtrlSFD = new System.Windows.Forms.SaveFileDialog();
            this.CtrlDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // CtrlButLoad
            // 
            this.CtrlButLoad.Location = new System.Drawing.Point(12, 12);
            this.CtrlButLoad.Name = "CtrlButLoad";
            this.CtrlButLoad.Size = new System.Drawing.Size(102, 23);
            this.CtrlButLoad.TabIndex = 0;
            this.CtrlButLoad.Text = "Загрузить";
            this.CtrlButLoad.UseVisualStyleBackColor = true;
            this.CtrlButLoad.Click += new System.EventHandler(this.CtrlButLoad_Click);
            // 
            // CtrlOFD
            // 
            this.CtrlOFD.FileName = "openFileDialog1";
            // 
            // CtrlLblAns
            // 
            this.CtrlLblAns.Location = new System.Drawing.Point(12, 110);
            this.CtrlLblAns.Name = "CtrlLblAns";
            this.CtrlLblAns.Size = new System.Drawing.Size(112, 52);
            this.CtrlLblAns.TabIndex = 4;
            this.CtrlLblAns.Text = "Максимумы: 0, Минимумы: 0, Экстремумы: 0.";
            // 
            // CtrlButSave
            // 
            this.CtrlButSave.Location = new System.Drawing.Point(12, 51);
            this.CtrlButSave.Name = "CtrlButSave";
            this.CtrlButSave.Size = new System.Drawing.Size(102, 23);
            this.CtrlButSave.TabIndex = 8;
            this.CtrlButSave.Text = "Сохранить";
            this.CtrlButSave.UseVisualStyleBackColor = true;
            this.CtrlButSave.Click += new System.EventHandler(this.CtrlButSave_Click);
            // 
            // CtrlDGV
            // 
            this.CtrlDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CtrlDGV.ColumnHeadersVisible = false;
            this.CtrlDGV.Location = new System.Drawing.Point(130, 12);
            this.CtrlDGV.Name = "CtrlDGV";
            this.CtrlDGV.RowHeadersVisible = false;
            this.CtrlDGV.Size = new System.Drawing.Size(163, 150);
            this.CtrlDGV.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 172);
            this.Controls.Add(this.CtrlLblAns);
            this.Controls.Add(this.CtrlDGV);
            this.Controls.Add(this.CtrlButSave);
            this.Controls.Add(this.CtrlButLoad);
            this.Name = "MainForm";
            this.Text = "WindowsFormsApplication13.2";
            ((System.ComponentModel.ISupportInitialize)(this.CtrlDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CtrlButLoad;
        private System.Windows.Forms.OpenFileDialog CtrlOFD;
        private System.Windows.Forms.Label CtrlLblAns;
        private System.Windows.Forms.Button CtrlButSave;
        private System.Windows.Forms.SaveFileDialog CtrlSFD;
        private System.Windows.Forms.DataGridView CtrlDGV;
    }
}


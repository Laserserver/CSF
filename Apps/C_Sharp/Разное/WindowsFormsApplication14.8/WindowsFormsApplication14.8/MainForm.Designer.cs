namespace WindowsFormsApplication14._8
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
            this.CtrlDGV = new System.Windows.Forms.DataGridView();
            this.CtrlBaton = new System.Windows.Forms.Button();
            this.Edit1 = new System.Windows.Forms.TextBox();
            this.CtrlLblMisc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // CtrlDGV
            // 
            this.CtrlDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CtrlDGV.ColumnHeadersVisible = false;
            this.CtrlDGV.Location = new System.Drawing.Point(12, 12);
            this.CtrlDGV.MultiSelect = false;
            this.CtrlDGV.Name = "CtrlDGV";
            this.CtrlDGV.RowHeadersVisible = false;
            this.CtrlDGV.Size = new System.Drawing.Size(122, 310);
            this.CtrlDGV.TabIndex = 0;
            // 
            // CtrlBaton
            // 
            this.CtrlBaton.Location = new System.Drawing.Point(140, 56);
            this.CtrlBaton.Name = "CtrlBaton";
            this.CtrlBaton.Size = new System.Drawing.Size(66, 46);
            this.CtrlBaton.TabIndex = 1;
            this.CtrlBaton.Text = "Найти и удалить";
            this.CtrlBaton.UseVisualStyleBackColor = true;
            this.CtrlBaton.Click += new System.EventHandler(this.CtrlBaton_Click);
            // 
            // Edit1
            // 
            this.Edit1.Location = new System.Drawing.Point(140, 30);
            this.Edit1.Name = "Edit1";
            this.Edit1.Size = new System.Drawing.Size(66, 20);
            this.Edit1.TabIndex = 2;
            // 
            // CtrlLblMisc
            // 
            this.CtrlLblMisc.AutoSize = true;
            this.CtrlLblMisc.Location = new System.Drawing.Point(140, 9);
            this.CtrlLblMisc.Name = "CtrlLblMisc";
            this.CtrlLblMisc.Size = new System.Drawing.Size(42, 13);
            this.CtrlLblMisc.TabIndex = 3;
            this.CtrlLblMisc.Text = "Число:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 334);
            this.Controls.Add(this.CtrlLblMisc);
            this.Controls.Add(this.Edit1);
            this.Controls.Add(this.CtrlBaton);
            this.Controls.Add(this.CtrlDGV);
            this.Name = "MainForm";
            this.Text = "14.8";
            ((System.ComponentModel.ISupportInitialize)(this.CtrlDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CtrlDGV;
        private System.Windows.Forms.Button CtrlBaton;
        private System.Windows.Forms.TextBox Edit1;
        private System.Windows.Forms.Label CtrlLblMisc;
    }
}


namespace PenPlugin
{
    partial class UIPenControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.PenSizeValue = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PenSizeValue)).BeginInit();
            this.SuspendLayout();
            // 
            // PenSizeValue
            // 
            this.PenSizeValue.Location = new System.Drawing.Point(17, 34);
            this.PenSizeValue.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PenSizeValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PenSizeValue.Name = "PenSizeValue";
            this.PenSizeValue.Size = new System.Drawing.Size(120, 20);
            this.PenSizeValue.TabIndex = 0;
            this.PenSizeValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PenSizeValue.ValueChanged += new System.EventHandler(this.PenSizeValue_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Толщина";
            // 
            // UIPenControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PenSizeValue);
            this.Name = "UIPenControl";
            this.Size = new System.Drawing.Size(150, 78);
            ((System.ComponentModel.ISupportInitialize)(this.PenSizeValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown PenSizeValue;
        private System.Windows.Forms.Label label1;
    }
}

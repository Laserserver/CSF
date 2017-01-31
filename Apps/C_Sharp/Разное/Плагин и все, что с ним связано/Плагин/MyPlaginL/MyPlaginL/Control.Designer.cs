namespace Eraser
{
    partial class Eraser
    {
        /// <summary> 
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDownForPen = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownForPen)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownForPen
            // 
            this.numericUpDownForPen.Location = new System.Drawing.Point(30, 19);
            this.numericUpDownForPen.Name = "numericUpDownForPen";
            this.numericUpDownForPen.Size = new System.Drawing.Size(46, 20);
            this.numericUpDownForPen.TabIndex = 1;
            this.numericUpDownForPen.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ControlLiniya
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDownForPen);
            this.Name = "ControlLiniya";
            this.Size = new System.Drawing.Size(153, 184);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownForPen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownForPen;
    }
}

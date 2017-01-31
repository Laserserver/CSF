namespace Oop.Tasks.Paint.Plugins
{
    partial class PaintEllipsePluginOptionsControl
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
            this.brushStyleListBox = new System.Windows.Forms.ListBox();
            this.withEdge = new System.Windows.Forms.RadioButton();
            this.withEdgeAndSmth = new System.Windows.Forms.RadioButton();
            this.withoutEdge = new System.Windows.Forms.RadioButton();
            this.numericUpDownForPen = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownForPen)).BeginInit();
            this.SuspendLayout();
            // 
            // brushStyleListBox
            // 
            this.brushStyleListBox.FormattingEnabled = true;
            this.brushStyleListBox.Location = new System.Drawing.Point(37, 3);
            this.brushStyleListBox.Name = "brushStyleListBox";
            this.brushStyleListBox.Size = new System.Drawing.Size(120, 95);
            this.brushStyleListBox.TabIndex = 0;
            // 
            // withEdge
            // 
            this.withEdge.AutoSize = true;
            this.withEdge.Checked = true;
            this.withEdge.Location = new System.Drawing.Point(3, 162);
            this.withEdge.Name = "withEdge";
            this.withEdge.Size = new System.Drawing.Size(81, 17);
            this.withEdge.TabIndex = 1;
            this.withEdge.TabStop = true;
            this.withEdge.Tag = "0";
            this.withEdge.Text = "с границей";
            this.withEdge.UseVisualStyleBackColor = true;
            this.withEdge.CheckedChanged += new System.EventHandler(this.withEdge_CheckedChanged);
            // 
            // withEdgeAndSmth
            // 
            this.withEdgeAndSmth.AutoSize = true;
            this.withEdgeAndSmth.Location = new System.Drawing.Point(3, 185);
            this.withEdgeAndSmth.Name = "withEdgeAndSmth";
            this.withEdgeAndSmth.Size = new System.Drawing.Size(141, 17);
            this.withEdgeAndSmth.TabIndex = 2;
            this.withEdgeAndSmth.Tag = "1";
            this.withEdgeAndSmth.Text = "с границей и заливкой";
            this.withEdgeAndSmth.UseVisualStyleBackColor = true;
            this.withEdgeAndSmth.CheckedChanged += new System.EventHandler(this.withEdgeAndSmth_CheckedChanged);
            // 
            // withoutEdge
            // 
            this.withoutEdge.AutoSize = true;
            this.withoutEdge.Location = new System.Drawing.Point(3, 208);
            this.withoutEdge.Name = "withoutEdge";
            this.withoutEdge.Size = new System.Drawing.Size(89, 17);
            this.withoutEdge.TabIndex = 3;
            this.withoutEdge.Tag = "2";
            this.withoutEdge.Text = "без границы";
            this.withoutEdge.UseVisualStyleBackColor = true;
            this.withoutEdge.CheckedChanged += new System.EventHandler(this.withoutEdge_CheckedChanged);
            // 
            // numericUpDownForPen
            // 
            this.numericUpDownForPen.Location = new System.Drawing.Point(123, 121);
            this.numericUpDownForPen.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownForPen.Name = "numericUpDownForPen";
            this.numericUpDownForPen.Size = new System.Drawing.Size(34, 20);
            this.numericUpDownForPen.TabIndex = 4;
            this.numericUpDownForPen.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // PaintEllipsePluginOptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDownForPen);
            this.Controls.Add(this.withoutEdge);
            this.Controls.Add(this.withEdgeAndSmth);
            this.Controls.Add(this.withEdge);
            this.Controls.Add(this.brushStyleListBox);
            this.Name = "PaintEllipsePluginOptionsControl";
            this.Size = new System.Drawing.Size(160, 240);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownForPen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox brushStyleListBox;
        private System.Windows.Forms.RadioButton withEdge;
        private System.Windows.Forms.RadioButton withEdgeAndSmth;
        private System.Windows.Forms.RadioButton withoutEdge;
        private System.Windows.Forms.NumericUpDown numericUpDownForPen;

    }
}

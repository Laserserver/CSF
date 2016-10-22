namespace Graphics_One
{
    partial class LoTVForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
      this._ctrlBatonDay = new System.Windows.Forms.Button();
      this._ctrlBatonStart = new System.Windows.Forms.Button();
      this.LoTVCanvas = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.LoTVCanvas)).BeginInit();
      this.SuspendLayout();
      // 
      // _ctrlBatonDay
      // 
      this._ctrlBatonDay.Location = new System.Drawing.Point(12, 434);
      this._ctrlBatonDay.Name = "_ctrlBatonDay";
      this._ctrlBatonDay.Size = new System.Drawing.Size(75, 23);
      this._ctrlBatonDay.TabIndex = 1;
      this._ctrlBatonDay.Text = "День";
      this._ctrlBatonDay.UseVisualStyleBackColor = true;
      this._ctrlBatonDay.Click += new System.EventHandler(this._ctrlBaton_Click);
      // 
      // _ctrlBatonStart
      // 
      this._ctrlBatonStart.Location = new System.Drawing.Point(206, 434);
      this._ctrlBatonStart.Name = "_ctrlBatonStart";
      this._ctrlBatonStart.Size = new System.Drawing.Size(75, 23);
      this._ctrlBatonStart.TabIndex = 4;
      this._ctrlBatonStart.Text = "Старт";
      this._ctrlBatonStart.UseVisualStyleBackColor = true;
      this._ctrlBatonStart.Click += new System.EventHandler(this._ctrlBatonStart_Click);
      // 
      // LoTVCanvas
      // 
      this.LoTVCanvas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.LoTVCanvas.Location = new System.Drawing.Point(0, 0);
      this.LoTVCanvas.Name = "LoTVCanvas";
      this.LoTVCanvas.Size = new System.Drawing.Size(720, 430);
      this.LoTVCanvas.TabIndex = 5;
      this.LoTVCanvas.TabStop = false;
      // 
      // LoTVForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(720, 463);
      this.Controls.Add(this.LoTVCanvas);
      this.Controls.Add(this._ctrlBatonStart);
      this.Controls.Add(this._ctrlBatonDay);
      this.Name = "LoTVForm";
      this.Text = "Зад.1";
      ((System.ComponentModel.ISupportInitialize)(this.LoTVCanvas)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button _ctrlBatonDay;
    private System.Windows.Forms.Button _ctrlBatonStart;
    private System.Windows.Forms.PictureBox LoTVCanvas;
  }
}


namespace _15_35
{
  partial class Shit
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shit));
      this._ctrlLblTask = new System.Windows.Forms.Label();
      this._ctrlBaton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // _ctrlLblTask
      // 
      this._ctrlLblTask.Location = new System.Drawing.Point(12, 9);
      this._ctrlLblTask.Name = "_ctrlLblTask";
      this._ctrlLblTask.Size = new System.Drawing.Size(516, 63);
      this._ctrlLblTask.TabIndex = 0;
      this._ctrlLblTask.Text = resources.GetString("_ctrlLblTask.Text");
      // 
      // _ctrlBaton
      // 
      this._ctrlBaton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this._ctrlBaton.Location = new System.Drawing.Point(76, 75);
      this._ctrlBaton.Name = "_ctrlBaton";
      this._ctrlBaton.Size = new System.Drawing.Size(382, 99);
      this._ctrlBaton.TabIndex = 1;
      this._ctrlBaton.Text = "Niggerforce fuckshit KKK smasher of faggots x5000 alpha-version 133.7";
      this._ctrlBaton.UseVisualStyleBackColor = true;
      this._ctrlBaton.Click += new System.EventHandler(this._ctrlBaton_Click);
      // 
      // Shit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(528, 188);
      this.Controls.Add(this._ctrlBaton);
      this.Controls.Add(this._ctrlLblTask);
      this.Name = "Shit";
      this.Text = "15-35";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label _ctrlLblTask;
    private System.Windows.Forms.Button _ctrlBaton;
  }
}


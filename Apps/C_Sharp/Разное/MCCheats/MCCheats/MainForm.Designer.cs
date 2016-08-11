namespace MCCheats
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
      this._ctrlBtnClear = new System.Windows.Forms.Button();
      this._ctrlBaton = new System.Windows.Forms.Button();
      this._ctrlPanel = new System.Windows.Forms.Panel();
      this._ctrlPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // _ctrlBtnClear
      // 
      this._ctrlBtnClear.Location = new System.Drawing.Point(25, 12);
      this._ctrlBtnClear.Name = "_ctrlBtnClear";
      this._ctrlBtnClear.Size = new System.Drawing.Size(75, 23);
      this._ctrlBtnClear.TabIndex = 0;
      this._ctrlBtnClear.Text = "Вернуть";
      this._ctrlBtnClear.UseVisualStyleBackColor = true;
      this._ctrlBtnClear.Click += new System.EventHandler(this._ctrlBtnClear_Click);
      // 
      // _ctrlBaton
      // 
      this._ctrlBaton.Location = new System.Drawing.Point(500, 500);
      this._ctrlBaton.Name = "_ctrlBaton";
      this._ctrlBaton.Size = new System.Drawing.Size(75, 75);
      this._ctrlBaton.TabIndex = 1;
      this._ctrlBaton.Text = "Установить читы";
      this._ctrlBaton.UseVisualStyleBackColor = true;
      // 
      // _ctrlPanel
      // 
      this._ctrlPanel.Controls.Add(this._ctrlBaton);
      this._ctrlPanel.Controls.Add(this._ctrlBtnClear);
      this._ctrlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this._ctrlPanel.Location = new System.Drawing.Point(0, 0);
      this._ctrlPanel.Name = "_ctrlPanel";
      this._ctrlPanel.Size = new System.Drawing.Size(1142, 683);
      this._ctrlPanel.TabIndex = 2;
      this._ctrlPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this._ctrlPanel_MouseMove);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1142, 683);
      this.Controls.Add(this._ctrlPanel);
      this.Name = "MainForm";
      this.Text = "Читы Minecraft";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this._ctrlPanel.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button _ctrlBtnClear;
    private System.Windows.Forms.Button _ctrlBaton;
    private System.Windows.Forms.Panel _ctrlPanel;
  }
}


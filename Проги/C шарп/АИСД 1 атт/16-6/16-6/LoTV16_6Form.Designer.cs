namespace _16_6
{
  partial class LoTV16_6Form
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoTV16_6Form));
      this._ctrlLblTask = new System.Windows.Forms.Label();
      this._ctrlBaton = new System.Windows.Forms.Button();
      this._ctrlLoadBaton = new System.Windows.Forms.Button();
      this.ctrlOFD = new System.Windows.Forms.OpenFileDialog();
      this._ctrlDGVIn = new System.Windows.Forms.DataGridView();
      this._ctrlDGVOut = new System.Windows.Forms.DataGridView();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlDGVIn)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlDGVOut)).BeginInit();
      this.SuspendLayout();
      // 
      // _ctrlLblTask
      // 
      this._ctrlLblTask.Location = new System.Drawing.Point(12, 9);
      this._ctrlLblTask.Name = "_ctrlLblTask";
      this._ctrlLblTask.Size = new System.Drawing.Size(374, 86);
      this._ctrlLblTask.TabIndex = 0;
      this._ctrlLblTask.Text = resources.GetString("_ctrlLblTask.Text");
      // 
      // _ctrlBaton
      // 
      this._ctrlBaton.Location = new System.Drawing.Point(284, 98);
      this._ctrlBaton.Name = "_ctrlBaton";
      this._ctrlBaton.Size = new System.Drawing.Size(75, 23);
      this._ctrlBaton.TabIndex = 1;
      this._ctrlBaton.Text = "Батон";
      this._ctrlBaton.UseVisualStyleBackColor = true;
      this._ctrlBaton.Click += new System.EventHandler(this._ctrlBaton_Click);
      // 
      // _ctrlLoadBaton
      // 
      this._ctrlLoadBaton.Location = new System.Drawing.Point(29, 98);
      this._ctrlLoadBaton.Name = "_ctrlLoadBaton";
      this._ctrlLoadBaton.Size = new System.Drawing.Size(119, 23);
      this._ctrlLoadBaton.TabIndex = 2;
      this._ctrlLoadBaton.Text = "Загрузить список";
      this._ctrlLoadBaton.UseVisualStyleBackColor = true;
      this._ctrlLoadBaton.Click += new System.EventHandler(this._ctrlLoadBaton_Click);
      // 
      // ctrlOFD
      // 
      this.ctrlOFD.FileName = "LoTVOFD";
      // 
      // _ctrlDGVIn
      // 
      this._ctrlDGVIn.AllowUserToAddRows = false;
      this._ctrlDGVIn.AllowUserToDeleteRows = false;
      this._ctrlDGVIn.AllowUserToResizeColumns = false;
      this._ctrlDGVIn.AllowUserToResizeRows = false;
      this._ctrlDGVIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this._ctrlDGVIn.ColumnHeadersVisible = false;
      this._ctrlDGVIn.Location = new System.Drawing.Point(15, 138);
      this._ctrlDGVIn.MultiSelect = false;
      this._ctrlDGVIn.Name = "_ctrlDGVIn";
      this._ctrlDGVIn.ReadOnly = true;
      this._ctrlDGVIn.RowHeadersVisible = false;
      this._ctrlDGVIn.RowHeadersWidth = 30;
      this._ctrlDGVIn.Size = new System.Drawing.Size(145, 198);
      this._ctrlDGVIn.TabIndex = 3;
      // 
      // _ctrlDGVOut
      // 
      this._ctrlDGVOut.AllowUserToAddRows = false;
      this._ctrlDGVOut.AllowUserToDeleteRows = false;
      this._ctrlDGVOut.AllowUserToResizeColumns = false;
      this._ctrlDGVOut.AllowUserToResizeRows = false;
      this._ctrlDGVOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this._ctrlDGVOut.ColumnHeadersVisible = false;
      this._ctrlDGVOut.Location = new System.Drawing.Point(232, 138);
      this._ctrlDGVOut.MultiSelect = false;
      this._ctrlDGVOut.Name = "_ctrlDGVOut";
      this._ctrlDGVOut.ReadOnly = true;
      this._ctrlDGVOut.RowHeadersVisible = false;
      this._ctrlDGVOut.Size = new System.Drawing.Size(154, 198);
      this._ctrlDGVOut.TabIndex = 4;
      // 
      // LoTV16_6Form
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(398, 348);
      this.Controls.Add(this._ctrlDGVOut);
      this.Controls.Add(this._ctrlDGVIn);
      this.Controls.Add(this._ctrlLoadBaton);
      this.Controls.Add(this._ctrlBaton);
      this.Controls.Add(this._ctrlLblTask);
      this.Name = "LoTV16_6Form";
      this.Text = "16-6";
      ((System.ComponentModel.ISupportInitialize)(this._ctrlDGVIn)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlDGVOut)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label _ctrlLblTask;
    private System.Windows.Forms.Button _ctrlBaton;
    private System.Windows.Forms.Button _ctrlLoadBaton;
    private System.Windows.Forms.OpenFileDialog ctrlOFD;
    private System.Windows.Forms.DataGridView _ctrlDGVIn;
    private System.Windows.Forms.DataGridView _ctrlDGVOut;
  }
}


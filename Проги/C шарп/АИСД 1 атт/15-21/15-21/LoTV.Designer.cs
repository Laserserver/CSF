namespace _15_21
{
  partial class LoTV
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoTV));
        this.ctrlLblTask = new System.Windows.Forms.Label();
        this.ctrlOFD = new System.Windows.Forms.OpenFileDialog();
        this.ctrlBaton = new System.Windows.Forms.Button();
        this.ctrlTxb = new System.Windows.Forms.TextBox();
        this.ctrlDGV = new System.Windows.Forms.DataGridView();
        this.ctrlLoadBaton = new System.Windows.Forms.Button();
        this.ctrlDGVPreview = new System.Windows.Forms.DataGridView();
        ((System.ComponentModel.ISupportInitialize)(this.ctrlDGV)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ctrlDGVPreview)).BeginInit();
        this.SuspendLayout();
        // 
        // ctrlLblTask
        // 
        this.ctrlLblTask.Location = new System.Drawing.Point(12, 9);
        this.ctrlLblTask.Name = "ctrlLblTask";
        this.ctrlLblTask.Size = new System.Drawing.Size(405, 47);
        this.ctrlLblTask.TabIndex = 0;
        this.ctrlLblTask.Text = resources.GetString("ctrlLblTask.Text");
        // 
        // ctrlOFD
        // 
        this.ctrlOFD.FileName = "openFileDialog1";
        // 
        // ctrlBaton
        // 
        this.ctrlBaton.Location = new System.Drawing.Point(15, 125);
        this.ctrlBaton.Name = "ctrlBaton";
        this.ctrlBaton.Size = new System.Drawing.Size(75, 23);
        this.ctrlBaton.TabIndex = 1;
        this.ctrlBaton.Text = "Удалить";
        this.ctrlBaton.UseVisualStyleBackColor = true;
        this.ctrlBaton.Click += new System.EventHandler(this.ctrlBaton_Click);
        // 
        // ctrlTxb
        // 
        this.ctrlTxb.Location = new System.Drawing.Point(15, 74);
        this.ctrlTxb.Name = "ctrlTxb";
        this.ctrlTxb.Size = new System.Drawing.Size(75, 20);
        this.ctrlTxb.TabIndex = 2;
        // 
        // ctrlDGV
        // 
        this.ctrlDGV.AllowUserToAddRows = false;
        this.ctrlDGV.AllowUserToDeleteRows = false;
        this.ctrlDGV.AllowUserToResizeColumns = false;
        this.ctrlDGV.AllowUserToResizeRows = false;
        this.ctrlDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.ctrlDGV.ColumnHeadersVisible = false;
        this.ctrlDGV.Location = new System.Drawing.Point(282, 74);
        this.ctrlDGV.Name = "ctrlDGV";
        this.ctrlDGV.ReadOnly = true;
        this.ctrlDGV.RowHeadersVisible = false;
        this.ctrlDGV.Size = new System.Drawing.Size(135, 336);
        this.ctrlDGV.TabIndex = 3;
        // 
        // ctrlLoadBaton
        // 
        this.ctrlLoadBaton.Location = new System.Drawing.Point(15, 100);
        this.ctrlLoadBaton.Name = "ctrlLoadBaton";
        this.ctrlLoadBaton.Size = new System.Drawing.Size(75, 23);
        this.ctrlLoadBaton.TabIndex = 4;
        this.ctrlLoadBaton.Text = "Загрузить";
        this.ctrlLoadBaton.UseVisualStyleBackColor = true;
        this.ctrlLoadBaton.Click += new System.EventHandler(this.ctrlLoadBaton_Click);
        // 
        // ctrlDGVPreview
        // 
        this.ctrlDGVPreview.AllowUserToAddRows = false;
        this.ctrlDGVPreview.AllowUserToDeleteRows = false;
        this.ctrlDGVPreview.AllowUserToResizeColumns = false;
        this.ctrlDGVPreview.AllowUserToResizeRows = false;
        this.ctrlDGVPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.ctrlDGVPreview.ColumnHeadersVisible = false;
        this.ctrlDGVPreview.Location = new System.Drawing.Point(123, 74);
        this.ctrlDGVPreview.Name = "ctrlDGVPreview";
        this.ctrlDGVPreview.ReadOnly = true;
        this.ctrlDGVPreview.RowHeadersVisible = false;
        this.ctrlDGVPreview.Size = new System.Drawing.Size(135, 336);
        this.ctrlDGVPreview.TabIndex = 5;
        // 
        // LoTV
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(429, 422);
        this.Controls.Add(this.ctrlDGVPreview);
        this.Controls.Add(this.ctrlLoadBaton);
        this.Controls.Add(this.ctrlDGV);
        this.Controls.Add(this.ctrlTxb);
        this.Controls.Add(this.ctrlBaton);
        this.Controls.Add(this.ctrlLblTask);
        this.Name = "LoTV";
        this.Text = "15-21";
        ((System.ComponentModel.ISupportInitialize)(this.ctrlDGV)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ctrlDGVPreview)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label ctrlLblTask;
    private System.Windows.Forms.OpenFileDialog ctrlOFD;
    private System.Windows.Forms.Button ctrlBaton;
    private System.Windows.Forms.TextBox ctrlTxb;
    private System.Windows.Forms.DataGridView ctrlDGV;
    private System.Windows.Forms.Button ctrlLoadBaton;
    private System.Windows.Forms.DataGridView ctrlDGVPreview;
  }
}


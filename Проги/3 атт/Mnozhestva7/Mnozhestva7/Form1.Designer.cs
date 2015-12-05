namespace Mnozhestva7
{
  partial class Form1
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.dgvIn = new System.Windows.Forms.DataGridView();
      this.dgvOut = new System.Windows.Forms.DataGridView();
      this.label1 = new System.Windows.Forms.Label();
      this.btnFind = new System.Windows.Forms.Button();
      this.lblAns = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.dgvIn)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).BeginInit();
      this.SuspendLayout();
      // 
      // dgvIn
      // 
      this.dgvIn.AllowUserToAddRows = false;
      this.dgvIn.AllowUserToDeleteRows = false;
      this.dgvIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvIn.ColumnHeadersVisible = false;
      this.dgvIn.Location = new System.Drawing.Point(15, 128);
      this.dgvIn.Name = "dgvIn";
      this.dgvIn.ReadOnly = true;
      this.dgvIn.RowHeadersVisible = false;
      this.dgvIn.Size = new System.Drawing.Size(208, 202);
      this.dgvIn.TabIndex = 0;
      // 
      // dgvOut
      // 
      this.dgvOut.AllowUserToAddRows = false;
      this.dgvOut.AllowUserToDeleteRows = false;
      this.dgvOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvOut.ColumnHeadersVisible = false;
      this.dgvOut.Location = new System.Drawing.Point(273, 128);
      this.dgvOut.Name = "dgvOut";
      this.dgvOut.RowHeadersVisible = false;
      this.dgvOut.Size = new System.Drawing.Size(118, 202);
      this.dgvOut.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(379, 62);
      this.label1.TabIndex = 3;
      this.label1.Text = resources.GetString("label1.Text");
      // 
      // btnFind
      // 
      this.btnFind.Location = new System.Drawing.Point(273, 74);
      this.btnFind.Name = "btnFind";
      this.btnFind.Size = new System.Drawing.Size(118, 47);
      this.btnFind.TabIndex = 4;
      this.btnFind.Text = "Сформировать новое множество";
      this.btnFind.UseVisualStyleBackColor = true;
      this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
      // 
      // lblAns
      // 
      this.lblAns.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblAns.Location = new System.Drawing.Point(37, 91);
      this.lblAns.Name = "lblAns";
      this.lblAns.Size = new System.Drawing.Size(100, 23);
      this.lblAns.TabIndex = 5;
      this.lblAns.Text = "Ответ:";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(422, 342);
      this.Controls.Add(this.lblAns);
      this.Controls.Add(this.btnFind);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.dgvOut);
      this.Controls.Add(this.dgvIn);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.dgvIn)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView dgvIn;
    private System.Windows.Forms.DataGridView dgvOut;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnFind;
    private System.Windows.Forms.Label lblAns;
  }
}


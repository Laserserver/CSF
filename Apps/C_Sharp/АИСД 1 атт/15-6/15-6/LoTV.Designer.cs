namespace _15_6
{
  partial class LoTV
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.ctrlLblTask = new System.Windows.Forms.Label();
      this.ctrlDGVIn = new System.Windows.Forms.DataGridView();
      this.ctrlBaton = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.ctrlDGVIn)).BeginInit();
      this.SuspendLayout();
      // 
      // ctrlLblTask
      // 
      this.ctrlLblTask.Location = new System.Drawing.Point(91, 12);
      this.ctrlLblTask.Name = "ctrlLblTask";
      this.ctrlLblTask.Size = new System.Drawing.Size(118, 212);
      this.ctrlLblTask.TabIndex = 0;
      this.ctrlLblTask.Text = "6. Дан список вещественных чисел. Проверить, упорядочены ли числа по возрастанию " +
          "или по убыванию.";
      // 
      // ctrlDGVIn
      // 
      this.ctrlDGVIn.AllowUserToResizeColumns = false;
      this.ctrlDGVIn.AllowUserToResizeRows = false;
      this.ctrlDGVIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.ctrlDGVIn.ColumnHeadersVisible = false;
      this.ctrlDGVIn.Location = new System.Drawing.Point(12, 12);
      this.ctrlDGVIn.Name = "ctrlDGVIn";
      this.ctrlDGVIn.RowHeadersVisible = false;
      this.ctrlDGVIn.Size = new System.Drawing.Size(56, 282);
      this.ctrlDGVIn.TabIndex = 1;
      // 
      // ctrlBaton
      // 
      this.ctrlBaton.Location = new System.Drawing.Point(94, 239);
      this.ctrlBaton.Name = "ctrlBaton";
      this.ctrlBaton.Size = new System.Drawing.Size(101, 23);
      this.ctrlBaton.TabIndex = 2;
      this.ctrlBaton.Text = "Батон";
      this.ctrlBaton.UseVisualStyleBackColor = true;
      this.ctrlBaton.Click += new System.EventHandler(this.ctrlBaton_Click);
      // 
      // LoTV
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.ClientSize = new System.Drawing.Size(230, 303);
      this.Controls.Add(this.ctrlBaton);
      this.Controls.Add(this.ctrlDGVIn);
      this.Controls.Add(this.ctrlLblTask);
      this.Name = "LoTV";
      this.Text = "15-6";
      ((System.ComponentModel.ISupportInitialize)(this.ctrlDGVIn)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label ctrlLblTask;
    private System.Windows.Forms.DataGridView ctrlDGVIn;
    private System.Windows.Forms.Button ctrlBaton;
  }
}


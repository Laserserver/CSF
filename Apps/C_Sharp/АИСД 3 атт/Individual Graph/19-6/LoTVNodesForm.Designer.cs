namespace _19_6
{
  partial class LoTVNodes
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
      this._ctrlBaton = new System.Windows.Forms.Button();
      this._ctrlDGV = new System.Windows.Forms.DataGridView();
      this._ctrlBatonDelete = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlDGV)).BeginInit();
      this.SuspendLayout();
      // 
      // _ctrlBaton
      // 
      this._ctrlBaton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this._ctrlBaton.Location = new System.Drawing.Point(12, 263);
      this._ctrlBaton.Name = "_ctrlBaton";
      this._ctrlBaton.Size = new System.Drawing.Size(162, 23);
      this._ctrlBaton.TabIndex = 0;
      this._ctrlBaton.Text = "Переименовать";
      this._ctrlBaton.UseVisualStyleBackColor = true;
      this._ctrlBaton.Click += new System.EventHandler(this._ctrlBaton_Click);
      // 
      // _ctrlDGV
      // 
      this._ctrlDGV.AllowUserToAddRows = false;
      this._ctrlDGV.AllowUserToDeleteRows = false;
      this._ctrlDGV.AllowUserToResizeRows = false;
      this._ctrlDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this._ctrlDGV.ColumnHeadersVisible = false;
      this._ctrlDGV.Location = new System.Drawing.Point(12, 12);
      this._ctrlDGV.MultiSelect = false;
      this._ctrlDGV.Name = "_ctrlDGV";
      this._ctrlDGV.ReadOnly = true;
      this._ctrlDGV.RowHeadersVisible = false;
      this._ctrlDGV.Size = new System.Drawing.Size(162, 216);
      this._ctrlDGV.TabIndex = 1;
      // 
      // _ctrlBatonDelete
      // 
      this._ctrlBatonDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this._ctrlBatonDelete.Location = new System.Drawing.Point(12, 234);
      this._ctrlBatonDelete.Name = "_ctrlBatonDelete";
      this._ctrlBatonDelete.Size = new System.Drawing.Size(162, 23);
      this._ctrlBatonDelete.TabIndex = 3;
      this._ctrlBatonDelete.Text = "Удалить";
      this._ctrlBatonDelete.UseVisualStyleBackColor = true;
      this._ctrlBatonDelete.Click += new System.EventHandler(this._ctrlBatonDelete_Click);
      // 
      // LoTVNodes
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(188, 298);
      this.Controls.Add(this._ctrlBatonDelete);
      this.Controls.Add(this._ctrlDGV);
      this.Controls.Add(this._ctrlBaton);
      this.Name = "LoTVNodes";
      this.Text = "Узлы";
      ((System.ComponentModel.ISupportInitialize)(this._ctrlDGV)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button _ctrlBaton;
    private System.Windows.Forms.DataGridView _ctrlDGV;
    private System.Windows.Forms.Button _ctrlBatonDelete;
  }
}
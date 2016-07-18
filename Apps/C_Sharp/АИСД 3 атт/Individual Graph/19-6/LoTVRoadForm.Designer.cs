namespace _19_6
{
  partial class LoTVRoadForm
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
      this._ctrlNumRows = new System.Windows.Forms.NumericUpDown();
      this._ctrlLblUtilRows = new System.Windows.Forms.Label();
      this._ctrlTxb = new System.Windows.Forms.TextBox();
      this._ctrlLblUtilName = new System.Windows.Forms.Label();
      this._ctrlLblName = new System.Windows.Forms.Label();
      this._ctrlButSetData = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumRows)).BeginInit();
      this.SuspendLayout();
      // 
      // _ctrlNumRows
      // 
      this._ctrlNumRows.Location = new System.Drawing.Point(68, 12);
      this._ctrlNumRows.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this._ctrlNumRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this._ctrlNumRows.Name = "_ctrlNumRows";
      this._ctrlNumRows.Size = new System.Drawing.Size(126, 20);
      this._ctrlNumRows.TabIndex = 0;
      this._ctrlNumRows.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // _ctrlLblUtilRows
      // 
      this._ctrlLblUtilRows.AutoSize = true;
      this._ctrlLblUtilRows.Location = new System.Drawing.Point(12, 14);
      this._ctrlLblUtilRows.Name = "_ctrlLblUtilRows";
      this._ctrlLblUtilRows.Size = new System.Drawing.Size(50, 13);
      this._ctrlLblUtilRows.TabIndex = 1;
      this._ctrlLblUtilRows.Text = "Полосы:";
      // 
      // _ctrlTxb
      // 
      this._ctrlTxb.Location = new System.Drawing.Point(50, 53);
      this._ctrlTxb.Name = "_ctrlTxb";
      this._ctrlTxb.Size = new System.Drawing.Size(144, 20);
      this._ctrlTxb.TabIndex = 2;
      // 
      // _ctrlLblUtilName
      // 
      this._ctrlLblUtilName.AutoSize = true;
      this._ctrlLblUtilName.Location = new System.Drawing.Point(12, 56);
      this._ctrlLblUtilName.Name = "_ctrlLblUtilName";
      this._ctrlLblUtilName.Size = new System.Drawing.Size(32, 13);
      this._ctrlLblUtilName.TabIndex = 3;
      this._ctrlLblUtilName.Text = "Имя:";
      // 
      // _ctrlLblName
      // 
      this._ctrlLblName.AutoSize = true;
      this._ctrlLblName.Location = new System.Drawing.Point(12, 35);
      this._ctrlLblName.Name = "_ctrlLblName";
      this._ctrlLblName.Size = new System.Drawing.Size(78, 13);
      this._ctrlLblName.TabIndex = 4;
      this._ctrlLblName.Text = "Текущее имя:";
      // 
      // _ctrlButSetData
      // 
      this._ctrlButSetData.DialogResult = System.Windows.Forms.DialogResult.OK;
      this._ctrlButSetData.Location = new System.Drawing.Point(12, 90);
      this._ctrlButSetData.Name = "_ctrlButSetData";
      this._ctrlButSetData.Size = new System.Drawing.Size(182, 23);
      this._ctrlButSetData.TabIndex = 5;
      this._ctrlButSetData.Text = "Сохранить";
      this._ctrlButSetData.UseVisualStyleBackColor = true;
      this._ctrlButSetData.Click += new System.EventHandler(this._ctrlButSetData_Click);
      // 
      // LoTVRoadForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(206, 121);
      this.Controls.Add(this._ctrlButSetData);
      this.Controls.Add(this._ctrlLblName);
      this.Controls.Add(this._ctrlLblUtilName);
      this.Controls.Add(this._ctrlTxb);
      this.Controls.Add(this._ctrlLblUtilRows);
      this.Controls.Add(this._ctrlNumRows);
      this.Name = "LoTVRoadForm";
      this.Text = "Меню дороги";
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumRows)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.NumericUpDown _ctrlNumRows;
    private System.Windows.Forms.Label _ctrlLblUtilRows;
    private System.Windows.Forms.TextBox _ctrlTxb;
    private System.Windows.Forms.Label _ctrlLblUtilName;
    private System.Windows.Forms.Label _ctrlLblName;
    private System.Windows.Forms.Button _ctrlButSetData;
  }
}
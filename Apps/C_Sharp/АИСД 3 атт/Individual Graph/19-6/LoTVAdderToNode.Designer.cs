namespace _19_6
{
  partial class LoTVAdderToNode
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
      this._ctrlDGVAncs = new System.Windows.Forms.DataGridView();
      this._ctrlDGVDescs = new System.Windows.Forms.DataGridView();
      this._ctrlLblAnc = new System.Windows.Forms.Label();
      this._ctrlLblDesc = new System.Windows.Forms.Label();
      this._ctrlBaton = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlDGVAncs)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlDGVDescs)).BeginInit();
      this.SuspendLayout();
      // 
      // _ctrlDGVAncs
      // 
      this._ctrlDGVAncs.AllowUserToAddRows = false;
      this._ctrlDGVAncs.AllowUserToDeleteRows = false;
      this._ctrlDGVAncs.AllowUserToResizeColumns = false;
      this._ctrlDGVAncs.AllowUserToResizeRows = false;
      this._ctrlDGVAncs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this._ctrlDGVAncs.ColumnHeadersVisible = false;
      this._ctrlDGVAncs.Location = new System.Drawing.Point(12, 36);
      this._ctrlDGVAncs.MultiSelect = false;
      this._ctrlDGVAncs.Name = "_ctrlDGVAncs";
      this._ctrlDGVAncs.ReadOnly = true;
      this._ctrlDGVAncs.RowHeadersVisible = false;
      this._ctrlDGVAncs.Size = new System.Drawing.Size(117, 238);
      this._ctrlDGVAncs.TabIndex = 0;
      this._ctrlDGVAncs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._ctrlDGVAncs_CellClick);
      // 
      // _ctrlDGVDescs
      // 
      this._ctrlDGVDescs.AllowUserToAddRows = false;
      this._ctrlDGVDescs.AllowUserToDeleteRows = false;
      this._ctrlDGVDescs.AllowUserToResizeColumns = false;
      this._ctrlDGVDescs.AllowUserToResizeRows = false;
      this._ctrlDGVDescs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this._ctrlDGVDescs.ColumnHeadersVisible = false;
      this._ctrlDGVDescs.Location = new System.Drawing.Point(153, 36);
      this._ctrlDGVDescs.Name = "_ctrlDGVDescs";
      this._ctrlDGVDescs.ReadOnly = true;
      this._ctrlDGVDescs.RowHeadersVisible = false;
      this._ctrlDGVDescs.Size = new System.Drawing.Size(119, 209);
      this._ctrlDGVDescs.TabIndex = 1;
      // 
      // _ctrlLblAnc
      // 
      this._ctrlLblAnc.Location = new System.Drawing.Point(12, 16);
      this._ctrlLblAnc.Name = "_ctrlLblAnc";
      this._ctrlLblAnc.Size = new System.Drawing.Size(117, 13);
      this._ctrlLblAnc.TabIndex = 2;
      this._ctrlLblAnc.Text = "Доступные узлы";
      this._ctrlLblAnc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // _ctrlLblDesc
      // 
      this._ctrlLblDesc.Location = new System.Drawing.Point(150, 16);
      this._ctrlLblDesc.Name = "_ctrlLblDesc";
      this._ctrlLblDesc.Size = new System.Drawing.Size(122, 13);
      this._ctrlLblDesc.TabIndex = 3;
      this._ctrlLblDesc.Text = "Предки выбранного";
      this._ctrlLblDesc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // _ctrlBaton
      // 
      this._ctrlBaton.Location = new System.Drawing.Point(153, 251);
      this._ctrlBaton.Name = "_ctrlBaton";
      this._ctrlBaton.Size = new System.Drawing.Size(119, 23);
      this._ctrlBaton.TabIndex = 4;
      this._ctrlBaton.Text = "Добавить";
      this._ctrlBaton.UseVisualStyleBackColor = true;
      this._ctrlBaton.Click += new System.EventHandler(this._ctrlBaton_Click);
      // 
      // LoTVAdderToNode
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 286);
      this.Controls.Add(this._ctrlBaton);
      this.Controls.Add(this._ctrlLblDesc);
      this.Controls.Add(this._ctrlLblAnc);
      this.Controls.Add(this._ctrlDGVDescs);
      this.Controls.Add(this._ctrlDGVAncs);
      this.Name = "LoTVAdderToNode";
      this.Text = "Добавление к предку";
      ((System.ComponentModel.ISupportInitialize)(this._ctrlDGVAncs)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlDGVDescs)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView _ctrlDGVAncs;
    private System.Windows.Forms.DataGridView _ctrlDGVDescs;
    private System.Windows.Forms.Label _ctrlLblAnc;
    private System.Windows.Forms.Label _ctrlLblDesc;
    private System.Windows.Forms.Button _ctrlBaton;
  }
}
namespace Yaisp3_v._0._1
{
  partial class _FormAgency
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
      this._ctrlTxbName = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this._ctrlTxbDeposit = new System.Windows.Forms.TextBox();
      this._ctrlGrBStrat = new System.Windows.Forms.GroupBox();
      this._ctrlRadAggro = new System.Windows.Forms.RadioButton();
      this._ctrlRadNormal = new System.Windows.Forms.RadioButton();
      this._ctrlRadConserv = new System.Windows.Forms.RadioButton();
      this.label3 = new System.Windows.Forms.Label();
      this._ctrlTxbBillboards = new System.Windows.Forms.TextBox();
      this._ctrlButCreate = new System.Windows.Forms.Button();
      this._ctrlButEdit = new System.Windows.Forms.Button();
      this._ctrlGrBStrat.SuspendLayout();
      this.SuspendLayout();
      // 
      // _ctrlTxbName
      // 
      this._ctrlTxbName.Location = new System.Drawing.Point(75, 22);
      this._ctrlTxbName.Name = "_ctrlTxbName";
      this._ctrlTxbName.Size = new System.Drawing.Size(169, 20);
      this._ctrlTxbName.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 25);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(60, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Название:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 51);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(57, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Депозит: ";
      // 
      // _ctrlTxbDeposit
      // 
      this._ctrlTxbDeposit.Location = new System.Drawing.Point(75, 48);
      this._ctrlTxbDeposit.Name = "_ctrlTxbDeposit";
      this._ctrlTxbDeposit.Size = new System.Drawing.Size(100, 20);
      this._ctrlTxbDeposit.TabIndex = 2;
      // 
      // _ctrlGrBStrat
      // 
      this._ctrlGrBStrat.Controls.Add(this._ctrlRadConserv);
      this._ctrlGrBStrat.Controls.Add(this._ctrlRadNormal);
      this._ctrlGrBStrat.Controls.Add(this._ctrlRadAggro);
      this._ctrlGrBStrat.Location = new System.Drawing.Point(15, 118);
      this._ctrlGrBStrat.Name = "_ctrlGrBStrat";
      this._ctrlGrBStrat.Size = new System.Drawing.Size(121, 90);
      this._ctrlGrBStrat.TabIndex = 4;
      this._ctrlGrBStrat.TabStop = false;
      this._ctrlGrBStrat.Tag = "3";
      this._ctrlGrBStrat.Text = "Стратегия";
      // 
      // _ctrlRadAggro
      // 
      this._ctrlRadAggro.AutoSize = true;
      this._ctrlRadAggro.Location = new System.Drawing.Point(6, 65);
      this._ctrlRadAggro.Name = "_ctrlRadAggro";
      this._ctrlRadAggro.Size = new System.Drawing.Size(91, 17);
      this._ctrlRadAggro.TabIndex = 5;
      this._ctrlRadAggro.Text = "Агрессивная";
      this._ctrlRadAggro.UseVisualStyleBackColor = true;
      // 
      // _ctrlRadNormal
      // 
      this._ctrlRadNormal.AutoSize = true;
      this._ctrlRadNormal.Location = new System.Drawing.Point(6, 42);
      this._ctrlRadNormal.Name = "_ctrlRadNormal";
      this._ctrlRadNormal.Size = new System.Drawing.Size(83, 17);
      this._ctrlRadNormal.TabIndex = 6;
      this._ctrlRadNormal.Tag = "2";
      this._ctrlRadNormal.Text = "Умеренная";
      this._ctrlRadNormal.UseVisualStyleBackColor = true;
      // 
      // _ctrlRadConserv
      // 
      this._ctrlRadConserv.AutoSize = true;
      this._ctrlRadConserv.Checked = true;
      this._ctrlRadConserv.Location = new System.Drawing.Point(6, 19);
      this._ctrlRadConserv.Name = "_ctrlRadConserv";
      this._ctrlRadConserv.Size = new System.Drawing.Size(109, 17);
      this._ctrlRadConserv.TabIndex = 7;
      this._ctrlRadConserv.TabStop = true;
      this._ctrlRadConserv.Tag = "1";
      this._ctrlRadConserv.Text = "Консервативная";
      this._ctrlRadConserv.UseVisualStyleBackColor = true;
      this._ctrlRadConserv.CheckedChanged += new System.EventHandler(this.ChangeStrategyEvent);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 77);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(42, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "Щиты: ";
      // 
      // _ctrlTxbBillboards
      // 
      this._ctrlTxbBillboards.Location = new System.Drawing.Point(75, 74);
      this._ctrlTxbBillboards.Name = "_ctrlTxbBillboards";
      this._ctrlTxbBillboards.Size = new System.Drawing.Size(100, 20);
      this._ctrlTxbBillboards.TabIndex = 5;
      // 
      // _ctrlButCreate
      // 
      this._ctrlButCreate.Location = new System.Drawing.Point(15, 235);
      this._ctrlButCreate.Name = "_ctrlButCreate";
      this._ctrlButCreate.Size = new System.Drawing.Size(75, 23);
      this._ctrlButCreate.TabIndex = 7;
      this._ctrlButCreate.Text = "Создать";
      this._ctrlButCreate.UseVisualStyleBackColor = true;
      this._ctrlButCreate.Click += new System.EventHandler(this._ctrlButCreate_Click);
      // 
      // _ctrlButEdit
      // 
      this._ctrlButEdit.Location = new System.Drawing.Point(169, 235);
      this._ctrlButEdit.Name = "_ctrlButEdit";
      this._ctrlButEdit.Size = new System.Drawing.Size(75, 23);
      this._ctrlButEdit.TabIndex = 8;
      this._ctrlButEdit.Text = "Изменить";
      this._ctrlButEdit.UseVisualStyleBackColor = true;
      this._ctrlButEdit.Click += new System.EventHandler(this._ctrlButEdit_Click);
      // 
      // _FormAgency
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(256, 271);
      this.Controls.Add(this._ctrlButEdit);
      this.Controls.Add(this._ctrlButCreate);
      this.Controls.Add(this.label3);
      this.Controls.Add(this._ctrlTxbBillboards);
      this.Controls.Add(this._ctrlGrBStrat);
      this.Controls.Add(this.label2);
      this.Controls.Add(this._ctrlTxbDeposit);
      this.Controls.Add(this.label1);
      this.Controls.Add(this._ctrlTxbName);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "_FormAgency";
      this.Text = "Рекламное баннерное агентство";
      this.Load += new System.EventHandler(this._FormAgency_Load);
      this._ctrlGrBStrat.ResumeLayout(false);
      this._ctrlGrBStrat.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox _ctrlTxbName;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox _ctrlTxbDeposit;
    private System.Windows.Forms.GroupBox _ctrlGrBStrat;
    private System.Windows.Forms.RadioButton _ctrlRadConserv;
    private System.Windows.Forms.RadioButton _ctrlRadNormal;
    private System.Windows.Forms.RadioButton _ctrlRadAggro;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox _ctrlTxbBillboards;
    private System.Windows.Forms.Button _ctrlButCreate;
    private System.Windows.Forms.Button _ctrlButEdit;
  }
}
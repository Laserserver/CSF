namespace Binary
{
  partial class BNRForm
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
      this._ctrlTab = new System.Windows.Forms.TabControl();
      this._ctrlPageCalc = new System.Windows.Forms.TabPage();
      this._ctrlBinBaton = new System.Windows.Forms.Button();
      this._ctrlDGVBinary = new System.Windows.Forms.DataGridView();
      this._ctrlGrBCase = new System.Windows.Forms.GroupBox();
      this._ctrlRadBAddit = new System.Windows.Forms.RadioButton();
      this._ctrlRadBPlus = new System.Windows.Forms.RadioButton();
      this._ctrlGrBData = new System.Windows.Forms.GroupBox();
      this._ctrlTxbFirst = new System.Windows.Forms.TextBox();
      this._ctrlLblSecond = new System.Windows.Forms.Label();
      this._ctrlTxbSecond = new System.Windows.Forms.TextBox();
      this._ctrlLblFirst = new System.Windows.Forms.Label();
      this._ctrlPageTrans = new System.Windows.Forms.TabPage();
      this._ctrlDGVDHOBView = new System.Windows.Forms.DataGridView();
      this._ctrlTab.SuspendLayout();
      this._ctrlPageCalc.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlDGVBinary)).BeginInit();
      this._ctrlGrBCase.SuspendLayout();
      this._ctrlGrBData.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlDGVDHOBView)).BeginInit();
      this.SuspendLayout();
      // 
      // _ctrlTab
      // 
      this._ctrlTab.Controls.Add(this._ctrlPageCalc);
      this._ctrlTab.Controls.Add(this._ctrlPageTrans);
      this._ctrlTab.Dock = System.Windows.Forms.DockStyle.Fill;
      this._ctrlTab.Location = new System.Drawing.Point(0, 0);
      this._ctrlTab.Name = "_ctrlTab";
      this._ctrlTab.SelectedIndex = 0;
      this._ctrlTab.Size = new System.Drawing.Size(697, 426);
      this._ctrlTab.TabIndex = 0;
      // 
      // _ctrlPageCalc
      // 
      this._ctrlPageCalc.Controls.Add(this._ctrlDGVDHOBView);
      this._ctrlPageCalc.Controls.Add(this._ctrlBinBaton);
      this._ctrlPageCalc.Controls.Add(this._ctrlDGVBinary);
      this._ctrlPageCalc.Controls.Add(this._ctrlGrBCase);
      this._ctrlPageCalc.Controls.Add(this._ctrlGrBData);
      this._ctrlPageCalc.Location = new System.Drawing.Point(4, 22);
      this._ctrlPageCalc.Name = "_ctrlPageCalc";
      this._ctrlPageCalc.Padding = new System.Windows.Forms.Padding(3);
      this._ctrlPageCalc.Size = new System.Drawing.Size(689, 400);
      this._ctrlPageCalc.TabIndex = 0;
      this._ctrlPageCalc.Text = "Двоичные операции";
      this._ctrlPageCalc.UseVisualStyleBackColor = true;
      // 
      // _ctrlBinBaton
      // 
      this._ctrlBinBaton.Location = new System.Drawing.Point(223, 180);
      this._ctrlBinBaton.Name = "_ctrlBinBaton";
      this._ctrlBinBaton.Size = new System.Drawing.Size(75, 23);
      this._ctrlBinBaton.TabIndex = 11;
      this._ctrlBinBaton.Text = "Батон";
      this._ctrlBinBaton.UseVisualStyleBackColor = true;
      this._ctrlBinBaton.Click += new System.EventHandler(this._ctrlBinBaton_Click);
      // 
      // _ctrlDGVBinary
      // 
      this._ctrlDGVBinary.AllowUserToAddRows = false;
      this._ctrlDGVBinary.AllowUserToDeleteRows = false;
      this._ctrlDGVBinary.AllowUserToResizeColumns = false;
      this._ctrlDGVBinary.AllowUserToResizeRows = false;
      this._ctrlDGVBinary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this._ctrlDGVBinary.ColumnHeadersVisible = false;
      this._ctrlDGVBinary.Location = new System.Drawing.Point(223, 6);
      this._ctrlDGVBinary.Name = "_ctrlDGVBinary";
      this._ctrlDGVBinary.ReadOnly = true;
      this._ctrlDGVBinary.RowHeadersVisible = false;
      this._ctrlDGVBinary.Size = new System.Drawing.Size(202, 84);
      this._ctrlDGVBinary.TabIndex = 10;
      // 
      // _ctrlGrBCase
      // 
      this._ctrlGrBCase.Controls.Add(this._ctrlRadBAddit);
      this._ctrlGrBCase.Controls.Add(this._ctrlRadBPlus);
      this._ctrlGrBCase.Location = new System.Drawing.Point(6, 85);
      this._ctrlGrBCase.Name = "_ctrlGrBCase";
      this._ctrlGrBCase.Size = new System.Drawing.Size(200, 118);
      this._ctrlGrBCase.TabIndex = 9;
      this._ctrlGrBCase.TabStop = false;
      this._ctrlGrBCase.Text = "Операция";
      // 
      // _ctrlRadBAddit
      // 
      this._ctrlRadBAddit.AutoSize = true;
      this._ctrlRadBAddit.Location = new System.Drawing.Point(6, 42);
      this._ctrlRadBAddit.Name = "_ctrlRadBAddit";
      this._ctrlRadBAddit.Size = new System.Drawing.Size(110, 17);
      this._ctrlRadBAddit.TabIndex = 1;
      this._ctrlRadBAddit.TabStop = true;
      this._ctrlRadBAddit.Text = "Добавочный код";
      this._ctrlRadBAddit.UseVisualStyleBackColor = true;
      // 
      // _ctrlRadBPlus
      // 
      this._ctrlRadBPlus.AutoSize = true;
      this._ctrlRadBPlus.Location = new System.Drawing.Point(6, 19);
      this._ctrlRadBPlus.Name = "_ctrlRadBPlus";
      this._ctrlRadBPlus.Size = new System.Drawing.Size(76, 17);
      this._ctrlRadBPlus.TabIndex = 0;
      this._ctrlRadBPlus.TabStop = true;
      this._ctrlRadBPlus.Text = "Сложение";
      this._ctrlRadBPlus.UseVisualStyleBackColor = true;
      // 
      // _ctrlGrBData
      // 
      this._ctrlGrBData.BackColor = System.Drawing.Color.Transparent;
      this._ctrlGrBData.Controls.Add(this._ctrlTxbFirst);
      this._ctrlGrBData.Controls.Add(this._ctrlLblSecond);
      this._ctrlGrBData.Controls.Add(this._ctrlTxbSecond);
      this._ctrlGrBData.Controls.Add(this._ctrlLblFirst);
      this._ctrlGrBData.Location = new System.Drawing.Point(6, 6);
      this._ctrlGrBData.Name = "_ctrlGrBData";
      this._ctrlGrBData.Size = new System.Drawing.Size(200, 73);
      this._ctrlGrBData.TabIndex = 8;
      this._ctrlGrBData.TabStop = false;
      this._ctrlGrBData.Text = "Данные";
      // 
      // _ctrlTxbFirst
      // 
      this._ctrlTxbFirst.Location = new System.Drawing.Point(58, 19);
      this._ctrlTxbFirst.Name = "_ctrlTxbFirst";
      this._ctrlTxbFirst.Size = new System.Drawing.Size(136, 20);
      this._ctrlTxbFirst.TabIndex = 4;
      // 
      // _ctrlLblSecond
      // 
      this._ctrlLblSecond.AutoSize = true;
      this._ctrlLblSecond.Location = new System.Drawing.Point(7, 48);
      this._ctrlLblSecond.Name = "_ctrlLblSecond";
      this._ctrlLblSecond.Size = new System.Drawing.Size(43, 13);
      this._ctrlLblSecond.TabIndex = 7;
      this._ctrlLblSecond.Text = "Второе";
      // 
      // _ctrlTxbSecond
      // 
      this._ctrlTxbSecond.Location = new System.Drawing.Point(58, 45);
      this._ctrlTxbSecond.Name = "_ctrlTxbSecond";
      this._ctrlTxbSecond.Size = new System.Drawing.Size(136, 20);
      this._ctrlTxbSecond.TabIndex = 5;
      // 
      // _ctrlLblFirst
      // 
      this._ctrlLblFirst.AutoSize = true;
      this._ctrlLblFirst.Location = new System.Drawing.Point(7, 22);
      this._ctrlLblFirst.Name = "_ctrlLblFirst";
      this._ctrlLblFirst.Size = new System.Drawing.Size(45, 13);
      this._ctrlLblFirst.TabIndex = 6;
      this._ctrlLblFirst.Text = "Первое";
      // 
      // _ctrlPageTrans
      // 
      this._ctrlPageTrans.Location = new System.Drawing.Point(4, 22);
      this._ctrlPageTrans.Name = "_ctrlPageTrans";
      this._ctrlPageTrans.Padding = new System.Windows.Forms.Padding(3);
      this._ctrlPageTrans.Size = new System.Drawing.Size(689, 400);
      this._ctrlPageTrans.TabIndex = 1;
      this._ctrlPageTrans.Text = "Перевод";
      this._ctrlPageTrans.UseVisualStyleBackColor = true;
      // 
      // _ctrlDGVDHOBView
      // 
      this._ctrlDGVDHOBView.AllowUserToAddRows = false;
      this._ctrlDGVDHOBView.AllowUserToDeleteRows = false;
      this._ctrlDGVDHOBView.AllowUserToResizeColumns = false;
      this._ctrlDGVDHOBView.AllowUserToResizeRows = false;
      this._ctrlDGVDHOBView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this._ctrlDGVDHOBView.ColumnHeadersVisible = false;
      this._ctrlDGVDHOBView.Location = new System.Drawing.Point(425, 6);
      this._ctrlDGVDHOBView.Name = "_ctrlDGVDHOBView";
      this._ctrlDGVDHOBView.ReadOnly = true;
      this._ctrlDGVDHOBView.RowHeadersVisible = false;
      this._ctrlDGVDHOBView.Size = new System.Drawing.Size(85, 84);
      this._ctrlDGVDHOBView.TabIndex = 12;
      // 
      // BNRForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(697, 426);
      this.Controls.Add(this._ctrlTab);
      this.Name = "BNRForm";
      this.Text = "Двоичный калькулятор";
      this._ctrlTab.ResumeLayout(false);
      this._ctrlPageCalc.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this._ctrlDGVBinary)).EndInit();
      this._ctrlGrBCase.ResumeLayout(false);
      this._ctrlGrBCase.PerformLayout();
      this._ctrlGrBData.ResumeLayout(false);
      this._ctrlGrBData.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlDGVDHOBView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl _ctrlTab;
    private System.Windows.Forms.TabPage _ctrlPageCalc;
    private System.Windows.Forms.Button _ctrlBinBaton;
    private System.Windows.Forms.DataGridView _ctrlDGVBinary;
    private System.Windows.Forms.GroupBox _ctrlGrBCase;
    private System.Windows.Forms.RadioButton _ctrlRadBAddit;
    private System.Windows.Forms.RadioButton _ctrlRadBPlus;
    private System.Windows.Forms.GroupBox _ctrlGrBData;
    private System.Windows.Forms.TextBox _ctrlTxbFirst;
    private System.Windows.Forms.Label _ctrlLblSecond;
    private System.Windows.Forms.TextBox _ctrlTxbSecond;
    private System.Windows.Forms.Label _ctrlLblFirst;
    private System.Windows.Forms.TabPage _ctrlPageTrans;
    private System.Windows.Forms.DataGridView _ctrlDGVDHOBView;
  }
}


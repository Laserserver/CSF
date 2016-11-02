namespace Yaisp3_v._0._1
{
  partial class _FormCity
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
      this._ctrlPicBxCity = new System.Windows.Forms.PictureBox();
      this._ctrlButMark = new System.Windows.Forms.Button();
      this._ctrlNumCityWidth = new System.Windows.Forms.NumericUpDown();
      this._ctrlNumCityHeight = new System.Windows.Forms.NumericUpDown();
      this._ctrlMiscLbl1 = new System.Windows.Forms.Label();
      this._ctrlMiscLbl2 = new System.Windows.Forms.Label();
      this._ctrlGrBCity = new System.Windows.Forms.GroupBox();
      this._ctrlGrBHouse = new System.Windows.Forms.GroupBox();
      this._ctrlButHouse = new System.Windows.Forms.Button();
      this._ctrlLblMisc4 = new System.Windows.Forms.Label();
      this._ctrlNumHouseWidth = new System.Windows.Forms.NumericUpDown();
      this._ctrlLblMisc3 = new System.Windows.Forms.Label();
      this._ctrlNumHouseHeigth = new System.Windows.Forms.NumericUpDown();
      this._ctrlTxbCityName = new System.Windows.Forms.TextBox();
      this._ctrlLblMisc5 = new System.Windows.Forms.Label();
      this._ctrlButReady = new System.Windows.Forms.Button();
      this._ctrlReset = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlPicBxCity)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumCityWidth)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumCityHeight)).BeginInit();
      this._ctrlGrBCity.SuspendLayout();
      this._ctrlGrBHouse.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumHouseWidth)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumHouseHeigth)).BeginInit();
      this.SuspendLayout();
      // 
      // _ctrlPicBxCity
      // 
      this._ctrlPicBxCity.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this._ctrlPicBxCity.Location = new System.Drawing.Point(12, 12);
      this._ctrlPicBxCity.Name = "_ctrlPicBxCity";
      this._ctrlPicBxCity.Size = new System.Drawing.Size(450, 450);
      this._ctrlPicBxCity.TabIndex = 0;
      this._ctrlPicBxCity.TabStop = false;
      this._ctrlPicBxCity.MouseDown += new System.Windows.Forms.MouseEventHandler(this._ctrlPicBxCity_MouseDown);
      this._ctrlPicBxCity.MouseMove += new System.Windows.Forms.MouseEventHandler(this._ctrlPicBxCity_MouseMove);
      this._ctrlPicBxCity.MouseUp += new System.Windows.Forms.MouseEventHandler(this._ctrlPicBxCity_MouseUp);
      // 
      // _ctrlButMark
      // 
      this._ctrlButMark.Location = new System.Drawing.Point(6, 68);
      this._ctrlButMark.Name = "_ctrlButMark";
      this._ctrlButMark.Size = new System.Drawing.Size(97, 26);
      this._ctrlButMark.TabIndex = 1;
      this._ctrlButMark.Text = "Разметить";
      this._ctrlButMark.UseVisualStyleBackColor = true;
      this._ctrlButMark.Click += new System.EventHandler(this.button1_Click);
      // 
      // _ctrlNumCityWidth
      // 
      this._ctrlNumCityWidth.Location = new System.Drawing.Point(55, 13);
      this._ctrlNumCityWidth.Name = "_ctrlNumCityWidth";
      this._ctrlNumCityWidth.Size = new System.Drawing.Size(48, 20);
      this._ctrlNumCityWidth.TabIndex = 2;
      this._ctrlNumCityWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // _ctrlNumCityHeight
      // 
      this._ctrlNumCityHeight.Location = new System.Drawing.Point(55, 42);
      this._ctrlNumCityHeight.Name = "_ctrlNumCityHeight";
      this._ctrlNumCityHeight.Size = new System.Drawing.Size(48, 20);
      this._ctrlNumCityHeight.TabIndex = 3;
      this._ctrlNumCityHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // _ctrlMiscLbl1
      // 
      this._ctrlMiscLbl1.AutoSize = true;
      this._ctrlMiscLbl1.Location = new System.Drawing.Point(3, 15);
      this._ctrlMiscLbl1.Name = "_ctrlMiscLbl1";
      this._ctrlMiscLbl1.Size = new System.Drawing.Size(46, 13);
      this._ctrlMiscLbl1.TabIndex = 4;
      this._ctrlMiscLbl1.Text = "Ширина";
      // 
      // _ctrlMiscLbl2
      // 
      this._ctrlMiscLbl2.AutoSize = true;
      this._ctrlMiscLbl2.Location = new System.Drawing.Point(3, 44);
      this._ctrlMiscLbl2.Name = "_ctrlMiscLbl2";
      this._ctrlMiscLbl2.Size = new System.Drawing.Size(45, 13);
      this._ctrlMiscLbl2.TabIndex = 5;
      this._ctrlMiscLbl2.Text = "Высота";
      // 
      // _ctrlGrBCity
      // 
      this._ctrlGrBCity.Controls.Add(this._ctrlButMark);
      this._ctrlGrBCity.Controls.Add(this._ctrlMiscLbl2);
      this._ctrlGrBCity.Controls.Add(this._ctrlNumCityWidth);
      this._ctrlGrBCity.Controls.Add(this._ctrlMiscLbl1);
      this._ctrlGrBCity.Controls.Add(this._ctrlNumCityHeight);
      this._ctrlGrBCity.Location = new System.Drawing.Point(468, 64);
      this._ctrlGrBCity.Name = "_ctrlGrBCity";
      this._ctrlGrBCity.Size = new System.Drawing.Size(113, 100);
      this._ctrlGrBCity.TabIndex = 6;
      this._ctrlGrBCity.TabStop = false;
      this._ctrlGrBCity.Text = "Разметка города";
      // 
      // _ctrlGrBHouse
      // 
      this._ctrlGrBHouse.Controls.Add(this._ctrlButHouse);
      this._ctrlGrBHouse.Controls.Add(this._ctrlLblMisc4);
      this._ctrlGrBHouse.Controls.Add(this._ctrlNumHouseWidth);
      this._ctrlGrBHouse.Controls.Add(this._ctrlLblMisc3);
      this._ctrlGrBHouse.Controls.Add(this._ctrlNumHouseHeigth);
      this._ctrlGrBHouse.Location = new System.Drawing.Point(468, 184);
      this._ctrlGrBHouse.Name = "_ctrlGrBHouse";
      this._ctrlGrBHouse.Size = new System.Drawing.Size(113, 100);
      this._ctrlGrBHouse.TabIndex = 7;
      this._ctrlGrBHouse.TabStop = false;
      this._ctrlGrBHouse.Text = "Вставка дома";
      // 
      // _ctrlButHouse
      // 
      this._ctrlButHouse.Location = new System.Drawing.Point(6, 68);
      this._ctrlButHouse.Name = "_ctrlButHouse";
      this._ctrlButHouse.Size = new System.Drawing.Size(97, 26);
      this._ctrlButHouse.TabIndex = 1;
      this._ctrlButHouse.Text = "Установить";
      this._ctrlButHouse.UseVisualStyleBackColor = true;
      this._ctrlButHouse.Click += new System.EventHandler(this._ctrlButHouse_Click);
      // 
      // _ctrlLblMisc4
      // 
      this._ctrlLblMisc4.AutoSize = true;
      this._ctrlLblMisc4.Location = new System.Drawing.Point(3, 44);
      this._ctrlLblMisc4.Name = "_ctrlLblMisc4";
      this._ctrlLblMisc4.Size = new System.Drawing.Size(45, 13);
      this._ctrlLblMisc4.TabIndex = 5;
      this._ctrlLblMisc4.Text = "Высота";
      // 
      // _ctrlNumHouseWidth
      // 
      this._ctrlNumHouseWidth.Location = new System.Drawing.Point(55, 13);
      this._ctrlNumHouseWidth.Name = "_ctrlNumHouseWidth";
      this._ctrlNumHouseWidth.Size = new System.Drawing.Size(48, 20);
      this._ctrlNumHouseWidth.TabIndex = 2;
      this._ctrlNumHouseWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // _ctrlLblMisc3
      // 
      this._ctrlLblMisc3.AutoSize = true;
      this._ctrlLblMisc3.Location = new System.Drawing.Point(3, 15);
      this._ctrlLblMisc3.Name = "_ctrlLblMisc3";
      this._ctrlLblMisc3.Size = new System.Drawing.Size(46, 13);
      this._ctrlLblMisc3.TabIndex = 4;
      this._ctrlLblMisc3.Text = "Ширина";
      // 
      // _ctrlNumHouseHeigth
      // 
      this._ctrlNumHouseHeigth.Location = new System.Drawing.Point(55, 42);
      this._ctrlNumHouseHeigth.Name = "_ctrlNumHouseHeigth";
      this._ctrlNumHouseHeigth.Size = new System.Drawing.Size(48, 20);
      this._ctrlNumHouseHeigth.TabIndex = 3;
      this._ctrlNumHouseHeigth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // _ctrlTxbCityName
      // 
      this._ctrlTxbCityName.Location = new System.Drawing.Point(468, 38);
      this._ctrlTxbCityName.Name = "_ctrlTxbCityName";
      this._ctrlTxbCityName.Size = new System.Drawing.Size(113, 20);
      this._ctrlTxbCityName.TabIndex = 8;
      this._ctrlTxbCityName.Text = "Город";
      // 
      // _ctrlLblMisc5
      // 
      this._ctrlLblMisc5.AutoSize = true;
      this._ctrlLblMisc5.Location = new System.Drawing.Point(476, 22);
      this._ctrlLblMisc5.Name = "_ctrlLblMisc5";
      this._ctrlLblMisc5.Size = new System.Drawing.Size(95, 13);
      this._ctrlLblMisc5.TabIndex = 9;
      this._ctrlLblMisc5.Text = "Название города";
      // 
      // _ctrlButReady
      // 
      this._ctrlButReady.Location = new System.Drawing.Point(468, 439);
      this._ctrlButReady.Name = "_ctrlButReady";
      this._ctrlButReady.Size = new System.Drawing.Size(113, 23);
      this._ctrlButReady.TabIndex = 10;
      this._ctrlButReady.Text = "Готово";
      this._ctrlButReady.UseVisualStyleBackColor = true;
      this._ctrlButReady.Click += new System.EventHandler(this._ctrlButReady_Click);
      // 
      // _ctrlReset
      // 
      this._ctrlReset.Location = new System.Drawing.Point(468, 348);
      this._ctrlReset.Name = "_ctrlReset";
      this._ctrlReset.Size = new System.Drawing.Size(113, 23);
      this._ctrlReset.TabIndex = 11;
      this._ctrlReset.Text = "Сброс";
      this._ctrlReset.UseVisualStyleBackColor = true;
      this._ctrlReset.Click += new System.EventHandler(this._ctrlReset_Click);
      // 
      // _FormCity
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(736, 556);
      this.Controls.Add(this._ctrlReset);
      this.Controls.Add(this._ctrlButReady);
      this.Controls.Add(this._ctrlLblMisc5);
      this.Controls.Add(this._ctrlTxbCityName);
      this.Controls.Add(this._ctrlGrBHouse);
      this.Controls.Add(this._ctrlGrBCity);
      this.Controls.Add(this._ctrlPicBxCity);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "_FormCity";
      this.Text = "Редактор города";
      this.Load += new System.EventHandler(this._FormCity_Load);
      ((System.ComponentModel.ISupportInitialize)(this._ctrlPicBxCity)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumCityWidth)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumCityHeight)).EndInit();
      this._ctrlGrBCity.ResumeLayout(false);
      this._ctrlGrBCity.PerformLayout();
      this._ctrlGrBHouse.ResumeLayout(false);
      this._ctrlGrBHouse.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumHouseWidth)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._ctrlNumHouseHeigth)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox _ctrlPicBxCity;
    private System.Windows.Forms.Button _ctrlButMark;
    private System.Windows.Forms.NumericUpDown _ctrlNumCityWidth;
    private System.Windows.Forms.NumericUpDown _ctrlNumCityHeight;
    private System.Windows.Forms.Label _ctrlMiscLbl1;
    private System.Windows.Forms.Label _ctrlMiscLbl2;
    private System.Windows.Forms.GroupBox _ctrlGrBCity;
    private System.Windows.Forms.GroupBox _ctrlGrBHouse;
    private System.Windows.Forms.Button _ctrlButHouse;
    private System.Windows.Forms.Label _ctrlLblMisc4;
    private System.Windows.Forms.NumericUpDown _ctrlNumHouseWidth;
    private System.Windows.Forms.Label _ctrlLblMisc3;
    private System.Windows.Forms.NumericUpDown _ctrlNumHouseHeigth;
    private System.Windows.Forms.TextBox _ctrlTxbCityName;
    private System.Windows.Forms.Label _ctrlLblMisc5;
    private System.Windows.Forms.Button _ctrlButReady;
    private System.Windows.Forms.Button _ctrlReset;
  }
}
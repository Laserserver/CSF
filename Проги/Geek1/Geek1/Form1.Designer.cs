namespace Geek1
{
  partial class MainForm
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
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
      this.блокнотToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiLstAddDate = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiLstAddTime = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.tsmiLstSave = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiLstLoad = new System.Windows.Forms.ToolStripMenuItem();
      this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabLst = new System.Windows.Forms.TabPage();
      this.rtbLst = new System.Windows.Forms.RichTextBox();
      this.tabRnd = new System.Windows.Forms.TabPage();
      this.chkbxRnd = new System.Windows.Forms.CheckBox();
      this.btnRndCopy = new System.Windows.Forms.Button();
      this.btnRndClear = new System.Windows.Forms.Button();
      this.txbRnd = new System.Windows.Forms.TextBox();
      this.lblRndAns = new System.Windows.Forms.Label();
      this.lblRndTo = new System.Windows.Forms.Label();
      this.lblRndFrom = new System.Windows.Forms.Label();
      this.nudTo = new System.Windows.Forms.NumericUpDown();
      this.nudFrom = new System.Windows.Forms.NumericUpDown();
      this.btnRnd = new System.Windows.Forms.Button();
      this.tabCount = new System.Windows.Forms.TabPage();
      this.lblCount = new System.Windows.Forms.Label();
      this.butZero = new System.Windows.Forms.Button();
      this.butIncr = new System.Windows.Forms.Button();
      this.butDecr = new System.Windows.Forms.Button();
      this.tabPass = new System.Windows.Forms.TabPage();
      this.clbPass = new System.Windows.Forms.CheckedListBox();
      this.nudPassLngt = new System.Windows.Forms.NumericUpDown();
      this.lblPass = new System.Windows.Forms.Label();
      this.btnPass = new System.Windows.Forms.Button();
      this.txbPassOut = new System.Windows.Forms.TextBox();
      this.tabConv = new System.Windows.Forms.TabPage();
      this.cmbConvIn = new System.Windows.Forms.ComboBox();
      this.cmbConvOut = new System.Windows.Forms.ComboBox();
      this.btnConv = new System.Windows.Forms.Button();
      this.txbConvIn = new System.Windows.Forms.TextBox();
      this.txbConvOut = new System.Windows.Forms.TextBox();
      this.btnConvSwap = new System.Windows.Forms.Button();
      this.cmbConvMetr = new System.Windows.Forms.ComboBox();
      this.menuStrip1.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabLst.SuspendLayout();
      this.tabRnd.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudTo)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudFrom)).BeginInit();
      this.tabCount.SuspendLayout();
      this.tabPass.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudPassLngt)).BeginInit();
      this.tabConv.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.блокнотToolStripMenuItem,
            this.помощьToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(284, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // файлToolStripMenuItem
      // 
      this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExit});
      this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
      this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
      this.файлToolStripMenuItem.Text = "Файл";
      // 
      // tsmiExit
      // 
      this.tsmiExit.Name = "tsmiExit";
      this.tsmiExit.Size = new System.Drawing.Size(108, 22);
      this.tsmiExit.Text = "Выход";
      this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
      // 
      // блокнотToolStripMenuItem
      // 
      this.блокнотToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLstAddDate,
            this.tsmiLstAddTime,
            this.toolStripMenuItem1,
            this.tsmiLstSave,
            this.tsmiLstLoad});
      this.блокнотToolStripMenuItem.Name = "блокнотToolStripMenuItem";
      this.блокнотToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
      this.блокнотToolStripMenuItem.Text = "Блокнот";
      // 
      // tsmiLstAddDate
      // 
      this.tsmiLstAddDate.Name = "tsmiLstAddDate";
      this.tsmiLstAddDate.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift)
                  | System.Windows.Forms.Keys.D)));
      this.tsmiLstAddDate.Size = new System.Drawing.Size(228, 22);
      this.tsmiLstAddDate.Text = "Вставить дату";
      this.tsmiLstAddDate.Click += new System.EventHandler(this.tsmiLstAddDate_Click);
      // 
      // tsmiLstAddTime
      // 
      this.tsmiLstAddTime.Name = "tsmiLstAddTime";
      this.tsmiLstAddTime.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift)
                  | System.Windows.Forms.Keys.T)));
      this.tsmiLstAddTime.Size = new System.Drawing.Size(228, 22);
      this.tsmiLstAddTime.Text = "Вставить время";
      this.tsmiLstAddTime.Click += new System.EventHandler(this.tsmiLstAddTime_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(225, 6);
      // 
      // tsmiLstSave
      // 
      this.tsmiLstSave.Name = "tsmiLstSave";
      this.tsmiLstSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.tsmiLstSave.Size = new System.Drawing.Size(228, 22);
      this.tsmiLstSave.Text = "Сохранить";
      this.tsmiLstSave.Click += new System.EventHandler(this.tsmiLstSave_Click);
      // 
      // tsmiLstLoad
      // 
      this.tsmiLstLoad.Name = "tsmiLstLoad";
      this.tsmiLstLoad.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
      this.tsmiLstLoad.Size = new System.Drawing.Size(228, 22);
      this.tsmiLstLoad.Text = "Загрузить";
      this.tsmiLstLoad.Click += new System.EventHandler(this.tsmiLstLoad_Click);
      // 
      // помощьToolStripMenuItem
      // 
      this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout});
      this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
      this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
      this.помощьToolStripMenuItem.Text = "Помощь";
      // 
      // tsmiAbout
      // 
      this.tsmiAbout.Name = "tsmiAbout";
      this.tsmiAbout.Size = new System.Drawing.Size(149, 22);
      this.tsmiAbout.Text = "О программе";
      this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabConv);
      this.tabControl1.Controls.Add(this.tabPass);
      this.tabControl1.Controls.Add(this.tabLst);
      this.tabControl1.Controls.Add(this.tabRnd);
      this.tabControl1.Controls.Add(this.tabCount);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 24);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(284, 238);
      this.tabControl1.TabIndex = 1;
      // 
      // tabLst
      // 
      this.tabLst.Controls.Add(this.rtbLst);
      this.tabLst.Location = new System.Drawing.Point(4, 22);
      this.tabLst.Name = "tabLst";
      this.tabLst.Size = new System.Drawing.Size(276, 212);
      this.tabLst.TabIndex = 2;
      this.tabLst.Text = "Блокнот";
      this.tabLst.UseVisualStyleBackColor = true;
      // 
      // rtbLst
      // 
      this.rtbLst.Dock = System.Windows.Forms.DockStyle.Fill;
      this.rtbLst.Location = new System.Drawing.Point(0, 0);
      this.rtbLst.Name = "rtbLst";
      this.rtbLst.Size = new System.Drawing.Size(276, 212);
      this.rtbLst.TabIndex = 0;
      this.rtbLst.Text = "";
      // 
      // tabRnd
      // 
      this.tabRnd.Controls.Add(this.chkbxRnd);
      this.tabRnd.Controls.Add(this.btnRndCopy);
      this.tabRnd.Controls.Add(this.btnRndClear);
      this.tabRnd.Controls.Add(this.txbRnd);
      this.tabRnd.Controls.Add(this.lblRndAns);
      this.tabRnd.Controls.Add(this.lblRndTo);
      this.tabRnd.Controls.Add(this.lblRndFrom);
      this.tabRnd.Controls.Add(this.nudTo);
      this.tabRnd.Controls.Add(this.nudFrom);
      this.tabRnd.Controls.Add(this.btnRnd);
      this.tabRnd.Location = new System.Drawing.Point(4, 22);
      this.tabRnd.Name = "tabRnd";
      this.tabRnd.Padding = new System.Windows.Forms.Padding(3);
      this.tabRnd.Size = new System.Drawing.Size(276, 212);
      this.tabRnd.TabIndex = 1;
      this.tabRnd.Text = "Рандом";
      this.tabRnd.UseVisualStyleBackColor = true;
      // 
      // chkbxRnd
      // 
      this.chkbxRnd.AutoSize = true;
      this.chkbxRnd.Location = new System.Drawing.Point(24, 172);
      this.chkbxRnd.Name = "chkbxRnd";
      this.chkbxRnd.Size = new System.Drawing.Size(107, 17);
      this.chkbxRnd.TabIndex = 9;
      this.chkbxRnd.Text = "Без повторений";
      this.chkbxRnd.UseVisualStyleBackColor = true;
      // 
      // btnRndCopy
      // 
      this.btnRndCopy.Location = new System.Drawing.Point(16, 142);
      this.btnRndCopy.Name = "btnRndCopy";
      this.btnRndCopy.Size = new System.Drawing.Size(88, 24);
      this.btnRndCopy.TabIndex = 8;
      this.btnRndCopy.Text = "Копировать";
      this.btnRndCopy.UseVisualStyleBackColor = true;
      this.btnRndCopy.Click += new System.EventHandler(this.btnRndCopy_Click);
      // 
      // btnRndClear
      // 
      this.btnRndClear.Location = new System.Drawing.Point(16, 102);
      this.btnRndClear.Name = "btnRndClear";
      this.btnRndClear.Size = new System.Drawing.Size(75, 23);
      this.btnRndClear.TabIndex = 7;
      this.btnRndClear.Text = "Очистить";
      this.btnRndClear.UseVisualStyleBackColor = true;
      this.btnRndClear.Click += new System.EventHandler(this.btnRndClear_Click);
      // 
      // txbRnd
      // 
      this.txbRnd.Location = new System.Drawing.Point(170, 86);
      this.txbRnd.Multiline = true;
      this.txbRnd.Name = "txbRnd";
      this.txbRnd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txbRnd.Size = new System.Drawing.Size(87, 99);
      this.txbRnd.TabIndex = 6;
      // 
      // lblRndAns
      // 
      this.lblRndAns.AutoSize = true;
      this.lblRndAns.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblRndAns.Location = new System.Drawing.Point(202, 58);
      this.lblRndAns.Name = "lblRndAns";
      this.lblRndAns.Size = new System.Drawing.Size(19, 20);
      this.lblRndAns.TabIndex = 5;
      this.lblRndAns.Text = "0";
      // 
      // lblRndTo
      // 
      this.lblRndTo.AutoSize = true;
      this.lblRndTo.Location = new System.Drawing.Point(13, 68);
      this.lblRndTo.Name = "lblRndTo";
      this.lblRndTo.Size = new System.Drawing.Size(22, 13);
      this.lblRndTo.TabIndex = 4;
      this.lblRndTo.Text = "До";
      // 
      // lblRndFrom
      // 
      this.lblRndFrom.AutoSize = true;
      this.lblRndFrom.Location = new System.Drawing.Point(13, 23);
      this.lblRndFrom.Name = "lblRndFrom";
      this.lblRndFrom.Size = new System.Drawing.Size(20, 13);
      this.lblRndFrom.TabIndex = 3;
      this.lblRndFrom.Text = "От";
      // 
      // nudTo
      // 
      this.nudTo.Location = new System.Drawing.Point(65, 61);
      this.nudTo.Name = "nudTo";
      this.nudTo.Size = new System.Drawing.Size(87, 20);
      this.nudTo.TabIndex = 2;
      this.nudTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // nudFrom
      // 
      this.nudFrom.Location = new System.Drawing.Point(65, 16);
      this.nudFrom.Name = "nudFrom";
      this.nudFrom.Size = new System.Drawing.Size(88, 20);
      this.nudFrom.TabIndex = 1;
      // 
      // btnRnd
      // 
      this.btnRnd.Location = new System.Drawing.Point(170, 6);
      this.btnRnd.Name = "btnRnd";
      this.btnRnd.Size = new System.Drawing.Size(87, 30);
      this.btnRnd.TabIndex = 0;
      this.btnRnd.Text = "Задать";
      this.btnRnd.UseVisualStyleBackColor = true;
      this.btnRnd.Click += new System.EventHandler(this.btnRnd_Click);
      // 
      // tabCount
      // 
      this.tabCount.Controls.Add(this.lblCount);
      this.tabCount.Controls.Add(this.butZero);
      this.tabCount.Controls.Add(this.butIncr);
      this.tabCount.Controls.Add(this.butDecr);
      this.tabCount.Location = new System.Drawing.Point(4, 22);
      this.tabCount.Name = "tabCount";
      this.tabCount.Padding = new System.Windows.Forms.Padding(3);
      this.tabCount.Size = new System.Drawing.Size(276, 212);
      this.tabCount.TabIndex = 0;
      this.tabCount.Text = "Счётчик";
      this.tabCount.UseVisualStyleBackColor = true;
      // 
      // lblCount
      // 
      this.lblCount.AutoSize = true;
      this.lblCount.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblCount.Location = new System.Drawing.Point(94, 62);
      this.lblCount.Name = "lblCount";
      this.lblCount.Size = new System.Drawing.Size(16, 17);
      this.lblCount.TabIndex = 3;
      this.lblCount.Text = "0";
      // 
      // butZero
      // 
      this.butZero.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.butZero.Location = new System.Drawing.Point(166, 52);
      this.butZero.Name = "butZero";
      this.butZero.Size = new System.Drawing.Size(68, 32);
      this.butZero.TabIndex = 2;
      this.butZero.Text = "Сброс";
      this.butZero.UseVisualStyleBackColor = true;
      this.butZero.Click += new System.EventHandler(this.butZero_Click);
      // 
      // butIncr
      // 
      this.butIncr.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.butIncr.Location = new System.Drawing.Point(69, 17);
      this.butIncr.Name = "butIncr";
      this.butIncr.Size = new System.Drawing.Size(68, 28);
      this.butIncr.TabIndex = 1;
      this.butIncr.Text = "+";
      this.butIncr.UseVisualStyleBackColor = true;
      this.butIncr.Click += new System.EventHandler(this.butIncr_Click);
      // 
      // butDecr
      // 
      this.butDecr.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.butDecr.Location = new System.Drawing.Point(69, 95);
      this.butDecr.Name = "butDecr";
      this.butDecr.Size = new System.Drawing.Size(69, 29);
      this.butDecr.TabIndex = 0;
      this.butDecr.Text = "-";
      this.butDecr.UseVisualStyleBackColor = true;
      this.butDecr.Click += new System.EventHandler(this.butDecr_Click);
      // 
      // tabPass
      // 
      this.tabPass.Controls.Add(this.txbPassOut);
      this.tabPass.Controls.Add(this.btnPass);
      this.tabPass.Controls.Add(this.lblPass);
      this.tabPass.Controls.Add(this.nudPassLngt);
      this.tabPass.Controls.Add(this.clbPass);
      this.tabPass.Location = new System.Drawing.Point(4, 22);
      this.tabPass.Name = "tabPass";
      this.tabPass.Size = new System.Drawing.Size(276, 212);
      this.tabPass.TabIndex = 3;
      this.tabPass.Text = "Пароли";
      this.tabPass.UseVisualStyleBackColor = true;
      // 
      // clbPass
      // 
      this.clbPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.clbPass.CheckOnClick = true;
      this.clbPass.FormattingEnabled = true;
      this.clbPass.Items.AddRange(new object[] {
            "Цифры",
            "Строчные буквы",
            "Прописные буквы",
            "Спец. символы: #, $, %, &,*, @, +, -, ?"});
      this.clbPass.Location = new System.Drawing.Point(18, 17);
      this.clbPass.Name = "clbPass";
      this.clbPass.Size = new System.Drawing.Size(229, 60);
      this.clbPass.TabIndex = 0;
      // 
      // nudPassLngt
      // 
      this.nudPassLngt.Location = new System.Drawing.Point(109, 83);
      this.nudPassLngt.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
      this.nudPassLngt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudPassLngt.Name = "nudPassLngt";
      this.nudPassLngt.Size = new System.Drawing.Size(38, 20);
      this.nudPassLngt.TabIndex = 6;
      this.nudPassLngt.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
      // 
      // lblPass
      // 
      this.lblPass.AutoSize = true;
      this.lblPass.Location = new System.Drawing.Point(15, 85);
      this.lblPass.Name = "lblPass";
      this.lblPass.Size = new System.Drawing.Size(79, 13);
      this.lblPass.TabIndex = 2;
      this.lblPass.Text = "Длина пароля";
      // 
      // btnPass
      // 
      this.btnPass.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.btnPass.Location = new System.Drawing.Point(0, 189);
      this.btnPass.Name = "btnPass";
      this.btnPass.Size = new System.Drawing.Size(276, 23);
      this.btnPass.TabIndex = 3;
      this.btnPass.Text = "Создать пароль";
      this.btnPass.UseVisualStyleBackColor = true;
      this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
      // 
      // txbPassOut
      // 
      this.txbPassOut.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.txbPassOut.Location = new System.Drawing.Point(0, 169);
      this.txbPassOut.Name = "txbPassOut";
      this.txbPassOut.Size = new System.Drawing.Size(276, 20);
      this.txbPassOut.TabIndex = 4;
      // 
      // tabConv
      // 
      this.tabConv.Controls.Add(this.cmbConvMetr);
      this.tabConv.Controls.Add(this.btnConvSwap);
      this.tabConv.Controls.Add(this.txbConvOut);
      this.tabConv.Controls.Add(this.txbConvIn);
      this.tabConv.Controls.Add(this.btnConv);
      this.tabConv.Controls.Add(this.cmbConvOut);
      this.tabConv.Controls.Add(this.cmbConvIn);
      this.tabConv.Location = new System.Drawing.Point(4, 22);
      this.tabConv.Name = "tabConv";
      this.tabConv.Size = new System.Drawing.Size(276, 212);
      this.tabConv.TabIndex = 4;
      this.tabConv.Text = "Конвертер";
      this.tabConv.UseVisualStyleBackColor = true;
      // 
      // cmbConvIn
      // 
      this.cmbConvIn.FormattingEnabled = true;
      this.cmbConvIn.Items.AddRange(new object[] {
            "мм",
            "см",
            "дм",
            "м",
            "км",
            "мили"});
      this.cmbConvIn.Location = new System.Drawing.Point(5, 148);
      this.cmbConvIn.Name = "cmbConvIn";
      this.cmbConvIn.Size = new System.Drawing.Size(87, 21);
      this.cmbConvIn.TabIndex = 0;
      this.cmbConvIn.Text = "мм";
      // 
      // cmbConvOut
      // 
      this.cmbConvOut.FormattingEnabled = true;
      this.cmbConvOut.Items.AddRange(new object[] {
            "мм",
            "см",
            "дм",
            "м",
            "км",
            "мили"});
      this.cmbConvOut.Location = new System.Drawing.Point(179, 148);
      this.cmbConvOut.Name = "cmbConvOut";
      this.cmbConvOut.Size = new System.Drawing.Size(86, 21);
      this.cmbConvOut.TabIndex = 1;
      this.cmbConvOut.Text = "мм";
      // 
      // btnConv
      // 
      this.btnConv.Location = new System.Drawing.Point(98, 181);
      this.btnConv.Name = "btnConv";
      this.btnConv.Size = new System.Drawing.Size(75, 23);
      this.btnConv.TabIndex = 2;
      this.btnConv.Text = "Конверт";
      this.btnConv.UseVisualStyleBackColor = true;
      this.btnConv.Click += new System.EventHandler(this.btnConv_Click);
      // 
      // txbConvIn
      // 
      this.txbConvIn.Location = new System.Drawing.Point(5, 186);
      this.txbConvIn.Name = "txbConvIn";
      this.txbConvIn.Size = new System.Drawing.Size(87, 20);
      this.txbConvIn.TabIndex = 3;
      this.txbConvIn.Text = "1";
      // 
      // txbConvOut
      // 
      this.txbConvOut.Location = new System.Drawing.Point(179, 184);
      this.txbConvOut.Name = "txbConvOut";
      this.txbConvOut.ReadOnly = true;
      this.txbConvOut.Size = new System.Drawing.Size(86, 20);
      this.txbConvOut.TabIndex = 4;
      // 
      // btnConvSwap
      // 
      this.btnConvSwap.Location = new System.Drawing.Point(99, 148);
      this.btnConvSwap.Name = "btnConvSwap";
      this.btnConvSwap.Size = new System.Drawing.Size(75, 23);
      this.btnConvSwap.TabIndex = 5;
      this.btnConvSwap.Text = "<->";
      this.btnConvSwap.UseVisualStyleBackColor = true;
      this.btnConvSwap.Click += new System.EventHandler(this.btnConvSwap_Click);
      // 
      // cmbConvMetr
      // 
      this.cmbConvMetr.FormattingEnabled = true;
      this.cmbConvMetr.Items.AddRange(new object[] {
            "Длина",
            "Масса"});
      this.cmbConvMetr.Location = new System.Drawing.Point(99, 93);
      this.cmbConvMetr.Name = "cmbConvMetr";
      this.cmbConvMetr.Size = new System.Drawing.Size(75, 21);
      this.cmbConvMetr.TabIndex = 6;
      this.cmbConvMetr.Text = "Длина";
      this.cmbConvMetr.SelectedIndexChanged += new System.EventHandler(this.cmbConvMetr_SelectedIndexChanged);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 262);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainForm";
      this.Text = "Проект C#";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.tabControl1.ResumeLayout(false);
      this.tabLst.ResumeLayout(false);
      this.tabRnd.ResumeLayout(false);
      this.tabRnd.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudTo)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudFrom)).EndInit();
      this.tabCount.ResumeLayout(false);
      this.tabCount.PerformLayout();
      this.tabPass.ResumeLayout(false);
      this.tabPass.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudPassLngt)).EndInit();
      this.tabConv.ResumeLayout(false);
      this.tabConv.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem tsmiExit;
    private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabCount;
    private System.Windows.Forms.Label lblCount;
    private System.Windows.Forms.Button butZero;
    private System.Windows.Forms.Button butIncr;
    private System.Windows.Forms.Button butDecr;
    private System.Windows.Forms.TabPage tabRnd;
    private System.Windows.Forms.Label lblRndAns;
    private System.Windows.Forms.Label lblRndTo;
    private System.Windows.Forms.Label lblRndFrom;
    private System.Windows.Forms.NumericUpDown nudTo;
    private System.Windows.Forms.NumericUpDown nudFrom;
    private System.Windows.Forms.Button btnRnd;
    private System.Windows.Forms.TextBox txbRnd;
    private System.Windows.Forms.Button btnRndClear;
    private System.Windows.Forms.Button btnRndCopy;
    private System.Windows.Forms.CheckBox chkbxRnd;
    private System.Windows.Forms.TabPage tabLst;
    private System.Windows.Forms.RichTextBox rtbLst;
    private System.Windows.Forms.ToolStripMenuItem блокнотToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem tsmiLstAddDate;
    private System.Windows.Forms.ToolStripMenuItem tsmiLstAddTime;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem tsmiLstSave;
    private System.Windows.Forms.ToolStripMenuItem tsmiLstLoad;
    private System.Windows.Forms.TabPage tabPass;
    private System.Windows.Forms.CheckedListBox clbPass;
    private System.Windows.Forms.TextBox txbPassOut;
    private System.Windows.Forms.Button btnPass;
    private System.Windows.Forms.Label lblPass;
    private System.Windows.Forms.NumericUpDown nudPassLngt;
    private System.Windows.Forms.TabPage tabConv;
    private System.Windows.Forms.TextBox txbConvOut;
    private System.Windows.Forms.TextBox txbConvIn;
    private System.Windows.Forms.Button btnConv;
    private System.Windows.Forms.ComboBox cmbConvOut;
    private System.Windows.Forms.ComboBox cmbConvIn;
    private System.Windows.Forms.Button btnConvSwap;
    private System.Windows.Forms.ComboBox cmbConvMetr;
  }
}


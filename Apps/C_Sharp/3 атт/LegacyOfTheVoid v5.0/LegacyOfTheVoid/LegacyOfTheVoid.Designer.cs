﻿namespace ProjectRed
{
  partial class LegacyOfTheVoid
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LegacyOfTheVoid));
      this.lblHello = new System.Windows.Forms.Label();
      this.gridStudentNames = new System.Windows.Forms.DataGridView();
      this.gridStudentMarks = new System.Windows.Forms.DataGridView();
      this.gridLessonNames = new System.Windows.Forms.DataGridView();
      this.gridLessonTexts = new System.Windows.Forms.DataGridView();
      this.menuLotV = new System.Windows.Forms.MenuStrip();
      this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
      this.menuLoadStudList = new System.Windows.Forms.ToolStripMenuItem();
      this.menuLoadLessonList = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.menuLoadJournal = new System.Windows.Forms.ToolStripMenuItem();
      this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
      this.helpAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
      this.FuckYou = new System.Windows.Forms.Label();
      this.gridClasses = new System.Windows.Forms.DataGridView();
      this.grbClasses = new System.Windows.Forms.GroupBox();
      this.grbStuds = new System.Windows.Forms.GroupBox();
      this.grbLessons = new System.Windows.Forms.GroupBox();
      this.grbText = new System.Windows.Forms.GroupBox();
      this.chbStudList = new System.Windows.Forms.CheckBox();
      this.chbLessonList = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.gridStudentNames)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridStudentMarks)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridLessonNames)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridLessonTexts)).BeginInit();
      this.menuLotV.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridClasses)).BeginInit();
      this.grbClasses.SuspendLayout();
      this.grbStuds.SuspendLayout();
      this.grbLessons.SuspendLayout();
      this.grbText.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblHello
      // 
      this.lblHello.Location = new System.Drawing.Point(12, 53);
      this.lblHello.Name = "lblHello";
      this.lblHello.Size = new System.Drawing.Size(850, 40);
      this.lblHello.TabIndex = 2;
      this.lblHello.Text = resources.GetString("lblHello.Text");
      // 
      // gridStudentNames
      // 
      this.gridStudentNames.AllowUserToAddRows = false;
      this.gridStudentNames.AllowUserToDeleteRows = false;
      this.gridStudentNames.AllowUserToResizeColumns = false;
      this.gridStudentNames.AllowUserToResizeRows = false;
      this.gridStudentNames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.gridStudentNames.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
      this.gridStudentNames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gridStudentNames.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.gridStudentNames.Location = new System.Drawing.Point(5, 20);
      this.gridStudentNames.Name = "gridStudentNames";
      this.gridStudentNames.ReadOnly = true;
      this.gridStudentNames.RowHeadersVisible = false;
      this.gridStudentNames.Size = new System.Drawing.Size(135, 480);
      this.gridStudentNames.TabIndex = 2;
      // 
      // gridStudentMarks
      // 
      this.gridStudentMarks.AllowUserToAddRows = false;
      this.gridStudentMarks.AllowUserToDeleteRows = false;
      this.gridStudentMarks.AllowUserToResizeColumns = false;
      this.gridStudentMarks.AllowUserToResizeRows = false;
      this.gridStudentMarks.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
      this.gridStudentMarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gridStudentMarks.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.gridStudentMarks.Location = new System.Drawing.Point(138, 20);
      this.gridStudentMarks.Name = "gridStudentMarks";
      this.gridStudentMarks.RowHeadersVisible = false;
      this.gridStudentMarks.Size = new System.Drawing.Size(425, 480);
      this.gridStudentMarks.TabIndex = 1;
      // 
      // gridLessonNames
      // 
      this.gridLessonNames.AllowUserToAddRows = false;
      this.gridLessonNames.AllowUserToDeleteRows = false;
      this.gridLessonNames.AllowUserToResizeColumns = false;
      this.gridLessonNames.AllowUserToResizeRows = false;
      this.gridLessonNames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.gridLessonNames.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
      this.gridLessonNames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gridLessonNames.ColumnHeadersVisible = false;
      this.gridLessonNames.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.gridLessonNames.Location = new System.Drawing.Point(5, 20);
      this.gridLessonNames.Name = "gridLessonNames";
      this.gridLessonNames.ReadOnly = true;
      this.gridLessonNames.RowHeadersVisible = false;
      this.gridLessonNames.Size = new System.Drawing.Size(135, 480);
      this.gridLessonNames.TabIndex = 3;
      this.gridLessonNames.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLessonNames_CellClick);
      // 
      // gridLessonTexts
      // 
      this.gridLessonTexts.AllowUserToAddRows = false;
      this.gridLessonTexts.AllowUserToDeleteRows = false;
      this.gridLessonTexts.AllowUserToResizeColumns = false;
      this.gridLessonTexts.AllowUserToResizeRows = false;
      this.gridLessonTexts.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
      this.gridLessonTexts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gridLessonTexts.ColumnHeadersVisible = false;
      this.gridLessonTexts.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.gridLessonTexts.Location = new System.Drawing.Point(6, 20);
      this.gridLessonTexts.Name = "gridLessonTexts";
      this.gridLessonTexts.ReadOnly = true;
      this.gridLessonTexts.RowHeadersVisible = false;
      this.gridLessonTexts.Size = new System.Drawing.Size(425, 480);
      this.gridLessonTexts.TabIndex = 1;
      // 
      // menuLotV
      // 
      this.menuLotV.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.menuLotV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuHelp,
            this.helpAbout,
            this.menuClose});
      this.menuLotV.Location = new System.Drawing.Point(0, 0);
      this.menuLotV.Name = "menuLotV";
      this.menuLotV.Size = new System.Drawing.Size(1410, 24);
      this.menuLotV.TabIndex = 13;
      this.menuLotV.Text = "menuStrip1";
      // 
      // menuFile
      // 
      this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLoadStudList,
            this.menuLoadLessonList,
            this.toolStripMenuItem1,
            this.menuLoadJournal});
      this.menuFile.Name = "menuFile";
      this.menuFile.Size = new System.Drawing.Size(48, 20);
      this.menuFile.Text = "Файл";
      // 
      // menuLoadStudList
      // 
      this.menuLoadStudList.Name = "menuLoadStudList";
      this.menuLoadStudList.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.menuLoadStudList.Size = new System.Drawing.Size(265, 22);
      this.menuLoadStudList.Text = "Загрузить список учеников";
      this.menuLoadStudList.Click += new System.EventHandler(this.menuLoadStudList_Click);
      // 
      // menuLoadLessonList
      // 
      this.menuLoadLessonList.Name = "menuLoadLessonList";
      this.menuLoadLessonList.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
      this.menuLoadLessonList.Size = new System.Drawing.Size(265, 22);
      this.menuLoadLessonList.Text = "Загрузить учебный план";
      this.menuLoadLessonList.Click += new System.EventHandler(this.menuLoadLessonList_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(262, 6);
      // 
      // menuLoadJournal
      // 
      this.menuLoadJournal.Name = "menuLoadJournal";
      this.menuLoadJournal.Size = new System.Drawing.Size(265, 22);
      this.menuLoadJournal.Text = "Сохранить журнал";
      this.menuLoadJournal.Click += new System.EventHandler(this.menuLoadJournal_Click);
      // 
      // menuHelp
      // 
      this.menuHelp.Name = "menuHelp";
      this.menuHelp.Size = new System.Drawing.Size(68, 20);
      this.menuHelp.Text = "Помощь";
      this.menuHelp.Click += new System.EventHandler(this.menuHelp_Click);
      // 
      // helpAbout
      // 
      this.helpAbout.Name = "helpAbout";
      this.helpAbout.Size = new System.Drawing.Size(94, 20);
      this.helpAbout.Text = "О программе";
      this.helpAbout.Click += new System.EventHandler(this.helpAbout_Click);
      // 
      // menuClose
      // 
      this.menuClose.Name = "menuClose";
      this.menuClose.Size = new System.Drawing.Size(53, 20);
      this.menuClose.Text = "Выход";
      this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
      // 
      // FuckYou
      // 
      this.FuckYou.AutoSize = true;
      this.FuckYou.Location = new System.Drawing.Point(956, 80);
      this.FuckYou.Name = "FuckYou";
      this.FuckYou.Size = new System.Drawing.Size(183, 13);
      this.FuckYou.TabIndex = 21;
      this.FuckYou.Text = "Учебный план изменять нельзя :P";
      // 
      // gridClasses
      // 
      this.gridClasses.AllowUserToAddRows = false;
      this.gridClasses.AllowUserToDeleteRows = false;
      this.gridClasses.AllowUserToResizeColumns = false;
      this.gridClasses.AllowUserToResizeRows = false;
      this.gridClasses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.gridClasses.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
      this.gridClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gridClasses.ColumnHeadersVisible = false;
      this.gridClasses.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.gridClasses.Location = new System.Drawing.Point(5, 20);
      this.gridClasses.Name = "gridClasses";
      this.gridClasses.ReadOnly = true;
      this.gridClasses.RowHeadersVisible = false;
      this.gridClasses.Size = new System.Drawing.Size(135, 480);
      this.gridClasses.TabIndex = 22;
      this.gridClasses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridClasses_CellClick);
      // 
      // grbClasses
      // 
      this.grbClasses.Controls.Add(this.gridClasses);
      this.grbClasses.Location = new System.Drawing.Point(10, 130);
      this.grbClasses.Name = "grbClasses";
      this.grbClasses.Size = new System.Drawing.Size(145, 510);
      this.grbClasses.TabIndex = 23;
      this.grbClasses.TabStop = false;
      this.grbClasses.Text = "Классы";
      // 
      // grbStuds
      // 
      this.grbStuds.Controls.Add(this.gridStudentNames);
      this.grbStuds.Controls.Add(this.gridStudentMarks);
      this.grbStuds.Location = new System.Drawing.Point(320, 130);
      this.grbStuds.Name = "grbStuds";
      this.grbStuds.Size = new System.Drawing.Size(570, 510);
      this.grbStuds.TabIndex = 24;
      this.grbStuds.TabStop = false;
      this.grbStuds.Text = "Оценки";
      // 
      // grbLessons
      // 
      this.grbLessons.Controls.Add(this.gridLessonNames);
      this.grbLessons.Location = new System.Drawing.Point(165, 130);
      this.grbLessons.Name = "grbLessons";
      this.grbLessons.Size = new System.Drawing.Size(145, 510);
      this.grbLessons.TabIndex = 25;
      this.grbLessons.TabStop = false;
      this.grbLessons.Text = "Предметы";
      // 
      // grbText
      // 
      this.grbText.Controls.Add(this.gridLessonTexts);
      this.grbText.Location = new System.Drawing.Point(905, 130);
      this.grbText.Name = "grbText";
      this.grbText.Size = new System.Drawing.Size(440, 510);
      this.grbText.TabIndex = 26;
      this.grbText.TabStop = false;
      this.grbText.Text = "Учебный план";
      // 
      // chbStudList
      // 
      this.chbStudList.AutoSize = true;
      this.chbStudList.Enabled = false;
      this.chbStudList.Location = new System.Drawing.Point(170, 83);
      this.chbStudList.Name = "chbStudList";
      this.chbStudList.Size = new System.Drawing.Size(168, 17);
      this.chbStudList.TabIndex = 27;
      this.chbStudList.Text = "Список студентов загружен";
      this.chbStudList.ThreeState = true;
      this.chbStudList.UseVisualStyleBackColor = true;
      // 
      // chbLessonList
      // 
      this.chbLessonList.AutoSize = true;
      this.chbLessonList.Enabled = false;
      this.chbLessonList.Location = new System.Drawing.Point(170, 101);
      this.chbLessonList.Name = "chbLessonList";
      this.chbLessonList.Size = new System.Drawing.Size(149, 17);
      this.chbLessonList.TabIndex = 28;
      this.chbLessonList.Text = "Учебный план загружен";
      this.chbLessonList.UseVisualStyleBackColor = true;
      // 
      // LegacyOfTheVoid
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ControlLight;
      this.ClientSize = new System.Drawing.Size(1410, 646);
      this.Controls.Add(this.chbLessonList);
      this.Controls.Add(this.chbStudList);
      this.Controls.Add(this.grbText);
      this.Controls.Add(this.grbLessons);
      this.Controls.Add(this.grbStuds);
      this.Controls.Add(this.grbClasses);
      this.Controls.Add(this.FuckYou);
      this.Controls.Add(this.lblHello);
      this.Controls.Add(this.menuLotV);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.MainMenuStrip = this.menuLotV;
      this.Name = "LegacyOfTheVoid";
      this.Text = "Классный журнал";
      ((System.ComponentModel.ISupportInitialize)(this.gridStudentNames)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridStudentMarks)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridLessonNames)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridLessonTexts)).EndInit();
      this.menuLotV.ResumeLayout(false);
      this.menuLotV.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridClasses)).EndInit();
      this.grbClasses.ResumeLayout(false);
      this.grbStuds.ResumeLayout(false);
      this.grbLessons.ResumeLayout(false);
      this.grbText.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblHello;
    private System.Windows.Forms.DataGridView gridStudentMarks;
    private System.Windows.Forms.DataGridView gridLessonTexts;
    private System.Windows.Forms.MenuStrip menuLotV;
    private System.Windows.Forms.ToolStripMenuItem menuFile;
    private System.Windows.Forms.ToolStripMenuItem menuHelp;
    private System.Windows.Forms.ToolStripMenuItem menuClose;
    private System.Windows.Forms.ToolStripMenuItem menuLoadStudList;
    private System.Windows.Forms.ToolStripMenuItem menuLoadLessonList;
    private System.Windows.Forms.ToolStripMenuItem helpAbout;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem menuLoadJournal;
    private System.Windows.Forms.Label FuckYou;
    private System.Windows.Forms.DataGridView gridStudentNames;
    private System.Windows.Forms.DataGridView gridLessonNames;
    private System.Windows.Forms.DataGridView gridClasses;
    private System.Windows.Forms.GroupBox grbClasses;
    private System.Windows.Forms.GroupBox grbStuds;
    private System.Windows.Forms.GroupBox grbLessons;
    private System.Windows.Forms.GroupBox grbText;
    private System.Windows.Forms.CheckBox chbStudList;
    private System.Windows.Forms.CheckBox chbLessonList;
  }
}


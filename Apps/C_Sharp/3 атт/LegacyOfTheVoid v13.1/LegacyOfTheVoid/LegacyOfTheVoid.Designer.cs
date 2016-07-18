namespace ProjectRed
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LegacyOfTheVoid));
      this.gridStudentNames = new System.Windows.Forms.DataGridView();
      this.gridStudentMarks = new System.Windows.Forms.DataGridView();
      this.gridSubjectNames = new System.Windows.Forms.DataGridView();
      this.gridThisSubjectLessons = new System.Windows.Forms.DataGridView();
      this.menuLotV = new System.Windows.Forms.MenuStrip();
      this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
      this.menuLoadStudList = new System.Windows.Forms.ToolStripMenuItem();
      this.menuLoadLessonList = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.loadJournal = new System.Windows.Forms.ToolStripMenuItem();
      this.saveJournal = new System.Windows.Forms.ToolStripMenuItem();
      this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
      this.helpAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
      this.gridClasses = new System.Windows.Forms.DataGridView();
      this.grbClasses = new System.Windows.Forms.GroupBox();
      this.grbStuds = new System.Windows.Forms.GroupBox();
      this.gridMiddleMarks = new System.Windows.Forms.DataGridView();
      this.grbLessons = new System.Windows.Forms.GroupBox();
      this.grbText = new System.Windows.Forms.GroupBox();
      this.chbStudList = new System.Windows.Forms.CheckBox();
      this.chbLessonList = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.gridStudentNames)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridStudentMarks)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridSubjectNames)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridThisSubjectLessons)).BeginInit();
      this.menuLotV.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridClasses)).BeginInit();
      this.grbClasses.SuspendLayout();
      this.grbStuds.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridMiddleMarks)).BeginInit();
      this.grbLessons.SuspendLayout();
      this.grbText.SuspendLayout();
      this.SuspendLayout();
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
      this.gridStudentNames.GridColor = System.Drawing.SystemColors.ControlText;
      this.gridStudentNames.Location = new System.Drawing.Point(5, 20);
      this.gridStudentNames.MultiSelect = false;
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
      this.gridStudentMarks.GridColor = System.Drawing.SystemColors.ControlText;
      this.gridStudentMarks.Location = new System.Drawing.Point(138, 20);
      this.gridStudentMarks.MultiSelect = false;
      this.gridStudentMarks.Name = "gridStudentMarks";
      this.gridStudentMarks.RowHeadersVisible = false;
      this.gridStudentMarks.Size = new System.Drawing.Size(358, 480);
      this.gridStudentMarks.TabIndex = 1;
      this.gridStudentMarks.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridStudentMarks_CellEndEdit);
      // 
      // gridSubjectNames
      // 
      this.gridSubjectNames.AllowUserToAddRows = false;
      this.gridSubjectNames.AllowUserToDeleteRows = false;
      this.gridSubjectNames.AllowUserToResizeColumns = false;
      this.gridSubjectNames.AllowUserToResizeRows = false;
      this.gridSubjectNames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.gridSubjectNames.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
      this.gridSubjectNames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gridSubjectNames.ColumnHeadersVisible = false;
      this.gridSubjectNames.GridColor = System.Drawing.SystemColors.ControlText;
      this.gridSubjectNames.Location = new System.Drawing.Point(5, 20);
      this.gridSubjectNames.MultiSelect = false;
      this.gridSubjectNames.Name = "gridSubjectNames";
      this.gridSubjectNames.ReadOnly = true;
      this.gridSubjectNames.RowHeadersVisible = false;
      this.gridSubjectNames.Size = new System.Drawing.Size(135, 480);
      this.gridSubjectNames.TabIndex = 3;
      this.gridSubjectNames.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLessonNames_CellClick);
      // 
      // gridThisSubjectLessons
      // 
      this.gridThisSubjectLessons.AllowUserToAddRows = false;
      this.gridThisSubjectLessons.AllowUserToDeleteRows = false;
      this.gridThisSubjectLessons.AllowUserToResizeColumns = false;
      this.gridThisSubjectLessons.AllowUserToResizeRows = false;
      this.gridThisSubjectLessons.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
      this.gridThisSubjectLessons.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
      this.gridThisSubjectLessons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.gridThisSubjectLessons.DefaultCellStyle = dataGridViewCellStyle1;
      this.gridThisSubjectLessons.GridColor = System.Drawing.SystemColors.ControlText;
      this.gridThisSubjectLessons.Location = new System.Drawing.Point(6, 20);
      this.gridThisSubjectLessons.MultiSelect = false;
      this.gridThisSubjectLessons.Name = "gridThisSubjectLessons";
      this.gridThisSubjectLessons.ReadOnly = true;
      this.gridThisSubjectLessons.RowHeadersVisible = false;
      this.gridThisSubjectLessons.Size = new System.Drawing.Size(270, 480);
      this.gridThisSubjectLessons.TabIndex = 1;
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
      this.menuLotV.Size = new System.Drawing.Size(1141, 24);
      this.menuLotV.TabIndex = 13;
      this.menuLotV.Text = "menuStrip1";
      // 
      // menuFile
      // 
      this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLoadStudList,
            this.menuLoadLessonList,
            this.toolStripMenuItem1,
            this.loadJournal,
            this.saveJournal});
      this.menuFile.Name = "menuFile";
      this.menuFile.Size = new System.Drawing.Size(48, 20);
      this.menuFile.Text = "Файл";
      // 
      // menuLoadStudList
      // 
      this.menuLoadStudList.Name = "menuLoadStudList";
      this.menuLoadStudList.Size = new System.Drawing.Size(225, 22);
      this.menuLoadStudList.Text = "Загрузить список учеников";
      this.menuLoadStudList.Click += new System.EventHandler(this.menuLoadStudList_Click);
      // 
      // menuLoadLessonList
      // 
      this.menuLoadLessonList.Name = "menuLoadLessonList";
      this.menuLoadLessonList.Size = new System.Drawing.Size(225, 22);
      this.menuLoadLessonList.Text = "Загрузить учебный план";
      this.menuLoadLessonList.Click += new System.EventHandler(this.menuLoadLessonList_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(222, 6);
      // 
      // loadJournal
      // 
      this.loadJournal.Name = "loadJournal";
      this.loadJournal.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
      this.loadJournal.Size = new System.Drawing.Size(225, 22);
      this.loadJournal.Text = "Загрузить журнал";
      this.loadJournal.Click += new System.EventHandler(this.loadJournal_Click);
      // 
      // saveJournal
      // 
      this.saveJournal.Name = "saveJournal";
      this.saveJournal.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.saveJournal.Size = new System.Drawing.Size(225, 22);
      this.saveJournal.Text = "Сохранить журнал";
      this.saveJournal.Click += new System.EventHandler(this.saveJournal_Click);
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
      this.gridClasses.GridColor = System.Drawing.SystemColors.ControlText;
      this.gridClasses.Location = new System.Drawing.Point(5, 20);
      this.gridClasses.MultiSelect = false;
      this.gridClasses.Name = "gridClasses";
      this.gridClasses.ReadOnly = true;
      this.gridClasses.RowHeadersVisible = false;
      this.gridClasses.Size = new System.Drawing.Size(93, 480);
      this.gridClasses.TabIndex = 22;
      this.gridClasses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridClasses_CellClick);
      // 
      // grbClasses
      // 
      this.grbClasses.Controls.Add(this.gridClasses);
      this.grbClasses.Location = new System.Drawing.Point(10, 77);
      this.grbClasses.Name = "grbClasses";
      this.grbClasses.Size = new System.Drawing.Size(104, 510);
      this.grbClasses.TabIndex = 23;
      this.grbClasses.TabStop = false;
      this.grbClasses.Text = "Классы";
      // 
      // grbStuds
      // 
      this.grbStuds.Controls.Add(this.gridMiddleMarks);
      this.grbStuds.Controls.Add(this.gridStudentNames);
      this.grbStuds.Controls.Add(this.gridStudentMarks);
      this.grbStuds.Location = new System.Drawing.Point(271, 77);
      this.grbStuds.Name = "grbStuds";
      this.grbStuds.Size = new System.Drawing.Size(570, 510);
      this.grbStuds.TabIndex = 24;
      this.grbStuds.TabStop = false;
      this.grbStuds.Text = "Оценки";
      // 
      // gridMiddleMarks
      // 
      this.gridMiddleMarks.AllowUserToAddRows = false;
      this.gridMiddleMarks.AllowUserToDeleteRows = false;
      this.gridMiddleMarks.AllowUserToResizeColumns = false;
      this.gridMiddleMarks.AllowUserToResizeRows = false;
      this.gridMiddleMarks.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
      this.gridMiddleMarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle2.Format = "N2";
      dataGridViewCellStyle2.NullValue = null;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.gridMiddleMarks.DefaultCellStyle = dataGridViewCellStyle2;
      this.gridMiddleMarks.GridColor = System.Drawing.SystemColors.ControlText;
      this.gridMiddleMarks.Location = new System.Drawing.Point(494, 20);
      this.gridMiddleMarks.MultiSelect = false;
      this.gridMiddleMarks.Name = "gridMiddleMarks";
      this.gridMiddleMarks.ReadOnly = true;
      this.gridMiddleMarks.RowHeadersVisible = false;
      this.gridMiddleMarks.Size = new System.Drawing.Size(70, 480);
      this.gridMiddleMarks.TabIndex = 3;
      // 
      // grbLessons
      // 
      this.grbLessons.Controls.Add(this.gridSubjectNames);
      this.grbLessons.Location = new System.Drawing.Point(120, 77);
      this.grbLessons.Name = "grbLessons";
      this.grbLessons.Size = new System.Drawing.Size(145, 510);
      this.grbLessons.TabIndex = 25;
      this.grbLessons.TabStop = false;
      this.grbLessons.Text = "Предметы";
      // 
      // grbText
      // 
      this.grbText.Controls.Add(this.gridThisSubjectLessons);
      this.grbText.Location = new System.Drawing.Point(847, 77);
      this.grbText.Name = "grbText";
      this.grbText.Size = new System.Drawing.Size(282, 510);
      this.grbText.TabIndex = 26;
      this.grbText.TabStop = false;
      this.grbText.Text = "Учебный план";
      // 
      // chbStudList
      // 
      this.chbStudList.AutoSize = true;
      this.chbStudList.Enabled = false;
      this.chbStudList.Location = new System.Drawing.Point(10, 31);
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
      this.chbLessonList.Location = new System.Drawing.Point(10, 54);
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
      this.ClientSize = new System.Drawing.Size(1141, 591);
      this.Controls.Add(this.chbLessonList);
      this.Controls.Add(this.chbStudList);
      this.Controls.Add(this.grbText);
      this.Controls.Add(this.grbLessons);
      this.Controls.Add(this.grbStuds);
      this.Controls.Add(this.grbClasses);
      this.Controls.Add(this.menuLotV);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuLotV;
      this.Name = "LegacyOfTheVoid";
      this.Text = "Классный журнал";
      ((System.ComponentModel.ISupportInitialize)(this.gridStudentNames)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridStudentMarks)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridSubjectNames)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridThisSubjectLessons)).EndInit();
      this.menuLotV.ResumeLayout(false);
      this.menuLotV.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridClasses)).EndInit();
      this.grbClasses.ResumeLayout(false);
      this.grbStuds.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridMiddleMarks)).EndInit();
      this.grbLessons.ResumeLayout(false);
      this.grbText.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataGridView gridStudentMarks;
    private System.Windows.Forms.DataGridView gridThisSubjectLessons;
    private System.Windows.Forms.MenuStrip menuLotV;
    private System.Windows.Forms.ToolStripMenuItem menuFile;
    private System.Windows.Forms.ToolStripMenuItem menuHelp;
    private System.Windows.Forms.ToolStripMenuItem menuClose;
    private System.Windows.Forms.ToolStripMenuItem menuLoadStudList;
    private System.Windows.Forms.ToolStripMenuItem menuLoadLessonList;
    private System.Windows.Forms.ToolStripMenuItem helpAbout;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem saveJournal;
    private System.Windows.Forms.DataGridView gridStudentNames;
    private System.Windows.Forms.DataGridView gridSubjectNames;
    private System.Windows.Forms.DataGridView gridClasses;
    private System.Windows.Forms.GroupBox grbClasses;
    private System.Windows.Forms.GroupBox grbStuds;
    private System.Windows.Forms.GroupBox grbLessons;
    private System.Windows.Forms.GroupBox grbText;
    private System.Windows.Forms.CheckBox chbStudList;
    private System.Windows.Forms.CheckBox chbLessonList;
    private System.Windows.Forms.ToolStripMenuItem loadJournal;
    private System.Windows.Forms.DataGridView gridMiddleMarks;
  }
}


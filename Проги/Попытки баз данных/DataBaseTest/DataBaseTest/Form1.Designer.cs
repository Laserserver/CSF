namespace DataBaseTest
{
  partial class Form1
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
      this.components = new System.ComponentModel.Container();
      this.MexDBBinder = new System.Windows.Forms.BindingSource(this.components);
      this.ctrlDGVClasses = new System.Windows.Forms.DataGridView();
      this.ctrlDGVSubjects = new System.Windows.Forms.DataGridView();
      this.ctrlDGVNames = new System.Windows.Forms.DataGridView();
      this.ctrlDGVMarks = new System.Windows.Forms.DataGridView();
      this.ctrlDGVThemes = new System.Windows.Forms.DataGridView();
      this.mexDBDataSet = new DataBaseTest.MexDBDataSet();
      this.tableClassesBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.tableClassesTableAdapter = new DataBaseTest.MexDBDataSetTableAdapters.TableClassesTableAdapter();
      this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.classNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.classLetterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tableSubjectsBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.tableSubjectsTableAdapter = new DataBaseTest.MexDBDataSetTableAdapters.TableSubjectsTableAdapter();
      this.iDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.classIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.subjectNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tableStudentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.tableStudentsTableAdapter = new DataBaseTest.MexDBDataSetTableAdapters.TableStudentsTableAdapter();
      this.iDDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.classIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.studentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.studentSurnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tableMarksBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.tableMarksTableAdapter = new DataBaseTest.MexDBDataSetTableAdapters.TableMarksTableAdapter();
      this.iDDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.themeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.studentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.markDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tableThemesBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.tableThemesTableAdapter = new DataBaseTest.MexDBDataSetTableAdapters.TableThemesTableAdapter();
      this.iDDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.subjectIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dateDayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dateMonthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dateYearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.themeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.homeWorkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.MexDBBinder)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ctrlDGVClasses)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ctrlDGVSubjects)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ctrlDGVNames)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ctrlDGVMarks)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ctrlDGVThemes)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.mexDBDataSet)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.tableClassesBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.tableSubjectsBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.tableStudentsBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.tableMarksBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.tableThemesBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // MexDBBinder
      // 
      this.MexDBBinder.DataSource = this.mexDBDataSet;
      this.MexDBBinder.Position = 0;
      // 
      // ctrlDGVClasses
      // 
      this.ctrlDGVClasses.AutoGenerateColumns = false;
      this.ctrlDGVClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.ctrlDGVClasses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.classNumberDataGridViewTextBoxColumn,
            this.classLetterDataGridViewTextBoxColumn});
      this.ctrlDGVClasses.DataSource = this.tableClassesBindingSource;
      this.ctrlDGVClasses.Location = new System.Drawing.Point(25, 57);
      this.ctrlDGVClasses.Name = "ctrlDGVClasses";
      this.ctrlDGVClasses.Size = new System.Drawing.Size(129, 468);
      this.ctrlDGVClasses.TabIndex = 0;
      // 
      // ctrlDGVSubjects
      // 
      this.ctrlDGVSubjects.AutoGenerateColumns = false;
      this.ctrlDGVSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.ctrlDGVSubjects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn1,
            this.classIDDataGridViewTextBoxColumn,
            this.subjectNameDataGridViewTextBoxColumn});
      this.ctrlDGVSubjects.DataSource = this.tableSubjectsBindingSource;
      this.ctrlDGVSubjects.Location = new System.Drawing.Point(180, 57);
      this.ctrlDGVSubjects.Name = "ctrlDGVSubjects";
      this.ctrlDGVSubjects.Size = new System.Drawing.Size(121, 468);
      this.ctrlDGVSubjects.TabIndex = 1;
      // 
      // ctrlDGVNames
      // 
      this.ctrlDGVNames.AutoGenerateColumns = false;
      this.ctrlDGVNames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.ctrlDGVNames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn2,
            this.classIDDataGridViewTextBoxColumn1,
            this.studentNameDataGridViewTextBoxColumn,
            this.studentSurnameDataGridViewTextBoxColumn});
      this.ctrlDGVNames.DataSource = this.tableStudentsBindingSource;
      this.ctrlDGVNames.Location = new System.Drawing.Point(337, 57);
      this.ctrlDGVNames.Name = "ctrlDGVNames";
      this.ctrlDGVNames.Size = new System.Drawing.Size(113, 468);
      this.ctrlDGVNames.TabIndex = 2;
      // 
      // ctrlDGVMarks
      // 
      this.ctrlDGVMarks.AutoGenerateColumns = false;
      this.ctrlDGVMarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.ctrlDGVMarks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn3,
            this.themeIDDataGridViewTextBoxColumn,
            this.studentIDDataGridViewTextBoxColumn,
            this.markDataGridViewTextBoxColumn});
      this.ctrlDGVMarks.DataSource = this.tableMarksBindingSource;
      this.ctrlDGVMarks.Location = new System.Drawing.Point(474, 57);
      this.ctrlDGVMarks.Name = "ctrlDGVMarks";
      this.ctrlDGVMarks.Size = new System.Drawing.Size(279, 467);
      this.ctrlDGVMarks.TabIndex = 3;
      // 
      // ctrlDGVThemes
      // 
      this.ctrlDGVThemes.AutoGenerateColumns = false;
      this.ctrlDGVThemes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.ctrlDGVThemes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn4,
            this.subjectIDDataGridViewTextBoxColumn,
            this.dateDayDataGridViewTextBoxColumn,
            this.dateMonthDataGridViewTextBoxColumn,
            this.dateYearDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.themeDataGridViewTextBoxColumn,
            this.homeWorkDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn});
      this.ctrlDGVThemes.DataSource = this.tableThemesBindingSource;
      this.ctrlDGVThemes.Location = new System.Drawing.Point(880, 57);
      this.ctrlDGVThemes.Name = "ctrlDGVThemes";
      this.ctrlDGVThemes.Size = new System.Drawing.Size(233, 466);
      this.ctrlDGVThemes.TabIndex = 4;
      // 
      // mexDBDataSet
      // 
      this.mexDBDataSet.DataSetName = "MexDBDataSet";
      this.mexDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // tableClassesBindingSource
      // 
      this.tableClassesBindingSource.DataMember = "TableClasses";
      this.tableClassesBindingSource.DataSource = this.MexDBBinder;
      // 
      // tableClassesTableAdapter
      // 
      this.tableClassesTableAdapter.ClearBeforeFill = true;
      // 
      // iDDataGridViewTextBoxColumn
      // 
      this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
      this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
      this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
      this.iDDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // classNumberDataGridViewTextBoxColumn
      // 
      this.classNumberDataGridViewTextBoxColumn.DataPropertyName = "ClassNumber";
      this.classNumberDataGridViewTextBoxColumn.HeaderText = "ClassNumber";
      this.classNumberDataGridViewTextBoxColumn.Name = "classNumberDataGridViewTextBoxColumn";
      // 
      // classLetterDataGridViewTextBoxColumn
      // 
      this.classLetterDataGridViewTextBoxColumn.DataPropertyName = "ClassLetter";
      this.classLetterDataGridViewTextBoxColumn.HeaderText = "ClassLetter";
      this.classLetterDataGridViewTextBoxColumn.Name = "classLetterDataGridViewTextBoxColumn";
      // 
      // tableSubjectsBindingSource
      // 
      this.tableSubjectsBindingSource.DataMember = "TableSubjects";
      this.tableSubjectsBindingSource.DataSource = this.MexDBBinder;
      // 
      // tableSubjectsTableAdapter
      // 
      this.tableSubjectsTableAdapter.ClearBeforeFill = true;
      // 
      // iDDataGridViewTextBoxColumn1
      // 
      this.iDDataGridViewTextBoxColumn1.DataPropertyName = "ID";
      this.iDDataGridViewTextBoxColumn1.HeaderText = "ID";
      this.iDDataGridViewTextBoxColumn1.Name = "iDDataGridViewTextBoxColumn1";
      this.iDDataGridViewTextBoxColumn1.ReadOnly = true;
      // 
      // classIDDataGridViewTextBoxColumn
      // 
      this.classIDDataGridViewTextBoxColumn.DataPropertyName = "ClassID";
      this.classIDDataGridViewTextBoxColumn.HeaderText = "ClassID";
      this.classIDDataGridViewTextBoxColumn.Name = "classIDDataGridViewTextBoxColumn";
      // 
      // subjectNameDataGridViewTextBoxColumn
      // 
      this.subjectNameDataGridViewTextBoxColumn.DataPropertyName = "SubjectName";
      this.subjectNameDataGridViewTextBoxColumn.HeaderText = "SubjectName";
      this.subjectNameDataGridViewTextBoxColumn.Name = "subjectNameDataGridViewTextBoxColumn";
      // 
      // tableStudentsBindingSource
      // 
      this.tableStudentsBindingSource.DataMember = "TableStudents";
      this.tableStudentsBindingSource.DataSource = this.MexDBBinder;
      // 
      // tableStudentsTableAdapter
      // 
      this.tableStudentsTableAdapter.ClearBeforeFill = true;
      // 
      // iDDataGridViewTextBoxColumn2
      // 
      this.iDDataGridViewTextBoxColumn2.DataPropertyName = "ID";
      this.iDDataGridViewTextBoxColumn2.HeaderText = "ID";
      this.iDDataGridViewTextBoxColumn2.Name = "iDDataGridViewTextBoxColumn2";
      this.iDDataGridViewTextBoxColumn2.ReadOnly = true;
      // 
      // classIDDataGridViewTextBoxColumn1
      // 
      this.classIDDataGridViewTextBoxColumn1.DataPropertyName = "ClassID";
      this.classIDDataGridViewTextBoxColumn1.HeaderText = "ClassID";
      this.classIDDataGridViewTextBoxColumn1.Name = "classIDDataGridViewTextBoxColumn1";
      // 
      // studentNameDataGridViewTextBoxColumn
      // 
      this.studentNameDataGridViewTextBoxColumn.DataPropertyName = "StudentName";
      this.studentNameDataGridViewTextBoxColumn.HeaderText = "StudentName";
      this.studentNameDataGridViewTextBoxColumn.Name = "studentNameDataGridViewTextBoxColumn";
      // 
      // studentSurnameDataGridViewTextBoxColumn
      // 
      this.studentSurnameDataGridViewTextBoxColumn.DataPropertyName = "StudentSurname";
      this.studentSurnameDataGridViewTextBoxColumn.HeaderText = "StudentSurname";
      this.studentSurnameDataGridViewTextBoxColumn.Name = "studentSurnameDataGridViewTextBoxColumn";
      // 
      // tableMarksBindingSource
      // 
      this.tableMarksBindingSource.DataMember = "TableMarks";
      this.tableMarksBindingSource.DataSource = this.MexDBBinder;
      // 
      // tableMarksTableAdapter
      // 
      this.tableMarksTableAdapter.ClearBeforeFill = true;
      // 
      // iDDataGridViewTextBoxColumn3
      // 
      this.iDDataGridViewTextBoxColumn3.DataPropertyName = "ID";
      this.iDDataGridViewTextBoxColumn3.HeaderText = "ID";
      this.iDDataGridViewTextBoxColumn3.Name = "iDDataGridViewTextBoxColumn3";
      this.iDDataGridViewTextBoxColumn3.ReadOnly = true;
      // 
      // themeIDDataGridViewTextBoxColumn
      // 
      this.themeIDDataGridViewTextBoxColumn.DataPropertyName = "ThemeID";
      this.themeIDDataGridViewTextBoxColumn.HeaderText = "ThemeID";
      this.themeIDDataGridViewTextBoxColumn.Name = "themeIDDataGridViewTextBoxColumn";
      // 
      // studentIDDataGridViewTextBoxColumn
      // 
      this.studentIDDataGridViewTextBoxColumn.DataPropertyName = "StudentID";
      this.studentIDDataGridViewTextBoxColumn.HeaderText = "StudentID";
      this.studentIDDataGridViewTextBoxColumn.Name = "studentIDDataGridViewTextBoxColumn";
      // 
      // markDataGridViewTextBoxColumn
      // 
      this.markDataGridViewTextBoxColumn.DataPropertyName = "Mark";
      this.markDataGridViewTextBoxColumn.HeaderText = "Mark";
      this.markDataGridViewTextBoxColumn.Name = "markDataGridViewTextBoxColumn";
      // 
      // tableThemesBindingSource
      // 
      this.tableThemesBindingSource.DataMember = "TableThemes";
      this.tableThemesBindingSource.DataSource = this.MexDBBinder;
      // 
      // tableThemesTableAdapter
      // 
      this.tableThemesTableAdapter.ClearBeforeFill = true;
      // 
      // iDDataGridViewTextBoxColumn4
      // 
      this.iDDataGridViewTextBoxColumn4.DataPropertyName = "ID";
      this.iDDataGridViewTextBoxColumn4.HeaderText = "ID";
      this.iDDataGridViewTextBoxColumn4.Name = "iDDataGridViewTextBoxColumn4";
      this.iDDataGridViewTextBoxColumn4.ReadOnly = true;
      // 
      // subjectIDDataGridViewTextBoxColumn
      // 
      this.subjectIDDataGridViewTextBoxColumn.DataPropertyName = "SubjectID";
      this.subjectIDDataGridViewTextBoxColumn.HeaderText = "SubjectID";
      this.subjectIDDataGridViewTextBoxColumn.Name = "subjectIDDataGridViewTextBoxColumn";
      // 
      // dateDayDataGridViewTextBoxColumn
      // 
      this.dateDayDataGridViewTextBoxColumn.DataPropertyName = "DateDay";
      this.dateDayDataGridViewTextBoxColumn.HeaderText = "DateDay";
      this.dateDayDataGridViewTextBoxColumn.Name = "dateDayDataGridViewTextBoxColumn";
      // 
      // dateMonthDataGridViewTextBoxColumn
      // 
      this.dateMonthDataGridViewTextBoxColumn.DataPropertyName = "DateMonth";
      this.dateMonthDataGridViewTextBoxColumn.HeaderText = "DateMonth";
      this.dateMonthDataGridViewTextBoxColumn.Name = "dateMonthDataGridViewTextBoxColumn";
      // 
      // dateYearDataGridViewTextBoxColumn
      // 
      this.dateYearDataGridViewTextBoxColumn.DataPropertyName = "DateYear";
      this.dateYearDataGridViewTextBoxColumn.HeaderText = "DateYear";
      this.dateYearDataGridViewTextBoxColumn.Name = "dateYearDataGridViewTextBoxColumn";
      // 
      // typeDataGridViewTextBoxColumn
      // 
      this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
      this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
      this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
      // 
      // themeDataGridViewTextBoxColumn
      // 
      this.themeDataGridViewTextBoxColumn.DataPropertyName = "Theme";
      this.themeDataGridViewTextBoxColumn.HeaderText = "Theme";
      this.themeDataGridViewTextBoxColumn.Name = "themeDataGridViewTextBoxColumn";
      // 
      // homeWorkDataGridViewTextBoxColumn
      // 
      this.homeWorkDataGridViewTextBoxColumn.DataPropertyName = "HomeWork";
      this.homeWorkDataGridViewTextBoxColumn.HeaderText = "HomeWork";
      this.homeWorkDataGridViewTextBoxColumn.Name = "homeWorkDataGridViewTextBoxColumn";
      // 
      // statusDataGridViewTextBoxColumn
      // 
      this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
      this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
      this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1179, 547);
      this.Controls.Add(this.ctrlDGVThemes);
      this.Controls.Add(this.ctrlDGVMarks);
      this.Controls.Add(this.ctrlDGVNames);
      this.Controls.Add(this.ctrlDGVSubjects);
      this.Controls.Add(this.ctrlDGVClasses);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.MexDBBinder)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ctrlDGVClasses)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ctrlDGVSubjects)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ctrlDGVNames)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ctrlDGVMarks)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ctrlDGVThemes)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.mexDBDataSet)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.tableClassesBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.tableSubjectsBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.tableStudentsBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.tableMarksBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.tableThemesBindingSource)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.BindingSource MexDBBinder;
    private MexDBDataSet mexDBDataSet;
    private System.Windows.Forms.DataGridView ctrlDGVClasses;
    private System.Windows.Forms.DataGridView ctrlDGVSubjects;
    private System.Windows.Forms.DataGridView ctrlDGVNames;
    private System.Windows.Forms.DataGridView ctrlDGVMarks;
    private System.Windows.Forms.DataGridView ctrlDGVThemes;
    private System.Windows.Forms.BindingSource tableClassesBindingSource;
    private MexDBDataSetTableAdapters.TableClassesTableAdapter tableClassesTableAdapter;
    private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn classNumberDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn classLetterDataGridViewTextBoxColumn;
    private System.Windows.Forms.BindingSource tableSubjectsBindingSource;
    private MexDBDataSetTableAdapters.TableSubjectsTableAdapter tableSubjectsTableAdapter;
    private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn classIDDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn subjectNameDataGridViewTextBoxColumn;
    private System.Windows.Forms.BindingSource tableStudentsBindingSource;
    private MexDBDataSetTableAdapters.TableStudentsTableAdapter tableStudentsTableAdapter;
    private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn2;
    private System.Windows.Forms.DataGridViewTextBoxColumn classIDDataGridViewTextBoxColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn studentNameDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn studentSurnameDataGridViewTextBoxColumn;
    private System.Windows.Forms.BindingSource tableMarksBindingSource;
    private MexDBDataSetTableAdapters.TableMarksTableAdapter tableMarksTableAdapter;
    private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn3;
    private System.Windows.Forms.DataGridViewTextBoxColumn themeIDDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn studentIDDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn markDataGridViewTextBoxColumn;
    private System.Windows.Forms.BindingSource tableThemesBindingSource;
    private MexDBDataSetTableAdapters.TableThemesTableAdapter tableThemesTableAdapter;
    private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn4;
    private System.Windows.Forms.DataGridViewTextBoxColumn subjectIDDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn dateDayDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn dateMonthDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn dateYearDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn themeDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn homeWorkDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
  }
}


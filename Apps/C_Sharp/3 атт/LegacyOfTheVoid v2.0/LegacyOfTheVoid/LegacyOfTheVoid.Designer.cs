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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LegacyOfTheVoid));
      this.lblHello = new System.Windows.Forms.Label();
      this.batonAddLesson = new System.Windows.Forms.Button();
      this.batonSaveData = new System.Windows.Forms.Button();
      this.batonLoadStudents = new System.Windows.Forms.Button();
      this.batonLessonPlan = new System.Windows.Forms.Button();
      this.listOfLessonTypesMarks = new System.Windows.Forms.ListBox();
      this.batonLoadData = new System.Windows.Forms.Button();
      this.tabJournal = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.gridJournal = new System.Windows.Forms.DataGridView();
      this.gridLessons = new System.Windows.Forms.DataGridView();
      this.listOfLessonTypesList = new System.Windows.Forms.ListBox();
      this.tabJournal.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridJournal)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridLessons)).BeginInit();
      this.SuspendLayout();
      // 
      // lblHello
      // 
      this.lblHello.Location = new System.Drawing.Point(12, 9);
      this.lblHello.Name = "lblHello";
      this.lblHello.Size = new System.Drawing.Size(850, 40);
      this.lblHello.TabIndex = 2;
      this.lblHello.Text = resources.GetString("lblHello.Text");
      // 
      // batonAddLesson
      // 
      this.batonAddLesson.Location = new System.Drawing.Point(12, 327);
      this.batonAddLesson.Name = "batonAddLesson";
      this.batonAddLesson.Size = new System.Drawing.Size(173, 43);
      this.batonAddLesson.TabIndex = 4;
      this.batonAddLesson.Text = "Добавить урок";
      this.batonAddLesson.UseVisualStyleBackColor = true;
      this.batonAddLesson.Click += new System.EventHandler(this.batonAddLesson_Click);
      // 
      // batonSaveData
      // 
      this.batonSaveData.Location = new System.Drawing.Point(12, 589);
      this.batonSaveData.Name = "batonSaveData";
      this.batonSaveData.Size = new System.Drawing.Size(173, 26);
      this.batonSaveData.TabIndex = 6;
      this.batonSaveData.Text = "Сохранить данные в файл";
      this.batonSaveData.UseVisualStyleBackColor = true;
      this.batonSaveData.Click += new System.EventHandler(this.batonSaveData_Click);
      // 
      // batonLoadStudents
      // 
      this.batonLoadStudents.Location = new System.Drawing.Point(12, 430);
      this.batonLoadStudents.Name = "batonLoadStudents";
      this.batonLoadStudents.Size = new System.Drawing.Size(173, 27);
      this.batonLoadStudents.TabIndex = 7;
      this.batonLoadStudents.Text = "Загрузить список учеников";
      this.batonLoadStudents.UseVisualStyleBackColor = true;
      this.batonLoadStudents.Click += new System.EventHandler(this.batonLoadStudents_Click);
      // 
      // batonLessonPlan
      // 
      this.batonLessonPlan.Location = new System.Drawing.Point(12, 463);
      this.batonLessonPlan.Name = "batonLessonPlan";
      this.batonLessonPlan.Size = new System.Drawing.Size(173, 27);
      this.batonLessonPlan.TabIndex = 8;
      this.batonLessonPlan.Text = "Загрузить учебный план";
      this.batonLessonPlan.UseVisualStyleBackColor = true;
      this.batonLessonPlan.Click += new System.EventHandler(this.batonLessonPlan_Click);
      // 
      // listOfLessonTypesMarks
      // 
      this.listOfLessonTypesMarks.FormattingEnabled = true;
      this.listOfLessonTypesMarks.Location = new System.Drawing.Point(560, 0);
      this.listOfLessonTypesMarks.Name = "listOfLessonTypesMarks";
      this.listOfLessonTypesMarks.Size = new System.Drawing.Size(107, 472);
      this.listOfLessonTypesMarks.TabIndex = 10;
      // 
      // batonLoadData
      // 
      this.batonLoadData.Location = new System.Drawing.Point(12, 536);
      this.batonLoadData.Name = "batonLoadData";
      this.batonLoadData.Size = new System.Drawing.Size(173, 36);
      this.batonLoadData.TabIndex = 11;
      this.batonLoadData.Text = "Загрузить дубилов";
      this.batonLoadData.UseVisualStyleBackColor = true;
      this.batonLoadData.Click += new System.EventHandler(this.batonLoadData_Click);
      // 
      // tabJournal
      // 
      this.tabJournal.Controls.Add(this.tabPage1);
      this.tabJournal.Controls.Add(this.tabPage2);
      this.tabJournal.Location = new System.Drawing.Point(191, 123);
      this.tabJournal.Name = "tabJournal";
      this.tabJournal.SelectedIndex = 0;
      this.tabJournal.Size = new System.Drawing.Size(671, 492);
      this.tabJournal.TabIndex = 12;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.gridJournal);
      this.tabPage1.Controls.Add(this.listOfLessonTypesMarks);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(663, 466);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Оценки";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.listOfLessonTypesList);
      this.tabPage2.Controls.Add(this.gridLessons);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(663, 466);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Уроки";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // gridJournal
      // 
      this.gridJournal.AllowUserToAddRows = false;
      this.gridJournal.AllowUserToDeleteRows = false;
      this.gridJournal.AllowUserToResizeColumns = false;
      this.gridJournal.AllowUserToResizeRows = false;
      this.gridJournal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gridJournal.ColumnHeadersVisible = false;
      this.gridJournal.Location = new System.Drawing.Point(-4, 0);
      this.gridJournal.Name = "gridJournal";
      this.gridJournal.RowHeadersVisible = false;
      this.gridJournal.Size = new System.Drawing.Size(567, 467);
      this.gridJournal.TabIndex = 1;
      // 
      // gridLessons
      // 
      this.gridLessons.AllowUserToAddRows = false;
      this.gridLessons.AllowUserToDeleteRows = false;
      this.gridLessons.AllowUserToResizeColumns = false;
      this.gridLessons.AllowUserToResizeRows = false;
      this.gridLessons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gridLessons.ColumnHeadersVisible = false;
      this.gridLessons.Location = new System.Drawing.Point(-4, 0);
      this.gridLessons.Name = "gridLessons";
      this.gridLessons.RowHeadersVisible = false;
      this.gridLessons.Size = new System.Drawing.Size(568, 467);
      this.gridLessons.TabIndex = 1;
      // 
      // listOfLessonTypesList
      // 
      this.listOfLessonTypesList.FormattingEnabled = true;
      this.listOfLessonTypesList.Location = new System.Drawing.Point(560, 0);
      this.listOfLessonTypesList.Name = "listOfLessonTypesList";
      this.listOfLessonTypesList.Size = new System.Drawing.Size(107, 472);
      this.listOfLessonTypesList.TabIndex = 11;
      // 
      // LegacyOfTheVoid
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(874, 627);
      this.Controls.Add(this.tabJournal);
      this.Controls.Add(this.batonLoadData);
      this.Controls.Add(this.batonLessonPlan);
      this.Controls.Add(this.batonLoadStudents);
      this.Controls.Add(this.batonSaveData);
      this.Controls.Add(this.batonAddLesson);
      this.Controls.Add(this.lblHello);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Name = "LegacyOfTheVoid";
      this.Text = "Классный журнал";
      this.tabJournal.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridJournal)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridLessons)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblHello;
    private System.Windows.Forms.Button batonAddLesson;
    private System.Windows.Forms.Button batonSaveData;
    private System.Windows.Forms.Button batonLoadStudents;
    private System.Windows.Forms.Button batonLessonPlan;
    private System.Windows.Forms.ListBox listOfLessonTypesMarks;
    private System.Windows.Forms.Button batonLoadData;
    private System.Windows.Forms.TabControl tabJournal;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.DataGridView gridJournal;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.DataGridView gridLessons;
    private System.Windows.Forms.ListBox listOfLessonTypesList;
  }
}


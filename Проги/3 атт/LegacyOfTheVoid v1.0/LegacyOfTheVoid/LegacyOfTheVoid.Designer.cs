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
      this.gridJournal = new System.Windows.Forms.DataGridView();
      this.lblHello = new System.Windows.Forms.Label();
      this.lblLes = new System.Windows.Forms.Label();
      this.batonAddLesson = new System.Windows.Forms.Button();
      this.batonSaveData = new System.Windows.Forms.Button();
      this.batonLoadStudents = new System.Windows.Forms.Button();
      this.batonLessonPlan = new System.Windows.Forms.Button();
      this.listOfLessonTypes = new System.Windows.Forms.ListBox();
      ((System.ComponentModel.ISupportInitialize)(this.gridJournal)).BeginInit();
      this.SuspendLayout();
      // 
      // gridJournal
      // 
      this.gridJournal.AllowUserToAddRows = false;
      this.gridJournal.AllowUserToDeleteRows = false;
      this.gridJournal.AllowUserToResizeColumns = false;
      this.gridJournal.AllowUserToResizeRows = false;
      this.gridJournal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gridJournal.ColumnHeadersVisible = false;
      this.gridJournal.Location = new System.Drawing.Point(191, 148);
      this.gridJournal.Name = "gridJournal";
      this.gridJournal.RowHeadersVisible = false;
      this.gridJournal.Size = new System.Drawing.Size(671, 467);
      this.gridJournal.TabIndex = 0;
      // 
      // lblHello
      // 
      this.lblHello.Location = new System.Drawing.Point(12, 9);
      this.lblHello.Name = "lblHello";
      this.lblHello.Size = new System.Drawing.Size(850, 40);
      this.lblHello.TabIndex = 2;
      this.lblHello.Text = resources.GetString("lblHello.Text");
      // 
      // lblLes
      // 
      this.lblLes.AutoSize = true;
      this.lblLes.Location = new System.Drawing.Point(73, 148);
      this.lblLes.Name = "lblLes";
      this.lblLes.Size = new System.Drawing.Size(52, 13);
      this.lblLes.TabIndex = 3;
      this.lblLes.Text = "Предмет";
      // 
      // batonAddLesson
      // 
      this.batonAddLesson.Location = new System.Drawing.Point(12, 327);
      this.batonAddLesson.Name = "batonAddLesson";
      this.batonAddLesson.Size = new System.Drawing.Size(173, 29);
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
      this.batonSaveData.Click += new System.EventHandler(this.batonSaveInfo_Click);
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
      // listOfLessonTypes
      // 
      this.listOfLessonTypes.FormattingEnabled = true;
      this.listOfLessonTypes.Location = new System.Drawing.Point(15, 164);
      this.listOfLessonTypes.Name = "listOfLessonTypes";
      this.listOfLessonTypes.Size = new System.Drawing.Size(173, 95);
      this.listOfLessonTypes.TabIndex = 10;
      // 
      // LegacyOfTheVoid
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(874, 627);
      this.Controls.Add(this.listOfLessonTypes);
      this.Controls.Add(this.batonLessonPlan);
      this.Controls.Add(this.batonLoadStudents);
      this.Controls.Add(this.batonSaveData);
      this.Controls.Add(this.batonAddLesson);
      this.Controls.Add(this.lblLes);
      this.Controls.Add(this.lblHello);
      this.Controls.Add(this.gridJournal);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Name = "LegacyOfTheVoid";
      this.Text = "Классный журнал";
      ((System.ComponentModel.ISupportInitialize)(this.gridJournal)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataGridView gridJournal;
    private System.Windows.Forms.Label lblHello;
    private System.Windows.Forms.Label lblLes;
    private System.Windows.Forms.Button batonAddLesson;
    private System.Windows.Forms.Button batonSaveData;
    private System.Windows.Forms.Button batonLoadStudents;
    private System.Windows.Forms.Button batonLessonPlan;
    private System.Windows.Forms.ListBox listOfLessonTypes;
  }
}


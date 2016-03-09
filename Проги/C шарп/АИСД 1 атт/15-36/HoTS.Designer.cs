namespace _15_36
{
  partial class HoTS
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
        this.ctrlLblTask = new System.Windows.Forms.Label();
        this.ctrlOFD = new System.Windows.Forms.OpenFileDialog();
        this.ctrlBaton = new System.Windows.Forms.Button();
        this.ctrlLblAnswer = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // ctrlLblTask
        // 
        this.ctrlLblTask.Location = new System.Drawing.Point(12, 9);
        this.ctrlLblTask.Name = "ctrlLblTask";
        this.ctrlLblTask.Size = new System.Drawing.Size(201, 69);
        this.ctrlLblTask.TabIndex = 0;
        this.ctrlLblTask.Text = "36. Создать очередь, информационные поля которой содержат числа из текстового фай" +
            "ла. Подсчитать число максимальных элементов списка.";
        // 
        // ctrlOFD
        // 
        this.ctrlOFD.FileName = "openFileDialog1";
        // 
        // ctrlBaton
        // 
        this.ctrlBaton.Location = new System.Drawing.Point(15, 116);
        this.ctrlBaton.Name = "ctrlBaton";
        this.ctrlBaton.Size = new System.Drawing.Size(75, 23);
        this.ctrlBaton.TabIndex = 1;
        this.ctrlBaton.Text = "Батон";
        this.ctrlBaton.UseVisualStyleBackColor = true;
        this.ctrlBaton.Click += new System.EventHandler(this.ctrlBaton_Click);
        // 
        // ctrlLblAnswer
        // 
        this.ctrlLblAnswer.AutoSize = true;
        this.ctrlLblAnswer.Location = new System.Drawing.Point(131, 121);
        this.ctrlLblAnswer.Name = "ctrlLblAnswer";
        this.ctrlLblAnswer.Size = new System.Drawing.Size(43, 13);
        this.ctrlLblAnswer.TabIndex = 2;
        this.ctrlLblAnswer.Text = "Ответ: ";
        // 
        // HoTS
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(234, 164);
        this.Controls.Add(this.ctrlLblAnswer);
        this.Controls.Add(this.ctrlBaton);
        this.Controls.Add(this.ctrlLblTask);
        this.Name = "HoTS";
        this.Text = "15-36";
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label ctrlLblTask;
    private System.Windows.Forms.OpenFileDialog ctrlOFD;
    private System.Windows.Forms.Button ctrlBaton;
    private System.Windows.Forms.Label ctrlLblAnswer;
  }
}


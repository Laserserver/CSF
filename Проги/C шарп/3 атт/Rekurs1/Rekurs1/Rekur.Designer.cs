namespace Rekurs1
{
  partial class Rekur
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
      this.rtbIn = new System.Windows.Forms.RichTextBox();
      this.lblTask = new System.Windows.Forms.Label();
      this.baton = new System.Windows.Forms.Button();
      this.lblAns = new System.Windows.Forms.Label();
      this.batonLoad = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // rtbIn
      // 
      this.rtbIn.Location = new System.Drawing.Point(12, 136);
      this.rtbIn.Name = "rtbIn";
      this.rtbIn.Size = new System.Drawing.Size(409, 348);
      this.rtbIn.TabIndex = 0;
      this.rtbIn.Text = "";
      // 
      // lblTask
      // 
      this.lblTask.Location = new System.Drawing.Point(12, 9);
      this.lblTask.Name = "lblTask";
      this.lblTask.Size = new System.Drawing.Size(409, 29);
      this.lblTask.TabIndex = 1;
      this.lblTask.Text = "1.\tОписать рекурсивную функцию для подсчёта количества запятых  в  данном текстов" +
          "ом файле.";
      // 
      // baton
      // 
      this.baton.Location = new System.Drawing.Point(15, 54);
      this.baton.Name = "baton";
      this.baton.Size = new System.Drawing.Size(131, 76);
      this.baton.TabIndex = 2;
      this.baton.Text = "Батон";
      this.baton.UseVisualStyleBackColor = true;
      this.baton.Click += new System.EventHandler(this.baton_Click);
      // 
      // lblAns
      // 
      this.lblAns.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblAns.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblAns.Location = new System.Drawing.Point(177, 54);
      this.lblAns.Name = "lblAns";
      this.lblAns.Size = new System.Drawing.Size(73, 76);
      this.lblAns.TabIndex = 3;
      this.lblAns.Text = "Ответ";
      // 
      // batonLoad
      // 
      this.batonLoad.Location = new System.Drawing.Point(290, 54);
      this.batonLoad.Name = "batonLoad";
      this.batonLoad.Size = new System.Drawing.Size(130, 75);
      this.batonLoad.TabIndex = 4;
      this.batonLoad.Text = "Загрузить из файла";
      this.batonLoad.UseVisualStyleBackColor = true;
      this.batonLoad.Click += new System.EventHandler(this.batonLoad_Click);
      // 
      // Rekur
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(432, 496);
      this.Controls.Add(this.batonLoad);
      this.Controls.Add(this.lblAns);
      this.Controls.Add(this.baton);
      this.Controls.Add(this.lblTask);
      this.Controls.Add(this.rtbIn);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Name = "Rekur";
      this.Text = "Рекурсия 1";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.RichTextBox rtbIn;
    private System.Windows.Forms.Label lblTask;
    private System.Windows.Forms.Button baton;
    private System.Windows.Forms.Label lblAns;
    private System.Windows.Forms.Button batonLoad;
  }
}


namespace Task3_test
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.but_show = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.map_of_Europe1 = new Task3_test.NewComponent.Map_of_Europe(this.components);
            this.TB_info = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // but_show
            // 
            resources.ApplyResources(this.but_show, "but_show");
            this.but_show.Name = "but_show";
            this.but_show.UseVisualStyleBackColor = true;
            this.but_show.Click += new System.EventHandler(this.but_show_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // TB_info
            // 
            resources.ApplyResources(this.TB_info, "TB_info");
            this.TB_info.Name = "TB_info";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.TB_info);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.but_show);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_show;
        private Task3_test.NewComponent.Map_of_Europe map_of_Europe1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox TB_info;
    }
}


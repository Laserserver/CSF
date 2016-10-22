namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.x_ref = new System.Windows.Forms.Button();
            this.y_ref = new System.Windows.Forms.Button();
            this.z_ref = new System.Windows.Forms.Button();
            this.reflectgroup = new System.Windows.Forms.GroupBox();
            this.resizebox = new System.Windows.Forms.GroupBox();
            this.makesmall = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.makebig = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.reflectgroup.SuspendLayout();
            this.resizebox.SuspendLayout();
            this.SuspendLayout();
            // 
            // x_ref
            // 
            this.x_ref.Location = new System.Drawing.Point(41, 19);
            this.x_ref.Name = "x_ref";
            this.x_ref.Size = new System.Drawing.Size(95, 25);
            this.x_ref.TabIndex = 0;
            this.x_ref.Text = "Отразить по У";
            this.x_ref.UseVisualStyleBackColor = true;
            this.x_ref.Click += new System.EventHandler(this.x_ref_Click);
            // 
            // y_ref
            // 
            this.y_ref.Location = new System.Drawing.Point(41, 50);
            this.y_ref.Name = "y_ref";
            this.y_ref.Size = new System.Drawing.Size(95, 26);
            this.y_ref.TabIndex = 1;
            this.y_ref.Text = "Отразить по Х";
            this.y_ref.UseVisualStyleBackColor = true;
            this.y_ref.Click += new System.EventHandler(this.y_ref_Click);
            // 
            // z_ref
            // 
            this.z_ref.Location = new System.Drawing.Point(40, 82);
            this.z_ref.Name = "z_ref";
            this.z_ref.Size = new System.Drawing.Size(95, 27);
            this.z_ref.TabIndex = 2;
            this.z_ref.Text = "Отразить по Z";
            this.z_ref.UseVisualStyleBackColor = true;
            this.z_ref.Click += new System.EventHandler(this.z_ref_Click);
            // 
            // reflectgroup
            // 
            this.reflectgroup.Controls.Add(this.z_ref);
            this.reflectgroup.Controls.Add(this.y_ref);
            this.reflectgroup.Controls.Add(this.x_ref);
            this.reflectgroup.Location = new System.Drawing.Point(998, 13);
            this.reflectgroup.Name = "reflectgroup";
            this.reflectgroup.Size = new System.Drawing.Size(183, 124);
            this.reflectgroup.TabIndex = 3;
            this.reflectgroup.TabStop = false;
            this.reflectgroup.Text = "Отражение";
            // 
            // resizebox
            // 
            this.resizebox.Controls.Add(this.makesmall);
            this.resizebox.Controls.Add(this.button2);
            this.resizebox.Controls.Add(this.button1);
            this.resizebox.Controls.Add(this.makebig);
            this.resizebox.Location = new System.Drawing.Point(999, 143);
            this.resizebox.Name = "resizebox";
            this.resizebox.Size = new System.Drawing.Size(182, 115);
            this.resizebox.TabIndex = 4;
            this.resizebox.TabStop = false;
            this.resizebox.Text = "Изменить размер";
            // 
            // makesmall
            // 
            this.makesmall.Location = new System.Drawing.Point(40, 62);
            this.makesmall.Name = "makesmall";
            this.makesmall.Size = new System.Drawing.Size(95, 27);
            this.makesmall.TabIndex = 1;
            this.makesmall.Text = "Уменьшить";
            this.makesmall.UseVisualStyleBackColor = true;
            this.makesmall.Click += new System.EventHandler(this.makesmall_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(40, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 27);
            this.button2.TabIndex = 0;
            this.button2.Text = "Увеличить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.makebig_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "Увеличить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.makebig_Click);
            // 
            // makebig
            // 
            this.makebig.Location = new System.Drawing.Point(40, 29);
            this.makebig.Name = "makebig";
            this.makebig.Size = new System.Drawing.Size(95, 27);
            this.makebig.TabIndex = 0;
            this.makebig.Text = "Увеличить";
            this.makebig.UseVisualStyleBackColor = true;
            this.makebig.Click += new System.EventHandler(this.makebig_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.checkBox1.Location = new System.Drawing.Point(1038, 280);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Автоповорот";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(1040, 306);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(76, 17);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "Проекция";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1194, 522);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.resizebox);
            this.Controls.Add(this.reflectgroup);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.Text = "Лабораторная № 4";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.reflectgroup.ResumeLayout(false);
            this.resizebox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button x_ref;
        private System.Windows.Forms.Button y_ref;
        private System.Windows.Forms.Button z_ref;
        private System.Windows.Forms.GroupBox reflectgroup;
        private System.Windows.Forms.GroupBox resizebox;
        private System.Windows.Forms.Button makesmall;
        private System.Windows.Forms.Button makebig;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox2;




    }
}


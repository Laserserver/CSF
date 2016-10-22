namespace Lab4
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.isWireframe = new System.Windows.Forms.CheckBox();
            this.perspective = new System.Windows.Forms.CheckBox();
            this.screenDist = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.radiusBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edgeCountBox = new System.Windows.Forms.TextBox();
            this.heightBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.viewPointZ = new System.Windows.Forms.TextBox();
            this.viewPointY = new System.Windows.Forms.TextBox();
            this.viewPointX = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.isWireframe);
            this.panel1.Controls.Add(this.perspective);
            this.panel1.Controls.Add(this.screenDist);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.radiusBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.edgeCountBox);
            this.panel1.Controls.Add(this.heightBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.viewPointZ);
            this.panel1.Controls.Add(this.viewPointY);
            this.panel1.Controls.Add(this.viewPointX);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(155, 431);
            this.panel1.TabIndex = 0;
            // 
            // isWireframe
            // 
            this.isWireframe.AutoSize = true;
            this.isWireframe.Location = new System.Drawing.Point(6, 312);
            this.isWireframe.Name = "isWireframe";
            this.isWireframe.Size = new System.Drawing.Size(63, 17);
            this.isWireframe.TabIndex = 16;
            this.isWireframe.Text = "Каркас";
            this.isWireframe.UseVisualStyleBackColor = true;
            // 
            // perspective
            // 
            this.perspective.AutoSize = true;
            this.perspective.Checked = true;
            this.perspective.CheckState = System.Windows.Forms.CheckState.Checked;
            this.perspective.Location = new System.Drawing.Point(6, 289);
            this.perspective.Name = "perspective";
            this.perspective.Size = new System.Drawing.Size(112, 17);
            this.perspective.TabIndex = 15;
            this.perspective.Text = "Персп. проекция";
            this.perspective.UseVisualStyleBackColor = true;
            // 
            // screenDist
            // 
            this.screenDist.Location = new System.Drawing.Point(4, 224);
            this.screenDist.Name = "screenDist";
            this.screenDist.Size = new System.Drawing.Size(128, 20);
            this.screenDist.TabIndex = 14;
            this.screenDist.Text = "800";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Расстояние до экрана";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(5, 335);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Рендеринг";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Z Точки наблюдения";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Y Точки наблюдения";
            // 
            // radiusBox
            // 
            this.radiusBox.Location = new System.Drawing.Point(5, 185);
            this.radiusBox.Name = "radiusBox";
            this.radiusBox.Size = new System.Drawing.Size(129, 20);
            this.radiusBox.TabIndex = 9;
            this.radiusBox.Text = "24";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Радиус";
            // 
            // edgeCountBox
            // 
            this.edgeCountBox.Location = new System.Drawing.Point(4, 263);
            this.edgeCountBox.Name = "edgeCountBox";
            this.edgeCountBox.Size = new System.Drawing.Size(128, 20);
            this.edgeCountBox.TabIndex = 7;
            this.edgeCountBox.Text = "12";
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(6, 146);
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(128, 20);
            this.heightBox.TabIndex = 6;
            this.heightBox.Text = "48";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Количество граней";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Высота";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "X Точки наблюдения";
            // 
            // viewPointZ
            // 
            this.viewPointZ.Location = new System.Drawing.Point(4, 107);
            this.viewPointZ.Name = "viewPointZ";
            this.viewPointZ.Size = new System.Drawing.Size(128, 20);
            this.viewPointZ.TabIndex = 2;
            this.viewPointZ.Text = "300";
            // 
            // viewPointY
            // 
            this.viewPointY.Location = new System.Drawing.Point(4, 68);
            this.viewPointY.Name = "viewPointY";
            this.viewPointY.Size = new System.Drawing.Size(128, 20);
            this.viewPointY.TabIndex = 1;
            this.viewPointY.Text = "300";
            // 
            // viewPointX
            // 
            this.viewPointX.Location = new System.Drawing.Point(4, 29);
            this.viewPointX.Name = "viewPointX";
            this.viewPointX.Size = new System.Drawing.Size(128, 20);
            this.viewPointX.TabIndex = 0;
            this.viewPointX.Text = "300";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(155, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(361, 431);
            this.panel2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 431);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edgeCountBox;
        private System.Windows.Forms.TextBox heightBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox viewPointZ;
        private System.Windows.Forms.TextBox viewPointY;
        private System.Windows.Forms.TextBox viewPointX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox radiusBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox screenDist;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox perspective;
        private System.Windows.Forms.CheckBox isWireframe;
    }
}


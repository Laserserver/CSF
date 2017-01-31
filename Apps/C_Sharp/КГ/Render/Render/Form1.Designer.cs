namespace Render
{
    partial class Form1
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
            this.renderBut = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.zoomBut = new System.Windows.Forms.Button();
            this.yMinus = new System.Windows.Forms.Button();
            this.yPlus = new System.Windows.Forms.Button();
            this.xMinus = new System.Windows.Forms.Button();
            this.xPlus = new System.Windows.Forms.Button();
            this.zoomMinus = new System.Windows.Forms.Button();
            this.isFill = new System.Windows.Forms.RadioButton();
            this.fileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.zoomBox = new System.Windows.Forms.TextBox();
            this.edgeMod = new System.Windows.Forms.RadioButton();
            this.drawing = new System.Windows.Forms.GroupBox();
            this.pointsOn = new System.Windows.Forms.CheckBox();
            this.aa = new System.Windows.Forms.Label();
            this.light = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.normalsOff = new System.Windows.Forms.RadioButton();
            this.normalsOn = new System.Windows.Forms.RadioButton();
            this.coefControl = new System.Windows.Forms.TextBox();
            this.coefCtrl = new System.Windows.Forms.Label();
            this.turnV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.turnMinus = new System.Windows.Forms.Button();
            this.turnPlus = new System.Windows.Forms.Button();
            this.turnOX = new System.Windows.Forms.CheckBox();
            this.softLightning = new System.Windows.Forms.CheckBox();
            this.deepCoef = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.zoomConstT = new System.Windows.Forms.TextBox();
            this.drawing.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // renderBut
            // 
            this.renderBut.Location = new System.Drawing.Point(2616, 22);
            this.renderBut.Margin = new System.Windows.Forms.Padding(5);
            this.renderBut.Name = "renderBut";
            this.renderBut.Size = new System.Drawing.Size(131, 42);
            this.renderBut.TabIndex = 0;
            this.renderBut.Text = "Render";
            this.renderBut.UseVisualStyleBackColor = true;
            this.renderBut.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(2684, 74);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 42);
            this.button2.TabIndex = 2;
            this.button2.Text = ">>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(2606, 74);
            this.button3.Margin = new System.Windows.Forms.Padding(5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(68, 42);
            this.button3.TabIndex = 3;
            this.button3.Text = "<<";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(21, 22);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2512, 1854);
            this.panel1.TabIndex = 4;
            this.panel1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel1_Scroll);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // zoomBut
            // 
            this.zoomBut.Location = new System.Drawing.Point(2612, 126);
            this.zoomBut.Margin = new System.Windows.Forms.Padding(5);
            this.zoomBut.Name = "zoomBut";
            this.zoomBut.Size = new System.Drawing.Size(131, 42);
            this.zoomBut.TabIndex = 5;
            this.zoomBut.Text = "zoom";
            this.zoomBut.UseVisualStyleBackColor = true;
            this.zoomBut.Click += new System.EventHandler(this.zoomBut_Click);
            // 
            // yMinus
            // 
            this.yMinus.Location = new System.Drawing.Point(2651, 312);
            this.yMinus.Margin = new System.Windows.Forms.Padding(5);
            this.yMinus.Name = "yMinus";
            this.yMinus.Size = new System.Drawing.Size(51, 50);
            this.yMinus.TabIndex = 6;
            this.yMinus.Text = "^";
            this.yMinus.UseVisualStyleBackColor = true;
            this.yMinus.Click += new System.EventHandler(this.yMinus_Click);
            // 
            // yPlus
            // 
            this.yPlus.Location = new System.Drawing.Point(2651, 429);
            this.yPlus.Margin = new System.Windows.Forms.Padding(5);
            this.yPlus.Name = "yPlus";
            this.yPlus.Size = new System.Drawing.Size(51, 50);
            this.yPlus.TabIndex = 7;
            this.yPlus.Text = "\\/";
            this.yPlus.UseVisualStyleBackColor = true;
            this.yPlus.Click += new System.EventHandler(this.yPlus_Click);
            // 
            // xMinus
            // 
            this.xMinus.Location = new System.Drawing.Point(2590, 371);
            this.xMinus.Margin = new System.Windows.Forms.Padding(5);
            this.xMinus.Name = "xMinus";
            this.xMinus.Size = new System.Drawing.Size(51, 50);
            this.xMinus.TabIndex = 8;
            this.xMinus.Text = "<";
            this.xMinus.UseVisualStyleBackColor = true;
            this.xMinus.Click += new System.EventHandler(this.xMinus_Click);
            // 
            // xPlus
            // 
            this.xPlus.Location = new System.Drawing.Point(2711, 371);
            this.xPlus.Margin = new System.Windows.Forms.Padding(5);
            this.xPlus.Name = "xPlus";
            this.xPlus.Size = new System.Drawing.Size(51, 50);
            this.xPlus.TabIndex = 9;
            this.xPlus.Text = ">";
            this.xPlus.UseVisualStyleBackColor = true;
            this.xPlus.Click += new System.EventHandler(this.xPlus_Click);
            // 
            // zoomMinus
            // 
            this.zoomMinus.Location = new System.Drawing.Point(2612, 177);
            this.zoomMinus.Margin = new System.Windows.Forms.Padding(5);
            this.zoomMinus.Name = "zoomMinus";
            this.zoomMinus.Size = new System.Drawing.Size(131, 42);
            this.zoomMinus.TabIndex = 10;
            this.zoomMinus.Text = "zoom-";
            this.zoomMinus.UseVisualStyleBackColor = true;
            this.zoomMinus.Click += new System.EventHandler(this.zoomMinus_Click);
            // 
            // isFill
            // 
            this.isFill.AutoSize = true;
            this.isFill.Checked = true;
            this.isFill.Location = new System.Drawing.Point(10, 38);
            this.isFill.Margin = new System.Windows.Forms.Padding(5);
            this.isFill.Name = "isFill";
            this.isFill.Size = new System.Drawing.Size(139, 33);
            this.isFill.TabIndex = 11;
            this.isFill.TabStop = true;
            this.isFill.Text = "FillMode";
            this.isFill.UseVisualStyleBackColor = true;
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(2606, 703);
            this.fileName.Margin = new System.Windows.Forms.Padding(5);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(144, 35);
            this.fileName.TabIndex = 12;
            this.fileName.Text = "Rabbit.OBJ|1.PNG";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2606, 662);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2592, 989);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 29);
            this.label2.TabIndex = 14;
            this.label2.Text = "zoomConst";
            // 
            // zoomBox
            // 
            this.zoomBox.Location = new System.Drawing.Point(2586, 1025);
            this.zoomBox.Margin = new System.Windows.Forms.Padding(5);
            this.zoomBox.Name = "zoomBox";
            this.zoomBox.Size = new System.Drawing.Size(142, 35);
            this.zoomBox.TabIndex = 15;
            this.zoomBox.Text = "100";
            // 
            // edgeMod
            // 
            this.edgeMod.AutoSize = true;
            this.edgeMod.Location = new System.Drawing.Point(10, 87);
            this.edgeMod.Margin = new System.Windows.Forms.Padding(5);
            this.edgeMod.Name = "edgeMod";
            this.edgeMod.Size = new System.Drawing.Size(164, 33);
            this.edgeMod.TabIndex = 16;
            this.edgeMod.TabStop = true;
            this.edgeMod.Text = "EdgeMode";
            this.edgeMod.UseVisualStyleBackColor = true;
            // 
            // drawing
            // 
            this.drawing.Controls.Add(this.pointsOn);
            this.drawing.Controls.Add(this.edgeMod);
            this.drawing.Controls.Add(this.isFill);
            this.drawing.Location = new System.Drawing.Point(2586, 754);
            this.drawing.Margin = new System.Windows.Forms.Padding(5);
            this.drawing.Name = "drawing";
            this.drawing.Padding = new System.Windows.Forms.Padding(5);
            this.drawing.Size = new System.Drawing.Size(183, 183);
            this.drawing.TabIndex = 17;
            this.drawing.TabStop = false;
            this.drawing.Text = "Drawing";
            // 
            // pointsOn
            // 
            this.pointsOn.AutoSize = true;
            this.pointsOn.Location = new System.Drawing.Point(10, 138);
            this.pointsOn.Margin = new System.Windows.Forms.Padding(5);
            this.pointsOn.Name = "pointsOn";
            this.pointsOn.Size = new System.Drawing.Size(155, 33);
            this.pointsOn.TabIndex = 17;
            this.pointsOn.Text = "Points ON";
            this.pointsOn.UseVisualStyleBackColor = true;
            // 
            // aa
            // 
            this.aa.AutoSize = true;
            this.aa.Location = new System.Drawing.Point(2592, 1071);
            this.aa.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.aa.Name = "aa";
            this.aa.Size = new System.Drawing.Size(82, 29);
            this.aa.TabIndex = 18;
            this.aa.Text = "Vector";
            // 
            // light
            // 
            this.light.Location = new System.Drawing.Point(2586, 1107);
            this.light.Margin = new System.Windows.Forms.Padding(5);
            this.light.Name = "light";
            this.light.Size = new System.Drawing.Size(153, 35);
            this.light.TabIndex = 19;
            this.light.Text = "0;1;1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.normalsOff);
            this.groupBox1.Controls.Add(this.normalsOn);
            this.groupBox1.Location = new System.Drawing.Point(2597, 515);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(171, 142);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Normals";
            // 
            // normalsOff
            // 
            this.normalsOff.AutoSize = true;
            this.normalsOff.Checked = true;
            this.normalsOff.Location = new System.Drawing.Point(19, 87);
            this.normalsOff.Margin = new System.Windows.Forms.Padding(5);
            this.normalsOff.Name = "normalsOff";
            this.normalsOff.Size = new System.Drawing.Size(93, 33);
            this.normalsOff.TabIndex = 1;
            this.normalsOff.TabStop = true;
            this.normalsOff.Text = "OFF";
            this.normalsOff.UseVisualStyleBackColor = true;
            // 
            // normalsOn
            // 
            this.normalsOn.AutoSize = true;
            this.normalsOn.Location = new System.Drawing.Point(19, 38);
            this.normalsOn.Margin = new System.Windows.Forms.Padding(5);
            this.normalsOn.Name = "normalsOn";
            this.normalsOn.Size = new System.Drawing.Size(81, 33);
            this.normalsOn.TabIndex = 0;
            this.normalsOn.Text = "ON";
            this.normalsOn.UseVisualStyleBackColor = true;
            // 
            // coefControl
            // 
            this.coefControl.Location = new System.Drawing.Point(2586, 1211);
            this.coefControl.Margin = new System.Windows.Forms.Padding(5);
            this.coefControl.Name = "coefControl";
            this.coefControl.Size = new System.Drawing.Size(172, 35);
            this.coefControl.TabIndex = 21;
            this.coefControl.Text = "0";
            // 
            // coefCtrl
            // 
            this.coefCtrl.AutoSize = true;
            this.coefCtrl.Location = new System.Drawing.Point(2586, 1169);
            this.coefCtrl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.coefCtrl.Name = "coefCtrl";
            this.coefCtrl.Size = new System.Drawing.Size(163, 29);
            this.coefCtrl.TabIndex = 22;
            this.coefCtrl.Text = "Minimum coef";
            // 
            // turnV
            // 
            this.turnV.Location = new System.Drawing.Point(2586, 1300);
            this.turnV.Margin = new System.Windows.Forms.Padding(5);
            this.turnV.Name = "turnV";
            this.turnV.Size = new System.Drawing.Size(172, 35);
            this.turnV.TabIndex = 23;
            this.turnV.Text = "1;0;0;0,1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2586, 1263);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 29);
            this.label3.TabIndex = 24;
            this.label3.Text = "Turn Vector";
            // 
            // turnMinus
            // 
            this.turnMinus.Location = new System.Drawing.Point(2586, 1350);
            this.turnMinus.Margin = new System.Windows.Forms.Padding(5);
            this.turnMinus.Name = "turnMinus";
            this.turnMinus.Size = new System.Drawing.Size(84, 42);
            this.turnMinus.TabIndex = 25;
            this.turnMinus.Text = "-";
            this.turnMinus.UseVisualStyleBackColor = true;
            this.turnMinus.Click += new System.EventHandler(this.turnMinus_Click);
            // 
            // turnPlus
            // 
            this.turnPlus.Location = new System.Drawing.Point(2684, 1350);
            this.turnPlus.Margin = new System.Windows.Forms.Padding(5);
            this.turnPlus.Name = "turnPlus";
            this.turnPlus.Size = new System.Drawing.Size(77, 42);
            this.turnPlus.TabIndex = 26;
            this.turnPlus.Text = "+";
            this.turnPlus.UseVisualStyleBackColor = true;
            this.turnPlus.Click += new System.EventHandler(this.turnPlus_Click);
            // 
            // turnOX
            // 
            this.turnOX.AutoSize = true;
            this.turnOX.Location = new System.Drawing.Point(2597, 941);
            this.turnOX.Margin = new System.Windows.Forms.Padding(5);
            this.turnOX.Name = "turnOX";
            this.turnOX.Size = new System.Drawing.Size(130, 33);
            this.turnOX.TabIndex = 27;
            this.turnOX.Text = "TurnOY";
            this.turnOX.UseVisualStyleBackColor = true;
            // 
            // softLightning
            // 
            this.softLightning.AutoSize = true;
            this.softLightning.Location = new System.Drawing.Point(2586, 1402);
            this.softLightning.Margin = new System.Windows.Forms.Padding(5);
            this.softLightning.Name = "softLightning";
            this.softLightning.Size = new System.Drawing.Size(178, 33);
            this.softLightning.TabIndex = 28;
            this.softLightning.Text = "Soft Lighting";
            this.softLightning.UseVisualStyleBackColor = true;
            // 
            // deepCoef
            // 
            this.deepCoef.Location = new System.Drawing.Point(2597, 1513);
            this.deepCoef.Margin = new System.Windows.Forms.Padding(5);
            this.deepCoef.Name = "deepCoef";
            this.deepCoef.Size = new System.Drawing.Size(172, 35);
            this.deepCoef.TabIndex = 29;
            this.deepCoef.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2586, 1447);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 58);
            this.label4.TabIndex = 30;
            this.label4.Text = "We need \r\nto go dipper";
            // 
            // zoomConstT
            // 
            this.zoomConstT.Location = new System.Drawing.Point(2616, 227);
            this.zoomConstT.Name = "zoomConstT";
            this.zoomConstT.Size = new System.Drawing.Size(127, 35);
            this.zoomConstT.TabIndex = 31;
            this.zoomConstT.Text = "2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2789, 1863);
            this.Controls.Add(this.zoomConstT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.deepCoef);
            this.Controls.Add(this.softLightning);
            this.Controls.Add(this.turnOX);
            this.Controls.Add(this.turnPlus);
            this.Controls.Add(this.turnMinus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.turnV);
            this.Controls.Add(this.coefCtrl);
            this.Controls.Add(this.coefControl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.light);
            this.Controls.Add(this.aa);
            this.Controls.Add(this.drawing);
            this.Controls.Add(this.zoomBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.zoomMinus);
            this.Controls.Add(this.xPlus);
            this.Controls.Add(this.xMinus);
            this.Controls.Add(this.yPlus);
            this.Controls.Add(this.yMinus);
            this.Controls.Add(this.zoomBut);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.renderBut);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.drawing.ResumeLayout(false);
            this.drawing.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button renderBut;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button zoomBut;
        private System.Windows.Forms.Button yMinus;
        private System.Windows.Forms.Button yPlus;
        private System.Windows.Forms.Button xMinus;
        private System.Windows.Forms.Button xPlus;
        private System.Windows.Forms.Button zoomMinus;
        private System.Windows.Forms.RadioButton isFill;
        private System.Windows.Forms.TextBox fileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox zoomBox;
        private System.Windows.Forms.RadioButton edgeMod;
        private System.Windows.Forms.GroupBox drawing;
        private System.Windows.Forms.Label aa;
        private System.Windows.Forms.TextBox light;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton normalsOff;
        private System.Windows.Forms.RadioButton normalsOn;
        private System.Windows.Forms.CheckBox pointsOn;
        private System.Windows.Forms.TextBox coefControl;
        private System.Windows.Forms.Label coefCtrl;
        private System.Windows.Forms.TextBox turnV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button turnMinus;
        private System.Windows.Forms.Button turnPlus;
        private System.Windows.Forms.CheckBox turnOX;
        private System.Windows.Forms.CheckBox softLightning;
        private System.Windows.Forms.TextBox deepCoef;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox zoomConstT;
    }
}


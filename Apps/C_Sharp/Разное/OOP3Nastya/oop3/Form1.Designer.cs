namespace OOP3
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.chbIsPc1 = new System.Windows.Forms.RadioButton();
            this.chbIsPlayer1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gameControlForm1 = new OOP3.GameControlForm();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // btnStartGame
            // 
            this.btnStartGame.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnStartGame.Location = new System.Drawing.Point(457, 214);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(75, 23);
            this.btnStartGame.TabIndex = 10;
            this.btnStartGame.Text = "Начать игру";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // chbIsPc1
            // 
            this.chbIsPc1.AutoSize = true;
            this.chbIsPc1.Location = new System.Drawing.Point(6, 19);
            this.chbIsPc1.Name = "chbIsPc1";
            this.chbIsPc1.Size = new System.Drawing.Size(83, 17);
            this.chbIsPc1.TabIndex = 11;
            this.chbIsPc1.Text = "Компьютер";
            this.chbIsPc1.UseVisualStyleBackColor = true;
            // 
            // chbIsPlayer1
            // 
            this.chbIsPlayer1.AutoSize = true;
            this.chbIsPlayer1.Checked = true;
            this.chbIsPlayer1.Location = new System.Drawing.Point(6, 42);
            this.chbIsPlayer1.Name = "chbIsPlayer1";
            this.chbIsPlayer1.Size = new System.Drawing.Size(69, 17);
            this.chbIsPlayer1.TabIndex = 12;
            this.chbIsPlayer1.TabStop = true;
            this.chbIsPlayer1.Text = "Человек";
            this.chbIsPlayer1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox1.Controls.Add(this.chbIsPc1);
            this.groupBox1.Controls.Add(this.chbIsPlayer1);
            this.groupBox1.Location = new System.Drawing.Point(426, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(143, 66);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Игрок 1";
            // 
            // gameControlForm1
            // 
            this.gameControlForm1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameControlForm1.Cell1Color = System.Drawing.Color.WhiteSmoke;
            this.gameControlForm1.Cell2Color = System.Drawing.Color.DimGray;
            this.gameControlForm1.HeightCells = 8;
            this.gameControlForm1.Location = new System.Drawing.Point(45, 20);
            this.gameControlForm1.Name = "gameControlForm1";
            this.gameControlForm1.Size = new System.Drawing.Size(375, 367);
            this.gameControlForm1.TabIndex = 8;
            this.gameControlForm1.WidthCells = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 399);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gameControlForm1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GameControlForm gameControlForm1;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton chbIsPc1;
        private System.Windows.Forms.RadioButton chbIsPlayer1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btnStartGame;
    }
}


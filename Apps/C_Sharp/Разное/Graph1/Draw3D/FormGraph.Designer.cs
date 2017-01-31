namespace Draw3D
{
    partial class FormGraph
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.матрицаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.операцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискВГлубинуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискВГлубинустекToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискВШиринуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.построениеДереваостовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.путиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.эйлеровыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.гамильтоновыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tttToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.минимальноеРасстояниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.общийАлгоритмToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фордаБелманаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дейкстрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.раскраскаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переборныйАлгоритмToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.связностьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.топологическаяСортировкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.минимальныйОстовКраскалаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выделениеСвязностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.propertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.видToolStripMenuItem,
            this.операцииToolStripMenuItem,
            this.поискToolStripMenuItem,
            this.путиToolStripMenuItem,
            this.минимальноеРасстояниеToolStripMenuItem,
            this.раскраскаToolStripMenuItem,
            this.связностьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(955, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItem2.Text = "Save As ...";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.матрицаToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // матрицаToolStripMenuItem
            // 
            this.матрицаToolStripMenuItem.Name = "матрицаToolStripMenuItem";
            this.матрицаToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.матрицаToolStripMenuItem.Text = "Матрица";
            this.матрицаToolStripMenuItem.Click += new System.EventHandler(this.матрицаToolStripMenuItem_Click);
            // 
            // операцииToolStripMenuItem
            // 
            this.операцииToolStripMenuItem.Name = "операцииToolStripMenuItem";
            this.операцииToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.операцииToolStripMenuItem.Text = "Операции";
            // 
            // поискToolStripMenuItem
            // 
            this.поискToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поискВГлубинуToolStripMenuItem,
            this.поискВГлубинустекToolStripMenuItem,
            this.поискВШиринуToolStripMenuItem,
            this.построениеДереваостовToolStripMenuItem});
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.поискToolStripMenuItem.Text = "Поиск";
            this.поискToolStripMenuItem.Click += new System.EventHandler(this.поискToolStripMenuItem_Click);
            // 
            // поискВГлубинуToolStripMenuItem
            // 
            this.поискВГлубинуToolStripMenuItem.Name = "поискВГлубинуToolStripMenuItem";
            this.поискВГлубинуToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.поискВГлубинуToolStripMenuItem.Text = "Поиск в глубину";
            this.поискВГлубинуToolStripMenuItem.Click += new System.EventHandler(this.поискВГлубинуToolStripMenuItem_Click);
            // 
            // поискВГлубинустекToolStripMenuItem
            // 
            this.поискВГлубинустекToolStripMenuItem.Name = "поискВГлубинустекToolStripMenuItem";
            this.поискВГлубинустекToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.поискВГлубинустекToolStripMenuItem.Text = "Поиск в глубину (стек)";
            this.поискВГлубинустекToolStripMenuItem.Click += new System.EventHandler(this.поискВГлубинустекToolStripMenuItem_Click);
            // 
            // поискВШиринуToolStripMenuItem
            // 
            this.поискВШиринуToolStripMenuItem.Name = "поискВШиринуToolStripMenuItem";
            this.поискВШиринуToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.поискВШиринуToolStripMenuItem.Text = "Поиск в ширину";
            this.поискВШиринуToolStripMenuItem.Click += new System.EventHandler(this.поискВШиринуToolStripMenuItem_Click);
            // 
            // построениеДереваостовToolStripMenuItem
            // 
            this.построениеДереваостовToolStripMenuItem.Name = "построениеДереваостовToolStripMenuItem";
            this.построениеДереваостовToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.построениеДереваостовToolStripMenuItem.Text = "Построение дерева (остов)";
            this.построениеДереваостовToolStripMenuItem.Click += new System.EventHandler(this.построениеДереваостовToolStripMenuItem_Click);
            // 
            // путиToolStripMenuItem
            // 
            this.путиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.эйлеровыToolStripMenuItem,
            this.гамильтоновыToolStripMenuItem,
            this.PathToolStripMenuItem,
            this.tttToolStripMenuItem});
            this.путиToolStripMenuItem.Name = "путиToolStripMenuItem";
            this.путиToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.путиToolStripMenuItem.Text = "Пути";
            // 
            // эйлеровыToolStripMenuItem
            // 
            this.эйлеровыToolStripMenuItem.Name = "эйлеровыToolStripMenuItem";
            this.эйлеровыToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.эйлеровыToolStripMenuItem.Text = "Эйлеровы";
            this.эйлеровыToolStripMenuItem.Click += new System.EventHandler(this.эйлеровыToolStripMenuItem_Click);
            // 
            // гамильтоновыToolStripMenuItem
            // 
            this.гамильтоновыToolStripMenuItem.Name = "гамильтоновыToolStripMenuItem";
            this.гамильтоновыToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.гамильтоновыToolStripMenuItem.Text = "Гамильтоновы";
            this.гамильтоновыToolStripMenuItem.Click += new System.EventHandler(this.гамильтоновыToolStripMenuItem_Click);
            // 
            // PathToolStripMenuItem
            // 
            this.PathToolStripMenuItem.Name = "PathToolStripMenuItem";
            this.PathToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.PathToolStripMenuItem.Text = "Path";
            // 
            // tttToolStripMenuItem
            // 
            this.tttToolStripMenuItem.Name = "tttToolStripMenuItem";
            this.tttToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.tttToolStripMenuItem.Text = "Почтальона";
            this.tttToolStripMenuItem.Click += new System.EventHandler(this.tttToolStripMenuItem_Click);
            // 
            // минимальноеРасстояниеToolStripMenuItem
            // 
            this.минимальноеРасстояниеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.общийАлгоритмToolStripMenuItem,
            this.фордаБелманаToolStripMenuItem,
            this.дейкстрыToolStripMenuItem});
            this.минимальноеРасстояниеToolStripMenuItem.Name = "минимальноеРасстояниеToolStripMenuItem";
            this.минимальноеРасстояниеToolStripMenuItem.Size = new System.Drawing.Size(148, 20);
            this.минимальноеРасстояниеToolStripMenuItem.Text = "Минимальное расстояние";
            // 
            // общийАлгоритмToolStripMenuItem
            // 
            this.общийАлгоритмToolStripMenuItem.Name = "общийАлгоритмToolStripMenuItem";
            this.общийАлгоритмToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.общийАлгоритмToolStripMenuItem.Text = "Общий алгоритм";
            this.общийАлгоритмToolStripMenuItem.Click += new System.EventHandler(this.общийАлгоритмToolStripMenuItem_Click);
            // 
            // фордаБелманаToolStripMenuItem
            // 
            this.фордаБелманаToolStripMenuItem.Name = "фордаБелманаToolStripMenuItem";
            this.фордаБелманаToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.фордаБелманаToolStripMenuItem.Text = "Форда-Беллмана";
            this.фордаБелманаToolStripMenuItem.Click += new System.EventHandler(this.фордаБелманаToolStripMenuItem_Click);
            // 
            // дейкстрыToolStripMenuItem
            // 
            this.дейкстрыToolStripMenuItem.Name = "дейкстрыToolStripMenuItem";
            this.дейкстрыToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.дейкстрыToolStripMenuItem.Text = "Дейкстры";
            this.дейкстрыToolStripMenuItem.Click += new System.EventHandler(this.дейкстрыToolStripMenuItem_Click);
            // 
            // раскраскаToolStripMenuItem
            // 
            this.раскраскаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.переборныйАлгоритмToolStripMenuItem});
            this.раскраскаToolStripMenuItem.Name = "раскраскаToolStripMenuItem";
            this.раскраскаToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.раскраскаToolStripMenuItem.Text = "Раскраска";
            // 
            // переборныйАлгоритмToolStripMenuItem
            // 
            this.переборныйАлгоритмToolStripMenuItem.Name = "переборныйАлгоритмToolStripMenuItem";
            this.переборныйАлгоритмToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.переборныйАлгоритмToolStripMenuItem.Text = "Переборный алгоритм";
            this.переборныйАлгоритмToolStripMenuItem.Click += new System.EventHandler(this.переборныйАлгоритмToolStripMenuItem_Click);
            // 
            // связностьToolStripMenuItem
            // 
            this.связностьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.топологическаяСортировкаToolStripMenuItem,
            this.минимальныйОстовКраскалаToolStripMenuItem,
            this.выделениеСвязностиToolStripMenuItem});
            this.связностьToolStripMenuItem.Name = "связностьToolStripMenuItem";
            this.связностьToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.связностьToolStripMenuItem.Text = "Связность";
            // 
            // топологическаяСортировкаToolStripMenuItem
            // 
            this.топологическаяСортировкаToolStripMenuItem.Name = "топологическаяСортировкаToolStripMenuItem";
            this.топологическаяСортировкаToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.топологическаяСортировкаToolStripMenuItem.Text = "Топологическая сортировка";
            this.топологическаяСортировкаToolStripMenuItem.Click += new System.EventHandler(this.топологическаяСортировкаToolStripMenuItem_Click);
            // 
            // минимальныйОстовКраскалаToolStripMenuItem
            // 
            this.минимальныйОстовКраскалаToolStripMenuItem.Name = "минимальныйОстовКраскалаToolStripMenuItem";
            this.минимальныйОстовКраскалаToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.минимальныйОстовКраскалаToolStripMenuItem.Text = "Минимальный остов (Краскала)";
            this.минимальныйОстовКраскалаToolStripMenuItem.Click += new System.EventHandler(this.минимальныйОстовКраскалаToolStripMenuItem_Click);
            // 
            // выделениеСвязностиToolStripMenuItem
            // 
            this.выделениеСвязностиToolStripMenuItem.Name = "выделениеСвязностиToolStripMenuItem";
            this.выделениеСвязностиToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.выделениеСвязностиToolStripMenuItem.Text = "Выделение связности";
            this.выделениеСвязностиToolStripMenuItem.Click += new System.EventHandler(this.выделениеСвязностиToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propertyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(120, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // propertyToolStripMenuItem
            // 
            this.propertyToolStripMenuItem.Name = "propertyToolStripMenuItem";
            this.propertyToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.propertyToolStripMenuItem.Text = "Property";
            this.propertyToolStripMenuItem.Click += new System.EventHandler(this.propertyToolStripMenuItem_Click);
            // 
            // FormGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 548);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormGraph";
            this.Text = "FormGraph";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem propertyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem матрицаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem операцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поискВГлубинуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поискВГлубинустекToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поискВШиринуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem построениеДереваостовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem путиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem эйлеровыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem гамильтоновыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem минимальноеРасстояниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem общийАлгоритмToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фордаБелманаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дейкстрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem раскраскаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переборныйАлгоритмToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem связностьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem топологическаяСортировкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem минимальныйОстовКраскалаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выделениеСвязностиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tttToolStripMenuItem;
    }
}


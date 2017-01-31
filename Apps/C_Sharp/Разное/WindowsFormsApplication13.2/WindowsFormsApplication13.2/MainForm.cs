using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication13._2
{
    /*
     Дан файл вещественных чисел. Найти количество его локальных минимумов1|максимумов2|экстремумов3.
     */
    public partial class MainForm : Form
    {
        private Logics logics;
        private OpenFileDialog ofd = new OpenFileDialog();
        private SaveFileDialog sfd = new SaveFileDialog();

        public MainForm()
        {
            InitializeComponent();
            logics = new Logics();
            CtrlDGV.RowCount = 1;
        }

        private void CtrlButLoad_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CtrlLblAns.Text = logics.FindValues(ofd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Проблема при загрузке файла: " + ex.Message, "Ошибка");
                }
            }
        }

        private void CtrlButSave_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string[] Arr = new string[CtrlDGV.Rows.Count - 1];
                for (int i = 0; i < CtrlDGV.Rows.Count - 1; i++)
                    Arr[i] = CtrlDGV.Rows[i].Cells[0].Value.ToString();
                logics.Save(sfd.FileName, logics.ParseArray(Arr));
            }
        }
        
    }
}

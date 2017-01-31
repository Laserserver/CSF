using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication14._8
{
    /*
     8. Используя функцию memb, проверить, входит ли число,
     введённое в поле Edit1, в созданный список. Если да, то
     удалить из списка первое вхождение этого числа с помощью
     процедуры dele и вывести преобразованный список в текстовый
     файл с помощью процедуры out. В противном случае вывести сообщение:
     «Такого элемента нет».
     */
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CtrlDGV.RowCount = 1;
        }

        private void CtrlBaton_Click(object sender, EventArgs e)
        {
            string[] Arr = new string[CtrlDGV.RowCount - 1];
            for (int i = 0; i < CtrlDGV.RowCount - 1; i++)
                Arr[i] = CtrlDGV.Rows[i].Cells[0].Value.ToString();
            List Lst;
            try
            {
                Lst = new List(Arr);
                double Num;
                try
                {
                    Num = double.Parse(Edit1.Text.Replace('.', ','));
                    if (!Lst.StartDeleting(Num))
                        MessageBox.Show("Такого элемента нет");
                }
                catch
                {
                    MessageBox.Show("Ошибка считывания числа для поиска. Проверьте правильность введённого значения.", "Ошибка");
                }

            }
            catch
            {
                MessageBox.Show("Ошибка считывания чисел. Проверьте правильность введённых значений.", "Ошибка");
            }
        }
    }
}

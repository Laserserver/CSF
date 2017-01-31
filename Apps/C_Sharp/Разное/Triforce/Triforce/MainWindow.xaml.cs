using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Triforce
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CtrlBaton_Click(object sender, RoutedEventArgs e)
        {
            CtrlTBOut.Text = SetText(int.Parse(CtrlTBIn.Text));
        }

        private string SetText(int Length)
        {
            string Out = "";
            int Spaces = Length - 1, Triangles = 1;

            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Spaces; j++)
                    Out += "&#8194;";
                Spaces--;
                for (int j = 0; j < Triangles; j++)
                    Out += "▲";
                Triangles++;
                Out += '\n';
            }
            return Out;
        }
    }
}

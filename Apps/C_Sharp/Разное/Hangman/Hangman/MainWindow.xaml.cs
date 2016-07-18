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
using System.IO;
using Microsoft.Win32;

namespace Hangman
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    byte State = 0;
    public MainWindow()
    {
      InitializeComponent();
      _Head.Visibility = _HeadEy1.Visibility = _HeadEy2.Visibility = _HeadEy3.Visibility = _HeadEy4.Visibility = _HeadMouth.Visibility = Visibility.Hidden;
      _Body.Visibility = _Leg_l.Visibility = _Leg_r.Visibility = _Hand_l.Visibility = _Hand_r.Visibility = Visibility.Hidden;
      ctrlBaton.IsEnabled = false;
    }

    private void _ctrlBatLoad_Click(object sender, RoutedEventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog();
      if (ofd.ShowDialog() == true)
      {
        Logic.Parser(File.ReadAllText(ofd.FileName));
        ctrlBaton.IsEnabled = true;
      }
    }

    private void DrawParts()
    {
      switch (State)
      {
        case 1:
          _Head.Visibility = _HeadEy1.Visibility = _HeadEy2.Visibility = _HeadEy3.Visibility = _HeadEy4.Visibility = _HeadMouth.Visibility = Visibility.Visible;
          break;
        case 2:
          _Body.Visibility = Visibility.Visible;
          break;
        case 3:
          _Leg_l.Visibility = Visibility.Visible;
          break;
        case 4:
          _Leg_r.Visibility = Visibility.Visible;
          break;
        case 5:
          _Hand_l.Visibility = Visibility.Visible;
          break;
        case 6:
          _Hand_r.Visibility = Visibility.Visible;
          break;
      }
    }

    private void ctrlBaton_Click(object sender, RoutedEventArgs e)
    {
      string BefText = ctrlTxb.Text;
      if (BefText.Length == 1)
      {
        State = Logic.Check(Char.ToLower(ctrlTxb.Text[0])) ? State : ++State;
        DrawParts();
        ctrlLbl.Content = Logic.OutWord(false);
      }
      else
        MessageBox.Show("Только один символ может быть введен.");
      if (State == 6)
      {
        ctrlBaton.IsEnabled = false;
        ctrlLbl.Content = Logic.OutWord(true);
      }
    }

    private void _ctrlBatReset_Click(object sender, RoutedEventArgs e)
    {
      Logic.ReturnRand();
      ctrlLbl.Content = Logic.OutWord(false);
    }
  }
}

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

namespace OvWH
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    OvWHList StandList, SortList;
    string[] FirstList, SecondList;

    public MainWindow()
    {
      InitializeComponent();
    }

    private void button_Click(object sender, RoutedEventArgs e)
    {
      _ctrlListIn.ItemsSource = OvWHLogic.OvWHGetNumbers(int.Parse(_ctrlTxb.Text));
      StandList = OvWHLogic.OvWHFillList();
      SortList = OvWHLogic.OvWHFillSortList();
      FirstList = StandList.OvWhListPrint();
      SecondList = SortList.OvWhListPrint();

      _ctrlListUnsort.ItemsSource = FirstList;
      _ctrlListSort.ItemsSource = SecondList;
    }
  }
}

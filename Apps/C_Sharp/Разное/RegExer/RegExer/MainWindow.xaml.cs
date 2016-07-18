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

namespace RegExer
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

    private void _ctrlButLoad_Click(object sender, RoutedEventArgs e)
    {
      Logics.Text = null;
      Logics.Urls = new List<string>();
      Logics.Logins = new List<string>();
      Logics.Passes = new List<string>();
      OpenFileDialog ofd = new OpenFileDialog();
      if (ofd.ShowDialog() == true)
        Logics.Parser(File.ReadAllText(ofd.FileName));
      _ctrlOutText.Text = Logics.Text;
    }

    private void _ctrlButSave_Click(object sender, RoutedEventArgs e)
    {
      SaveFileDialog sfd = new SaveFileDialog();
      if (sfd.ShowDialog() == true)
        File.WriteAllText(sfd.SafeFileName, Logics.Text);
    }
  }
}

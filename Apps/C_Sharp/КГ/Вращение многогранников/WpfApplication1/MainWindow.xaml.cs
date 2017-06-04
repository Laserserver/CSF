using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Timers;

namespace Icosaedr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            update = new System.Timers.Timer();
            update.Interval = Settings.updateInterval;
            update.AutoReset = true;
            update.Elapsed += Update;
            
        }
        bool X = false, Y = false, Z = false;
        double oldX, oldY;
        System.Timers.Timer update;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            ModelStorage.ParseFile(Settings.filename);
            Drawer.Draw(canv);
        }

        private void checkBox1_Click(object sender, RoutedEventArgs e)
        {
            Y = !Y;
        }

        private void checkBox2_Click(object sender, RoutedEventArgs e)
        {
            Z = !Z;
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
        
            update.Enabled = !update.Enabled;

        }

        private void canv_MouseUp(object sender, MouseButtonEventArgs e)
        {
        }

        private void canv_MouseDown(object sender, MouseButtonEventArgs e)
        {
            oldX = e.GetPosition(canv).X;
            oldY = e.GetPosition(canv).Y;
        }

        private void CtrlTxb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Settings.rotateAngle = 0.5 * double.Parse(CtrlTxb.Text);
        }

        private void canv_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton==MouseButtonState.Pressed)
            {
                Drawer.CamZ += e.GetPosition(canv).X-oldX;
                Drawer.CamX += e.GetPosition(canv).Y - oldY;
                oldX = e.GetPosition(canv).X;
                oldY = e.GetPosition(canv).Y;
                if(!update.Enabled)Drawer.Update(canv);
            }
        }

        private void Update(Object source, ElapsedEventArgs e)
        {
            //Settings.coef = Convert.ToInt32(textBox.Text);
            ModelStorage.RotateFigure(Settings.rotateAngle, X, Y, Z);
            Dispatcher.BeginInvoke(new ThreadStart(delegate { Drawer.Update(canv); }));

            
        }

        private void checkBox_Click(object sender, RoutedEventArgs e)
        {
            X = !X;
        }
    }
}

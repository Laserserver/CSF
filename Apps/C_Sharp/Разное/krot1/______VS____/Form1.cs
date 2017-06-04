using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using System.IO;
using PlugIn;

namespace ДачникVSКрот
{

    public partial class Form1 : Form, IPluginHost
    {
        public const int picSize = 80;
        MainAction mainAction = null;
        List<IPlugin> _plugins;
        private Graphics BitmapGraph;
        public PictureBox MainFrame;
        Bitmap Frame;
        Graphics PictureBoxGraph;

        public Form1()
        {
            InitializeComponent();
            MainFrame = pictureBox1;
            Frame = new Bitmap(MainFrame.Width, MainFrame.Height);
            PictureBoxGraph = MainFrame.CreateGraphics();

        }
        public bool Register(IPlugin plug)
        {
            return true;
        }
        private void LoadPlugins(string path)
        {
            string[] pluginFiles = Directory.GetFiles(path, "*.dll");
            this._plugins = new List<IPlugin>();

            foreach (string pluginPath in pluginFiles)
            {
                Type objType = null;
                try
                {
                    // пытаемся загрузить библиотеку
                    Assembly assembly = Assembly.LoadFrom(pluginPath);
                    if (assembly != null)
                    {
                        objType = assembly.GetType(Path.GetFileNameWithoutExtension(pluginPath) + ".PlugIn");
                    }
                }
                catch
                {
                    continue;
                }
                try
                {
                    if (objType != null)
                    {
                        this._plugins.Add((IPlugin)Activator.CreateInstance(objType));
                        this._plugins[this._plugins.Count - 1].Host = (PlugIn.IPluginHost)this;
                    }
                }
                catch
                {
                    continue;
                }
            }
        }
        private void StartGameButton_Click_EventHandler(object sender, EventArgs e)
        {
            

            if (mainAction != null)
            {
                mainAction.EventCrotCountChange -= new DelegateCrotEventHandler(CrotCountChange_EventHandler);
                mainAction.EventPlantCountChange -= new DelegatePlantEventHandler(PlantCountChange_EventHandler);
            }
            this.mainAction = new MainAction(this.start, this.Frame, this.PictureBoxGraph, this.BitmapGraph, (int)numericUpDown1.Value, (int)numericUpDown2.Value);

            mainAction.EventCrotCountChange += new DelegateCrotEventHandler(CrotCountChange_EventHandler);
            mainAction.EventPlantCountChange += new DelegatePlantEventHandler(PlantCountChange_EventHandler);
            mainAction.EventEndGame += new DelegateEndEventHandler(EndGame_EventHandler);
            mainAction.StartGame();

            pictureBox1.Focus();
        }

        private void CrotCountChange_EventHandler(int sender)
        {
            textBoxKrotCount.Invoke(new Action(() => textBoxKrotCount.Text = sender.ToString()));
        }
       
        private void PlantCountChange_EventHandler(int sender)
        {
            textBoxPlantCount.Invoke(new Action(() => textBoxPlantCount.Text = sender.ToString()));
        }
        private void StartGameButton_Enter_EventHandler(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }
        private void textBoxPlantCount_Enter_EventHandler(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }

        private void textBoxKrotCount_Enter_EventHandler(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }
        private void MainFrame_KeyDown_EventHandler(object sender, PreviewKeyDownEventArgs e)
        {
            int currentKey = e.KeyValue;
            switch (currentKey)
            {
                case 37:    //левая
                    {
                        mainAction.Move('L');
                        break;
                    }
                case 39:    //правая
                    {
                        mainAction.Move('R');
                        break;
                    }
                case 38:    //вперед
                    {
                        mainAction.Move('W');
                        break;
                    }
                case 40:    //вниз
                    {
                        mainAction.Move('S');
                        break;
                    }
                case 32:    //space
                    {
                        mainAction.Move('K');
                        break;
                    }
            }

            pictureBox1.Focus();
        }
        private void numericUpDown1_Enter_EventHandler(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }
        private void numericUpDown2_Enter_EventHandler(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }

      

        public void EndGame_EventHandler(object sender, MyEventArg Arg)
        {
            string str="";
            if (Arg.mainAction.KrotCount == 0) str = "Победа! Дачник уничтожил кротов";
            if (Arg.mainAction.PlantCount == 0) str = "УВЫ :( Кроты уничножили все растения";
                ;
            if (MessageBox.Show(str + "\nХотите сыграть еще раз?", "Поражение(", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Arg.mainAction.Clearing();
                Arg.mainAction.StartGame();
            }
            else
            {
                //
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.LoadPlugins(Application.StartupPath);//"E:/krot/______VS____/bin/Debug/Plugins");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // this._plugins[0].Show();
        }    
    }

}

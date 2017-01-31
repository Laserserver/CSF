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

namespace ДачникVSКрот
{

    public partial class Form1 : Form
    {
        public const int picSize = 80;
        //Класс общения формы с логикой через события
        MainAction mainAction = null;
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
        //Обработчик нажатия кнопки старта
        private void StartGameButton_Click_EventHandler(object sender, EventArgs e)
        {
            if (mainAction != null)
            {
                mainAction.EventCrotCountChange -= new DelegateCrotEventHandler(CrotCountChange_EventHandler);
                mainAction.EventPlantCountChange -= new DelegatePlantEventHandler(PlantCountChange_EventHandler);
            }
            mainAction = new MainAction(start, Frame, PictureBoxGraph, BitmapGraph, (int)numericUpDown1.Value, (int)numericUpDown2.Value);
            //Подписываем события в класс общения
            mainAction.EventCrotCountChange += new DelegateCrotEventHandler(CrotCountChange_EventHandler);
            mainAction.EventPlantCountChange += new DelegatePlantEventHandler(PlantCountChange_EventHandler);
            mainAction.EventEndGame += new DelegateEndEventHandler(EndGame_EventHandler);
            mainAction.StartGame();
            //Фокусируемся на канвасе
            pictureBox1.Focus();
        }

        //Запись кол-ва кротов в текстбокс главным классом
        private void CrotCountChange_EventHandler(int sender)
        {
            textBoxKrotCount.Invoke(new Action(() => textBoxKrotCount.Text = sender.ToString()));
        }
        //Запись кол-ва растений в текстбокс главным классом
        private void PlantCountChange_EventHandler(int sender)
        {
            textBoxPlantCount.Invoke(new Action(() => textBoxPlantCount.Text = sender.ToString()));
        }
        //Без этих методов по стрелкам будут выбираться текстбоксы и кнопки
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
        private void numericUpDown1_Enter_EventHandler(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }
        private void numericUpDown2_Enter_EventHandler(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }
        //Это движение клавиатурой
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


        }
        //Событие окончания игры
        public void EndGame_EventHandler(object sender, MyEventArg Arg)
        {
            string str = "";
            if (Arg.mainAction.KrotCount == 0)
                str = "Победа! Дачник уничтожил кротов";
            if (Arg.mainAction.PlantCount == 0)
                str = "УВЫ :( Кроты уничножили все растения";
            if (MessageBox.Show(str + "\nХотите сыграть еще раз?", "Результат", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Arg.mainAction.Clearing();
                Arg.mainAction.StartGame();
            }
        }
        
    }

}

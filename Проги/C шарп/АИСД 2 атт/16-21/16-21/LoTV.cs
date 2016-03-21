using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _16_21
{

  public partial class LoTV : Form
  {
    static Graphics NewImage;  //Картинка
    static Graphics Panel;     //Панель
    static Bitmap Canvas;       //???
    static Rectangle Rect; //Границы канваса

    public LoTV()
    {
      InitializeComponent();
      LoTVClass.LoTVCreate(); //Заполняем массив
      LoTVClass.LoTVSetValues();
    }

    private void LoTV_Load(object sender, EventArgs e)
    {
      Panel = _ctrlPanel.CreateGraphics();                               //Место, где рисуем
      Canvas = new Bitmap(_ctrlPanel.Width, _ctrlPanel.Height);          //Создаем пустую картинку
      Rect = new Rectangle(0, 0, _ctrlPanel.Width, _ctrlPanel.Height);   //Выделяем границы канваса
      NewImage = Graphics.FromImage(Canvas);                             //Создаем пустой образ для канваса
    }

    public static void Draw()
    {
      NewImage.Clear(Color.White);          //Очищаем канвас
      LoTVClass.LoTVOutImage(NewImage);
      Panel.DrawImage(Canvas, Rect);
    }

    private void _ctrlBaton_Click(object sender, EventArgs e)
    {
      int State = _ctrlRadBatonLog2.Checked ? 1 : _ctrlRadBatonLog3.Checked ? 2 : 3;
      LoTVClass.LoTVSetValues();
      LoTVClass.LoTVSort(State);
    }

    private void _ctrlFill_Click(object sender, EventArgs e)
    {
      LoTVClass.LoTVCreate();
      Draw();
    }
  }
}

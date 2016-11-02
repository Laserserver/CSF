using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/*8. Баннерное рекламное агенство.
В городе баннерное агенство может строить свои рекламные щиты и размещать на них рекламу.
//Ввести словарь для года?
 * 
Показать процесс развития рекламного агенства с учетом движения денежных средств. Изначально 
у рекламного агенства есть несколько рекламных щитов и некая сумма денег на счету.  //Лимит денег ввести
 * При старте процесса появляются клиенты (физические, юридические лица, госструктуры), которые 
заказывают размещение своей рекламы на баннерах организации. //Очередь структур клиентов
 * Госструктуры могут иметь приоритет и "заказывать" социальную рекламу, за которую они не платят.
//С приоритетом
Учесть, что обслуживание баннеров, содержание штата фирмы, постройка новых
баннеров требует вложений денежных средств со счета организации.  //Каждый баннер == затраты

Реализовать различные стратегии поведения фирмы (агрессивная -- частое строительство новых баннеров,
умеренная -- строительство баннеров при большом росте счета, консервативная -- крайне редкое 
строительство новых баннеров).   //Радиобатоны

На форме показать размещение баннеров в городе, очередь клиентов, пожелания клиентов,
динамику поведения счета.  //Графики чтоль?
 */
namespace Yaisp3_v._0._1
{
    public partial class MainForm : Form
    {
        double coeff;
        public MainForm()
        {
            MouseWheel+= new MouseEventHandler(_ctrlPicBxMap_MouseScroll);
            InitializeComponent();
        }

        private void _ctrlPicBxMap_MouseScroll(object sender, MouseEventArgs e)
        {
            double x = DrawingClass.XX(e.X);
            double y = DrawingClass.YY(e.Y);
            if (e.Delta < 0)
                coeff = 1.03;
            else
                coeff = 0.97;
        }
        private void _ctrlPicBxMap_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void _ctrlPicBxMap_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void _ctrlPicBxMap_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}

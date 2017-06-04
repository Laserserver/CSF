using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Task3_test.NewComponent
{
    public class Country
    {
        public Coordinates coordinates;
        public PictureBox picture=new PictureBox();
        public string Name;
        public string Capital;
        public PictureBox brief_information=new PictureBox();//краткая информация
        public string ExtendedInfo;//расширенная информация
        
    }
}

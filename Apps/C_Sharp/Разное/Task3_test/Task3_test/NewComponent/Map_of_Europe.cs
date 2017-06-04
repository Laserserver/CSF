using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Task3_test.NewComponent
{
    public partial class Map_of_Europe : Component
    {
        public Country[] countrys=new Country[33];//=new Country[0];// Russia, Estonia, Latvia, Lithuania, Belarus, Ukraine, Moldavia, Romania, Bulgaria, Greece, Albania, Macedonia, Montenegro/*Черногория*/, Kosovo, Serbia, Bosnia, Сroatia/*Хорватия*/, Slovenia, Hungary/*Венгрия*/, Slovakia, Austria, Czech/*Чехия*/, Poland, Germany, Netherlands, Belgium, Luxembourg, switzerland/*Швейцария*/, France, Britain, Ireland, Norway, Sweden, Denmark/*Дания*/, Spain, Portugal, Morocco, Algeria, Tunisia;
        Image img_fon;// = Image.FromFile("travel_map.jpg");
        public Country SelectedCountry;
        public MapForm MF;
        /*public Country SelectedCountry
        {
            get { return selectedCountry; }
            set { selectedCountry = value; }
        }*/
        public Map_of_Europe()
        {
            InitializeComponent();
            
        }
        string ReadTxt(string name)
        {
            string str="";
            string pathOpen = Application.StartupPath + "\\text\\"+name+".txt"; 
            //TextReader sr = new StreamReader(pathOpen, Encoding.GetEncoding("koi8-r"));
            Stream stream = new FileStream(pathOpen, FileMode.Open, FileAccess.Read);
            TextReader sr = new StreamReader(stream, Encoding.GetEncoding("Windows-1251"));
            int b = File.ReadAllLines(Application.StartupPath + "\\text\\" + name + ".txt").Length - 1;
            for(int i=0;i<b;i++)
            {
                str += sr.ReadLine();
                str += '\n';
            }
            sr.Close();
            return str;
        }
        public Map_of_Europe(IContainer container)
        {
            img_fon = Image.FromFile("map.jpg");
            container.Add(this);
            InitializeComponent();
            for (int i = 0; i < countrys.Length; i++)
            {
                countrys[i] = new Country();
                countrys[i].picture.MouseClick += new MouseEventHandler(picture_MouseClick);

 
            }
            
            //Россия
            countrys[0].Name = "Россия";
            countrys[0].picture.Image = Image.FromFile("Russia.jpg");
            countrys[0].picture.Location = new System.Drawing.Point(1139, 0);
            countrys[0].picture.Size = new System.Drawing.Size(143, 295);
            countrys[0].picture.Visible=false;
            countrys[0].picture.InitialImage=img_fon;
            countrys[0].coordinates = new Coordinates(1163, 56, 1280, 154);
            countrys[0].ExtendedInfo = ReadTxt("Russia");
            countrys[0].brief_information.Image = Image.FromFile("info_Russia.gif");
            //Эстония
            countrys[1].Name = "Эстония";
            countrys[1].picture.Image = Image.FromFile("Estonia.jpg");
            countrys[1].picture.Location = new System.Drawing.Point(1076, 46);
            countrys[1].picture.Size = new System.Drawing.Size(99, 81);
            countrys[1].picture.Visible=false;
            countrys[1].picture.InitialImage=img_fon;
            countrys[1].coordinates = new Coordinates(1094, 55, 1150, 106);
            countrys[1].ExtendedInfo = ReadTxt("Estonia");

            //Латвия
            countrys[2].Name = "Латвия";
            countrys[2].picture.Image = Image.FromFile("Latvia.jpg");
            countrys[2].picture.Location = new System.Drawing.Point(1025, 86);
            countrys[2].picture.Size = new System.Drawing.Size(153, 93);
            countrys[2].picture.Visible=false;
            countrys[2].picture.InitialImage=img_fon;
            countrys[2].coordinates = new Coordinates(1056,113,1160,145);
            countrys[2].ExtendedInfo = ReadTxt("Latvia");
            //
            countrys[3].Name = "Литва";
            countrys[3].picture.Image = Image.FromFile("Lithuania.jpg");
            countrys[3].picture.Location = new System.Drawing.Point(1041, 133);
            countrys[3].picture.Size = new System.Drawing.Size(112, 104);
            countrys[3].picture.Visible=false;
            countrys[3].picture.InitialImage=img_fon;
            countrys[3].coordinates = new Coordinates(1047,155,1115,214);
            countrys[3].ExtendedInfo = "";
            //
            countrys[4].Name = "Беларусь";
            countrys[4].picture.Image = Image.FromFile("Belarus.jpg");
            countrys[4].picture.Location = new System.Drawing.Point(1076, 146);
            countrys[4].picture.Size = new System.Drawing.Size(184, 172);
            countrys[4].picture.Visible=false;
            countrys[4].picture.InitialImage=img_fon;
            countrys[4].coordinates = new Coordinates(1136,171,1212,300);
            countrys[4].ExtendedInfo = ReadTxt("Belarus");
            
            countrys[5].Name = "Германия";
            countrys[5].picture.Image = Image.FromFile("Germany.jpg");
            countrys[5].picture.Location = new System.Drawing.Point(730, 168);
            countrys[5].picture.Size = new System.Drawing.Size(198, 268);
            countrys[5].picture.Visible=false;
            countrys[5].picture.InitialImage=img_fon;
            countrys[5].coordinates = new Coordinates(773,212,844,400);
            countrys[5].ExtendedInfo = ReadTxt("Germany");
            countrys[5].brief_information.Image = Image.FromFile("info_Germany.gif");
            //
            countrys[6].Name = "Нидерланды";
            countrys[6].picture.Image = Image.FromFile("Netherlands.jpg");
            countrys[6].picture.Location = new System.Drawing.Point(701, 188);
            countrys[6].picture.Size = new System.Drawing.Size(78, 92);
            countrys[6].picture.Visible=false;
            countrys[6].picture.InitialImage=img_fon;
            countrys[6].coordinates = new Coordinates(728,216,758,245);
            countrys[6].ExtendedInfo = ReadTxt("Netherlands");
            //
            
            countrys[7].Name = "Бельгия";
            countrys[7].picture.Image = Image.FromFile("Belgium.jpg");
            countrys[7].picture.Location = new System.Drawing.Point(669, 235);
            countrys[7].picture.Size = new System.Drawing.Size(73, 102);
            countrys[7].picture.Visible=false;
            countrys[7].picture.InitialImage=img_fon;
            countrys[7].coordinates = new Coordinates(673,259,729,292);
            countrys[7].ExtendedInfo = ReadTxt("Belgium");
            //
            countrys[8].Name = "Люксембург";
            countrys[8].picture.Image = Image.FromFile("Luxembourg.jpg");
            countrys[8].picture.Location = new System.Drawing.Point(701, 289);
            countrys[8].picture.Size = new System.Drawing.Size(47, 57);
            countrys[8].picture.Visible=false;
            countrys[8].picture.InitialImage=img_fon;
            countrys[8].coordinates = new Coordinates(727,307,735,318);
            countrys[8].ExtendedInfo = ReadTxt("Luxembourg");
            
            countrys[9].Name = "Франция";
            countrys[9].picture.Image = Image.FromFile("France.jpg");
            countrys[9].picture.Location = new System.Drawing.Point(488, 254);
            countrys[9].picture.Size = new System.Drawing.Size(281, 274);
            countrys[9].picture.Visible=false;
            countrys[9].picture.InitialImage=img_fon;
            countrys[9].coordinates = new Coordinates(553,304,702,510);
            countrys[9].ExtendedInfo = ReadTxt("France");
            countrys[9].brief_information.Image = Image.FromFile("info_France.gif");
            
            countrys[10].Name = "Норвегия";
            countrys[10].picture.Image = Image.FromFile("Norway.jpg");
            countrys[10].picture.Location = new System.Drawing.Point(768, 0);
            countrys[10].picture.Size = new System.Drawing.Size(144, 74);
            countrys[10].picture.Visible=false;
            countrys[10].picture.InitialImage=img_fon;
            countrys[10].coordinates = new Coordinates(815,0,876,57);
            countrys[10].ExtendedInfo = ReadTxt("Norway");
            //
            countrys[11].Name = "Швеция";
            countrys[11].picture.Image = Image.FromFile("Sweden.jpg");
            countrys[11].picture.Location = new System.Drawing.Point(877, 0);
            countrys[11].picture.Size = new System.Drawing.Size(136, 185);
            countrys[11].picture.Visible=false;
            countrys[11].picture.InitialImage=img_fon;
            countrys[11].coordinates = new Coordinates(907,0,953,146);
            countrys[11].ExtendedInfo = ReadTxt("Sweden");
            //
            countrys[12].Name = "Дания";
            countrys[12].picture.Image = Image.FromFile("Denmark.jpg");
            countrys[12].picture.Location = new System.Drawing.Point(781, 79);
            countrys[12].picture.Size = new System.Drawing.Size(98, 106);
            countrys[12].picture.Visible=false;
            countrys[12].picture.InitialImage=img_fon;
            countrys[12].coordinates = new Coordinates(817,115,838,146);
            countrys[12].ExtendedInfo = ReadTxt("Denmark");
            //
            countrys[13].Name = "Испания";
            countrys[13].picture.Image = Image.FromFile("Spain.jpg");
            countrys[13].picture.Location = new System.Drawing.Point(321, 391);
            countrys[13].picture.Size = new System.Drawing.Size(301, 264);
            countrys[13].picture.Visible=false;
            countrys[13].picture.InitialImage=img_fon;
            countrys[13].coordinates = new Coordinates(396,469,502,617);
            countrys[13].ExtendedInfo = ReadTxt("Spain");
            //
            countrys[14].Name = "Португалия";
            countrys[14].picture.Image = Image.FromFile("Portugal.jpg");
            countrys[14].picture.Location = new System.Drawing.Point(277, 416);
            countrys[14].picture.Size = new System.Drawing.Size(134, 194);
            countrys[14].picture.Visible=false;
            countrys[14].picture.InitialImage=img_fon;
            countrys[14].coordinates = new Coordinates(287,516,341,518);
            countrys[14].ExtendedInfo = ReadTxt("Portugal");
            //
            countrys[15].Name = "Марокко";
            countrys[15].picture.Image = Image.FromFile("Morocco.jpg");
            countrys[15].picture.Location = new System.Drawing.Point(204, 650);
            countrys[15].picture.Size = new System.Drawing.Size(243, 150);
            countrys[15].picture.Visible=false;
            countrys[15].picture.InitialImage=img_fon;
            countrys[15].coordinates = new Coordinates(221,710,409,795);
            countrys[15].ExtendedInfo = ReadTxt("Morocco");
            //
            countrys[16].Name = "Алжир";
            countrys[16].picture.Image = Image.FromFile("Algeria.jpg");
            countrys[16].picture.Location = new System.Drawing.Point(395, 684);
            countrys[16].picture.Size = new System.Drawing.Size(310, 116);
            countrys[16].picture.Visible=false;
            countrys[16].picture.InitialImage=img_fon;
            countrys[16].coordinates = new Coordinates(423,720,674,795);
            countrys[16].ExtendedInfo = ReadTxt("Algeria");
            //
            countrys[17].Name = "Тунис";
            countrys[17].picture.Image = Image.FromFile("Tunisia.jpg");
            countrys[17].picture.Location = new System.Drawing.Point(660, 723);
            countrys[17].picture.Size = new System.Drawing.Size(111, 77);
            countrys[17].picture.Visible=false;
            countrys[17].picture.InitialImage=img_fon;
            countrys[17].coordinates = new Coordinates(689,742,751,800);
            countrys[17].ExtendedInfo = ReadTxt("Tunisia");
            //
            
            countrys[18].Name = "Великобритания";
            countrys[18].picture.Image = Image.FromFile("Britain.jpg");
            countrys[18].picture.Location = new System.Drawing.Point(507, 1);
            countrys[18].picture.Size = new System.Drawing.Size(176,262);
            countrys[18].picture.Visible=false;
            countrys[18].picture.InitialImage=img_fon;
            countrys[18].coordinates = new Coordinates(598,0,646,237);
            countrys[18].ExtendedInfo = ReadTxt("Britain");
            countrys[18].brief_information.Image = Image.FromFile("info_Britain.gif");
            //
            countrys[19].Name = "Ирландия";
            countrys[19].picture.Image = Image.FromFile("Ireland.jpg");
            countrys[19].picture.Location = new System.Drawing.Point(440,42);
            countrys[19].picture.Size = new System.Drawing.Size(136,134);
            countrys[19].picture.Visible = false;
            countrys[19].picture.InitialImage = img_fon;
            countrys[19].coordinates = new Coordinates(516,125,576,125);
            countrys[19].ExtendedInfo = ReadTxt("Ireland");
            
            //

            //
            
            countrys[20].Name = "Украина";
            countrys[20].picture.Image = Image.FromFile("Ukraine.jpg");
            countrys[20].picture.Location = new System.Drawing.Point(1047,266);
            countrys[20].picture.Size = new System.Drawing.Size(233,213);
            countrys[20].picture.Visible=false;
            countrys[20].picture.InitialImage=img_fon;
            countrys[20].coordinates = new Coordinates(1096,304,1280,406);
            countrys[20].ExtendedInfo = ReadTxt("Ukraine");
            //
            countrys[21].Name = "Молдавия";
            countrys[21].picture.Image = Image.FromFile("Moldavia.jpg");
            countrys[21].picture.Location = new System.Drawing.Point(1156,401);
            countrys[21].picture.Size = new System.Drawing.Size(90,118);
            countrys[21].picture.Visible=false;
            countrys[21].picture.InitialImage=img_fon;
            countrys[21].coordinates = new Coordinates(1170,424,1220,468);
            countrys[21].ExtendedInfo = ReadTxt("Moldavia");
            //
            countrys[22].Name = "Румыния";
            countrys[22].picture.Image = Image.FromFile("Romania.jpg");
            countrys[22].picture.Location = new System.Drawing.Point(1015,402);
            countrys[22].picture.Size = new System.Drawing.Size(219,190);
            countrys[22].picture.Visible=false;
            countrys[22].picture.InitialImage=img_fon;
            countrys[22].coordinates = new Coordinates(1069,419,1197,547);
            countrys[22].ExtendedInfo = ReadTxt("Romania");
            //
            countrys[23].Name = "Бoлгария";
            countrys[23].picture.Image = Image.FromFile("Bulgaria.jpg");
            countrys[23].picture.Location = new System.Drawing.Point(1049,532);
            countrys[23].picture.Size = new System.Drawing.Size(152,124);
            countrys[23].picture.Visible=false;
            countrys[23].picture.InitialImage=img_fon;
            countrys[23].coordinates = new Coordinates(1074,577,1183,622);
            countrys[23].ExtendedInfo = ReadTxt("Bulgaria");
            //
            countrys[24].Name = "Греция";
            countrys[24].picture.Image = Image.FromFile("Greece.jpg");
            countrys[24].picture.Location = new System.Drawing.Point(992,632);
            countrys[24].picture.Size = new System.Drawing.Size(175,168);
            countrys[24].picture.Visible=false;
            countrys[24].picture.InitialImage=img_fon;
            countrys[24].coordinates = new Coordinates(1004,680,1091,752);
            countrys[24].ExtendedInfo = ReadTxt("Greece");
            countrys[24].brief_information.Image = Image.FromFile("info_Greece.gif");
            
            //
            
            //
            countrys[25].Name = "Македония";
            countrys[25].picture.Image = Image.FromFile("Macedonia.jpg");
            countrys[25].picture.Location = new System.Drawing.Point(992,596);
            countrys[25].picture.Size = new System.Drawing.Size(98,79);
            countrys[25].picture.Visible=false;
            countrys[25].picture.InitialImage=img_fon;
            countrys[25].coordinates = new Coordinates(1007,619,107,640);
            countrys[25].ExtendedInfo = ReadTxt("Macedonia");
            //
 
            //

            //
            countrys[26].Name = "Сербия";
            countrys[26].picture.Image = Image.FromFile("Serbia.jpg");
            countrys[26].picture.Location = new System.Drawing.Point(971,470);
            countrys[26].picture.Size = new System.Drawing.Size(112,159);
            countrys[26].picture.Visible=false;
            countrys[26].picture.InitialImage=img_fon;
            countrys[26].coordinates = new Coordinates(986,490,1053,590);
            countrys[26].ExtendedInfo = "";
            //
            countrys[27].Name = "Босния";
            countrys[27].picture.Image = Image.FromFile("Bosnia.jpg");
            countrys[27].picture.Location = new System.Drawing.Point(913,494);
            countrys[27].picture.Size = new System.Drawing.Size(101,109);
            countrys[27].picture.Visible=false;
            countrys[27].picture.InitialImage=img_fon;
            countrys[27].coordinates = new Coordinates(917,517,987,567);
            countrys[27].ExtendedInfo = ReadTxt("Bosnia");
            //
            countrys[28].Name = "Хорватия";
            countrys[28].picture.Image = Image.FromFile("Croatia.jpg");
            countrys[28].picture.Location = new System.Drawing.Point(861,451);
            countrys[28].picture.Size = new System.Drawing.Size(132,127);
            countrys[28].picture.Visible=false;
            countrys[28].picture.InitialImage=img_fon;
            countrys[28].coordinates = new Coordinates(889,493,972,505);
            countrys[28].ExtendedInfo = ReadTxt("Croatia");
            //
            countrys[29].Name = "Словения";
            countrys[29].picture.Image = Image.FromFile("Slovenia.jpg");
            countrys[29].picture.Location = new System.Drawing.Point(852,433);
            countrys[29].picture.Size = new System.Drawing.Size(91,72);
            countrys[29].picture.Visible=false;
            countrys[29].picture.InitialImage=img_fon;
            countrys[29].coordinates = new Coordinates(867,455,912,471);
            countrys[29].ExtendedInfo = ReadTxt("Slovenia");

            //

            //

            //
            countrys[30].Name = "Австрия";
            countrys[30].picture.Image = Image.FromFile("Austria.jpg");
            countrys[30].picture.Location = new System.Drawing.Point(763,374);
            countrys[30].picture.Size = new System.Drawing.Size(198,96);
            countrys[30].picture.Visible=false;
            countrys[30].picture.InitialImage=img_fon;
            countrys[30].coordinates = new Coordinates(859,400,925,440);
            countrys[30].ExtendedInfo = ReadTxt("Austria");
            //

            //


            countrys[31].Name = "Швейцария";
            countrys[31].picture.Image = Image.FromFile("Switzerland.jpg");
            countrys[31].picture.Location = new System.Drawing.Point(692,378);
            countrys[31].picture.Size = new System.Drawing.Size(128,74);
            countrys[31].picture.Visible = false;
            countrys[31].picture.InitialImage = img_fon;
            countrys[31].coordinates = new Coordinates(713,406,791,436);
            countrys[31].ExtendedInfo = ReadTxt("Switzerland");
            
            countrys[32].Name = "Италия";
            countrys[32].picture.Image = Image.FromFile("Italy.jpg");
            countrys[32].picture.Location = new System.Drawing.Point(706,425);
            countrys[32].picture.Size = new System.Drawing.Size(264,321);
            countrys[32].picture.Visible = false;
            countrys[32].picture.InitialImage = img_fon;
            countrys[32].coordinates = new Coordinates(723,448,949,667);
            countrys[32].ExtendedInfo = ReadTxt("Italy");
            countrys[32].brief_information.Image = Image.FromFile("info_Italy.gif");

            SelectedCountry = countrys[0];
            
        }




        void picture_MouseClick(object sender, MouseEventArgs e)
        {
            this.SelectedCountry = MF.fuction_return();
            MF.Close(); 
        }
        
        public void ShowMap()
        {
            MF = new MapForm(this.countrys,this);
            MF.Show();
        }

        
    }
}

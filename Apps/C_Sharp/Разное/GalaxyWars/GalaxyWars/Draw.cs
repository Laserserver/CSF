using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GalaxyWars
{
    class Draw
    {
        Graphics g;
        Bitmap bm;
        public Star star;
        public List<Civilisation> civ;
        public Draw(Size size) 
        {
             bm = new Bitmap(size.Width, size.Height);
             g = Graphics.FromImage(bm);
            star = new Star(Properties.Resources.Sun, 100, new Point(size.Width / 2 - 100, size.Height / 2 - 100));
            civ = new List<Civilisation>();

            
        }
        public void Refresh(Size size)
        {
            if (size.Width != 0 && size.Height != 0)
            {
                bm = new Bitmap(size.Width, size.Height);
                g = Graphics.FromImage(bm);
            }
        }
        public void Work(bool period)
        {
            foreach(Civilisation c in civ)
            {
                c.Work(period, star.Planets, g);
            }
        }
        public void ImDraw(Graphics G,bool period)
        {
            g.Clear(Color.Black);
            
            star.Draw(g);
            Work(period);
            
            G.DrawImage(bm as Image, 0, 0);
        }
    }
    class Galaxy
    {
        public List<Star> stars;
        public List<Civilisation> teams;
        static public Size size;
        public Galaxy(Size size)
        {
            Galaxy.size = size;
        }
        public void InitRand(int teams_count)
        {
            Random rand = new Random();
            stars = new List<Star>();
            teams = new List<Civilisation>();
            int n = rand.Next(2, 6);

            stars.Add(new Star(Properties.Resources.Sun, rand.Next(70, 80),
                new Point(size.Width / 2 - 100, size.Height / 2 - 100)));
            stars[0].Loc = new Point(stars[0].Area.Width/2, stars[0].Area.Height/2);
            stars[0].Refresh();
            for (int i = 1; i < n; i++)
            {
                rand = new Random(rand.Next());
                stars.Add(new Star(Properties.Resources.Sun, rand.Next(70,80),
                    new Point(size.Width / 2 - 100, size.Height / 2 - 100)));

                //центр текущей звезды
                int x = stars[i - 1].Loc.X + stars[i - 1].Area.Width / 2//правая граница предыдущего 
                    + stars[stars.Count - 1].Area.Width / 2;// левая граница текущего
                int y= stars[i - 1].Loc.Y + stars[i - 1].Area.Height / 2// нижняя граница предыдущего 
                    + stars[stars.Count - 1].Area.Height / 2;// верхняя граница текущего
                if (x+ stars[stars.Count - 1].Area.Width / 2<size.Width)
                {
                    stars[stars.Count - 1].Loc = new Point(x, stars[i - 1].Loc.Y);
                    stars[stars.Count - 1].Refresh();
                }
                else
                {
                    if (y + stars[stars.Count - 1].Area.Height / 2 < size.Height)
                    {
                        stars[stars.Count - 1].Loc = new Point(stars[0].Loc.X, y);
                        stars[stars.Count - 1].Refresh();
                    }
                    else
                        break;
                }
               
            }

        }
    }
}

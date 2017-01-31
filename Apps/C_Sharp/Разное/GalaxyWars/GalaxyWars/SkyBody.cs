using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GalaxyWars
{
    enum Resources
    {
        metal,carbon,organic
    }
    enum Strategy
    {
        colonise,colonise_defend, agressive
    }
    struct Priority
    {
        public int[] K;
        public Priority(Strategy s)
        {
            switch ((int)s)//c f b
            {
                case 0:
                    K = new int[] { 4, 1, 0 };
                    break;
                case 2:
                    K = new int[] { 1, 1, 3 };
                    break;

                case 1:
                    K = new int[] { 2, 3, 0 };
                    break;
                default:
                    K = new int[] { 0, 0, 0 };
                    break;
            }
        }
    }
    abstract class SkyBody
    {
        
        protected Random rand;
        protected Image texture;
        protected Rectangle area;
        public int Size { get; set; }
        public Civilisation team;
        public Point Loc { get; set; }
        public Rectangle Area
        {
            get
            {
                return area;
            }
        }

        public abstract void Draw(Graphics g);
        public SkyBody(Image texture,int size,Point Loc)
        {
            rand = new Random();
            this.texture = texture;
            this.Size = size;
            this.Loc = Loc;
        }

    }
    class Star : SkyBody
    {
        List<Planet> planets;
        Rectangle rect;
        public Star(Image texture, int size, Point Loc):base(texture,size,Loc)
        {
            Size = size;
            rand = new Random(rand.Next());
            int n = rand.Next(5,15);

            planets = new List<Planet>(n);
            for (int i = 0; i < n; i++)
            {
                int s = rand.Next(size / 3, size / 2);
                int k = rand.Next();
                planets.Add(
                    new Planet(Properties.Resources.Earth, s,
                        new Point((int)(Loc.X + size / 2 + s / 2 + (size + size * i / 3) * Math.Cos(k * Math.PI * i / n)),
                                  (int)(Loc.Y + size / 2 + s / 2 + (size + size * i / 3) * Math.Sin(k * Math.PI * i / n)))
                                                                                                      ));
            }
            for(int i = 0; i< planets.Count;i++)
            {
                if(planets.Any(p=>p.Area.IntersectsWith(planets[i].Area)))
                {
                    planets.RemoveAt(i);
                }
            }
            n = planets.Count;
            int x = (Loc.X + size / 2 - (size + size * n / 3)),
                y = (Loc.Y + size / 2 - (size + size * n / 3)),
                z = 2*(size + size * n / 3)+size/2;

            area = new Rectangle(x,y,z,z);
            rect = new Rectangle(Loc, new Size(size, size));
        }
        
        internal List<Planet> Planets
        {
            get
            {
                return planets;
            }
        }
        public void Refresh()
        {

            int x = (Loc.X + Size / 2 - (Size + Size * planets.Count / 3)),
                y = (Loc.Y + Size / 2 - (Size + Size * planets.Count / 3)),
                z = 2 * (Size + Size * planets.Count / 3) + Size / 2;

            area = new Rectangle(x, y, z, z);
            int n = planets.Count;
            planets.Clear();
            for (int i = 0; i < n; i++)
            {
                int s = rand.Next(Size / 3, Size / 2);
                int k = rand.Next();
                planets.Add(
                    new Planet(Properties.Resources.Earth, s,
                        new Point((int)(Loc.X + Size / 2 + s / 2 + (Size + Size * i / 3) * Math.Cos(k * Math.PI * i / n)),
                                  (int)(Loc.Y + Size / 2 + s / 2 + (Size + Size * i / 3) * Math.Sin(k * Math.PI * i / n)))
                                                                                                      ));
            }
        }
        public override void Draw(Graphics g)
        {
           // g.FillRectangle(new SolidBrush(team.color), area);
            g.DrawImage(texture, rect);
            foreach (Planet p in planets)
            {
                p.Draw(g);
            }
          
        }
    }
    class Planet : SkyBody
    {
        Rectangle rect;
        Dictionary<Resources, int> resourse;
       public List< Fleet> Orbit;
        public Planet(Image texture, int size, Point Loc) : base(texture, size, Loc)
        {
            team = new Civilisation(0,0,this);
            rand = new Random(rand.Next());
            rect = new Rectangle(Loc.X-size/2,Loc.Y-size/2, size+size/4, size);
            resourse = new Dictionary<Resources, int>(3);
            resourse.Add(Resources.carbon, rand.Next(100,1000));
            resourse.Add(Resources.metal, rand.Next(100,1000));
            resourse.Add(Resources.organic, rand.Next(100,1000));
            area = new Rectangle(new Point(Loc.X-size/2-size/8,Loc.Y-size/2), new Size(size + size / 4, size ));
            Orbit = new List<Fleet>();
        }
        public Planet(Image texture, int size, Point Loc,int carbon,int metal,int organic) : base(texture, size, Loc)
        {
            rect = new Rectangle(Loc.X - size / 2, Loc.Y - size / 2, size + size / 4, size);
            resourse = new Dictionary<Resources, int>(3);
            resourse.Add(Resources.carbon, carbon);
            resourse.Add(Resources.metal, metal);
            resourse.Add(Resources.organic, organic);

        }

      

        internal Dictionary<Resources, int> Resourse
        {
            get
            {
                return resourse;
            }
        }
       
        public override void Draw(Graphics g)
        {

            g.FillEllipse(new SolidBrush(team.color), new Rectangle(rect.Location.X+2, rect.Location.Y+2, rect.Width-4,rect.Height-4));
            g.DrawImage(texture, rect);
            for(int i = 0; i< Orbit.Count;i++)
            {
                for(int j = i+1;j<Orbit.Count;j++)
                {
                    if(Orbit[i].team.team!=Orbit[j].team.team)
                    {
                        Orbit[i].Fight(Orbit[j]);
                        if(Orbit[i].HP<=0)
                        {
                            Orbit[i].team.fleet.Remove(Orbit[i]);
                            Orbit.RemoveAt(i);
                        }
                    }
                    

                }
            }
            try {
                for (int i = 0; i < Orbit.Count; i++)
                {
                    if (Orbit.All(ff => ff.team.team == Orbit[i].team.team))
                    {
                        if (Orbit[i] is Colony)
                        {
                            (Orbit[i] as Colony).Colonise(this);
                        }
                        if (Orbit[i] is Bomber)
                        {
                            if (this.team.team != Orbit[i].team.team)
                                (Orbit[i] as Bomber).Bomb(this);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                
            }

        }
        
    }
    
    abstract class Fleet
    {
        public int Damage;
        public int HP {get; set;}
        public Planet planet;
        public Civilisation team;
        public Point[] figure;
        public Point Loc;
        public abstract void Draw(Graphics g, List<Planet> planets);
        public abstract void Behavior(List<Planet> planets);
        public bool Move(Planet planet)
        {

            int b = Math.Abs(Loc.X - planet.Loc.X) == 0 ? 1 : Math.Abs(Loc.X - planet.Loc.X);
            int a = Math.Abs(Loc.Y - planet.Loc.Y) == 0 ? 0 : Math.Abs(Loc.Y - planet.Loc.Y);
            double phi = Math.Atan(a / b);
            int x = (int)(10 * Math.Cos(phi * (3.141592 / 180)))
                , y = 10;//(int)(10*Math.Sin(phi * (3.141592 / 180)));

            if (!planet.Area.Contains(Loc))
            {
                if (Loc.X < planet.Loc.X && Loc.Y <= planet.Loc.Y)
                {
                    Loc.X += x;
                    Loc.Y += y;
                }
                if (Loc.X < planet.Loc.X && Loc.Y > planet.Loc.Y)
                {
                    Loc.X += x;
                    Loc.Y -= y;
                }
                if (Loc.X > planet.Loc.X && Loc.Y <= planet.Loc.Y)
                {
                    Loc.X -= x;
                    Loc.Y += y;
                }
                if (Loc.X > planet.Loc.X && Loc.Y > planet.Loc.Y)
                {
                    Loc.X -= x;
                    Loc.Y -= y;
                }
            }
            else return true;
            return false;     

        }
        protected int size = 10;
        public void Fight(Fleet enemy)
        {
            if (enemy.team != this.team)
            {
                enemy.HP -= this.Damage;
                this.HP -= enemy.Damage;
                if (enemy.HP <= 0)
                {
                    enemy.team.fleet.Remove(enemy);
                    enemy.planet.Orbit.Remove(enemy);
                }
                //вадим, узбагойся!
            }
        }
        public Fleet(Point Loc,Civilisation team)
        {
            this.Loc = Loc;
            this.team = team;
            HP = 100;
        }

    }
    //todo: истощение планет
    class Fighter : Fleet
    {
        public static int Metal = 10, Carbon = 20, Organic = 5;
    
        public Fighter(Planet planet,Civilisation team):base(planet.Loc, team) 
        {
            this.planet = planet;
            figure = new Point[] 
            {
                new Point(Loc.X, Loc.Y-size/2),
                new Point(Loc.X + size/2, Loc.Y+size/2),
                new Point(Loc.X - size/2, Loc.Y+size/2)
            };
            Damage = 100;
        }
        double Distance(Point A, Point B)
        {
            return Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
        }
        Planet SearchPlanet(List<Planet> planets, List<int> index)//переделать с зависимостью от стратегии
        {
            double max = 0;
            int maxi = -1;
            for (int i = 0; i < planets.Count; i++)
            {
                if (Distance(planets[i].Loc, Loc) > max)
                {
                    if (index.Any(R => R != i))
                    {
                        max = Distance(planets[i].Loc, Loc);
                        index.Add(planets.IndexOf(planet));
                        maxi = i;
                    }
                }

            }
            bool k = false;
            Planet result;
            if (maxi >= 0)
                result = planets[maxi];
            else
                result = null;
            index.ForEach(R => { if (index.Count > 0) if (planets[R] == planets[maxi]) k = true; });
            switch ((int)team.strategy)
            {
                case 0:
                    break;
                case 1:
                    if (planets[maxi].team != this.team || planets[maxi] == planet ||planets[maxi].Orbit.Count>0|| k)
                    {
                        result = SearchPlanet(planets, index);
                    }
                    else
                    {
                        return result;
                    }
                   
                    break;
                case 2:
                    if (planets[maxi].team == this.team || planets[maxi].Orbit.Count == 0 || planets[maxi] == planet || k)
                    {
                        result = SearchPlanet(planets, index);
                    }
                    else
                    {
                        return result;
                    }
                    break;
            }

            return result;
        }
        Planet SearchPlanet(List<Planet> planets)
        {
            Planet result = null;

            switch ((int)team.strategy)
            {
                case 0:
                    break;
                case 1:
                    for (int i = 0; i < planets.Count; i++)
                    {
                        if ( planets[i].team == this.team && planets[i] != planet)
                        {
                            result = planets[i];
                            break;
                        }

                    }
                    break;
                case 2:
                    for (int i = 0; i < planets.Count; i++)
                    {
                        if (planets[i].team != this.team && planets[i] != planet && planets[i].Orbit.Count != 0)
                        {
                            result = planets[i];
                            break;
                        }

                    }                   
                    break;
            }
         
            

            return result;
        }
        public override void Behavior(List<Planet> planets)
        {
            // List<int> index = new List<int>();
            Planet temp = SearchPlanet(planets);
            if (temp != null)
            {
                planet.Orbit.Remove(this);
                if (Move(temp))
                {
                    if (temp.Orbit.Count > 0)
                    {
                        for (int i = 0; i < planets[planets.IndexOf(temp)].Orbit.Count; i++)
                        {
                            if (this.HP > 0) this.Fight(planets[planets.IndexOf(temp)].Orbit[i]); if (this.HP <= 0) this.team.fleet.Remove(this);
                        }
                    }
                    if (HP > 0)
                    {
                        planets[planets.IndexOf(temp)].Orbit.Add(this);
                        this.planet = planets[planets.IndexOf(temp)];
                    }
                }
            }


        }
        public override void Draw(Graphics g, List<Planet> planets)
        {
            Behavior(planets);
            figure = new Point[]
             {
                new Point(Loc.X, Loc.Y-size/2),
                new Point(Loc.X + size/2, Loc.Y+size/2),
                new Point(Loc.X - size/2, Loc.Y+size/2)
             };
            g.FillPolygon(new SolidBrush(team.color), figure);
            g.DrawPolygon(Pens.Black, figure);
        }
    }
    class Bomber : Fleet
    {

        public static int Metal = 20, Carbon = 10, Organic = 5;
        public Bomber(Planet planet, Civilisation team) : base(planet.Loc, team)
        {
            Damage = 50;
            this.planet = planet;
            figure = new Point[] 
            {
                new Point(Loc.X - size, Loc.Y - size),
                new Point(Loc.X + size, Loc.Y - size),
                new Point(Loc.X + size, Loc.Y + size),
                new Point(Loc.X - size, Loc.Y + size)
            };
        }
        double Distance(Point A, Point B)
        {
            return Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
        }
        Planet SearchPlanet(List<Planet> planets,List<int> index)
        {
            double max = 0;
            int maxi = -1;
            for (int i = 0; i < planets.Count; i++)
            {
                if (Distance(planets[i].Loc, Loc) > max)
                {
                    if (index.Any(R => R != i))
                    {
                        max = Distance(planets[i].Loc, Loc);
                        index.Add(planets.IndexOf(planet));
                        maxi = i;
                    }
                }

            }
            bool k = false;
            Planet result;
            if (maxi >= 0)
                result = planets[maxi];
            else
                result = null;
            index.ForEach(R => { if (index.Count > 0) if (planets[R] == planets[maxi]) k = true; });
            if (planets[maxi].team == this.team ||planets[maxi].team.team==0|| planets[maxi] == planet||k)
            {
                result = SearchPlanet(planets, index);
            }
            else
            {
                return result;
            }

            return result;
        }
        Planet SearchPlanet(List<Planet> planets)
        {
            Planet result = null;

            for (int i = 0; i < planets.Count; i++)
            {
                if (planets[i].team.team != 0 && planets[i].team != this.team && planets[i] != planet)
                {
                    result = planets[i];
                    break;
                }

            }

            return result;
        }
        public override void Behavior(List<Planet> planets)
        {
            // List<int> index = new List<int>();
            Planet temp = SearchPlanet(planets);
            if (temp != null)
            {
                planet.Orbit.Remove(this);
                if (Move(temp))
                {
                    if (temp.Orbit.Count > 0)
                    {
                        for (int i = 0; i < planets[planets.IndexOf(temp)].Orbit.Count; i++)
                        {
                            if (this.HP > 0) this.Fight(planets[planets.IndexOf(temp)].Orbit[i]); if (this.HP <= 0) this.team.fleet.Remove(this);
                        }
                    }
                    if (HP > 0)
                    {
                        planets[planets.IndexOf(temp)].Orbit.Add(this);
                        this.planet = planets[planets.IndexOf(temp)];

                        Bomb(planets[planets.IndexOf(temp)]);
                    }
                }
            }


        }
        public override void Draw(Graphics g,List<Planet> planets)
        {
            Behavior(planets);
            figure =new Point[]
           {
                new Point(Loc.X - size, Loc.Y - size),
                new Point(Loc.X + size, Loc.Y - size),
                new Point(Loc.X + size, Loc.Y + size),
                new Point(Loc.X - size, Loc.Y + size)
           };
            g.FillPolygon(new SolidBrush(team.color), figure);
            g.DrawPolygon(Pens.Black,figure);

        }
        public void Bomb(Planet planet)
        {
            if (planet.team != team)
            {
                planet.team.planets.Remove(planet);
                planet.team = new Civilisation(0, 0, planet);
            }
        }
    }
    class Colony : Fleet
    {

        public static int Metal = 10, Carbon = 10, Organic = 50;
        Rectangle O;
        public Colony(Planet planet, Civilisation team) : base(planet.Loc, team)
        {
            Damage = 0;
            this.planet = planet;
            
            O = new Rectangle(Loc.X - size / 2, Loc.Y - size / 2, size, size);
        }
        double Distance(Point A, Point B)
        {
            return Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
        }
        Planet SearchPlanet(List<Planet> planets)
        {
            Planet result = null;
            
            for (int i = 0; i < planets.Count; i++)
            {
                if (planets[i].team.team == 0 && planets[i] != planet&&planets[i].team!=this.team)
                {
                    result = planets[i];
                    break;
                }

            }

            return result;
        }
        Planet SearchPlanet(List<Planet> planets, List<int> index)
        {
            double max = 0;
            int maxi = -1;
            for (int i = 0; i < planets.Count; i++)
            {
                if (Distance(planets[i].Loc, Loc) > max)
                {
                    if (index.Any(R => R != i))
                    {
                        max = Distance(planets[i].Loc, Loc);
                        index.Add(planets.IndexOf(planet));
                        maxi = i;
                    }
                }

            }
            bool k = false;
            Planet result;
            if (maxi >= 0)
            {
                result = planets[maxi];
                index.ForEach(R => { if (index.Count > 0) if (planets[R] == planets[maxi]) k = true; });
                if (planets[maxi].team == this.team || planets[maxi].team.team != 0 || planets[maxi] == planet || k)
                {
                    result = SearchPlanet(planets, index);
                }
                else
                {
                    return result;
                }

            }
            else
            {
                result = null;
                if(index.Count!=planets.Count)
                result = SearchPlanet(planets, index);
            }
           
            return result;
        }
        public override void Behavior(List<Planet> planets)
        {
           // List<int> index = new List<int>();
            Planet temp = SearchPlanet(planets);
            if (temp != null)
            {
                planet.Orbit.Remove(this);
                if (Move(temp))
                {
                    if (temp.Orbit.Count > 0)
                    {
                        for (int i = 0; i < planets[planets.IndexOf(temp)].Orbit.Count; i++)
                        {
                            if (this.HP > 0) this.Fight(planets[planets.IndexOf(temp)].Orbit[i]); if (this.HP <= 0) this.team.fleet.Remove(this);
                        }
                    }
                    if (HP > 0)
                    {
                        Colonise(planets[planets.IndexOf(temp)]);
                    }
                }
            }
        }
        public override void Draw(Graphics g, List<Planet> planets)
        {
            Behavior(planets);
            O = new Rectangle(Loc.X - size / 2, Loc.Y - size / 2, size, size);
            g.FillRectangle(new SolidBrush(team.color), O);
            g.DrawRectangle(Pens.Black, O);
        }
        public void Colonise(Planet planet)
        {
            if (planet.team.team == 0)
            {
                planet.team = this.team;
                team.planets.Add(planet);
                this.team.fleet.Remove(this);
                planet.Orbit.Remove(this);
            }
        }
    }
    class Civilisation
    {
        public int limit = 5;
        public List<Planet> planets;
        public List<Fleet> fleet;
       public  Color color;
       public  int team;
        public Strategy strategy;
        public Priority prior;
        Random rand;
        public Civilisation(int team,Strategy s,Planet startplanet)
        {
            rand = new Random();
            this.team = team;
            byte R = (byte)(team == 0 ? 0 :255-50*team), 
                 G = (byte)(team == 0 ? 0 : 255/team-10*team),
                 B = (byte)(team == 0 ? 0 : 255 / team);
            color = Color.FromArgb(R, G, B);
            strategy = s;
            prior = new Priority(s);
            planets = new List<Planet>();
            planets.Add(startplanet);
            fleet = new List<Fleet>();
            if (team != 0)
            {
                fleet.Add(new Colony(startplanet, this));
                startplanet.Orbit.Add(fleet[0]);
            }
        }
        public void Work(bool period,List<Planet> pplanets, Graphics g)
        {
            if (period)
            {
                foreach (Planet p in planets)
                {
                    for(int i = 0;i<prior.K.Length;i++)
                    {

                        switch (i)
                        {
                            case 0:
                                bool alot = false;
                                fleet.ForEach(R => { int l = 0; if (R is Colony) l++; alot = l>= prior.K[i]; });
                                if (!alot)
                                {
                                    p.Resourse[0] -= Colony.Metal;
                                    p.Resourse[(Resources)1] -= Colony.Carbon;
                                    p.Resourse[(Resources)2] -= Colony.Organic;
                                    if (p.Resourse.Any(R => R.Value < 0))
                                    {
                                        p.Resourse[0] += Colony.Metal;
                                        p.Resourse[(Resources)1] += Colony.Carbon;
                                        p.Resourse[(Resources)2] += Colony.Organic;
                                        break;
                                    }
                                    p.Orbit.Add(new Colony(p, this));
                                    p.team.fleet.Add(p.Orbit[p.Orbit.Count - 1]);
                                }
                                break;
                            case 1:
                                alot = false;
                                fleet.ForEach(R => { int l = 0; if (R is Fighter) l++; alot = l >= prior.K[i]; });
                                if (!alot)
                                {
                                    p.Resourse[0] -= Fighter.Metal;
                                    p.Resourse[(Resources)1] -= Fighter.Carbon;
                                    p.Resourse[(Resources)2] -= Fighter.Organic;
                                    if (p.Resourse.Any(R => R.Value < 0))
                                    {
                                        p.Resourse[0] += Fighter.Metal;
                                        p.Resourse[(Resources)1] += Fighter.Carbon;
                                        p.Resourse[(Resources)2] += Fighter.Organic;
                                        break;
                                    }
                                    p.Orbit.Add(new Fighter(p, this));

                                    p.team.fleet.Add(p.Orbit[p.Orbit.Count - 1]);
                                }
                                break;
                            case 2:
                                alot = false;
                                fleet.ForEach(R => { int l = 0; if (R is Bomber) l++; alot = l >= prior.K[i]; });
                                if (!alot)
                                {
                                    p.Resourse[0] -= Bomber.Metal;
                                    p.Resourse[(Resources)1] -= Bomber.Carbon;
                                    p.Resourse[(Resources)2] -= Bomber.Organic;
                                    if (p.Resourse.Any(R => R.Value < 0))
                                    {
                                        p.Resourse[0] += Bomber.Metal;
                                        p.Resourse[(Resources)1] += Bomber.Carbon;
                                        p.Resourse[(Resources)2] += Bomber.Organic;
                                        break;
                                    }
                                    p.Orbit.Add(new Bomber(p, this));

                                    p.team.fleet.Add(p.Orbit[p.Orbit.Count - 1]);
                                }
                                break;
                            default:
                                break;

                        }
                    }
                    p.Resourse[0] += 10;
                    p.Resourse[(Resources)1] += 10;
                    p.Resourse[(Resources)2] += 10;
                }
            }
            else
            {
                //foreach (Fleet f in fleet)
                //{
                //    f.Draw(g,planets);
                //}
                for(int i = 0;i<fleet.Count;i++)
                {
                    if(fleet[i].HP>0)
                    fleet[i].Draw(g, pplanets);
                }
            }

        }

    }
    

}

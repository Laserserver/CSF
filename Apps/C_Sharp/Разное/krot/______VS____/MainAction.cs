using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ДачникVSКрот
{
    //Делегаты для общения этого класса с формой
    public delegate void DelegateCrotEventHandler(int sender);
    public delegate void DelegatePlantEventHandler(int sender);
    public delegate void DelegateEndEventHandler(object sender, MyEventArg Arg);

    public class MainAction
    {
        //События, связанные с верхними делегатами
        public event DelegateCrotEventHandler EventCrotCountChange;
        public event DelegatePlantEventHandler EventPlantCountChange;
        public event DelegateEndEventHandler EventEndGame;

        //Таймер появления кротов
        private System.Threading.Timer Tms;
        //Таймер поедания растения
        private System.Threading.Timer Eatting;
        //Список таймеров, но работает еще и как список съеденных позиций
        static List<System.Threading.Timer> DeadLockComingSoon = new List<System.Threading.Timer>();

        private Graphics PictureBoxGraph;
        private Graphics BitmapGraph;
        private Bitmap Frame;

        private Man Man = new Man();
        private GameField GameField;

        public int KrotCount = 0;
        public int KrotCreated = 0;
        public int PlantCount = 0;
        

        private const int picSize = 80;
        //Список кротов
        List<Krot> krotList = new List<Krot>();

        //Формирование экземпляра поля
        public MainAction(Button startGameButton, Bitmap Frame, Graphics PictureBoxGraph, Graphics BitmapGraph, int gameFieldI, int gamefieldJ)
        {
            GameField = new GameField(gameFieldI, gamefieldJ);
            PlantCount = GameField.plantCount;
            this.PictureBoxGraph = PictureBoxGraph;
            this.BitmapGraph = BitmapGraph;
            this.Frame = Frame;
        }
        //Убийство крота
        private void Killing(Man man)
        {
            for (int i = 0; i < krotList.Count(); i++)
            {
                if ((man.location == krotList[i].location) && (krotList[i].IsAlive))
                {
                    krotList[i].IsAlive = false;
                    GameField.game_field[krotList[i].location.X / picSize, krotList[i].location.Y / picSize].IsOccupied = false;
                    AllKrotsPaint();
                    KrotCount--;
                    EventCrotCountChange(KrotCount);
                }
            }
            if ((KrotCount == 0) && (KrotCreated == 3))
            {
                EventEndGame(this, new MyEventArg(this));
            }
        }
        //Инициализация экземпляра поля и отрисовка
        private void InitializeMyComponent()
        {
            GameField.Game_Field_Init();
            BitmapGraph = Graphics.FromImage(Frame);
            BitmapGraph.SmoothingMode = SmoothingMode.HighQuality;
        }
        //Появление крота
        private void KrotAppear(object jbj)
        {
            if (KrotCreated == 3)
            {
                Tms.Dispose();
            }
            else
            {
                Krot krot = new Krot(GameField.field_sizeI, GameField.field_sizeJ);

                KrotCreated++;
                KrotCount++;
                EventCrotCountChange(KrotCount);

                krotList.Add(krot);

                Relocation(krot);

                krot.Krot_Paint(PictureBoxGraph, BitmapGraph, Frame, krot.location.X, krot.location.Y);

                GameField.game_field[(int)(krot.location.X / picSize), (int)(krot.location.Y / picSize)].IsOccupied = true;
                Object obj = krot;

                //вызвать таймер съедения растения
                System.Threading.Timer Eatting = new System.Threading.Timer(KrotDisappear, obj, 5000, 3000);
                //Добавить в список таймеров
                DeadLockComingSoon.Add(Eatting);

            }
        }
        //Пропажа крота - убит или передислоцируется
        private void KrotDisappear(Object krot)
        {
            Krot tempKrot = (krot as Krot);

            if (tempKrot.IsAlive)
            {
                GameField.game_field[(int)(tempKrot.location.X / picSize), (int)(tempKrot.location.Y / picSize)].im = Image.FromFile(@"cell_digged.png");

                if (GameField.game_field[(int)(tempKrot.location.X / picSize), (int)(tempKrot.location.Y / picSize)].IsPlant)
                    PlantCount--;
                //вызвать событие изменения количества растений
                EventPlantCountChange(PlantCount);
                GameField.game_field[(int)(tempKrot.location.X / picSize), (int)(tempKrot.location.Y / picSize)].IsEatten = true;

                if ((PlantCount == 0))
                {
                    EventEndGame(this, new MyEventArg(this));
                }
                if (PlantCount != 0)
                {
                    Point oldXY = tempKrot.location;
                    Relocation(tempKrot); //рандомить крота на новую клетку                    

                    GameField.game_field[oldXY.X / picSize, oldXY.Y / picSize].IsOccupied = false;
                    GameField.Game_Field_Paint(PictureBoxGraph, BitmapGraph, Frame);

                    AllKrotsPaint();

                    Man.Man_Paint(PictureBoxGraph, BitmapGraph, Frame, Man.location.X, Man.location.Y);
                }
            }
            else DeadLockComingSoon.Remove(Eatting);
        }
        //Переход крота на новую клетку
        private void Relocation(Krot krot)
        {
            krot.location = Krot.RandLoc(GameField.field_sizeI, GameField.field_sizeJ);
            while ((GameField.game_field[(int)(krot.location.X / picSize), (int)(krot.location.Y / picSize)].IsOccupied)
                    || (GameField.game_field[(int)(krot.location.X / picSize), (int)(krot.location.Y / picSize)].IsEatten))
            {
                krot.location = Krot.RandLoc(GameField.field_sizeI, GameField.field_sizeJ);

            }

            GameField.game_field[(int)(krot.location.X / picSize), (int)(krot.location.Y / picSize)].IsOccupied = true;
        }
        //Отрисовка живых кротов
        private void AllKrotsPaint()
        {
            foreach (Krot el in krotList)
            {
                bool flag = false;
                do
                {
                    try
                    {
                        if (el.IsAlive)
                        {
                            BitmapGraph.DrawImage(el.im, el.location.X, el.location.Y, picSize, picSize);
                        }
                        flag = true;
                    }
                    catch (InvalidOperationException)
                    {
                        System.Threading.Thread.Sleep(5);
                    }
                }
                while (flag == false);
            }
            try
            {
                PictureBoxGraph.DrawImage(Frame, 0, 0);
            }
            catch
            { }
        }
        //Полное очищение списка кротов - игрок выиграл или проиграл
        public void Clearing()
        {
            krotList.Clear();
            DeadLockComingSoon.Clear();
            foreach (System.Threading.Timer Dead in DeadLockComingSoon) Dead.Dispose();
            KrotCreated = 0;
            KrotCount = 0;
            PlantCount = (int)(GameField.field_sizeI * GameField.field_sizeJ / 3);

        }
        //Начало игры
        public void StartGame()
        {
            InitializeMyComponent();

            GameField.Game_Field_Paint(PictureBoxGraph, BitmapGraph, Frame);  //Рисуем само поле
            Man.Man_Paint(PictureBoxGraph, BitmapGraph, Frame, 0, 0);         //Рисуем чувака
            EventPlantCountChange(PlantCount);
            Tms = new System.Threading.Timer(KrotAppear, null, 1000, 1000);
        }
        //Движение чувака
        public void Move(char Ch)
        {
            char currentKey = Ch;
            switch (currentKey)
            {
                case 'L':    //левая
                    {
                        if (Man.location.X != 0)
                        {
                            Man.location.X -= picSize;
                        }
                        Man.im = Image.FromFile(@"дачник Л.PNG");
                        break;
                    }
                case 'R':    //правая
                    {
                        if (Man.location.X != ((GameField.field_sizeI - 1) * picSize))
                        {
                            Man.location.X += picSize;
                        }
                        Man.im = Image.FromFile(@"дачник.PNG");
                        break;
                    }
                case 'W':    //вперед
                    {
                        if (Man.location.Y != 0)
                        {
                            Man.location.Y -= picSize;
                        }
                        break;
                    }
                case 'S':    //вниз
                    {
                        if (Man.location.Y != ((GameField.field_sizeJ - 1) * picSize))
                        {
                            Man.location.Y += picSize;
                        }
                        break;
                    }
                case 'K':
                    {
                        Killing(Man);
                        break;
                    }
            }
            GameField.Game_Field_Paint(PictureBoxGraph, BitmapGraph, Frame);
            AllKrotsPaint();
            Man.Man_Paint(PictureBoxGraph, BitmapGraph, Frame, Man.location.X, Man.location.Y);

            // MainFrame.Focus();

        }
    }
}

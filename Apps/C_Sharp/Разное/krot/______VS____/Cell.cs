using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ДачникVSКрот
{
    //Родительский класс с данными размера картинки и массивом картинок
    class counts
    {
        public const int picSize = 80;
        private static Image[] gallery;
        public static Image[] GetGallery()
        {
            if (gallery == null)
            {
                gallery = new Image[3];
                //с растением
                gallery[0] = Image.FromFile(@"cell_plant.png");

                //просто трава
                gallery[1] = Image.FromFile(@"cell_grace.png");

                //съеденная
                gallery[2] = Image.FromFile(@"cell_digged.png");
            }
            return gallery;

        }
    }
    class GameField : counts
    {
        public Cell[,] game_field;
        public int field_sizeI;
        public int field_sizeJ;
        public int plantCount;
       

        public GameField(int field_sizeI, int field_sizeJ)
        { 
            this.field_sizeI = field_sizeI;
            this.field_sizeJ = field_sizeJ;
            this.game_field = new Cell[field_sizeI, field_sizeJ];
            this.plantCount = (int) (field_sizeI * field_sizeJ / 3);
        }

        //Выдает случайную точку поля в зависимости от времени
        private Point Rand(int key)
        {

            Random rand1 = new Random((int)(key * DateTime.Now.Ticks));
            Random rand2 = new Random(key * rand1.Next(- field_sizeI, field_sizeI));

            int i = Math.Abs(rand1.Next(-field_sizeI+1, field_sizeI-1));
            int j = Math.Abs(rand2.Next(-field_sizeJ+1, field_sizeJ-1));

            Point p = new Point(i, j);

            return p;

        }

        //Установка растений по рандому
        private void RandPlants()
        {
            Point p;

            for (int t = 0; t < plantCount; t++)
            {
                do
                    p = Rand((int)DateTime.Now.Ticks);
                while (game_field[p.X, p.Y].IsPlant);

                game_field[p.X, p.Y] = new Cell(1, 0, 0, 0);
            }
        }
        //Инициализация поля
        public void Game_Field_Init()
        {
            for (int i = 0; i < field_sizeI; i++)
            {
                for (int j = 0; j < field_sizeJ; j++)
                {
                    game_field[i, j] = new Cell(0, 1, 0, 0);
                }
            }
            RandPlants();
        }
        //Отрисовка картинок на поле
        public void Game_Field_Paint(Graphics PictureBoxGraph, Graphics BitmapGraph, Bitmap Frame)
        {
            try
            {
                for (int i = 0; i < field_sizeI; i++)
                {
                    for (int j = 0; j < field_sizeJ; j++)
                    {
                        BitmapGraph.DrawImage(game_field[i, j].im, i * picSize, j * picSize, picSize, picSize);
                    }
                }
                PictureBoxGraph.DrawImage(Frame, 0, 0);
            }
            catch
            { }
        }
    }

    class Main
    {
        public const int picSize = 80;
        public Image im;
        public Point location;
    }
    //Класс ячейки, хранящий состояние ячейки
    class Cell : Main
    {
        public bool IsPlant = false;
        public bool IsGrace = false;
        public bool IsEatten = false;
        public bool IsOccupied = false;

        public Cell(int IsPlant, int IsGrace, int IsEatten, int IsOccurpied)
        {
            //Заталкиваем нужные картинки
            if (IsPlant == 1) { this.IsPlant = true; this.im = counts.GetGallery()[0]; }
            if (IsGrace == 1) { this.IsGrace = true; this.im = counts.GetGallery()[1]; }
            if (IsEatten == 1) { this.IsEatten = true; this.im = counts.GetGallery()[2]; }
            if (IsOccurpied == 1) this.IsOccupied = true;
        }

    }

    class Krot : Main
    {
        public bool IsAlive = true;

        public Krot(int game_fieldI, int game_fieldJ)
        {
            im = Image.FromFile(@"krot.png");
            location = RandLoc(game_fieldI, game_fieldJ);
            IsAlive = true;

        }
        //Получаем случайное местоположение
        public static Point RandLoc(int game_fieldI, int game_fieldJ)
        {

            Random rand1 = new Random((int)DateTime.Now.Ticks);
            Random rand2 = new Random((int)DateTime.Now.Millisecond * rand1.Next(- game_fieldI, game_fieldJ));

            int i = Math.Abs(rand1.Next(0, game_fieldI));
            int j = Math.Abs(rand2.Next(0, game_fieldJ));

            Point p = new Point(i * picSize, j * picSize);

            return p;
        }
        //Отрисовка
        public void Krot_Paint(Graphics PictureBoxGraph, Graphics BitmapGraph, Bitmap Frame, int X, int Y)
        {
            bool u = false;
            do
            {
                try
                {
                    BitmapGraph.DrawImage(im, X, Y, picSize, picSize);
                    PictureBoxGraph.DrawImage(Frame, 0, 0);
                    u = true;
                }
                catch (InvalidOperationException)//Экзепшн который вылетает при допросе
                {
                    System.Threading.Thread.Sleep(1);
                    u = false;
                }
            }
            while (!u);
        }
    }

    class Man : Main
    {
        public Man()
        {
            this.location = new Point(0, 0);
            this.im = Image.FromFile(@"дачник.PNG");
        }
        //Отрисовка 
        public void Man_Paint(Graphics PictureBoxGraph, Graphics BitmapGraph, Bitmap Frame, int X, int Y)
        {
            try
            {
                BitmapGraph.DrawImage(im, X, Y, picSize, picSize);
                try
                {
                    PictureBoxGraph.DrawImage(Frame, 0, 0);
                }
                catch
                { }
            }
            catch (InvalidOperationException)//Экзепшн который вылетает при допросе
            {
                System.Threading.Thread.Sleep(5);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uslovshina41
{
    class Program
    {
        static void Main(string[] args)
        {
            /*41.	Даны координаты трех точек на плоскости. Если они могут быть вершинами
             * остроугольного треугольника, вывести их в порядке убывания, вычислить площадь полученного треугольника.*/
            double X0 = 0, X1 = 0, X2 = 0, 
                   Y0 = 0, Y1 = 0, Y2 = 0,
            First = 0, Second = 0, Third = 0, Square = 0, Temp = 0;
            Console.WriteLine("Вас приветствует программа, вычисляющая площадь остроугольного треугольника по\nкоординатам его вершин.");
            Console.WriteLine("Введите координаты (X и Y) первой вершины:");
            double.TryParse(Console.ReadLine(), out X0);
            double.TryParse(Console.ReadLine(), out Y0);
            Console.WriteLine("Введите координаты (X и Y) второй вершины:");
            double.TryParse(Console.ReadLine(), out X1);
            double.TryParse(Console.ReadLine(), out Y1);
            Console.WriteLine("Введите координаты (X и Y) третьей вершины:");
            double.TryParse(Console.ReadLine(), out X2);
            double.TryParse(Console.ReadLine(), out Y2);
            First = Math.Sqrt((X1 - X0) * (X1 - X0) + (Y1 - Y0) * (Y1 - Y0));
            Second = Math.Sqrt((X2 - X1) * (X2 - X1) + (Y2 - Y1) * (Y2 - Y1));
            Third = Math.Sqrt((X2 - X0) * (X2 - X0) + (Y2 - Y0) * (Y2 - Y0)); 
            if (First < Second)
            {
                Temp = First;
                First = Second;
                Second = Temp;
            }
            if (First < Third)
            {
                Temp = First;
                First = Third;
                Third = Temp;
            }
            if (Second < Third)
            {
                Temp = Second;
                Second = Third;
                Third = Temp;
            }
            if (First + Second > Third && Third * Third + Second * Second > First * First)
            {
                double P = (First + Second + Third) * 0.5;
                Square = Math.Sqrt(P * (P - First) * (P - Second) * (P - Third));
                Console.WriteLine("{0} {1} {2} {3}", Square, First, Second, Third);
            }
            else
            {
                Console.WriteLine("Треугольника с такой конфигурацией не существует или он не остроугольный.");
            }
            Console.WriteLine("Нажмите Enter для выхода.");
            Console.ReadLine();
        }
    }
}

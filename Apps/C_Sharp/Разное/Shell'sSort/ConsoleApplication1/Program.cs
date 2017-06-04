using System;
using System.Diagnostics;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        private static Stopwatch swatchSingleThreaded = new Stopwatch();
        private static Stopwatch swatchMultiThreaded = new Stopwatch();
        private static int[] array;

        private static void Main()
        {
            string arrLength;//строка в которую запишем длину масссива
            int temp;//временная переменная для трайпарса
            Console.WriteLine("Please, enter a positive number of elements of sorting array.");
            arrLength = Console.ReadLine();//вводим строку
            if (Int32.TryParse(arrLength, out temp) && temp > 0)//если трайпарс выдает true, т.е. строка 
                //сконвертировалась в нашу временную инт переменную то создаем массив такого размера
            {
                CreateArray(temp);//вызываем метод создания массива
            }
            else
            {
                Console.WriteLine("Please, enter a positive number only!");
                Main();//в обратном случае выводим ошибку и заново
            }
            SingleThreadedSort(array);//сначала запускаем сортировку в один поток
            MultithreadedSort(array);//затем многопоточную
            Console.WriteLine("Time taken in sinle-sort -- {0} ms.\nTime taken in multisort -- {1} ms.", 
                swatchSingleThreaded.ElapsedMilliseconds, swatchMultiThreaded.ElapsedMilliseconds);
            //выводим в консоль результаты засекания времени на обе сортировки
            Console.ReadKey();
        }

        private static void CreateArray(int capacity)
        {//метод рандомного создания массива
                Random rnd = new Random();
                array = new int[capacity];//создаем массив вместимостью, которую передали в метод

                for (int i = 0; i < array.Length; i++)
                {//выдаем рандомные значения (от 0 до макс. значения которое может принимать инт переменная)
                    array[i] = rnd.Next(0, Int32.MaxValue);
                }
        }

        private static int[] SingleThreadedSort(int[] array)
        {//метод однопоточной сортировки
            swatchSingleThreaded.Start();//запускаем таймер
            //далее идет сортировка Шелла
            for (int step = array.Length / 2; step > 0; step /= 2)
            {
                for (int i = step; i < array.Length; i++)
                {
                    int j;
                    int temp = array[i];

                    for (j = i; j >= step; j -= step)
                    {
                        if (temp < array[j - step])
                        {
                            array[j] = array[j - step];
                        }
                        else
                        {
                            break;
                        }
                    }
                    array[j] = temp;
                }
            }
            swatchSingleThreaded.Stop();//останавливаем таймер
            return array;//возвращаем массив
        }

        private static int[] MultithreadedSort(int[] array)
        {//метод многопоточной сортировки
            swatchMultiThreaded.Start();//запускаем таймер
            int med = array.Length / 2;//находим середину 

            int[] left = new int[med];//разбиваем массив на 2 части по середине
            int[] right = new int[array.Length - med];

            for (int i = 0; i < med; i++)//заполняем эти подмассивы
            {
                left[i] = array[i];
            }

            for (int i = med; i < array.Length; i++)
            {
                right[i - med] = array[i];
            }
            //создаем потоки. через делегаты вызываем методы одиночной сортировки одновременно для двух потоков, используем join
            Thread t1 = new Thread(delegate() { SingleThreadedSort(left); });
            t1.Start();
            Thread t2 = new Thread(delegate() { SingleThreadedSort(right); });
            t2.Start();
            t1.Join();
            t2.Join();

            array = Merge(left, right);//затем вызываем метод слияния двух подмассивов в массив
            swatchMultiThreaded.Stop();//останавливаем таймер
            return array;//возвращаем массив
        }

        public static int[] Merge(int[] left, int[] right)
        {//метод слияния 2х массивов в один
            int[] buff = new int[left.Length + right.Length];//создаем новый массив который и будет результатом слияния
            int l = 0;
            int r = 0;
            //процедура слияния двух упорядоченных массивов в один (можешь загуглить если не понимаешь) 
            for (int i = 0; i < buff.Length; i++)
            {
                if (r < right.Length && l < left.Length)
                {
                    if (left[l] > right[r])
                    {
                        buff[i] = right[r++];
                    }
                    else
                    {
                        buff[i] = left[l++];
                    }
                }
                else
                {
                    if (r < right.Length)
                        buff[i] = right[r++];
                    else
                        buff[i] = left[l++];
                }
            }
            return buff;//возврат массива
        }
    }
}

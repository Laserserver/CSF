using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeaching
{
    class Search
    {
            private int numberForSearch, numberOfComparsions;
        private int[] rez;
        private bool findNumber;

        public Search()
        {
            this.findNumber = false;
        }
        private void getNumberForSearch()
        {
            Console.WriteLine("Введите номер для поиска:");
            numberForSearch = Convert.ToInt32(Console.ReadLine());
        }
        public void ShowResult()
        {
            if (findNumber)
            {
                Console.WriteLine("Позиция номера: " + rez[0] + "\nКоличество сравнений: " + rez[1]);
            }
            else
            {
                Console.WriteLine("Этого номера нет в массиве. Количество сравнений: " + rez[1]);
            }
        }
        public int[] LinearSearch(int[] arr)
        {
            Console.WriteLine("-----Линейный поиск-----");
            getNumberForSearch();
            int position = 0;
            numberOfComparsions = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == numberForSearch)
                {
                    numberOfComparsions++;
                    position = i;
                    findNumber = true;
                    break;
                }
                else
                {
                    numberOfComparsions++;
                }
                
            }

            rez = new int[] { position + 1, numberOfComparsions };
            return rez;
        }
        public int[] BinarySearch(int[] arr)
        {
            getNumberForSearch();
            numberOfComparsions = 0;

            int medium = 0, left = 0, right = arr.Length;
            while (left != right)
            {
                numberOfComparsions++;
                medium = (right + left) / 2;
                if (arr[medium] == numberForSearch)
                {
                    left = right;
                    findNumber = true;
                }
                else
                {
                    if (arr[medium] < numberForSearch)
                    {
                        left = medium + 1;
                    }
                    else
                    {
                        right = medium;
                    }
                }
            }

            rez = new int[] { medium + 1, numberOfComparsions };
            return rez;
        }

    }
}

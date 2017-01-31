using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySort
{
    class Sorting
    {
        private int numberOfComparsion;
        public int[] InsertionSort(int[] array, int numberOfElements)
        {
            bool ok;
            for (int i = 1; i < numberOfElements; i++)
            {
                int j = i;
                while (j > 0)
                {
                    ok = false;
                    numberOfComparsion++;
                    if (array[j] < array[j - 1])
                    {
                        int temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                        ok = true;
                    }
                    if (!ok)
                    {
                        break;
                    }
                    j--;
              
                }
                
            }
            
           return array;
            
        }
        public int[] BinaryInsertionSort(int[] array, int numberOfElements)
        {
            for (int i = 1; i < numberOfElements; i++)
            {
                int current = array[i];
                int min = 0;
                int max = i;
                while (min < max)
                {
                    int med = (min + max) / 2;
                    if (current < array[med])
                    {
                        max = med;
                    }
                    else
                    {
                        min = med + 1;
                    }
                    numberOfComparsion++;
                }
                for (int j = i - 1; j >= max; j--)
                {
                    array[j + 1] = array[j];
                }
                array[max] = current;
            }
            return array;
        }
        public int[] QuickSort(int[] array, int left, int right)
        {
            int temp;
            int x = array[left];
            int i = left;
            int j = right;

            while (i <= j)
            {
                while (array[i] < x)
                {
                    ++i;
                    numberOfComparsion++;
                }
                while (array[j] > x)
                {
                    --j;
                    numberOfComparsion++;
                }
                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }
            if (i < right)
            {
                QuickSort(array, i, right);
            }
            if (j > left)
            {
                QuickSort(array, left, j);
            }
            return array;
        }
        public int[] BubbleSort(int[] array, int numberOfElements)
        {
            for (int i = 0; i < numberOfElements; i++)
            {
                for (int j = numberOfElements - 1; j > i; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                    numberOfComparsion++;
                }
            }
            return array;
        }
        public int ReternNumberOfComparsion()
        {
            return numberOfComparsion;
        }
        public void print(int[] sortArray, int numberOfComparsion)
        {
         
            Console.WriteLine("Количество сравнений: " + numberOfComparsion);
        }
    }
}

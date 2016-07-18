using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
              /*7.	Напишите функцию NonAlpha(str: string), которая получает
               * параметр str типа string и возвращает позицию его первой литеры, 
               * не являющейся буквой (как латинского, так и русского алфавитов) 
               * строчной или прописной. Например, NonAlpha( 'stev7n' ) дает 5.*/
namespace Stroki7
{
    public class NonAlpha
    {
        public int i;
        public byte Num;
        public NonAlpha(string str)
    {
        while (i < str.Length)
        {
            string Temp;
            char s = str[i];
            bool ans = Char.IsDigit(s);
            Temp = Convert.ToString(s);
            byte.TryParse(Temp, out Num);
            i++;
            if (ans)
            {
                break;
                
            }
        }
    }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string Inter = null;
            Console.WriteLine("Вас приветствует программа, показывающая номер первой не-буквы в набранной Вами строке.");
            Console.Write("Введите набор символов: ");
            Inter = Console.ReadLine();
            NonAlpha(Inter);
            Console.WriteLine("Число с номером {0} - цифра {1}", i, Num);
            Console.WriteLine("Нажмите Enter для выхода из программы.");
            Console.ReadLine();
        }
    }
}

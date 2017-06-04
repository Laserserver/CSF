using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempCons
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Sas.Sas2();

            Console.Read();
        }
    }

    public delegate string MyDel(string input);

    public static class Sas
    {
        static MyDel del = (string a) => { return a + a; };

        public static void Sas2()
        {
            Console.WriteLine(del("Сасай"));
            Console.WriteLine(del("Лалка"));
        }
    }


    public sealed class Rational
    {
        dynamic Num;
        public Rational(Int32 num)
        {
            Num = num;
        }
        public Rational(Single num)
        {
            Num = num;
        }
        public Int32 ToInt32()
        {
            return (Int32)Num;
        }
        public Single ToSingle()
        {
            return 10000;
        }
        public static implicit operator Rational(Int32 num)
        {
            return new Rational(num);
        }
        public static implicit operator Rational(Single num)
        {
            return new Rational(num);
        }
        public static explicit operator Int32(Rational r)
        {
            return r.ToInt32();
        }
        public static explicit operator Single(Rational r)
        {
            return r.ToSingle();
        }
    }


    public interface IInt1
    {
        void Action();
    }

    public interface IInt2
    {
        void Action();
    }

    public class FirstClass : IInt1, IInt2
    {
        void IInt1.Action()
        {
            Console.WriteLine("It was first");
        }

        void IInt2.Action()
        {
            Console.WriteLine("It was second");
        }

        public void Action()
        {
            Console.WriteLine("Standard invoke");
        }
    }

    public class SecondClass : IInt1, IInt2
    {
        public void Action()
        {
            Console.WriteLine("Just active");
        }
    }
}

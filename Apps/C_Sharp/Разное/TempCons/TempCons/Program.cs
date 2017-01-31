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
            A a1 = new A();
            A a2 = new B();
            B b2 = new B();

            bool c1 = a1 is A;
            bool c2 = a1 is B;
            bool c3 = a2 is A;
            bool c4 = a2 is B;
            bool c5 = b2 is A;
            bool c6 = b2 is B;


            //FactoryPattern.FactoryMethod();
            //IndexTry.Method();
            //Console.Read();

            //Entity Cat = new Cat();
            //Entity Dog = new Dog();

            //Cat.Sound();
            //Dog.Sound();
            Console.Read();
        }

    }

    class A
    {

    }

    class B : A { }

    abstract class Entity
    {
        abstract public void Sound();
    }
    class Cat : Entity
    {
        public override void Sound()
        {
            Console.WriteLine("Мяу");
        }
    }
    class Dog : Entity
    {
        public override void Sound()
        {
            Console.WriteLine("Гав");
        }
    }


    static class IndexTry
    {
        public static void Method()
        {
            User Sas = new User()
            {
                Name = "Suka mudak"
            };
            Console.WriteLine(Sas.Name);
            Sas[5] = "Lol";
            Console.WriteLine(Sas[5]);
            Console.WriteLine(Sas.Name);
        }
    }

    interface IInd
    {
        string this[int ind] { get; set; }
    }

    class User : IInd
    {
        private string name;

        public string this[int ind] { get => name; set => name = value; }

        public string Name { get => name; set => name = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempCons
{
    static class FactoryPattern
    {
        public static void FactoryMethod()
        {
            Console.WriteLine("Пример паттерна фабрики");
            Random sich = new Random();
            AbstractFactory Factory = new Factory();
            List<IProduct> Products = new List<IProduct>();
            for (int i = 0; i < 15; i++)
                Products.Add(Factory.CreateProduct(sich.Next(0, 100) > 50));

            for (int i = 0; i < 15; i++)
                Console.WriteLine(Products[i].Type());
        }
    }

    interface IProduct
    {
        int Num { get; }
        string Type();
    }

    abstract class AbstractFactory
    {
        public abstract IProduct CreateProduct(bool flag);
    }

    class Factory : AbstractFactory
    {
        private int products = 0;

        public override IProduct CreateProduct(bool type)
        {
            IProduct Out;
            if (type)
                Out = new ProductTrue(++products);
            else
                Out = new ProductFalse(++products);
            return Out;
        }
    }

    class ProductTrue : IProduct
    {
        private int num;
        public ProductTrue(int num) => this.num = num;
        public int Num { get => num; }

        public string Type() => "True";
    }

    class ProductFalse : IProduct
    {
        private int num;
        public ProductFalse(int num) => this.num = num;
        public int Num { get => num; }

        public string Type() => "False";
    }
}

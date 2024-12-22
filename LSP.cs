using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class LSP
    {
        public abstract class Fruit
        {
            public Fruit()
            {
                Console.WriteLine("Fruit Class Contructor Called");
            }
            abstract public string GetColor();
        }

        public class Orange : Fruit
        {
            public override string GetColor()
            {
                return "Orange";
            }
        }

        public class Banana : Fruit
        {
            public override string GetColor()
            {
                return "Yellow";
            }
        }

        public class Program
        {
            static void Main(string[] args)
            {
                Fruit na = new Orange();
                na.GetColor();
                Fruit na1 = new Banana();
                na1.GetColor();
                Console.ReadKey();
            }
        }
    }
}

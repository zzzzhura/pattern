using PharmFactoryLib.AbstractModels;
using System;

namespace PharmFactoryLib.Models
{
    public class Vitamin : Pharm
    {
        public override void Display()
        {
            Console.WriteLine("Витамин");
        }
    }
}

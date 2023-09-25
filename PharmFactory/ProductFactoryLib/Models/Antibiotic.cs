using PharmFactoryLib.AbstractModels;
using System;

namespace PharmFactoryLib.Models
{
    public class Antibiotic : Pharm
    {
        public override void Display()
        {
            Console.WriteLine("Антибиотик");
        }
    }
}

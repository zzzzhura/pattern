using PharmFactoryLib.AbstractModels;
using System;

namespace PharmFactoryLib.Models
{
    public class AntiVirus : Pharm
    {
        public override void Display()
        {
            Console.WriteLine("Противовирусное");
        }
    }
}

using PharmFactoryLib.AbstractModels;
using System;

namespace PharmFactoryLib.Models
{
    public class Bad : Pharm
    {
        public override void Display()
        {
            Console.WriteLine("БАД (Биологически активная добавка)");
        }
    }
}

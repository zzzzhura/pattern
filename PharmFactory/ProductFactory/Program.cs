using PharmFactoryLib.AbstractModels;
using PharmFactoryLib.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmFactoryLib
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            PharmFactory usualFactory = new UsualFactory();
            Pharm usualProduct = usualFactory.CreateResipeProduct();
            Pharm usualConfectionery = usualFactory.CreateNonResipeProduct();

            Console.WriteLine("Производим безрецептурные препараты:");
            usualProduct.Display();
            usualConfectionery.Display();

            // Создаем фабрику для производства рецептурных препаратов
            PharmFactory resipeFactory = new ResipeFactory();
            Pharm antiVirusProduct = resipeFactory.CreateResipeProduct();
            Pharm antibioticProduct = resipeFactory.CreateNonResipeProduct();

            Console.WriteLine("\nПроизводим рецептурные препараты:");
            antiVirusProduct.Display();
            antibioticProduct.Display();

            Console.ReadKey();
        }
    }
}

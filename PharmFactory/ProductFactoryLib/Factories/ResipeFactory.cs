using PharmFactoryLib.AbstractModels;
using PharmFactoryLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmFactoryLib.Factories
{
    public class ResipeFactory : PharmFactory
    {
        public override Pharm CreateResipeProduct()
        {
            return new AntiVirus();
        }

        public override Pharm CreateNonResipeProduct()
        {
            return new Antibiotic();
        }
    }
}

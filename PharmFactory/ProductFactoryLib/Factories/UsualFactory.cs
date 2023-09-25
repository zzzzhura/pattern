using PharmFactoryLib.AbstractModels;
using PharmFactoryLib.Models;

namespace PharmFactoryLib.Factories
{
    public class UsualFactory : PharmFactory
    {
        public override Pharm CreateResipeProduct()
        {
            return new Bad();
        }

        public override Pharm CreateNonResipeProduct()
        {
            return new Vitamin();
        }
    }
}

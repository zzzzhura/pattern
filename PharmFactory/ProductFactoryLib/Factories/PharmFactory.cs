using PharmFactoryLib.AbstractModels;

namespace PharmFactoryLib.Factories
{
    public abstract class PharmFactory
    {
        public abstract Pharm CreateResipeProduct();
        public abstract Pharm CreateNonResipeProduct();
    }
}

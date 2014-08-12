namespace ComputersBuilder
{
    using System;

    public class ManufacturerFactory : IManufacturerFactory
    {
        private IComputerFactory factory;
        private IStringBuilderDrawer drawer;

        public ManufacturerFactory(IComputerFactory factory, IStringBuilderDrawer drawer)
        {
            this.factory = factory;
            this.drawer = drawer;
        }

        public IManufacturer GetManufacturer(string name)
        {
            if (name == "HP")
            {
                return new Hp(this.factory, this.drawer);
            }
            else if (name == "Dell")
            {
                return new Dell(this.factory, this.drawer);
            }
            else if (name == "Lenovo")
            {
                return new Lenovo(this.factory, this.drawer);
            }
            else
            {
                throw new ArgumentException("Invalid manufacturer!");
            }
        }
    }
}

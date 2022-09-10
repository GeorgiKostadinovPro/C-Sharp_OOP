namespace Facade
{
    public class CarAddresBuilder : CarBuilderFacade
    {
        public CarAddresBuilder(Car car)
        {
            this.Car = car;
        }

        public CarAddresBuilder InCity(string cityName)
        {
            this.Car.City = cityName;

            return this;
        }

        public CarAddresBuilder AtAddress(string address)
        {
            this.Car.Address = address;

            return this;
        }
    }
}

using VehiclesExtension.Models;

namespace VehiclesExtension.Factories.Interfaces
{
    public interface IVehicleFactory
    {
        Vehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity);
    }
}

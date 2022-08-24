using Vehicles.Models;

namespace Vehicles.Factories.Interfaces
{
    public interface IVehicleFactory
    {
        Vehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption);
    }
}

using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private IDictionary<int, Models.Products.Components.IComponent> components;
        private IDictionary<int, IPeripheral> peripherals;
        private IDictionary<int, IComputer> computers;

        public Controller()
        {
            this.components = new Dictionary<int, Models.Products.Components.IComponent>();
            this.peripherals = new Dictionary<int, IPeripheral>();
            this.computers = new Dictionary<int, IComputer>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            Models.Products.Components.IComponent component;

            if (this.components.ContainsKey(id))
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            IComputer computer = this.computers.FirstOrDefault(c => c.Key == computerId).Value;

            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException("Component type is invalid.");
            }

            computer.AddComponent(component);
            this.components.Add(id, component);

            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer;

            if (computers.ContainsKey(id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else 
            {
                throw new ArgumentException("Computer type is invalid.");
            }

            this.computers.Add(id, computer);
            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IPeripheral peripheral;

            if (this.peripherals.ContainsKey(id))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            IComputer computer = this.computers.FirstOrDefault(c => c.Key == computerId).Value;

            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else 
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }

            computer.AddPeripheral(peripheral);
            this.peripherals.Add(id, peripheral);

            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string BuyBest(decimal budget)
        {
            IComputer computer = this.computers
                .OrderByDescending(c => c.Value.OverallPerformance)
                .Where(c => c.Value.Price <= budget)
                .FirstOrDefault().Value;

            if (computer == null)
            {
                throw new ArgumentException("Can't buy a computer with a budget of ${budget}.");
            }

            this.computers.Remove(computer.Id);

            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Key == id).Value;

            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            this.computers.Remove(id);
            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Key == id).Value;

            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Key == computerId).Value;

            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            Models.Products.Components.IComponent component = 
                this.components.FirstOrDefault(c => c.Value.GetType().Name == componentType).Value;

            computer.RemoveComponent(componentType);
            this.components.Remove(component.Id);

            return $"Successfully removed {componentType} with id {component.Id}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Key == computerId).Value;

            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            IPeripheral peripheral =
                this.peripherals.FirstOrDefault(c => c.Value.GetType().Name == peripheralType).Value;

            computer.RemovePeripheral(peripheralType);
            this.peripherals.Remove(peripheral.Id);

            return $"Successfully removed {peripheralType} with id {peripheral.Id}.";
        }
    }
}

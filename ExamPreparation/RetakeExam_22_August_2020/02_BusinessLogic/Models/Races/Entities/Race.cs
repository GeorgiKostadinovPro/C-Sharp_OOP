using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private readonly ICollection<IDriver> drivers;

        private Race()
        {
            this.drivers = new List<IDriver>();
        }

        public Race(string name, int laps)
            : this()
        {
            this.Name = name;
            this.Laps = laps;
        }

        public string Name
        {
            get 
            {
                return this.name;
            }
            private set 
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }

                this.name = value;
            }
        } 

        public int Laps
        {
            get 
            {
                return this.laps;
            }
            private set 
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers 
            => (IReadOnlyCollection<IDriver>)this.drivers;

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentException(ExceptionMessages.DriverInvalid);
            }

            if (!driver.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if (this.drivers.Any(d => d.Name == driver.Name))
            {
                throw new ArgumentNullException(driver.GetType().Name ,string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name));
            }

            this.drivers.Add(driver);
        }
    }
}

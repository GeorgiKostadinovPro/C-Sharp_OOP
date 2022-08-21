using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Core.Contracts;
using Telephony.Models;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        private readonly Smartphone smartphone;
        private readonly StationaryPhone stationaryPhone;

        public Engine()
        {
            this.smartphone = new Smartphone();
            this.stationaryPhone = new StationaryPhone();
        }

        public void Run()
        {
            string[] phoneNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] webistesURLAddress = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                string currPhoneNumber = phoneNumbers[i];

                if (currPhoneNumber.Any(d => !char.IsDigit(d)))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }

                if (currPhoneNumber.Length == 10)
                {
                    Console.WriteLine(smartphone.Call(currPhoneNumber));
                }
                else
                {
                    Console.WriteLine(stationaryPhone.Call(currPhoneNumber));
                }
            }

            for (int i = 0; i < webistesURLAddress.Length; i++)
            {
                string currWebsiteURLAddress = webistesURLAddress[i];

                if (currWebsiteURLAddress.Any(l => char.IsDigit(l)))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }

                Console.WriteLine(smartphone.Browse(currWebsiteURLAddress));
            }
        }
    }
}

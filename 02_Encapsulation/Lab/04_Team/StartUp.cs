using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();
            Team team = new Team("SoftUni");

            for (int i = 0; i < lines; i++)
            {
                try
                {
                    string[] cmdArgs = Console.ReadLine()
                       .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    
                    string firstName = cmdArgs[0];
                    string lastName = cmdArgs[1];
                    int age = int.Parse(cmdArgs[2]);
                    decimal salary = decimal.Parse(cmdArgs[3]);
                    
                    Person person = new Person(firstName, lastName, age, salary);
                    persons.Add(person);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (Person player in persons)
            {
                team.AddPlayer(player);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}

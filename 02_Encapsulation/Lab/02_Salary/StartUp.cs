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

            for (int i = 0; i < lines; i++)
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

            decimal parcentage = decimal.Parse(Console.ReadLine());

            persons.ForEach(p => p.IncreaseSalary(parcentage));
            persons.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}

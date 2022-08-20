using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                AddPeople(people);
                AddProducts(products);

                string command;

                while ((command = Console.ReadLine()) != "END")
                {
                    BuyProducts(people, products, command);
                }

                foreach (var person in people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void BuyProducts(List<Person> persons, List<Product> products, string input)
        {
            var tokens = input
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var personName = tokens[0];
            var productName = tokens[1];

            var currentPerson = persons
                .FirstOrDefault(p => p.Name == personName);
            var currentProduct = products
                .FirstOrDefault(p => p.Name == productName);

            var output = currentPerson.TryBuyProduct(currentProduct);

            Console.WriteLine(output);
        }

        private static void AddProducts(List<Product> products)
        {
            var productInput = Console.ReadLine()
                        .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var pkvp in productInput)
            {
                var tokens = pkvp
                    .Split("=");
                var productName = tokens[0];
                var productPrice = decimal.Parse(tokens[1]);

                var product = new Product(productName, productPrice);

                products.Add(product);
            }
        }

        private static void AddPeople(List<Person> persons)
        {
            var personInput = Console.ReadLine()
                        .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var pkvp in personInput)
            {
                var tokens = pkvp
                    .Split("=");
                var personName = tokens[0];
                var personMoney = decimal.Parse(tokens[1]);

                var person = new Person(personName, personMoney);

                persons.Add(person);
            }
        }
    }
}

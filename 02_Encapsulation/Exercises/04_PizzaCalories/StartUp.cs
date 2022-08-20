using System;

namespace PizzaCalories
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Pizza pizza = null;
            bool isPizzaCreationSuccessful = true;
            string line = string.Empty;

            while ((line = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] cmdArgs = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string cmd = cmdArgs[0];
                    string type = cmdArgs[1].ToLower();

                    if (cmd == "Pizza")
                    {
                        string pizzaName = type[0].ToString().ToUpper() + type.Substring(1);
                        pizza = new Pizza(pizzaName, null);
                    }
                    else if (cmd == "Dough")
                    {
                        string bakingTechnique = cmdArgs[2].ToLower();
                        double weight = double.Parse(cmdArgs[3]);

                        Dough dough = new Dough(type, bakingTechnique, weight);
                        pizza.Dough = dough;
                    }
                    else if (cmd == "Topping")
                    {
                        double weight = double.Parse(cmdArgs[2]);

                        Topping topping = new Topping(type, weight);
                        pizza.AddTopping(topping);
                    }
                }
                catch (ArgumentException ex)
                { 
                    Console.WriteLine(ex.Message);
                    isPizzaCreationSuccessful = false;
                    break;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Pizza name should be between 1 and 15 symbols.");
                    isPizzaCreationSuccessful = false;
                    break;
                }
            }

            if (isPizzaCreationSuccessful)
            {
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
        }
    }
}

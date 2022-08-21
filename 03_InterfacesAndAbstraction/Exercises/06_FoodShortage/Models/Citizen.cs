using FoodShortage.Models.Contracts;

namespace FoodShortage.Models
{
    public class Citizen : ICitizen, IBuyer
    {
        public Citizen(string id, string name, int age, string birthDate)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.BirthDate = birthDate;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string BirthDate { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}

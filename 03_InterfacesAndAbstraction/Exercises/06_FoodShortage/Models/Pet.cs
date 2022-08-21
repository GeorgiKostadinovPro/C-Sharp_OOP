using FoodShortage.Models.Contracts;

namespace FoodShortage.Models
{
    public class Pet : IPet
    {
        public Pet(string name, string birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }
        public string Name  {get; private set;}    
                                
        public string BirthDate { get; private set; }
    }
}

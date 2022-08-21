namespace BirthdayCelebrations.Models.Contracts
{
    public interface ICitizen
    { 
        string Id { get; }

        string Name { get; }

        int Age { get; }

        string BirthDate { get; }
    }
}

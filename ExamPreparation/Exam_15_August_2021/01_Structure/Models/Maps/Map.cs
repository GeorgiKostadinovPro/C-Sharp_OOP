namespace CarRacing.Models.Maps
{   
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Utilities.Messages;

    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            string result = string.Empty;   

            if (!racerOne.IsAvailable())
            {
                result = string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }

            if (!racerTwo.IsAvailable())
            {
                result = string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                result = string.Format(OutputMessages.RaceCannotBeCompleted);
            }

            double racerOneWinningChance = 0.0d;
            double racerTwoWinningChance = 0.0d;       
            
            racerOne.Race();
            racerTwo.Race();

            if (racerOne.RacingBehavior == "strict")
            {
                racerOneWinningChance = racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.2;
            }
            else if (racerOne.RacingBehavior == "aggressive")
            {
                racerOneWinningChance = racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.1;
            }

            if (racerTwo.RacingBehavior == "strict")
            {
                racerTwoWinningChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.2;
            }
            else if (racerTwo.RacingBehavior == "aggressive")
            {
                racerTwoWinningChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.1;
            }
     
            if (racerOneWinningChance > racerTwoWinningChance)
            { 
                
                result = string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }
            else 
            { 
                result = string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
            }

            return result;
        }
    }
}

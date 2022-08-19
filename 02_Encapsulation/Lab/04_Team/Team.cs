using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private readonly ICollection<Person> firstTeam;
        private readonly ICollection<Person> reserveTeam;

        private Team()
        {
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public Team(string name)
            : this()
        {
            this.Name = name;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public IReadOnlyCollection<Person> FirstTeam 
            => (IReadOnlyCollection<Person>)this.firstTeam;

        public IReadOnlyCollection<Person> ReserveTeam 
            => (IReadOnlyCollection<Person>)this.reserveTeam;

        public void AddPlayer(Person player)
        {
            if (player.Age < 40)
            {
                this.firstTeam.Add(player);
            }
            else 
            {
                this.reserveTeam.Add(player);
            }
        }
    }
}

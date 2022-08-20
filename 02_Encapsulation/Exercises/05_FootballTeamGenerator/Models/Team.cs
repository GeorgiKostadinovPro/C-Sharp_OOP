using FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private readonly ICollection<Player> players;

        private Team()
        {
            this.players = new List<Player>();
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.NullOrWhitespaceName);
                }

                this.name = value;
            }
        }

        public int Rating
        {
            get
            {
               return this.players.Count > 0 ? (int)Math.Round(this.players.Average(p => p.Stats.GetOverallStatus()), 0) : 0;
            }
        }
        public void AddPlayer(Player player)
        {
            if (!this.players.Contains(player))
            {
                this.players.Add(player);
            }
        }

        public void RemovePlayer(string playerName)
        {
            Player playerToDelete = this.players
                .FirstOrDefault(p => p.Name == playerName);

            if (playerToDelete == null)
            {
                throw new InvalidOperationException(
                    string.Format(ErrorMessages.PlayerNotInTeam, playerName, this.Name));
            }

            this.players.Remove(playerToDelete);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}

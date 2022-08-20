using FootballTeamGenerator.Common;
using FootballTeamGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator.Core
{
    public class Engine
    {
        private readonly ICollection<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string line = string.Empty;

            while ((line = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] cmdArgs = line
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

                    CommandInterpreter(teams, cmdArgs);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine(ErrorMessages.NullOrWhitespaceName);
                }
            }
        }

        public void CommandInterpreter(ICollection<Team> teams, string[] cmdArgs)
        {
            string cmdType = cmdArgs[0];
            string teamName = cmdArgs[1];

            if (cmdType == "Team")
            {
                Team team = new Team(teamName);
                teams.Add(team);
            }
            else
            {
                Team team = teams
                        .FirstOrDefault(t => t.Name == teamName);

                if (team == null)
                {
                    throw new InvalidOperationException(
                        string.Format(ErrorMessages.TeamNotExists, teamName));
                }

                if (cmdType == "Add")
                {
                    string playerName = cmdArgs[2];
                    string[] statsInfo = cmdArgs.Skip(3).ToArray();

                    Stats playerStats = GeneratePlayerStats(statsInfo);
                    Player player = new Player(playerName, playerStats);

                    team.AddPlayer(player);
                }
                else if (cmdType == "Remove")
                {
                    string playerName = cmdArgs[2];

                    team.RemovePlayer(playerName);
                }
                else if (cmdType == "Rating")
                {
                    Console.WriteLine(team.ToString());
                }
            }
        }

        public Stats GeneratePlayerStats(string[] stats)
        {
            int endurance = int.Parse(stats[0]);
            int sprint = int.Parse(stats[1]);
            int dribble = int.Parse(stats[2]);
            int passing = int.Parse(stats[3]);
            int shooting = int.Parse(stats[4]);

            Stats generatedStats = new Stats(endurance, sprint, dribble, passing, shooting);
            return generatedStats;
        }
    }
}

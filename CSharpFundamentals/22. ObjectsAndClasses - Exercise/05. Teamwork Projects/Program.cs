using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            int countOfTeams = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfTeams; i++)
            {
                string[] creatorAndTeam = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string creator = creatorAndTeam[0];
                string teamName = creatorAndTeam[1];

                if (teams.Any(t => t.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }
                if (teams.Any(c => c.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                Team team = new Team(teamName, creator);
                teams.Add(team);
                Console.WriteLine($"Team {teamName} has been created by {creator}!");
            }

            string addingMember = "";
            while ((addingMember = Console.ReadLine()) != "end of assignment")
            {
                string[] memberToTeam = addingMember.Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string member = memberToTeam[0];
                string wantedTeam = memberToTeam[1];

                Team chekingTeam = teams.FirstOrDefault(t => t.TeamName == wantedTeam);

                if (chekingTeam == null)
                {
                    Console.WriteLine($"Team {wantedTeam} does not exist!");
                    continue;
                }
                if (teams.Any(m => m.Creator == member))
                {
                    Console.WriteLine($"Member {member} cannot join team {wantedTeam}!");
                    continue;
                }
                if (teams.Any(m => m.Creator == member))
                {
                    Console.WriteLine($"Member {member} cannot join team {wantedTeam}!");
                    continue;
                }
                chekingTeam.AddingMember(member);
                    
                
            }

            List<Team> teamsWithMembers = teams.Where(t => t.Members.Count > 0).OrderByDescending(t => t.Members.Count).ThenBy(t => t.TeamName).ToList();
            List<Team> teamsToDisband = teams.Where(t => t.Members.Count == 0).OrderBy(t => t.TeamName).ToList();

            foreach (Team valid in teamsWithMembers)
            {
                Console.WriteLine($"{valid.TeamName}");
                Console.WriteLine($"- {valid.Creator}");
                foreach (string member in valid.Members.OrderBy(m => m))
                {
                    Console.WriteLine($"-- {member}");
                }
            }
            Console.WriteLine("Teams to disband:");
            foreach (Team empty in teamsToDisband)
            {
                Console.WriteLine($"{empty.TeamName}");

            }
        }
    }
    class Team
    {
        public Team(string teamName, string creator)
        {
            this.TeamName = teamName;
            this.Creator = creator;
            this.Members = new List<string>();
        }
        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }

        public void AddingMember(string member)
        {
            this.Members.Add(member);
        }

    }
    
    
    
}

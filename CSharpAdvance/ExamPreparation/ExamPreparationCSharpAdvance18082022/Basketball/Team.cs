using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private const int MinimumPlayerRating = 80;

        private string name;
        private int openPositions;
        private char group;
        private List<Player> players;

        public Team(string name, int openPositions, char group)
        {
            this.Name = name;
            this.OpenPositions = openPositions;
            this.Group = group;
            this.Players = new List<Player>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int OpenPositions
        {
            get { return openPositions; }
            set { openPositions = value; }
        }
        public char Group
        {
            get { return group; }
            set { group = value; }
        }
        public List<Player> Players
        {
            get { return players; }
            set { players = value; }
        }
        public int Count => this.Players.Count;

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }
            if (this.OpenPositions == 0)
            {
                return "There are no more open positions.";
            }
            if (player.Rating < MinimumPlayerRating)
            {
                return "Invalid player's rating.";
            }
            this.Players.Add(player);
            this.OpenPositions--;
            return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
        }
        public bool RemovePlayer(string name)
        {
            Player playerToRemove = this.Players.FirstOrDefault(p => p.Name == name);
            if (playerToRemove != null)
            {
                this.Players.Remove(playerToRemove);
                this.OpenPositions++;
                return true;
            }
            return false;
        }
        public int RemovePlayerByPosition(string position)
        {
            int playersRemoved = this.Players.RemoveAll(p => p.Position == position);
            this.openPositions += playersRemoved;
            return playersRemoved;
        }
        public Player RetirePlayer(string name)
        {
            Player playerToRetire = this.Players.FirstOrDefault(p => p.Name == name);
            if (playerToRetire != null)
            {
                Retire(playerToRetire);
                return playerToRetire;
            }
            return null;
        }

        public List<Player> AwardPlayers(int games)
        {
            List<Player> sortedList = this.Players.Where(p => p.Games >= games).ToList();
            return sortedList;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            List<Player> sortedList = this.Players.Where(p => p.Retired == false).ToList();
            sb.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}:");
            foreach (Player player in sortedList)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().Trim();
        }
        private void Retire(Player player)
        {
            if (player.Retired == false)
            {
                player.Retired = true;
            }
           
        }
    }
}

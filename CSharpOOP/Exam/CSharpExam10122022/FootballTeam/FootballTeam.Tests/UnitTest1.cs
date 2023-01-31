using NUnit.Framework;
using System;
using System.Numerics;
using System.Threading.Tasks;

namespace FootballTeam.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void Test_CreatingFootballTeam_Work()
        {
            FootballTeam team = new FootballTeam("Levaci", 15);
            Assert.AreEqual("Levaci", team.Name);
            Assert.AreEqual(15, team.Capacity);
        }
        [Test]
        public void Test_CreatingFootballTeamWithNullName_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam(null, 15);

            }, "Name cannot be null or empty!");

        }
        [Test]
        public void Test_CreatingFootballTeamWithEmptyName_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam("", 15);

            }, "Name cannot be null or empty!");

        }
        [Test]
        public void Test_CreatingFootballTeamWithLessCapacity_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam("Levaci", 14);

            }, "Capacity min value = 15");

        }
        [Test]
        public void Test_PlayersPorperty_Work()
        {
            FootballTeam team = new FootballTeam("Levaci", 15);
            FootballPlayer playerOne = new FootballPlayer("Sakat", 13, "Goalkeeper");
            team.AddNewPlayer(playerOne);
            Assert.AreEqual(1, team.Players.Count);
        }
        [Test]
        public void Test_AddNewPlayer_Work()
        {
            FootballTeam team = new FootballTeam("Levaci", 15);
            FootballPlayer playerOne = new FootballPlayer("Sakat", 13, "Goalkeeper");
            FootballPlayer playerTwo = new FootballPlayer("Sakat", 14, "Goalkeeper");
            team.AddNewPlayer(playerOne);
            Assert.AreEqual(1, team.Players.Count);
            string actual = team.AddNewPlayer(playerTwo);
            string expected = "Added player Sakat in position Goalkeeper with number 14";
            Assert.AreEqual(2, team.Players.Count);
            Assert.AreEqual(expected, actual);

        }
        [Test]
        public void Test_AddNewPlayerWithMoreCapacity_ShouldReturnMessage()
        {
            FootballTeam team = new FootballTeam("Levaci", 15);
            FootballPlayer player1 = new FootballPlayer("Sakat", 13, "Goalkeeper");
            FootballPlayer player2 = new FootballPlayer("Sakat", 14, "Goalkeeper");
            FootballPlayer player3 = new FootballPlayer("Sakat", 14, "Goalkeeper");
            FootballPlayer player4 = new FootballPlayer("Sakat", 14, "Goalkeeper");
            FootballPlayer player5 = new FootballPlayer("Sakat", 14, "Goalkeeper");
            FootballPlayer player6 = new FootballPlayer("Sakat", 14, "Goalkeeper");
            FootballPlayer player7 = new FootballPlayer("Sakat", 14, "Goalkeeper");
            FootballPlayer player8 = new FootballPlayer("Sakat", 14, "Goalkeeper");
            FootballPlayer player9 = new FootballPlayer("Sakat", 14, "Goalkeeper");
            FootballPlayer player10 = new FootballPlayer("Sakat", 14, "Goalkeeper");
            FootballPlayer player11 = new FootballPlayer("Sakat", 14, "Goalkeeper");
            FootballPlayer player12 = new FootballPlayer("Sakat", 14, "Goalkeeper");
            FootballPlayer player13 = new FootballPlayer("Sakat", 14, "Goalkeeper");
            FootballPlayer player14 = new FootballPlayer("Sakat", 14, "Goalkeeper");
            FootballPlayer player15 = new FootballPlayer("Sakat", 14, "Goalkeeper");           
            FootballPlayer player16 = new FootballPlayer("Sakat", 14, "Goalkeeper");
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player2);
            team.AddNewPlayer(player3);
            team.AddNewPlayer(player4);
            team.AddNewPlayer(player5);
            team.AddNewPlayer(player6);
            team.AddNewPlayer(player7);
            team.AddNewPlayer(player8);
            team.AddNewPlayer(player9);
            team.AddNewPlayer(player10);
            team.AddNewPlayer(player11);
            team.AddNewPlayer(player12);
            team.AddNewPlayer(player13);
            team.AddNewPlayer(player14);
            team.AddNewPlayer(player15);
            string actual = team.AddNewPlayer(player16);
            string expected = "No more positions available!";
            Assert.AreEqual(expected, actual);
        }
        [Test]
        //[TestCase("Zidan")]
        public void Test_PickPlayer_ReturnPlayerCorectly()
        {
            FootballTeam team = new FootballTeam("Levaci", 15);
            FootballPlayer player1 = new FootballPlayer("Sakat", 13, "Goalkeeper");
            team.AddNewPlayer(player1);
            FootballPlayer footbalPlayerToReturn = team.PickPlayer("Sakat");
            Assert.AreEqual(player1, footbalPlayerToReturn);
           
        }
        [Test]
        
        public void Test_PickPlayer_ReturnNullWhenNameIsNotInTeam()
        {
            FootballTeam team = new FootballTeam("Levaci", 15);
            FootballPlayer player1 = new FootballPlayer("Sakat", 13, "Goalkeeper");
            team.AddNewPlayer(player1);
            FootballPlayer footbalPlayerToReturn = team.PickPlayer("Zidan");
            Assert.AreEqual(null, footbalPlayerToReturn);
            
        }
        [Test]

        public void Test_PlayerScore_Work()
        {
            FootballTeam team = new FootballTeam("Levaci", 15);
            FootballPlayer player1 = new FootballPlayer("Sakat", 13, "Goalkeeper");
            team.AddNewPlayer(player1);
            string expected = "Sakat scored and now has 1 for this season!";
            
            string actual = team.PlayerScore(13);
            Assert.AreEqual(expected, actual);

        }
    }
}
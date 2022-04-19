using Microsoft.VisualStudio.TestTools.UnitTesting;
using MK_KupSkorer.Contracts;
using MK_KupSkorer.Data;
using MK_KupSkorer.Models.PlayerModels;
using MK_KupSkorer.Services;
using System;
using System.Linq;

namespace MK_KupSkorer.Tests
{
    [TestClass]
    public class PlayerServiceTests
    {
        int playerId;

        [TestMethod]
        public void CreatePlayerIncrementsCountOfPlayers()
        {
            //arrange
            var svc = new PlayerService();
            var playToAdd = new PlayerCreate{
                FirstName = "Test",
                LastName =  "Player",
                Nickname = "nickname",
                IsActive = true

            };
            var wasAdded = false;
            int playerCountBeforeAdd;
            int playerCountAfterAdd;
                using (var ctx = new ApplicationDbContext())
            {
                playerCountBeforeAdd = ctx.Players.Count();
            }

            //act
            playerId = svc.CreatePlayer(playToAdd);
            using (var ctx = new ApplicationDbContext())
            {
                playerCountAfterAdd = ctx.Players.Count();
            }

            //assert
            Assert.IsTrue(wasAdded);
            Assert.AreEqual(playerCountBeforeAdd, playerCountAfterAdd - 1);
        }

        [TestMethod]
        public void GetPlayerByIdReturnsTestPlayer()
        {
            //arrange
            var svc = new PlayerService();
            PlayerDetail playerToCheckAgainst = new PlayerDetail
            {
                PlayerId = playerId,
                FirstName = "Test",
                LastName = "Player",
                Nickname = "nickname",
                TotalRacePoints = 0,
                TotalBonusPoints = 0,
                IsActive = true
            };

            //act
            var playToBeChecked = svc.GetPlayerById(playerId);

            //assert
            Assert.AreEqual(playToBeChecked, playerToCheckAgainst);

        }

        [TestMethod]
        public void DeletePlayerByIdReturnsTrue()
        {
            //Arrange
            var svc = new PlayerService();
            bool wasDeleted = false;
            int countBeforeDeletion;
            int countAfterDeletion;
            using (var ctx = new ApplicationDbContext())
            {
                countBeforeDeletion = ctx.Players.Count();
            }

            //Act
            wasDeleted = svc.DeletePlayerById(playerId);
            using (var ctx = new ApplicationDbContext())
            {
                countAfterDeletion = ctx.Players.Count();
            }

            //Assert
            Assert.IsTrue(wasDeleted);
            Assert.AreEqual(countBeforeDeletion, countAfterDeletion + 1);

        }
    }
}

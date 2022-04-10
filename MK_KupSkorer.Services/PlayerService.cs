using MK_KupSkorer.Contracts;
using MK_KupSkorer.Data;
using MK_KupSkorer.Models.PlayerModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MK_KupSkorer.Services
{
    public class PlayerService : IPlayerService
    {
        //constructor - interface IPlayerService

        public bool CreatePlayer(PlayerCreate playerCreateModel)
        {
            if (playerCreateModel == null)
            {
                return false;
            }

            using (var ctx = new ApplicationDbContext())
            {
                Player playerToCreate = new Player
                {
                    FirstName = playerCreateModel.FirstName,
                    LastName = playerCreateModel.LastName,
                    Nickname = playerCreateModel.Nickname
                };
                ctx.Players.Add(playerToCreate);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PlayerListItem> GetPlayerList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Players
                    .Select(p => new PlayerListItem
                    {
                        PlayerId = p.PlayerId,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        Nickname = p.Nickname
                    });
                return query.ToArray();
            }
        }

        public IEnumerable<PlayerListItem> GetPlayerListByKupId(int kupId)
        {
            List<PlayerListItem> playerList = new List<PlayerListItem>();

            using (var ctx = new ApplicationDbContext())
            {
                var kup = ctx.Kups
                   .Single(i => i.KupId == kupId);

                playerList.Add(GetPlayerListItemById(kup.Player1Id));
                playerList.Add(GetPlayerListItemById(kup.Player2Id));
                if(kup.Player3 != null)
                playerList.Add(GetPlayerListItemById(kup.Player3Id));
                if(kup.Player4 != null)
                playerList.Add(GetPlayerListItemById(kup.Player4Id));
            }
            return playerList.ToArray();
        }

        public PlayerDetail GetPlayerById(int playerId)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var dbRow = ctx.Players.Find(playerId);
                    if (dbRow != null)
                    {
                        return new PlayerDetail
                        {
                            PlayerId = dbRow.PlayerId,
                            FirstName = dbRow.FirstName,
                            LastName = dbRow.LastName,
                            Nickname = dbRow.Nickname,
                            TotalPoints = dbRow.TotalPoints,
                            TotalBonusPoints = dbRow.TotalBonusPoints
                        };
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                //do logging
                Console.WriteLine(e);
                return null;
            }
        }

        public PlayerListItem GetPlayerListItemById(int? playerId)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var dbRow = ctx.Players.Find(playerId);
                    if (dbRow != null)
                    {
                        return new PlayerListItem
                        {
                            PlayerId = dbRow.PlayerId,
                            FirstName = dbRow.FirstName,
                            LastName = dbRow.LastName,
                            Nickname = dbRow.Nickname
                        };
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                //do logging
                Console.WriteLine(e);
                return null;
            }
        }

        public bool UpdatePlayerAttributes(UpdatePlayerAttributes playerUpdateAttributesModel, int playerId)
        {
            if (playerUpdateAttributesModel == null)
                return false;

            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.Players.Find(playerId) != null)
                {
                    var playerToUpdate = ctx.Players
                        .Where(p => p.PlayerId == playerId)
                        .Single();

                    playerToUpdate.FirstName = playerUpdateAttributesModel.FirstName;
                    playerToUpdate.LastName = playerUpdateAttributesModel.LastName;
                    playerToUpdate.Nickname = playerUpdateAttributesModel.Nickname;

                    return ctx.SaveChanges() == 1;
                }
                return false;
            }
        }

        public bool UpdatePlayerPoints(UpdatePlayerPoints playerUpdatePointsModel)
        {
            if (playerUpdatePointsModel == null)
                return false;

            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.Players.Find(playerUpdatePointsModel.PlayerId) != null)
                {
                    var playerToUpdate = ctx.Players
                        .Where(p => p.PlayerId == playerUpdatePointsModel.PlayerId)
                        .Single();

                    playerToUpdate.TotalPoints += playerUpdatePointsModel.TotalPoints;

                    playerToUpdate.TotalBonusPoints += playerUpdatePointsModel.TotalBonusPoints;

                    playerToUpdate.TotalWins += 
                        playerUpdatePointsModel.TotalWins;

                    return ctx.SaveChanges() == 1;
                }
                return false;
            }
        }

        public double GetPlayerPointsByKupID(int kupId)
        {
            throw new NotImplementedException();
        }

        public bool DeletePlayerById(int playerId)
        {
            try
            {

                using (var ctx = new ApplicationDbContext())
                {
                    var playerToDelete = ctx.Players.Find(playerId);
                    if (playerToDelete != null)
                        ctx.Players.Remove(playerToDelete);
                    return ctx.SaveChanges() == 1;
                }
            }
            catch (Exception ex)
            {
                //do logging
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}

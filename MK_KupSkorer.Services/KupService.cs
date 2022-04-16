using MK_KupSkorer.Contracts;
using MK_KupSkorer.Data;
using MK_KupSkorer.Models.KupModels;
using MK_KupSkorer.Models.PlayerModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MK_KupSkorer.Services
{
    public class KupService : IKupService
    {
        //CRUD operations to the DB for the Kup models

        public int CreateKup(KupCreate model)
        {
            if (model == null)
                return -1;

            using (var ctx = new ApplicationDbContext())
            {
                var kupToCreate = new Kup
                {
                    KupDateTime = DateTimeOffset.Now,
                    Player1Id = model.Player1Id,
                    Player2Id = model.Player2Id,
                    Player3Id = model.Player3Id,
                    Player4Id = model.Player4Id
                };
                ctx.Kups.Add(kupToCreate);
                if (ctx.SaveChanges() == 1)
                    return kupToCreate.KupId;
                return -1;
            }
        }

        public IEnumerable<KupListItem> GetKupListItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var queryListOfKups = ctx.Kups
                    .Select(k => new KupListItem
                    {
                        KupId = k.KupId,
                        KupDateTime = k.KupDateTime
                    });
                return queryListOfKups.ToList();
            }
        }

        public KupDetail GetKupById(int kupId)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var kupQuery = ctx.Kups.Find(kupId);
                    if (kupQuery != null)
                    {
                        return new KupDetail
                        {
                            KupId = kupQuery.KupId,
                            KupDateTime = kupQuery.KupDateTime,
                            Player1Id = kupQuery.Player1Id,
                            Player2Id = kupQuery.Player2Id,
                            Player3Id = kupQuery.Player3Id,
                            Player4Id = kupQuery.Player4Id
                        };
                    }
                    return null;
                }
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateKup(UpdateKup updatedKup)
        {
            if (updatedKup == null)
                return false;

            using (var ctx = new ApplicationDbContext())
            {
                var kupToUpdate = ctx.Kups.Find(updatedKup.KupId);
                if (kupToUpdate != null)
                {
                    kupToUpdate.UpdatedDateTime = updatedKup.UpdatedDateTime;
                }
                return ctx.SaveChanges() == 1;
            }
        }

        public bool IncrementKupRaceCount(int kupId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var kupToUpdate = ctx.Kups.Find(kupId);
                kupToUpdate.RaceCount++;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteKup(int kupId)
        {
            try
            {

                using (var ctx = new ApplicationDbContext())
                {
                    var kupToDelete = ctx.Kups.Find(kupId);
                    if (kupToDelete != null)
                    {
                        ctx.Kups.Remove(kupToDelete);
                    }
                    return ctx.SaveChanges() == 1;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //returns an int (the playerId) if a player should be awarded a bonus point.
        public int RewardBonusPoint(int kupId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                //query db for list of race for the kup
                var races = ctx.Races
                    .Where(r => r.KupId == kupId)
                    .ToList();

                //Get list of all winners of the races in the kup
                List<int?> winnerList = new List<int?>();
                foreach(Race r in races)
                {
                    winnerList.Add(r.WinnerId);
                }

                //set the 1st race winner Id
                int? race1winner = winnerList[0];
                //cycle through rest of races and see if the winner is the same on each
                bool wonAllRaces = true;
                for(int i = 1; i < races.Count; i++)
                {
                    if (race1winner.HasValue)
                        if (race1winner != races[i].WinnerId)
                            wonAllRaces = false;
                }

                if (wonAllRaces && race1winner.HasValue)
                 return (int)race1winner;
                return -1;
            }
        }
    }
}

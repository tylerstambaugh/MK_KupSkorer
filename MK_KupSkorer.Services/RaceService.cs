using MK_KupSkorer.Contracts;
using MK_KupSkorer.Data;
using MK_KupSkorer.Models.PlayerModels;
using MK_KupSkorer.Models.RaceModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MK_KupSkorer.Services
{
    public class RaceService : IRaceService
    {
        public int CreateRace(RaceCreate raceToCreateModel)
        {
            if (raceToCreateModel == null)
                return -1;

            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var raceToCreate = new Race
                    {
                        KupId = raceToCreateModel.KupId
                    };

                    ctx.Races.Add(raceToCreate);
                    if (ctx.SaveChanges() == 1)
                    {
                        return raceToCreate.RaceId;
                    }
                    return -1;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public IEnumerable<RaceListItem> GetRaceList()
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var raceQuery = ctx.Races
                        .Select(r => new RaceListItem
                        {
                            RaceId = r.RaceId,
                            RaceDateTime = r.RaceDateTime
                        });
                    return raceQuery.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<RaceListItem> GetRaceListByKupId(int kupId)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var raceQuery = ctx.Races
                        .Where(r => r.KupId == kupId)
                        .Select(r => new RaceListItem
                        {
                            RaceId = r.RaceId,
                            RaceDateTime = r.RaceDateTime
                        });
                    return raceQuery.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<RaceDetail> GetRaceDetailListByKupId(int kupId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var raceQuery = ctx.Races
                    .Where(r => r.KupId == kupId)
                    .Select(r => new RaceDetail
                    {
                        RaceId = r.RaceId,
                        RaceDateTime = r.RaceDateTime,
                        WinnerId = r.WinnerId,
                        KupId = r.KupId
                    });
                return raceQuery.ToList();
            }
        }

        public RaceDetail GetRaceById(int raceId)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var raceQuery = ctx.Races.Find(raceId);
                    if (raceQuery != null)
                    {
                        return new RaceDetail
                        {
                            RaceId = raceQuery.RaceId,
                            RaceDateTime = raceQuery.RaceDateTime,
                            KupId = raceQuery.KupId,
                            WinnerId = raceQuery.WinnerId
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

        public bool UpdateRace(UpdateRace raceToUpdateModel, int raceId)
        {
            if (raceToUpdateModel == null)
                return false;

            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var raceToUpdate = ctx.Races.Find(raceId);
                    if (raceToUpdate != null)
                    {
                        raceToUpdate.WinnerId = raceToUpdateModel.WinnerId;
                        raceToUpdate.RaceDateTime = DateTime.Now;
                    }
                    return ctx.SaveChanges() == 1;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public int GetKupRaceCountByRaceId(int raceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var raceCount = ctx.Races
                    .Where(r => r.RaceId == raceId)
                    .Select(k => k.Kup.RaceCount);

                return raceCount.First();
                
            }
        }

        public bool IsLastRace(int raceId)
        {
            if (GetKupRaceCountByRaceId(raceId) == 4)
                return true;
            return false;
        }
        public bool DeleteRaceById(int raceId)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var raceToDelete = ctx.Races.Find(raceId);
                    if (raceToDelete != null)
                    {
                        ctx.Races.Remove(raceToDelete);
                        return ctx.SaveChanges() == 1;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int GetWinnerIdByRaceId(int raceId)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var race = ctx.Races.Find(raceId);

                if(race != null)
                {
                    return (int)race.WinnerId;
                }
            }
                return -1;
        }

        //public int RewardBonusPoint(int kupId)
        //{

        //}
    }
}

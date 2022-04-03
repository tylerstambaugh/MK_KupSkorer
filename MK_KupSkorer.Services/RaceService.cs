using MK_KupSkorer.Contracts;
using MK_KupSkorer.Data;
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
                return 0;

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
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
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
    }
}

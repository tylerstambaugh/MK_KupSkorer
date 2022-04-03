using MK_KupSkorer.Models.RaceModels;
using System.Collections.Generic;

namespace MK_KupSkorer.Contracts
{
    public interface IRaceService
    {
        int CreateRace(RaceCreate raceToCreateModel);
        bool DeleteRaceById(int raceId);
        RaceDetail GetRaceById(int raceId);
        IEnumerable<RaceListItem> GetRaceList();
        IEnumerable<RaceListItem> GetRaceListByKupId(int kupId);
        bool UpdateRace(UpdateRace raceToUpdateModel, int raceId);
    }
}
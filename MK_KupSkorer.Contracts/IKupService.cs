using MK_KupSkorer.Models.KupModels;
using System.Collections.Generic;

namespace MK_KupSkorer.Contracts
{
    public interface IKupService
    {
        int CreateKup(KupCreate model);
        bool DeleteKup(int kupId);
        KupDetail GetKupById(int kupId);
        IEnumerable<KupListItem> GetKupListItems();
        bool UpdateKup(UpdateKup updatedKup);

        bool IncrementKupRaceCount(int kupId);

        int RewardBonusPoint(int kupId);
    }
}
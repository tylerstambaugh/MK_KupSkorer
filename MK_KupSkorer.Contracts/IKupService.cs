using MK_KupSkorer.Models.KupModels;
using System.Collections.Generic;

namespace MK_KupSkorer.Contracts
{
    public interface IKupService
    {
        bool CreateKup(KupCreate kupCreateModel);
        bool DeleteKup(int kupId);
        KupDetail GetKupById(int kupId);
        IEnumerable<KupListItem> GetKupListItems();
        bool UpdateKup(UpdateKup updatedKup);
    }
}
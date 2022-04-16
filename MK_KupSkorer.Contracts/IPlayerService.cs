using MK_KupSkorer.Models.PlayerModels;
using System.Collections.Generic;

namespace MK_KupSkorer.Contracts
{
    public interface IPlayerService
    {
        bool CreatePlayer(PlayerCreate playerCreateModel);
        bool DeletePlayerById(int playerId);
        PlayerDetail GetPlayerById(int playerId);
        IEnumerable<PlayerListItem> GetActivePlayerList();
        IEnumerable<PlayerListItem> GetPlayerList();
        IEnumerable<PlayerListItem> GetPlayerListByKupId(int kupId);
        PlayerListItem GetPlayerListItemById(int? playerId);
        bool UpdatePlayerAttributes(UpdatePlayerAttributes playerUpdateAttributesModel, int playerId);
        bool UpdatePlayerPoints(UpdatePlayerPoints playerUpdatePointsModel);
        bool AddBonusPointToPlayer(int playerId);

        bool MarkPlayerInactive(int playerId);

    }
}
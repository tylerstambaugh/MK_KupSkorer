using MK_KupSkorer.Models.PlayerModels;
using System.Collections.Generic;

namespace MK_KupSkorer.Contracts
{
    public interface IPlayerService
    {
        bool CreatePlayer(PlayerCreate playerCreateModel);
        bool DeletePlayerById(int playerId);
        PlayerDetail GetPlayerById(int playerId);
        IEnumerable<PlayerListItem> GetPlayerList();
        IEnumerable<int> GetPlayerIdsByKupId(int kupId);
        bool UpdatePlayerAttributes(UpdatePlayerAttributes playerUpdateAttributesModel, int playerId);
        bool UpdatePlayerPoints(UpdatePlayerPoints playerUpdatePointsModel, int playerId);
    }
}
using MK_KupSkorer.Data;
using MK_KupSkorer.Models.PlayerModels;
using System.Collections.Generic;
using System.Linq;

namespace MK_KupSkorer.Services
{
    public class PlayerService
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
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        Nickname = p.Nickname
                    });
                return query.ToList();
            }
        }

        //public PlayerDetail GetPlayerById(int playerId)
        //{

        //}
    }
}

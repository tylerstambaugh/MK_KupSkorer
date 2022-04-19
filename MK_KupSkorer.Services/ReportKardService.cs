using MK_KupSkorer.Contracts;
using MK_KupSkorer.Data;
using MK_KupSkorer.Models.ReportKardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK_KupSkorer.Services
{
    public class ReportKardService : IReportKardService
    {
        public IEnumerable<ReportKardRacer> GetRacerReportKard()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Players.OrderBy(x => x.TotalRacePoints)
                    .Select(r => new ReportKardRacer
                    {
                        PlayerId = r.PlayerId,
                        FirstName = r.FirstName,
                        LastName = r.LastName,
                        Nickname = r.Nickname,
                        TotalWins = r.TotalWins,
                        TotalRacePoints = r.TotalRacePoints,
                        TotalBonusPoints = r.TotalBonusPoints
                    }) ;

                return query.ToArray();
            }
        }

    }
}

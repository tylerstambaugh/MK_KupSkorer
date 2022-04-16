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
        public IEnumerable<ReportKardTotalPoints> GetTotalPointsReportKard()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Players.OrderBy(x => x.TotalPoints)
                    .Select(r => new ReportKardTotalPoints
                    {
                        PlayerId = r.PlayerId,
                        FirstName = r.FirstName,
                        LastName = r.LastName,
                        NickName = r.Nickname,
                        TotalPoints = r.TotalPoints
                    }) ;

                return query.ToArray();
            }
        }

        public IEnumerable<ReportKardTotalWins> GetTotalWinsReportKard()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Players.OrderBy(x => x.TotalPoints)
                    .Select(r => new ReportKardTotalWins
                    {
                        PlayerId = r.PlayerId,
                        FirstName = r.FirstName,
                        LastName = r.LastName,
                        NickName = r.Nickname,
                        TotalWins = r.TotalWins
                    });

                return query.ToArray();
            }
        }
    }
}

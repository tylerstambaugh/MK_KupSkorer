using MK_KupSkorer.Models.ReportKardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK_KupSkorer.Contracts
{
    public interface IReportKardService
    {
        IEnumerable<ReportKardRacer> GetRacerReportKard();
        IEnumerable<ReportKardKupRace> GetKupReportKardByKupId(int kupId);
    }
}

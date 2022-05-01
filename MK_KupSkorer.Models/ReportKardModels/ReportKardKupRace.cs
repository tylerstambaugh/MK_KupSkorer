using MK_KupSkorer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK_KupSkorer.Models.ReportKardModels
{
    public  class ReportKardKupRace
    {
        public int KupId { get; set; }
        public DateTimeOffset KupDateTime { get; set; }
        public DateTimeOffset RaceDateTime { get; set; }
        public Player Winner { get; set; }
        public int RaceId { get; set; }

    }
}

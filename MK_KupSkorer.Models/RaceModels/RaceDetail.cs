using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK_KupSkorer.Models.RaceModels
{
    public class RaceDetail
    {
        public int RaceId { get; set; }
        public DateTimeOffset? RaceDateTime { get; set; }
        public int KupId { get; set; }
        public int? WinnerId { get; set; }
    }
}

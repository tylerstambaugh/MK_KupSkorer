using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK_KupSkorer.Data
{
    public class Race
    {
        [Key]
        public int RaceId { get; set; }
        public DateTime RaceDateTime { get; set; }
        public int KupId { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK_KupSkorer.Models.KupModels
{
    public class KupBonusPoint
    {
        public int KupId { get; set; }

        public int BonusPointPlayerId { get; set; }
    }
}

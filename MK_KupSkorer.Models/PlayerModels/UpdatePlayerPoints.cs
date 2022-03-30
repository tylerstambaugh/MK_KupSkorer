using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK_KupSkorer.Models.PlayerModels
{
    public class UpdatePlayerPoints
    {
        public int PlayerId { get; set; }
        public double TotalPoints { get; set; }

        public int TotalBonusPoints { get; set; }
    }
}

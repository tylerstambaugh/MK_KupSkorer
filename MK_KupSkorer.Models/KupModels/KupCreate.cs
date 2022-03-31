using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK_KupSkorer.Models.KupModels
{
    public class KupCreate
    {
        public DateTime KupDate { get; set; }
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public int? Player3Id { get; set; }
        public int? Player4Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK_KupSkorer.Data
{
    public class Kup
    {
        [Key]
        public int KupId { get; set; }
        public DateTime KupDate { get; set; }
        [Required]
        public int Player1Id { get; set; }
        public virtual Player Player1 { get; set; }

        [Required]
        public int Player2Id { get; set; }
        public virtual Player Player2 { get; set; }
        public int Player3Id { get; set; }
        public virtual Player Player3 { get; set; }
        public int Player4Id { get; set; }
        public virtual Player Player4 { get; set; }

    }
}

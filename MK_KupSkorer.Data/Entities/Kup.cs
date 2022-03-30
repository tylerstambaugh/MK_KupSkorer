using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MK_KupSkorer.Data
{
    public class Kup
    {
        [Key]
        public int KupId { get; set; }

        [Required]
        public DateTime KupDate { get; set; }

        [Required]
        [ForeignKey(nameof(Player1))]
        public int Player1Id { get; set; }
        public virtual Player Player1 { get; set; }

        [Required]
        [ForeignKey(nameof(Player2))]
        public int Player2Id { get; set; }
        public virtual Player Player2 { get; set; }

        [ForeignKey(nameof(Player3))]
        public int Player3Id { get; set; }
        public virtual Player Player3 { get; set; }

        [ForeignKey(nameof(Player4))]
        public int Player4Id { get; set; }
        public virtual Player Player4 { get; set; }

    }
}

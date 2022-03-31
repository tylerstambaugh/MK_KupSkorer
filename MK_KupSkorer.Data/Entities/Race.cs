using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MK_KupSkorer.Data
{
    public class Race
    {
        [Key]
        public int RaceId { get; set; }
        public DateTime RaceDateTime { get; set; }

        [Required]
        [ForeignKey("Kup")]
        public int KupId { get; set; }
        public virtual Kup Kup { get; set; }

        [Required]
        [ForeignKey(nameof(Winner))]
        public int WinnerId { get; set; }
        public virtual Player Winner { get; set; }

    }
}

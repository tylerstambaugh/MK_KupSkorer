using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MK_KupSkorer.Data
{
    public class Race
    {
        [Key]
        public int RaceId { get; set; }
        [Display(Name = "Race Date")]
        public DateTimeOffset? RaceDateTime { get; set; }

        [Required]
        [ForeignKey("Kup")]
        public int KupId { get; set; }
        public virtual Kup Kup { get; set; }

        [ForeignKey(nameof(Winner))]
        public int? WinnerId { get; set; }
        [Display(Name = "Winner")]
        public virtual Player Winner { get; set; }
    }
}

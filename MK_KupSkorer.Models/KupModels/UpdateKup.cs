using System;
using System.ComponentModel.DataAnnotations;

namespace MK_KupSkorer.Models.KupModels
{
    public class UpdateKup
    {
        public int KupId { get; set; }

        [Required]
        [Display(Name = "Race #")]
        public int RaceCount { get; set; }
        public DateTimeOffset UpdatedDateTime { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MK_KupSkorer.Models.PlayerModels
{
    public class UpdatePlayerPoints
    {
        public int PlayerId { get; set; }

        [Display(Name = "Total Points")]
        public double TotalPoints { get; set; }

        [Display(Name = "Total Bonus Points")]
        public int TotalBonusPoints { get; set; }

        [Display(Name = "Total Wins")]
        public int TotalWins { get; set; }
    }
}

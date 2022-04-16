using System.ComponentModel.DataAnnotations;

namespace MK_KupSkorer.Models.PlayerModels
{
    public class PlayerDetail
    {
        public int PlayerId { get; set; }


        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]

        public string LastName { get; set; }


        [Display(Name = "NickName")]
        public string Nickname { get; set; }

        public bool IsActive { get; set; }


        [Display(Name = "Total Points")]
        public double TotalPoints { get; set; }

        [Display(Name = "Total Bonus Points")]
        public int TotalBonusPoints { get; set; }

        [Display(Name = "Total Wins")]
        public int TotalWins { get; set; }
    }
}

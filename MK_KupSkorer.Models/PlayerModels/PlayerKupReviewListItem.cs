using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK_KupSkorer.Models.PlayerModels
{
    public class PlayerKupReviewListItem
    {
        [Display(Name = "Player Id")]
        public int PlayerId { get; set; }

        [Display(Name = "Name")]
        public string PlayerName { get; set; }
        [Display(Name = "Wins")]
        public int PlayerKupWins { get; set; }
        [Display(Name = "Points")]
        public double PlayerKupPoints { get; set; }
    }
}

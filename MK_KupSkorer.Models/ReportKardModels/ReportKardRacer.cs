using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK_KupSkorer.Models.ReportKardModels
{
    public class ReportKardRacer
    {

        public int PlayerId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Nickname")]
        public string Nickname { get; set; }
        [Display(Name = "# Wins")]
        public int  TotalWins { get; set; }
        [Display(Name = "Total Points")]
        public double TotalRacePoints { get; set; }
        [Display(Name = "Total Bonus Points")]
        public int TotalBonusPoints { get; set; }
    }
}

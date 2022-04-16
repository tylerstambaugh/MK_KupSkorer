using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK_KupSkorer.Models.ReportKardModels
{
    public class ReportKardTotalPoints
    {

        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public double TotalPoints { get; set; }
    }
}

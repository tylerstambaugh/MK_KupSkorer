﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK_KupSkorer.Models.PlayerModels
{
    public class UpdatePlayerAttributes
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nickname { get; set; }

        public double TotalPoints { get; set; }

        public int TotalBonusPoints { get; set; }
    }
}
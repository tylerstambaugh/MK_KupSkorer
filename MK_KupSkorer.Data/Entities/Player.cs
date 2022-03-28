using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK_KupSkorer.Data
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }

        [Required, Display(Name = "First Name"), MinLength(2, ErrorMessage = "First name must be atleast two characters.") ]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name"), MinLength(2, ErrorMessage = "Last name must be atleast two characters.")]
        public string LastName { get; set; }
    }
}

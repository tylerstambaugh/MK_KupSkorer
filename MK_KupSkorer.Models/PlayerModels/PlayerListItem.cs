using System.ComponentModel.DataAnnotations;

namespace MK_KupSkorer.Models.PlayerModels
{
    public class PlayerListItem
    {
        public int PlayerId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Nickname")]
        public string Nickname { get; set; }
        [Display(Name = "Active?")]
        public bool IsActive { get; set; }
    }
}

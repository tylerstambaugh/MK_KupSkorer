using System.ComponentModel.DataAnnotations;

namespace MK_KupSkorer.Models.PlayerModels
{
    public class PlayerCreate
    {
        [Required]
        [Display(Name = "First Name")]
        [MinLength(2, ErrorMessage = "First name must be atleast two characters.")]
        [MaxLength(20, ErrorMessage = "First name cannot exceed 20 characters.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MinLength(2, ErrorMessage = "Last name must be atleast two characters.")]
        [MaxLength(20, ErrorMessage = "Last name cannot exceed 20 characters.")]
        public string LastName { get; set; }

        [Display(Name = "Nickname")]
        [MinLength(2, ErrorMessage = "Nickname must be at least two characters.")]
        [MaxLength(20, ErrorMessage = "Nickname cannot exceed 20 characters.")]
        public string Nickname { get; set; }

        public bool IsActive { get; set; }
    }
}

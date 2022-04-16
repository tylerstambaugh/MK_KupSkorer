using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MK_KupSkorer.Data
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

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

        [Display(Name = "Total Points")]
        public double TotalPoints { get; set; } = 0;

        [Display(Name = "Total Bonus Points")]
        public int TotalBonusPoints { get; set; } = 0;

        [Display(Name = "Total Wins")]
        public int TotalWins { get; set; } = 0;
        public bool IsActive { get; set; }

    }
}

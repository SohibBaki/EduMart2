using EduMart.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace EduMart.Models
{
    public class Mentors:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 50 characters")]
        public string FullName { get; set; }

        [Display(Name = "About")]
        [Required(ErrorMessage = "About is required")]
        public string About { get; set; }

        // Relationships
        public List<Mentors_Skills> ? Mentors_Skills { get; set; }
    }
}

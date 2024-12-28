using IleriWebProje.Data.Base;
using System.ComponentModel.DataAnnotations;


namespace IleriWebProje.Models
{
    public class SkillOrganizers : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Agency")]
        [Required(ErrorMessage = "Profile picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Agency Name")]
        [Required(ErrorMessage = "Full name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 50 characters")]
        public string FullName { get; set; }

        [Display(Name = "About")]
        [Required(ErrorMessage = "About is required")]
        public string About { get; set; }

        // Relationships
        public List<Skills>?Skills { get; set; }

    }
}

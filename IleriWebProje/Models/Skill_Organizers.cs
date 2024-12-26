using System.ComponentModel.DataAnnotations;

namespace IleriWebProje.Models
{
    public class Skill_Organizers
    {
        [Key]
        public int SkillOrganizerID { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "About")]
        public string About { get; set; }

        // Relationships
        public List<Skills> Skills { get; set; }

    }
}

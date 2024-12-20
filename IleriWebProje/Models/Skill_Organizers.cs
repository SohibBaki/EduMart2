using System.ComponentModel.DataAnnotations;

namespace IleriWebProje.Models
{
    public class Skill_Organizers
    {
        [Key]
        public int SkillOrganizerID { get; set; }
        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string About { get; set; }

        // Relationships
        public List<Skills> Skills { get; set; }

    }
}

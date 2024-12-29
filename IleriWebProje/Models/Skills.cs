using IleriWebProje.Data.Base;
using IleriWebProje.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IleriWebProje.Models
{
    public class Skills : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }
        public string Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Skill_Category SkillCategory { get; set; }

        // Relationships
        public List<Mentors_Skills>? Mentors_Skills { get; set; }

        // Platforms
        public int PlatformId { get; set; }
        [ForeignKey("PlatformId")]
        public Platforms Platforms { get; set; }

        // Skill_Organizers
        public int SkillOrganizerID { get; set; }
        [ForeignKey("SkillOrganizerID")]
        public SkillOrganizers Skill_Organizers { get; set; }
    }
}

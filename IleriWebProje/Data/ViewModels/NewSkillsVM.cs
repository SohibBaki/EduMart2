using IleriWebProje.Data.Base;
using IleriWebProje.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IleriWebProje.Models
{
    public class NewSkillsVM
    {

        [Display(Description = "Skill Name")]
        [Required(ErrorMessage = "Name is required")]
        public string SkillName { get; set; }
        [Display(Description = "Skill Description")]
        [Required(ErrorMessage = "Description is required")]
        public string SkillDescription { get; set; }
        [Display(Description = "Price in TL")]
        [Required(ErrorMessage = "Price is required")]
        public string Price { get; set; }
        [Display(Description = "Image URL")]
        [Required(ErrorMessage = "Image URL is required")]
        public string ImageURL { get; set; }
        [Display(Description = "Skill Start Date")]
        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }
        [Display(Description = "Skill End Date")]
        [Required(ErrorMessage = "End Date is required")]
        public DateTime EndDate { get; set; }
        [Display(Description = "Skill Category")]
        [Required(ErrorMessage = "Category is required")]
        public Skill_Category SkillCategory { get; set; }

        // Relationships
        [Display(Description = "Select Mentor(s)")]
        [Required(ErrorMessage = "Skill Mentor(s) is required")]
        public List<int>? MentorIds { get; set; }

        [Display(Description = "Select a Platform")]
        [Required(ErrorMessage = "Skill Platform is required")]
        public int PlatformId { get; set; }

        [Display(Description = "Select a Skill Organizer")]
        [Required(ErrorMessage = "Skill Organizer is required")]
        public int SkillOrganizerID { get; set; }

    }
}

using EduMart.Data.Base;
using EduMart.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduMart.Data.ViewModels
{
    public class NewSkillsVM
    {
        public int Id { get; set; }

        [Display(Name = "Skill Name")]
        [Required(ErrorMessage = "Name is required")]
        public string SkillName { get; set; }

        [Display(Name = "Skill description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Image URL")]
        [Required(ErrorMessage = "Image URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Skill Start Date")]
        [Required(ErrorMessage = "Start Date is required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Skill End Date")]
        [Required(ErrorMessage = "End Date is required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Skill Category")]
        [Required(ErrorMessage = "Category is required")]
        public Skill_Category SkillCategory { get; set; }

        // Relationships
        [Display(Name = "Select Mentor(s)")]
        [Required(ErrorMessage = "Skill Mentor(s) is required")]
        public List<int>? MentorIds { get; set; }

        [Display(Name = "Select a Platform")]
        [Required(ErrorMessage = "Skill Platform is required")]
        public int PlatformId { get; set; }

        [Display(Name = "Select a Skill Organizer")]
        [Required(ErrorMessage = "Skill Organizer is required")]
        public int SkillOrganizerID { get; set; }
    }
}

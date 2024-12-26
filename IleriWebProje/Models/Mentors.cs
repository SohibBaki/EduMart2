using System.ComponentModel.DataAnnotations;

namespace IleriWebProje.Models
{
    public class Mentors
    {
        [Key]
        public int MentorID { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "About")]
        //public string Title { get; set; }
        public string About { get; set; }

        // Relationships
        public List<Mentors_Skills> Mentors_Skills { get; set; }
    }
}

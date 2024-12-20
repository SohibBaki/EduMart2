using System.ComponentModel.DataAnnotations;

namespace IleriWebProje.Models
{
    public class Mentors
    {
        [Key]
        public int MentorID { get; set; }
        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string About { get; set; }

        // Relationships
        public List<Mentors_Skills> Mentors_Skills { get; set; }
    }
}

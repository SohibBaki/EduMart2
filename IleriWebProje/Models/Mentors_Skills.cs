namespace IleriWebProje.Models
{
    public class Mentors_Skills
    {
        public int MentorID { get; set; }
        public Mentors Mentors { get; set; }
        public int SkillID { get; set; }
        public Skills Skills { get; set; }
    }
}

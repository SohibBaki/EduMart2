namespace IleriWebProje.Models
{
    public class Mentors_Skills
    {
        public int Id { get; set; }
        public Mentors Mentor { get; set; }
        public int SkillID { get; set; }
        public Skills Skill { get; set; }
    }
}

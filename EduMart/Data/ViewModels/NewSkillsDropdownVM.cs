using EduMart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace EduMart.Data.ViewModels
{
    public class NewSkillsDropdownVM
    {
        public NewSkillsDropdownVM()
        {
            skillOrganizers = new List<SkillOrganizers>();
            platforms = new List<Platforms>();
            mentors = new List<Mentors>();
        }

        public List<SkillOrganizers> skillOrganizers { get; set; }
        public List<Platforms> platforms { get; set; }
        public List<Mentors> mentors { get; set; }
    }
}

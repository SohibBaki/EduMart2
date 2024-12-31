using IleriWebProje.Data;
using IleriWebProje.Data.Base;
using IleriWebProje.Data.ViewModels;
using IleriWebProje.Models;
using Microsoft.EntityFrameworkCore;

namespace IleriWebProje.Data.Services
{
    public class SkillsService : EntityBaseRepository<Skills>, ISkillsService
    {
        private readonly AppDbContext _context;

        public SkillsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewSkillAsync(NewSkillsVM data)
        {
            var newSkill = new Skills()
            {
                SkillName = data.SkillName,
                SkillDescription = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                PlatformId = data.PlatformId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                SkillCategory = data.SkillCategory,
                SkillOrganizerID = data.SkillOrganizerID
            };
            await _context.Skills.AddAsync(newSkill);
            await _context.SaveChangesAsync();

            //Add Skills
            foreach (var mentorId in data.MentorIds)
            {
                var newMentorSkill = new Mentors_Skills()
                {
                    SkillID = newSkill.Id,
                    MentorID = mentorId
                };
                await _context.Mentors_Skills.AddAsync(newMentorSkill);
            }
            await _context.SaveChangesAsync();
        }


        public async Task<NewSkillsDropdownVM> GetNewSkillDropdownValuesAsync()
        {
            var response = new NewSkillsDropdownVM()
            {
                platforms = await _context.Platforms.OrderBy(n => n.PlatformName).ToListAsync(),
                skillOrganizers = await _context.Skill_Organizers.OrderBy(n => n.FullName).ToListAsync(),
                mentors = await _context.Mentors.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task<Skills> GetSkillByIdAsync(int id)
        {
            return await _context.Skills
                .Include(s => s.Platforms)
                .Include(s => s.Skill_Organizers)
                .Include(s => s.Mentors_Skills)
                    .ThenInclude(s => s.Mentors)
                .FirstOrDefaultAsync(s => s.Id == id);
        }



        public async Task UpdateSkillAsync(NewSkillsVM data)
        {
            var dbSkill = await _context.Skills.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbSkill != null)
            {
                dbSkill.SkillName = data.SkillName;
                dbSkill.SkillDescription = data.Description;
                dbSkill.Price = data.Price;
                dbSkill.ImageURL = data.ImageURL;
                dbSkill.PlatformId = data.PlatformId;
                dbSkill.StartDate = data.StartDate;
                dbSkill.EndDate = data.EndDate;
                dbSkill.SkillCategory = data.SkillCategory;
                dbSkill.SkillOrganizerID = data.SkillOrganizerID;
                await _context.SaveChangesAsync();
            }

            //Removing existing Mentors
            var existingMentorsDb = _context.Mentors_Skills.Where(n => n.SkillID == data.Id).ToList();
            _context.Mentors_Skills.RemoveRange(existingMentorsDb);
            await _context.SaveChangesAsync();

            //Add Skills Mentors
            foreach (var mentorId in data.MentorIds)
            {
                var newMentorSkill = new Mentors_Skills()
                {
                    SkillID = data.Id,
                    MentorID = mentorId
                };
                await _context.Mentors_Skills.AddAsync(newMentorSkill);
            }
            await _context.SaveChangesAsync();
        }
    }
}

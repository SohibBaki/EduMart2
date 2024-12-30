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

        public Task AddNewMovieAsync(NewSkillsVM data)
        {
            throw new NotImplementedException();
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

        public Task UpdateMovieAsync(NewSkillsVM data)
        {
            throw new NotImplementedException();
        }
    }
}

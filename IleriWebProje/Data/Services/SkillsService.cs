using IleriWebProje.Data;
using IleriWebProje.Data.Base;
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

        public async Task<Skills> GetSkillByIdAsync(int id)
        {
            return await _context.Skills
                .Include(s => s.Platforms)
                .Include(s => s.Skill_Organizers)
                .Include(s => s.Mentors_Skills)
                    .ThenInclude(ms => ms.Mentor)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}

using EduMart.Data.Base;
using EduMart.Models;

namespace EduMart.Data.Services
{
    public class SkillOrganizersService : EntityBaseRepository<SkillOrganizers>, ISkillOrganizersService
    {
        public SkillOrganizersService(AppDbContext context) : base(context) { }
    }
}

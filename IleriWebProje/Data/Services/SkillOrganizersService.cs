using IleriWebProje.Data.Base;
using IleriWebProje.Models;

namespace IleriWebProje.Data.Services
{
    public class SkillOrganizersService : EntityBaseRepository<SkillOrganizers>, ISkillOrganizersService
    {
        public SkillOrganizersService(AppDbContext context) : base(context) { }
    }
}

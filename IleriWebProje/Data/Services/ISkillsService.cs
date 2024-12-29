using IleriWebProje.Data.Base;
using IleriWebProje.Models;

namespace IleriWebProje.Data.Services
{
    public interface ISkillsService : IEntityBaseRepository<Skills>
    {
        Task<Skills> GetSkillByIdAsync(int id);
    }


}

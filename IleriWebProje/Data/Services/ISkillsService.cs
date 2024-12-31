using IleriWebProje.Data.Base;
using IleriWebProje.Models;
using IleriWebProje.Data.ViewModels;


namespace IleriWebProje.Data.Services
{
    public interface ISkillsService : IEntityBaseRepository<Skills>
    {
        Task<Skills> GetSkillByIdAsync(int id);
        Task<NewSkillsDropdownVM> GetNewSkillDropdownValuesAsync();
        Task AddNewSkillAsync(NewSkillsVM data);
        Task UpdateSkillAsync(NewSkillsVM data);
    }
}

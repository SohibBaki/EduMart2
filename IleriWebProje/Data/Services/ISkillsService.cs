using EduMart.Data.Base;
using EduMart.Models;
using EduMart.Data.ViewModels;


namespace EduMart.Data.Services
{
    public interface ISkillsService : IEntityBaseRepository<Skills>
    {
        Task<Skills> GetSkillByIdAsync(int id);
        Task<NewSkillsDropdownVM> GetNewSkillDropdownValuesAsync();
        Task AddNewSkillAsync(NewSkillsVM data);
        Task UpdateSkillAsync(NewSkillsVM data);
    }
}

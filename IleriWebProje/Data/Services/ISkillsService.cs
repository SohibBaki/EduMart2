using IleriWebProje.Data.Base;
using IleriWebProje.Models;
using IleriWebProje.Data.ViewModels;


namespace IleriWebProje.Data.Services
{
    public interface ISkillsService : IEntityBaseRepository<Skills>
    {
        Task<Skills> GetSkillByIdAsync(int id);
        Task<NewSkillsDropdownVM> GetNewSkillDropdownValuesAsync();
        Task AddNewMovieAsync(NewSkillsVM data);
        Task UpdateMovieAsync(NewSkillsVM data);
    }
}

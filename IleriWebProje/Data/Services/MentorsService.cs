using IleriWebProje.Data.Base;
using IleriWebProje.Models;
using Microsoft.EntityFrameworkCore;

namespace IleriWebProje.Data.Services
{
    public class MentorsService : EntityBaseRepository<Mentors>, IMentorsService
    {
        public MentorsService(AppDbContext context) : base(context) { }
    }
}

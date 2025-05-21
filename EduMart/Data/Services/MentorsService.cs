using EduMart.Data.Base;
using EduMart.Models;
using Microsoft.EntityFrameworkCore;

namespace EduMart.Data.Services
{
    public class MentorsService : EntityBaseRepository<Mentors>, IMentorsService
    {
        public MentorsService(AppDbContext context) : base(context) { }
    }
}

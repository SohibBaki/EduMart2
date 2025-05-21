using EduMart.Data.Base;
using EduMart.Models;

namespace EduMart.Data.Services
{
    public class PlatformService : EntityBaseRepository<Platforms>, IPlatformService
    {
        public PlatformService(AppDbContext context) : base(context)
        {
            
        }
    }
}

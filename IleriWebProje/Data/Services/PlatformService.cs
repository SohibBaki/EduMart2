using IleriWebProje.Data.Base;
using IleriWebProje.Models;

namespace IleriWebProje.Data.Services
{
    public class PlatformService : EntityBaseRepository<Platforms>, IPlatformService
    {
        public PlatformService(AppDbContext context) : base(context)
        {
            
        }
    }
}

using IleriWebProje.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IleriWebProje.Controllers
{
    public class PlatformsController : Controller
    {
        private readonly AppDbContext _context;
        public PlatformsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task <IActionResult> Index()
        {
             var allPlatforms = await _context.Platforms.ToListAsync();
            return View(allPlatforms);
        }
    }
}

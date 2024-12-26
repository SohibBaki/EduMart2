using IleriWebProje.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IleriWebProje.Controllers
{
    public class Skill_OrganizersController : Controller
    {
        private readonly AppDbContext _context;
        public Skill_OrganizersController(AppDbContext context)
        {
            _context = context;
        }
        public async Task <IActionResult> Index()
        {
            var allskill_Organizers = await _context.Skill_Organizers.ToListAsync();
            return View(allskill_Organizers);
        }
    }
} 

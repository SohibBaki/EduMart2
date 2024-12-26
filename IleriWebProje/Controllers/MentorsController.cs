using IleriWebProje.Data;
using Microsoft.AspNetCore.Mvc;

namespace IleriWebProje.Controllers
{
    public class MentorsController : Controller
    {
        private readonly AppDbContext _context;
        public MentorsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var allMentors = _context.Mentors.ToList();
            return View(allMentors);
        }
    }
}

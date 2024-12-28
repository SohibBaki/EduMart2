using IleriWebProje.Data;
using IleriWebProje.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IleriWebProje.Controllers
{
    public class PlatformsController : Controller
    {
        private readonly IPlatformService _service;
        public PlatformsController(IPlatformService service)
        {
            _service = service;
        }
        public async Task <IActionResult> Index()
        {
             var allPlatforms = await _service.GetAllAsync();
            return View(allPlatforms);
        }
    }
}

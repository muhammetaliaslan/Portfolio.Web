using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;
using System.Linq;

namespace Portfolio.Web.Controllers
{
    public class AboutController : Controller
    {
        private readonly PortfolioContext _context;

        public AboutController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Son eklenen aktif kaydı al
            var aboutData = _context.Abouts
                                    .Where(a => a.IsAvailable)
                                    .OrderByDescending(a => a.AboutId)
                                    .FirstOrDefault();

            if (aboutData == null)
            {
                aboutData = new About
                {
                    Title = "Başlık Yok",
                    Description = "Hakkımda bilgisi bulunamadı.",
                    ImageUrl = "~/Kelly-1.0.0/assets/img/profile-img.jpg",
                    Birthdate = System.DateTime.Now,
                    WebSite = "-",
                    PhoneNumber = "-",
                    City = "-",
                    Graduation = "-",
                    Email = "-",
                    IsAvailable = false
                };
            }

            return View(aboutData);
        }
    }
}

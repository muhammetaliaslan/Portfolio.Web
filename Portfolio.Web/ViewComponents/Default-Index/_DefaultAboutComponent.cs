using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;
using System.Linq;

namespace Portfolio.Web.ViewComponents.Default_Index
{
    public class _DefaultAboutComponent : ViewComponent
    {
        private readonly PortfolioContext _context;

        // Dependency Injection ile Context’i alıyoruz
        public _DefaultAboutComponent(PortfolioContext context)
        {
            _context = context;
        }

        // Kullanıcı tarafında Hakkımda bilgilerini gösterir
        public IViewComponentResult Invoke()
        {
            var about = _context.Abouts.FirstOrDefault(); // Tek kayıt alıyoruz
            return View(about);
        }
    }
}

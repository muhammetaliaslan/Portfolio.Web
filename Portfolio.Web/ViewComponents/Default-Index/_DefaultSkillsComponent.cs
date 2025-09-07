using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using System.Linq;

namespace Portfolio.Web.ViewComponents.Default_Index
{
    public class _DefaultSkillsComponent : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultSkillsComponent(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            // Veritabanından tüm yetenekleri alıyoruz
            var skills = _context.Skills.ToList();
            return View(skills); // Model olarak gönderiyoruz
        }
    }
}

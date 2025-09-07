using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;
using System.Linq;

namespace Portfolio.Web.ViewComponents.Default_Index
{
    public class _DefaultResumeComponent : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultResumeComponent(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            // Artık ViewModel yok, direkt verileri View'a gönderiyoruz
            var educations = _context.Educations.ToList();
            var experiences = _context.Experiences.ToList();

            ViewData["Educations"] = educations;
            ViewData["Experiences"] = experiences;

            return View();
        }
    }
}

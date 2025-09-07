using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using System.Linq;

namespace Portfolio.Web.ViewComponents.Default_Index
{
    public class _DefaultTestimonialsComponent : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultTestimonialsComponent(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var testimonials = _context.Testimonials
                .OrderByDescending(x => x.TestimonialId)
                .Take(3)
                .ToList();

            return View(testimonials);
        }
    }
}

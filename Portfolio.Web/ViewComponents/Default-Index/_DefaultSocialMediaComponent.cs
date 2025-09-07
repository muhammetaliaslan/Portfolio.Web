using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Default
{
    public class _DefaultSocialMediaComponent : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultSocialMediaComponent(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var social = _context.SocialMedias.FirstOrDefault();
            return View(social);
        }
    }
}

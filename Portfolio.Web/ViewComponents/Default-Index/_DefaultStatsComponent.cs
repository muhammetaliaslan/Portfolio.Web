using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Default_Index
{
    public class _DefaultStatsComponent : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultStatsComponent(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var model = new StatsViewModel
            {
                ProjectCount = _context.Projects.Count(),
                SkillCount = _context.Skills.Count(),
                ExperienceCount = _context.Experiences.Count(),
                MessageCount = _context.UserMessages.Count()
            };

            return View(model);
        }
    }

    public class StatsViewModel
    {
        public int ProjectCount { get; set; }
        public int SkillCount { get; set; }
        public int ExperienceCount { get; set; }
        public int MessageCount { get; set; }
    }
}


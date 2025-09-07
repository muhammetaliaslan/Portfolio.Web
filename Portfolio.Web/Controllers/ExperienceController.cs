
using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;
using System.Linq;

namespace Portfolio.Web.Controllers.Admin
{
    public class ExperienceController : Controller
    {
        private readonly PortfolioContext _context;
        public ExperienceController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var experiences = _context.Experiences.ToList();
            return View(experiences);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Experience experience)
        {
            if (ModelState.IsValid)
            {
                _context.Experiences.Add(experience);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(experience);
        }

        public IActionResult Edit(int id)
        {
            var experience = _context.Experiences.FirstOrDefault(e => e.ExperienceId == id);
            if (experience == null) return NotFound();
            return View(experience);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Experience experience)
        {
            if (ModelState.IsValid)
            {
                var existing = _context.Experiences.FirstOrDefault(e => e.ExperienceId == experience.ExperienceId);
                if (existing == null) return NotFound();

                existing.Title = experience.Title;
                existing.Company = experience.Company;
                existing.City = experience.City;
                existing.StartYear = experience.StartYear;
                existing.EndYear = experience.EndYear;
                existing.Description = experience.Description;

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(experience);
        }

        public IActionResult Delete(int id)
        {
            var experience = _context.Experiences.FirstOrDefault(e => e.ExperienceId == id);
            if (experience == null) return NotFound();

            _context.Experiences.Remove(experience);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

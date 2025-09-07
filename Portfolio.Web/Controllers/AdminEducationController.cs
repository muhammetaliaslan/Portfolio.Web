using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;
using System.Linq;

namespace Portfolio.Web.Controllers
{
    public class AdminEducationController : Controller
    {
        private readonly PortfolioContext _context;

        public AdminEducationController(PortfolioContext context)
        {
            _context = context;
        }

        // GET: /AdminEducation/Index
        public IActionResult Index()
        {
            var educations = _context.Educations.ToList();
            return View(educations);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Education education)
        {
            if (ModelState.IsValid)
            {
                _context.Educations.Add(education);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(education);
        }

        public IActionResult Edit(int id)
        {
            var education = _context.Educations.FirstOrDefault(e => e.EducationId == id);
            if (education == null) return NotFound();
            return View(education);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Education education)
        {
            if (ModelState.IsValid)
            {
                var existing = _context.Educations.FirstOrDefault(e => e.EducationId == education.EducationId);
                if (existing == null) return NotFound();

                existing.SchoolName = education.SchoolName;
                existing.Department = education.Department;
                existing.StartYear = education.StartYear;
                existing.EndYear = education.EndYear;
                existing.Description = education.Description;

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(education);
        }

        public IActionResult Delete(int id)
        {
            var education = _context.Educations.FirstOrDefault(e => e.EducationId == id);
            if (education == null) return NotFound();

            _context.Educations.Remove(education);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

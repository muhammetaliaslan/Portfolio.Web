using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly PortfolioContext _context;

        public AdminAboutController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var abouts = _context.Abouts.ToList();
            return View(abouts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(About about)
        {
            _context.Abouts.Add(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var about = _context.Abouts.Find(id);
            return View(about);
        }

        [HttpPost]
        public IActionResult Edit(About about)
        {
            _context.Abouts.Update(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var about = _context.Abouts.Find(id);
            _context.Abouts.Remove(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

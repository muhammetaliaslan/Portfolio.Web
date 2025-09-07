using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;
using System.Linq;

namespace Portfolio.Web.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly PortfolioContext _context;

        public TestimonialController(PortfolioContext context)
        {
            _context = context;
        }

        // Listeleme
        public IActionResult Index()
        {
            var testimonials = _context.Testimonials.ToList();
            return View(testimonials);
        }

        // Yeni testimonial ekleme formu
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Testimonial testimonial)
        {
            if (ModelState.IsValid)
            {
                _context.Testimonials.Add(testimonial);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testimonial);
        }

        // Düzenleme formu
        public IActionResult Edit(int id)
        {
            var testimonial = _context.Testimonials.FirstOrDefault(x => x.TestimonialId == id);
            if (testimonial == null) return NotFound();
            return View(testimonial);
        }

        [HttpPost]
        public IActionResult Edit(Testimonial testimonial)
        {
            if (ModelState.IsValid)
            {
                _context.Testimonials.Update(testimonial);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testimonial);
        }

        // Silme işlemi
        public IActionResult Delete(int id)
        {
            var testimonial = _context.Testimonials.FirstOrDefault(x => x.TestimonialId == id);
            if (testimonial == null) return NotFound();

            _context.Testimonials.Remove(testimonial);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

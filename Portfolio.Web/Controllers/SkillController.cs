using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;
using System.Linq;

namespace Portfolio.Web.Controllers.Admin
{
    public class SkillController : Controller
    {
        private readonly PortfolioContext _context;

        public SkillController(PortfolioContext context)
        {
            _context = context;
        }

        // GET: Admin/Skills
        public IActionResult Index()
        {
            var skills = _context.Skills.ToList();
            return View(skills);
        }

        // GET: Admin/Skills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Skills/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Skill skill)
        {
            if (ModelState.IsValid)
            {
                _context.Skills.Add(skill);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(skill);
        }

        // GET: Admin/Skills/Edit/5
        public IActionResult Edit(int id)
        {
            var skill = _context.Skills.FirstOrDefault(s => s.SkillId == id);
            if (skill == null)
                return NotFound();
            return View(skill);
        }

        // POST: Admin/Skills/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Skill skill)
        {
            if (ModelState.IsValid)
            {
                var existingSkill = _context.Skills.FirstOrDefault(s => s.SkillId == skill.SkillId);
                if (existingSkill == null)
                    return NotFound();

                existingSkill.Title = skill.Title;
                existingSkill.Percentage = skill.Percentage;

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(skill);
        }

        // GET: Admin/Skills/Delete/5
        public IActionResult Delete(int id)
        {
            var skill = _context.Skills.FirstOrDefault(s => s.SkillId == id);
            if (skill == null)
                return NotFound();

            _context.Skills.Remove(skill);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}

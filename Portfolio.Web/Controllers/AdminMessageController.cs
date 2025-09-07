using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;
using System.Linq;

namespace Portfolio.Web.Controllers
{
    public class AdminMessageController : Controller
    {
        private readonly PortfolioContext _context;

        public AdminMessageController(PortfolioContext context)
        {
            _context = context;
        }

        // Mesaj listesi
        public IActionResult Index()
        {
            var messages = _context.UserMessages.OrderByDescending(m => m.UserMessageId).ToList();
            return View(messages);
        }

        // Mesaj detay / aç
        public IActionResult Details(int id)
        {
            var message = _context.UserMessages.FirstOrDefault(m => m.UserMessageId == id);
            if (message == null) return NotFound();

            if (!message.IsRead)
            {
                message.IsRead = true;
                _context.SaveChanges();
            }

            return View(message);
        }

        // Mesaj sil
        public IActionResult Delete(int id)
        {
            var message = _context.UserMessages.FirstOrDefault(m => m.UserMessageId == id);
            if (message == null) return NotFound();

            _context.UserMessages.Remove(message);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

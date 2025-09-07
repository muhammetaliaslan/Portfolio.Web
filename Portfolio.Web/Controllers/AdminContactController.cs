using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;
using System.Linq;

namespace Portfolio.Web.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly PortfolioContext _context;

        public AdminContactController(PortfolioContext context)
        {
            _context = context;
        }

        // Index: Tüm contact bilgilerini listele
        public IActionResult Index()
        {
            var contacts = _context.ContactInfos.ToList();
            return View(contacts);
        }

        // Edit: Contact bilgilerini düzenle (GET)
        public IActionResult Edit(int id)
        {
            var contact = _context.ContactInfos.FirstOrDefault(c => c.ContactInfoId == id);
            if (contact == null) return NotFound();

            return View(contact);
        }

        // Edit: Contact bilgilerini kaydet (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ContactInfo contact)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Lütfen tüm alanları doğru doldurun!";
                return View(contact);
            }

            var existingContact = _context.ContactInfos.FirstOrDefault(c => c.ContactInfoId == contact.ContactInfoId);
            if (existingContact == null) return NotFound();

            existingContact.Address = contact.Address;
            existingContact.PhoneNumber = contact.PhoneNumber;
            existingContact.Email = contact.Email;
            existingContact.MapUrl = contact.MapUrl;

            _context.SaveChanges();

            TempData["SuccessMessage"] = "İletişim bilgileri başarıyla güncellendi!";
            return RedirectToAction("Index");
        }
    }
}

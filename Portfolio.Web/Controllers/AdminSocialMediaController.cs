using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;
using System.Linq;

namespace Portfolio.Web.Controllers
{
    public class AdminSocialMediaController : Controller
    {
        private readonly PortfolioContext _context;

        public AdminSocialMediaController(PortfolioContext context)
        {
            _context = context;
        }

        // GET: AdminSocialMedia
        public IActionResult Index()
        {
            // Veritabanından tek bir sosyal medya kaydını al
            var social = _context.SocialMedias.FirstOrDefault();
            return View(social);
        }

        // POST: AdminSocialMedia/Update
        [HttpPost]
        public IActionResult Update(SocialMedia model)
        {
            // Veritabanında zaten bir kayıt var mı kontrol et
            var social = _context.SocialMedias.FirstOrDefault();
            if (social == null)
            {
                // Yoksa yeni kayıt ekle
                _context.SocialMedias.Add(model);
            }
            else
            {
                // Varsa var olan kayıtları güncelle
                social.Twitter = model.Twitter;
                social.Facebook = model.Facebook;
                social.Instagram = model.Instagram;
                social.LinkedIn = model.LinkedIn;
            }

            _context.SaveChanges();

            // Başarı mesajını TempData ile gönder
            TempData["SuccessMessage"] = "Bilgiler başarıyla güncellendi.";

            return RedirectToAction("Index");
        }
    }
}

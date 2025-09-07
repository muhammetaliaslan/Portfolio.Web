using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;
using Portfolio.Web.Models;
using System.Linq;

namespace Portfolio.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly PortfolioContext _context;

        public ProfileController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Update()
        {
            var userName = HttpContext.Session.GetString("UserName");
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);

            if (user == null)
                return RedirectToAction("Login", "Auth");

            var model = new ProfileUpdateViewModel
            {
                UserName = user.UserName
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(ProfileUpdateViewModel model)
        {
            var userName = HttpContext.Session.GetString("UserName");
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);

            if (user == null)
            {
                ViewBag.Message = "Kullanıcı bulunamadı";
                return View(model);
            }

            if (user.Password != model.CurrentPassword)
            {
                ModelState.AddModelError("CurrentPassword", "Mevcut şifre hatalı");
                return View(model);
            }

            if (!string.IsNullOrEmpty(model.NewPassword))
            {
                if (model.NewPassword != model.ConfirmNewPassword)
                {
                    ModelState.AddModelError("ConfirmNewPassword", "Yeni şifreler eşleşmiyor");
                    return View(model);
                }

                user.Password = model.NewPassword;
            }

            user.UserName = model.UserName;
            _context.SaveChanges();

            ViewBag.Message = "Bilgiler başarıyla güncellendi";
            return View(model);
        }
    }
}

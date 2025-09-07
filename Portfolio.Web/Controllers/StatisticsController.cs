using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using System;
using System.Linq;

namespace Portfolio.Web.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly PortfolioContext _context;

        public StatisticsController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Mevcut istatistikler
            ViewBag.skillAverage = _context.Skills.Any() ? _context.Skills.Average(x => x.Percentage).ToString("00.00") : "0.00";
            ViewBag.unreadMessageCount = _context.UserMessages.Count(x => x.IsRead == false);
            ViewBag.lastMessageOwner = _context.UserMessages.OrderByDescending(x => x.UserMessageId).Select(x => x.Name).FirstOrDefault();
            var startYear = _context.Experiences.Any() ? _context.Experiences.Min(x => x.StartYear) : DateTime.Now.Year;
            ViewBag.experienceYear = DateTime.Now.Year - startYear;
            ViewBag.companyCount = _context.Experiences.Select(x => x.Company).Distinct().Count();
            ViewBag.reviewAverage = _context.Testimonials.Any() ? _context.Testimonials.Average(x => x.Review).ToString("0.0") : "Değerlendirme Yapılmadı";
            ViewBag.MaxReviewOwner = _context.Testimonials.OrderByDescending(x => x.Review).Select(x => x.Name).FirstOrDefault();

            // Yeni eklenen istatistikler
            ViewBag.experienceCount = _context.Experiences.Count();
            ViewBag.skillCount = _context.Skills.Count();
            ViewBag.messageCount = _context.UserMessages.Count();
            ViewBag.projectCount = _context.Projects.Count();

            // İsteğe bağlı olarak diğer yeni istatistikler
            ViewBag.totalClients = 50; // Örnek sabit değer, dilersen dinamik hesaplayabilirsin
            ViewBag.hoursOfSupport = 1453; // Örnek sabit değer
            ViewBag.workersCount = 32; // Örnek sabit değer

            return View();
        }
    }
}

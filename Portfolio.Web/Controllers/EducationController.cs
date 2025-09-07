using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

public class EducationController : Controller
{
    private readonly PortfolioContext _context;
    public EducationController(PortfolioContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var educations = _context.Educations.ToList();
        return View(educations); // UI view'e model olarak gönderiliyor
    }
}

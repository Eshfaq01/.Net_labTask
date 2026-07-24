using assignment.EF;
using Microsoft.AspNetCore.Mvc;

namespace assignment.Controllers
{
    public class ReportController : Controller
    {
        BloodBankDbContext db;
        public ReportController(BloodBankDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

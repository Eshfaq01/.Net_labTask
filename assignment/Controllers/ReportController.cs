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
        // + er jonno url= /Report/BGFilter?group=W%2B----------------------------------------
        public IActionResult BGFilter(string group)
        {
            var data =
                db.Donors
                .Where(x => x.BloodGroup == group.Trim())
                .ToList();


            return View(data);
        }
        public IActionResult RecentDonors()
        {

            var data =
                db.Donors
                .OrderByDescending(x => x.LastDonationDate)
                .ToList();


            return View(data);

        }
        public IActionResult DonationCount()
        {

            var result = db.Donors
            .Select(d => new
            {
                Name = d.FullName,
                TotalDonation = d.Donations.Count()
            })
            .ToList();

            return View(result);

        }
        public IActionResult TotalVolume()
        {

            int total =
            db.Donations
            .Sum(x => x.VolumeMl);


            ViewBag.Total = total;


            return View();

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

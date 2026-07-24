using assignment.EF;
using assignment.EF.Tables;
using Microsoft.AspNetCore.Mvc;


namespace assignment.Controllers
{
    
    public class DonorController : Controller
    {
        BloodBankDbContext db;
        public DonorController(BloodBankDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Donor d)
        {
            if (ModelState.IsValid)
            {
                db.Donors.Add(d);
                var rs=db.SaveChanges();
                if (rs >= 0) return RedirectToAction("Index");
                
            }

            return View(d);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var d= db.Donors.Find(id);

            return View(d);
        }
        [HttpPost]
        public IActionResult Edit(Donor d)
        {
            if (ModelState.IsValid)
            {
                db.Donors.Update(d);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(d);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var donor = db.Donors.Find(id);

            return View(donor);
        }
        [HttpPost]
        public IActionResult Delete(Donor d)
        {
            var data = db.Donors.Find(d.DonorId);

            db.Donors.Remove(data);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var data = db.Donors.ToList();
            return View(data);
        }
    }
}

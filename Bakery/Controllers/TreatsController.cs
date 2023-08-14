using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Bakery.Controllers
{
    public class TreatsController : Controller
    {
        private readonly BakeryContext _db;

        public TreatsController(BakeryContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Treat> treats = _db.Treats.ToList();
            return View(treats);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Treat treat)
        {
            _db.Treats.Add(treat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Treat treat = _db.Treats.FirstOrDefault(model => model.TreatId == id);
            return View(treat);
        }

        public ActionResult Update(int id)
        {
            Treat treat = _db.Treats.FirstOrDefault(model => model.TreatId == id);
            return View(treat);
        }

        [HttpPost]
        public ActionResult Update(Treat treat)
        {
            _db.Update(treat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Treat treat = _db.Treats.FirstOrDefault(model => model.TreatId == id);
            return View(treat);
        }

        [HttpPost]
        public ActionResult Delete(Treat treat)
        {
            _db.Remove(treat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
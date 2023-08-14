using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Bakery.Controllers
{
    public class FlavorsController : Controller
    {
        private readonly BakeryContext _db;

        public FlavorsController(BakeryContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Flavor> flavors = _db.Flavors.ToList();
            return View(flavors);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Flavor flavor)
        {
            _db.Flavors.Add(flavor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Flavor flavor = _db.Flavors.FirstOrDefault(model => model.FlavorId == id);
            return View(flavor);
        }

        public ActionResult Update(int id)
        {
            Flavor flavor = _db.Flavors.FirstOrDefault(model => model.FlavorId == id);
            return View(flavor);
        }

        [HttpPost]
        public ActionResult Update(Flavor flavor)
        {
            _db.Update(flavor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Flavor flavor = _db.Flavors.FirstOrDefault(model => model.FlavorId == id);
            return View(flavor);
        }

        [HttpPost]
        public ActionResult Delete(Flavor flavor)
        {
            _db.Remove(flavor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
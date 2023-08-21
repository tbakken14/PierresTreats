using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Bakery.Controllers
{
    [Authorize]
    public class TreatsController : Controller
    {
        private readonly BakeryContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public TreatsController(BakeryContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [AllowAnonymous]
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
            Treat treat = _db.Treats
                .Include(m => m.TreatFlavors)
                .ThenInclude(m => m.Flavor)
                .FirstOrDefault(model => model.TreatId == id);
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

        public ActionResult AddFlavor(int id)
        {
            Treat treat = _db.Treats
                .FirstOrDefault(model => model.TreatId == id);
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
            return View(treat);
        }

        [HttpPost]
        public ActionResult AddFlavor(Treat treat, int flavorId)
        {
#nullable enable
            TreatFlavor? treatFlavor = _db.TreatFlavors
                .FirstOrDefault(model => model.FlavorId == flavorId && model.TreatId == treat.TreatId);
#nullable disable
            if (treatFlavor == null && flavorId != 0)
            {
                _db.TreatFlavors.Add(new TreatFlavor() { FlavorId = flavorId, TreatId = treat.TreatId });
                _db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = treat.TreatId });
        }
    }
}
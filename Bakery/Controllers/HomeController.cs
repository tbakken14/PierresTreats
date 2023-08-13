using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Bakery.Controllers
{
    public class HomeController : Controller
    {
        private readonly BakeryContext _db;

        public HomeController(BakeryContext db)
        {
            _db = db;
        }
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
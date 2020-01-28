using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AplikacjeInternetoweProject.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext db = new AppDbContext();
        public async Task<ActionResult> Index() 
        { 
            var products = db.Products.Include(p => p.Category);
            return View(await products.ToListAsync());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using iBuy.Models;

namespace iBuy.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = null;

        public HomeController()
        {
            db = new ApplicationDbContext();
        }

        public async Task<ActionResult> Index()
        {
            return View(await db.Announces.ToListAsync());
        }

//        public ActionResult Index()
//        {
//            return View();
//        }

        // GET: Announces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announce announce = db.Announces.Find(id);
            if (announce == null)
            {
                return HttpNotFound();
            }

            return View(announce);
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
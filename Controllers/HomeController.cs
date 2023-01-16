using JobsOffers.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
       
        public ActionResult Index()
        {
            var list = db.Catrgories.ToList();
            return View(list);
        }
        public ActionResult Details(int JobId)
        {
            var job = db.Jobs.Find(JobId);
            if(job==null)
            {
                return HttpNotFound();
            }
            Session["JobId"] = JobId;
            return View(job);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Apply()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Apply(string Message)
        {
            var userid = User.Identity.GetUserId();
            var JobId = (int)Session["JobId"];

            var check = db.ApplyForJobs.Where(a => a.JopId == JobId && a.UserId == userid).ToList();

            if(check.Count < 1)
            {
            var job = new ApplyForJob();
            job.UserId = userid;
            job.JopId = JobId;
            job.Message = Message;
            job.ApplyDate = DateTime.Now;

            db.ApplyForJobs.Add(job);
            db.SaveChanges();
                ViewBag.Result = "تمت الأضافه بنجاح";
            }
            else
            {
                ViewBag.Result = "المعذرة لقد سبق وتقدمت الى نفس الوظيفة";
            }
         

            return View();
        }
        [HttpGet]
        [Authorize]
        public ActionResult GetJopsByUser()
        {
            var userId = User.Identity.GetUserId();

            var jobs = db.ApplyForJobs.Where(a => a.UserId == userId);
            return View(jobs.ToList());
        }

       public ActionResult DetailsOfJob(int id)
        {
            var job = db.ApplyForJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize]
        public ActionResult GetJobsByPublisher()
        {
            var UserID = User.Identity.GetUserId();
            var Jobs = from app in db.ApplyForJobs
                       join job in db.Jobs on app.JopId equals job.Id
                       where job.User.Id == UserID
                       select app;

            return View(Jobs.ToList());

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DendrochronologyReferenceBook.Models;
using PagedList;

namespace DendrochronologyReferenceBook.Controllers
{
    public class HomeController : Controller
    {

        private List<Measurement> Measurements;

        public HomeController()
        {
            Measurements = new List<Measurement>();
            Measurements.Add(new Measurement {Id = 1, UploadDate = DateTime.Today });
            Measurements.Add(new Measurement { Id = 2, UploadDate = DateTime.Today });
            Measurements.Add(new Measurement { Id = 3, UploadDate = DateTime.Today });

        }


        


        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(Measurements.ToPagedList(pageNumber, pageSize));
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
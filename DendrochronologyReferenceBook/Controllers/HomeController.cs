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
        private Specie CommonLarch;
        private Specie Cedar;
        private Specie CommonBirch;
        private ApplicationUser Sviderskaya;

        public HomeController()
        {
            CommonLarch = new Specie {Id = 1, Name = "Лиственница обыкновенная"};
            Cedar = new Specie {Id = 2, Name = "Кедр"};
            CommonBirch = new Specie {Id = 3, Name ="Берёза белая"};

            Sviderskaya = new ApplicationUser {Id = "1", UserName = "Свидерская Ирина Викторовна" };



            Measurements = new List<Measurement>();

            Measurements.Add(new Measurement {Id = 1, UploadDate = DateTime.Today, Specie = CommonLarch, User = Sviderskaya, SamplingYear = 1960});
            Measurements.Add(new Measurement { Id = 2, UploadDate = DateTime.Today, Specie = CommonLarch, User = Sviderskaya, SamplingYear = 1960 });
            Measurements.Add(new Measurement { Id = 3, UploadDate = DateTime.Today, Specie = Cedar, User = Sviderskaya, SamplingYear = 1965 });
            Measurements.Add(new Measurement { Id = 4, UploadDate = DateTime.Today, Specie = CommonBirch, User = Sviderskaya, SamplingYear = 1980 });
            Measurements.Add(new Measurement { Id = 5, UploadDate = DateTime.Today, Specie = CommonBirch, User = Sviderskaya, SamplingYear = 1980 });
            Measurements.Add(new Measurement { Id = 6, UploadDate = DateTime.Today, Specie = CommonLarch, User = Sviderskaya, SamplingYear = 1960 });
            Measurements.Add(new Measurement { Id = 7, UploadDate = DateTime.Today, Specie = Cedar, User = Sviderskaya, SamplingYear = 1965 });
            Measurements.Add(new Measurement { Id = 8, UploadDate = DateTime.Today, Specie = Cedar, User = Sviderskaya, SamplingYear = 1965 });
            Measurements.Add(new Measurement { Id = 9, UploadDate = DateTime.Today, Specie = Cedar, User = Sviderskaya, SamplingYear = 1980 });
            Measurements.Add(new Measurement { Id = 10, UploadDate = DateTime.Today, Specie = CommonBirch, User = Sviderskaya, SamplingYear = 1980 });
            Measurements.Add(new Measurement { Id = 11, UploadDate = DateTime.Today, Specie = CommonBirch, User = Sviderskaya, SamplingYear = 1980 });
            Measurements.Add(new Measurement { Id = 12, UploadDate = DateTime.Today, Specie = CommonBirch, User = Sviderskaya, SamplingYear = 1980 });

        }


        


        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Index(int? page)
        {
            int pageSize = 5;
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
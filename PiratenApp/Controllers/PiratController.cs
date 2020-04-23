using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiratenApp.Models;
using PiratenApp.Models.Viewmodels;
using PiratenApp.Repositories;

namespace PiratenApp.Controllers
{
    public class PiratController : Controller
    {
        private IPiratRepository PiratRepo;
        private ISchiffRepository SchiffRepo;
        private IPiratSchiffRepository PiratSchiffRepo;
        private IWebHostEnvironment env;

        public PiratController(IPiratRepository PiratRepo, 
                               ISchiffRepository SchiffRepo,
                               IPiratSchiffRepository PiratSchiffRepo,
                               IWebHostEnvironment env)
        {
            this.PiratRepo = PiratRepo;
            this.SchiffRepo = SchiffRepo;
            this.PiratSchiffRepo = PiratSchiffRepo;
            this.env = env;
        }

        public IActionResult Index()
        {
            // Übersicht verbergen wenn die Piratencollection leer ist
            ViewBag.ShowAll = PiratRepo.Piraten.Count() != 0 ? "filled" : "zero";
            return View();
        }



        [HttpGet]
        public IActionResult InputForm()
        {
            PiratIndexViewModel temp = new PiratIndexViewModel
            {
                Pirat = new Pirat(),
                Schiffe = SchiffRepo.Schiffe
            };

            return View(temp);
        }


        [HttpPost]
        public IActionResult InputForm(PiratIndexViewModel piratIndex, IFormFile file = null, IEnumerable<string> Schiffe = null)
        {
            string motivFileName = "";

            if (file != null)
            {
                var dir = env.WebRootPath + @"\Upload\Images";

                motivFileName = (Guid.NewGuid().ToString() + ".jpg");

                using (var fileStream = new FileStream(Path.Combine(dir, motivFileName), FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fileStream);
                }
            }
            else
            {
                motivFileName = "default.jpg";
            }

            piratIndex.Pirat.Motiv = motivFileName;



            // Schiffe aus dem Repository nach Namen ausgelesen 
            IEnumerable<Schiff> tempSchiffe = ( (SchiffRepository) SchiffRepo ).GetSchiffeByName(Schiffe);


            tempSchiffe.ToList().ForEach(schiff => {

                PiratSchiff piratSchiffe = new PiratSchiff();

                piratSchiffe.Pirat = piratIndex.Pirat;

                piratSchiffe.Schiff = schiff;

                PiratSchiffRepo.savePiratSchiff( piratSchiffe );

            });
            
            return RedirectToAction(nameof(Index)); 
        }


        public IActionResult ShowAll()
        {
            IEnumerable<Pirat> temp = PiratRepo.Piraten;
            
            return View(temp);
        }


        
    }








    //public class PiratController : Controller
    //{
    //    private IPiratRepository PiratRepo;
    //    private ISchiffRepository SchiffRepo;
    //    private IWebHostEnvironment env;

    //    public PiratController(IPiratRepository PiratRepo, ISchiffRepository SchiffRepo, IWebHostEnvironment env)
    //    {
    //        this.PiratRepo = PiratRepo;
    //        this.SchiffRepo = SchiffRepo;
    //        this.env = env;
    //    }

    //    public IActionResult Index()
    //    {
    //        // Übersicht verbergen wenn die Piratencollection leer ist
    //        ViewBag.ShowAll = PiratRepo.Piraten.Count() != 0 ? "filled" : "zero";
    //        return View();
    //    }



    //    [HttpGet]
    //    public IActionResult InputForm()
    //    {
    //        PiratIndexViewModel temp = new PiratIndexViewModel
    //        {
    //            Pirat = new Pirat(),
    //            Schiffe = SchiffRepo.Schiffe
    //        };

    //        return View(temp);
    //    }

    //    [HttpPost]
    //    public IActionResult InputForm(PiratIndexViewModel piratIndex, IFormFile file = null, IEnumerable<string> Schiffe = null)
    //    {
    //        string motivFileName = "";

    //        if (file != null)
    //        {
    //            var dir = env.WebRootPath + @"\Upload\Images";

    //            motivFileName = (Guid.NewGuid().ToString() + ".jpg");

    //            using (var fileStream = new FileStream(Path.Combine(dir, motivFileName), FileMode.Create, FileAccess.Write))
    //            {
    //                file.CopyTo(fileStream);
    //            }
    //        }
    //        else
    //        {
    //            motivFileName = "default.jpg";
    //        }

    //        piratIndex.Pirat.Motiv = motivFileName;



    //        // Schiffe aus dem Repository nach Namen ausgelesen 
    //        IEnumerable<Schiff> tempSchiffe = ((Schiffrepository)SchiffRepo).GetSchiffeByName(Schiffe);

    //        tempSchiffe.ToList().ForEach(schiff => {

    //            piratIndex.Pirat.PiratSchiff.Add(new PiratSchiff
    //            {
    //                Schiff = new Schiff { SchiffName = "pizda" },
    //                Pirat = piratIndex.Pirat
    //            });
    //        });




    //        PiratRepo.savePirat(piratIndex.Pirat);

    //        //tempSchiffe.ToList().ForEach(schiff => {
    //        //    SchiffRepo.saveSchiff(schiff);
    //        //});

    //        return RedirectToAction(nameof(Index)); ;
    //    }


    //    public IActionResult ShowAll()
    //    {
    //        IEnumerable<Pirat> temp = PiratRepo.Piraten;

    //        return View(temp);
    //    }
    //}


}
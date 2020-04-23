using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PiratenApp.Models;
using PiratenApp.Repositories;

namespace PiratenApp.Controllers
{
    public class SchiffController : Controller
    {


        private ISchiffRepository SchiffRepo;
        public SchiffController(ISchiffRepository SchiffRepo)
        {
            this.SchiffRepo = SchiffRepo;
        }


        public IActionResult SchiffeForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SchiffeInput(Schiff schiff)
        {
            SchiffRepo.saveSchiff(schiff);

            return RedirectToAction( "Index", "Pirat" ) ;
        }

    }
}
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MpumalangaHealth.Controllers
{
    public class FacilitiesController : Controller
    {
        public IActionResult Index()
        {
            // We'll start with sample data, then connect to database later
            var facilities = new List<Facility>
            {
                new Facility { Id = 1, Name = "Rob Ferreira Hospital", Type = "Hospital", District = "Ehlanzeni", Phone = "013 759 0300", Address = "1 Ferreira St, Mbombela" },
                new Facility { Id = 2, Name = "Embhuleni Hospital", Type = "Hospital", District = "Gert Sibande", Phone = "017 883 1102", Address = "Elukwatini, 1192" },
                new Facility { Id = 3, Name = "Witbank Hospital", Type = "Hospital", District = "Nkangala", Phone = "013 690 3000", Address = "Corner Kerk & Hofmeyer St, Witbank" },
                new Facility { Id = 4, Name = "Matsulu Clinic", Type = "Clinic", District = "Ehlanzeni", Phone = "013 790 2018", Address = "Matsulu, Mbombela" },
                new Facility { Id = 5, Name = "Ermelo Hospital", Type = "Hospital", District = "Gert Sibande", Phone = "017 811 1775", Address = "De Clercq St, Ermelo" }
            };

            return View(facilities);
        }

        public IActionResult Details(int id)
        {
            // For now, return a simple view - we'll add real data later
            return View();
        }
    }

    // Temporary model class - we'll create proper models later
    public class Facility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string District { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
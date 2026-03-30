using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MpumalangaHealth.Controllers
{
    public class FacilitiesController : Controller
    {
        // Sample data - only hospitals
        private static List<Facility> _hospitals = new List<Facility>
        {
            new Facility
            {
                Id = 1,
                Name = "Rob Ferreira Hospital",
                Type = "Hospital",
                District = "Ehlanzeni",
                Phone = "013 759 0300",
                Address = "1 Ferreira St, Mbombela",
                Latitude = -25.4667,
                Longitude = 30.9833,
                VisitingHours = "15:00 - 16:00",
                EmergencyContact = "013 759 0300",
                Email = "robferreira@mpuhealth.gov.za",
                Website = "www.robferreira.mpuhealth.gov.za",
                OperatingHours = "24/7",
                Beds = 450,
                Specialties = new List<string> { "Cardiology", "Pediatrics", "Orthopedics", "Radiology" }
            },
            new Facility
            {
                Id = 2,
                Name = "Embhuleni Hospital",
                Type = "Hospital",
                District = "Gert Sibande",
                Phone = "017 883 1102",
                Address = "Elukwatini, 1192",
                Latitude = -26.1842,
                Longitude = 30.5186,
                VisitingHours = "14:00 - 15:30",
                EmergencyContact = "017 883 1102",
                Email = "embhuleni@mpuhealth.gov.za",
                OperatingHours = "24/7",
                Beds = 200,
                Specialties = new List<string> { "General Medicine", "Pediatrics" }
            },
            new Facility
            {
                Id = 3,
                Name = "Witbank Hospital",
                Type = "Hospital",
                District = "Nkangala",
                Phone = "013 690 3000",
                Address = "Corner Kerk & Hofmeyer St, Witbank",
                Latitude = -25.8714,
                Longitude = 29.2333,
                VisitingHours = "15:00 - 16:30",
                EmergencyContact = "013 690 3000",
                Email = "witbank@mpuhealth.gov.za",
                OperatingHours = "24/7",
                Beds = 380,
                Specialties = new List<string> { "Cardiology", "Orthopedics", "Neurology" }
            },
            new Facility
            {
                Id = 5,
                Name = "Ermelo Hospital",
                Type = "Hospital",
                District = "Gert Sibande",
                Phone = "017 811 1775",
                Address = "De Clercq St, Ermelo",
                Latitude = -26.5233,
                Longitude = 29.9833,
                VisitingHours = "14:30 - 16:00",
                EmergencyContact = "017 811 1775",
                Email = "ermelo@mpuhealth.gov.za",
                OperatingHours = "24/7",
                Beds = 280,
                Specialties = new List<string> { "General Medicine", "Surgery", "Pediatrics" }
            },
            new Facility
            {
                Id = 6,
                Name = "Barberton Hospital",
                Type = "Hospital",
                District = "Ehlanzeni",
                Phone = "013 712 2000",
                Address = "8th Avenue, Barberton",
                Latitude = -25.7833,
                Longitude = 31.05,
                VisitingHours = "15:00 - 16:00",
                EmergencyContact = "013 712 2000",
                Email = "barberton@mpuhealth.gov.za",
                OperatingHours = "24/7",
                Beds = 180,
                Specialties = new List<string> { "General Medicine", "Obstetrics" }
            },
            new Facility
            {
                Id = 8,
                Name = "Standerton Hospital",
                Type = "Hospital",
                District = "Gert Sibande",
                Phone = "017 712 4100",
                Address = "Hospital Road, Standerton",
                Latitude = -26.95,
                Longitude = 29.25,
                VisitingHours = "15:00 - 16:30",
                EmergencyContact = "017 712 4100",
                Email = "standerton@mpuhealth.gov.za",
                OperatingHours = "24/7",
                Beds = 320,
                Specialties = new List<string> { "General Medicine", "Surgery", "Orthopedics" }
            }
        };

        public IActionResult Index(string search = "", string district = "")
        {
            var hospitals = _hospitals.AsQueryable();

            // Apply filters
            if (!string.IsNullOrEmpty(search))
            {
                hospitals = hospitals.Where(h =>
                    h.Name.ToLower().Contains(search.ToLower()) ||
                    h.Address.ToLower().Contains(search.ToLower()));
            }

            if (!string.IsNullOrEmpty(district) && district != "All")
            {
                hospitals = hospitals.Where(h => h.District == district);
            }

            // Pass filter values to view
            ViewBag.CurrentSearch = search;
            ViewBag.CurrentDistrict = district;
            ViewBag.TotalHospitals = _hospitals.Count();

            return View(hospitals.ToList());
        }

        public IActionResult Details(int id)
        {
            var hospital = _hospitals.FirstOrDefault(h => h.Id == id);
            if (hospital == null)
            {
                return NotFound();
            }

            // Get nearby hospitals in same district
            ViewBag.NearbyHospitals = _hospitals
                .Where(h => h.District == hospital.District && h.Id != hospital.Id)
                .Take(3)
                .ToList();

            return View(hospital);
        }
    }

    public class Facility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string District { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string VisitingHours { get; set; }
        public string EmergencyContact { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string OperatingHours { get; set; }
        public int Beds { get; set; }
        public List<string> Specialties { get; set; } = new List<string>();
    }
}
using Microsoft.AspNetCore.Mvc;
using MpumalangaHealth.Models;
using System.Collections.Generic;
using System.Linq;

namespace MpumalangaHealth.Controllers
{
    public class CareersController : Controller
    {
        // Sample data - we'll replace with database later
        private static List<JobVacancy> _jobVacancies = new List<JobVacancy>
        {
            new JobVacancy {
                Id = 1,
                Title = "Professional Nurse",
                Department = "Nursing Services",
                Location = "Rob Ferreira Hospital, Mbombela",
                Description = "We are seeking dedicated Professional Nurses to join our healthcare team.",
                Requirements = "• Diploma/Degree in Nursing\n• Registration with SANC\n• 2+ years experience\n• BLS certification",
                Responsibilities = "• Provide comprehensive nursing care\n• Administer medications\n• Monitor patient progress\n• Maintain patient records",
                SalaryRange = "R25,000 - R35,000 per month",
                EmploymentType = "Full-time",
                ClosingDate = DateTime.Now.AddDays(21),
                PostedDate = DateTime.Now.AddDays(-2),
                ReferenceNumber = "MDoH/NUR/2024/001",
                IsFeatured = true
            },
            new JobVacancy {
                Id = 2,
                Title = "Medical Doctor",
                Department = "Medical Services",
                Location = "Witbank Hospital, Witbank",
                Description = "Medical Doctor needed for our busy hospital department.",
                Requirements = "• MBChB degree\n• HPCSA registration\n• 3+ years clinical experience\n• Community service completed",
                Responsibilities = "• Diagnose and treat patients\n• Perform medical procedures\n• Supervise junior staff\n• Participate in ward rounds",
                SalaryRange = "R45,000 - R65,000 per month",
                EmploymentType = "Full-time",
                ClosingDate = DateTime.Now.AddDays(14),
                PostedDate = DateTime.Now.AddDays(-5),
                ReferenceNumber = "MDoH/MED/2024/002",
                IsFeatured = true
            },
            new JobVacancy {
                Id = 3,
                Title = "Administrative Clerk",
                Department = "Hospital Administration",
                Location = "Ermelo Hospital, Ermelo",
                Description = "Administrative professional needed for hospital records department.",
                Requirements = "• Matric certificate\n• Office Administration diploma\n• Computer literacy\n• 1+ years admin experience",
                Responsibilities = "• Manage patient records\n• Handle correspondence\n• Schedule appointments\n• Data capturing",
                SalaryRange = "R12,000 - R18,000 per month",
                EmploymentType = "Full-time",
                ClosingDate = DateTime.Now.AddDays(30),
                PostedDate = DateTime.Now.AddDays(-1),
                ReferenceNumber = "MDoH/ADM/2024/003",
                IsFeatured = false
            },
            new JobVacancy {
                Id = 4,
                Title = "Pharmacist Assistant",
                Department = "Pharmacy Services",
                Location = "Various Clinics, Gert Sibande District",
                Description = "Join our pharmacy team to support medication distribution.",
                Requirements = "• Grade 12\n• Pharmacist Assistant qualification\n• Registered with SAPC\n• Attention to detail",
                Responsibilities = "• Assist pharmacist with dispensing\n• Manage stock levels\n• Handle patient queries\n• Maintain pharmacy cleanliness",
                SalaryRange = "R15,000 - R22,000 per month",
                EmploymentType = "Full-time",
                ClosingDate = DateTime.Now.AddDays(7),
                PostedDate = DateTime.Now.AddDays(-3),
                ReferenceNumber = "MDoH/PHA/2024/004",
                IsFeatured = false
            }
        };

        public IActionResult Index()
        {
            var activeJobs = _jobVacancies
                .Where(j => j.ClosingDate >= DateTime.Now)
                .OrderByDescending(j => j.PostedDate)
                .ToList();
            return View(activeJobs);
        }

        public IActionResult Details(int id)
        {
            var job = _jobVacancies.FirstOrDefault(j => j.Id == id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

        public IActionResult Application(int id)
        {
            var job = _jobVacancies.FirstOrDefault(j => j.Id == id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

        [HttpPost]
        public IActionResult SubmitApplication()
        {
            // For now, we'll just show a success message
            // In a real application, we would process the form data here
            TempData["SuccessMessage"] = "Your application has been submitted successfully!";
            return RedirectToAction("Index");
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using MpumalangaHealth.Models;
using System.Collections.Generic;
using System.Linq;

namespace MpumalangaHealth.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            var categories = new List<ServiceCategory>
            {
                new ServiceCategory {
                    Name = "Primary Health Care",
                    Description = "Basic healthcare services at clinics and community health centers",
                    ServiceCount = 8,
                    Icon = "fas fa-stethoscope"
                },
                new ServiceCategory {
                    Name = "Hospital Services",
                    Description = "Comprehensive medical care at provincial hospitals",
                    ServiceCount = 6,
                    Icon = "fas fa-hospital"
                },
                new ServiceCategory {
                    Name = "Emergency Services",
                    Description = "24/7 emergency medical care and ambulance services",
                    ServiceCount = 4,
                    Icon = "fas fa-ambulance"
                },
                new ServiceCategory {
                    Name = "Maternal & Child Health",
                    Description = "Healthcare services for mothers, infants, and children",
                    ServiceCount = 5,
                    Icon = "fas fa-baby"
                },
                new ServiceCategory {
                    Name = "Chronic Diseases",
                    Description = "Management and treatment of long-term health conditions",
                    ServiceCount = 6,
                    Icon = "fas fa-heartbeat"
                },
                new ServiceCategory {
                    Name = "Specialized Programs",
                    Description = "Targeted health programs and initiatives",
                    ServiceCount = 7,
                    Icon = "fas fa-clipboard-list"
                }
            };

            return View(categories);
        }

        public IActionResult Category(string category)
        {
            var services = GetHealthServices().Where(s => s.Category == category).ToList();
            ViewBag.Category = category;
            return View(services);
        }

        public IActionResult Details(int id)
        {
            var service = GetHealthServices().FirstOrDefault(s => s.Id == id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        public IActionResult Programs()
        {
            var programs = new List<HealthProgram>
            {
                new HealthProgram {
                    Id = 1,
                    Name = "HIV/AIDS Prevention & Treatment",
                    Description = "Comprehensive HIV prevention, testing, and treatment services",
                    Objectives = "• Reduce new HIV infections\n• Improve treatment adherence\n• Eliminate mother-to-child transmission\n• Reduce stigma and discrimination",
                    TargetGroup = "General population, pregnant women, key populations",
                    ServicesProvided = "• HIV testing and counseling\n• Antiretroviral therapy\n• Prevention of mother-to-child transmission\n• Post-exposure prophylaxis\n• Support groups",
                    ContactInfo = "HIV/AIDS Program Unit - 013 766 3250",
                    ProgramDuration = "Ongoing",
                    IsActive = true
                },
                new HealthProgram {
                    Id = 2,
                    Name = "TB Control Program",
                    Description = "Tuberculosis prevention, diagnosis, and treatment services",
                    Objectives = "• Increase TB case detection\n• Improve treatment success rates\n• Reduce TB mortality\n• Prevent drug-resistant TB",
                    TargetGroup = "TB patients, contacts, high-risk groups",
                    ServicesProvided = "• TB screening and diagnosis\n• Directly Observed Treatment (DOT)\n• Contact tracing\n• Drug-resistant TB management\n• Health education",
                    ContactInfo = "TB Program Unit - 013 766 3255",
                    ProgramDuration = "Ongoing",
                    IsActive = true
                },
                new HealthProgram {
                    Id = 3,
                    Name = "Expanded Program on Immunization",
                    Description = "Childhood and adult immunization services",
                    Objectives = "• Achieve 95% immunization coverage\n• Eliminate vaccine-preventable diseases\n• Maintain polio-free status\n• Introduce new vaccines",
                    TargetGroup = "Children 0-12 years, pregnant women, high-risk adults",
                    ServicesProvided = "• Routine childhood immunization\n• School-based vaccination\n• Travel vaccinations\n• Outbreak response vaccination\n• Vaccine safety monitoring",
                    ContactInfo = "EPI Unit - 013 766 3260",
                    ProgramDuration = "Ongoing",
                    IsActive = true
                },
                new HealthProgram {
                    Id = 4,
                    Name = "Integrated Management of Childhood Illnesses",
                    Description = "Comprehensive approach to childhood illness management",
                    Objectives = "• Reduce child mortality\n• Improve quality of care for children\n• Strengthen health systems\n• Promote child development",
                    TargetGroup = "Children under 5 years",
                    ServicesProvided = "• Assessment and classification\n• Treatment guidance\n• Counseling for caregivers\n• Follow-up care\n• Referral services",
                    ContactInfo = "Child Health Unit - 013 766 3265",
                    ProgramDuration = "Ongoing",
                    IsActive = true
                }
            };

            return View(programs);
        }

        public IActionResult Emergency()
        {
            return View();
        }

        private List<HealthService> GetHealthServices()
        {
            return new List<HealthService>
            {
                // Primary Health Care Services
                new HealthService {
                    Id = 1,
                    Name = "General Medical Consultations",
                    Description = "Comprehensive medical consultations and treatment for common illnesses",
                    DetailedDescription = "Our clinics provide general medical consultations for common illnesses and minor injuries. Services include diagnosis, treatment, prescription of medication, and referrals to specialists when needed.",
                    Category = "Primary Health Care",
                    Icon = "fas fa-user-md",
                    ImageUrl = "/images/services/general-consultation.jpg",
                    ServicesIncluded = new List<string> {
                        "Medical diagnosis and treatment",
                        "Prescription of medication",
                        "Minor wound care",
                        "Chronic medication management",
                        "Referral to specialists"
                    },
                    TargetAudience = "All age groups",
                    ContactDepartment = "Primary Health Care - 013 766 3200",
                    Eligibility = "Available to all residents",
                    IsFeatured = true
                },
                new HealthService {
                    Id = 2,
                    Name = "Chronic Disease Management",
                    Description = "Ongoing care and management for chronic health conditions",
                    DetailedDescription = "We provide comprehensive management for chronic diseases including hypertension, diabetes, asthma, and epilepsy. Patients receive regular monitoring, medication, and lifestyle counseling.",
                    Category = "Primary Health Care",
                    Icon = "fas fa-heartbeat",
                    ImageUrl = "/images/services/chronic-care.jpg",
                    ServicesIncluded = new List<string> {
                        "Regular health monitoring",
                        "Chronic medication supply",
                        "Lifestyle counseling",
                        "Complication screening",
                        "Support group referrals"
                    },
                    TargetAudience = "Patients with chronic conditions",
                    ContactDepartment = "Chronic Care Unit - 013 766 3210",
                    Eligibility = "Diagnosed with chronic condition",
                    IsFeatured = false
                },
                new HealthService {
                    Id = 3,
                    Name = "Family Planning Services",
                    Description = "Comprehensive reproductive health and family planning services",
                    DetailedDescription = "We offer a range of family planning methods and reproductive health services to help individuals and couples make informed choices about their reproductive health.",
                    Category = "Primary Health Care",
                    Icon = "fas fa-venus-mars",
                    ImageUrl = "/images/services/family-planning.jpg",
                    ServicesIncluded = new List<string> {
                        "Contraceptive counseling",
                        "Various contraceptive methods",
                        "Pregnancy testing",
                        "Reproductive health education",
                        "STI screening and prevention"
                    },
                    TargetAudience = "Reproductive age individuals",
                    ContactDepartment = "Reproductive Health - 013 766 3220",
                    Eligibility = "Available to all reproductive age individuals",
                    IsFeatured = true
                },

                // Hospital Services
                new HealthService {
                    Id = 4,
                    Name = "Surgical Services",
                    Description = "Comprehensive surgical care including emergency and elective procedures",
                    DetailedDescription = "Our hospitals provide a wide range of surgical services from minor procedures to major operations. We have specialized surgical units including general surgery, orthopedics, and gynecology.",
                    Category = "Hospital Services",
                    Icon = "fas fa-procedures",
                    ImageUrl = "/images/services/surgical.jpg",
                    ServicesIncluded = new List<string> {
                        "Emergency surgery",
                        "Elective procedures",
                        "Minimally invasive surgery",
                        "Post-operative care",
                        "Surgical follow-up"
                    },
                    TargetAudience = "Patients requiring surgical intervention",
                    ContactDepartment = "Surgical Department - 013 766 3300",
                    Eligibility = "Referred by medical practitioner",
                    IsFeatured = true
                },
                new HealthService {
                    Id = 5,
                    Name = "Maternity Services",
                    Description = "Comprehensive care for pregnant women and new mothers",
                    DetailedDescription = "We provide complete maternity care from antenatal to postnatal services. Our facilities are equipped to handle normal deliveries and have emergency obstetric care capabilities.",
                    Category = "Hospital Services",
                    Icon = "fas fa-baby-carriage",
                    ImageUrl = "/images/services/maternity.jpg",
                    ServicesIncluded = new List<string> {
                        "Antenatal care",
                        "Labor and delivery",
                        "Postnatal care",
                        "Caesarean sections",
                        "Newborn care"
                    },
                    TargetAudience = "Pregnant women and new mothers",
                    ContactDepartment = "Maternity Unit - 013 766 3310",
                    Eligibility = "Pregnant women",
                    IsFeatured = true
                },

                // Emergency Services
                new HealthService {
                    Id = 6,
                    Name = "Emergency Medical Services",
                    Description = "24/7 emergency care and ambulance services",
                    DetailedDescription = "Our emergency departments provide immediate medical care for life-threatening conditions. We operate 24/7 with trained emergency medical personnel and advanced equipment.",
                    Category = "Emergency Services",
                    Icon = "fas fa-ambulance",
                    ImageUrl = "/images/services/emergency.jpg",
                    ServicesIncluded = new List<string> {
                        "Emergency triage",
                        "Critical care",
                        "Ambulance services",
                        "Trauma care",
                        "Emergency surgery"
                    },
                    TargetAudience = "Patients with emergency conditions",
                    ContactDepartment = "Emergency Unit - 013 766 3350",
                    Eligibility = "Medical emergencies only",
                    IsFeatured = true
                },

                // Maternal & Child Health
                new HealthService {
                    Id = 7,
                    Name = "Child Health Services",
                    Description = "Comprehensive healthcare services for children from birth to adolescence",
                    DetailedDescription = "We provide specialized healthcare services for children including growth monitoring, immunization, and management of childhood illnesses. Our child-friendly facilities ensure comfort and quality care.",
                    Category = "Maternal & Child Health",
                    Icon = "fas fa-child",
                    ImageUrl = "/images/services/child-health.jpg",
                    ServicesIncluded = new List<string> {
                        "Growth monitoring",
                        "Childhood immunization",
                        "Nutritional assessment",
                        "Developmental screening",
                        "School health services"
                    },
                    TargetAudience = "Children 0-18 years",
                    ContactDepartment = "Child Health - 013 766 3400",
                    Eligibility = "All children",
                    IsFeatured = false
                },

                // Specialized Programs
                new HealthService {
                    Id = 8,
                    Name = "Mental Health Services",
                    Description = "Comprehensive mental health care and psychological support",
                    DetailedDescription = "We provide mental health services including assessment, counseling, and treatment for various mental health conditions. Our services range from outpatient care to specialized inpatient treatment.",
                    Category = "Specialized Programs",
                    Icon = "fas fa-brain",
                    ImageUrl = "/images/services/mental-health.jpg",
                    ServicesIncluded = new List<string> {
                        "Psychological assessment",
                        "Individual counseling",
                        "Group therapy",
                        "Psychiatric medication",
                        "Crisis intervention"
                    },
                    TargetAudience = "Individuals with mental health needs",
                    ContactDepartment = "Mental Health Unit - 013 766 3450",
                    Eligibility = "Referred by healthcare provider",
                    IsFeatured = false
                }
            };
        }
    }
}
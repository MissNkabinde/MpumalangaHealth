using Microsoft.AspNetCore.Mvc;
using MpumalangaHealth.Models;
using System.Collections.Generic;
using System.Linq;

namespace MpumalangaHealth.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VisionMission()
        {
            var structure = new OrganizationalStructure
            {
                DepartmentName = "Mpumalanga Department of Health",
                Vision = "A long and healthy life for all people in Mpumalanga.",
                Mission = "To provide accessible, equitable, and quality health care services to the people of Mpumalanga through a caring and professional workforce, in collaboration with our partners.",
                Values = "• Caring\n• Compassion\n• Competence\n• Accountability\n• Integrity\n• Transparency\n• Equity",
                History = "The Mpumalanga Department of Health was established to coordinate and deliver healthcare services across the province. Over the years, we have expanded our services to reach even the most remote communities, ensuring that every citizen has access to quality healthcare.",
                Mandate = "The Department's mandate is derived from the Constitution of the Republic of South Africa, which assigns provincial governments the responsibility for health services. We are committed to implementing national health policies while addressing the unique needs of Mpumalanga's diverse population."
            };

            return View(structure);
        }

        public IActionResult Management()
        {
            var managementTeam = new List<ManagementTeam>
            {

                new ManagementTeam {
    Id = 1,
    Name = "Ms. Sasekani Manzini",
    Position = "Member of the Executive Council (MEC)",
    Department = "Office of the MEC",
    Qualifications = "Information not publicly available",
    Biography = "Ms. Manzini serves as the political head of the Department of Health. She has been vocal about addressing public health crises in the province, including teenage pregnancy and social determinants of health. In early 2026, she announced stricter legal measures to combat statutory rape and intensified inter-departmental cooperation to keep young mothers in school [citation:1].",
    Email = "prettyd@mpuhealth.gov.za",
    Phone = "013 766 3754",
    PhotoUrl = "/images/management/mec.jpg",
    Order = 1
},
                new ManagementTeam {
    Id = 2,
    Name = "Dr. Lucas K. Ndhlovu",
    Position = "Head of Department (HOD)",
    Department = "Office of the HOD",
    Qualifications = "MBChB (MEDUNSA), BSc Hons, LLB, Master's in Business Leadership",
    Biography = "Dr. Ndhlovu was appointed as the Head of Department in April 2023. He is a seasoned health professional with extensive experience in clinical management and hospital administration. Prior to this role, he served as CEO of Dr. George Mukhari Academic Hospital in Pretoria, managing a staff compliment of over 5,200 employees and a budget of R3.6 billion. He has also held senior clinical manager positions at Mapulaneng Hospital, Kwa-Mhlanga Hospital, Witbank Hospital, and Themba Hospital [citation:4].",
    Email = "pauleckm@mpuhealth.gov.za",
    Phone = "013 766 3031",
    PhotoUrl = "/images/management/hod.jpg",
    Order = 2
},
                new ManagementTeam {
    Id = 3,
    Name = "Mr. P. Makhubela",
    Position = "Office Manager",
    Department = "Office of the Head of Department",
    Qualifications = "Information not publicly available",
    Biography = "Mr. Makhubela serves as the Office Manager in the HOD's office, facilitating administrative coordination and supporting the office's daily operations [citation:2].",
    Email = "pauleckm@mpuhealth.gov.za",
    Phone = "013 766 3031",
    PhotoUrl = "/images/management/office-manager.jpg",
    Order = 3
},
                new ManagementTeam {
    Id = 4,
    Name = "Dr. Cheryl Nelson",
    Position = "Chief Director: Primary Health Care",
    Department = "Primary Health Care",
    Qualifications = "Information not publicly available",
    Biography = "Dr. Nelson currently serves as the Chief Director for Primary Health Care. She has been with the department for an extended period and in late 2024, she led the farewell ceremony for a retiring official, where she praised the legacy of commitment and work ethic within the primary health care sphere [citation:3].",
    Email = "Information not publicly available",
    Phone = "Information not publicly available",
    PhotoUrl = "/images/management/chief-director-phc.jpg",
    Order = 4
},
                new ManagementTeam {
    Id = 5,
    Name = "Ms. Dudu Mdluli",
    Position = "Deputy Director General: Clinical Services",
    Department = "Clinical Services",
    Qualifications = "Information not publicly available",
    Biography = "Ms. Mdluli was appointed as the Deputy Director General for Clinical Services in August 2021 [citation:5]. Her appointment came at a critical time during the province's fight against the COVID-19 pandemic, where she was expected to provide capacity for the inoculation programme [citation:5]. She continues to lead clinical services, and in July 2024, she was speaking at the Provincial Paediatrics Awards ceremony, commending facilities for their work in HIV/AIDS care and encouraging them to achieve the 95-95-95 treatment targets [citation:1]. She has also led the department's public participation processes regarding the National Health Insurance (NHI) Bill [citation:3].",
    Email = "Information not publicly available",
    Phone = "Information not publicly available",
    PhotoUrl = "/images/management/ddg-clinical.jpg",
    Order = 5
},
                new ManagementTeam {
                    Id = 6,
                    Name = "Dr. M. P. Williams",
                    Position = "Chief Director: Health Programs",
                    Department = "Health Programs",
                    Qualifications = "MBChB, MPH, PhD Epidemiology",
                    Biography = "Dr. Williams leads the department's specialized health programs including HIV/AIDS, TB, Maternal and Child Health. She has published extensively in public health research.",
                    Email = "health.programs@mpuhealth.gov.za",
                    Phone = "013 766 3006",
                    PhotoUrl = "/images/management/programs.jpg",
                    Order = 6
                }
            };

            return View(managementTeam.OrderBy(m => m.Order).ToList());
        }

        public IActionResult Districts()
        {
            var districts = new List<District>
            {
                new District {
                    Id = 1,
                    Name = "Ehlanzeni District",
                    Description = "Ehlanzeni District is the largest and most populous district in Mpumalanga, home to the provincial capital Mbombela. The district features diverse healthcare needs from urban centers to rural communities.",
                    Manager = "Mr. S. J. Maseko",
                    Contact = "013 766 3100",
                    Email = "ehlanzeni.district@mpuhealth.gov.za",
                    Address = "District Offices, Government Boulevard, Mbombela, 1200",
                    FacilitiesCount = 87,
                    MapUrl = "/images/districts/ehlanzeni-map.jpg"
                },
                new District {
                    Id = 2,
                    Name = "Gert Sibande District",
                    Description = "Gert Sibande District covers the southern part of Mpumalanga with major towns including Ermelo, Bethal, and Standerton. The district has a strong focus on agricultural health and mining community healthcare.",
                    Manager = "Dr. A. B. Pretorius",
                    Contact = "017 811 1000",
                    Email = "gertsibande.district@mpuhealth.gov.za",
                    Address = "District Offices, Hospital Street, Ermelo, 2350",
                    FacilitiesCount = 65,
                    MapUrl = "/images/districts/gert-sibande-map.jpg"
                },
                new District {
                    Id = 3,
                    Name = "Nkangala District",
                    Description = "Nkangala District serves the western part of the province including Witbank, Middelburg, and eMalahleni. The district faces unique health challenges related to mining and industrial activities.",
                    Manager = "Ms. D. K. Moloi",
                    Contact = "013 690 2000",
                    Email = "nkangala.district@mpuhealth.gov.za",
                    Address = "District Offices, OR Tambo Street, Witbank, 1035",
                    FacilitiesCount = 72,
                    MapUrl = "/images/districts/nkangala-map.jpg"
                }
            };

            return View(districts);
        }

        public IActionResult Structure()
        {
            // This would typically show an organizational chart
            // For now, we'll return a view with department information
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
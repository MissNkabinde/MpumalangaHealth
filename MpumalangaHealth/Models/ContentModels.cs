using System.ComponentModel.DataAnnotations;

namespace MpumalangaHealth.Models
{
    public class NewsArticles
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; }

        [StringLength(500, ErrorMessage = "Summary cannot exceed 500 characters")]
        public string Summary { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        public DateTime PublishedDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsPublished { get; set; }
        public bool IsEmergency { get; set; }
        public string Author { get; set; }
    }

    public class AdminJobVacancy
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Job title is required")]
        [StringLength(200, ErrorMessage = "Job title cannot exceed 200 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public string Requirements { get; set; }
        public string Responsibilities { get; set; }
        public string SalaryRange { get; set; }
        public string EmploymentType { get; set; }

        [Required(ErrorMessage = "Closing date is required")]
        public DateTime ClosingDate { get; set; }

        public DateTime PostedDate { get; set; }
        public string ReferenceNumber { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsActive { get; set; }
    }

    public class AdminTender
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tender title is required")]
        [StringLength(200, ErrorMessage = "Tender title cannot exceed 200 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Tender number is required")]
        public string TenderNumber { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Budget is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Budget must be a positive value")]
        public decimal Budget { get; set; }

        [Required(ErrorMessage = "Closing date is required")]
        public DateTime ClosingDate { get; set; }

        public DateTime PostedDate { get; set; }
        public string Status { get; set; } // Open, Closed, Awarded
        public string ContactPerson { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string BidRequirements { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsActive { get; set; }
    }

    public class ContentManager
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; }

        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
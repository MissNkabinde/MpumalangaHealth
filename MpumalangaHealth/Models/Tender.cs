using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MpumalangaHealth.Models
{
    public class Tender
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tender Number")]
        public string TenderNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        [Display(Name = "Title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [Display(Name = "Department")]
        public string Department { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Display(Name = "Category")]
        public string Category { get; set; } = string.Empty;

        [Display(Name = "Published Date")]
        [DataType(DataType.DateTime)]
        public DateTime PublishedDate { get; set; } = DateTime.Now;

        [Display(Name = "Closing Date")]
        [DataType(DataType.DateTime)]
        public DateTime ClosingDate { get; set; } = DateTime.Now.AddDays(30);

        [Required]
        [StringLength(20)]
        [Display(Name = "Status")]
        public string Status { get; set; } = "Open";

        [Display(Name = "Budget")]
        [DataType(DataType.Currency)]
        public decimal? Budget { get; set; }

        [StringLength(100)]
        [Display(Name = "Contact Person")]
        public string? ContactPerson { get; set; }

        [StringLength(100)]
        [Display(Name = "Contact Email")]
        [EmailAddress]
        public string? ContactEmail { get; set; }

        [StringLength(20)]
        [Display(Name = "Contact Phone")]
        public string? ContactPhone { get; set; }

        [StringLength(500)]
        [Display(Name = "Document URL")]
        public string? DocumentUrl { get; set; }

        [Display(Name = "Published")]
        public bool IsPublished { get; set; } = true;

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; }

        // REMOVED: IsFeatured, BidRequirements, PostedDate - these don't exist in your database

        // Not mapped properties for display only
        [NotMapped]
        public int DaysRemaining => ClosingDate > DateTime.Now ? (ClosingDate - DateTime.Now).Days : 0;

        [NotMapped]
        public string StatusClass => Status switch
        {
            "Open" => "bg-success",
            "Closing Soon" => "bg-warning text-dark",
            "Closed" => "bg-secondary",
            "Awarded" => "bg-info",
            "Cancelled" => "bg-danger",
            _ => "bg-secondary"
        };

        [NotMapped]
        public bool IsOpen => Status == "Open" || Status == "Closing Soon";
    }
}
// Models/NewsItem.cs
using System;
using System.ComponentModel.DataAnnotations;
// At the top of your controller/cs file
using MpumalangaHealth.Models; // or MpumalangaHealth.Data.Models
using MpumalangaHealth.Data;

namespace MpumalangaHealth.Models
{
    public class NewsItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Summary { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        public DateTime PublishedDate { get; set; } = DateTime.Now;

        public bool IsEmergency { get; set; }

        [StringLength(500)]
        public string? ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }
    }
}
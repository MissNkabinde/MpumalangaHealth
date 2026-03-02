namespace MpumalangaHealth.Models
{
    public class HealthService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DetailedDescription { get; set; }
        public string Category { get; set; } // Primary Care, Hospital Care, Specialized, etc.
        public string Icon { get; set; }
        public string ImageUrl { get; set; }
        public List<string> ServicesIncluded { get; set; }
        public string TargetAudience { get; set; }
        public string ContactDepartment { get; set; }
        public string Eligibility { get; set; }
        public bool IsFeatured { get; set; }
    }

    public class HealthProgram
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Objectives { get; set; }
        public string TargetGroup { get; set; }
        public string ServicesProvided { get; set; }
        public string ContactInfo { get; set; }
        public string ProgramDuration { get; set; }
        public bool IsActive { get; set; }
    }

    public class ServiceCategory
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ServiceCount { get; set; }
        public string Icon { get; set; }
    }
}
namespace MpumalangaHealth.Models
{
    public class JobVacancy
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Responsibilities { get; set; }
        public string SalaryRange { get; set; }
        public string EmploymentType { get; set; } // Full-time, Part-time, Contract
        public DateTime ClosingDate { get; set; }
        public DateTime PostedDate { get; set; }
        public string ReferenceNumber { get; set; }
        public bool IsFeatured { get; set; }
    }
}
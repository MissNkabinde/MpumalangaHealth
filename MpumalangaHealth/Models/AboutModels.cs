namespace MpumalangaHealth.Models
{
    public class OrganizationalStructure
    {
        public string DepartmentName { get; set; }
        public string Vision { get; set; }
        public string Mission { get; set; }
        public string Values { get; set; }
        public string History { get; set; }
        public string Mandate { get; set; }
    }

    public class ManagementTeam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Qualifications { get; set; }
        public string Biography { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhotoUrl { get; set; }
        public int Order { get; set; }
    }

    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manager { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int FacilitiesCount { get; set; }
        public string MapUrl { get; set; }
    }
}
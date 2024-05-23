namespace api.Models
{
    public class LecturerDepDetail
    {
        // Primary key
        public int Id { get; set; } 
        //Foreign Keys
        public string? DepartmentName { get; set; }
        public string? LecturerTC { get; set; }
        public int Hours { get; set; }
        // Navigation Properties
        public LecturerAccount? Lecturer { get; set; }
        public Department? Department { get; set; }
    }
}
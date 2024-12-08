namespace SIS.Application.DTOs.CourseSelection
{
    public class DepartmentInfoDto
    {
        public DateOnly RegistrationDate { get; set; }
        public string? FacultyName { get; set; }
        public string? DepartmentName { get; set; }
        public string? Type { get; set; }
        public string? Language { get; set; }
    }
}
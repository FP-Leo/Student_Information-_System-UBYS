namespace api.DTO.CourseSelection
{
    public class DepartmentInfoDto
    {
        public DateOnly RegistrationDate { get; set; }
        public String? FacultyName { get; set; }
        public String? DepartmentName { get; set; }
        public String? Type { get; set; }
        public String? Language { get; set; }
    }
}
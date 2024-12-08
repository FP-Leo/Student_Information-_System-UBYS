namespace SIS.Application.DTOs.StudentDepDetails
{
    public class StudentAllDepDetails
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public ICollection<DepDetailDto>? Departments { get; set; }
    }
}
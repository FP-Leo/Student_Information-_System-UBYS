namespace api.DTO.StudentDepDetails
{
    public class StudentAllDepDetails
    {
        public int ID { get; set; }
        public String? Name { get; set; }
        public ICollection<DepDetailDto>? Departments { get; set; }
    }
}
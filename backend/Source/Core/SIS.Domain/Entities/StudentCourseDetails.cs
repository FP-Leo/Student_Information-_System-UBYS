using System.ComponentModel.DataAnnotations.Schema;

namespace SIS.Domain.Entities
{
    public class StudentCourseDetails
    {
        public StudentCourseDetails() { }
        public StudentCourseDetails(string[] data)
        {
            DepartmentName = data[0];
            CourseCode = data[1];
            SchoolYear = int.Parse(data[2]);
            TC = data[3];
            State = data[4];
            if (data[5] == "null")
            {
                AttendanceFulfilled = null;
            }
            else
            {
                AttendanceFulfilled = bool.Parse(data[5]);
            }
            if (data[6] == "null")
            {
                MidTermAnnouncment = null;
            }
            else
            {
                MidTermAnnouncment = DateTime.Parse(data[6]);
            }
            if (data[7] == "null")
            {
                FinalAnnouncment = null;
            }
            else
            {
                FinalAnnouncment = DateTime.Parse(data[7]);
            }
            if (data[8] == "null")
            {
                ComplementAnnouncment = null;
            }
            else
            {
                ComplementAnnouncment = DateTime.Parse(data[8]);
            }
            if (data[9] == "null")
            {
                MidTerm = null;
            }
            else
            {
                MidTerm = int.Parse(data[9]);
            }
            if (data[10] == "null")
            {
                Final = null;
            }
            else
            {
                Final = int.Parse(data[10]);
            }
            if (data[11] == "null")
            {
                ComplementRight = null;
            }
            else
            {
                ComplementRight = bool.Parse(data[11]);
            }
            if (data[12] == "null")
            {
                Complement = null;
            }
            else
            {
                Complement = int.Parse(data[12]);
            }
            if (data[13] == "null")
            {
                Grade = null;
            }
            else
            {
                Grade = float.Parse(data[13]);
            }
        }
        [Column(Order = 0)]
        public int Id { get; set; }
        public string? State { get; set; }
        public bool? AttendanceFulfilled { get; set; }
        public DateTime? MidTermAnnouncment { get; set; }
        public int? MidTerm { get; set; }
        public DateTime? FinalAnnouncment { get; set; }
        public int? Final { get; set; }
        public float? Grade { get; set; }
        public bool? ComplementRight { get; set; } // bütünleme hakkı
        public DateTime? ComplementAnnouncment { get; set; }
        public int? Complement { get; set; }
        // Foreign Key
        [Column(Order = 3)]
        public string? TC { get; set; }
        [Column(Order = 2)]
        public string? CourseCode { get; set; }
        [Column(Order = 1)]
        public string? DepartmentName { get; set; }
        public int SchoolYear { get; set; }
        // Navigation Property
        public CourseClass? CourseClass { get; set; }
        public StudentDepDetails? StudentDetails { get; set; }
    }
}
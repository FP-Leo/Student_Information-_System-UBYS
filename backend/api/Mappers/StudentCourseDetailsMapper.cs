using api.DTO.StudentCourseDetails;
using api.Models;

namespace api.Mappers
{
    public static class StudentCourseDetailsMapper
    {
        public static StudentCourseDetailsDto ToStudentCourseDetailsDto(this StudentCourseDetails studentCourseDetails, String name, int semester){
            return new StudentCourseDetailsDto(){
                Id = studentCourseDetails.Id,
                CourseCode = studentCourseDetails.CourseCode,
                CourseName = name,
                Semester = semester,
                SchoolYear = studentCourseDetails.SchoolYear,
                TC = studentCourseDetails.TC,
                State = studentCourseDetails.State,
                AttendanceFulfilled = studentCourseDetails.AttendanceFulfilled,
                MidTerm = studentCourseDetails.MidTerm,
                Final = studentCourseDetails.Final,
                ComplementRight = studentCourseDetails.ComplementRight,
                Complement = studentCourseDetails.Complement,
                Grade = studentCourseDetails.Grade
            };
        }

        public static StudentCourseDetails ToStudentCourseDetails(this StudentCourseDetailsPostDto studentCourseDetailsPostDto, int SchoolYear){
            return new StudentCourseDetails{
                CourseCode = studentCourseDetailsPostDto.CourseCode,
                SchoolYear = SchoolYear,
                TC = studentCourseDetailsPostDto.TC,
                State = "Attending",
                AttendanceFulfilled = false,
                MidTerm = null,
                Final = null,
                ComplementRight = null,
                Complement = null,
                Grade = null
            };
        }

        public static ICollection<StudentCourseDetailsDto> ToStudentCourseDetailsDto(this ICollection<StudentCourseDetails> studentCoursesDetails, List<string> names, List<int> semesters){
            ICollection<StudentCourseDetailsDto> studentCoursesDetailsDto = [];
            int i = 0;
            foreach(var stdCourseDetails in studentCoursesDetails){
                studentCoursesDetailsDto.Add(stdCourseDetails.ToStudentCourseDetailsDto(names[i], semesters[i]));
                i++;
            }
            return studentCoursesDetailsDto;
        }
    }
}
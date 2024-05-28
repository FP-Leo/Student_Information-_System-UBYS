using api.DTO.StudentCourseDetails;
using api.Models;

namespace api.Mappers
{
    public static class StudentCourseDetailsMapper
    {
        public static StudentCourseDetailsDto ToStudentCourseDetailsDto(this StudentCourseDetails studentCourseDetails){
            return new StudentCourseDetailsDto(){
                Id = studentCourseDetails.Id,
                DepartmentName = studentCourseDetails.DepartmentName,
                CourseName = studentCourseDetails.CourseName,
                SchoolYear = studentCourseDetails.SchoolYear,
                TC = studentCourseDetails.TC,
                State = studentCourseDetails.State,
                AttendanceFulfilled = studentCourseDetails.AttendanceFulfilled,
                MidTerm = studentCourseDetails.MidTerm,
                Final = studentCourseDetails.Final,
                Grade = studentCourseDetails.Grade
            };
        }

        public static StudentCourseDetails ToStudentCourseDetails(this StudentCourseDetailsPostDto studentCourseDetailsPostDto, int SchoolYear){
            return new StudentCourseDetails{
                DepartmentName = studentCourseDetailsPostDto.DepartmentName,
                CourseName = studentCourseDetailsPostDto.CourseName,
                SchoolYear = SchoolYear,
                TC = studentCourseDetailsPostDto.TC,
                State = "Currently Attending",
                AttendanceFulfilled = false,
                MidTerm = null,
                Final = null,
                Grade = null
            };
        }

        public static ICollection<StudentCourseDetailsDto> ToStudentCourseDetailsDto(this ICollection<StudentCourseDetails> studentCoursesDetails){
            ICollection<StudentCourseDetailsDto> studentCoursesDetailsDto = [];
            foreach(var stdCourseDetails in studentCoursesDetails){
                studentCoursesDetailsDto.Add(stdCourseDetails.ToStudentCourseDetailsDto());
            }
            return studentCoursesDetailsDto;
        }
    }
}
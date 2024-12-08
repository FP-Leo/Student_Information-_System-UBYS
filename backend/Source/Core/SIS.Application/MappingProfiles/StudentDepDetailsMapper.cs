using SIS.Application.DTOs.CourseSelection;
using SIS.Application.DTOs.StudentDepDetails;
using SIS.Domain.Entities;

namespace SIS.Application.MappingProfiles
{
    public static class StudentDepDetailsMapper
    {
        public static StudentDepDetailsDto ToStudentDepDetailsDto(this StudentDepDetails studentDepDetails)
        {
            return new StudentDepDetailsDto
            {
                RegistrationDate = studentDepDetails.RegistrationDate,
                StudentType = studentDepDetails.StudentType,
                StudentStatus = studentDepDetails.StudentStatus,
                CurrentSchoolYear = studentDepDetails.CurrentSchoolYear,
                CurrentSemester = studentDepDetails.CurrentSemester,
                CurrentAKTS = studentDepDetails.CurrentAKTS,
                TotalAKTS = studentDepDetails.TotalAKTS,
                Gno = studentDepDetails.Gno,
                DepartmentName = studentDepDetails.DepartmentName,
                TC = studentDepDetails.TC,
            };
        }
        public static StudentDepDetails ToStudentDepDetails(this StudentDepDetailsPostDto studentDepDetails)
        {
            return new StudentDepDetails
            {
                RegistrationDate = DateOnly.FromDateTime(DateTime.Now),
                StudentType = studentDepDetails.StudentType,
                StudentStatus = studentDepDetails.StudentStatus,
                CurrentSchoolYear = studentDepDetails.CurrentSchoolYear,
                CurrentSemester = studentDepDetails.CurrentSemester,
                CurrentAKTS = studentDepDetails.CurrentAKTS,
                TotalAKTS = studentDepDetails.TotalAKTS,
                Gno = studentDepDetails.Gno,
                DepartmentName = studentDepDetails.DepartmentName,
                TC = studentDepDetails.TC,
            };
        }
        public static DepartmentInfoDto ToDepartmentInfo(this StudentDepDetails studentCourseDetails, string FacultyName)
        {
            var departmentInfoDto = new DepartmentInfoDto
            {
                RegistrationDate = studentCourseDetails.RegistrationDate,
                DepartmentName = studentCourseDetails.DepartmentName,
                FacultyName = FacultyName,
                Type = studentCourseDetails.StudentType,
                Language = "Turkish"
            };
            return departmentInfoDto;
        }
    }
}
using api.DTO.StudentDepDetails;
using api.Models;

namespace api.Mappers
{
    public static class StudentDepDetailsMapper
    {
        public static StudentDepDetailsDto ToStudentDepDetailsDto(this StudentDepDetail studentDepDetails){
            return new StudentDepDetailsDto{
                Id = studentDepDetails.Id,
                StudentType = studentDepDetails.StudentType,
                StudentStatus = studentDepDetails.StudentStatus,
                CurrentSchoolYear = studentDepDetails.CurrentSchoolYear,
                CurrentSemester = studentDepDetails.CurrentSemester,
                CurrentAKTS = studentDepDetails.CurrentAKTS,
                TotalAKTS = studentDepDetails.TotalAKTS,
                Gno = studentDepDetails.Gno,
                DepartmentId = studentDepDetails.DepartmentId,
                TC = studentDepDetails.TC,
            };
        }
    }
}
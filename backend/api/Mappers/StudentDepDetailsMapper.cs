using api.DTO.StudentDepDetails;
using api.Models;

namespace api.Mappers
{
    public static class StudentDepDetailsMapper
    {
        public static StudentDepDetailsDto ToStudentDepDetailsDto(this StudentDepDetail studentDepDetails){
            return new StudentDepDetailsDto{
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
        public static StudentDepDetail ToStudentDepDetails(this StudentDepDetailsPostDto studentDepDetails){
            return new StudentDepDetail{
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

        public static StudentDepDetail ToStudentDepDetails(this StudentDepDetailsUpdateDto studentDepDetails){
            return new StudentDepDetail{
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
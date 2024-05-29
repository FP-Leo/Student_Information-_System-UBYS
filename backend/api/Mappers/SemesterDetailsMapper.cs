using api.DTO.SemesterDetails;
using api.Models;

namespace api.Mappers
{
    public static class SemesterDetailsMapper
    {
        public static SemesterDetailsDto ToSemesterDetailsDto(this SemesterDetail semesterDetails){
            return new SemesterDetailsDto{
                DepartmentName = semesterDetails.DepartmentName,
                AcademicYear = semesterDetails.AcademicYear,
                Semester = semesterDetails.Semester,
                NumberOfObligatoryCourses = semesterDetails.NumberOfObligatoryCourses,
                NumberOfSelectiveCourses = semesterDetails.NumberOfSelectiveCourses,
                SelectiveCourseACTS = semesterDetails.SelectiveCourseACTS,
                SelectiveCourseKredi = semesterDetails.SelectiveCourseKredi,
                TotalCourses = semesterDetails.TotalCourses
            };
        }
        public static SemesterDetail ToSemesterDetails(this SemesterDetailsPostDto semesterDetails){
            int AcademicYear = (semesterDetails.Semester + 1)/2;
            return new SemesterDetail{
                DepartmentName = semesterDetails.DepartmentName,
                AcademicYear = AcademicYear,
                Semester = semesterDetails.Semester,
                NumberOfObligatoryCourses = semesterDetails.NumberOfObligatoryCourses,
                NumberOfSelectiveCourses = semesterDetails.NumberOfSelectiveCourses,
                SelectiveCourseACTS = semesterDetails.SelectiveCourseACTS,
                SelectiveCourseKredi = semesterDetails.SelectiveCourseKredi,
                TotalCourses = 0
            };
        }
    }
}
using api.DTO.SemesterDetails;
using api.Models;

namespace api.Mappers
{
    public static class SemesterDetailsMapper
    {
        public static SemesterDetailsDto ToSemesterDetailsDto(this SemesterDetail semesterDetails){
            return new SemesterDetailsDto{
                DepartmentName = semesterDetails.DepartmentName,
                Semester = semesterDetails.Semester,
                NumberOfObligatoryCourses = semesterDetails.NumberOfObligatoryCourses,
                NumberOfSelectiveCourses = semesterDetails.NumberOfSelectiveCourses,
                SelectiveCourseACTS = semesterDetails.SelectiveCourseACTS,
                SelectiveCourseKredi = semesterDetails.SelectiveCourseKredi,
            };
        }
        public static SemesterDetail ToSemesterDetails(this SemesterDetailsPostDto semesterDetails){
            return new SemesterDetail{
                DepartmentName = semesterDetails.DepartmentName,
                Semester = semesterDetails.Semester,
                NumberOfObligatoryCourses = semesterDetails.NumberOfObligatoryCourses,
                NumberOfSelectiveCourses = semesterDetails.NumberOfSelectiveCourses,
                SelectiveCourseACTS = semesterDetails.SelectiveCourseACTS,
                SelectiveCourseKredi = semesterDetails.SelectiveCourseKredi,
            };
        }
    }
}
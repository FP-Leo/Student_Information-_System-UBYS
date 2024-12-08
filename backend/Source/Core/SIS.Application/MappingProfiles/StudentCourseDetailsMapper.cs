using SIS.Application.DTOs.StudentCourseDetails;
using SIS.Domain.Entities;

namespace SIS.Application.MappingProfiles
{
    public static class StudentCourseDetailsMapper
    {
        public static StudentCourseDetailsDto ToStudentCourseDetailsDto(this StudentCourseDetails studentCourseDetails, string name, int semester)
        {
            return new StudentCourseDetailsDto()
            {
                Id = studentCourseDetails.Id,
                CourseCode = studentCourseDetails.CourseCode,
                CourseName = name,
                Semester = semester,
                SchoolYear = studentCourseDetails.SchoolYear,
                TC = studentCourseDetails.TC,
                State = studentCourseDetails.State,
                AttendanceFulfilled = studentCourseDetails.AttendanceFulfilled,
                MidTermAnnouncment = studentCourseDetails.MidTermAnnouncment,
                MidTerm = studentCourseDetails.MidTerm,
                FinalAnnouncment = studentCourseDetails.FinalAnnouncment,
                Final = studentCourseDetails.Final,
                ComplementRight = studentCourseDetails.ComplementRight,
                Complement = studentCourseDetails.Complement,
                Grade = studentCourseDetails.Grade
            };
        }

        public static ICollection<StudentCourseDetailsDto> ToStudentCourseDetailsDto(this ICollection<StudentCourseDetails> studentCoursesDetails, List<string> names, List<int> semesters)
        {
            ICollection<StudentCourseDetailsDto> studentCoursesDetailsDto = [];
            int i = 0;
            foreach (var stdCourseDetails in studentCoursesDetails)
            {
                studentCoursesDetailsDto.Add(stdCourseDetails.ToStudentCourseDetailsDto(names[i], semesters[i]));
                i++;
            }
            return studentCoursesDetailsDto;
        }

        public static ExamResultsDto ToExamResultsDto(this StudentCourseDetails studentCourseDetails, string LecturerName, float[] averages)
        {
            ExamResultsDto examResultsDto = new()
            {
                LecturerName = LecturerName,
                State = studentCourseDetails.State,
                Grade = studentCourseDetails.Grade,
                ExamResultDtos = []
            };
            if (studentCourseDetails.MidTerm != null)
            {
                var midTermResult = new ExamResultDto
                {
                    ExamName = "Mid Term",
                    AnnouncmentDate = studentCourseDetails.MidTermAnnouncment,
                    Points = studentCourseDetails.MidTerm,
                    ClassAverage = averages[0]
                };
                examResultsDto.ExamResultDtos.Add(midTermResult);
            }

            if (studentCourseDetails.Final != null)
            {
                var FinalResult = new ExamResultDto
                {
                    ExamName = "Final",
                    AnnouncmentDate = studentCourseDetails.FinalAnnouncment,
                    Points = studentCourseDetails.Final,
                    ClassAverage = averages[1]
                };
                examResultsDto.ExamResultDtos.Add(FinalResult);
            }

            if (studentCourseDetails.Complement != null)
            {
                var ComplementResult = new ExamResultDto
                {
                    ExamName = "Complement",
                    AnnouncmentDate = studentCourseDetails.ComplementAnnouncment,
                    Points = studentCourseDetails.Complement,
                    ClassAverage = averages[2]
                };
                examResultsDto.ExamResultDtos.Add(ComplementResult);
            }

            return examResultsDto;
        }
    }
}
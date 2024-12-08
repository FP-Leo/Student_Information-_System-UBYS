using SIS.Application.DTOs.Faculty;
using SIS.Domain.Entities;

namespace SIS.Application.MappingProfiles
{
    public static class FacultyMapper
    {
        public static FacultyDto ToFacultyDto(this Faculty faculty)
        {
            return new FacultyDto
            {
                FacultyID = faculty.FacultyID,
                FacultyName = faculty.FacultyName,
                Address = faculty.Address,
                Mail = faculty.Mail,
                WebSite = faculty.WebSite,
                PhoneNumber = faculty.PhoneNumber,
                UniName = faculty.UniName,
                DeanTC = faculty.DeanTC
            };
        }
        public static Faculty ToFaculty(this FacultyPostDto facultyPost)
        {
            return new Faculty
            {
                FacultyName = facultyPost.FacultyName,
                Address = facultyPost.Address,
                Mail = facultyPost.Mail,
                WebSite = facultyPost.WebSite,
                PhoneNumber = facultyPost.PhoneNumber,
                UniName = facultyPost.UniName,
                DeanTC = facultyPost.DeanTC
            };
        }
    }
}
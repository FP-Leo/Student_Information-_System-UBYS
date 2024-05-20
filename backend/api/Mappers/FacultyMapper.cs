using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.Faculty;
using api.Models;

namespace api.Mappers
{
    public static class FacultyMapper
    {
        public static FacultyDto ToFacultyDto(this Faculty faculty){
            return new FacultyDto{
                FacultyID = faculty.FacultyID,
                FacultyName = faculty.FacultyName,
                Address = faculty.Address,
                Mail = faculty.Mail,
                WebSite = faculty.WebSite,
                PhoneNumber = faculty.PhoneNumber,
                UniId = faculty.UniId,
                DeanId = faculty.DeanId
            };
        }
        public static Faculty ToFaculty(this FacultyPostDto facultyPost){
            return new Faculty{
                FacultyName = facultyPost.FacultyName,
                Address = facultyPost.Address,
                Mail = facultyPost.Mail,
                WebSite = facultyPost.WebSite,
                PhoneNumber = facultyPost.PhoneNumber,
                UniId = facultyPost.UniId,
                DeanId = facultyPost.DeanId
            };
        }
    }
}
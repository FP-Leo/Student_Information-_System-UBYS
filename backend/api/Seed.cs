using System.Runtime.CompilerServices;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api
{
    public class Seed
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        public Seed(ApplicationDBContext context, UserManager<User> userManager, ITokenService tokenService){
            _context = context;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task SeedDataContext(){
            if(!_context.Users.Any()){
                await Register("10000000000", "Erlindi.1234", "Admin");
                await Register("10000000001", "Erlindi.1234", "Student");  
                await Register("10000000002", "Erlindi.1234", "Administrator");
                await Register("10000000003", "Erlindi.1234", "Lecturer");
            }
            if(!_context.Universities.Any()){
                var uni = new University{
                    Name = "Çanakkale Onsekiz Mart Üniversitesi",
                    Address = "Barbaros, Çanakkale Onsekiz Mart Üniversitesi Terzioğlu Kampüsü, Prof. Dr. Sevim Buluç Sk. No:20, 17100 Sarıcaeli/Çanakkale Merkez/Çanakkale",
                    WebSite = "comu.edu.tr",
                    Mail = "bidb@comu.edu.tr",
                    PhoneNumber = "444 17 18",
                    CurrentSchoolYear = 2023,
                    RectorTC = "10000000000"
                };
                await _context.Universities.AddAsync(uni);
                await _context.SaveChangesAsync();
            }
            if(!_context.Faculties.Any()){
                var faculty = new Faculty{
                    UniName = "Çanakkale Onsekiz Mart Üniversitesi",
                    FacultyName = "Mühendislik",
                    Address = "Terzioğlu Kampüsü Mühendislik Fakültesi Barbaros Mah Çanakkale 18 Mart Üniversitesi, 4C7C+FX, 17100 Sarıcaeli/Çanakkale Merkez/Çanakkale",
                    Mail = "mf@comu.edu.tr",
                    WebSite = "ce.comu.edu.tr",
                    PhoneNumber = "(0286) 218 05 40",
                    DeanTC = "10000000000"
                };
                await _context.Faculties.AddAsync(faculty);
                await _context.SaveChangesAsync();
            }
            if(!_context.Departments.Any()){
                var department = new Department{
                    FacultyName = "Mühendislik",
                    DepartmentName = "Bilgisayar Mühendisliği",
                    NumberOfSemesters = 8,
                    MaxYears = 7,
                    DepCode = "BLM",
                    BuildingNumber = "2. Bina",
                    FloorNumber = 2,
                    HeadOfDepartmentTC = "10000000002"
                };
                await _context.Departments.AddAsync(department);
                await _context.SaveChangesAsync();
            }
            if(!_context.SemesterDetails.Any()){
                var semesterOne = new SemesterDetail{
                    DepartmentName = "Bilgisayar Mühendisliği",
                    AcademicYear = 1,
                    Semester = 1,
                    NumberOfObligatoryCourses = 9,
                    NumberOfSelectiveCourses = 1,
                    SelectiveCourseACTS = 1,
                    SelectiveCourseKredi = 0,
                    TotalCourses = 1
                };
                var semesterTwo = new SemesterDetail{
                    DepartmentName = "Bilgisayar Mühendisliği",
                    AcademicYear = 1,
                    Semester = 2,
                    NumberOfObligatoryCourses = 8,
                    NumberOfSelectiveCourses = 1,
                    SelectiveCourseACTS = 1,
                    SelectiveCourseKredi = 0,
                    TotalCourses = 0
                };
                var semesterThree = new SemesterDetail{
                    DepartmentName = "Bilgisayar Mühendisliği",
                    AcademicYear = 2,
                    Semester = 3,
                    NumberOfObligatoryCourses = 6,
                    NumberOfSelectiveCourses = 0,
                    SelectiveCourseACTS = 0,
                    SelectiveCourseKredi = 0,
                    TotalCourses = 0
                };
                await _context.SemesterDetails.AddAsync(semesterOne);
                await _context.SemesterDetails.AddAsync(semesterTwo);
                await _context.SemesterDetails.AddAsync(semesterThree);
                await _context.SaveChangesAsync();
            }
            if(!_context.Courses.Any()){
                var course = new Course{CourseName = "Math"};
                await _context.Courses.AddAsync(course);
                await _context.SaveChangesAsync();
            }
            if(!_context.CourseDetails.Any()){
                var courseDetail = new CourseDetails{
                    CourseName = "Math",
                    CourseLanguage = "Türkçe",
                    CourseLevel = "Bachelor",
                    CourseType = "Zorunlu",
                    CourseContent = "Doğrusal denklemler, eşitsizlikler, fonksiyonlar, grafikler."
                };
                await _context.CourseDetails.AddAsync(courseDetail);
                await _context.SaveChangesAsync();
            }
            if(!_context.DepartmentCourses.Any()){
                var depCourse = new DepartmentCourse{
                    DepartmentName = "Bilgisayar Mühendisliği",
                    CourseName = "Math",
                    TaughtSemester = 1,
                    Status = "Open",
                    CourseDetailsId = 1,
                    CourseCode = "BLM-1001"
                };
                await _context.DepartmentCourses.AddAsync(depCourse);
                await _context.SaveChangesAsync();
            }
            if(!_context.LecturerDepDetails.Any()){
                var lectDepDetails = new LecturerDepDetails{
                    DepartmentName = "Bilgisayar Mühendisliği",
                    TC = "10000000003",
                    HoursPerWeek = 0,
                    StartDate = DateTime.Now,
                    EndDate = null,
                };
                await _context.LecturerDepDetails.AddAsync(lectDepDetails);
                await _context.SaveChangesAsync();
            }
            if(!_context.StudentsDepDetails.Any()){
                var studentDepDetails = new StudentDepDetails{
                    DepartmentName = "Bilgisayar Mühendisliği",
                    TC = "10000000001",
                    StudentType = "Bachelor",
                    StudentStatus = "Active",
                    CurrentSchoolYear = 3,
                    CurrentSemester = 6,
                    CurrentAKTS = 30,
                    TotalAKTS = 151,
                    Gno = 0,
                };
                await _context.StudentsDepDetails.AddAsync(studentDepDetails);
                await _context.SaveChangesAsync();
            }
            if(!_context.CourseClasses.Any()){
                var courseClass = new CourseClass{
                    CourseCode = "BLM-1001",
                    SchoolYear = 2023,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClassTwo = new CourseClass{
                    CourseCode = "BLM-1001",
                    SchoolYear = 2021,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                await _context.CourseClasses.AddAsync(courseClass);
                await _context.CourseClasses.AddAsync(courseClassTwo);
                await _context.SaveChangesAsync();
            }
            if(!_context.ClassDates.Any()){
                var classDateOne = new ClassDate{
                    Day = "Monday",
                    Time = DateTime.ParseExact("12:00", "HH:mm", null),
                    NumberOfClasses = 2
                };
                var classDateTwo = new ClassDate{
                    Day = "Tuesday",
                    Time = DateTime.ParseExact("12:00", "HH:mm", null),
                    NumberOfClasses = 2
                };
                await _context.ClassDates.AddAsync(classDateOne);
                await _context.ClassDates.AddAsync(classDateTwo);
                await _context.SaveChangesAsync();
            }
            if(!_context.CourseClassDates.Any()){
                var courseClassDate = new CourseClassDate{
                    CourseCode = "BLM-1001",
                    SchoolYear = 2023,
                    ClassDateId = 1
                };
                var courseClassDateTwo = new CourseClassDate{
                    CourseCode = "BLM-1001",
                    SchoolYear = 2023,
                    ClassDateId = 2
                };
                var courseClassDateThree = new CourseClassDate{
                    CourseCode = "BLM-1001",
                    SchoolYear = 2021,
                    ClassDateId = 1
                };
                await _context.CourseClassDates.AddAsync(courseClassDate);
                await _context.CourseClassDates.AddAsync(courseClassDateTwo);
                await _context.CourseClassDates.AddAsync(courseClassDateThree);
                await _context.SaveChangesAsync();
            }
            if(!_context.StudentsCourseDetails.Any()){
                var studentCourseDetails = new StudentCourseDetails{
                    DepartmentName = "Bilgisayar Mühendisliği",
                    CourseCode = "BLM-1001",
                    SchoolYear = 2021,
                    TC = "10000000001",
                    State = "Passed",
                    AttendanceFulfilled = true,
                    MidTerm = 85,
                    Final = 95,
                    Grade = 4,
                };
                await _context.StudentsCourseDetails.AddAsync(studentCourseDetails);
                await _context.SaveChangesAsync();
            }
        }

        private async Task Register(String Username, String Password, String Role){
            var appUser = new User
            {
                UserName = Username,
            };

            var createdUser = await _userManager.CreateAsync(appUser, Password);
            if (createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(appUser, Role);
                if (roleResult.Succeeded)
                {
                    if(Role == "Student"){
                        var student = new StudentAccount{
                            TC = Username,
                            FirstName = "Erlindi",
                            LastName = "Isaj",
                            BirthDate = new DateTime(2001,12,04),
                            SSN = 200401110,
                            RegisterDate = DateTime.Now,
                            CurrentType = "Bachelor",
                            CurrentStatus = "Active",
                            SchoolMail = "200401110@ogr.comu.edu.tr",
                            PersonalMail = "leonitshabani3@gmail.com",
                            Phone = "+905551722975"
                        };
                        await _context.StudentAccounts.AddAsync(student);
                    }
                    if(Role == "Lecturer"){
                        var lecturer = new LecturerAccount{
                            TC = Username,
                            FirstName = "Ayşe Nur",
                            LastName = "Tunç",
                            BirthDate = DateTime.Now,
                            LecturerId = 100000000,
                            RegisterDate = DateTime.Now,
                            Title = "Asst. Prof.",
                            CurrentStatus = "Active",
                            SchoolMail = "aysenurtunc@comu.edu.tr",
                            PersonalMail = null,
                            Phone = "+90 286 218 0018"
                        };
                        await _context.LecturerAccounts.AddAsync(lecturer);
                    }
                    if(Role == "Advisor"){
                        var advisor = new AdvisorAccount{
                            TC = Username,
                            FirstName = "Muammer",
                            LastName = "Ceylan",
                            BirthDate = DateTime.Now,
                            AdvisorId = 100000000,
                            RegisterDate = DateTime.Now,
                            SchoolMail = "mceylan@comu.edu.tr",
                            PersonalMail = null,
                            Phone = "+90 286 213 9905"
                        };
                        await _context.AdvisorAccounts.AddAsync(advisor);
                    }
                    if(Role == "Administrator"){
                        var administrator = new AdministratorAccount{
                            TC = Username,
                            FirstName = "Safiye Ayşe",
                            LastName = "Göker",
                            BirthDate = DateTime.Now,
                            AdministratorId = 100000000,
                            RegisterDate = DateTime.Now,
                            SchoolMail = "safiyeayse.goker@comu.edu.tr",
                            PersonalMail = null,
                            Phone = null
                        };
                        await _context.AdministratorAccounts.AddAsync(administrator);
                    }
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
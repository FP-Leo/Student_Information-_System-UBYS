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
                await Register("10000000004", "Erlindi.1234", "Advisor");
            }
            if(!_context.Universities.Any()){
                var uni = new University{
                    Name = "Comu", //Name = "Çanakkale Onsekiz Mart Üniversitesi",
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
                    UniName = "Comu", //"Çanakkale Onsekiz Mart Üniversitesi",
                    FacultyName = "M", //"Mühendislik",
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
                    FacultyName = "M", //"Mühendislik",
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    NumberOfSemesters = 8,
                    MaxYears = 7,
                    CourseSelectionStartDate = DateTime.Now,
                    CourseSelectionEndDate = new DateTime(2024,06,07,12,00,0),
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
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    AcademicYear = 1,
                    Semester = 1,
                    NumberOfObligatoryCourses = 9,
                    NumberOfSelectiveCourses = 1,
                    SelectiveCourseACTS = 1,
                    SelectiveCourseKredi = 0,
                    TotalCourses = 1
                };
                var semesterTwo = new SemesterDetail{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    AcademicYear = 1,
                    Semester = 2,
                    NumberOfObligatoryCourses = 8,
                    NumberOfSelectiveCourses = 1,
                    SelectiveCourseACTS = 1,
                    SelectiveCourseKredi = 0,
                    TotalCourses = 0
                };
                var semesterThree = new SemesterDetail{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
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
                var course2 = new Course{CourseName = "Algoritma"};
                var course3 = new Course{CourseName = "BMG"};
                var course4 = new Course{CourseName = "Tarih"};
                var course5 = new Course{CourseName = "Edebiyat"};
                var course6 = new Course{CourseName = "Muzik"};
                var course7 = new Course{CourseName = "Diferansiyel Denklemler"};
                var course8 = new Course{CourseName = "Ayrık Matematik"};
                var course9 = new Course{CourseName = "Veri Yapıları"};
                var course10 = new Course{CourseName = "Elektronik"};
                var course11 = new Course{CourseName = "Nesne Yönelik Programlama"};
                var course12 = new Course{CourseName = "Analitik Geometri"};
                var course13 = new Course{CourseName = "Tarih 2"};
                var course14 = new Course{CourseName = "Bilgisayar Organizasyon"};
                var course15 = new Course{CourseName = "Ontoloji"};
                var course16 = new Course{CourseName = "Edebiyat 2"};
                var course17 = new Course{CourseName = "Sayısal Elektronik"};
                var course18 = new Course{CourseName = "VYDY"};
                var course19 = new Course{CourseName = "Math 2"};
                var course20 = new Course{CourseName = "Programlama Laboratuvarı"};
                var course21 = new Course{CourseName = "VTYS"};
                await _context.Courses.AddAsync(course);
                await _context.Courses.AddAsync(course2);
                await _context.Courses.AddAsync(course3);
                await _context.Courses.AddAsync(course4);
                await _context.Courses.AddAsync(course5);
                await _context.Courses.AddAsync(course6);
                await _context.Courses.AddAsync(course7);
                await _context.Courses.AddAsync(course8);
                await _context.Courses.AddAsync(course9);
                await _context.Courses.AddAsync(course10);
                await _context.Courses.AddAsync(course11);
                await _context.Courses.AddAsync(course12);
                await _context.Courses.AddAsync(course13);
                await _context.Courses.AddAsync(course14);
                await _context.Courses.AddAsync(course15);
                await _context.Courses.AddAsync(course16);
                await _context.Courses.AddAsync(course17);
                await _context.Courses.AddAsync(course18);
                await _context.Courses.AddAsync(course19);
                await _context.Courses.AddAsync(course20);
                await _context.Courses.AddAsync(course21);
                await _context.SaveChangesAsync();
            }
            if(!_context.CourseDetails.Any()){
                var courseDetail = new CourseDetails{
                    CourseName = "Math",
                    CourseLanguage = "Turkish",
                    CourseLevel = "Bachelor",
                    CourseType = "Mandatory",
                    CourseContent = "Doğrusal denklemler, eşitsizlikler, fonksiyonlar, grafikler."
                };
                var courseDetail2 = new CourseDetails{
                    CourseName = "Algoritma",
                    CourseLanguage = "Turkish",
                    CourseLevel = "Bachelor",
                    CourseType = "Mandatory",
                    CourseContent = ""
                };
                var courseDetail3 = new CourseDetails{
                    CourseName = "BMG",
                    CourseLanguage = "Turkish",
                    CourseLevel = "Bachelor",
                    CourseType = "Mandatory",
                    CourseContent = ""
                };
                var courseDetail4 = new CourseDetails{
                    CourseName = "Tarih",
                    CourseLanguage = "Turkish",
                    CourseLevel = "Bachelor",
                    CourseType = "Mandatory",
                    CourseContent = ""
                };
                var courseDetail5 = new CourseDetails{
                    CourseName = "Edebiyat",
                    CourseLanguage = "Turkish",
                    CourseLevel = "Bachelor",
                    CourseType = "Mandatory",
                    CourseContent = ""
                };
                var courseDetail6 = new CourseDetails{
                    CourseName = "Muzik",
                    CourseLanguage = "Turkish",
                    CourseLevel = "Bachelor",
                    CourseType = "Optional",
                    CourseContent = ""
                };
                var courseDetail7 = new CourseDetails{
                    CourseName = "Diferansiyel Denklemler",
                    CourseLanguage = "Turkish",
                    CourseLevel = "Bachelor",
                    CourseType = "Mandatory",
                    CourseContent = ""
                };
                var courseDetail8 = new CourseDetails{
                    CourseName = "Ayrık Matematik",
                    CourseLanguage = "Turkish",
                    CourseLevel = "Bachelor",
                    CourseType = "Mandatory",
                    CourseContent = ""
                };
                var courseDetail9 = new CourseDetails{
                    CourseName = "Veri yapıları",
                    CourseLanguage = "Turkish",
                    CourseLevel = "Bachelor",
                    CourseType = "Mandatory",
                    CourseContent = ""
                };
                var courseDetail10 = new CourseDetails{
                    CourseName = "Elektronik",
                    CourseLanguage = "Turkish",
                    CourseLevel = "Bachelor",
                    CourseType = "Mandatory",
                    CourseContent = ""
                };
                var courseDetail11 = new CourseDetails{
                    CourseName = "Nesne Yönelik Programlama",
                    CourseLanguage = "Turkish",
                    CourseLevel = "Bachelor",
                    CourseType = "Mandatory",
                    CourseContent = ""
                };
                var courseDetail12 = new CourseDetails{
                    CourseName = "Analitik Geometri",
                    CourseLanguage = "Turkish",
                    CourseLevel = "Bachelor",
                    CourseType = "Mandatory",
                    CourseContent = ""
                };
                var courseDetail13 = new CourseDetails{
                    CourseName = "Tarih 2",
                    CourseLanguage = "Turkish",
                    CourseLevel = "Bachelor",
                    CourseType = "Mandatory",
                    CourseContent = ""
                };
                var courseDetail14 = new CourseDetails{
                    CourseName = "Bilgisayar Organizasyon",
                    CourseLanguage = "Turkish",
                    CourseLevel = "Bachelor",
                    CourseType = "Mandatory",
                    CourseContent = ""
                };
                var courseDetail15 = new CourseDetails{
                    CourseName = "Ontoloji",
                    CourseLanguage = "Turkish",
                    CourseLevel = "Bachelor",
                    CourseType = "Optional",
                    CourseContent = ""
                };
                var courseDetail16 = new CourseDetails{
                    CourseName = "Edebiyat 2",
                    CourseLanguage = "Turkish",
                    CourseLevel = "Bachelor",
                    CourseType = "Mandatory",
                    CourseContent = ""
                };
                var courseDetail17 = new CourseDetails{
                    CourseName = "Sayısal Elektronik",
                    CourseLanguage = "Turkish",
                    CourseLevel = "Bachelor",
                    CourseType = "Mandatory",
                    CourseContent = ""
                };
                var courseDetail18 = new CourseDetails{
                    CourseName = "VYDY",
                    CourseLanguage = "Turkish",
                    CourseLevel = "Bachelor",
                    CourseType = "Mandatory",
                    CourseContent = ""
                };
                var courseDetail19 = new CourseDetails{
                    CourseName = "Math 2",
                    CourseLanguage = "Turkish",
                    CourseLevel = "Bachelor",
                    CourseType = "Mandatory",
                    CourseContent = ""
                };
                var courseDetail20 = new CourseDetails{
                    CourseName = "Programlama Laboratuvarı",
                    CourseLanguage = "Turkish",
                    CourseLevel = "Bachelor",
                    CourseType = "Mandatory",
                    CourseContent = ""
                };
                var courseDetail21 = new CourseDetails{
                    CourseName = "VTYS",
                    CourseLanguage = "Turkish",
                    CourseLevel = "Bachelor",
                    CourseType = "Optional",
                    CourseContent = ""
                };
                await _context.CourseDetails.AddAsync(courseDetail);
                await _context.CourseDetails.AddAsync(courseDetail2);
                await _context.CourseDetails.AddAsync(courseDetail3);
                await _context.CourseDetails.AddAsync(courseDetail4);
                await _context.CourseDetails.AddAsync(courseDetail5);
                await _context.CourseDetails.AddAsync(courseDetail6);
                await _context.CourseDetails.AddAsync(courseDetail7);
                await _context.CourseDetails.AddAsync(courseDetail8);
                await _context.CourseDetails.AddAsync(courseDetail9);
                await _context.CourseDetails.AddAsync(courseDetail10);
                await _context.CourseDetails.AddAsync(courseDetail11);
                await _context.CourseDetails.AddAsync(courseDetail12);
                await _context.CourseDetails.AddAsync(courseDetail13);
                await _context.CourseDetails.AddAsync(courseDetail14);
                await _context.CourseDetails.AddAsync(courseDetail15);
                await _context.CourseDetails.AddAsync(courseDetail16);
                await _context.CourseDetails.AddAsync(courseDetail17);
                await _context.CourseDetails.AddAsync(courseDetail18);
                await _context.CourseDetails.AddAsync(courseDetail19);
                await _context.CourseDetails.AddAsync(courseDetail20);
                await _context.CourseDetails.AddAsync(courseDetail21);
                await _context.SaveChangesAsync();
            }
            if(!_context.DepartmentCourses.Any()){
                var depCourse = new DepartmentCourse{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseName = "Math",
                    TaughtSemester = 1,
                    Status = "Open",
                    CourseDetailsId = 1,
                    CourseCode = "BLM-1001"
                };
                var depCourse2 = new DepartmentCourse{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseName = "Algoritma",
                    TaughtSemester = 1,
                    Status = "Open",
                    CourseDetailsId = 2,
                    CourseCode = "BLM-1002"
                };
                var depCourse3 = new DepartmentCourse{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseName = "BMG",
                    TaughtSemester = 1,
                    Status = "Open",
                    CourseDetailsId = 3,
                    CourseCode = "BLM-1003"
                };
                var depCourse4 = new DepartmentCourse{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseName = "Tarih",
                    TaughtSemester = 1,
                    Status = "Open",
                    CourseDetailsId = 4,
                    CourseCode = "BLM-1004"
                };
                var depCourse5 = new DepartmentCourse{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseName = "Edebiyat",
                    TaughtSemester = 1,
                    Status = "Open",
                    CourseDetailsId = 5,
                    CourseCode = "BLM-1005"
                };
                var depCourse6 = new DepartmentCourse{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseName = "Muzik",
                    TaughtSemester = 1,
                    Status = "Open",
                    CourseDetailsId = 6,
                    CourseCode = "BLM-1006"
                };
                var depCourse7 = new DepartmentCourse{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseName = "Diferansiyel Denklemler",
                    TaughtSemester = 3,
                    Status = "Open",
                    CourseDetailsId = 7,
                    CourseCode = "BLM-2001"
                };
                var depCourse8 = new DepartmentCourse{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseName = "Ayrık Matematik",
                    TaughtSemester = 3,
                    Status = "Open",
                    CourseDetailsId = 8,
                    CourseCode = "BLM-2002"
                };
                var depCourse9 = new DepartmentCourse{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseName = "Veri yapıları",
                    TaughtSemester = 3,
                    Status = "Open",
                    CourseDetailsId = 9,
                    CourseCode = "BLM-2003"
                };
                var depCourse10 = new DepartmentCourse{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseName = "Elektronik",
                    TaughtSemester = 3,
                    Status = "Open",
                    CourseDetailsId = 10,
                    CourseCode = "BLM-2004"
                };
                var depCourse11 = new DepartmentCourse{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseName = "Nesne Yönelik Programlama",
                    TaughtSemester = 3,
                    Status = "Open",
                    CourseDetailsId = 11,
                    CourseCode = "BLM-2005"
                };
                var depCourse12 = new DepartmentCourse{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseName = "Analitik Geometri",
                    TaughtSemester = 3,
                    Status = "Open",
                    CourseDetailsId = 12,
                    CourseCode = "BLM-2006"
                };
                var depCourse13 = new DepartmentCourse{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseName = "Tarih 2",
                    TaughtSemester = 2,
                    Status = "Open",
                    CourseDetailsId = 13,
                    CourseCode = "BLM-1007"
                };
                var depCourse14 = new DepartmentCourse{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseName = "Bilgisayar Organizasyon",
                    TaughtSemester = 4,
                    Status = "Open",
                    CourseDetailsId = 14,
                    CourseCode = "BLM-2007"
                };
                var depCourse15 = new DepartmentCourse{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseName = "Ontoloji",
                    TaughtSemester = 5,
                    Status = "Open",
                    CourseDetailsId = 15,
                    CourseCode = "BLM-3001"
                };
                var depCourse16 = new DepartmentCourse{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseName = "Edebiyat 2",
                    TaughtSemester = 2,
                    Status = "Open",
                    CourseDetailsId = 16,
                    CourseCode = "BLM-1008"
                };
                var depCourse17 = new DepartmentCourse{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseName = "Sayısal Elektronik",
                    TaughtSemester = 4,
                    Status = "Open",
                    CourseDetailsId = 17,
                    CourseCode = "BLM-2008"
                };
                var depCourse18 = new DepartmentCourse{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseName = "VYDY",
                    TaughtSemester = 5,
                    Status = "Open",
                    CourseDetailsId = 17,
                    CourseCode = "BLM-3002"
                };
                var depCourse19 = new DepartmentCourse{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseName = "Math 2",
                    TaughtSemester = 2,
                    Status = "Open",
                    CourseDetailsId = 16,
                    CourseCode = "BLM-1009"
                };
                var depCourse20 = new DepartmentCourse{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseName = "Programlama Laboratuvarı",
                    TaughtSemester = 4,
                    Status = "Open",
                    CourseDetailsId = 17,
                    CourseCode = "BLM-2009"
                };
                var depCourse21 = new DepartmentCourse{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseName = "VTYS",
                    TaughtSemester = 5,
                    Status = "Open",
                    CourseDetailsId = 17,
                    CourseCode = "BLM-3003"
                };
                await _context.DepartmentCourses.AddAsync(depCourse);
                await _context.DepartmentCourses.AddAsync(depCourse2);
                await _context.DepartmentCourses.AddAsync(depCourse3);
                await _context.DepartmentCourses.AddAsync(depCourse4);
                await _context.DepartmentCourses.AddAsync(depCourse5);
                await _context.DepartmentCourses.AddAsync(depCourse6);
                await _context.DepartmentCourses.AddAsync(depCourse7);
                await _context.DepartmentCourses.AddAsync(depCourse8);
                await _context.DepartmentCourses.AddAsync(depCourse9);
                await _context.DepartmentCourses.AddAsync(depCourse10);
                await _context.DepartmentCourses.AddAsync(depCourse11);
                await _context.DepartmentCourses.AddAsync(depCourse12);
                await _context.DepartmentCourses.AddAsync(depCourse13);
                await _context.DepartmentCourses.AddAsync(depCourse14);
                await _context.DepartmentCourses.AddAsync(depCourse15);
                await _context.DepartmentCourses.AddAsync(depCourse16);
                await _context.DepartmentCourses.AddAsync(depCourse17);
                await _context.DepartmentCourses.AddAsync(depCourse18);
                await _context.DepartmentCourses.AddAsync(depCourse19);
                await _context.DepartmentCourses.AddAsync(depCourse20);
                await _context.DepartmentCourses.AddAsync(depCourse21);
                await _context.SaveChangesAsync();
            }
            if(!_context.LecturerDepDetails.Any()){
                var lectDepDetails = new LecturerDepDetails{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
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
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    RegistrationDate = DateOnly.FromDateTime(DateTime.Now),
                    TC = "10000000001",
                    StudentType = "Bachelor",
                    StudentStatus = "Active",
                    CurrentSchoolYear = 2,
                    CurrentSemester = 3,
                    CurrentAKTS = 0,
                    TotalAKTS = 0,
                    Gno = (float)2.5,
                };
                await _context.StudentsDepDetails.AddAsync(studentDepDetails);
                await _context.SaveChangesAsync();
            }
            if(!_context.CourseClasses.Any()){
                var courseClass = new CourseClass{
                    CourseCode = "BLM-1001",
                    SchoolYear = 2022,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass2 = new CourseClass{
                    CourseCode = "BLM-1002",
                    SchoolYear = 2022,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass3 = new CourseClass{
                    CourseCode = "BLM-1003",
                    SchoolYear = 2022,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass4 = new CourseClass{
                    CourseCode = "BLM-1004",
                    SchoolYear = 2022,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 5,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass5 = new CourseClass{
                    CourseCode = "BLM-1005",
                    SchoolYear = 2022,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass6 = new CourseClass{
                    CourseCode = "BLM-1006",
                    SchoolYear = 2022,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 1,
                    Kredi = 0,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass41 = new CourseClass{
                    CourseCode = "BLM-1007",
                    SchoolYear = 2022,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 1,
                    Kredi = 0,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass7 = new CourseClass{
                    CourseCode = "BLM-2001",
                    SchoolYear = 2023,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 5,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass8 = new CourseClass{
                    CourseCode = "BLM-2002",
                    SchoolYear = 2023,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 5,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass9 = new CourseClass{
                    CourseCode = "BLM-2003",
                    SchoolYear = 2023,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 5,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass10 = new CourseClass{
                    CourseCode = "BLM-2004",
                    SchoolYear = 2023,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 5,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass11 = new CourseClass{
                    CourseCode = "BLM-2005",
                    SchoolYear = 2023,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 5,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass12 = new CourseClass{
                    CourseCode = "BLM-2006",
                    SchoolYear = 2023,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 5,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass13 = new CourseClass{
                    CourseCode = "BLM-1001",
                    SchoolYear = 2023,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass14 = new CourseClass{
                    CourseCode = "BLM-1002",
                    SchoolYear = 2023,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass15 = new CourseClass{
                    CourseCode = "BLM-1003",
                    SchoolYear = 2023,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass16 = new CourseClass{
                    CourseCode = "BLM-1004",
                    SchoolYear = 2023,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 5,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass17 = new CourseClass{
                    CourseCode = "BLM-1005",
                    SchoolYear = 2023,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass18 = new CourseClass{
                    CourseCode = "BLM-1006",
                    SchoolYear = 2023,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 1,
                    Kredi = 0,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass19 = new CourseClass{
                    CourseCode = "BLM-1007",
                    SchoolYear = 2023,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass20 = new CourseClass{
                    CourseCode = "BLM-2007",
                    SchoolYear = 2023,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass21 = new CourseClass{
                    CourseCode = "BLM-3001",
                    SchoolYear = 2023,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass22 = new CourseClass{
                    CourseCode = "BLM-1008",
                    SchoolYear = 2022,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass23 = new CourseClass{
                    CourseCode = "BLM-1008",
                    SchoolYear = 2023,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass24 = new CourseClass{
                    CourseCode = "BLM-2008",
                    SchoolYear = 2022,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass25 = new CourseClass{
                    CourseCode = "BLM-2008",
                    SchoolYear = 2023,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass26 = new CourseClass{
                    CourseCode = "BLM-3002",
                    SchoolYear = 2022,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass27 = new CourseClass{
                    CourseCode = "BLM-3002",
                    SchoolYear = 2023,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass28 = new CourseClass{
                    CourseCode = "BLM-1009",
                    SchoolYear = 2022,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass29 = new CourseClass{
                    CourseCode = "BLM-1009",
                    SchoolYear = 2023,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass30 = new CourseClass{
                    CourseCode = "BLM-2009",
                    SchoolYear = 2022,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass31 = new CourseClass{
                    CourseCode = "BLM-2009",
                    SchoolYear = 2023,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass32 = new CourseClass{
                    CourseCode = "BLM-3003",
                    SchoolYear = 2022,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass33 = new CourseClass{
                    CourseCode = "BLM-3003",
                    SchoolYear = 2023,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass35 = new CourseClass{
                    CourseCode = "BLM-2001",
                    SchoolYear = 2022,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 5,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass36 = new CourseClass{
                    CourseCode = "BLM-2002",
                    SchoolYear = 2022,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 5,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass37 = new CourseClass{
                    CourseCode = "BLM-2003",
                    SchoolYear = 2022,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 5,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass38 = new CourseClass{
                    CourseCode = "BLM-2004",
                    SchoolYear = 2022,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 5,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass39 = new CourseClass{
                    CourseCode = "BLM-2005",
                    SchoolYear = 2022,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 5,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass40 = new CourseClass{
                    CourseCode = "BLM-2006",
                    SchoolYear = 2022,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 5,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                var courseClass42 = new CourseClass{
                    CourseCode = "BLM-2007",
                    SchoolYear = 2022,
                    LecturerTC = "10000000003",
                    HourPerWeek = 4,
                    AKTS = 6,
                    Kredi = 3,
                    MidTermValue = 40,
                    FinalValue = 60,
                };
                await _context.CourseClasses.AddAsync(courseClass);
                await _context.CourseClasses.AddAsync(courseClass2);
                await _context.CourseClasses.AddAsync(courseClass3);
                await _context.CourseClasses.AddAsync(courseClass4);
                await _context.CourseClasses.AddAsync(courseClass5);
                await _context.CourseClasses.AddAsync(courseClass6);
                await _context.CourseClasses.AddAsync(courseClass7);
                await _context.CourseClasses.AddAsync(courseClass8);
                await _context.CourseClasses.AddAsync(courseClass9);
                await _context.CourseClasses.AddAsync(courseClass10);
                await _context.CourseClasses.AddAsync(courseClass11);
                await _context.CourseClasses.AddAsync(courseClass12);
                await _context.CourseClasses.AddAsync(courseClass13);
                await _context.CourseClasses.AddAsync(courseClass14);
                await _context.CourseClasses.AddAsync(courseClass15);
                await _context.CourseClasses.AddAsync(courseClass16);
                await _context.CourseClasses.AddAsync(courseClass17);
                await _context.CourseClasses.AddAsync(courseClass18);
                await _context.CourseClasses.AddAsync(courseClass19);
                await _context.CourseClasses.AddAsync(courseClass20);
                await _context.CourseClasses.AddAsync(courseClass21);
                await _context.CourseClasses.AddAsync(courseClass22);
                await _context.CourseClasses.AddAsync(courseClass23);
                await _context.CourseClasses.AddAsync(courseClass24);
                await _context.CourseClasses.AddAsync(courseClass25);
                await _context.CourseClasses.AddAsync(courseClass26);
                await _context.CourseClasses.AddAsync(courseClass27);
                await _context.CourseClasses.AddAsync(courseClass28);
                await _context.CourseClasses.AddAsync(courseClass29);
                await _context.CourseClasses.AddAsync(courseClass30);
                await _context.CourseClasses.AddAsync(courseClass31);
                await _context.CourseClasses.AddAsync(courseClass32);
                await _context.CourseClasses.AddAsync(courseClass33);
                await _context.CourseClasses.AddAsync(courseClass35);
                await _context.CourseClasses.AddAsync(courseClass36);
                await _context.CourseClasses.AddAsync(courseClass37);
                await _context.CourseClasses.AddAsync(courseClass38);
                await _context.CourseClasses.AddAsync(courseClass39);
                await _context.CourseClasses.AddAsync(courseClass40);
                await _context.CourseClasses.AddAsync(courseClass41);
                await _context.CourseClasses.AddAsync(courseClass42);
                await _context.SaveChangesAsync();
            }
            if(!_context.ClassDates.Any()){
                var classDateOne = new ClassDate{
                    Day = "Monday",
                    Time = TimeOnly.FromDateTime(DateTime.ParseExact("12:00", "HH:mm", null)),
                    NumberOfClasses = 2
                };
                var classDateTwo = new ClassDate{
                    Day = "Tuesday",
                    Time = TimeOnly.FromDateTime(DateTime.ParseExact("12:00", "HH:mm", null)),
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
                    CourseCode = "BLM-1002",
                    SchoolYear = 2023,
                    ClassDateId = 2
                };
                var courseClassDate3 = new CourseClassDate{
                    CourseCode = "BLM-2007",
                    SchoolYear = 2023,
                    ClassDateId = 1
                };
                var courseClassDate4 = new CourseClassDate{
                    CourseCode = "BLM-2008",
                    SchoolYear = 2023,
                    ClassDateId = 2
                };
                var courseClassDate5 = new CourseClassDate{
                    CourseCode = "BLM-2009",
                    SchoolYear = 2023,
                    ClassDateId = 2
                };
                await _context.CourseClassDates.AddAsync(courseClassDate);
                await _context.CourseClassDates.AddAsync(courseClassDateTwo);
                await _context.CourseClassDates.AddAsync(courseClassDate3);
                await _context.CourseClassDates.AddAsync(courseClassDate4);
                await _context.CourseClassDates.AddAsync(courseClassDate5);
                await _context.SaveChangesAsync();
            }
            if(!_context.StudentsCourseDetails.Any()){
                var studentCourseDetails = new StudentCourseDetails{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseCode = "BLM-1001",
                    SchoolYear = 2022,
                    TC = "10000000001",
                    State = "Passed",
                    AttendanceFulfilled = true,
                    MidTermAnnouncment = DateTime.Now,
                    FinalAnnouncment = DateTime.Now,
                    ComplementAnnouncment = null,
                    MidTerm = 85,
                    Final = 95,
                    ComplementRight = false,
                    Complement = null,
                    Grade = 4,
                };
                var studentCourseDetails2 = new StudentCourseDetails{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseCode = "BLM-1002",
                    SchoolYear = 2022,
                    TC = "10000000001",
                    State = "Failed",
                    AttendanceFulfilled = true,
                    MidTermAnnouncment = DateTime.Now,
                    FinalAnnouncment = DateTime.Now,
                    ComplementAnnouncment = DateTime.Now,
                    MidTerm = 30,
                    Final = 40,
                    ComplementRight = true,
                    Complement = 60,
                    Grade = (float?)0.5,
                };
                var studentCourseDetails3 = new StudentCourseDetails{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseCode = "BLM-1003",
                    SchoolYear = 2022,
                    TC = "10000000001",
                    State = "Passed",
                    AttendanceFulfilled = true,
                    MidTermAnnouncment = DateTime.Now,
                    FinalAnnouncment = DateTime.Now,
                    ComplementAnnouncment = null,
                    MidTerm = 85,
                    Final = 95,
                    ComplementRight = false,
                    Complement = null,
                    Grade = 4,
                };
                var studentCourseDetails4 = new StudentCourseDetails{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseCode = "BLM-1004",
                    SchoolYear = 2022,
                    TC = "10000000001",
                    State = "Failed",
                    AttendanceFulfilled = true,
                    MidTermAnnouncment = DateTime.Now,
                    FinalAnnouncment = DateTime.Now,
                    ComplementAnnouncment = DateTime.Now,
                    MidTerm = 85,
                    Final = 45,
                    ComplementRight = true,
                    Complement = 40,
                    Grade = 0,
                };
                var studentCourseDetails5 = new StudentCourseDetails{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseCode = "BLM-1005",
                    SchoolYear = 2022,
                    TC = "10000000001",
                    State = "Partially Passed",
                    AttendanceFulfilled = true,
                    MidTermAnnouncment = DateTime.Now,
                    FinalAnnouncment = DateTime.Now,
                    ComplementAnnouncment = null,
                    MidTerm = 50,
                    Final = 50,
                    ComplementRight = false,
                    Complement = null,
                    Grade = (float?)1.5,
                };
                var studentCourseDetails6 = new StudentCourseDetails{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseCode = "BLM-1006",
                    SchoolYear = 2022,
                    TC = "10000000001",
                    State = "Failed",
                    AttendanceFulfilled = false,
                    MidTermAnnouncment = DateTime.Now,
                    FinalAnnouncment = DateTime.Now,
                    ComplementAnnouncment = null,
                    MidTerm = 85,
                    Final = 95,
                    ComplementRight = false,
                    Complement = null,
                    Grade = 0
                };
                var studentCourseDetails7 = new StudentCourseDetails{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseCode = "BLM-1007",
                    SchoolYear = 2022,
                    TC = "10000000001",
                    State = "Failed",
                    AttendanceFulfilled = true,
                    MidTermAnnouncment = DateTime.Now,
                    FinalAnnouncment = DateTime.Now,
                    ComplementAnnouncment = DateTime.Now,
                    MidTerm = 85,
                    Final = 45,
                    ComplementRight = true,
                    Complement = 40,
                    Grade = 0
                };
                var studentCourseDetails8 = new StudentCourseDetails{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseCode = "BLM-1008",
                    SchoolYear = 2022,
                    TC = "10000000001",
                    State = "Partially Passed",
                    AttendanceFulfilled = true,
                    MidTermAnnouncment = DateTime.Now,
                    FinalAnnouncment = DateTime.Now,
                    ComplementAnnouncment = null,
                    MidTerm = 50,
                    Final = 50,
                    ComplementRight = false,
                    Complement = null,
                    Grade = (float?)1.5,
                };
                var studentCourseDetails9 = new StudentCourseDetails{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseCode = "BLM-1009",
                    SchoolYear = 2022,
                    TC = "10000000001",
                    State = "Failed",
                    AttendanceFulfilled = false,
                    MidTermAnnouncment = DateTime.Now,
                    FinalAnnouncment = DateTime.Now,
                    ComplementAnnouncment = null,
                    MidTerm = 85,
                    Final = 95,
                    ComplementRight = false,
                    Complement = null,
                    Grade = 0
                };
                /*
                var studentCourseDetails19 = new StudentCourseDetails{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseCode = "BLM-2001",
                    SchoolYear = 2023,
                    TC = "10000000001",
                    State = "Passed",
                    AttendanceFulfilled = true,
                    MidTermAnnouncment = DateTime.Now,
                    FinalAnnouncment = DateTime.Now,
                    ComplementAnnouncment = null,
                    MidTerm = 85,
                    Final = 95,
                    ComplementRight = false,
                    Complement = null,
                    Grade = 4,
                };
                var studentCourseDetails20 = new StudentCourseDetails{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseCode = "BLM-2002",
                    SchoolYear = 2023,
                    TC = "10000000001",
                    State = "Failed",
                    AttendanceFulfilled = true,
                    MidTermAnnouncment = DateTime.Now,
                    FinalAnnouncment = DateTime.Now,
                    ComplementAnnouncment = DateTime.Now,
                    MidTerm = 30,
                    Final = 40,
                    ComplementRight = true,
                    Complement = 60,
                    Grade = 1,
                };
                var studentCourseDetails21 = new StudentCourseDetails{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseCode = "BLM-2003",
                    SchoolYear = 2023,
                    TC = "10000000001",
                    State = "Passed",
                    AttendanceFulfilled = true,
                    MidTermAnnouncment = DateTime.Now,
                    FinalAnnouncment = DateTime.Now,
                    ComplementAnnouncment = null,
                    MidTerm = 85,
                    Final = 95,
                    ComplementRight = false,
                    Complement = null,
                    Grade = 4,
                };
                var studentCourseDetails22 = new StudentCourseDetails{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseCode = "BLM-2004",
                    SchoolYear = 2023,
                    TC = "10000000001",
                    State = "Failed",
                    AttendanceFulfilled = true,
                    MidTermAnnouncment = DateTime.Now,
                    FinalAnnouncment = DateTime.Now,
                    ComplementAnnouncment = DateTime.Now,
                    MidTerm = 85,
                    Final = 45,
                    ComplementRight = true,
                    Complement = 40,
                    Grade = 0
                };
                var studentCourseDetails23 = new StudentCourseDetails{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseCode = "BLM-2005",
                    SchoolYear = 2023,
                    TC = "10000000001",
                    State = "Partially Passed",
                    AttendanceFulfilled = true,
                    MidTermAnnouncment = DateTime.Now,
                    FinalAnnouncment = DateTime.Now,
                    ComplementAnnouncment = null,
                    MidTerm = 50,
                    Final = 50,
                    ComplementRight = false,
                    Complement = null,
                    Grade = (float?)1.5
                };
                var studentCourseDetails24 = new StudentCourseDetails{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseCode = "BLM-2006",
                    SchoolYear = 2023,
                    TC = "10000000001",
                    State = "Failed",
                    AttendanceFulfilled = false,
                    MidTermAnnouncment = DateTime.Now,
                    FinalAnnouncment = DateTime.Now,
                    ComplementAnnouncment = null,
                    MidTerm = 85,
                    Final = 95,
                    ComplementRight = false,
                    Complement = null,
                    Grade = 0
                };
                */
                var studentCourseDetails25 = new StudentCourseDetails{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseCode = "BLM-2007",
                    SchoolYear = 2023,
                    TC = "10000000001",
                    State = "Attending",
                    AttendanceFulfilled = null,
                    MidTermAnnouncment = null,
                    FinalAnnouncment = null,
                    ComplementAnnouncment = null,
                    MidTerm = null,
                    Final = null,
                    ComplementRight = null,
                    Complement = null,
                    Grade = null,
                };
                var studentCourseDetails26 = new StudentCourseDetails{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseCode = "BLM-2008",
                    SchoolYear = 2023,
                    TC = "10000000001",
                    State = "Attending",
                    AttendanceFulfilled = null,
                    MidTermAnnouncment = null,
                    FinalAnnouncment = null,
                    ComplementAnnouncment = null,
                    MidTerm = null,
                    Final = null,
                    ComplementRight = null,
                    Complement = null,
                    Grade = null,
                };
                var studentCourseDetails27 = new StudentCourseDetails{
                    DepartmentName = "BM", //"Bilgisayar Mühendisliği",
                    CourseCode = "BLM-2009",
                    SchoolYear = 2023,
                    TC = "10000000001",
                    State = "Attending",
                    AttendanceFulfilled = null,
                    MidTermAnnouncment = null,
                    FinalAnnouncment = null,
                    ComplementAnnouncment = null,
                    MidTerm = null,
                    Final = null,
                    ComplementRight = null,
                    Complement = null,
                    Grade = null,
                };
                await _context.StudentsCourseDetails.AddAsync(studentCourseDetails);
                await _context.StudentsCourseDetails.AddAsync(studentCourseDetails2);
                await _context.StudentsCourseDetails.AddAsync(studentCourseDetails3);
                await _context.StudentsCourseDetails.AddAsync(studentCourseDetails4);
                await _context.StudentsCourseDetails.AddAsync(studentCourseDetails5);
                await _context.StudentsCourseDetails.AddAsync(studentCourseDetails6);
                await _context.StudentsCourseDetails.AddAsync(studentCourseDetails7);
                await _context.StudentsCourseDetails.AddAsync(studentCourseDetails8);
                await _context.StudentsCourseDetails.AddAsync(studentCourseDetails9);
                //await _context.StudentsCourseDetails.AddAsync(studentCourseDetails19);
                //await _context.StudentsCourseDetails.AddAsync(studentCourseDetails20);
                //await _context.StudentsCourseDetails.AddAsync(studentCourseDetails21);
                //await _context.StudentsCourseDetails.AddAsync(studentCourseDetails22);
                //await _context.StudentsCourseDetails.AddAsync(studentCourseDetails23);
                //await _context.StudentsCourseDetails.AddAsync(studentCourseDetails24);
                await _context.StudentsCourseDetails.AddAsync(studentCourseDetails25);
                await _context.StudentsCourseDetails.AddAsync(studentCourseDetails26);
                await _context.StudentsCourseDetails.AddAsync(studentCourseDetails27);
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
                            BirthDate = DateOnly.FromDateTime(new DateTime(2001,12,04)),
                            SSN = 200401110,
                            RegisterDate = DateOnly.FromDateTime(DateTime.Now),
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
                            BirthDate = DateOnly.FromDateTime(DateTime.Now),
                            LecturerId = 100000000,
                            RegisterDate = DateOnly.FromDateTime(DateTime.Now),
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
                            BirthDate = DateOnly.FromDateTime(DateTime.Now),
                            AdvisorId = 100000000,
                            RegisterDate = DateOnly.FromDateTime(DateTime.Now),
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
                            BirthDate = DateOnly.FromDateTime(DateTime.Now),
                            AdministratorId = 100000000,
                            RegisterDate = DateOnly.FromDateTime(DateTime.Now),
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
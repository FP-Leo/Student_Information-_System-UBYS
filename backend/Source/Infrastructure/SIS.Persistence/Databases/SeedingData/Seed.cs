using Microsoft.AspNetCore.Identity;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Contexts.Data;

namespace SIS.Persistence.Databases.SeedingData
{
    public class Seed
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<User> _userManager;
        private readonly string userPath = "./SeedData/user.csv";
        private readonly string uniPath = "./SeedData/uni.csv";
        private readonly string facultyPath = "./SeedData/faculty.csv";
        private readonly string depPath = "./SeedData/department.csv";
        private readonly string semesterPath = "./SeedData/semester.csv";
        private readonly string coursePath = "./SeedData/course.csv";
        private readonly string courseDetailPath = "./SeedData/courseDetail.csv";
        private readonly string depCoursePath = "./SeedData/departmentCourse.csv";
        private readonly string lecDepDetailPath = "./SeedData/lecDepDetail.csv";
        private readonly string studentDepDetailPath = "./SeedData/studentDepDetail.csv";
        private readonly string courseClassPath = "./SeedData/courseClass.csv";
        private readonly string classDatePath = "./SeedData/classDate.csv";
        private readonly string courseClassDatePath = "./SeedData/courseClassDate.csv";
        private readonly string studentCourseDetailsPath = "./SeedData/studentCourseDetails.csv";
        public Seed(ApplicationDBContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task SeedDataContext()
        {
            if (!_context.Users.Any())
            {
                var data = File.ReadAllLines(userPath).Skip(1).Select(a => a.Split("|"));
                foreach (var user in data)
                {
                    //Console.WriteLine(user.Length);
                    await Register(user);
                }
            }
            if (!_context.Universities.Any())
            {
                var data = File.ReadAllLines(uniPath).Skip(1).Select(a => a.Split("|"));
                foreach (var uni in data)
                {
                    await _context.Universities.AddAsync(new University(uni));
                }
                await _context.SaveChangesAsync();
            }
            if (!_context.Faculties.Any())
            {
                var data = File.ReadAllLines(facultyPath).Skip(1).Select(a => a.Split("|"));
                foreach (var faculty in data)
                {
                    await _context.Faculties.AddAsync(new Faculty(faculty));
                }
                await _context.SaveChangesAsync();
            }
            if (!_context.Departments.Any())
            {
                var data = File.ReadAllLines(depPath).Skip(1).Select(a => a.Split("|"));
                foreach (var department in data)
                {
                    await _context.Departments.AddAsync(new Department(department));
                }
                await _context.SaveChangesAsync();
            }
            if (!_context.SemesterDetails.Any())
            {
                var data = File.ReadAllLines(semesterPath).Skip(1).Select(a => a.Split("|"));
                foreach (var semester in data)
                {
                    await _context.SemesterDetails.AddAsync(new SemesterDetail(semester));
                }
                await _context.SaveChangesAsync();
            }
            if (!_context.Courses.Any())
            {
                var data = File.ReadAllLines(coursePath).Skip(1).Select(a => a.Split("|"));
                foreach (var course in data)
                {
                    await _context.Courses.AddAsync(new Course(course));
                }
                await _context.SaveChangesAsync();
            }
            if (!_context.CourseDetails.Any())
            {
                var data = File.ReadAllLines(courseDetailPath).Skip(1).Select(a => a.Split("|"));
                foreach (var course in data)
                {
                    await _context.CourseDetails.AddAsync(new CourseDetails(course));
                }
                await _context.SaveChangesAsync();
            }
            if (!_context.DepartmentCourses.Any())
            {
                var data = File.ReadAllLines(depCoursePath).Skip(1).Select(a => a.Split("|"));
                foreach (var depCourse in data)
                {
                    await _context.DepartmentCourses.AddAsync(new DepartmentCourse(depCourse));
                }
                await _context.SaveChangesAsync();
            }
            if (!_context.LecturerDepDetails.Any())
            {
                var data = File.ReadAllLines(lecDepDetailPath).Skip(1).Select(a => a.Split("|"));
                foreach (var lectDepDetails in data)
                {
                    await _context.LecturerDepDetails.AddAsync(new LecturerDepDetails(lectDepDetails));
                }
                await _context.SaveChangesAsync();
            }
            if (!_context.StudentsDepDetails.Any())
            {
                var data = File.ReadAllLines(studentDepDetailPath).Skip(1).Select(a => a.Split("|"));
                foreach (var studentDepDetails in data)
                {
                    await _context.StudentsDepDetails.AddAsync(new StudentDepDetails(studentDepDetails));
                }
                await _context.SaveChangesAsync();
            }
            if (!_context.CourseClasses.Any())
            {
                var data = File.ReadAllLines(courseClassPath).Skip(1).Select(a => a.Split("|"));
                foreach (var courseClass in data)
                {
                    await _context.CourseClasses.AddAsync(new CourseClass(courseClass));
                }
                await _context.SaveChangesAsync();
            }
            if (!_context.ClassDates.Any())
            {
                var data = File.ReadAllLines(classDatePath).Skip(1).Select(a => a.Split("|"));
                foreach (var classDate in data)
                {
                    await _context.ClassDates.AddAsync(new ClassDate(classDate));
                }
                await _context.SaveChangesAsync();
            }
            if (!_context.CourseClassDates.Any())
            {
                var data = File.ReadAllLines(courseClassDatePath).Skip(1).Select(a => a.Split("|"));
                foreach (var courseClassDate in data)
                {
                    await _context.CourseClassDates.AddAsync(new CourseClassDate(courseClassDate));
                }
                await _context.SaveChangesAsync();
            }
            if (!_context.StudentsCourseDetails.Any())
            {
                var data = File.ReadAllLines(studentCourseDetailsPath).Skip(1).Select(a => a.Split("|"));
                foreach (var stdCourseDetails in data)
                {
                    await _context.StudentsCourseDetails.AddAsync(new StudentCourseDetails(stdCourseDetails));
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task Register(string[] userData)
        {
            var appUser = new User
            {
                UserName = userData[2],
            };

            var createdUser = await _userManager.CreateAsync(appUser, userData[1]);
            if (createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(appUser, userData[0]);
                if (roleResult.Succeeded && userData[0] != "Admin")
                {
                    var userAccData = new string[9];
                    for (int i = 2; i < 11; i++)
                    {
                        userAccData[i - 2] = userData[i];
                    }
                    if (userData[0] == "Student")
                    {
                        var extraData = userData[11].Split(",");
                        await _context.StudentAccounts.AddAsync(new StudentAccount(userAccData, extraData));
                    }
                    else if (userData[0] == "Lecturer")
                    {
                        var extraData = userData[11].Split(",");
                        await _context.LecturerAccounts.AddAsync(new LecturerAccount(userAccData, extraData));
                    }
                    else if (userData[0] == "Advisor")
                    {
                        await _context.AdvisorAccounts.AddAsync(new AdvisorAccount(userAccData));
                    }
                    else if (userData[0] == "Administrator")
                    {
                        await _context.AdministratorAccounts.AddAsync(new AdministratorAccount(userAccData));
                    }
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
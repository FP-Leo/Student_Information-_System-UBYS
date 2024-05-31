using Microsoft.EntityFrameworkCore;
using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using api.DTO.Account;


namespace api.Data
{
    public class ApplicationDBContext: IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions){}
        public DbSet<AdministratorAccount> AdministratorAccounts { get; set; }
        public DbSet<AdvisorAccount> AdvisorAccounts { get; set; }
        public DbSet<StudentAccount> StudentAccounts { get; set; }
        public DbSet<LecturerAccount> LecturerAccounts { get; set; }
        public DbSet<University> Universities{ get; set; }
        public DbSet<Faculty> Faculties{ get; set; }
        public DbSet<Department> Departments{ get; set; }
        public DbSet<SemesterDetail> SemesterDetails { get; set; }
        public DbSet<StudentDepDetails> StudentsDepDetails{ get; set; }
        public DbSet<StudentCourseDetails> StudentsCourseDetails{ get; set; }
        public DbSet<LecturerDepDetails> LecturerDepDetails{ get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<DepartmentCourse> DepartmentCourses { get; set; }
        public DbSet<CourseDetails> CourseDetails { get; set; }
        public DbSet<CourseClass> CourseClasses { get; set; }
        public DbSet<ClassDate> ClassDates { get; set; }
        public DbSet<CourseClassDate> CourseClassDates { get; set; }
        public DbSet<StudentCourseSelection> StudentCourseSelections { get; set; }
        public DbSet<StudentCourseSelect> StudentSelectedCourses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            // List of Roles.
            List<IdentityRole> roles = [
                new IdentityRole{
                    Name = "Student",
                    NormalizedName = "STUDENT"
                },
                new IdentityRole{
                    Name = "Lecturer",
                    NormalizedName = "LECTURER"
                },
                new IdentityRole{
                    Name = "Advisor",
                    NormalizedName = "ADVISOR"
                },
                new IdentityRole{
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole{
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                } /*,
                new IdentityRole{
                    Name = "Staff",
                    NormalizedName = "STAFF"
                }*/ // If we ever want to represent the rector and the dean as a different account.
            ];
            // Add Roles
            modelBuilder.Entity<IdentityRole>().HasData(roles);
            // Saves tables inhereted from User Account as separate tables
            modelBuilder.Entity<UserAccount>().UseTpcMappingStrategy();

            //// Alterante Keys
            // Set up alterate keys to be used as foreign keys instead of the primary ones.
            modelBuilder.Entity<User>().HasAlternateKey(u=> u.UserName);
            // Since Ids differ for each type of user account, TC can be used as fk instead.
            modelBuilder.Entity<UserAccount>().HasAlternateKey(ua => ua.TC);
            // For better readability
            modelBuilder.Entity<University>().HasAlternateKey(u => u.Name);
            modelBuilder.Entity<Faculty>().HasAlternateKey(f => f.FacultyName);
            modelBuilder.Entity<Department>().HasAlternateKey(d => d.DepartmentName);
            // To give back the course name instead of the id.
            modelBuilder.Entity<Course>().HasAlternateKey(c => c.CourseName);
            // Compound Alt key to be used for Specific Course Explanation.
            modelBuilder.Entity<DepartmentCourse>().HasAlternateKey(dc => dc.CourseCode);
            // Compound Alt key to reference Lecturer, Department and Faculty at the same time.
            modelBuilder.Entity<LecturerDepDetails>().HasAlternateKey(ld => new { ld.DepartmentName, ld.TC });
            // Compound Alt key to reference Class, Course and Department at the same time.
            modelBuilder.Entity<CourseClass>().HasAlternateKey(cc => new { cc.CourseCode, cc.SchoolYear });
            // Compound Alt key to reference Student Dep Details.
            modelBuilder.Entity<StudentDepDetails>().HasAlternateKey(sdd => new { sdd.DepartmentName, sdd.TC });
            //// Relationships
            
            //// User Account
            // One to One UserAccount - User
            modelBuilder.Entity<UserAccount>()
                        .HasOne(u => u.User)
                        .WithOne(ua => ua.UserAccount)
                        .HasForeignKey<UserAccount>(ua => ua.TC)
                        .HasPrincipalKey<User>(u => u.UserName)
                        .IsRequired();
            
            //// University
            // One to One University - User for Rector
            modelBuilder.Entity<University>()
                        .HasOne(u => u.Rector)
                        .WithOne(uni => uni.University)
                        .HasForeignKey<University>(uni => uni.RectorTC)
                        .HasPrincipalKey<User>(u => u.UserName)
                        .IsRequired();
            //// Faculty
            // Many to One Faculty - University
            modelBuilder.Entity<Faculty>()
                        .HasOne(e => e.University)
                        .WithMany(e => e.Faculties)
                        .HasForeignKey(e => e.UniName)
                        .HasPrincipalKey(e => e.Name)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Restrict);
            // One to One Faculty - User for Dean
            modelBuilder.Entity<Faculty>()
                        .HasOne(e => e.Dean)
                        .WithOne(e => e.Faculty)
                        .HasForeignKey<Faculty>(e => e.DeanTC)
                        .HasPrincipalKey<User>(u => u.UserName)
                        .IsRequired();
            //// Department
            // Many To One Department - Faculty
            modelBuilder.Entity<Department>()
                        .HasOne(e => e.Faculty)
                        .WithMany(e => e.Departments)
                        .HasForeignKey(e => e.FacultyName)
                        .HasPrincipalKey(e => e.FacultyName)
                        .IsRequired();
            // One to One Department - User for HeadOfDepartment
            modelBuilder.Entity<Department>()
                        .HasOne(e => e.HeadOfDepartment)
                        .WithOne(e => e.Department)
                        .HasForeignKey<Department>(e => e.HeadOfDepartmentTC)
                        .HasPrincipalKey<User>(u => u.UserName)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Restrict);
            ////Student Details
            // Many to One Student Details - Department
            modelBuilder.Entity<StudentDepDetails>()
                        .HasOne(e => e.Department)
                        .WithMany(e => e.StudentDepDetails)
                        .HasForeignKey(e => e.DepartmentName)
                        .HasPrincipalKey(e => e.DepartmentName)
                        .IsRequired();
            // Many to One Student Details - StudentAccount
            modelBuilder.Entity<StudentDepDetails>()
                        .HasOne(e => e.StudentAccount)
                        .WithMany(e => e.StudentDepDetails)
                        .HasForeignKey(e => e.TC)
                        .HasPrincipalKey(e => e.TC)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Restrict);
            //// DepartmentCourse
            // One to Many DepartmentCourse - Course
            modelBuilder.Entity<DepartmentCourse>()
                        .HasOne(e => e.Course)
                        .WithMany(e => e.DepartmentCourses)
                        .HasForeignKey(e => e.CourseName)
                        .HasPrincipalKey(e => e.CourseName)
                        .IsRequired();
            // One to Many DepartmentCourse - Department
            modelBuilder.Entity<DepartmentCourse>()
                        .HasOne(e => e.Department)
                        .WithMany(e => e.DepartmentCourses)
                        .HasForeignKey(e => e.DepartmentName)
                        .HasPrincipalKey(e => e.DepartmentName)
                        .IsRequired();
            // Many to One DepartmentCourse - CourseDetails
            modelBuilder.Entity<DepartmentCourse>()
                        .HasOne(cd => cd.CourseDetails)
                        .WithMany(dc => dc.DepartmentCourses)
                        .HasForeignKey(dc => dc.CourseDetailsId)
                        .IsRequired();
            ////CourseClass
            // Many to One Class - Lecturer
            modelBuilder.Entity<CourseClass>()
                        .HasOne( cc => cc.LecturerDetails)
                        .WithMany(la => la.Courses)
                        .HasForeignKey(cc => cc.LecturerTC)
                        .HasPrincipalKey(la => la.TC)
                        .OnDelete(DeleteBehavior.Restrict);
            // Many to One Class - Course
            modelBuilder.Entity<CourseClass>()
                        .HasOne(e => e.DepartmentCourse)
                        .WithMany(e => e.CourseClasses)
                        .HasForeignKey(cc => cc.CourseCode)
                        .HasPrincipalKey(dc => dc.CourseCode)
                        .IsRequired();
            //// Lecturer Dep Details
            // Many to One LecturerDepDetail - Lecturer
            modelBuilder.Entity<LecturerDepDetails>()
                        .HasOne(ldd => ldd.Lecturer)
                        .WithMany(l => l.LecturerDepDetails)
                        .HasForeignKey(ldd => ldd.TC)
                        .HasPrincipalKey(l => l.TC)
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
            // Many to One LecturerDepDetail - Department
            modelBuilder.Entity<LecturerDepDetails>()
                        .HasOne(ldd => ldd.Department)
                        .WithMany(d => d.LecturerDepDetails)
                        .HasForeignKey(ldd => ldd.DepartmentName)
                        .HasPrincipalKey(d => d.DepartmentName)
                        .IsRequired();
            //// StudentCourseDetails
            // Many to One StudentCourseDetails - CourseClass
            modelBuilder.Entity<StudentCourseDetails>()
                        .HasOne(scd => scd.CourseClass)
                        .WithMany(cc =>cc.StudentsCourseDetails)
                        .HasForeignKey(scd => new { scd.CourseCode, scd.SchoolYear })
                        .HasPrincipalKey(cc => new { cc.CourseCode, cc.SchoolYear })
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
            // Many to One StudentCourseDetails - StudentDetails
            modelBuilder.Entity<StudentCourseDetails>()
                        .HasOne(scd => scd.StudentDetails)
                        .WithMany(scd =>scd.StudentCoursesDetails)
                        .HasForeignKey(scd => new { scd.DepartmentName, scd.TC})
                        .HasPrincipalKey(sdd => new { sdd.DepartmentName, sdd.TC})
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
            //// CourseClassDate
            // Many to One CourseClassDate - ClassDate
            modelBuilder.Entity<CourseClassDate>()
                        .HasOne(ccd => ccd.ClassDate)
                        .WithMany(cd => cd.CourseClassDates)
                        .HasForeignKey(ccd => ccd.ClassDateId)
                        .IsRequired();
            // Many to One CourseClassDate - CourseClass
            modelBuilder.Entity<CourseClassDate>()
                        .HasOne(ccd => ccd.CourseClass)
                        .WithMany(cd => cd.CourseClassDates)
                        .HasForeignKey(ccd => new { ccd.CourseCode, ccd.SchoolYear})
                        .HasPrincipalKey(cc => new { cc.CourseCode, cc.SchoolYear })
                        .IsRequired();
            //// SemesterDetail
            // Many to One SemesterDetail - Department
             modelBuilder.Entity<SemesterDetail>()
                        .HasOne(sd => sd.Department)
                        .WithMany(d => d.SemestersDetails)
                        .HasForeignKey(sd => sd.DepartmentName)
                        .HasPrincipalKey(d => d.DepartmentName)
                        .IsRequired();
            //// StudentCourseSelection
            // One to One StudentCourseSelection - StudentDepDetails
             modelBuilder.Entity<StudentCourseSelection>()
                        .HasOne(sd => sd.StudentDepDetails)
                        .WithOne(d => d.StudentCourseSelection)
                        .HasForeignKey<StudentCourseSelection>(scs => new {scs.DepartmentName, scs.TC})
                        .HasPrincipalKey<StudentDepDetails>(sdd => new {sdd.DepartmentName, sdd.TC})
                        .IsRequired();
            // Many to One StudentCourseSelection - Department
             modelBuilder.Entity<StudentCourseSelect>()
                        .HasOne(scss => scss.StudentCourseSelection)
                        .WithMany(scs => scs.SelectedCourses)
                        .HasForeignKey(scs => new {scs.DepartmentName, scs.TC})
                        .HasPrincipalKey(scss => new {scss.DepartmentName, scss.TC})
                        .IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}
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
        public DbSet<StudentDepDetail> StudentDepDetails{ get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<DepartmentCourse> DepartmentCourses { get; set; }
        public DbSet<CourseDetails> CourseExplanations { get; set; }
        public DbSet<CourseClass> CourseClasses { get; set; }
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
            modelBuilder.Entity<UserAccount>().HasAlternateKey(u=> u.TC);
            // For better readability
            modelBuilder.Entity<University>().HasAlternateKey(u=> u.Name);
            modelBuilder.Entity<Faculty>().HasAlternateKey(u=> u.FacultyName);
            modelBuilder.Entity<Department>().HasAlternateKey(u=> u.DepartmentName);
            // To give back the course name instead of the id.
            modelBuilder.Entity<Course>().HasAlternateKey(u=> u.CourseName);
            // Compound Alt key to be used for Specific Course Explanation.
            modelBuilder.Entity<DepartmentCourse>().HasAlternateKey(c => new { c.CourseName, c.DepartmentName });
            // Compount Alt key to reference Lecturer, Department and Faculty at the same time.
            modelBuilder.Entity<LecturerDepDetail>().HasAlternateKey(ld => new { ld.DepartmentName, ld.LecturerTC });

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
            modelBuilder.Entity<StudentDepDetail>()
                        .HasOne(e => e.Department)
                        .WithMany(e => e.StudentDepDetails)
                        .HasForeignKey(e => e.DepartmentName)
                        .HasPrincipalKey(e => e.DepartmentName)
                        .IsRequired();
            // Many to One Student Details - StudentAccount
            modelBuilder.Entity<StudentDepDetail>()
                        .HasOne(e => e.StudentAccount)
                        .WithMany(e => e.StudentDepDetails)
                        .HasForeignKey(e => e.TC)
                        .HasPrincipalKey(e => e.TC)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Restrict);
            //// DepartmentCourse
            // One to One DepartmentCourse - Course
            modelBuilder.Entity<DepartmentCourse>()
                        .HasOne(e => e.Course)
                        .WithOne(e => e.DepartmentCourse)
                        .HasForeignKey<DepartmentCourse>(e => e.CourseName)
                        .HasPrincipalKey<Course>(e => e.CourseName)
                        .IsRequired();
            // One to One DepartmentCourse - Department
            modelBuilder.Entity<DepartmentCourse>()
                        .HasOne(e => e.Department)
                        .WithOne(e => e.DepartmentCourse)
                        .HasForeignKey<DepartmentCourse>(e => e.DepartmentName)
                        .HasPrincipalKey<Department>(e => e.DepartmentName)
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
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
            // Many to One Class - Course
            modelBuilder.Entity<CourseClass>()
                        .HasOne(e => e.DepartmentCourse)
                        .WithMany(e => e.CourseClasses)
                        .HasForeignKey(cc => new { cc.CourseName, cc.DepartmentName })
                        .HasPrincipalKey(dc => new { dc.CourseName, dc.DepartmentName })
                        .IsRequired();
            //// Lecturer Dep Details
            // Many to One LecturerDepDetail - Lecturer
            modelBuilder.Entity<LecturerDepDetail>()
                        .HasOne(ldd => ldd.Lecturer)
                        .WithMany(l => l.LecturerDepDetails)
                        .HasForeignKey(ldd => ldd.LecturerTC)
                        .HasPrincipalKey(l => l.TC)
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
            // Many to One LecturerDepDetail - Department
            modelBuilder.Entity<LecturerDepDetail>()
                        .HasOne(ldd => ldd.Department)
                        .WithMany(d => d.LecturerDepDetails)
                        .HasForeignKey(ldd => ldd.DepartmentName)
                        .HasPrincipalKey(d => d.DepartmentName)
                        .IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}
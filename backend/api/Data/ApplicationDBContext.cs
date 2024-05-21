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
        public DbSet<CourseExplanation> CourseExplanations { get; set; }
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
            modelBuilder.Entity<IdentityRole>().HasData(roles);
            // Set up alterate keys to be used as foreign keys instead of the primary ones.
            modelBuilder.Entity<User>().HasAlternateKey( u=> u.UserName);
            // Since Ids differ for each type of user account, TC can be used as fk instead.
            modelBuilder.Entity<UserAccount>().HasAlternateKey( u=> u.TC);
            // One to One UserAccount - User
            modelBuilder.Entity<UserAccount>()
                .HasOne(u => u.User)
                .WithOne(ua => ua.UserAccount)
                .HasForeignKey<UserAccount>(ua => ua.TC)
                .HasPrincipalKey<User>(u => u.UserName)
                .IsRequired();
            // Saves tables inhereted from User Account as separate tables
            modelBuilder.Entity<UserAccount>().UseTpcMappingStrategy();
            // One to One University - User for Rector
            modelBuilder.Entity<University>()
                .HasOne(u => u.Rector)
                .WithOne(uni => uni.University)
                .HasForeignKey<University>(uni => uni.RectorId)
                .IsRequired();
            // Many to One Faculty - University
            modelBuilder.Entity<Faculty>()
                .HasOne(e => e.University)
                .WithMany(e => e.Faculties)
                .HasForeignKey(e => e.UniId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            // One to One Faculty - User for Dean
            modelBuilder.Entity<Faculty>()
                .HasOne(e => e.Dean)
                .WithOne(e => e.Faculty)
                .HasForeignKey<Faculty>(e => e.DeanId)
                .IsRequired();
            // One to Many Faculty - Departments
            modelBuilder.Entity<Department>()
                .HasOne(e => e.Faculty)
                .WithMany(e => e.Departments)
                .HasForeignKey(e => e.FacultyId)
                .IsRequired();
            // One to One Department - User for HeadOfDepartment
            modelBuilder.Entity<Department>()
                .HasOne(e => e.HeadOfDepartment)
                .WithOne(e => e.Department)
                .HasForeignKey<Department>(e => e.HeadOfDepartmentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentDepDetail>()
                .HasOne(e => e.Department)
                .WithMany(e => e.StudentDepDetails)
                .HasForeignKey(e => e.DepartmentId)
                .IsRequired();

            modelBuilder.Entity<StudentDepDetail>()
                .HasOne(e => e.StudentAccount)
                .WithMany(e => e.StudentDepDetails)
                .HasForeignKey(e => e.TC)
                .HasPrincipalKey(e=> e.TC)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
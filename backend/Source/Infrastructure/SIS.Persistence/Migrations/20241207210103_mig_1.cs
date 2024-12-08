using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "UserAccountSequence");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.UniqueConstraint("AK_AspNetUsers_UserName", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "ClassDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    NumberOfClasses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassDates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseContent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.UniqueConstraint("AK_Courses_CourseName", x => x.CourseName);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdministratorAccounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [UserAccountSequence]"),
                    TC = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    RegisterDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    SchoolMail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonalMail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministratorAccounts", x => x.AccountId);
                    table.UniqueConstraint("AK_AdministratorAccounts_ID", x => x.ID);
                    table.UniqueConstraint("AK_AdministratorAccounts_TC", x => x.TC);
                    table.ForeignKey(
                        name: "FK_AdministratorAccounts_AspNetUsers_TC",
                        column: x => x.TC,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvisorAccounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [UserAccountSequence]"),
                    TC = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    RegisterDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    SchoolMail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonalMail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvisorAccounts", x => x.AccountId);
                    table.UniqueConstraint("AK_AdvisorAccounts_ID", x => x.ID);
                    table.UniqueConstraint("AK_AdvisorAccounts_TC", x => x.TC);
                    table.ForeignKey(
                        name: "FK_AdvisorAccounts_AspNetUsers_TC",
                        column: x => x.TC,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TC = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDate = table.Column<DateOnly>(type: "date", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentRequests_AspNetUsers_TC",
                        column: x => x.TC,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LecturerAccounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [UserAccountSequence]"),
                    TC = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    RegisterDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    SchoolMail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonalMail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalWorkHours = table.Column<float>(type: "real", nullable: false),
                    CurrentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerAccounts", x => x.AccountId);
                    table.UniqueConstraint("AK_LecturerAccounts_ID", x => x.ID);
                    table.UniqueConstraint("AK_LecturerAccounts_TC", x => x.TC);
                    table.ForeignKey(
                        name: "FK_LecturerAccounts_AspNetUsers_TC",
                        column: x => x.TC,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAccounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [UserAccountSequence]"),
                    TC = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    RegisterDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    SchoolMail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonalMail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CurrentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAccounts", x => x.AccountId);
                    table.UniqueConstraint("AK_StudentAccounts_ID", x => x.ID);
                    table.UniqueConstraint("AK_StudentAccounts_TC", x => x.TC);
                    table.ForeignKey(
                        name: "FK_StudentAccounts_AspNetUsers_TC",
                        column: x => x.TC,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    UniversityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrentSchoolYear = table.Column<int>(type: "int", nullable: false),
                    RectorTC = table.Column<string>(type: "nvarchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.UniversityId);
                    table.UniqueConstraint("AK_Universities_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Universities_AspNetUsers_RectorTC",
                        column: x => x.RectorTC,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [UserAccountSequence]"),
                    TC = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    RegisterDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    SchoolMail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonalMail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.AccountId);
                    table.UniqueConstraint("AK_UserAccount_ID", x => x.ID);
                    table.UniqueConstraint("AK_UserAccount_TC", x => x.TC);
                    table.ForeignKey(
                        name: "FK_UserAccount_AspNetUsers_TC",
                        column: x => x.TC,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    FacultyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FacultyName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeanTC = table.Column<string>(type: "nvarchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.FacultyID);
                    table.UniqueConstraint("AK_Faculties_FacultyName", x => x.FacultyName);
                    table.ForeignKey(
                        name: "FK_Faculties_AspNetUsers_DeanTC",
                        column: x => x.DeanTC,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Faculties_Universities_UniName",
                        column: x => x.UniName,
                        principalTable: "Universities",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BuildingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FloorNumber = table.Column<int>(type: "int", nullable: false),
                    HeadOfDepartmentTC = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    NumberOfSemesters = table.Column<int>(type: "int", nullable: false),
                    MaxYears = table.Column<int>(type: "int", nullable: false),
                    CourseSelectionStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseSelectionEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepCode = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                    table.UniqueConstraint("AK_Departments_DepartmentName", x => x.DepartmentName);
                    table.ForeignKey(
                        name: "FK_Departments_AspNetUsers_HeadOfDepartmentTC",
                        column: x => x.HeadOfDepartmentTC,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departments_Faculties_FacultyName",
                        column: x => x.FacultyName,
                        principalTable: "Faculties",
                        principalColumn: "FacultyName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TaughtSemester = table.Column<int>(type: "int", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentCourses", x => x.Id);
                    table.UniqueConstraint("AK_DepartmentCourses_CourseCode", x => x.CourseCode);
                    table.ForeignKey(
                        name: "FK_DepartmentCourses_CourseDetails_CourseDetailsId",
                        column: x => x.CourseDetailsId,
                        principalTable: "CourseDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentCourses_Courses_CourseName",
                        column: x => x.CourseName,
                        principalTable: "Courses",
                        principalColumn: "CourseName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentCourses_Departments_DepartmentName",
                        column: x => x.DepartmentName,
                        principalTable: "Departments",
                        principalColumn: "DepartmentName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LecturerDepDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TC = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    HoursPerWeek = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerDepDetails", x => x.Id);
                    table.UniqueConstraint("AK_LecturerDepDetails_DepartmentName_TC", x => new { x.DepartmentName, x.TC });
                    table.ForeignKey(
                        name: "FK_LecturerDepDetails_Departments_DepartmentName",
                        column: x => x.DepartmentName,
                        principalTable: "Departments",
                        principalColumn: "DepartmentName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturerDepDetails_LecturerAccounts_TC",
                        column: x => x.TC,
                        principalTable: "LecturerAccounts",
                        principalColumn: "TC",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SemesterDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AcademicYear = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    NumberOfObligatoryCourses = table.Column<int>(type: "int", nullable: false),
                    NumberOfSelectiveCourses = table.Column<int>(type: "int", nullable: false),
                    SelectiveCourseACTS = table.Column<int>(type: "int", nullable: false),
                    SelectiveCourseKredi = table.Column<int>(type: "int", nullable: false),
                    TotalCourses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SemesterDetails_Departments_DepartmentName",
                        column: x => x.DepartmentName,
                        principalTable: "Departments",
                        principalColumn: "DepartmentName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsDepDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TC = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegistrationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    StudentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentSchoolYear = table.Column<int>(type: "int", nullable: false),
                    CurrentSemester = table.Column<int>(type: "int", nullable: false),
                    CurrentAKTS = table.Column<int>(type: "int", nullable: false),
                    TotalAKTS = table.Column<int>(type: "int", nullable: false),
                    Gno = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsDepDetails", x => x.Id);
                    table.UniqueConstraint("AK_StudentsDepDetails_DepartmentName_TC", x => new { x.DepartmentName, x.TC });
                    table.ForeignKey(
                        name: "FK_StudentsDepDetails_Departments_DepartmentName",
                        column: x => x.DepartmentName,
                        principalTable: "Departments",
                        principalColumn: "DepartmentName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsDepDetails_StudentAccounts_TC",
                        column: x => x.TC,
                        principalTable: "StudentAccounts",
                        principalColumn: "TC",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseClasses",
                columns: table => new
                {
                    CourseClassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HourPerWeek = table.Column<int>(type: "int", nullable: false),
                    SchoolYear = table.Column<int>(type: "int", nullable: false),
                    AKTS = table.Column<int>(type: "int", nullable: false),
                    Kredi = table.Column<int>(type: "int", nullable: false),
                    MidTermValue = table.Column<int>(type: "int", nullable: false),
                    FinalValue = table.Column<int>(type: "int", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LecturerTC = table.Column<string>(type: "nvarchar(256)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseClasses", x => x.CourseClassID);
                    table.UniqueConstraint("AK_CourseClasses_CourseCode_SchoolYear", x => new { x.CourseCode, x.SchoolYear });
                    table.ForeignKey(
                        name: "FK_CourseClasses_DepartmentCourses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "DepartmentCourses",
                        principalColumn: "CourseCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseClasses_LecturerAccounts_LecturerTC",
                        column: x => x.LecturerTC,
                        principalTable: "LecturerAccounts",
                        principalColumn: "TC",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourseSelections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TC = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourseSelections", x => x.Id);
                    table.UniqueConstraint("AK_StudentCourseSelections_DepartmentName_TC", x => new { x.DepartmentName, x.TC });
                    table.ForeignKey(
                        name: "FK_StudentCourseSelections_StudentsDepDetails_DepartmentName_TC",
                        columns: x => new { x.DepartmentName, x.TC },
                        principalTable: "StudentsDepDetails",
                        principalColumns: new[] { "DepartmentName", "TC" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseClassDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SchoolYear = table.Column<int>(type: "int", nullable: false),
                    ClassDateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseClassDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseClassDates_ClassDates_ClassDateId",
                        column: x => x.ClassDateId,
                        principalTable: "ClassDates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseClassDates_CourseClasses_CourseCode_SchoolYear",
                        columns: x => new { x.CourseCode, x.SchoolYear },
                        principalTable: "CourseClasses",
                        principalColumns: new[] { "CourseCode", "SchoolYear" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsCourseDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TC = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttendanceFulfilled = table.Column<bool>(type: "bit", nullable: true),
                    MidTermAnnouncment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MidTerm = table.Column<int>(type: "int", nullable: true),
                    FinalAnnouncment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Final = table.Column<int>(type: "int", nullable: true),
                    Grade = table.Column<float>(type: "real", nullable: true),
                    ComplementRight = table.Column<bool>(type: "bit", nullable: true),
                    ComplementAnnouncment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Complement = table.Column<int>(type: "int", nullable: true),
                    SchoolYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsCourseDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentsCourseDetails_CourseClasses_CourseCode_SchoolYear",
                        columns: x => new { x.CourseCode, x.SchoolYear },
                        principalTable: "CourseClasses",
                        principalColumns: new[] { "CourseCode", "SchoolYear" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentsCourseDetails_StudentsDepDetails_DepartmentName_TC",
                        columns: x => new { x.DepartmentName, x.TC },
                        principalTable: "StudentsDepDetails",
                        principalColumns: new[] { "DepartmentName", "TC" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentSelectedCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TC = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSelectedCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSelectedCourses_StudentCourseSelections_DepartmentName_TC",
                        columns: x => new { x.DepartmentName, x.TC },
                        principalTable: "StudentCourseSelections",
                        principalColumns: new[] { "DepartmentName", "TC" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19711b04-c998-4039-aff8-70120ca1ea73", null, "Advisor", "ADVISOR" },
                    { "2c125a95-0b26-4b32-a7d9-968dfc26b5a5", null, "Student", "STUDENT" },
                    { "42d06818-8cf6-4861-bf0b-deee1bd797c5", null, "Lecturer", "LECTURER" },
                    { "81c06ef6-9d4e-43c3-9692-b0b010a48da5", null, "Admin", "ADMIN" },
                    { "9e95ca2e-f17c-42be-8f71-65bef96c142a", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdministratorAccounts_ID",
                table: "AdministratorAccounts",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdministratorAccounts_PersonalMail",
                table: "AdministratorAccounts",
                column: "PersonalMail",
                unique: true,
                filter: "[PersonalMail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AdministratorAccounts_Phone",
                table: "AdministratorAccounts",
                column: "Phone",
                unique: true,
                filter: "[Phone] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AdministratorAccounts_SchoolMail",
                table: "AdministratorAccounts",
                column: "SchoolMail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorAccounts_ID",
                table: "AdvisorAccounts",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorAccounts_PersonalMail",
                table: "AdvisorAccounts",
                column: "PersonalMail",
                unique: true,
                filter: "[PersonalMail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorAccounts_Phone",
                table: "AdvisorAccounts",
                column: "Phone",
                unique: true,
                filter: "[Phone] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorAccounts_SchoolMail",
                table: "AdvisorAccounts",
                column: "SchoolMail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClassDates_Day_Time_NumberOfClasses",
                table: "ClassDates",
                columns: new[] { "Day", "Time", "NumberOfClasses" },
                unique: true,
                filter: "[Day] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CourseClassDates_ClassDateId",
                table: "CourseClassDates",
                column: "ClassDateId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseClassDates_CourseCode_SchoolYear_ClassDateId",
                table: "CourseClassDates",
                columns: new[] { "CourseCode", "SchoolYear", "ClassDateId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseClasses_CourseCode_SchoolYear",
                table: "CourseClasses",
                columns: new[] { "CourseCode", "SchoolYear" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseClasses_LecturerTC",
                table: "CourseClasses",
                column: "LecturerTC");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseName",
                table: "Courses",
                column: "CourseName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentCourses_CourseCode",
                table: "DepartmentCourses",
                column: "CourseCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentCourses_CourseDetailsId",
                table: "DepartmentCourses",
                column: "CourseDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentCourses_CourseName",
                table: "DepartmentCourses",
                column: "CourseName");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentCourses_DepartmentName_CourseName_TaughtSemester",
                table: "DepartmentCourses",
                columns: new[] { "DepartmentName", "CourseName", "TaughtSemester" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentName",
                table: "Departments",
                column: "DepartmentName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepCode",
                table: "Departments",
                column: "DepCode",
                unique: true,
                filter: "[DepCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FacultyName",
                table: "Departments",
                column: "FacultyName");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_HeadOfDepartmentTC",
                table: "Departments",
                column: "HeadOfDepartmentTC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentRequests_TC",
                table: "DocumentRequests",
                column: "TC");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_Address",
                table: "Faculties",
                column: "Address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_DeanTC",
                table: "Faculties",
                column: "DeanTC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_FacultyName",
                table: "Faculties",
                column: "FacultyName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_Mail",
                table: "Faculties",
                column: "Mail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_PhoneNumber",
                table: "Faculties",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_UniName_FacultyName",
                table: "Faculties",
                columns: new[] { "UniName", "FacultyName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_WebSite",
                table: "Faculties",
                column: "WebSite",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LecturerAccounts_ID",
                table: "LecturerAccounts",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LecturerAccounts_PersonalMail",
                table: "LecturerAccounts",
                column: "PersonalMail",
                unique: true,
                filter: "[PersonalMail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerAccounts_Phone",
                table: "LecturerAccounts",
                column: "Phone",
                unique: true,
                filter: "[Phone] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerAccounts_SchoolMail",
                table: "LecturerAccounts",
                column: "SchoolMail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LecturerDepDetails_TC_DepartmentName",
                table: "LecturerDepDetails",
                columns: new[] { "TC", "DepartmentName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SemesterDetails_DepartmentName_Semester",
                table: "SemesterDetails",
                columns: new[] { "DepartmentName", "Semester" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAccounts_ID",
                table: "StudentAccounts",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAccounts_PersonalMail",
                table: "StudentAccounts",
                column: "PersonalMail",
                unique: true,
                filter: "[PersonalMail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAccounts_Phone",
                table: "StudentAccounts",
                column: "Phone",
                unique: true,
                filter: "[Phone] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAccounts_SchoolMail",
                table: "StudentAccounts",
                column: "SchoolMail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseSelections_DepartmentName_TC",
                table: "StudentCourseSelections",
                columns: new[] { "DepartmentName", "TC" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourseDetails_CourseCode_SchoolYear",
                table: "StudentsCourseDetails",
                columns: new[] { "CourseCode", "SchoolYear" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourseDetails_DepartmentName_TC",
                table: "StudentsCourseDetails",
                columns: new[] { "DepartmentName", "TC" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsDepDetails_TC_DepartmentName",
                table: "StudentsDepDetails",
                columns: new[] { "TC", "DepartmentName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentSelectedCourses_DepartmentName_TC_CourseCode",
                table: "StudentSelectedCourses",
                columns: new[] { "DepartmentName", "TC", "CourseCode" },
                unique: true,
                filter: "[DepartmentName] IS NOT NULL AND [TC] IS NOT NULL AND [CourseCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Universities_Address",
                table: "Universities",
                column: "Address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Universities_Mail",
                table: "Universities",
                column: "Mail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Universities_Name",
                table: "Universities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Universities_PhoneNumber",
                table: "Universities",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Universities_RectorTC",
                table: "Universities",
                column: "RectorTC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Universities_WebSite",
                table: "Universities",
                column: "WebSite",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_ID",
                table: "UserAccount",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_PersonalMail",
                table: "UserAccount",
                column: "PersonalMail",
                unique: true,
                filter: "[PersonalMail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_Phone",
                table: "UserAccount",
                column: "Phone",
                unique: true,
                filter: "[Phone] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_SchoolMail",
                table: "UserAccount",
                column: "SchoolMail",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdministratorAccounts");

            migrationBuilder.DropTable(
                name: "AdvisorAccounts");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CourseClassDates");

            migrationBuilder.DropTable(
                name: "DocumentRequests");

            migrationBuilder.DropTable(
                name: "LecturerDepDetails");

            migrationBuilder.DropTable(
                name: "SemesterDetails");

            migrationBuilder.DropTable(
                name: "StudentsCourseDetails");

            migrationBuilder.DropTable(
                name: "StudentSelectedCourses");

            migrationBuilder.DropTable(
                name: "UserAccount");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ClassDates");

            migrationBuilder.DropTable(
                name: "CourseClasses");

            migrationBuilder.DropTable(
                name: "StudentCourseSelections");

            migrationBuilder.DropTable(
                name: "DepartmentCourses");

            migrationBuilder.DropTable(
                name: "LecturerAccounts");

            migrationBuilder.DropTable(
                name: "StudentsDepDetails");

            migrationBuilder.DropTable(
                name: "CourseDetails");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "StudentAccounts");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Universities");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropSequence(
                name: "UserAccountSequence");
        }
    }
}

using api;
using api.Data;
using api.Interfaces;
using api.Models;
using api.Repositories;
using api.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddIdentity<User, IdentityRole>(options => {
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 12;
    options.User.RequireUniqueEmail = false;
}).AddEntityFrameworkStores<ApplicationDBContext>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
#pragma warning disable CS8604 // Possible null reference argument.
    options.TokenValidationParameters = new TokenValidationParameters{
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"]))
    };
#pragma warning restore CS8604 // Possible null reference argument.
});

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IStudentAccountRepository, StudentAccountRepository>();
builder.Services.AddScoped<ILecturerAccountRepository, LecturerAccountRepository>();
builder.Services.AddScoped<IAdvisorAccountRepository, AdvisorAccountRepository>();
builder.Services.AddScoped<IAdministratorAccountRepository, AdministratorAccountRepository>();
builder.Services.AddScoped<IUniversityRepository, UniversityRepository>();
builder.Services.AddScoped<IFacultyRepository, FacultyRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IStudentDepDetailsRepository, StudentDepDetailsRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IDepartmentCourseRepository, DepartmentCourseRepository>();
builder.Services.AddScoped<ICourseDetailsRepository, CourseDetailsRepository>();
builder.Services.AddScoped<ILecturerDepDetailsRepository, LecturerDepDetailsRepository>();
builder.Services.AddScoped<ICourseClassRepository, CourseClassRepository>();
builder.Services.AddScoped<IStudentCourseDetailsRepostiory, StudentCourseDetailsRepository>();
builder.Services.AddScoped<IClassDateRepository, ClassDateRepository>();
builder.Services.AddScoped<ICourseClassDateRepository, CourseClassDateRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
           builder =>
           {
               builder.WithOrigins("http://localhost:3000") // Allow your frontend's origin
                       .AllowAnyMethod() // Allow any HTTP method (GET, POST, PUT, DELETE)
                       .AllowAnyHeader(); // Allow all headers
           });
});

var app = builder.Build();

SeedData(app);

async void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        await service.SeedDataContext();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

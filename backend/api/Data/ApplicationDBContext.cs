using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions){}
        public DbSet<User> Users { get; set; }
        public DbSet<LogInInfo> LogInInfos { get; set; }
    }
}
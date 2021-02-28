using Microsoft.EntityFrameworkCore;

using AspNetCoreWebApiIntro.Models;

namespace AspNetCoreWebApiIntro.Data
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppContext(DbContextOptions<AppContext> opt) : base(opt)
        {

        }
    }
}

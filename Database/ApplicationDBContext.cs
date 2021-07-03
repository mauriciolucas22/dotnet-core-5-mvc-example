using Microsoft.EntityFrameworkCore;

using dotnet_mvc.Models;
namespace dotnet_mvc.Database
{
    public class ApplicationDBContext : DbContext
    {

        public DbSet<Business> Businesses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
    }
}
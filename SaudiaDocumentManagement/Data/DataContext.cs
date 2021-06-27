using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SaudiaDocumentManagment;

namespace SaudiaDocumentManagement.Models
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
        public DbSet<category> category { get; set; }
        public DbSet<files> files { get; set; }
        public DbSet<activity_list> activity_List { get; set; }

    }
}
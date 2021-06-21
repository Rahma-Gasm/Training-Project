using Microsoft.EntityFrameworkCore;
using SaudiaDocumentManagment;

namespace SaudiaDocumentManagement.Models
{
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {

    }

    public DbSet<admin> admin { get; set; }
    public DbSet<category> category { get; set; }
    public DbSet<files> files { get; set; }
    public DbSet<activity_list> activity_List { get; set; }
           
}
}
using Microsoft.EntityFrameworkCore;

namespace RosterApp.Models
{
    public class RosterContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public RosterContext(DbContextOptions options) : base(options)
        {

        }
    }
}

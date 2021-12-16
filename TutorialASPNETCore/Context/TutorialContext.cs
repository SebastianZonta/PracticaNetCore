using Microsoft.EntityFrameworkCore;
using TutorialASPNETCore.Models;

namespace TutorialASPNETCore.Context
{
    public class TutorialContext : DbContext

    {
        public DbSet<Employee> employees { get; set; }
        public TutorialContext(DbContextOptions<TutorialContext> options) : base(options)
        {

        }
       
    }
}

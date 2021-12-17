
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TutorialASPNETCore.Models;

namespace TutorialASPNETCore.Context
{
    public class TutorialContext : IdentityDbContext

    {
        public DbSet<Employee> employees { get; set; }
        public TutorialContext(DbContextOptions<TutorialContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }
       

    }
}

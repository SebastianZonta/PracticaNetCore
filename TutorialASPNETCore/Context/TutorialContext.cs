using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using TutorialASPNETCore.Models;

namespace TutorialASPNETCore.Context
{
    public class TutorialContext : IdentityDbContext<ApplicationUser>
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

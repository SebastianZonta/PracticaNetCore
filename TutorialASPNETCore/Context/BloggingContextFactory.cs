using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TutorialASPNETCore.Context
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<TutorialContext>
    {
        public TutorialContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TutorialContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-U2M982S\\SQLEXPRESS;Initial Catalog=tutorial;Integrated Security=True");

            return new TutorialContext(optionsBuilder.Options);
        }
    }
}

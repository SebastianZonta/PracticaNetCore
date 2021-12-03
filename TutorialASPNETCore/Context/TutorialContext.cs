using Microsoft.EntityFrameworkCore;

namespace TutorialASPNETCore.Context
{
    public class TutorialContext : DbContext
    {
        public TutorialContext(DbContextOptions<TutorialContext> options) : base(options)
        {

        }
    }
}

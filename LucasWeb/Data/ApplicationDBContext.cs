using LucasWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace LucasWeb.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {

        }
        public DbSet<Category> Category { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace CoreAndFood.Models
{
    public class Context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=MER-NB-00890; database=coreandfood; integrated security=true;");
        }
        public DbSet<Food>? Foods { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<AdminModel> Admins { get; set; }
        public DbSet<User> Users { get; set; }

    }
}

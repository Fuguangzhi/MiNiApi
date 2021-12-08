using Microsoft.EntityFrameworkCore;

using MiNIAPi.Entites;

using System.Reflection.Emit;

namespace MiNIAPi.EFCoreMange
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.Entity<User>().HasData(new List<User>() { new User { Id = 1, Name = "测试" } });

    }
}

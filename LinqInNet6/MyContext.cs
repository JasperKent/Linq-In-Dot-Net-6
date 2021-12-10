using Microsoft.EntityFrameworkCore;

namespace LinqInNet6
{
    public class MyContext : DbContext
    {  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var file = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\LinqInNet6.db";

            optionsBuilder.UseSqlite($"Data Source={file}");
        }

        public DbSet<Person> People { get; set; } = null!;
    }
}

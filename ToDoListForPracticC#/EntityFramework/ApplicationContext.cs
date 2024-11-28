using Microsoft.EntityFrameworkCore;
using ToDoListForPracticC_.Models;

namespace ToDoListForPracticC_.EntityFramework
{
    public class ApplicationContext : DbContext
    {
        public DbSet<TaskItem> itemsDb => Set<TaskItem>();

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }
    }
}

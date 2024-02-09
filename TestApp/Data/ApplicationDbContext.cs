using Microsoft.EntityFrameworkCore;
using TestApp.Models;

namespace TestApp.Data
{
    // The inherited class (Dbcontext) is the root class of the Entity Framework code through which
    // we can access Entity Framework
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options)
        {
            
        }
        // In the <> put the class name which contains the column names of the DB you want to create
        // DbSet is used to create a table from the class. The name of the table is Categories.
        public DbSet<Category> Categories { get; set; }


        // To add data in the SQL 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Thriller", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Comedy", DisplayOrder = 3 }
                );
        }
    }
}

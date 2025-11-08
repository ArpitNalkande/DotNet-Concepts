using Microsoft.EntityFrameworkCore;

namespace DbOperationsEFCore.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) {
        }    


        public DbSet<Book> Books { get; set; } // Represents the Books table in the database Book is the name for model which we created in Book.cs
        public DbSet<Language> Languages { get; set; } // Represents the Languages table in the database // Language is the name for model which we created in Language.cs
    }
}

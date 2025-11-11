// useCase of the file is to make the connection with DB 
using Microsoft.EntityFrameworkCore;
namespace DbOperationsEFCore.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) {
        }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API configurations can be added here if needed
            modelBuilder.Entity<Currency>()
                .HasData(
                    new Currency { Id =1, currency = "USD", Description = "United States Dollar", title = "US Dollar" },
                    new Currency { Id =2, currency = "EUR", Description = "Euro", title = "Euro" },
                    new Currency { Id =3, currency = "GBP", Description = "British Pound Sterling", title = "British Pound" }
                );

            modelBuilder.Entity<Language>()
               .HasData(
                   new Language { Id =1, Title = "USD", Description = "Hindi" },
                   new Language { Id =2, Title = "EUR", Description = "English" },
                   new Language { Id =3, Title = "GBP", Description = "Telgu" }
               );
        }

        public DbSet<Book> Books { get; set; } // Represents the Books table in the database // Book is the name for model which we created in Book.cs
        public DbSet<Language> Languages { get; set; } 
        // Represents the Languages table in the database 
        // Language is the name for model which we created in Language.cs

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<BookPrice> BookPrices { get; set; }
        
       
    }
}

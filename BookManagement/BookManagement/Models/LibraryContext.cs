using System;
using BookManagement.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }
        public LibraryContext() { }



        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<Author> Authors { get; set; }
        public DbSet<BookRequest> BookRequests { get; set; }
        public DbSet<RequestDetail> RequestDetails { get; set; }
        public DbSet<User> Users { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder option)
        // {
        //     option.UseSqlServer("Server = LAPTOP-O71PKJ1L\\SQLEXPRESS;Database = Library;Trusted_Connection=True;MultipleActiveResultSets= true");
        // }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>()
            .Property(f => f.BookId)
            .ValueGeneratedOnAdd();
            builder.Entity<Category>()
            .Property(f => f.CategoryId)
            .ValueGeneratedOnAdd();
            builder.Entity<User>()
            .Property(f => f.UserId)
            .ValueGeneratedOnAdd();

            builder.Entity<BookRequest>()
           .Property(f => f.RequestId)
           .ValueGeneratedOnAdd();
            builder.Entity<RequestDetail>()
          .Property(f => f.Id)
          .ValueGeneratedOnAdd();
            base.OnModelCreating(builder);

            builder.Entity<BookRequest>()
            .Property(b => b.Status)
            .HasDefaultValue((Status)0);

            builder.Entity<Category>().HasData(new Category
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = "Novel"

            });
            builder.Entity<Category>().HasData(new Category
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = "Sciene"

            });
       
            
            builder.Entity<User>().HasData(new User
            {
                UserId = Guid.NewGuid(),
                Username = "admin",
                Password = "123",
                DoB = DateTime.Now.AddYears(-20),
                Name = "Nguyen Van A",
                Role = (Role)0
            });
            builder.Entity<User>().HasData(new User
            {
                UserId = Guid.NewGuid(),
                Username = "user",
                Password = "123",
                DoB = DateTime.Now.AddYears(-30),
                Name = "Nguyen Van B",
                Role = (Role)1
            });

        }

    }
}
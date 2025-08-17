using DataAccessLayer.Entities;
using DataAccessLayer.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<BookCopy> BookCopies { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<Ebook> Ebooks { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<LibraryBook> LibraryBooks { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Book)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(bg => bg.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

            
        }

    }
}

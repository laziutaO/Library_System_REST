using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class DatabaseSeeder
    {
        public static async Task SeedEbooksAsync(LibraryDbContext context)
        {
            if (context.Ebooks.Any()) return;

            var genres = new List<Genre>
        {
            new Genre { Id = Guid.NewGuid(), Name = "Fantasy" },
            new Genre { Id = Guid.NewGuid(), Name = "Science Fiction" },
            new Genre { Id = Guid.NewGuid(), Name = "Mystery" },
            new Genre { Id = Guid.NewGuid(), Name = "Romance" }
        };
            context.Genres.AddRange(genres);

            var authors = new List<Author>
        {
            new Author { Id = Guid.NewGuid(), Name = "J.R.R. Tolkien" },
            new Author { Id = Guid.NewGuid(), Name = "Isaac Asimov" },
            new Author { Id = Guid.NewGuid(), Name = "Agatha Christie" },
            new Author { Id = Guid.NewGuid(), Name = "Jane Austen" }
        };
            context.Authors.AddRange(authors);

            var books = new List<Ebook>
        {
            new Ebook
            {
                Id = Guid.NewGuid(),
                Title = "The Lord of the Rings",
                ISBN = "978-0261102385",
                Publisher = "Allen & Unwin",
                Year = 1954,
                PagesCount = 1178,
                Description = "Epic high fantasy novel.",
                CoverImageUrl = "https://example.com/lotr.jpg",
                FileUrl = "/ebooks/LOTR.pdf",
                BookAccessType = Enums.BookAccessType.Free,
                BookAuthors = new List<BookAuthor>(),
                BookGenres = new List<BookGenre>()
            },
            new Ebook
            {
                Id = Guid.NewGuid(),
                Title = "Foundation",
                ISBN = "978-0553293357",
                Publisher = "Gnome Press",
                Year = 1951,
                PagesCount = 255,
                Description = "Science fiction novel.",
                CoverImageUrl = "https://example.com/foundation.jpg",
                FileUrl = "/ebooks/Foundation.pdf",
                BookAccessType= Enums.BookAccessType.Paid,
                BookAuthors = new List<BookAuthor>(),
                BookGenres = new List<BookGenre>()
            }
        };

            books[0].BookAuthors.Add(new BookAuthor { Id = Guid.NewGuid(), Author = authors[0], Book = books[0] });
            books[0].BookGenres.Add(new BookGenre { Id = Guid.NewGuid(), Genre = genres[0], Book = books[0] });

            books[1].BookAuthors.Add(new BookAuthor { Id = Guid.NewGuid(), Author = authors[1], Book = books[1] });
            books[1].BookGenres.Add(new BookGenre { Id = Guid.NewGuid(), Genre = genres[1], Book = books[1] });

            context.Ebooks.AddRange(books);

            await context.SaveChangesAsync();
        }

        public static void SeedUsers(LibraryDbContext context, IPasswordHelper passwordHasher)
        {
            if (!context.Users.Any())
            {
                var users = DataGenerator.GetBogusUserData()
                    .Select(u => {
                        u.HashedPassword = passwordHasher.GeneratePassword(u, u.HashedPassword);
                        return u; 
                    }).ToList();
                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}

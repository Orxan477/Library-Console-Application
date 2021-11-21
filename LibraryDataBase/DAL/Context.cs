using LibraryDataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryDataBase.DAL
{
    class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-0EH6MSG;Initial Catalog=BookLibrary;"
            + "Integrated Security=true;");
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
    }
}

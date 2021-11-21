using LibraryDataBase.Business.Absract;
using LibraryDataBase.DAL;
using LibraryDataBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryDataBase.Controller
{
    class BookController : IController<Book>
    {
        public void SelectName(string name)
        {
            using (var db = new Context())
            {
                
                var books = db.Books
                    .Include(n => n.BookAuthors).ThenInclude(n => n.Author)
                    .Include(n => n.BookGenres).ThenInclude(n => n.Genre)
                    .Where(n => n.Name.Trim().ToLower().Contains(name.Trim().ToLower()));
                bool isExist = books.Any(n => n.Name.Trim().ToLower() == name.Trim().ToLower());
                if (isExist)
                {
                    foreach (var book in books)
                    {
                        foreach (var bookAuthor in book.BookAuthors)
                        {
                            Console.WriteLine($"Book Id:{bookAuthor.Book.Id}\nBook Name:{bookAuthor.Book.Name}");
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Not Found Book");
                    Console.WriteLine("----------------");
                }        
            }
        }
        public void GetInfo()
        {
            using (var db = new Context())
            {
                var getBook = db.Books
                    .Include(n => n.BookAuthors).ThenInclude(n => n.Author)
                    .Include(n => n.BookGenres).ThenInclude(n => n.Genre);

                foreach (var book in getBook)
                {
                    Console.WriteLine($"Book Id:{book.Id}");
                    Console.WriteLine($"Book Name:{book.Name}");

                    foreach (var bookAuthor in book.BookAuthors)
                    {
                        Console.WriteLine($"Author Name:{bookAuthor.Author.Name}");
                    }
                    foreach (var bookGenre in book.BookGenres)
                    {
                        Console.WriteLine($"Genre Name:{bookGenre.Genre.Name}\n");
                    }
                }
            }
        }

        public void Remove(string name)
        {
            using (var db = new Context())
            {
                Book book = db.Books.Where(x => x.Name == name).Single<Book>();
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }

        public void Update(string name)
        {
            using (var db = new Context())
            {
                Book book = db.Books.Where(x => x.Name == name).Single<Book>();
                db.Books.Update(book);               
                db.SaveChanges();
            }
        }
    }
}

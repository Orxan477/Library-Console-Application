using LibraryDataBase.Business.Absract;
using LibraryDataBase.DAL;
using LibraryDataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LibraryDataBase.Controller
{
    class AuthorController : IController<Author>
    {
        public void GetInfo()
        {
            using (var db = new Context())
            {
                var author = db.BookAuthors
                    .Include(n => n.Author).Include(n => n.Book);
                foreach (var bookAuthor in author)
                {
                    Console.WriteLine($"Book Id:{bookAuthor.Book.Id}\nBook Name:{bookAuthor.Book.Name}\n");
                }
            }
        }



        public void SelectName(string name)
        {
            using (var db = new Context())
            {

                var author = db.BookAuthors
                    .Include(n => n.Author).Include(n => n.Book)
                    .Where(n => n.Author.Name.Trim().ToLower().Contains(name.Trim().ToLower()));
                bool isExist = author.Any(n => n.Author.Name.Trim().ToLower() == name.Trim().ToLower());
                if (isExist)
                {
                    foreach (var bookAuthor in author)
                    {
                        Console.WriteLine($"{bookAuthor.Book.Id}. {bookAuthor.Book.Name}");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Not Found Author");
                    Console.WriteLine("----------------");
                }



            }
        }

        public void Remove(string name)
        {
            try
            {
                using (var db = new Context())
                {
                    Author author = db.Authors.Where(x => x.Name == name).Single<Author>();
                    db.Authors.Remove(author);
                    db.SaveChanges();
                    Console.WriteLine($"{name} is Remove");
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine($"Not Found {name}");
                Console.WriteLine("----------------");
            }
            
        }
        public void Update(string name)
        {
            try
            {
                using (var db = new Context())
                {
                    Author author = db.Authors.Where(x => x.Name == name).Single<Author>();
                    db.Authors.Update(author);
                    db.SaveChanges();
                    Console.WriteLine($"{name} is Update");
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine($"Not Found {name}");
                Console.WriteLine("----------------");
            }
           
        }
    }
}

using LibraryDataBase.Business.Absract;
using LibraryDataBase.DAL;
using LibraryDataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LibraryDataBase.Controller
{
    class GenreController : IController<Genre>
    {
        public void GetInfo()
        {
            using (var db = new Context())
            {
                var genre = db.BookGenres
                    .Include(n => n.Genre);
                foreach (var genreName in genre)
                {
                    Console.WriteLine($"Genre Id:{genreName.Genre.Id}\nGenre Name:{genreName.Genre.Name}\n");
                }
            }
        }

        public void SelectName(string name)
        {
            using (var db = new Context())
            {
                var genre = db.BookGenres
                    .Include(n => n.Genre).Include(n => n.Book)
                    .Where(n => n.Genre.Name.Trim().ToLower().Contains(name.Trim().ToLower()));
                bool isExist = genre.Any(n => n.Genre.Name.Trim().ToLower() == name.Trim().ToLower());
                if (isExist)
                {
                    foreach (var genreName in genre)
                    {
                        Console.WriteLine($"Book Id:{genreName.Book.Id}\nBook Name:{genreName.Book.Name}");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Not Found Genre");
                    Console.WriteLine("----------------");
                }
                //var author = db.Authors.Single(a => a.Name == "Muellifli");
                //Console.WriteLine(author.Name);
            }
        }
        public void Remove(string name)
        {
            try
            {
                using (var db = new Context())
                {
                    Genre genre = db.Genres.Where(x => x.Name == name).Single<Genre>();
                    db.Genres.Remove(genre);
                    db.SaveChanges();
                    Console.WriteLine($"{name} Removed");
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
                    Genre genre = db.Genres.Where(x => x.Name == name).Single<Genre>();
                    db.Genres.Update(genre);
                    db.SaveChanges();
                    Console.WriteLine($"{name} Updated");
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

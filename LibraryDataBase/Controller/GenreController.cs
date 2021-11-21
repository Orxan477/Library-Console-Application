using LibraryDataBase.Business.Absract;
using LibraryDataBase.DAL;
using LibraryDataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                foreach (var genreName in genre)
                {
                    Console.WriteLine($"Book Id:{genreName.Book.Id}\nBook Name:{genreName.Book.Name}");
                }
                //var author = db.Authors.Single(a => a.Name == "Muellifli");
                //Console.WriteLine(author.Name);
            }
        }
        public void Remove(Genre entity)
        {
            using (var db = new Context())
            {
                db.Remove<Genre>(entity);
                db.SaveChanges();
            }
        }
        public void Update(Genre entity)
        {
            using (var db = new Context())
            {
                db.Update<Genre>(entity);
                db.SaveChanges();
            }
        }
    }
}

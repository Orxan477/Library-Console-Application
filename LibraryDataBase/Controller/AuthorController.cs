﻿using LibraryDataBase.Business.Absract;
using LibraryDataBase.DAL;
using LibraryDataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                    Console.WriteLine($"Book Id:{bookAuthor.Author.Id}\nGenre Name:{bookAuthor.Author.Name}\n");
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
                
                    foreach (var bookAuthor in author)
                    {
                        Console.WriteLine($"{bookAuthor.Book.Id}. {bookAuthor.Book.Name}");
                    }
                
                
            }
        }

        public void Remove(string name)
        {
            using(var db=new Context())
            {
                Author author = db.Authors.Where(x => x.Name == name).Single<Author>();
                db.Authors.Update(author);
                db.SaveChanges();
            }
        }
        public void Update(string name)
        {
            using (var db = new Context())
            {
                Author author = db.Authors.Where(x => x.Name == name).Single<Author>();
                db.Authors.Update(author);
                db.SaveChanges();
            }
        }
    }
}

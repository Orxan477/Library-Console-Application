using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryDataBase.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }
        public List<BookGenre> BookGenres { get; set; }
    }
}

using LibraryDataBase.Controller;
using LibraryDataBase.DAL;
using LibraryDataBase.Models;
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace LibraryDataBase
{
    class Program
    {
        static readonly BookController bookController = new BookController();
        static readonly AuthorController authorController = new AuthorController();
        static readonly GenreController genreController = new GenreController();
        static void Main(string[] args)
        {
            Console.WriteLine(@"                                   ██╗    ██╗███████╗██╗      ██████╗ ██████╗ ███╗   ███╗███████╗
                                   ██║    ██║██╔════╝██║     ██╔════╝██╔═══██╗████╗ ████║██╔════╝
                                   ██║ █╗ ██║█████╗  ██║     ██║     ██║   ██║██╔████╔██║█████╗  
                                   ██║███╗██║██╔══╝  ██║     ██║     ██║   ██║██║╚██╔╝██║██╔══╝  
                                   ╚███╔███╔╝███████╗███████╗╚██████╗╚██████╔╝██║ ╚═╝ ██║███████╗
                                    ╚══╝╚══╝ ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝     ╚═╝╚══════╝
                                                                                                                      ");
            Console.WriteLine("------------------");
        TryAgain:
            try
            {
                Console.WriteLine("Select Option:");
                Console.WriteLine("1.Add Book\n2.Get Information\n3.Update\n4.Remove\n0.Exit\n------------------");
                string opinput = Console.ReadLine();
                int number = int.Parse(opinput);
                switch (number)
                {
                    case 1:
                        Console.Write("Enter Book Name: ");
                        string bookName = Console.ReadLine();
                        Console.Write("Enter Author Name: ");
                        string authorName = Console.ReadLine();
                        Console.WriteLine("------------");
                        genreController.GetInfo();
                        Console.Write("Enter Genre GenreId: ");
                        string genreName = Console.ReadLine();                    
                        AddBook(bookName, authorName,genreName);
                        Console.WriteLine("---------------------");
                        Console.WriteLine("Book added");
                        break;
                    case 2:
                        Console.WriteLine("-----------------");
                    Info:
                        Console.WriteLine("Select Option");
                        Console.WriteLine("1.All Books Information\n2.Book search\n3.Author search" +
                                          "\n4.Genre search\n0.Home Page\n--------------");
                        string info = Console.ReadLine();
                        int infonumber = int.Parse(info);
                        switch (infonumber)
                        {
                            case 1:
                                Console.WriteLine("----------------------");
                                bookController.GetInfo();
                                Console.WriteLine("----------------------");
                                goto Info;
                            case 2:
                                Console.Write("Enter name: ");
                                string searchName = Console.ReadLine();
                                bookController.SelectName(searchName);
                                Console.WriteLine("----------------------");
                                goto Info;
                            case 3:
                                Console.Write("Enter author: ");
                                string searchAuthor = Console.ReadLine();
                                authorController.SelectName(searchAuthor);
                                Console.WriteLine("----------------------");
                                goto Info;
                            case 4:
                                Console.Write("Enter genre: ");
                                string searchgenre = Console.ReadLine();
                                genreController.SelectName(searchgenre);
                                Console.WriteLine("----------------------");
                                goto Info;
                            case 0:
                                Console.WriteLine("Home Page");
                                goto TryAgain;
                            default:
                                Console.Clear();
                                Console.WriteLine("Incorrect Input");
                                Console.WriteLine("Please correct input!!!");
                                goto Info;
                        }
                    case 3:
                        Update:
                        Console.WriteLine("--------------");
                        Console.WriteLine("1.Book\n2.Author\n3.Genre\n0.Home Page");
                        string update = Console.ReadLine();
                        int updateNumber = int.Parse(update);
                        switch (updateNumber)
                        {
                            case 1:
                                Console.WriteLine("Book Name");
                                string updateBookName = Console.ReadLine();
                                bookController.Update(updateBookName);
                                break;
                            case 2:
                                Console.WriteLine("Author Name");
                                string updateAuthorName = Console.ReadLine();
                                authorController.Update(updateAuthorName);
                                break;
                            case 3:
                                Console.WriteLine("Genre Name");
                                string updateGenreName = Console.ReadLine();
                                genreController.Update(updateGenreName);
                                break;
                            case 0:
                                Console.WriteLine("Home Page");
                                goto TryAgain;
                            default:
                                Console.Clear();
                                Console.WriteLine("Incorrect Input");
                                Console.WriteLine("Please correct input!!!");
                                goto Update;
                        }
                        break;
                    case 4:
                        remove:
                        Console.WriteLine("--------------");
                        Console.WriteLine("1.Book\n2.Author\n3.Genre\n0.Home page");
                        string remove = Console.ReadLine();
                        int removeNumber = int.Parse(remove);
                        switch (removeNumber)
                        {
                            case 1:
                                string name = Console.ReadLine();
                                bookController.Remove(name);
                                break;
                            case 2:
                                string author = Console.ReadLine();
                                authorController.Remove(author);
                                break;
                            case 3:
                                string genre = Console.ReadLine();
                                genreController.Remove(genre);
                                break;
                            case 0:
                                Console.WriteLine("");
                                goto TryAgain;
                            default:
                                Console.Clear();
                                Console.WriteLine("Incorrect Input");
                                Console.WriteLine("Please correct input!!!");
                                goto remove;
                        }
                        break;
                    case 0:
                        Console.WriteLine("Log Out");
                        break;
                    
                    default:
                        Console.Clear();
                        Console.WriteLine("Incorrect Input");
                        Console.WriteLine("Please correct input!!!");
                        goto TryAgain;
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Incorrect Input");
                Console.WriteLine("Please correct input!!!");
                goto TryAgain;

            }
        }
        //Kitab elave etmek 
        public static void AddBook(string name, string author, string genre)
        {
            using (var contex = new Context())
            {
                var book = new Book
                {
                    Name = name,
                };
                var authorr = new Author
                {
                    Name = author
                };
                var genree = new Genre
                {
                    Name = genre
                };
                book.BookAuthors = new List<BookAuthor>
                {
                  new BookAuthor
                  {
                    Author = authorr,
                    Book = book,
                  }
                };
                book.BookGenres = new List<BookGenre>
                {
                  new BookGenre
                  {
                      Book = book,
                      Genre=genree,
                  }
                };
                contex.Books.Add(book);
                contex.SaveChanges();
            }

        }


    }
}
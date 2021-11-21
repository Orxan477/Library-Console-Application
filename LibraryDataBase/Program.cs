using LibraryDataBase.Controller;
using LibraryDataBase.DAL;
using LibraryDataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LibraryDataBase
{
    class Program
    {
        static readonly BookController bookController = new BookController();
        static readonly AuthorController authorController = new AuthorController();
        static readonly GenreController genreController = new GenreController();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome");
            Console.WriteLine("------------------");
        TryAgain:
            try
            {
                Console.WriteLine("Secim edin:");
                Console.WriteLine("1.Add Book\n2.Get Information\n3.Update\n4.Remove\n5.Exit\n------------------");
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
                        //
                        Console.Write("Enter Genre GenreId: ");
                        string genreName = Console.ReadLine();
                        //
                        AddBook(bookName, authorName, genreName);
                        Console.WriteLine("---------------------");
                        Console.WriteLine("Book added");
                        break;
                    case 2:
                        Console.WriteLine("-----------------");
                    Info:
                        Console.WriteLine("1.All Books Information\n2.Book search\n3.Author search" +
                                          "\n4.Genre search\n5.Home Page\n--------------");
                        string info = Console.ReadLine();
                        int infonumber = int.Parse(info);
                        switch (infonumber)
                        {
                            case 1:
                                Console.WriteLine("----------------------");
                                bookController.GetInfo();
                                break;
                            case 2:
                                Console.Write("Enter name: ");
                                string searchName = Console.ReadLine();
                                bookController.SelectName(searchName);
                                break;
                            case 3:
                                Console.Write("Enter author: ");
                                string searchAuthor = Console.ReadLine();
                                authorController.SelectName(searchAuthor);
                                break;
                            case 4:
                                Console.Write("Enter genre: ");
                                string searchgenre = Console.ReadLine();
                                genreController.SelectName(searchgenre);
                                break;
                            case 5:
                                Console.WriteLine("Home Page");
                                goto TryAgain;
                            default:
                                Console.Clear();
                                Console.WriteLine("Incorrect Input");
                                Console.WriteLine("Please correct input!!!");
                                goto Info;
                        }

                        break;
                    #region MyRegion
                    case 3:
                        Console.WriteLine("--------------");
                        Console.WriteLine("1.Book\n2.Author\n3.Genre");
                        string opinputt = Console.ReadLine();
                        int n = int.Parse(opinputt);
                        switch (n)
                        {
                            case 1:
                                string name = Console.ReadLine();
                                bookController.Update(name);
                                break;
                            default:
                                break;
                        }
                        break;
                    case 4:
                        Console.WriteLine("--------------");
                        Console.WriteLine("1.Book\n2.Author\n3.Genre");
                        string remove = Console.ReadLine();
                        int removenumber = int.Parse(remove);
                        switch (removenumber)
                        {
                            case 1:
                                string name = Console.ReadLine();
                                bookController.Remove(name);
                                break;
                            default:
                                break;
                        }
                        break;
                    #endregion
                    case 5:
                        return;
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
        //Kitab elave etmek ---completed
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



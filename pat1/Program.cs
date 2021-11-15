using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pat1
{
    public class Book
    {
        public string Author { get; }
        public string Title { get; }
        public string Gener { get; }
        public Book(string title, string author, string gener)
        {
            Author = author;
            Title = title;
            Gener = gener;
        }
    }
    public class HomeLibrary
    {
        private List<Book> books;
        public IEnumerable<Book> Books
        {
            get
            {
                foreach (var b in books)
                    yield return b;
            }
        }
        public int BooksCount
        {
            get
            {
                return books.Count;
            }
        }
        public HomeLibrary()
        {
            books = new List<Book>();
        }
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public void AddBook(List<Book> books)
        {
            this.books.AddRange(books);
        }
        public void DeleteBook(Book book)
        {
            books.Remove(books.First(b => b.Author == book.Author && b.Gener == book.Gener && b.Title == book.Title));
        }
        public Book FindFirst(Predicate<Book> match)
        {
            return books.Find(match);
        }
        public List<Book> FindAll(Predicate<Book> match)
        {
            return books.FindAll(match);
        }
        public void Sort(Comparison<Book> comparison)
        {
            books.Sort(comparison);
        }
    }
    public static class EqualsExtenstion
    {
        public static bool isEquals(this Book[] a, Book[] b)
        {
            if (a.Length != b.Length)
                return false;
            bool isEqualBooks = false;
            for (int i = 0; i < a.Length; i++)
            {
                isEqualBooks = a[i].Title == b[i].Title &&
                               a[i].Author == b[i].Author &&
                               a[i].Gener == b[i].Gener;
                if (!isEqualBooks)
                    return false;
            }
            return true;
        }
    }
    class Program
    {
        // 18
        public static HomeLibrary homeLibrary = new HomeLibrary();
        public static int CompareBooksByAuthor(Book x, Book y)
        {
            if (x == null)
            {
                if (y == null)
                    return 0;
                else
                    return -1;
            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {
                    int retval = x.Author.CompareTo(y.Author);
                    if (retval != 0)
                    {
                        return retval;
                    }
                    else
                    {
                        return x.Author.CompareTo(y.Author);
                    }
                }
            }
        }
        public static int CompareBooksByTitle(Book x, Book y)
        {
            if (x == null)
            {
                if (y == null)
                    return 0;
                else
                    return -1;
            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {
                    int retval = x.Title.CompareTo(y.Title);
                    if (retval != 0)
                    {
                        return retval;
                    }
                    else
                    {
                        return x.Title.CompareTo(y.Title);
                    }
                }
            }
        }
        public static int CompareBooksByGener(Book x, Book y)
        {
            if (x == null)
            {
                if (y == null)
                    return 0;
                else
                    return -1;
            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {
                    int retval = x.Gener.CompareTo(y.Gener);
                    if (retval != 0)
                    {
                        return retval;
                    }
                    else
                    {
                        return x.Gener.CompareTo(y.Gener);
                    }
                }
            }
        }
        public static void PrintBooks()
        {
            if (homeLibrary.BooksCount == 0)
                Console.WriteLine("*empty*");
            foreach (var book in homeLibrary.Books)
                Console.WriteLine($"{book.Title} - {book.Author} - {book.Gener}");
            Console.WriteLine();
        }
        public static void ConsoleReader()
        {
            void HandleCommand(string command)
            {
                var args = command.Split(' ');
                var cmd = args[0].ToLower();
                switch (cmd)
                {
                    case "add":
                        {
                            homeLibrary.AddBook(new Book(args[1], args[2], args[3]));
                            break;
                        }
                    case "addsm":
                        {
                            var books = new List<Book>();
                            for (int i = 0; i < Convert.ToInt32(args[1]); i++)
                                books.Add(new Book(args[2 + i * 3], args[3 + i * 3], args[4 + i * 3]));

                            homeLibrary.AddBook(books);
                            break;
                        }
                    case "del":
                        {
                            homeLibrary.DeleteBook(new Book(args[1], args[2], args[3]));
                            break;
                        }
                    case "sort":
                        {
                            for (int a = args.Length - 1; a > 0; a--)
                                switch (args[a].ToLower())
                                {
                                    case "title":
                                        homeLibrary.Sort(CompareBooksByTitle);
                                        break;
                                    case "author":
                                        homeLibrary.Sort(CompareBooksByAuthor);
                                        break;
                                    case "gener":
                                        homeLibrary.Sort(CompareBooksByGener);
                                        break;
                                    default:
                                        break;
                                }
                        }
                        break;
                    case "find":
                        {
                            Book finded = null;
                            switch (args[1].ToLower())
                            {
                                case "title":
                                    finded = homeLibrary.FindFirst(b => b.Title == args[2]);
                                    break;
                                case "author":
                                    finded = homeLibrary.FindFirst(b => b.Author == args[2]);
                                    break;
                                case "gener":
                                    finded = homeLibrary.FindFirst(b => b.Gener == args[2]);
                                    break;
                                default:
                                    break;
                            }
                            if (finded != null)
                                Console.WriteLine($"{finded.Author} - {finded.Title} - {finded.Gener}");
                            else
                                Console.WriteLine("not found");
                            break;
                        }
                    case "show":
                        {
                            PrintBooks();
                        }
                        break;
                    default:
                        {
                            Console.WriteLine($"<author> - Имя автора, \"author\" - Параметр \n\r\n\r" +
                              $"add          Добавить книгу                            <title> <author> <gener> \n\r" +
                              $"addsm        Добавить несколько книг                   <count of books> <title> <author> <gener>... \n\r" +
                              $"del (first)  Удалить первую подходящую                 <title> <author> <gener> \n\r" +
                              $"sort         Сорировать по одному или нескольким полям \"title\" OR \"author\" OR \"gener\"...\n\r" +
                              $"find (first) Поиск по..                                \"title\" <title> OR \"author\" <author> OR \"gener\" <gener>\n\r" +
                              $"show         Показать все книги\n\r" +
                              $"exit         Выйти\n\r");
                        }
                        break;
                }
            }
            string input = "";
            while (input != "exit")
            {
                HandleCommand(input);
                input = Console.ReadLine();
            }
        }
        static void Test()
        {
            homeLibrary = new HomeLibrary();

            var book1 = new Book("Книга1", "БАвтор01", "Сказки");
            var book2 = new Book("Книга99", "Автор99", "Комедия");
            var book3 = new Book("Книга3", "Автор03", "Детектив");
            PrintBooks();

            homeLibrary.AddBook(book3);
            homeLibrary.AddBook(book2);
            homeLibrary.AddBook(book1);
            homeLibrary.AddBook(book3);
            PrintBooks();

            if (!homeLibrary.Books.ToArray().isEquals(new Book[] { book3, book2, book1, book3 }))
                throw new Exception("Test failed");

            homeLibrary.DeleteBook(book3);
            PrintBooks();

            if (!homeLibrary.Books.ToArray().isEquals(new Book[] { book2, book1, book3 }))
                throw new Exception("Test failed");

            homeLibrary.Sort(CompareBooksByGener);
            homeLibrary.Sort(CompareBooksByAuthor);
            homeLibrary.Sort(CompareBooksByTitle);
            PrintBooks();

            if (!homeLibrary.Books.ToArray().isEquals(new Book[] { book1, book3, book2 }))
                throw new Exception("Test failed");

            homeLibrary.DeleteBook(homeLibrary.FindFirst(b => b.Author == "Автор99"));
            PrintBooks();

            if (!homeLibrary.Books.ToArray().isEquals(new Book[] { book1, book3 }))
                throw new Exception("Test failed");

            homeLibrary = new HomeLibrary();
        }
        static void Main(string[] args)
        {
            Test();
            Console.Clear();

            ConsoleReader();
        }
    }
}
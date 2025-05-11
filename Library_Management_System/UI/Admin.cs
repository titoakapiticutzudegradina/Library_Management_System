using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System.Domain;
using Library_Management_System.Service;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library_Management_System.UI
{
    class Admin
    {
        static BookService service = new();

        public void Main()
        {

            while (true)
            {
                Console.WriteLine("\nLibrary Managment System");
                Console.WriteLine("1.Add a book");
                Console.WriteLine("2.View all books");
                Console.WriteLine("3.Update a book");
                Console.WriteLine("4.Delete a book");
                Console.WriteLine("5.Search for a book by the title or the author");
                Console.WriteLine("6.Search for books by the quantity");
                Console.WriteLine("0.Exit");
                Console.WriteLine("Choose: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1": AddBook(); break;
                    case "2": ViewBooks(); break;
                    case "3": UpdateBook(); break;
                    case "4": DeleteBook(); break;
                    case "5": Search(); break;
                    case "6": SearchBetween(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid option"); break;
                }
            }
        }

        static void ViewBooks()
        {
            var books = service.GetAll();
            foreach (var book in books)
                Console.WriteLine($"{book.ID}: {book.Title} by {book.Author} | Available: {book.Quantity}");
        }

        static void AddBook()
        {
            var id = new Random().Next(1000, 9999);
            Console.WriteLine("Title: "); var title = Console.ReadLine();
            Console.WriteLine("Author: "); var author = Console.ReadLine();
            Console.WriteLine("Quantity: "); var quantity = int.Parse(Console.ReadLine());

            var book = new Book(id, title, author, quantity);

            service.Add(book);
            ViewBooks();
        }

        static void UpdateBook()
        {
            Console.WriteLine("Id of the book to be updated: "); var id = int.Parse(Console.ReadLine());
            Console.WriteLine("New Title: "); var title = Console.ReadLine();
            Console.WriteLine("New Author: "); var author = Console.ReadLine();
            Console.WriteLine("New Quantity: "); var quantity = int.Parse(Console.ReadLine());

            var book = new Book(id, title, author, quantity);

            service.Update(book);
            ViewBooks();
        }

        static void DeleteBook()
        {
            Console.WriteLine("Id of the book to be deleted: "); var id = int.Parse(Console.ReadLine());

            service.Delete(id);
            ViewBooks();
        }

        static void Search()
        {
            Console.WriteLine("Chooose by which cristeria do you want to search (0-by title 1-by author):  ");
            var id = int.Parse(Console.ReadLine());
            Console.WriteLine("Write the text you want to search by: ");
            var text = Console.ReadLine();
            var searched = service.Search(id, text);
            foreach (var book in searched)
                Console.WriteLine($"{book.ID}: {book.Title} by {book.Author} | Available: {book.Quantity}");

        }

        static void SearchBetween()
        {
            Console.WriteLine("Provide the lower and upper bound by which you want to search the books(if the lower bound is bigger than the upper bound it will take only the lower bound as a criteria): ");
            var lowerBound = int.Parse(Console.ReadLine());
            var upperBound = int.Parse(Console.ReadLine());
            var searched = service.SearchBetween(lowerBound, upperBound);
            foreach (var book in searched)
                Console.WriteLine($"{book.ID}: {book.Title} by {book.Author} | Available: {book.Quantity}");
        }

    }
}


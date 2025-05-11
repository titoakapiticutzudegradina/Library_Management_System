using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System.Domain;
using Library_Management_System.Service;


namespace Library_Management_System.UI
{
    class User
    {
        static BookService service = new();
        static UsersService usersService = new();
        public void Main()
        {
            while (true)
            {
                Console.WriteLine("\nHello user! Your options are: ");
                Console.WriteLine("1.View all books you have");
                Console.WriteLine("2.View all books in the library");
                Console.WriteLine("3.Lend a book");
                Console.WriteLine("4.Return a book");
                Console.WriteLine("0.Exit");
                Console.WriteLine("Choose: ");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1": ViewBooks(); break;
                    case "2": ViewLibraryBooks(); break;
                    case "3": LendBook(); break;
                    case "4": ReturnBook(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid option"); break;
                }
            }
        }

        static void ViewBooks()
        {
            Console.WriteLine("Enter your name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            var password = Console.ReadLine();
            if (usersService.Login(name, password))
            {
                Console.WriteLine($"User {name} logged in successfully!");
                var user = usersService.GetUser(name, password);
                var books = usersService.GetAllBooks(user);
                foreach (var book in books)
                    Console.WriteLine($"{book.ID}: {book.Title} by {book.Author} | Available: {book.Quantity}");

            }
            else
                Console.WriteLine("Invalid credentials");
        }

        static void ViewLibraryBooks()
        {
            var books = service.GetAll();
            foreach (var book in books)
                Console.WriteLine($"{book.ID}: {book.Title} by {book.Author} | Available: {book.Quantity}");
        }

        static void LendBook()
        {
            Console.WriteLine("Enter your name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            var password = Console.ReadLine();
            if (usersService.Login(name, password))
            {
                Console.WriteLine($"User {name} logged in successfully!");
                var user = usersService.GetUser(name, password);
                Console.WriteLine("Id of the book to be lent: ");
                var id = int.Parse(Console.ReadLine());
                if (usersService.LendBook(id, user))
                    Console.WriteLine("Book lent.");
                else
                    Console.WriteLine("Cannot lent - out of stock.");

            }
            else
                Console.WriteLine("Invalid credentials");
        }

        static void ReturnBook()
        {
            Console.WriteLine("Enter your name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            var password = Console.ReadLine();
            if (usersService.Login(name, password))
            {
                Console.WriteLine($"User {name} logged in successfully!");
                var user = usersService.GetUser(name, password);
                Console.WriteLine("Id of the book to be lent: ");
                var id = int.Parse(Console.ReadLine());
                if (usersService.ReturnBook(id, user))
                    Console.WriteLine("Book returned.");
                else
                    Console.WriteLine("Return not allowed- already fully returned.");

            }
            else
                Console.WriteLine("Invalid credentials");
        }

    }
}



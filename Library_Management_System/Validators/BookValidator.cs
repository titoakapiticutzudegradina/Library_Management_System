using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System.Domain;

namespace Library_Management_System.Validators
{
    internal class BookValidator
    {
        public bool ValidateBook(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
            {
                Console.WriteLine("Title cannot be empty");
                return false;
            }
            if (string.IsNullOrWhiteSpace(book.Author))
            {
                Console.WriteLine("Author cannot be empty");
                return false;
            }
            if (book.Quantity < 0)
            {
                Console.WriteLine("Quantity cannot be negative");
                return false;
            }
            return true;
        }
    }
}

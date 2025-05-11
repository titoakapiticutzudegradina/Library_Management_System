using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System.Domain;
using Library_Management_System.Repository;
using Library_Management_System.Validators;

namespace Library_Management_System.Service
{
    internal class BookService : IBookService
    {
        private readonly BookRepository _repo = new();
        private readonly BookValidator _validator = new();

        public List<Book> GetAll() => _repo.GetAll();

        public Book GetById(int id) => _repo.GetAll().FirstOrDefault(b => b.ID == id);

        public void Add(Book book)
        {
            if (!_validator.ValidateBook(book))
            {
                throw new Exception("Invalid book");
            }
            var books = _repo.GetAll();
            books.Add(book);
            _repo.SaveAll(books);
        }

        public void Update(Book bookToBeUpdated)
        {
            if (!_validator.ValidateBook(bookToBeUpdated))
            {
                throw new Exception("Invalid book");
            }
            var books = _repo.GetAll();
            var index = books.FindIndex(b => b.ID == bookToBeUpdated.ID);
            if(index != -1)
            {
                books[index].Title = bookToBeUpdated.Title;
                books[index].Author = bookToBeUpdated.Author;
                books[index].Quantity = bookToBeUpdated.Quantity;
                _repo.SaveAll(books);
            }
        }

        public void Delete(int id)
        {
            var books = _repo.GetAll();
            var book = books.FirstOrDefault(b => b.ID == id);
            if (book != null)
            {
                books.Remove(book);
                _repo.SaveAll(books);
            }
            else
            {
                throw new Exception("Book not found");
            }
        }

        public List<Book> Search(int id, string text) {
            //0=tile 1=author

            switch (id)
            {
                //Search through the repo to get all the books by the title
                case 0:
                    var booksTitle = _repo.GetAll();
                    List<Book> searchedByTitle = new List<Book>();
                    foreach (var book in booksTitle)
                    {
                        if (book.Title.Contains(text))
                            searchedByTitle.Add(book);
                    }
                    return searchedByTitle;
                //Search through the repo to get all the books by the author
                case 1:
                    var booksAuthor = _repo.GetAll();
                    List<Book> searchedByAuthor = new List<Book>();
                    foreach (var book in booksAuthor)
                    {
                        if (book.Author.Contains(text))
                            searchedByAuthor.Add(book);
                    }
                    return searchedByAuthor;
                //Exception when the id of the case is out of range
                default:
                    throw new ArgumentOutOfRangeException(nameof(id), id, "Invalid option selected.");
            }

        }

        public List<Book> SearchBetween(int lowerBound, int upperBound)
        {
            if (lowerBound < 0 || upperBound < 0)
            {
                throw new ArgumentOutOfRangeException("The quantity cannot be negative");
            }
            if (lowerBound % 1 != 0 || upperBound % 1 != 0)
            {
                throw new ArgumentOutOfRangeException("The quantity must be an integer");
            }
            var books = _repo.GetAll();
            List<Book> searchBetween = new List<Book>();
            foreach(var book in books)
            {
                if(lowerBound > upperBound)
                {
                    if(book.Quantity >= lowerBound)
                        searchBetween.Add(book);
                }
                else
                {
                    if(book.Quantity <= upperBound && book.Quantity >= lowerBound)
                        searchBetween.Add(book);
                }
            }
            return searchBetween;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System.Domain;

namespace Library_Management_System.Service
{
    internal interface IBookService
    {
        List<Book> GetAll();                                        //Get all the books in the repository
        Book GetById(int id);                                       //Get a book from the repository from its Id
        void Add(Book book);                                        //Add a new book to the repository
        void Update(Book book);                                     //Update an existant book; the id of the book given as a parameter should be the same as the book that needs to be updated
        void Delete(int id);                                        //Delete a book from the repository
        List<Book> Search(int id, string text);                     //Search form books by the title or author 
        List<Book> SearchBetween(int lowerBound, int upperBound);   //Search for books by the quantity
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System.Domain;

namespace Library_Management_System.Service
{
    internal interface IUsersService
    {
        void Register(string name, string password);                //Register a new user
        bool Login(string name, string password);                   //Login a user
        Users GetUser(string name,string password);                 //Get a user by name
        void LendBook(int id, Users user);                          //Lend a book to a user
        void ReturnBook(int id, Users user);                        //Return a book to the library
        List<Book> GetAllBooks(Users user);                         //Get all books borrowed by a user
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System.Domain;
using Library_Management_System.Repository;
using Library_Management_System.Validators;

namespace Library_Management_System.Service
{
    internal class UsersService
    {
        private readonly UsersRepository _repo = new();
        private readonly BookRepository _bookRepo = new();
        private readonly UserValidator _validator = new();

        public void Register(string name, string password)
        {
            var users = _repo.GetAll();
            var user = new Users(name, password);
            if (!_validator.ValidateUser(user))
            {
                throw new Exception("Invalid user");
            }
            users.Add(user);
            _repo.SaveAll(users);
        }

        public bool Login(string name, string password)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }
            var users = _repo.GetAll();
            var user = users.FirstOrDefault(u => u.Name == name && u.Password == password);
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public Users GetUser(string name, string password)
        {
            var users = _repo.GetAll();
            var user = users.FirstOrDefault(u => u.Name == name && u.Password == password);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public bool LendBook(int id, Users user)
        {
            if(!_validator.ValidateUser(user))
            {
                throw new Exception("Invalid user");
            }
            var books = _bookRepo.GetAll();
            var book = books.FirstOrDefault(b => b.ID == id);
            if (book != null && book.Quantity > 0)
            {
                book.Quantity -= 1;
                var users2 = _repo.GetAll();
                foreach (var u in users2)
                {
                    if (u.Name == user.Name && u.Password == user.Password)
                    {
                        u.BorrowedBooks.Add(book);
                    }
                }
                _bookRepo.SaveAll(books);
                _repo.SaveAll(users2);
                return true;
            }
            return false;
        }

        public bool ReturnBook(int id, Users user)
        {
            if (!_validator.ValidateUser(user))
            {
                throw new Exception("Invalid user");
            }
            var books = _bookRepo.GetAll();
            var book = books.FirstOrDefault(b => b.ID == id);
            var users = _repo.GetAll();
            if (book != null)
            {
                foreach(var b in user.BorrowedBooks)
                {
                    if(b.ID == id)
                    {
                        var bookToBeReturned = user.BorrowedBooks.FirstOrDefault(b => b.ID == id);
                        user.BorrowedBooks.Remove(bookToBeReturned);
                        _repo.Update(user);
                        book.Quantity += 1;
                        _bookRepo.SaveAll(books);
                        return true;
                    }
                }
            }
            return false;
        }

        public List<Book> GetAllBooks(Users user)
        {
            if (!_validator.ValidateUser(user))
            {
                throw new Exception("Invalid user");
            }
            return user.BorrowedBooks;
        }
        
    }
}

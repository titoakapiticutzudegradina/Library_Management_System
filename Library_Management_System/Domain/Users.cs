using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Domain
{
    internal class Users
    {
        private string name;
        private string password;
        private List<Book> borrowedBooks = new List<Book>();

        public Users(string _name, string _password)
        {
            name = _name;
            password = _password;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public List<Book> BorrowedBooks
        {
            get { return borrowedBooks; }
            set { borrowedBooks = value; }
        }
    }
}

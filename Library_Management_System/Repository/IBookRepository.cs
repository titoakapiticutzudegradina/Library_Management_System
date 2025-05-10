using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System.Domain;

namespace Library_Management_System.Repository
{
    internal interface IBookRepository
    {
        List<Book> GetAll();            //Get all the books from the JSON file  
        void SaveAll(List<Book> books); //Save all the books in the JSON file
    }
}

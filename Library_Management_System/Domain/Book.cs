using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Domain
{
    internal class Book
    {
        private int id;
        private string title;
        private string author;
        private int quantity;


        //Constructor
        public Book(int _id, string _title, string _author, int _quantity)
        {
            id = _id;
            title = _title;
            author = _author;
            quantity = _quantity;
        }

        //Getters adn Setters
        public int ID
        { 
            get { return id; } 
            set { id = value;} 
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value;}
        }
    }
}

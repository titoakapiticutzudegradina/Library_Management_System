using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Library_Management_System.Domain;
using Newtonsoft.Json;

namespace Library_Management_System.Repository
{
    internal class BookRepository : IBookRepository
    {
        private const string FilePath = "books.json";

        public List<Book> GetAll()
        {
            if(!File.Exists(FilePath)) return new List<Book>();
            var json  = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<Book>>(json) ?? new List<Book>();
        }

        public void SaveAll(List<Book> books)
        {
            var json = JsonConvert.SerializeObject(books,Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
    }
}

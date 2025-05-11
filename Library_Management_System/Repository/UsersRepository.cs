using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System.Domain;
using Newtonsoft.Json;

namespace Library_Management_System.Repository
{
    internal class UsersRepository : IUsersRepository
    {
        private const string FilePath = "users.json";
        public List<Users> GetAll()
        {
            if (!File.Exists(FilePath)) return new List<Users>();
            var json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<Users>>(json) ?? new List<Users>();
        }
        public void SaveAll(List<Users> users)
        {
            var json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }

        public void Update(Users updatedUser)
        {
            var users = GetAll();
            var index = users.FindIndex(u => u.Name == updatedUser.Name && u.Password == updatedUser.Password);

            if (index != -1)
            {
                users[index] = updatedUser;
                SaveAll(users);
            }
            else
            {
                throw new Exception($"User with Name '{updatedUser.Name}' and matching Password not found.");
            }
        }
    }
}

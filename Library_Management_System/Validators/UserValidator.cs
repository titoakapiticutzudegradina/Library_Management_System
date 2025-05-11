using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System.Domain;
using Library_Management_System.Repository;

namespace Library_Management_System.Validators
{
    internal class UserValidator
    {
        private readonly UsersRepository _repo = new();
        public bool ValidateUser(Users user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
            {
                Console.WriteLine("Name cannot be empty");
                return false;
            }
            if (string.IsNullOrWhiteSpace(user.Password))
            {
                Console.WriteLine("Password cannot be empty");
                return false;
            }
            foreach (var u in _repo.GetAll())
            {
                if (u.Name == user.Name)
                {
                    Console.WriteLine("User already exists");
                    return false;
                }
            }
            return true;

        }
    }
}

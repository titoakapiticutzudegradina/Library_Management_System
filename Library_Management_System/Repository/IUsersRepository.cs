using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System.Domain;

namespace Library_Management_System.Repository
{
    internal interface IUsersRepository
    {
        List<Users> GetAll();               //Get all the users from the JSON file  
        void SaveAll(List<Users> userss);   //Save all the userss in the JSON file
        void Update(Users updatedUser);     //Update the user in the JSON file
    }
}

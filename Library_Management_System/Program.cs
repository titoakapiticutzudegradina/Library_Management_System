using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System.Domain;
using Library_Management_System.Service;
using Library_Management_System.UI;
using static System.Reflection.Metadata.BlobBuilder;


class Program
{
    static UsersService service = new();

    static void Main()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("\nWho are you? ");
                Console.WriteLine("1. I am an admin");
                Console.WriteLine("2. I am a user");
                Console.WriteLine("3. Register");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Choose: ");
                var input = Console.ReadLine();
                var admin = new Admin();
                var user = new User();
                switch (input)
                {
                    case "1": admin.Main(); break;
                    case "2": user.Main(); break;
                    case "3": Register(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid option"); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }  
    }
    static void Register()
    {
        Console.WriteLine("Enter your name: ");
        var name = Console.ReadLine();
        Console.WriteLine("Enter your password: ");
        var password = Console.ReadLine();
        service.Register(name, password);
        Console.WriteLine($"User {name} registered successfully!");
    }
}

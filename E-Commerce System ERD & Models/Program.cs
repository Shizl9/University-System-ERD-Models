using E_Commerce_System_ERD___Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace E_Commerce_System_ERD___Models
{
    
    public class Program
    {
       
        public static EcommerceContext context = new EcommerceContext();
        //Register a New User 
        public static void RegisterUser()
        {
            Console.WriteLine("\n=== Register New User ===");

            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();
           
            string passwordHash = password;

            Console.Write("Enter full name: ");
            string fullName = Console.ReadLine();

            Console.Write("Enter phone number (optional, press Enter to skip): ");
            string phone = Console.ReadLine();

            Console.Write("Enter address (optional, press Enter to skip): ");
            string address = Console.ReadLine();

            
            User newUser = new User
            {
                username= username,
                email= email,
                passwordHash= passwordHash,
                fullName=fullName,
                phoneNumber=phone,
                address=address,
                registrationDate = DateTime.Now,
                isActive = true
            };

            context.Users.Add(newUser);

            context.SaveChanges();

            //.userId is now populated with the DB-assigned Id
            Console.WriteLine("New user ID: " + newUser.userId);
        }

        //add a New Product to a Category 
        public static void AddProduct()
        {
            Console.WriteLine("\n=== Add a New Product to a Category ===");

            Console.WriteLine("view all Caticories");
           foreach( Category c in context.Categories)
            {
                Console.WriteLine($"id:{c.categoryId}, Name:{c.categoryName},Description:{c.description}");
            }

            Console.WriteLine("Enter catigory Id:");
            int catigoryId = int.Parse(Console.ReadLine());

           
                                                             
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}

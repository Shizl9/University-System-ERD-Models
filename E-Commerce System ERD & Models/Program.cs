using E_Commerce_System_ERD___Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Threading.Channels;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            //view all Caticories

            List<Category> allCatigories = context.Categories.ToList();

            foreach (Category c in context.Categories)
            {
                Console.WriteLine($"id:{c.categoryId}, Name:{c.categoryName},Description:{c.description}");
            }

            //user choose catigory
            Console.WriteLine("Enter catigory Id:");
            int catigoryId = int.Parse(Console.ReadLine());

            //enter product details:
            Console.WriteLine("Enter product name:");
            string productName = Console.ReadLine();

            Console.WriteLine("Enter price:");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter stock Quantity:");
            int stockQuantity = int.Parse(Console.ReadLine());

            //add new product:
            Product newProduct = new Product
            {
                productName=productName,
                price=price,
                stockQuantity=stockQuantity,
                createdAt=DateTime.Now,
                isAvailable=true
            };

            context.Products.Add(newProduct);
            context.SaveChanges();

            Console.WriteLine($"new product Id:{newProduct.productId}");

        }


        //03 Place Order
        public static void PlaceOrder()
        {
            //make sure that usere is there:
            Console.WriteLine("Enter user Id:");
            int userId = int.Parse(Console.ReadLine());

            bool validuserTD = context.Users.Any(d => d.userId == userId);

            //if user not found print this:
            if (validuserTD == false)
            {
                Console.WriteLine("No users founded.");
                return;
            }

            //enter order details:
            Order newOrder = new Order
            {
                userId=userId,
                orderDate = DateTime.Now,
                status = "pending",
                totalAmount = 0
            };

            //add order:
            context.Orders.Add(newOrder);
            context.SaveChanges();
            Console.WriteLine($"new order Id:{newOrder.orderId}");

            //find selected prduct:
            Console.WriteLine("Enter product Id:");
            int productId = int.Parse(Console.ReadLine());

            Product selectedProduct = context.Products.FirstOrDefault(p => p.productId == productId);

            if (selectedProduct == null)
            {
                Console.WriteLine("Not found product.");
                return;
            }

            Console.WriteLine("Enter quantity:");
            int quantity = int.Parse(Console.ReadLine());

            //check stock:
            if (selectedProduct.stockQuantity < quantity)
            {
                Console.WriteLine("Not enough stock.");
                return;
            }
            
            //calculate total amount:
            decimal totalAmount = selectedProduct.price * quantity;

            //create orderItem:
            
            OrderItem newOrderItem = new OrderItem
            {
                orderId = newOrder.orderId,
                productId=productId,
                quantity=quantity,
                unitPrice = selectedProduct.price
            };

            context.OrderItems.Add(newOrderItem);
            

            newOrder.totalAmount += totalAmount;
            selectedProduct.stockQuantity-=quantity;

            context.SaveChanges();












        }

        //04Write a Product Review Easy 
        public static void WriteProductReview()
        {
            //view all users to choose user id:
            List<User> users = context.Users.ToList();

            foreach (User u in context.Users)
            {
                Console.WriteLine($"id:{u.userId}");
            }

            //choose user id:
            Console.WriteLine("Enter user Id:");
            int userId = int.Parse(Console.ReadLine());

            if (users ==null)
            {
                Console.WriteLine("No users found.");
                return;
            }

            //view all product to choose product id:
            List<Product> products = context.Products.ToList();

            //choose product id:
            Console.WriteLine("Enter product Id:");
            int prodductId = int.Parse(Console.ReadLine());

            if (products == null)
            {
                Console.WriteLine("No products found.");
                return;
            }

            //ask user to enter ratings from 1-5:
            Console.WriteLine("Enter rating :");
            int rating = int.Parse(Console.ReadLine());

            if (rating < 1 || rating > 5)
            {
                Console.WriteLine("incorrect rating.");
                return;
            }

            //ask user to write commernt
            Console.WriteLine("Enter comment:");
            string comment = Console.ReadLine();

            Review newReview = new Review
            {
                userId=userId,
                productId=prodductId,
                rating=rating,
                comment=comment,
                reviewDate=DateTime.Now
            };

            //add review 
            context.Reviews.Add(newReview);
            context.SaveChanges();

            Console.WriteLine($"review Id:{newReview.reviewId}");


        }

        //05Update Product Price and Availability
        public static void UpdateProductPriceandAvailability()
            {
            //ask to enter producct id :
            Console.WriteLine("Enter prduct Id:");
            int productId = int.Parse(Console.ReadLine());

            //find product Id:
           Product products = context.Products.FirstOrDefault(p=>p.productId==productId);

            if (products != null)
            {
                // ask about th new price & availability:
                Console.WriteLine("Enter a new price:");
                decimal UpdatedPrice = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter an availability of this product:");
                bool AvailableProduct = bool.Parse(Console.ReadLine());

                products.price = UpdatedPrice;
                products.isAvailable = AvailableProduct;
                context.SaveChanges();

                Console.WriteLine("product updated successfuly.");
            }




        }

        //06Cancel an Order
        public static void CancelanOrder()
        {
            //ask user to enter order id that he wanted to cancel:
            Console.WriteLine("Enter Order Id:");
            int orderId = int.Parse(Console.ReadLine());

            //find this order :
            Order orders = context.Orders.FirstOrDefault(o => o.orderId == orderId);

            if (orders == null)
            {
                Console.WriteLine("Order not found.");
                return;
            }

            //check order's status
            if (orders.status != "pending")
            {
                Console.WriteLine("You cannot cancel this order.");
                return;
            }

            //git all order items of this order:
            OrderItem orderItem = context.OrderItems.FirstOrDefault(o => o.orderId == orderId);

            if (orderItem != null)
            {
                //take product id:
                Console.WriteLine("Enter product Id:");
                int productId = int.Parse(Console.ReadLine());

                //find product id:
                Product product = context.Products.FirstOrDefault(p => p.productId == productId);

                orderItem.productId = productId;
                product.stockQuantity += orderItem.quantity;

                //after retrn the stock set status as cancelled:
                orders.status = "cancelled.";
                context.SaveChanges();

                Console.WriteLine("order cancelled successfuly.");
            }
        }

        //07Delete a Review

        public static void DeleteReview()
        {
            //ask user to enter review id that he wanted to delete:
            Console.WriteLine("Enter review Id:");
            int reviewId = int.Parse(Console.ReadLine());

            //find this id
            Review review = context.Reviews.FirstOrDefault(r => r.reviewId == reviewId);
            if (review != null)
            {
                context.Reviews.Remove(review);//deleted
                context.SaveChanges();
                Console.WriteLine("Review deleted.");
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}

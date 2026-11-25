using Project_E_Commerce_oop.Models;
using Project_E_Commerce_oop.Payments;
using Project_E_Commerce_oop.Services;

Store store = new Store();

store.Register( new Admin( 1, "admin", "123"));

store.AddProduct(new Product( 1, "Laptop", 20000, 10));

store.AddProduct(new Product( 2, "Mouse", 500, 20));

store.AddProduct(new Product( 3, "Keyboard", 1000, 15));

while (true)
{
    Console.WriteLine();
    Console.WriteLine("===== E-Commerce System =====");
    Console.WriteLine("1. Register");
    Console.WriteLine("2. Login");
    Console.WriteLine("3. Exit");

    int choice = int.Parse(Console.ReadLine());

    if (choice == 1)
    {
        Console.Write("Username: ");
        string username = Console.ReadLine();

        Console.Write("Password: ");
        string password = Console.ReadLine();

        Console.WriteLine("1. Customer");
        Console.WriteLine("2. Admin");

        int role = int.Parse(Console.ReadLine());

        try
        {
            if (role == 1)
            {
                store.Register(  new Customer( store.Users.Count + 1, username, password));
            }
            else
            {
                store.Register( new Admin( store.Users.Count + 1, username, password));
            }

            Console.WriteLine("Register Success");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    else if (choice == 2)
    {
        Console.Write("Username: ");
        string username = Console.ReadLine();

        Console.Write("Password: ");
        string password = Console.ReadLine();

        User? loggedUser =
            store.Login(username, password);

        if (loggedUser == null)
        {
            Console.WriteLine("Invalid Username Or Password");
            continue;
        }

        if (loggedUser is Admin)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("===== Admin Menu =====");
                Console.WriteLine("1. View Products");
                Console.WriteLine("2. Add Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. Logout");

                int adminChoice =
                    int.Parse(Console.ReadLine());

                if (adminChoice == 1)
                {
                    foreach (var product in store.Products)
                    {
                        Console.WriteLine(
                            $"{product.Id} - {product.Name} - {product.Price} - Stock: {product.StockQuantity}");
                    }
                }

                else if (adminChoice == 2)
                {
                    Console.Write("Id: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());

                    Console.Write("Stock: ");
                    int stock = int.Parse(Console.ReadLine());

                    store.AddProduct(new Product(  id, name, price, stock));

                    Console.WriteLine("Product Added");
                }

                else if (adminChoice == 3)
                {
                    Console.Write("Product Id: ");

                    int productId = int.Parse(Console.ReadLine());

                    Product? product = store.Products.FirstOrDefault( p => p.Id == productId);

                    if (product != null)
                    {
                        store.RemoveProduct(product);
                        Console.WriteLine("Deleted");
                    }
                }

                else if (adminChoice == 4)
                {
                    break;
                }
            }
        }

        else if (loggedUser is Customer customer)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("===== Customer Menu =====");
                Console.WriteLine("1. View Products");
                Console.WriteLine("2. Add To Cart");
                Console.WriteLine("3. View Cart");
                Console.WriteLine("4. Checkout");
                Console.WriteLine("5. Logout");

                int customerChoice =
                    int.Parse(Console.ReadLine());

                if (customerChoice == 1)
                {
                    foreach (var product in store.Products)
                    {
                        Console.WriteLine(
                            $"{product.Id} - {product.Name} - {product.Price} - Stock: {product.StockQuantity}");
                    }
                }

                else if (customerChoice == 2)
                {
                    Console.Write("Product Id: ");

                    int productId = int.Parse(Console.ReadLine());

                    Product? product = store.Products.FirstOrDefault( p => p.Id == productId);

                    if (product == null)
                    {
                        Console.WriteLine("Product Not Found");
                        continue;
                    }

                    Console.Write("Quantity: ");

                    int quantity = int.Parse(Console.ReadLine());

                    try
                    {
                        customer.Cart.AddProduct( product, quantity);

                        Console.WriteLine("Added To Cart");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                else if (customerChoice == 3)
                {
                    foreach (var item in customer.Cart.Items)
                    {
                        Console.WriteLine(
                            $"{item.Product.Name} x {item.Quantity}");
                    }

                    Console.WriteLine(
                        $"Total = {customer.Cart.GetTotalPrice()}");
                }

                else if (customerChoice == 4)
                {
                    Console.WriteLine("1. Credit Card");
                    Console.WriteLine("2. PayPal");
                    Console.WriteLine("3. Cash");

                    int paymentChoice = int.Parse(Console.ReadLine());

                    OrderService orderService = new OrderService();

                    if (paymentChoice == 1)
                    {
                        orderService.Checkout( customer.Cart, new CreditCardPayment());
                    }
                    else if (paymentChoice == 2)
                    {
                        orderService.Checkout( customer.Cart, new PayPalPayment());
                    }
                    else
                    {
                        orderService.Checkout( customer.Cart, new CashPayment());
                    }
                }

                else if (customerChoice == 5)
                {
                    break;
                }
            }
        }
    }

    else if (choice == 3)
    {
        break;
    }
}
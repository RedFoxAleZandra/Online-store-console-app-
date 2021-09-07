using FinalProject_OnlineShop_BLL.Services;
using FinalProject_OnlineShop_BLL.VMs.Auth;
using FinalProject_OnlineShop_BLL.VMs.CustomerData;
using FinalProject_OnlineShop_BLL.VMs.Order;
using FinalProject_OnlineShop_BLL.VMs.Product;
using FinalProject_OnlineShop_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OnlineShop.PureFabrication
{
    public class ConsoleHelper
    {
        public static AppDbContext db = new AppDbContext();

        public static ProductService productService = new ProductService(db);
        public static AuthService authService = new AuthService(db);
        public static CustomerDataService customerDataService = new CustomerDataService(db);
        public static ManagerDataService managerDataService = new ManagerDataService(db);
        public static OrderService orderService = new OrderService(db);

        public Guid CustomerId { get; set; }
        public Guid AuthId { get; set; }
        public Guid ManagerId { get; set; }
        public Guid OrderId { get; set; }
        

        public void OpenStartPage()
        {
            Console.Clear();
            Console.WriteLine("Hello!");
            Console.WriteLine("You can select: ");
            Console.WriteLine("1 - Login\n2 - Register");
            bool selectionLR;
            do
            {
                selectionLR = true;
                Console.Write("Your select: ");
                var selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        {
                            OpenLogin();
                            break;
                        }
                    case "2":
                        {
                            OpenRegister();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please, choose numer of oreration again!");
                            selectionLR = false;
                            break;
                        }
                }
            }
            while (!selectionLR);
        }

        //____________________________________________________ LOGIN _____________________________________________________________

        public void OpenLogin()
        {
            Console.WriteLine("Please, enter your login.");
            string login = Console.ReadLine();
            Console.WriteLine("Please, enter your password.");
            string password = Console.ReadLine();

            roleSelection:

            Console.WriteLine("Are you manager (M) or customer (C)?");
            string selection = Console.ReadLine();
            bool role;
            switch (selection)
            {
                case "c":
                    role = false;
                    break;

                case "m":
                    role = true;
                    break;

                default:
                    Console.Write("Please, try again.");
                    goto roleSelection;
                    

            }


            LoginVM newLogin = new LoginVM()
            {
                Login = login,
                PasswordHash = password,
                Role = role
            };

            try
            {
                var AuthDB = db.Authes.ToList();
                var currentUser = AuthDB.SingleOrDefault(m => m.Login == newLogin.Login && m.PasswordHash == newLogin.PasswordHash);
                AuthId = currentUser.Id;
            }
            catch (NullReferenceException)
            { 
            
            }


            try
            {
                authService.LogIn(newLogin);

                if (role)
                {
                    Console.Clear();
                    OpenManagerService();
                }
                else if (!role)
                {
                    Console.Clear();

                    var CustomersDb = db.Customers.ToList();
                    var currentCustomer = CustomersDb.Find(m => m.AuthId == AuthId);
                    CustomerId = currentCustomer.Id;

                    OpenCustomerService();
                }
            }
            catch 
            {
                Console.WriteLine("Login, password or role are wrong. Please, try again.\n");
                OpenLogin();
            }


               
        }
            

        //____________________________________________________ REGISTER _____________________________________________________________

        public void OpenRegister()
        {
            Console.WriteLine("Please, come up with your login.");
            string login = Console.ReadLine();
            Console.WriteLine("Please, come up with your password.");
            string password = Console.ReadLine();
            Console.WriteLine("Are you manager or client?");

            try
            {
                string selection = Console.ReadLine();
                bool role;


                switch (selection)
                {

                    case "client":
                        {
                            role = false;



                            RegistrationCustomerVM newAuthCustomer = new RegistrationCustomerVM()
                            {
                                Id = Guid.NewGuid(),
                                Login = login,
                                PasswordHash = password,
                                Role = role
                            };
                            authService.RegisterCustomer(newAuthCustomer);

                            Console.WriteLine("\nYou need to fill your personal data. Please, answer the following question below:");

                            Console.WriteLine("\nPlease, write your name: ");
                            var name = Console.ReadLine();

                            Console.WriteLine("Please, write your surname: ");
                            var surname = Console.ReadLine();
                            Console.WriteLine("Please, write your date of birth: ");
                            var dateOfBirth = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Please, write your sex (male or female): ");
                            var sex = Console.ReadLine();
                            Console.WriteLine("Please, write your phone number (in the format + 375 XX XXX XX XX): ");
                            var phoneNumber = Console.ReadLine();
                            Console.WriteLine("Please, write your card number (in the format XXXX XXXX XXXX XXXX): ");
                            var cardNumber = Console.ReadLine();
                            Console.WriteLine("Please, write your location: ");
                            var location = Console.ReadLine();

                            Console.WriteLine("Thank you for your answers!");

                            AuthId = newAuthCustomer.Id;

                            RegistrationCustomerDataVM newAuthCustomerData = new RegistrationCustomerDataVM()
                            {
                                Name = name,
                                Surname = surname,
                                DateOfBirth = dateOfBirth,
                                Sex = sex,
                                PhoneNumber = phoneNumber,
                                CardNumber = cardNumber,
                                Location = location,
                                AuthId = newAuthCustomer.Id,
                            };


                            authService.RegisterCustomerData(newAuthCustomerData);
                            Console.Clear();
                            OpenLogin();

                            break;
                        }
                    case "manager":
                        {
                            role = true;

                            RegistrationManagerVM newAuthManager = new RegistrationManagerVM()
                            {
                                Id = Guid.NewGuid(),
                                Login = login,
                                PasswordHash = password,
                                Role = role
                            };

                            authService.RegisterManager(newAuthManager);

                            Console.WriteLine("\nYou need to fill your personal data. Please, answer the following question below:");

                            Console.WriteLine("\nPlease, write your name: ");
                            var name = Console.ReadLine();
                            Console.WriteLine("Please, write your surname: ");
                            var surname = Console.ReadLine();
                            Console.WriteLine("Please, write your date of birth: ");
                            var dateOfBirth = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Please, write your sex (male or female): ");
                            var sex = Console.ReadLine();
                            Console.WriteLine("Please, write your recruitment date: ");
                            var recruitmentDate = Convert.ToDateTime(Console.ReadLine());

                            AuthId = newAuthManager.Id;
                            ManagerId = Guid.NewGuid();

                            RegistrationManagerDataVM newAuthManagerData = new RegistrationManagerDataVM()
                            {

                                Name = name,
                                Surname = surname,
                                DateOfBirth = dateOfBirth,
                                Sex = sex,
                                RecruitmentDate = recruitmentDate,
                                AuthId = AuthId
                            };

                            authService.RegisterManagerData(newAuthManagerData);
                            Console.Clear();
                            OpenLogin();

                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Please, choose number of operation again!");

                            break;
                        }
                }
            }

            catch
            {
                Console.WriteLine("Please try again.");
                OpenRegister();
            }
        }

        //________________________________________________________________________________MANAGER SERVICES___________________________________________________________________________________________________________

        public void OpenManagerService()
        {

            Console.WriteLine("Please, choose operation: \n1 - add new product,\n2 - update info about product,\n3 - see list of products.");
            var selection = Console.ReadLine();
            switch (selection)
            {

                case "1":
                    {
                        Console.Clear();
                        CreateNewProduct();
                        break;
                    }
                case "2":
                    {
                        Console.Clear();
                        UpdateInfoProduct();
                        break;
                    }
                case "3":
                    {
                        Console.Clear();
                        SeeListOfProducts();
                        break;
                    }

                default:
                    {
                        Console.Clear();
                        Console.WriteLine("Please, choose number of operation again!");
                        OpenManagerService();
                        break;
                    }
            }

        }
        public void CreateNewProduct()
        {
            Console.WriteLine("Please, enter name of product");
            var productName = Console.ReadLine();
            Console.WriteLine("Please, enter price of product");
            var productPrice = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Please, enter description of product");
            var descr = Console.ReadLine();
            Console.WriteLine("Please, enter country of origin of product");
            var country = Console.ReadLine();

            CreateOrUpdateProductVM newProduct = new CreateOrUpdateProductVM()
            {
                ProductName = productName,
                ProductPrice = productPrice,
                CountryOfOrigin = country,
                Description = descr,
            };
            productService.CreateProduct(newProduct);

            Console.WriteLine("Please press any key to return to the main menu");
            Console.ReadKey();
            Console.Clear();
            OpenManagerService();
        }

        public void UpdateInfoProduct()
        {
            productService.GetAllProducts().ToList();

            Console.WriteLine("\nWhat do you want to update? \n\n Name of product - please, enter 1;  \n Price of product - please, enter 2;\n Description of product - please, enter 3; \n Country of origin of product - please, enter 4; \n");
            string selection = Console.ReadLine();

            Console.WriteLine("\nPlease, enter ID of product to be updated:");
            var id = Console.ReadLine();
            Console.WriteLine("\nPlease, enter new name of product:");
            var newLine = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    {
                        productService.UpdateProductName(Guid.Parse(id), newLine);
                        break;
                    }
                case "2":
                    {
                        productService.UpdateProductPrice(Guid.Parse(id),Convert.ToDecimal( newLine));
                        break;
                    }
                case "3":
                    {
                        productService.UpdateProductDescr(Guid.Parse(id), newLine);
                        break;
                    }
                case "4":
                    {
                        productService.UpdateProductCountry(Guid.Parse(id), newLine);
                        break;
                    }
            }

            Console.WriteLine("Please, see updated info about product below:\n");
            var updatedProduct = productService.GetProduct(Guid.Parse(id));
            Console.WriteLine($"\nName - {updatedProduct.ProductName} || Price - { updatedProduct.ProductPrice} || Description - { updatedProduct.Description} || Country of origin - { updatedProduct.CountryOfOrigin}\n");

            Console.WriteLine("Please press any key to return to the main menu");
            Console.ReadKey();
            Console.Clear();
            OpenManagerService();
        }

        public void SeeListOfProducts()
        {
            productService.GetAllProducts().ToList();
            Console.WriteLine();
            Console.WriteLine("Please, enter 1 - to see more details about product or enter 2 - to return to the main page:");
            var selection = Console.ReadLine();

        
                switch (selection)
                {

                    case "1":
                        {
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("Please enter Id of product to see more details:");
                                    var productId = Console.ReadLine();
                                    var product = productService.GetProduct(Guid.Parse(productId));
                                    Console.WriteLine($"\nName - {product.ProductName} || Price - { product.ProductPrice} || Description - { product.Description} || Country of origin - { product.CountryOfOrigin}\n");

                                    Console.WriteLine("Please press any key to return to the previous page");
                                    Console.ReadKey();
                                    Console.Clear();
                                    SeeListOfProducts();
                                }
                                catch
                                {
                                    Console.WriteLine("\nSomething is wrong with product ID. Please, try again.\n");
                                }

                            }
                        }
                    case "2":
                        {
                            Console.Clear();
                            OpenManagerService();
                            break;
                        }
                default:
                    {
                        Console.WriteLine("Please, choose again.");
                        break;
                    }
                }

            Console.WriteLine("Please press any key to return to the main menu");
            Console.ReadKey();
            Console.Clear();
            OpenManagerService();
        }

        //________________________________________________________________________________CUSTOMER SERVICES___________________________________________________________________________________________________________

        public void OpenCustomerService()
        {
            Console.WriteLine("Please, choose operation: \n1 - add new order,\n2 - update my info,\n3 - see list of products, \n4 - see list of my orders.");
            var selection = Console.ReadLine();
            switch (selection)
            {

                case "1":
                    {
                        Console.Clear();
                        AddNewOrder();
                        break;
                    }
                case "2":
                    {
                        Console.Clear();
                        UpdateInfoAboutMe();
                        break;
                    }
                case "3":
                    {
                        Console.Clear();
                        SeeListOfProductsCustomer();
                        break;
                    }
                case "4":
                    {
                        Console.Clear();
                        SeeListOfMyOrders();
                        break;
                    }

                default:
                    {
                        Console.Clear();
                        Console.WriteLine("Please, choose number of operation again!");
                        OpenCustomerService();
                        break;
                    }
            }
        }

        public void AddNewOrder() 
        {
            Console.WriteLine("You can see list of products below:");

            productService.GetAllProducts();

            Console.WriteLine("Please, enter ID of product to add them to your order");
            var productId = Console.ReadLine();
            Console.WriteLine("Please, enter count of products you need");
            var countOfProducts = Convert.ToInt32(Console.ReadLine());

            CreateOrderVM neworderData = new CreateOrderVM()
            {
                CustomerId = CustomerId,
                OrderDate = DateTime.Today,
                ID = Guid.NewGuid()
            };

            CreateOrderItemVM newOrder = new CreateOrderItemVM()
            {
                ProductId = Guid.Parse(productId),
                CountofProduct = countOfProducts,
                OrderId = neworderData.ID,
                ID = Guid.NewGuid()
            };

            orderService.CreateOrder(neworderData, newOrder);

            Console.WriteLine("Your order is successfully created!");
            Console.WriteLine("Please press any key to return to the main menu");
            Console.ReadKey();
            Console.Clear();
            OpenCustomerService();
        }

        public void UpdateInfoAboutMe() 
        {
            Console.WriteLine("You can see your personal data below:");

            var customerData = customerDataService.GetCustomerData(CustomerId);
            Console.WriteLine($"\nYour name: {customerData.Name} \nYour surname: {customerData.Surname} \nYour date of birth: {customerData.DateOfBirth.ToString("dd.MM.yyyy")}\nYour phone number: {customerData.PhoneNumber} \nYour locaion: {customerData.Location} \nYour card number: {customerData.CardNumber}\n");


            Console.WriteLine("\nWhat do you want to update? \n\n Name - please, enter 1;  \n Surname - please, enter 2;\n Date of birth - please, enter 3; \n Phone number - please, enter 4; \n Card number - please, enter 5; \n Location - please, enter 6; \n");
            string selection = Console.ReadLine();

            Console.WriteLine("\nPlease, enter new field value:");
            var newLine = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    {
                        customerDataService.UpdateCutstomerName(CustomerId, newLine);
                        break;
                    }
                case "2":
                    {
                        customerDataService.UpdateCustomerSurname(CustomerId, newLine);
                        break;
                    }
                case "3":
                    {
                        customerDataService.UpdateCustomerDateOfBirth(CustomerId, Convert.ToDateTime(newLine));
                        break;
                    }
                case "4":
                    {
                        customerDataService.UpdateCustomerPhone(CustomerId, newLine);
                        break;
                    }
                case "5":
                    {
                        customerDataService.UpdateCustomerCardNumber(CustomerId, newLine);
                        break;
                    }
                case "6":
                    {
                        customerDataService.UpdateCustomerLocation(CustomerId, newLine);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("You chose nonexistent operation. Please, try again.");
                        UpdateInfoAboutMe();
                        break;
                    }
            }

            Console.WriteLine("Please, see your updated info below:\n");

            var customerDataUpdated = customerDataService.GetCustomerData(CustomerId);
            Console.WriteLine($"\nYour name: {customerDataUpdated.Name} \nYour surname: {customerDataUpdated.Surname} \nYour date of birth: {customerDataUpdated.DateOfBirth.ToString("dd.MM.yyyy")}\nYour phone number: {customerDataUpdated.PhoneNumber} \nYour locaion: {customerDataUpdated.Location} \nYour card number: {customerDataUpdated.CardNumber}\n");

            Console.WriteLine("Please press any key to return to the main menu");
            Console.ReadKey();
            Console.Clear();
            OpenCustomerService();
        }

        public void SeeListOfProductsCustomer() 
        {
            productService.GetAllProducts().ToList();
            Console.WriteLine();
            Console.WriteLine("Please, enter 1 - to see more details about product or enter 2 - to return to the main page:");
            var selection = Console.ReadLine();


            switch (selection)
            {

                case "1":
                    {
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Please enter Id of product to see more details:");
                                var productId = Console.ReadLine();
                                var product = productService.GetProduct(Guid.Parse(productId));
                                Console.WriteLine($"\nName - {product.ProductName} || Price - { product.ProductPrice} || Description - { product.Description} || Country of origin - { product.CountryOfOrigin}\n");

                                Console.WriteLine("Please press any key to return to the previous page");
                                Console.ReadKey();
                                Console.Clear();
                                SeeListOfProductsCustomer();
                            }
                            catch
                            {
                                Console.WriteLine("\nSomething is wrong with product ID. Please, try again.\n");
                            }

                        }
                    }
                case "2":
                    {
                        Console.Clear();
                        OpenCustomerService();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Please, choose again.");
                        break;
                    }
            }

            Console.WriteLine("Please press any key to return to the main menu");
            Console.ReadKey();
            Console.Clear();
            OpenCustomerService();
        }
        public void SeeListOfMyOrders() 
        {
            Console.WriteLine("Please, see list of your orders below:");

            var result = orderService.GetAllOrders(CustomerId);
            foreach (OpenOrderListVM i in result)
            {
                Console.WriteLine($"Order ID: {i.Id}  Order date: {i.OrderDate.ToString("dd.MM")}");
            }

            try
            {
                Console.WriteLine("To see more info about order, please, enter 1. To delete order, please enter 2.");
                var selection = Console.ReadLine();
                Console.WriteLine("Please, enter ID of selected order.");
                var orderID = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        {
                            var orderData = orderService.GetOrder(Guid.Parse(orderID));
                            Console.WriteLine($"Order ID: {orderData.OrderId}, Product ID: {orderData.ProductId}, Count of product: {orderData.CountofProduct}");

                            break;
                        }
                    case "2":
                        {
                            orderService.DeleteOrder(Guid.Parse(orderID));
                            Console.WriteLine("Your order was successfully deleted! \n");
                            break;
                        }
                }
            }
            catch
            {
                Console.WriteLine("You entered wrong ID. Please, try again.");
                SeeListOfMyOrders();
            }
            Console.WriteLine("Please press any key to return to the main menu");
            Console.ReadKey();
            Console.Clear();
            OpenCustomerService();
        }


    }
}


using System;
using System.Threading;
using BuySellTrade_App.Components;
namespace BuySellTrade_App;

/**
 * <summary>
 * This is the application class that allows interactions between 
 * customers and the admin. It implements the below fields<br/>
 * OneTimePassword, Members, Admin, Orders, TradeProposals, and an input
 * control variable, valid.
 * </summary>
 */
public class RegistrationController
{
    private int _oneTimePassword;
    private List<Customer> _member;
    private Admin _admin;
    private List<Order> _orders;
    private List<TradeProposal> _tradeProposal;

    private Boolean valid;

    /**
     * <summary>
     * Default Constructor:<br/>
     * 
     * Instatiates a default admin<br/>
     * Name: Billy Micah<br/>
     * Password: pass<br/>
     * <br/>
     * <br/>
     * 
     * Instatiates a default customer<br/>
     * Name: Billy<br/>
     * Password: passw<br/>
     * <br/>
     * <br/>
     * Instantiates some five products three of them are advertised and their
     * all added to the admin catalogue.
     * </summary>
     */
    public RegistrationController()
    {
        Admin billy = new(
            "Billy Micah",
            "me@you.com",
            "pass",
            456789876
        );

        Customer miki = new(
            "Billy",
            "me@you.com",
            "passw",
            67890
        );

        _admin = billy;

        Category Cars = new(
            "Cars"
        );
        Category Furniture = new(
            "Furniture"
        );
        Category Crokery = new(
            "Crokery"
        );

        Product one = new(
            "Honda Civic",
            "34567 KM mileage, within Kuching",
            10000.00,
            Condition.Used,
            Cars
        );
        Product two = new(
            "Italian Leather",
            "Nick Scali imported leather couch",
            4500.00,
            Condition.BrandNew,
            Furniture
        );
        Product trois = new(
            "Ford Falcon",
            "1347 KM mileage, From Kuala Lumpar",
            22000.00,
            Condition.Used,
            Cars
        );
        Product unn = new(
            "Home Couch",
            "Just bought this couch but won't fit in my house",
            2500.00,
            Condition.BrandNew,
            Furniture
        );
        Product via = new(
            "Perodua",
            "3467 KM mileage, within Kuching",
            10000.00,
            Condition.Used,
            Cars
        );

        via.Advertise.Life = 5;
        unn.Advertise.Life = 3;
        trois.Advertise.Life = 4;

        List<Product> products = new();
        products.Add( one );
        products.Add( two );
        products.Add( trois );
        products.Add( unn );
        products.Add( via );

        _admin.Catalogue.AddItem( products );



        _orders = new();
        _tradeProposal = new();
        _member = new();
        _member.Add( miki );
        valid = false;

        Random rand = new();
        _oneTimePassword = rand.Next();

    }
    
    /**
     * <summary>
     * This function implements a default homepage for all users and allows 
     * them to log in to the application if registered. Unregistered users can 
     * pick a menu option that allows them to register
     * </summary>
     */
    public void WelcomePage()
    {
        Console.Clear();
        Console.WriteLine("+===================================+");
        Console.WriteLine("|        WELCOME HOME PAGE          |");
        Console.WriteLine("+===================================+");
        Console.WriteLine("\n");
        Console.WriteLine("Welcome to the Buy And Trade Shop Home Page");
        Console.WriteLine("How would you like to proceed");
        Console.WriteLine("Please enter the number of the option you'd like to proceed with");
        Console.WriteLine("1. LogIn as Admin");
        Console.WriteLine("2. LogIn as Customer");
        Console.WriteLine("3. Register");
        Console.WriteLine("4. Browse Products");
        Console.WriteLine("5. Exit");
        
        valid = false;

        while (valid == false){
            string? val = Console.ReadLine();
            string answer = (val != null) ? val : "";

            switch(answer)
            {
                case "1":

                    Console.WriteLine("Please Enter your name");
                    string? resp = Console.ReadLine();
                    string name = (resp != null) ? resp : "";
                    Console.WriteLine("Please Enter your password");
                    string? resp2 = Console.ReadLine();
                    string passcode = (resp2 != null) ? resp2 : "";

                    if (name != _admin.Name || passcode != _admin.Password)
                    {
                        Console.WriteLine("Incorrect Details");
                        Console.WriteLine("Please try again");
                        valid = false;
                    }

                    valid = true;
                    LogIn("Billy Micah", "pass");
                    AdminHomePage();
                    break;
                case "2":
                    LogInCustomer();
                    valid = true;
                    break;
                case "3":
                    RegisterCustomer();
                    Console.WriteLine("You've successfully registered");
                    valid = true;
                    WelcomePage();
                    break;
                case "4":
                    valid = true;
                    _admin.Catalogue.Display();
                    break;
                case "5":
                    valid = true;
                    Console.WriteLine("Bye");
                    break;
                default:
                    valid = false;
                    Console.WriteLine("");
                    Console.WriteLine("Please pick an option to proceed.");
                    Console.WriteLine("Be sure to enter just the number of the option you'd like to proceed with.");
                    
                    break;
            } 
        }
    }

    /**
     * <summary>
     * This function allows users to register to the application
     * </summary>
     */
    public void RegisterCustomer()
    {
        Console.Clear();
        Console.WriteLine("+===================================+");
        Console.WriteLine("|        CUSTOMER REGISTRATION      |");
        Console.WriteLine("+===================================+");
        Console.WriteLine("\n");
        Console.WriteLine("Lets get you registered");
        while ( valid ==false ){
            Console.WriteLine("Please enter your name");
            string? nome = Console.ReadLine();
            string cust_name = (nome != null) ? nome : "";

            Console.WriteLine("Please enter your email");
            string? email = Console.ReadLine();
            string cust_email = (email != null) ? email : "";

            Console.WriteLine("Please enter your password");
            string? passw = Console.ReadLine();
            string cust_pass = (passw != null) ? passw : "";

            Console.WriteLine("Please enter your phone Number");
            string? phoneNum = Console.ReadLine();
            int cust_phone = 0;
            try {
                cust_phone = (phoneNum != null) ? Int32.Parse(phoneNum) : 0;

            } catch (FormatException){
                Console.WriteLine("Wrong input you need to enter an interger value for you phone number");
                Console.WriteLine("Please start over");

                valid=false;
                break;
            }

            Customer cust = new(
                cust_name,
                cust_email,
                cust_pass,
                cust_phone
            );
            _member.Add( cust );
            Console.Clear();
            Console.WriteLine("Thanks for Registering");
            Console.WriteLine("You can now log in");
            Console.WriteLine();
            WelcomePage();
            valid = true;
        }
    }

    /**
     * <summary>
     * Provides login utility for customeres by collectin the login details. This function
     * ascertains the user is registered to use the application before they can login.
     * </summary>
     */
    public void LogInCustomer()
    {
        Console.Clear();
        Console.WriteLine("+===================================+");
        Console.WriteLine("|        CUSTOMER LOGIN             |");
        Console.WriteLine("+===================================+");
        Console.WriteLine("\n");
        Console.WriteLine("Lets get you logged In");
        while ( valid ==false ){
            Console.WriteLine("Please enter your name");
            string? nome = Console.ReadLine();
            string cust_name = (nome != null) ? nome : "";

            Console.WriteLine("Please enter your password");
            string? passw = Console.ReadLine();
            string cust_pass = (passw != null) ? passw : "";

            var customer = _member.FirstOrDefault<Customer>(n => n.Name.ToLower() == cust_name.ToLower() );

            if (customer == null){
                Console.WriteLine("Your name was not found");
                Console.WriteLine("Please consider registering");
                Console.WriteLine();
                Console.WriteLine("How would you like to proceed");
                Console.WriteLine("Please enter the number of the option you'd like to proceed with");
                Console.WriteLine("1. Register Customer");
                Console.WriteLine("2. Back To Main");

                string? val = Console.ReadLine();
                string answer = (val != null) ? val : "";

                switch(answer)
                {
                    case "1":
                        RegisterCustomer();
                        break;
                    case "2":
                        WelcomePage();
                        break;
                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Please pick an option to proceed.");
                        Console.WriteLine("Be sure to enter just the number of the option you'd like to proceed with.");
                        WelcomePage();
                        break;
                } 
            }
            else {
                if(customer.Name.ToLower() == cust_name.ToLower() && customer.Password.ToLower() == cust_pass.ToLower()){
                    customer.LoggedIn = true;
                    CustomerHomePage(customer);
                } else {
                    Console.WriteLine("The info you entered Don't match");
                    Console.WriteLine("Please enter correct details to login");
                    LogInCustomer();
                }
            }
        }
    }
    
    /**
     * <summary>
     * provides a login utility for admins by collecting the log in details
     * </summary>
     */
    public void LogInAdmin()
    {
        Admin joe = new(
            "joe",
            "me@you.gmail.com",
            "jumpin",
            6794
        );
        AdminHomePage();

    }
    
    /**
     * <summary>
     * This function logs the user in by taking their name and password.
     * </summary>
     * <param name="name">Name of the user</param>
     * <param name="password">Password of the user</param>
     */
    private void LogIn(string name, string password)
    {
        _admin.LoggedIn = true;
    }

    /**
     * <summary>
     * This function logs the user in by taking their phone number and otp code
     * </summary>
     * <param name="phone">The user's phone number</param>
     * <param name="OTP">The OTP generated by the app</param>
     */
    private void LogIn(int phone, int OTP)
    {
        _admin.LoggedIn = true;
    }
    
    /**
     * <summary>
     * This function logs the user out of the applications
     * </summary>
     * <param name="user">The user to be logged out</param>
     */
    private void LogOut(User user)
    {
        _admin.LoggedIn = false;
    }

    /**
     * <summary>
     * This function is used for updating and removing items from the the customer cart
     * </summary>
     * <param name="customer">The logged in customer who's carts to be updates</param>
     */
    private void UpdateCustomerCart(Customer customer)
    {
        valid = false;

        while(valid == false)
        {
            customer.ShowCart();
            Console.WriteLine("\n");
            if (customer.Cart.Count > 0)
            {
                Console.WriteLine("Please enter the product Id of the product you'd like to remove from cart");
                Console.WriteLine("Type 'Exit' to go back");
                string? resp = Console.ReadLine();
                string response = (resp != null) ? resp : "";

                try {
                    int productId = Int32.Parse(response);
                    var cartProduct = customer.Cart.FirstOrDefault( n => n.ProdId == productId );
                    if (cartProduct != null) {
                        customer.RemoveFromCart(cartProduct);
                        Console.WriteLine("Great!!");
                        Console.WriteLine("Update Successful!!");
                        customer.ShowCart();
                        valid = true;
                    }
                    else {
                        Console.WriteLine();
                        Console.WriteLine("Well ..........");
                        Console.WriteLine("You don't appear to have such a product");
                        Console.WriteLine("Please Try again");
                        valid = false;
                    }
                } catch (System.FormatException){
                    if(response == "Exit".ToLower())
                    {
                        valid = true;
                        CustomerHomePage(customer);
                    } else {
                        System.Console.WriteLine("Wrong Input");
                        valid = false;
                    }
                }

            }
            else {
                AddCustomerCart(customer);
            }
        }
    }

    /**
     * <summary>
     * Shows the customer orders containing the objects they checked out.
     * </summary>
     * <param name="cust">The logged in customer who's orders to display</param>
     */
    private void CustomerOrders(Customer cust)
    {
        Console.Clear();
        Console.WriteLine("+=============================================+");
        Console.WriteLine("|    CUSTOMER ORDERS VIEW & TRACKING PAGE     |");
        Console.WriteLine("+=============================================+");
        Console.WriteLine("\n");
        if (cust.CustOrders.Count > 0)
        {
            Console.WriteLine("Here are your orders");
            foreach(Order ord in cust.CustOrders) ord.Print();
        }
        else {
            Console.WriteLine("Sorry You don't appear to have any orders at this time");
            Console.WriteLine("Consider making some purchases");
        }

        Console.WriteLine("Redirecting you in 2 seconds");
        Thread.Sleep(2000);
        CustomerNavigation(cust);
    }

    /**
     * <summary>
     * Shows the customer history including their orders adn trade proposals
     * </summary>
     * <param name="cust">The logged in customer who's history to display</param>
     */
    private void CustomerHistory(Customer cust)
    {
        Console.Clear();
        Console.WriteLine("+================================================+");
        Console.WriteLine("|    CUSTOMER TRANSACTION HISTORY VIEW PAGE      |");
        Console.WriteLine("+================================================+");
        Console.WriteLine("\n");

        if (cust.CustOrders.Count > 0 && cust.TradeProposed.Count > 0)
        {
            Console.WriteLine("\nYour Orders: ");
            foreach(Order item in cust.CustOrders) item.Print();
            Console.WriteLine("\nYour Proposed Trade Items: ");
            foreach(TradeProposal item in cust.TradeProposed) item.Print();
        } 
        else if (cust.CustOrders.Count > 0 && cust.TradeProposed.Count <= 0)
        {
            Console.WriteLine("\nYour Orders: ");
            foreach(Order item in cust.CustOrders) item.Print();
        }
        else if (cust.TradeProposed.Count > 0 && cust.CustOrders.Count <= 0)
        {
            Console.WriteLine("\nYour Proposed Trade Items: ");
            foreach(TradeProposal item in cust.TradeProposed) item.Print();
        }
        else{
            Console.WriteLine("\nYou don't seem to have had any activity thus far");
            Console.WriteLine("\nConsider making some purchases or trade proposals");
        }

        CustomerNavigation(cust);
    }

    /**
     * <summary>
     * This function provide a navigation tool for the customer
     * </summary>
     * <param name="customer">The logged in customer to whom the navigation is to be displayed</param>
     */
    private void CustomerNavigation(Customer customer)
    {

        Console.WriteLine();
        Console.WriteLine("How would you like to proceed");
        Console.WriteLine("Please enter the number of the option you'd like to proceed with");
        Console.WriteLine("1. Add Item To Cart");
        Console.WriteLine("2. Checkout");
        Console.WriteLine("3. Homepage");
        Console.WriteLine("4. View My Orders");
        Console.WriteLine("5. Transaction History");
        Console.WriteLine("6. Update Cart");
        Console.WriteLine("7. Trade Product");
        Console.WriteLine("8. LogOut");
        
        valid = false;

        while (valid == false)
        {

            string? next = Console.ReadLine();
            string goNext = (next != null) ? next : "";

            switch(goNext)
            {
                case "1":
                AddCustomerCart(customer);
                valid = true;
                break;
                case "2":
                customer.CheckOut();
                foreach(Order item in customer.CustOrders ) _orders.Add( item );
                Console.WriteLine("Redirecting You in a 3 Seconds..");
                Thread.Sleep(3000);
                CustomerHomePage(customer);
                valid = true;
                break;
                case "3":
                CustomerHomePage(customer);
                valid = true;
                break;
                case "4":
                CustomerOrders(customer);
                valid = true;
                break;
                case "5":
                CustomerHistory(customer);
                valid = true;
                break;
                case "6":
                UpdateCustomerCart(customer);
                valid = true;
                break;
                case "7":
                TradeProduct(customer);
                valid = true;
                break;
                case "8":
                customer.LoggedIn = false;
                WelcomePage();
                valid = true;
                break;
                default:
                
                Console.WriteLine("wrong input!");
                Console.WriteLine("Please enter a number of a given oprion above. Thanks");
                
                break;
            }
        }
    }
  
    /**
     * <summary>
     * This function provides a utility for adding items to customer cart
     * </summary>
     * <param name="customer">The logged in customer into who's cart the items should be added</param>
     */
    private void AddCustomerCart(Customer customer)
    {
        Console.Clear();
        _admin.Catalogue.Display();
        valid = false;

        while (valid == false){

            Console.WriteLine("Please enter the product ID of the Product you'd like to add to cart");
            Console.WriteLine("Type 'Exit' to go back");
            string? resp = Console.ReadLine();
            string response = (resp != null) ? resp : "";

            try {
                int index = Int32.Parse(response);
                var cart_item = _admin.Catalogue.ListOfProduct.FirstOrDefault<Product>( n => n.ProdId == index );
                if (cart_item != null){
                    customer.AddToCart( cart_item );
                    customer.ShowCart();
                    valid = true;
                } else {
                    valid = false;
                    Console.WriteLine("You entered the wrong number");
                }

            }
            catch (System.FormatException) {
                if (response == "Exit".ToLower())
                {
                    valid = true;
                } else {
                    valid = false;
                    Console.WriteLine("You entered the word/response");
                }
            }
        }
        CustomerNavigation(customer);
    }

    /**
     * <summary>
     * This implement a home page for admins along with a navigation tool specifically for admins
     * </summary>
     */
    private void AdminHomePage()
    {
        if (_admin.LoggedIn){

            Console.Clear();
            Console.WriteLine("+===================================+");
            Console.WriteLine("|        ADMIN HOME PAGE            |");
            Console.WriteLine("+===================================+");
            Console.WriteLine("\n");
            Console.WriteLine("Welcome to the Admin Home Page");
            Console.WriteLine("How would you like to proceed");
            Console.WriteLine("Please enter the number of the option you'd like to proceed with");
            Console.WriteLine("1. View Listed Products");
            Console.WriteLine("2. View Customer Orders");
            Console.WriteLine("3. View Product Categories");
            Console.WriteLine("4. View Trade Proposals");
            Console.WriteLine("5. LogOut");

            string? val = Console.ReadLine();
            string answer = (val != null) ? val : "";

            switch(answer)
            {
                case "1":
                    ViewProducts();
                    break;
                case "2":
                    ViewOrders();
                    break;
                case "3":
                    ViewCategories();
                    break;
                case "4":
                    ViewTradeProposal();
                    break;
                case "5":
                    LogOut(_admin);
                    WelcomePage();
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Please pick an option to proceed.");
                    Console.WriteLine("Be sure to enter just the number of the option you'd like to proceed with.");
                    AdminHomePage();
                    break;
            } 

        }
        else {
            Console.WriteLine("You'll need to log in to view the admin HomePage");
            WelcomePage();
        }
        // show the admin homepage

    }

    /**
     * <summary>
     * This function implements a customer homepage for logged in customers
     * </summary>
     * <param name="customer">The logged in customer to view the homepage</param>
     */
    private void CustomerHomePage(Customer customer)
    {
        Console.Clear();
        Console.WriteLine("+===================================+");
        Console.WriteLine("|        CUSTOMER HOME PAGE         |");
        Console.WriteLine("+===================================+");
        Console.WriteLine("\n");
        Console.WriteLine("Welcome to the Customer Home Page");
        _admin.Catalogue.Display();

        if (customer.LoggedIn){
            CustomerNavigation(customer);
        }else {
            Console.WriteLine("You'll need to log in to perform any actions");
            WelcomePage();
        }
        // show the customer Homepage

    }

    /**
     * <summary>
     * Allows the customer to trade a product with the admin. 
     * The customer inputs details about the product and upon completion
     * a trade proposal is sent to the admin.
     * 
     * </summary>
     * <param name="customer">
     * This customer parameter is required since the customer details
     * are collected to attach to the trade proposal.
     * </param>
     */
    private void TradeProduct(Customer customer)
    {
        Boolean another = true;
        List<Product> prodList = new();

        while (another)
        {
            Console.Clear();
            Console.WriteLine("+===================================+");
            Console.WriteLine("|       TRADE PRODUCT HOME PAGE     |");
            Console.WriteLine("+===================================+");
            Console.WriteLine("\n");
            Console.WriteLine("Welcome to the Product View Home Page");

            // valid = false;
            // while(valid == false)
            // {
            //     try{
            //         int tryInt = Int32.Parse(trNom);
            //         Console.WriteLine("You can't have numberes in this entry");
            //     } catch (System.FormatException) {
            //         valid = true;
            //     }
            // }
            Console.WriteLine("Please enter the name of the product you'd like to trade");
            string? trnom = Console.ReadLine();
            string trName = (trnom != null) ? trnom : "";

            Console.WriteLine("Please enter a product description");
            string? trdes = Console.ReadLine();
            string trDesc = (trdes != null) ? trdes : "";

            string trPrice = "";
            valid = false;
            while(valid == false)
            {
                Console.WriteLine("Please propose the product price");
                Console.WriteLine("Enter Numbers only, value in Malaysian Ringit");
                string? trprc = Console.ReadLine();
                trPrice = (trprc != null) ? trprc : "";

                try{
                    int price = Int32.Parse(trPrice);
                    valid = true;
                } catch(FormatException)
                {
                    Console.WriteLine("\n!!!!!!!!  INVALID INPUT  !!!!!!!!!!");
                    Console.WriteLine("You're required to enter a numerical value for the price\n");
                    valid = false;
                }

            }

            Console.WriteLine("Whats the product category");
            string? trcat = Console.ReadLine();
            string trCatgry = (trcat != null) ? trcat : "";

            int tradePrice = Int32.Parse(trPrice);
            Category tradeCat = new(trCatgry);

            Product trProd = new(trName, trDesc, tradePrice, Condition.Used, tradeCat);
            prodList.Add( trProd );

            Console.WriteLine("Would you like to propose another product");
            Console.WriteLine("Please enter 'Yes' or 'No' ");
            string? tranot = Console.ReadLine();
            string trAnother = (tranot != null) ? tranot : "";

            another = (trAnother.ToLower() == "yes") ? true : false;
        }

        TradeProposal trPropose = new(prodList, customer.Name);
        customer.TradeProposed.Add( trPropose );
        _tradeProposal.Add( trPropose );

        string suffix = ( customer.TradeProposed.Count > 1) ? "s" : "";
        Console.WriteLine($"\nGreat! Added your proposal{suffix} Successfully!!");
        
        CustomerNavigation(customer);

    }

    /**
     * <summary>
     * This function allows the admin to edit or update existing products in the catalogue
     * </summary>
     */
    private void EditProduct()
    {
        Console.Clear();
        Console.WriteLine("+===================================+");
        Console.WriteLine("|    ADMIN PRODUCT EDITING PAGE     |");
        Console.WriteLine("+===================================+");
        Console.WriteLine("\n");   
        _admin.Catalogue.Display();
        
        valid = false;
        Console.WriteLine("Please enter the product ID of the product you'd like to edit");
        while (valid == false)
        {
            string? val = Console.ReadLine();
            string answer = (val != null) ? val : "";

            try {
                int prodId = Int32.Parse(answer);

                var prod = _admin.Catalogue.ListOfProduct.FirstOrDefault<Product>( n => n.ProdId == prodId );
                if (prod != null) 
                {
                    Boolean another = true;
                    while (another)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("---------------------------");
                        Console.WriteLine(" Found Product of Interest ");
                        Console.WriteLine("---------------------------");
                        Console.WriteLine(prod.PrintInfo());
                        Console.WriteLine("Please enter the option you like to change");
                        Console.WriteLine("Type 'Exit' to go back");
                        Console.WriteLine("1. Name");
                        Console.WriteLine("2. Price");
                        Console.WriteLine("3. Description");
                        Console.WriteLine("4. Category");
                        Console.WriteLine("5. Advertisement");
                        Console.WriteLine("6. Condition");

                        string? resp = Console.ReadLine();
                        string response = (resp != null) ? resp : "";

                        switch(response)
                        {
                            case "1":
                                Console.WriteLine("Please enter the name you'd like to assign the product");
                                string? prnm = Console.ReadLine();
                                string prname = (prnm != null) ? prnm : "";

                                prod.Name = prname;
                                Console.WriteLine("\n");
                                Console.WriteLine("Updated Product\n");
                                Console.WriteLine(prod.PrintInfo());
                                
                                Console.WriteLine("\nUpdate another field...");
                                break;
                            case "2":
                                Console.WriteLine("Please make sure you enter numbers only for the price");
                                Console.WriteLine("The assumed currency is MYR");
                                Console.WriteLine("Please enter the price you'd like to assign the product");
                                string? prpric = Console.ReadLine();
                                string prPrice = (prpric != null) ? prpric : "";

                                try {
                                    int price = Int32.Parse(prPrice);
                                    prod.Price = price;
                                    Console.WriteLine("\n");
                                    Console.WriteLine("Updated Product\n");
                                    Console.WriteLine(prod.PrintInfo());
                                    
                                    Console.WriteLine("\nUpdate another field...");
                                } catch (FormatException) 
                                {
                                    Console.WriteLine("\n!!!!!!!!!!!   FAILED   !!!!!!!!!!!");
                                    Console.WriteLine("Price change unsuccessful");
                                    Console.WriteLine("Please make sure you enter numbers only for the price");
                                    Console.WriteLine("The assumed currency is MYR");
                                    Console.WriteLine("!!!!!!!!!!!   FAILED   !!!!!!!!!!!\n");
                                }

                                break;
                            case "3":
                                Console.WriteLine("Please enter the description you'd like to assign the product");
                                string? prds = Console.ReadLine();
                                string prdesc = (prds != null) ? prds : "";

                                prod.Description = prdesc;
                                Console.WriteLine("\n");
                                Console.WriteLine("Updated Product\n");
                                Console.WriteLine(prod.PrintInfo());
                                
                                Console.WriteLine("\nUpdate another field...\n");
                            break;
                            case "4":
                                if (_admin.Catalogue.Categories.Count > 0)
                                {
                                    Console.WriteLine("Please enter the category you'd like to assign the product");
                                    Console.WriteLine("You can either pick from the below category or provide a name to create a new one");
                                    foreach(Category catgr in _admin.Catalogue.Categories) Console.WriteLine(catgr.Name);
                                    
                                    string? prct = Console.ReadLine();
                                    string prctgry = (prct != null) ? prct : "";

                                    var catgry = _admin.Catalogue.Categories.FirstOrDefault<Category>( n => n.Name.ToLower() == prctgry.ToLower() );
                                    if ( catgry != null ) prod.Category = catgry;
                                    else{
                                        Category cat_new = new( prctgry );
                                        prod.Category = cat_new;
                                    }


                                    
                                }
                                else {
                                    Console.WriteLine("You don't appear to have any categories just yet");
                                    Console.WriteLine("Simply enter the name of a category to create one");

                                    string? prct = Console.ReadLine();
                                    string prctgry = (prct != null) ? prct : "";
                                    
                                    Category new_cat = new( prctgry );
                                    prod.Category = new_cat;

                                }
                                
                                Console.WriteLine("\n");
                                Console.WriteLine("Updated Product\n");
                                Console.WriteLine(prod.PrintInfo());
                                
                                Console.WriteLine("\nUpdate another field...");
                            break;
                            case "5":
                                Console.WriteLine("Please make sure you enter numbers only for the advert days");
                                Console.WriteLine("Please enter the number of days you'd like to advertise the product for");
                                Console.WriteLine("Enter a 0  to opt out of advertising this product");
                                string? prad = Console.ReadLine();
                                string prAdvert = (prad != null) ? prad : "";

                                try {
                                    int adDays = Int32.Parse(prAdvert);
                                    prod.Advertise.Life = adDays;
                                    Console.WriteLine("\n");
                                    Console.WriteLine("Updated Product\n");
                                    Console.WriteLine(prod.PrintInfo());
                                    
                                    Console.WriteLine("\nUpdate another field...");
                                } catch (FormatException) 
                                {
                                    Console.WriteLine("\n!!!!!!!!!!!   FAILED   !!!!!!!!!!!\n");
                                    Console.WriteLine("Advert update change unsuccessful");
                                    Console.WriteLine("Please make sure you enter numbers only for the advert days");
                                    Console.WriteLine("\n!!!!!!!!!!!   FAILED   !!!!!!!!!!!\n\n");
                                }
                            break;
                            case "6":
                                Console.WriteLine("You can only either have new or used for the description");
                                Console.WriteLine("Any further information can be added in the description\n");
                                Console.WriteLine("Is this product 'new' or 'used'? \n");
                                Console.WriteLine("Simply type 'new' or 'used to provide your answer'\n");
                                
                                string? prcnd = Console.ReadLine();
                                string prcond = (prcnd != null) ? prcnd : "";

                                if (prcond.ToLower() == "new")
                                {
                                    prod.Condition = Condition.BrandNew;
                                    Console.WriteLine("\n");
                                    Console.WriteLine("Updated Product\n");
                                    Console.WriteLine(prod.PrintInfo());
                                }
                                else if (prcond.ToLower() == "old")
                                {
                                    prod.Condition = Condition.Used;
                                    Console.WriteLine("\n");
                                    Console.WriteLine("Updated Product\n");
                                    Console.WriteLine(prod.PrintInfo());
                                }
                                else {
                                    Console.WriteLine("\n!!!!!!!!!!!   FAILED   !!!!!!!!!!!\n");
                                    Console.WriteLine("Advert update change unsuccessful");
                                    Console.WriteLine("Please make sure you enter numbers only for the advert days");
                                    Console.WriteLine("\n!!!!!!!!!!!   FAILED   !!!!!!!!!!!\n\n");
                                }

                                Console.WriteLine("\nUpdate another field...");
                            break;
                            default:
                                another = false;
                                AdminHomePage();
                                break;
                        }

                    }
                }
                else
                {
                    Console.WriteLine("You don't appear to have such a product");
                    Console.WriteLine("Redirecting you in 3 seconds");
                    Thread.Sleep(3000);
                }

                valid = true;
            } catch (FormatException) {
            
                Console.WriteLine("\n!!!!!!!!!    INVALID INPUT !!!!!!!!!!!!!\n");
                Console.WriteLine("Please provide an number value");
                Console.WriteLine("Check the product ID field and copy the ID of the product of interest\n");
            }
        }
    }

    /**
     * <summary>
     * This function allows admins to remove an existing product(s) from the catalogue
     * </summary>
     */
    private void RemoveProduct()
    {
        Console.Clear();
        Console.WriteLine("+===================================+");
        Console.WriteLine("|     ADMIN REMOVE PRODUCT PAGE     |");
        Console.WriteLine("+===================================+");
        Console.WriteLine("\n");   

        _admin.Catalogue.Display();
        
        valid = false;
        Console.WriteLine("Please enter the product ID of the product you'd like to remove");
        Console.WriteLine("Type 'Exit' to go back");
        string? prId = Console.ReadLine();
        string prodId = (prId != null) ? prId : "";
        try {
            int productId = Int32.Parse(prodId);
            var prod = _admin.Catalogue.ListOfProduct.FirstOrDefault<Product>(n => n.ProdId == productId);
            if (prod != null) {
                _admin.Catalogue.RemoveItem( prod );
            }
            else {
                System.Console.WriteLine("You don't appear to have a product of that ID");
                System.Console.WriteLine("You can try again in 3 seconds");
                Thread.Sleep(3000);
                RemoveProduct();
            }
        } catch (FormatException) {
            if (prodId.ToLower() == "exit")
            {
                Console.WriteLine("Bye");
            } else {
                Console.WriteLine("Invalid ID format");
                Console.WriteLine("Please Try again in 3 sec");
            }
        }

        Thread.Sleep(3000);
        AdminHomePage();
    }
  
    /**
     * <summary>
     * This function provides a utility that allows admins to add product to the catalogue
     * </summary>
     */
    private void AddProduct()
    {
        Console.Clear();
        Console.WriteLine("+===================================+");
        Console.WriteLine("|       ADMIN ADD PRODUCT PAGE      |");
        Console.WriteLine("+===================================+");
        Console.WriteLine(); 

        Boolean another = true;
        while (another)
        {
            Console.WriteLine("\nPlease enter the name of the product");
            string? prnm = Console.ReadLine();
            string prname = (prnm != null) ? prnm : "";

            Console.WriteLine("\nPlease enter the description you'd like to assign the product");
            string? prds = Console.ReadLine();
            string prdesc = (prds != null) ? prds : "";

            int prce = 0;
            valid = false;
            while(valid == false)
            {
                Console.WriteLine("\nPlease make sure you enter numbers only for the price");
                Console.WriteLine("The assumed currency is MYR");
                Console.WriteLine("Please enter the price you'd like to assign the product");
                string? prpric = Console.ReadLine();
                string prPrice = (prpric != null) ? prpric : "";

                try {
                    prce = Int32.Parse(prPrice);
                    valid = true;
                } catch (FormatException)
                {
                    System.Console.WriteLine("\nWrong value price value!\n");
                }
            }

            Category category = new();
            if (_admin.Catalogue.Categories.Count > 0)
            {
                Console.WriteLine("\nPlease enter the category you'd like to assign the product");
                Console.WriteLine("You can either pick from the below category or provide a name to create a new one");
                Console.WriteLine();
                foreach(Category catgr in _admin.Catalogue.Categories) Console.WriteLine(catgr.Name);
                
                string? prct = Console.ReadLine();
                string prctgry = (prct != null) ? prct : "";

                var catgry = _admin.Catalogue.Categories.FirstOrDefault<Category>( n => n.Name.ToLower() == prctgry.ToLower() );
                if ( catgry != null ) category = catgry;
                else{
                    Category cat_new = new( prctgry );
                    category = cat_new;
                }

            }
            else {
                Console.WriteLine("\nYou don't appear to have any categories just yet");
                Console.WriteLine("Simply enter the name of a category to create one");

                string? prct = Console.ReadLine();
                string prctgry = (prct != null) ? prct : "";
                
                Category new_cat = new( prctgry );
                category = new_cat;

            }

            Console.WriteLine("\nIs this a new or an used product");
            Console.WriteLine("Simply enter 'new' or 'used'");
            string? prcd = Console.ReadLine();
            string prcond = (prcd != null) ? prcd : "";

            Condition cond = (prcond.ToLower() == "new") ? Condition.BrandNew : Condition.Used;
            
            Product new_prod = new(
                prname,
                prdesc,
                prce,
                cond,
                category
            );
            _admin.Catalogue.AddItem(new_prod);

            Console.WriteLine("\nProduct Added Successfully");
            Console.WriteLine("Would you like to add another product?");
            Console.WriteLine("Simply enter 'yes' or 'no'");
            string? resp = Console.ReadLine();
            string response = (resp != null) ? resp : "";

            another = (response.ToLower() == "no" ) ? false : true;
        }

        AdminHomePage();
    }
    
    /**
     * <summary>
     * This function provides a utility that allows admins to advertise 
     * existing products in the catalogue
     * </summary>
     */
    private void AdvertiseProduct()
    {
        Console.Clear();
        Console.WriteLine("+===================================+");
        Console.WriteLine("|  ADMIN PRODUCT ADVERTISING PAGE   |");
        Console.WriteLine("+===================================+");
        Console.WriteLine("\n");   

        _admin.Catalogue.Display();
        
        valid = false;
        Console.WriteLine("Please enter the product ID of the product you'd like to edit");
        Console.WriteLine("Type 'Exit' to go back");
        string? prId = Console.ReadLine();
        string prodId = (prId != null) ? prId : "";
        try {
            int productId = Int32.Parse(prodId);
            var prod = _admin.Catalogue.ListOfProduct.FirstOrDefault<Product>(n => n.ProdId == productId);
            if (prod != null) {
                while(valid == false)
                {
                    Console.WriteLine("Please make sure you enter numbers only for the advert days");
                    Console.WriteLine("Please enter the number of days you'd like to advertise the product for");
                    string? prad = Console.ReadLine();
                    string prAdvert = (prad != null) ? prad : "";

                    try {
                        valid = true;
                        int adDays = Int32.Parse(prAdvert);
                        prod.Advertise.Life = adDays;
                        Console.WriteLine("\n");
                        Console.WriteLine("Your advert is now on you can head to view products\n");
                        Console.WriteLine(prod.PrintInfo());
                        
                    } catch (FormatException) 
                    {
                        Console.WriteLine("\n!!!!!!!!!!!   FAILED   !!!!!!!!!!!\n");
                        Console.WriteLine("Advert update change unsuccessful");
                        Console.WriteLine("Please make sure you enter numbers only for the advert days");
                        Console.WriteLine("\n!!!!!!!!!!!   FAILED   !!!!!!!!!!!\n\n");
                    }
                }
            }
            else {
                System.Console.WriteLine("You don't appear to have a product of that ID");
                System.Console.WriteLine("You can try again in 3 seconds");
                Thread.Sleep(3000);
                AdvertiseProduct();
            }
        } catch (FormatException) {
            if (prodId.ToLower() == "exit")
            {
                Console.WriteLine("Bye");
            } else {
                Console.WriteLine("Invalid ID format");
                Console.WriteLine("Please Try again in 3 sec");
            }
        }

        Thread.Sleep(3000);
        AdminHomePage();
    }

    /**
     * <summary>
     * This function provides a utility that allows admins to view products in the catalogue
     * </summary>
     */
    private void ViewProducts()
    {
        Console.Clear();
        Console.WriteLine("+===================================+");
        Console.WriteLine("|        PRODUCT VIEW HOME PAGE     |");
        Console.WriteLine("+===================================+");
        Console.WriteLine("\n");
        Console.WriteLine("Welcome to the Product View Home Page");
        // List out all products
        if (_admin.Catalogue.ListOfProduct.Count > 0){

            _admin.Catalogue.Display();

            Console.WriteLine("How would you like to proceed");
            Console.WriteLine("1. Edit Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. Advertise Product");
            Console.WriteLine("4. Update Product");
            Console.WriteLine("5. Add Product");
            Console.WriteLine("6. Back to Home Page");

            string? val = Console.ReadLine();
            string answer = (val != null) ? val : "";

            switch (answer)
            {
                case "1":
                    EditProduct();
                    break;
                case "2":
                    RemoveProduct();
                    break;
                case "3":
                    AdvertiseProduct();
                    break;
                case "4":
                    EditProduct();
                    break;
                case "5":
                    AddProduct();
                    break;
                case "6":
                    AdminHomePage();
                    break;
                default:
                    Console.WriteLine("=====================================");
                    Console.WriteLine("| Please Pick an option to continue |");
                    Console.WriteLine("=====================================");
                    ViewProducts();
                    break;
            }

        } else {
            Console.WriteLine("You dont have any Products at this time");
            Console.WriteLine("consider adding some products your catalogue");

            Console.WriteLine("How would you like to proceed");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Back to Home Page");

            string? val = Console.ReadLine();
            string answer = (val != null) ? val : "";

            switch (answer)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    AdminHomePage();
                    break;
                default:
                    Console.WriteLine("=====================================");
                    Console.WriteLine("| Please Pick an option to continue |");
                    Console.WriteLine("=====================================");
                    ViewProducts();
                    break;
            }
        }
    }

    /**
     * <summary>
     * This function provides a utility that allows admins to view customer orders made
     * </summary>
     */
    private void ShowOrders()
    {
        foreach (Order item in _orders) item.Print();
    }
   
    /**
     * <summary>
     * This function allows the admin to chose how to respond to a customer order. Whether to accept or reject it.
     * </summary>
     * <param name="action">either 'accept' or 'reject' to indicate how to respond to a customer order</param>
     */
    private void ActOnOrder(string action)
    {
        valid = false;

        while (valid == false)
        {
            Console.Clear();
            Console.WriteLine("+===================================+");
            string title = (action == "confirm") 
                ? "|      ORDERS CONFIRMATION PAGE     |" 
                : "|      ORDERS CANCELLATION PAGE     |";

            Console.WriteLine(title);
            Console.WriteLine("+===================================+");
            Console.WriteLine("\n");
            ShowOrders();
            Console.WriteLine($"Please enter the Order ID of the order you'd like to {action}");
            Console.WriteLine("Type 'Exit' to go back");

            string? val = Console.ReadLine();
            string answer = (val != null) ? val : "";
            try 
            {
                int ordId = Int32.Parse(answer);
                var order = _orders.FirstOrDefault<Order>( n => n.OrderId == ordId );
                if (order != null)
                {
                    if (action.ToLower() == "confirm"){
                        order.OrdProgress = Progress.Shipped;
                        Console.WriteLine("Thanks for confirming the order.");
                        Console.WriteLine("Order Progress was updates to 'Shipped' \n");
                        Console.WriteLine("\n");
                        Console.WriteLine("How would you like to proceed");
                        Console.WriteLine("1. Confirm An Order");
                        Console.WriteLine("2. Reject An Order");
                        Console.WriteLine("3. Go Back to Orders");
                        Console.WriteLine("4. Go Back to HomePage");
                    } 
                    else if (action.ToLower() == "reject")
                    {
                        _orders.Remove( order );
                        Console.WriteLine("Order Cancelled.");
                        Console.WriteLine("Customer has been notified");
                        Console.WriteLine("\n");
                        Console.WriteLine("How would you like to proceed");
                        Console.WriteLine("1. Confirm An Order");
                        Console.WriteLine("2. Reject An Order");
                        Console.WriteLine("3. Go Back to Orders");
                        Console.WriteLine("4. Go Back to HomePage");
                    }
                    
                }
            } catch (System.FormatException){
                if (answer.ToLower() == "Exit".ToLower())
                {
                    Console.WriteLine("Bye");
                    ViewOrders();
                } else {
                    Console.WriteLine("Wrong Input");
                }
            }
            switch(answer)
            {
                case "1":
                    ActOnOrder("confirm");
                    break;
                case "2":
                    ActOnOrder("reject");
                    break;
                case "3":
                    ViewOrders();
                    break;
                case "4":
                    AdminHomePage();
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Please pick an option to proceed.");
                    Console.WriteLine("Be sure to enter just the number of the option you'd like to proceed with.");
                    ViewOrders();
                    break;
            }

        }
    }

    /**
     * <summary>
     * This function allows the admin to view and act on the orders placed by customers
     * </summary>
     */
    private void ViewOrders()
    {
        Console.Clear();
        Console.WriteLine("+===================================+");
        Console.WriteLine("|        ORDERS VIEW HOME PAGE      |");
        Console.WriteLine("+===================================+");
        Console.WriteLine("\n");
        Console.WriteLine("Welcome to the Orders View Home Page");
        if (_orders.Count < 0){
            for( var i=0; i< _orders.Count; i++ ){
                _orders[i].AdminPrint();

            }
            Console.WriteLine();
            Console.WriteLine("How would you like to proceed");
            Console.WriteLine("Please enter the number of the option you'd like to proceed with");
            Console.WriteLine("1. Confirm Order");
            Console.WriteLine("2. Cancel Order");
            Console.WriteLine("3. Back to HomePage");

            string? val = Console.ReadLine();
            string answer = (val != null) ? val : "";

            switch(answer)
            {
                case "1":
                    ActOnOrder("confirm");
                    break;
                case "2":
                    ActOnOrder("reject");
                    break;
                case "3":
                    AdminHomePage();
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Please pick an option to proceed.");
                    Console.WriteLine("Be sure to enter just the number of the option you'd like to proceed with.");
                    ViewOrders();
                    break;
            }

        } else {
            Console.WriteLine("You have no orders at this time. Please check again later");

            Console.WriteLine();
            Console.WriteLine("How would you like to proceed");
            Console.WriteLine("Please enter the number of the option you'd like to proceed with");
            Console.WriteLine("1. Back to HomePage");

            string? val = Console.ReadLine();
            string answer = (val != null) ? val : "";

            switch(answer)
            {
                case "1":
                    AdminHomePage();
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Please pick an option to proceed.");
                    Console.WriteLine("Be sure to enter just the number of the option you'd like to proceed with.");
                    ViewOrders();
                    break;
            }
        }
    }
    
    /**
     * <summary>
     * This function allows the admin to either add or remove a category from 
     * the list of categories in the catalogue
     * </summary>
     * <param name="action">
     * either 'add' or 'remove' to indicate how to respond to a category in the catalogue
     * </param>
     */
    private void OperateCategory(string action)
    {
        Console.Clear();
        Console.WriteLine("+===================================+");
        string title = (action == "add") 
            ? "|        ADD CATEGORIES PAGE        |" 
            : "|       REMOVE CATEGORIES PAGE      |";

        Console.WriteLine(title);
        Console.WriteLine("+===================================+");
        Console.WriteLine("\n");

        foreach(Category catg in _admin.Catalogue.Categories) Console.WriteLine(catg.Name);
        Console.WriteLine();
        Console.WriteLine($"What's the name of the category you'd like to {action}");
        Console.WriteLine("Type 'Exit' to go back");

        string? val = Console.ReadLine();
        string answer = (val != null) ? val : "";

        if (answer.ToLower() != "exit")
        {
            if (action == "add")
            {
                Random rand = new();

                Category catgry = new( answer );
                _admin.Catalogue.Categories.Add( catgry );

            }
            else if (action == "remove")
            {
                Console.WriteLine("Please enter the name of the category you'd like to remove");
                string? rem = Console.ReadLine();
                string remove = (rem != null) ? rem : "";

                var catgry = _admin.Catalogue.Categories.FirstOrDefault<Category>( n => n.Name == remove );
                if (catgry != null)
                {
                    _admin.Catalogue.Categories.Remove( catgry );
                    Console.WriteLine("Category Successfully removed");
                }
                else {
                    Console.WriteLine("Invalid Category");
                }
            }
            
        }
        else {
            Console.WriteLine("Bye");
        }

        ViewCategories();
    }

    /**
     * <summary>
     * This function allows the admin to view the categories in the 
     * catalogue. It also provides a utility menu where they can either add new or remove existing
     * categories
     * </summary>
     */
    private void ViewCategories()
    {
        Console.Clear();
        Console.WriteLine("+===================================+");
        Console.WriteLine("|     CATEGORIES VIEW HOME PAGE     |");
        Console.WriteLine("+===================================+");
        Console.WriteLine("\n");
        Console.WriteLine("Welcome to the Categories View Home Page");
        // List out all categories
        if (_admin.Catalogue.Categories.Count > 0){
            foreach(Category item in _admin.Catalogue.Categories)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("How would you like to proceed");
            Console.WriteLine("Please enter the number of the option you'd like to proceed with");
            Console.WriteLine("1. Add Category");
            Console.WriteLine("2. Remove Category");
            Console.WriteLine("3. Back to HomePage");

            string? val = Console.ReadLine();
            string answer = (val != null) ? val : "";

            switch(answer)
            {
                case "1":
                    OperateCategory("add");
                    break;
                case "2":
                    OperateCategory("remove");
                    break;
                case "3":
                    AdminHomePage();
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Please pick an option to proceed.");
                    Console.WriteLine("Be sure to enter just the number of the option you'd like to proceed with.");
                    ViewCategories();
                    break;
            }
        } else {
            Console.WriteLine("You'll need to add some products to the catalogue for categories to be detected");

            Console.WriteLine();
            Console.WriteLine("How would you like to proceed");
            Console.WriteLine("Please enter the number of the option you'd like to proceed with");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Add Category");
            Console.WriteLine("3. Remove Category");
            Console.WriteLine("4. Back to HomePage");

            string? val = Console.ReadLine();
            string answer = (val != null) ? val : "";

            switch(answer)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    OperateCategory("add");
                    break;
                case "3":
                    OperateCategory("remove");
                    break;
                case "4":
                    AdminHomePage();
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Please pick an option to proceed.");
                    Console.WriteLine("Be sure to enter just the number of the option you'd like to proceed with.");
                    ViewCategories();
                    break;
            }
        }
    }

    /**
     * <summary>
     * This function allows the admin to respond to customer trade proposals
     * </summary>
     * <param name="action">
     * either 'accept' or 'reject' to indicate how to respond to a customer trade proposal
     * </param>
     */
    private void ProsopsalResponse(string action)
    {
        Boolean another = true;
        while (another)
        {
            Console.WriteLine($"Please enter the ID of the proposal you'd like to {action}");
            string? resp = Console.ReadLine();
            string response = (resp != null) ? resp : "";

            try {
                int trPropId = Int32.Parse(response);

                var proposal = _tradeProposal.FirstOrDefault<TradeProposal>(n => n.TrID == trPropId);
                if (proposal != null)
                {
                    if (action.ToLower() == "accept")
                    {
                        proposal.Status = TrStatus.Approved;
                        Console.WriteLine("\n-------------------------------------");
                        Console.WriteLine("Proposal status updated to 'Approved'");
                        Console.WriteLine("-------------------------------------\n");
                        
                    }
                    else if (action.ToLower() == "reject")
                    {
                        proposal.Status = TrStatus.Rejected;
                        Console.WriteLine("\n-------------------------------------");
                        Console.WriteLine("Proposal status updated to 'Rejected'");
                        Console.WriteLine("-------------------------------------\n");
                    }

                    Console.WriteLine("Would you like to act on another proposal?");
                    string? ans = Console.ReadLine();
                    string answer = (ans != null) ? ans : "";

                    another = (answer.ToLower() == "yes") ? true : false;

                }
                else {
                    Console.WriteLine("Sorry you don't appear to have a proposal of that ID");
                    Console.WriteLine("\nPlease wait. Redirecting you in 3 seconds...\n");
                    ViewTradeProposal();
                }
                

            } catch (FormatException){
                if (response.ToLower() == "exit")
                {
                    another = false;
                }
                else {
                    Console.WriteLine("\n!!!!!!     INVALID INPUT   !!!!!!!\n");
                    Console.WriteLine("Please enter a numerical value");
                }
            }

        }
        AdminHomePage();
    }
 
    /**
     * <summary>
     * This function allows the admin to view the trade proposals from customers.
     * It also provides a utility menu where they can either accept or reject 
     * proposals
     * </summary>
     */
    public void ViewTradeProposal()
    {
        Console.Clear();
        Console.WriteLine("+===================================+");
        Console.WriteLine("|  TRADE PROPOSALS VIEW HOME PAGE   |");
        Console.WriteLine("+===================================+");
        Console.WriteLine("\n");
        Console.WriteLine("Welcome to the Trade Proposals View Home Page");
        if(_tradeProposal.Count > 0){

            foreach(TradeProposal item in _tradeProposal)
            {
                item.AdminPrint();
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("How would you like to proceed");
            Console.WriteLine("Please enter the number of the option you'd like to proceed with");
            Console.WriteLine("1. Accept Proposal");
            Console.WriteLine("2. Reject Proposal");
            Console.WriteLine("3. Back to HomePage");

            string? val = Console.ReadLine();
            string answer = (val != null) ? val : "";

            switch(answer)
            {
                case "1":
                    ProsopsalResponse("accept");
                    break;
                case "2":
                    ProsopsalResponse("reject");
                    break;
                case "3":
                    AdminHomePage();
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Please pick an option to proceed.");
                    Console.WriteLine("Be sure to enter just the number of the option you'd like to proceed with.");
                    ViewTradeProposal();
                    break;
            }
        } else {
            Console.WriteLine("You don't seem to have any proposals at this time.");
            Console.WriteLine("Please check again later");
            Console.WriteLine();
            Console.WriteLine("How would you like to proceed");
            Console.WriteLine("Please enter the number of the option you'd like to proceed with");
            Console.WriteLine("1. Back to HomePage");

            string? val = Console.ReadLine();
            string answer = (val != null) ? val : "";

            switch(answer)
            {
                case "1":
                    AdminHomePage();
                    break;
                default:
                    Console.WriteLine("\n");
                    Console.WriteLine("Please pick an option to proceed.");
                    Console.WriteLine("Be sure to enter just the number of the option you'd like to proceed with.");
                    ViewTradeProposal();
                    break;
            }
        }
    }

}

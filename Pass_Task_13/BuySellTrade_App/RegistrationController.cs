using System;
using BuySellTrade_App.Components;
namespace BuySellTrade_App;

public class RegistrationController
{
    private int _oneTimePassword;
    private List<Customer> _member;
    private Admin _admin;
    private List<Order> _orders;
    private List<TradeProposal> _tradeProposal;

    private Boolean valid;

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
    public void LogIn(string name, string password)
    {
        _admin.LoggedIn = true;
    }
    public void LogIn(int phone, int OTP)
    {
        _admin.LoggedIn = true;
    }
    public void LogOut(User user)
    {
        _admin.LoggedIn = false;
    }

    private void UpdateCustomerCart(Customer customer)
    {
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

    private void AddCustomerCart(Customer customer)
    {
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
        Console.WriteLine();
        Console.WriteLine("How would you like to proceed");
        Console.WriteLine("Please enter the number of the option you'd like to proceed with");
        Console.WriteLine("1. Add another Item");
        Console.WriteLine("2. Checkout");
        Console.WriteLine("3. Homepage");
        Console.WriteLine("4. Update Cart");
        Console.WriteLine("5. LogOut");
        string? next = Console.ReadLine();
        string goNext = (next != null) ? next : "";

        switch(goNext)
        {
            case "1":
            AddCustomerCart(customer);
            break;
            case "2":
            customer.CheckOut();
            break;
            case "3":
            CustomerHomePage(customer);
            break;
            case "4":
            UpdateCustomerCart(customer);
            break;
            default:
            Console.WriteLine("wrong input!");
            CustomerHomePage(customer);
            break;
        }
    }

    public void AdminHomePage()
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
    public void CustomerHomePage(Customer customer)
    {
        Console.Clear();
        Console.WriteLine("+===================================+");
        Console.WriteLine("|        CUSTOMER HOME PAGE         |");
        Console.WriteLine("+===================================+");
        Console.WriteLine("\n");
        Console.WriteLine("Welcome to the Customer Home Page");
        _admin.Catalogue.Display();

        if (customer.LoggedIn){
            Console.WriteLine();
            Console.WriteLine("How would you like to proceed");
            Console.WriteLine("Please enter the number of the option you'd like to proceed with");
            Console.WriteLine("1. Add To Cart");
            Console.WriteLine("2. Checkout");
            Console.WriteLine("3. Sell Product");
            Console.WriteLine("4. Update Cart");
            Console.WriteLine("5. LogOut");

            string? val = Console.ReadLine();
            string answer = (val != null) ? val : "";

            switch(answer)
            {
                case "1":
                    AddCustomerCart(customer);
                    break;
                case "2":
                    customer.CheckOut();
                    break;
                case "3":
                    TradeProduct(customer);
                    break;
                case "4":
                    UpdateCustomerCart(customer);
                    break;
                case "5":
                    customer.LoggedIn = false;
                    WelcomePage();
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Please pick an option to proceed.");
                    Console.WriteLine("Be sure to enter just the number of the option you'd like to proceed with.");
                    ViewTradeProposal();
                    break;
            }
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

            Console.WriteLine("Please propose the product price");
            Console.WriteLine("Enter Numbers only, value in Malaysian Ringit");
            string? trprc = Console.ReadLine();
            string trPrice = (trprc != null) ? trprc : "";

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
        _tradeProposal.Add( trPropose );

    }

    private void EditProduct()
    {
        
    }
    private void RemoveProduct()
    {

    }
    private void AddProduct()
    {

    }
    private void AdvertiseProduct()
    {

    }
    private void UpdateProduct()
    {

    }

    public void ViewProducts()
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
                    UpdateProduct();
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

    private void ShowOrders()
    {
        foreach (Order item in _orders) item.Print();
    }
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

    public void ViewOrders()
    {
        Console.Clear();
        Console.WriteLine("+===================================+");
        Console.WriteLine("|        ORDERS VIEW HOME PAGE      |");
        Console.WriteLine("+===================================+");
        Console.WriteLine("\n");
        Console.WriteLine("Welcome to the Orders View Home Page");
        if (_orders.Count < 0){
            for( var i=0; i< _orders.Count; i++ ){
                Console.WriteLine($"Product {i+1}.\n{_orders[i].Print()}");

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

    public void ViewCategories()
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
                item.Print();
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
                    // Accepts Proposal  && proposal gets removed from the proposal list
                    break;
                case "2":
                    // rejects proposal && proposal gets removed from the proposal list
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
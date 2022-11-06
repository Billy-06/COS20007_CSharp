using System.Collections.Generic;
namespace BuySellTrade_App.Components;

/**
 * <summary>
 * This is the Customer class used for instatiating customers in 
 * the application. This class inherits from the abstract User
 * class and implements a additional attributes namely;<br/>
 * Cart, Order, TradeProposal
 * </summary>
 */
public class Customer : User 
{
    private List<Product> _cart;
    private List<Order> _order;
    private List<TradeProposal> _tradeProposed;

    /**
     * <summary>
     * This is a pass by value constructor of the customer class
     *  that accepts the below parameters<br/>
     * Name, Email, Password, Phone
     * <br/>
     * This constructor initialises the cart to an empty list, 
     * the orders to an empty list, and the trade Proposal to 
     * an empty list.
     * </summary>
     * <param name="name"></param>
     * <param name="email"></param>
     * <param name="password"></param>
     * <param name="phone"></param>
     */
    public Customer(string name, string email, string password, int phone) 
        : base (name, email, password, phone)
    {
        base.LoggedIn = false;
        _cart = new();
        _order = new();
        _tradeProposed = new();
    }

    /**
     * <summary>
     * This is a property for customer trade proposal field
     * </summary>
     * 
     * <value>The trade proposal by the customer</value>
     * 
     * <returns>
     * Returns a list of trade proposals by the customer
     * </returns>
     */
    public List<TradeProposal> TradeProposed
    {
        get => _tradeProposed;
        set => _tradeProposed = value;
    }

     /**
     * <summary>
     * This is a property for customer orders field
     * </summary>
     * 
     * <value>The orders by the customer</value>
     * 
     * <returns>
     * Returns a list of orders by the customer
     * </returns>
     */
    public List<Order> CustOrders
    {
        get => _order;
        set => _order = value;
    }

     /**
     * <summary>
     * This is a property for customer cart field
     * </summary>
     * 
     * <value>The cart of the customer</value>
     * 
     * <returns>
     * Returns an list of products in the customer cart 
     * </returns>
     */
    public List<Product> Cart 
    {
        get => _cart;
        set => _cart = value;
    }
    
    /**
     * <summary>
     * This function adds a product to the customer cart. It takes a product
     * as a parameter and appends it to the cart.
     * </summary>
     * <param name="prod">The product to be added to cart</param>
     */
    public void AddToCart(Product prod)
    {
        _cart.Add( prod );
    }

    /**
     * <summary>
     * This function removes a product from the customer cart. It takes a product
     * as a parameter and pops it to out of the cart.
     * </summary>
     * <param name="prod">The product to be removed from cart</param>
     */
    public void RemoveFromCart(Product prod)
    {
        _cart.Remove( prod );
    }

    /**
     * <summary>
     * This function checks the customer out by adding the products in the
     *  cart to an order object. It also clears up the carts after doing so.
     * </summary>
     */
    public void CheckOut()
    {
        if (_cart.Count > 0)
        {
            Order thisOrd = new( _cart, base.Name );
            _order.Add( thisOrd );

            _cart.RemoveAll( n => n.Name != "" );

            Console.WriteLine("You've successfully checked out");
            Console.WriteLine("You can now see your orders in the orders section. Thanks");

        }
        else {
            Console.WriteLine("You have an empty cart");
            Console.WriteLine("Consider adding some products in order to check out");

        }

    }

    /**
     * <summary>
     * This function prints out the customer cart on condition that
     *  there are item in the cart. Otherwise it notifies the customer of the
     * empty cart.
     * </summary>
     */
    public void ShowCart()
    {
        if (_cart.Count > 0)
        {
            Console.WriteLine("\n====================");
            Console.WriteLine("  Your Updated Cart ");
            Console.WriteLine("====================");
            foreach(Product prod in _cart)
            {
                Console.WriteLine(prod.PrintInfo());
            }

        } 
        else if (_cart.Any<Product>() == false)
        {
            Console.WriteLine("\n=========================");
            Console.WriteLine("  You Have an Empty Cart ");
            Console.WriteLine("=========================");

        }
    }
    
    /**
     * <summary>
     * This product prints out the customer details including the number of 
     * items in the cart, the number of orders placed and 
     * the number of trade proposals placed
     * </summary>
     * 
     * <returns>
     * Details of the customer, number of items in the cart, 
     * the number of trade proposals placed and number of orders placed
     * </returns>
     */
    public override string PrintInfo()
    {
        return $"Name: {base.Name}\nEmail: {base.Email}\nPhone: {base.Phone}\nCart Content: Cart has {_cart.Count} items\nOrders Sent: {_order.Count} orders sent\nTradeProposals Sent: {_tradeProposed.Count} proposals sent\n";
    }
}
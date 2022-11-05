using System.Collections.Generic;
namespace BuySellTrade_App.Components;

public class Customer : User 
{
    private List<Product> _cart;
    private List<Order> _order;

    public Customer(string name, string email, string password, int phone) 
        : base (name, email, password, phone)
    {
        base.LoggedIn = false;
        _cart = new();
        _order = new();
    }

    public List<Product> Cart 
    {
        get => _cart;
        set => _cart = value;
    }
    
    public void AddToCart(Product prod)
    {
        _cart.Add( prod );
    }

    public void RemoveFromCart(Product prod)
    {
        _cart.Remove( prod );
    }

    public void CheckOut()
    {
        Order thisOrd = new( _cart );
        _order.Add( thisOrd );

        if (_cart.Count > 0){
            foreach(Product item in _cart){
                _cart.Remove( item );
            }
        }

        Console.WriteLine("You've successfully checked out");
        Console.WriteLine("You can now see your orders in the orders section. Thanks");

    }
    public void TrackOrder(Product prod)
    {

    }

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
    

    public override string PrintInfo()
    {
        return $"Name: {base.Name}\nEmail: {base.Email}\nPhone: {base.Phone}\nCart Content: Cart has {_cart.Count} items\nOrders Sent: You have {_order.Count} orders sent\n";
    }
}
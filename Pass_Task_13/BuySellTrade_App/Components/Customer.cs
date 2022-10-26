using System.Collections.Generic;
namespace BuySellTrade_App.Components;

public class Customer : User 
{
    private Cart _cart;
    private List<Cart> _order;

    public Customer(string name, string email, string password, int phone) 
        : base (name, email, password, phone)
    {
        base.LoggedIn = false;
        _cart = new();
        
        _order = new();
        _order.Add( _cart );
    }

    public Cart Cart 
    {
        get => _cart;
        set => _cart = value;
    }
    

    public override string PrintInfo()
    {
        return $"Name: {base.Name}\nEmail: {base.Email}\nPhone: {base.Phone}\nCart Content: Cart has {_cart.CartItems()} items\n";
    }
}
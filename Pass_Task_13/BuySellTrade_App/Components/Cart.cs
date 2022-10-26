namespace BuySellTrade_App.Components;

public class Cart
{
    private List<Product> _products;

    public List<Product> Products
    {
        get => _products;
        set => _products = value;
    }

    public int CartItems() => _products.Count;

}
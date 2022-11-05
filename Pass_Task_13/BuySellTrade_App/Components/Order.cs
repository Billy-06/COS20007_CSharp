using System.Collections.Generic;
namespace BuySellTrade_App.Components;

public class Order
{
    private int _orderId;
    private DateTime _ordDate;
    private List<Product> _ordProducts;
    private Progress _ordProgress;

    public DateTime OrdDate 
    {
        get => _ordDate;
        set => _ordDate = value;
    }

    public List<Product> OrdProducts 
    {
        get => _ordProducts;
        set => _ordProducts = value;
    }
    public int OrderId 
    {
        get => _orderId;
        set => _orderId = value;
    }
    public Progress OrdProgress 
    {
        get => _ordProgress;
        set => _ordProgress = value;
    }

    public Order(List<Product> prods)
    {
        Random rand = new();
        _orderId = rand.Next(100, 800);
        _ordDate = new();
        _ordProducts = prods;
        _ordProgress = Progress.ReadToShip;
    }
    public string Print()
    {
        return $"";
    }
}

public enum Progress
{
    ReadToShip,
    Shipped,
    InTransit,
    Delivered
}
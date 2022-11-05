using System.Collections.Generic;
namespace BuySellTrade_App.Components;

public class TradeProposal
{
    private string _customerName;
    private DateTime _trDate;
    private List<Product> _trProducts;

    private TrStatus _status;

    public string CustomerName 
    {
        get => _customerName;
        set => _customerName = value;
    }
    public DateTime TrDate 
    {
        get => _trDate;
        set => _trDate = value;
    }
    public List<Product> TrProducts 
    {
        get => _trProducts;
        set => _trProducts = value;
    }
    public TrStatus Status 
    {
        get => _status;
        set => _status = value;
    }

    public TradeProposal(List<Product> prods, string custName)
    {
        _trDate = new();
        _trProducts = prods;
        _customerName = custName;
        _status = TrStatus.Pending;

    }

    public void Print()
    {
        Console.WriteLine($"Customer Name: {_customerName}\nDate: {_trDate}\nStatus: {_status}");
        foreach(Product item in _trProducts) Console.WriteLine(item.PrintInfo());
    }

}

public enum TrStatus
{
    Pending,
    Approved,
    Rejected
}
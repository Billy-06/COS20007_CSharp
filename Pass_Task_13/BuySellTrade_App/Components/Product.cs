namespace BuySellTrade_App.Components;

public class Product
{
    private int _prodId;
    private string _name;
    private double _price;
    private string _description;

    private Condition _condition;

    private Category _category;

    public Boolean Advertise { get; set; }

    public int ProductId
    {
        get => _prodId;
        set => _prodId = value;
    }
    public string Name 
    {
        get => _name;
        set => _name = value;
    }
    public double Price 
    {
        get => _price;
        set => _price = value;
    }
    public string Description 
    {
        get => _description;
        set => _description = value;
    }

    public string PrintInfo()
    {
        return $"Name: {_name}\nCategory: {_category}\nPrice: {_price}\nDescription: {_description}\nCondition: {_condition.ToString()}\n";
    }
}

[Flags]
public enum Condition
{
    BrandNew = 1,
    Used = 2
}
namespace BuySellTrade_App.Components;

public class Product
{
    private int _prodId;
    private string _name;
    private double _price;
    private string _description;

    private Condition _condition;

    private Category _category;

    public Advertisement Advertise { get; set; }

    public int ProdId
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
    public Condition Condition 
    {
        get => _condition;
        set => _condition = value;
    }
    public Category Category 
    {
        get => _category;
        set => _category = value;
    }
    public string Description 
    {
        get => _description;
        set => _description = value;
    }

    public Product(string name, string description, double price, Condition condition, Category category)
    {
        _prodId = 0;

        _name = name;
        _description = description;
        _price = price;
        _condition = condition;
        _category = category;
        Advertise = new();
    }

    public string PrintInfo()
    {
        if (_prodId == 0) {

            Console.WriteLine("Warning:\n================\nThis product has no ID");
            Console.WriteLine("Please add this product to the catalogue so it can get assigned an ID");
            return $"Product ID: *Missing*\nName: {_name}\nCategory: {_category.Name}\nPrice: {_price}\nDescription: {_description}\nCondition: {_condition.ToString()}\n";
            
        } else {

            return $"Product ID: {_prodId}\nName: {_name}\nCategory: {_category.Name}\nPrice: {_price}\nDescription: {_description}\nCondition: {_condition.ToString()}\n";
        }
    }
}

[Flags]
public enum Condition
{
    BrandNew = 1,
    Used = 2
}
namespace Week4_Exercise.MyObjects;

public abstract class Product
{
    private string _name = string.Empty;
    private int _price;
    private int _quantity;

    public Product()
    {
        _name = "Name not Provided";
        _price = 0;
        _quantity = 0;
    }

    public Product(string name, int price, int quantity)
    {
        _name = name;
        _price = price;
        _quantity = quantity;   
    }

    public string Name 
    {
        get => _name;
        set => _name = value;
    }
    public int Price 
    {
        get => _price;
        set => _price = value;
    }
    public int Quantity 
    {
        get => _quantity;
        set => _quantity = value;
    }

    public abstract void PrintInfo();
    
}
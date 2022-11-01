namespace BuySellTrade_App.Components;

public class Category
{
    private string _name;

    public string Name 
    {
        get => _name;
        set => _name = value;
    }

    public Category()
    {
        _name = string.Empty;
    }
    public Category(string name)
    {
        _name = name;
    }
}
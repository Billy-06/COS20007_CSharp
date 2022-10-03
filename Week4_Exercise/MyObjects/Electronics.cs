namespace Week4_Exercise.MyObjects;

public class Electronics : Product
{
    private int _watt;

    public Electronics(): base()
    {
        _watt = 0;
    }

    public Electronics(string name, int price, int quantity, int watt) : base (name, price, quantity)
    {
        _watt = watt;
    }

    public int Watt
    {
        get => _watt;
        set => _watt = value;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Name: {base.Name}\nPrice: {base.Price}\nQuantity: {base.Quantity}\nWatts: {this._watt}");
    }

}
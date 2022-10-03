namespace Week4_Exercise.MyObjects;

public class Furniture : Product
{
    private int _width;
    private int _height;

    public Furniture() : base()
    {
        _height = 0;
        _width = 0;
    }

    public Furniture(string name, int price, int quantity, int width, int height) : base(name, price, quantity)
    {
        _width = width;
        _height = height;
    }

    public int Width 
    {
        get => _width;
        set => _width = value;
    }
    public int Height 
    {
        get => _height;
        set => _height = value;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Name: {base.Name}\nPrice: {base.Price}\nQuantity: {base.Quantity}\nWidth: {this._width}\nHeight: {this._height}");
    }
}
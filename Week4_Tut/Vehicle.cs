namespace Week4_Tut;

public abstract class Vehicle
{
    private int _wheels;
    private double _weight;


    public Vehicle(int wheels, double weight)
    {
        _wheels = wheels;
        _weight = weight;
    }

    public int Wheels 
    {
        get => _wheels;
    }
    public double Weight 
    {
        get => _weight;
    }

    public abstract string PrintInfo();
    public double WheelLoad() => (_weight / _wheels);
    
}
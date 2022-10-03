namespace Week4_Tut;

public class Car : Vehicle
{
    private int _passengerLoad;

    public Car(int wheels, double weight) : base (wheels, weight)
    {
        _passengerLoad = 4;
    }

    public int PassengerLoad 
    {
        get => _passengerLoad;
    }

    public override string PrintInfo()
    {
        return $"Weight: {base.Weight}\nWheels: {base.Wheels}\nPassenger Load: {this._passengerLoad}\nWheel Load: {base.WheelLoad()}";
    }
}
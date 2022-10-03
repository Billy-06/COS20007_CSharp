namespace Week4_Tut;

public class Truck : Vehicle
{
    private double _payload;

    public Truck(int wheels, double weight, double payload) : base (wheels, weight)
    {
        _payload = payload;
    }

    public double Payload 
    {
        get => _payload;
        set => _payload = value;
    }

    public double Efficiency() => (_payload / (_payload/base.Weight) );
    
    public override string PrintInfo()
    {
        return $"Weight: {base.Weight}\nWheels: {base.Wheels}\nWheel Load: {base.WheelLoad()}\nPayload: {this._payload}\nEfficiency: {this.Efficiency()}";
    }
}
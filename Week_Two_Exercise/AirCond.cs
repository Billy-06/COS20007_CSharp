using System;
namespace Week_Two_Exercise;

public class AirCond
{
    private string _model;
    private string _brand;
    private double _temperature;
    private int _coolingCapacity;

    public AirCond(string model, string brand, int coolingCapacity, double temperature )
    {
        _model = model;
        _brand = brand;
        _coolingCapacity = coolingCapacity;
        _temperature = temperature;
        
    }
    public double Temperature 
    { 
        get { return _temperature; }
        set { _temperature = value; }
    }

    public void IncreaseTemp()
    {
        _temperature += 0.1;
    }
    public void DecreaseTemp()
    {
        _temperature -= 0.1;
    }

    public void PrintDetails()
    {
        Console.WriteLine("\n===== About this Air Cond ============");
        Console.WriteLine($"Model: {_model}\nBrand: {_brand}\nTemperature: {_temperature}\nCooling Capacity: {_coolingCapacity}\n");
    }

    


}
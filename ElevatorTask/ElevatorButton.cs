using System;
namespace ElevatorTask;

public class ElevatorButton : Button
{
    private int _floorNumber;

    public ElevatorButton(int floorNumber) : base()
    {
        _floorNumber = floorNumber;
    }
    public int FloorNumber 
    {
        get => _floorNumber;
        set => _floorNumber = value;
    }
    public override string Press()
    {
        if (!base.Illuminate) base.Illuminate = true;
        return $"You've pressed Floor number {_floorNumber}";
    }
}
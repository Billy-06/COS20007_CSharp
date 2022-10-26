using System;
namespace ElevatorTask;

public abstract class Button 
{
    private Boolean _illuminate;
    public Button()
    {
        _illuminate = false;   
    }
    public Boolean Illuminate 
    {
        get => _illuminate;
        set => _illuminate = value;
    }

    public abstract string Press();

    public void Release()
    {
        if (_illuminate) _illuminate = false;
        Console.WriteLine("Illumination is now off");
    }
}
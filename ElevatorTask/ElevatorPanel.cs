using System;
using System.Collections.Generic;
namespace ElevatorTask;
public class ElevatorPanel
{
    private List<Button> _buttons;

    public ElevatorPanel()
    {
        _buttons = new();
    }

    List<Button> Buttons 
    {
        get => _buttons;
        set => _buttons = value;
    }

    public void AddButton(Button button)
    {
        _buttons.Add( button );
    }

    public List<Button> retrievIlluminate()
    {
        List<Button> illuminated_Buttons = new();
        foreach(Button item in _buttons){
            if (item.Illuminate ) illuminated_Buttons.Add( item );
        }
        return illuminated_Buttons;
    }

    public void Reset()
    {

    }
}
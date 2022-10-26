using System;

namespace Week7_Class;

public class Potion : Component
{
    private Boolean _healer;


    public Potion() : base ()
    {
        _healer = false;
    }

    public Boolean Healer 
    {
        get => _healer;
        set => _healer = value;
    }

    public override string Execute(Category type)
    {
        _healer = true;
        if (type == Category.Beginner || type == Category.Intermediate) {
            _count++;
            return "Healing In Progress";
        }
        else {
            _count += 2;
            _healer = false;
            return "You're now Healed. Move on.";
        }
    }
}
using System;

namespace Week7_Class;

public class Bomb : Component
{

    public override string Execute(Category type){
        if (type == Category.Beginner) _count--;
        else if (type == Category.Advanced) _count -= 2;
        else _count -= 3;

        return "Run For you Life";
    }
}
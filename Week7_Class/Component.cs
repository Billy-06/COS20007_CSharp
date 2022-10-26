using System;

namespace Week7_Class;

public abstract class Component
{
    public static int _count=0;

    public abstract string Execute(Category type);
}
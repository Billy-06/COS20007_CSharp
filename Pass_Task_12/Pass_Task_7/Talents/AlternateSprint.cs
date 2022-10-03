using System;
namespace Pass_Task_7.Talents;

/**
    <summary>
        The AlternateSprint class extends from the talent class and implements an additional
        attribute Stamina which upon instantiation, defaults to 1000.</br>
    </br>
        The NormalAttack class uses the two pass by value constructor provided by the
        talent class
    </summary>
 */
public class AlternateSprint : Talent
{
    private int _stamina;

    /**
        <summary>
            Constructor takes a string value and initiates the base class' constructor
            which instantiates a beginner level talent and a NormalAttack Kind</br>
        </br>
            The AlternateSprint class further instantiates an additional attribute Stamina
            which defaults to true upon instantiation.
        </summary>
        <param name="name">
            The string value passed to serve as the name of the talent object
        </param>
     */
    public AlternateSprint(string name) : base (name)
    {
        _stamina = 1000;
    }

    /**
        <summary>
            This Cast() method overrides the abstract method provided in the base class
            Talent. It returns different string values depending upon the stamina value.
        </br>     
            It also decrease the instance's stamina by 100 every single time it runs.
        </summary>
        <returns>
            Returns a string value depending on the value of the instance's stamina
        </returns>
     */
    public override string Cast()
    {
        _stamina -= 100;

        if (_stamina <= 0) return $"No more sprint is allowed";
        else if (_stamina >= 1 && _stamina <= 300) return $"Sprint at reduced level";
        else if (_stamina >= 301 && _stamina <= 800) return $"Sprint triggered on the road";
        else return $"You can now move at high speed in water";
    }
}
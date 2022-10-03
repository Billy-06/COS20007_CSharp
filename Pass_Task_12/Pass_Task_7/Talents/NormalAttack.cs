using System;
namespace Pass_Task_7.Talents;

/**
 * <summary>
 * The NormalAttack class extends from the talent class and overrides the abstract
 * method Cast() to return selected responses depending upon the level of the talent
 * the instance has.</br>
 * </br>
 * The NormalAttack class uses the two pass by value constructor provided by the
 * talent class
 * </summary>
 */
public class NormalAttack : Talent
{

    /**
     * <summary>
     *      Constructor takes a string value and initiates the base class' constructor
     *      which instantiates a beginner level talent and a NormalAttack Kind
     * </summary>
     * <param name="name">
     *      The string value passed to serve as the name of the talent object
     * </param>
     */
    public NormalAttack(string name) : base (name)
    {
        
    }

    /**
     * <summary>
     *      Constructor takes three values name :string level: int (between 1-3) 
     *      and kind: int (between 1-3)
     * </summary>
     * <param name="name">
     *      Takes a string value which serves as the name of the talent instance.
     * </param>
     * <param name="level">
     *      Takes and integer value which is then used as a flag for the appropriate enum
     *      Level represented by the number. See the Talent class definition.
     * </param>
     * <param name="kind">
     *      Takes and integer value which is then used as a flag for the appropriate enum
     *      Kind represented by the number. See the Talent class definition.
     * </param>
     */
    public NormalAttack(string name, int level, int kind) : base (name, level, kind)
    {
        
    }

    /**
     * <summary>
     *      This is an override of the base classes Cast() method, which returns
     *      meant to output string values depending upon the level the talent 
     *      instance is in.
     * </summary>
     * <returns>
     *      Returns a string value depending upon the level the talent is in.
     * </returns>
     */
    public override string Cast()
    {
        if (base.Level == Level.Advanced){
            return $"\tPlunging attack triggered";
        }
        else if(base.Level == Level.Intermediate){
            return $"\tA powerful final slash strike";
        }
        else {
           return $"\t4 consecutive strikes triggered";
        }
    }
}
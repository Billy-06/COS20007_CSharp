using System;
namespace Pass_Task_7.Talents;

/**
 * <summary>
 *      The ElementalSkill class extends from the Talent class. It contains two additional
 *      attributes coolDownPeriod and charge which allow the player to charge up their 
 *      power and cool down as needed.
 * 
 *      The ElementalSkill class uses a single by value constructor provided by the
 *      base talent class
 * </summary>
 */
public class ElementalSkill : Talent
{
    private Boolean _coolDownPeriod;
    private int _charge;

    /**
     * <summary>
     *      This is a Property for the charge attribute of the player. It returns an int when
     *      used as a getter/accessor and takes an integer value when used as a
     *      setter/mutator.
     * </summary>
     */
    public int Charge 
    {
        get => _charge;
        set => _charge = value;
    }

    /**
     * <summary>
     *      Constructor takes a string value and initiates the base class' constructor
     *      which instantiates a beginner level talent and a NormalTalent Kind.</br>
     * </br>
     *      Additionally the Elemental Skill provides a default false value to the
     *      cool down period attribute and a random integer value to the talent charge
     *      attribute.
     * </summary>
     * <param name="name">
     *      The string value passed to serve as the name of the talent object
     * </param>
     */
    public ElementalSkill(string name) : base (name)
    {
        Random rand = new();
        _coolDownPeriod = false;
        _charge = rand.Next(1,10);
    }

    /**
     * <summary>
     *      Sets the cool down period to true and prints out a string displaying the 
     *      talent instance's charge.
     * </summary>
     * <returns>
     *      Returns a string value which affirms the cool down period is activated
     *      and also displays the talent instance's charge.
     * </returns>
     */
    public override string Cast()
    {
        if (!this._coolDownPeriod) this._coolDownPeriod = true;

        return $"Cool Down Period Activated:\nCharge: {this._charge}";
    }
}
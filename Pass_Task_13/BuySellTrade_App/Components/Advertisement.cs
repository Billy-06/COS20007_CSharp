using System;
namespace BuySellTrade_App.Components;

/**
 * <summary>
 * This class implements an advertisement with only a 'life' field which is
 * indicative of how many days the advert should be up for.
 * </summary>
 */
public class Advertisement
{
    /**
     * <summary>
     * This is a property for advertisement life field
     * </summary>
     * 
     * <value>The life of the advertisement</value>
     * 
     * <returns>
     * An integer value of the life field.
     * </returns>
     */
    public int Life { get; set; }

    /**
     * <summary>
     * Default constructor which initialises the life field to 0
     *  which means the advertisement witll be off
     * </summary>
     */
    public Advertisement()
    {
        Life = 0;
    }

    /**
     * <summary>
     * Parameterised constructor which accepts and integer value 
     * for the advertisement life
     * </summary>
     * <param name="life">The number of days the advert should be up for.</param>
     */
    public Advertisement(int life)
    {
        Life = life;
    }

    /**
     * <summary>
     * This function is used to end an advertisement on a product
     * </summary>
     */
    public void End()
    {
        if (Life > 0) {
            Life = 0;
            Console.WriteLine("The advertisement has been ended");
        } else {
            Console.WriteLine("No active advertisement was found");
        }
    }
}
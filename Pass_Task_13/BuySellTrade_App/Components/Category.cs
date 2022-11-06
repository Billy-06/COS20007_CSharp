namespace BuySellTrade_App.Components;

/**
 * <summary>
 * This object implements product categories and only contains a name field.
 * </summary>
 */
public class Category
{
    private string _name;

    /**
     * <summary>
     * This is a property for category name field
     * </summary>
     * 
     * <value>The name of the category</value>
     * 
     * <returns>
     * A string value of the Category name
     * </returns>
     */
    public string Name 
    {
        get => _name;
        set => _name = value;
    }

    /**
     * <summary>
     * Default constructor of the category class which 
     * initialises the name to an empty string
     * </summary>
     */
    public Category()
    {
        _name = string.Empty;
    }

    /**
     * <summary>
     * Parameterised constructor which takes a name parameter and instantiates
     * a category object
     * </summary>
     * <param name="name"></param>
     */
    public Category(string name)
    {
        _name = name;
    }
}
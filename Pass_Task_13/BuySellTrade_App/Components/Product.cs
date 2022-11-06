namespace BuySellTrade_App.Components;

/**
 * <summary>
 * This class represent the product class. It contains the below fields<br/>
 * Product ID, Name, Description, Price, Condition, Category, Advertisement
 * </summary>
 */
public class Product
{
    private int _prodId;
    private string _name;
    private double _price;
    private string _description;

    private Condition _condition;

    private Category _category;

    public Advertisement Advertise { get; set; }

    /**
     * <summary>
     * This is a property for product ID field
     * </summary>
     * 
     * <value>The ID of the product</value>
     * 
     * <returns>
     * Returns an integer value of the product ID
     * </returns>
     */
    public int ProdId
    {
        get => _prodId;
        set => _prodId = value;
    }

    /**
     * <summary>
     * This is a property for product name field
     * </summary>
     * 
     * <value>The name of the product</value>
     * 
     * <returns>
     * Returns a string value of the product name
     * </returns>
     */
    public string Name 
    {
        get => _name;
        set => _name = value;
    }

    /**
     * <summary>
     * This is a property for product price field
     * </summary>
     * 
     * <value>The price of the product</value>
     * 
     * <returns>
     * Returns an floating point value of the product price
     * </returns>
     */
    public double Price 
    {
        get => _price;
        set => _price = value;
    }

    /**
     * <summary>
     * This is a property for product condition field
     * </summary>
     * 
     * <value>The condition of the product</value>
     * 
     * <returns>
     * Returns an enumeration value of the product Condition
     * </returns>
     */
    public Condition Condition 
    {
        get => _condition;
        set => _condition = value;
    }

    /**
     * <summary>
     * This is a property for product category field
     * </summary>
     * 
     * <value>The category of the product</value>
     * 
     * <returns>
     * Returns a Category object type value of the product Category
     * </returns>
     */
    public Category Category 
    {
        get => _category;
        set => _category = value;
    }

    /**
     * <summary>
     * This is a property for product description field
     * </summary>
     * 
     * <value>The description of the product</value>
     * 
     * <returns>
     * Returns a string value of the product description
     * </returns>
     */
    public string Description 
    {
        get => _description;
        set => _description = value;
    }

    /**
     * <summary>
     * This is the pass by value constructor of the product object. 
     * It takes the parameters<br/>
     * Name, Description, Price, Condition, Category
     * </summary>
     * <param name="name"></param>
     * <param name="description"></param>
     * <param name="price"></param>
     * <param name="condition"></param>
     * <param name="category"></param>
     */
    public Product(string name, string description, double price, Condition condition, Category category)
    {
        _prodId = 0;

        _name = name;
        _description = description;
        _price = price;
        _condition = condition;
        _category = category;
        Advertise = new();
    }

    /**
     * <summary>
     * This is a string type function that returns each of the product details. This function issues a 
     * warning of the product added is not in the catalogue
     * </summary>
     * <returns>A string detailing out the product particulars</returns>
     */
    public string PrintInfo()
    {
        if (_prodId == 0) {

            Console.WriteLine("Warning:\n================\nThis product has no ID");
            Console.WriteLine("Please add this product to the catalogue so it can get assigned an ID");
            return $"Product ID: *Missing*\nName: {_name}\nCategory: {_category.Name}\nPrice: {_price}\nDescription: {_description}\nCondition: {_condition.ToString()}\n";
            
        } else {

            return $"Product ID: {_prodId}\nName: {_name}\nCategory: {_category.Name}\nPrice: {_price}\nDescription: {_description}\nCondition: {_condition.ToString()}\n";
        }
    }
}


/**
 * <summary>
 * This is an enumeration enlisting condition literals for the product object
 * </summary>
 */
[Flags]
public enum Condition
{
    BrandNew = 1,
    Used = 2
}
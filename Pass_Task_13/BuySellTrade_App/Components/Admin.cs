using System;
namespace BuySellTrade_App.Components;


/**
 * <summary>
 * This is the Admin class used for instatiating the admin of 
 * the application. This class inherits from the abstract User
 * class and implements an additional attribute namely;<br/>
 * Catalogue
 * </summary>
 */
public class Admin : User
{
    private Catalogue _catalogue;
    
    /**
     * <summary>
     * This is a property for the catalogue field
     * </summary>
     * 
     * <value>The admin's Catalogue</value>
     * 
     * <returns>
     * Returns a type Catalogue object 
     * representative of the admin's catalogue when used as a getter
     * </returns>
     */
    public Catalogue Catalogue
    {
        get => _catalogue;
        set => _catalogue = value; 
    }

    /**
     * <summary>
     * The Admin constructor used in instating an admin. The 
     * catalogue is defaulted to an empty catalogue.
     * </summary>
     * <param name="name">The admin's name</param>
     * <param name="email">The admin's email address</param>
     * <param name="password">The admin's log in password</param>
     * <param name="phone">The admin's phone number</param>
     */
    public Admin(string name, string email, string password, int phone) 
        : base(name, email, password, phone)
    {
        _catalogue = new();
    }

    /**
     * <summary>
     * A default Advertsing function which advertisees products
     * for 5 days. Sets the advertisment's life to 5
     * </summary>
     * 
     * <param name="product">Object of type Product. Pass the product intended to be advertised</param>
     * 
     * <returns>
     * Returns the product with an updated Advertisement period value
     * </returns>
     */
    public Product Advertise(Product product){
        if (product.Advertise.Life > 0) {
            Console.WriteLine("This product is already being advertised");
            
        }
        else {
            product.Advertise.Life = 5;
            Console.WriteLine("This product is now being advertised");
        }
        return product;
    }

    /**
     * <summary>
     * This functions allows the admin to update products by 
     * providing an updated product against the older one intent on being
     * updated.
     * </summary>
     * 
     * <param name="oldProduct">Product to be updated found in the list of products in the catalogue</param>
     * <param name="newProduct">New product to replace the old</param>
     * 
     * <returns>
     * Returns the confirmed updated Product
     * </returns>
     */
    public Product Update(Product oldProduct, Product newProduct){
        if (_catalogue.ListOfProduct.FirstOrDefault( n => n.Name == oldProduct.Name ) != null){
            oldProduct.ProdId = newProduct.ProdId;
            oldProduct.Name = newProduct.Name;
            oldProduct.Price = newProduct.Price;
            oldProduct.Condition = newProduct.Condition;
            oldProduct.Description = newProduct.Description;
            oldProduct.Advertise = newProduct.Advertise;

            Console.WriteLine("Product updated successfully");
        }
        else Console.WriteLine("Couldn't find the product you're attempting to replace");
 
        return newProduct;
    }

    /**
     * <summary>
     * This is a function used to remove a product from the catalogue. It takes 
     * the prameter of type Product which after beign found in the catalogue
     *  is removed from the catalogue
     * </summary>
     * 
     * <param name="product">The product to be removed from the Catalogue</param>
     * 
     * <returns>
     * Returns a string value which is a confirmatory statement that either 
     * the product removal was successful or not found.
     * </returns>
     */
    public string Remove(Product product){
        if (_catalogue.ListOfProduct.FirstOrDefault( n => n.Name == product.Name ) != null){
            _catalogue.ListOfProduct.Remove(product);
            return $"Product removed successfully";
        }
        else return $"The product you passed does not exist";
    }
    
    /**
     * <summary>
     * An overriden abstract function from the User class. This is a string
     * type function that returns the admin details.
     * </summary>
     * <returns>All the admin details including number of items in his(er) catalogue</returns>
     */
    public override string PrintInfo()
    {
        return $"Name: {base.Name}\nEmail: {base.Email}\nPassword: {base.Password}\nPhone: {base.Phone}\nCatalogue Items: {_catalogue.ListOfProduct.Count} Products\n";
    }

}
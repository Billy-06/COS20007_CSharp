using System;
using System.Collections.Generic;
using System.Collections;

namespace BuySellTrade_App.Components;

/**
 * <summary>
 * This is the Catalogue containing the products the admin is selling on the site.
 * Contians the below fields<br/>
 * List of Products, List of Categories, Advertisements
 * </summary>
 */
public class Catalogue
{
    private List<Product> _listOfProducts;
    
    /**
     * <summary>
     * This is a property for list of categories field
     * </summary>
     * 
     * <value>The List of products</value>
     * 
     * <returns>
     * Returns a list of categories in the admin's
     * catalogue when used as a getter
     * </returns>
     */
    public List<Category> Categories { get; set; }

    /**
     * <summary>
     * This is a property for Advertisement  field
     * </summary>
     * 
     * <value>The List of products</value>
     * 
     * <returns>
     * Returns a list of advertised products in the admin's
     * catalogue when used as a getter
     * </returns>
     */
    public List<Product> Adverts { get; set; }

    /**
     * <summary>
     * This is a property for list of products field
     * </summary>
     * 
     * <value>The List of products</value>
     * 
     * <returns>
     * Returns a list of products in the admin's
     * catalogue when used as a getter
     * </returns>
     */
    public List<Product> ListOfProduct 
    {
        get => _listOfProducts;
        set => _listOfProducts = value;
    }

    /**
     * <summary>
     * This is an indexer used in acessing products in the 
     * catalogue by their positional arguments (indices)
     * </summary>
     * <value>The product at a given position in the catalogue </value>
     * <param name="i">the index of the item in the list of products</param>
     */
    public Product this[int i]
    {
        get => _listOfProducts[i];
        set => _listOfProducts[i] = value;
    }

    /**
     * <summary>
     * Default constructor. All fields are initialised as empty lists.
     * </summary>
     */
    public Catalogue()
    {
        _listOfProducts = new();
        Adverts = new();
        Categories = new();
    }

    /**
     * <summary>
     * This is a private function used for the utility of generating 
     * random ID numbers when products are added to the catalogue
     * </summary>
     * <returns>A random integer value</returns>
     */
    private int GenerateId(){
        Random rand = new();
        int idNum = rand.Next();
        do
        {
            idNum = rand.Next();
        }
        while (_listOfProducts.FirstOrDefault<Product>( n => n.ProdId == idNum ) != null );

        return idNum;
    }

    /**
     * <summary>
     * This constructor takes a list of products and initialises the rest of teh fields
     * as empty lists.
     * </summary>
     * <param name="listOfProducts">List of products to be added to the catalogue</param>
     */
    public Catalogue(List<Product> listOfProducts)
    {
        _listOfProducts = new();

        foreach(Product item in listOfProducts) {
            AddCategory(item);
            item.ProdId = GenerateId();
        }
        Adverts = new();
        Categories = new();
    }

    /**
     * <summary>
     * Overloaded function:<br/>Used in adding a product item to the catalogue. Recommended to use this method
     * since it generates the ID for the product and updates the advertisement list.
     * </summary>
     * <param name="item">The product to be added to catalogue</param>
     */
    public void AddItem(Product item)
    {
        item.ProdId = GenerateId();
        AddCategory(item);
        _listOfProducts.Add( item );

        CheckAdvert();
    }

    /**
     * <summary>
     * Function used in adding categories to the catalogue. It ascertains that the 
     * category doesn't already exist before adding it to the list of categories
     * </summary>
     * <param name="item">A product added independently that'll then need to be parsed into the catalogue</param>
     */
    private void AddCategory(Product item)
    {
        if (Categories.FirstOrDefault<Category>( n => n == item.Category ) == null) Categories.Add( item.Category );

    }

    /**
     * <summary>
     * Prints out all the categories contained in a catalogue
     * </summary>
     */
    public void ShowCategories()
    {
        if (Categories.Count > 0){
            Console.WriteLine("========================================");
            Console.WriteLine("|        Your Product Categories        |");
            Console.WriteLine("========================================");
            foreach( Category item in Categories ) Console.WriteLine(item.Name);

        }
        else {
            Console.WriteLine("========================================");
            Console.WriteLine("|  You have yet to add any Categories  |");
            Console.WriteLine("========================================");
        }
    }

    /**
     * <summary>
     * Overloaded function:<br/> Used in adding a list of product items to the catalogue. Recommended to use this method
     * since it generates the ID for the product and updates the advertisement list.
     * </summary>
     * <param name="items">The list of products to be added to catalogue</param>
     */
    public void AddItem(List<Product> items)
    {
        foreach(Product product in items) {
            product.ProdId = GenerateId();
            AddCategory(product);
            _listOfProducts.Add( product );
        }

        CheckAdvert();
    }

    /**
     * <summary>
     * Overloaded Function<br/>
     * Uesd to remove an item from the catalogue. This function also checks if the product we being 
     * advertised and drops the advertisement as well
     * </summary>
     * <param name="item">The product to be removed from the catalogue</param>
     */
    public void RemoveItem(Product item)
    {
        var ad = Adverts.FirstOrDefault<Product>( n => n.ProdId == item.ProdId );
        
        if (_listOfProducts.FirstOrDefault<Product>( n => n.ProdId == item.ProdId ) != null)
        {
            _listOfProducts.Remove( item );
            if ( ad != null ) Adverts.Remove( ad );
            Console.WriteLine($"Successfully removed the product: {item.Name}.");

            CheckAdvert();
        } 
        else Console.WriteLine($"No item of name {item.Name} was found");
    }

    /**
     * <summary>
     * Overloaded Function<br/>
     * Uesd to remove an item from the catalogue. This function also checks if the product we being 
     * advertised and drops the advertisement as well
     * </summary>
     * <param name="productName">The name of the product to be removed from the catalogue</param>
     */
    public void RemoveItem(string productName)
    {
        var item = _listOfProducts.FirstOrDefault<Product>( n => n.Name.ToLower() == productName.ToLower() );
        var ad = Adverts.FirstOrDefault<Product>( n => n.Name.ToLower() == productName.ToLower() );
        
        if ( item != null)
        {
            if (ad != null ) Adverts.Remove( ad );
            _listOfProducts.Remove( item );
            Console.WriteLine($"Successfully removed the product: {productName}.");

            CheckAdvert();
        }
        else Console.WriteLine($"No item of name {productName} was found");
        
    }

    /**
     * <summary>
     * Prints out the products in the catalogue alongside the product advertisements
     * </summary>
     */
    public void Display()
    {
        if(Adverts.Count > 0){
            Console.WriteLine("Advertisements\n===================\n");
            foreach(Product prod in Adverts) Console.WriteLine($"Advertisement\n-----------------\n{prod.PrintInfo()}\n");
            Console.WriteLine();
        }
        if(_listOfProducts.Count > 0){
            Console.WriteLine("Products\n===================\n");
            foreach(Product prod in _listOfProducts) Console.WriteLine($"{prod.PrintInfo()}\n");
        }
        else {
            Console.WriteLine("There aren't any products in this catalogue");
        }
    }

    /**
     * <summary>
     * This function checks if any products in the advertisement list has been
     * updated and then updates the entire list
     * </summary>
     */
    private void CheckAdvert()
    {
        foreach(Product item in _listOfProducts)
        {
            if (item.Advertise.Life > 0 && Adverts.FirstOrDefault<Product>(n => n.ProdId == item.ProdId) == null)
            {
                Adverts.Add( item );
            }

        }
        foreach(Product item in Adverts)
        {
            if (item.Advertise.Life < 1 || _listOfProducts.FirstOrDefault<Product>(n => n.ProdId == item.ProdId) == null)
            {
                Adverts.Remove( item );
            }
        }
    }
}
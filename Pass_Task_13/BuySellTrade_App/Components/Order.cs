using System.Collections.Generic;
namespace BuySellTrade_App.Components;

/**
 * <summary>
 * This class represents the orders placed which entails
 *  a customer buying a product. It implemments an interface with
 * the below fields:<br/>
 * Order ID, Date, List of Products ordered, Customer Name, Order Tracking Progress
 * </summary>
 */
public class Order
{
    private int _orderId;
    private DateTime _ordDate;
    private List<Product> _ordProducts;
    private Progress _ordProgress;
    private string _customerName;

    /**
     * <summary>
     * This Order constructor instantiates an order object an takes the parameters below:<br/>
     * List of products ordered, Customer Name<br/>
     * It assigns a random Id number and a date, and the progress defaults to Ready to Ship
     * </summary>
     * <param name="prods"></param>
     * <param name="custName"></param>
     */
    public Order(List<Product> prods, string custName)
    {
        _customerName = custName;
        _ordProducts = prods;
        _ordDate = new();

        Random rand = new();
        _orderId = rand.Next(1000, 6000);
        _ordProgress = Progress.ReadToShip;
    }

    /**
     * <summary>
     * This is a property for order date field
     * </summary>
     * 
     * <value>The date of the order</value>
     * 
     * <returns>
     * A date value of the order
     * </returns>
     */
    public DateTime OrdDate 
    {
        get => _ordDate;
        set => _ordDate = value;
    }

    /**
     * <summary>
     * This is a property for order products field
     * </summary>
     * 
     * <value>The list of products of the order</value>
     * 
     * <returns>
     * A list of produtcs of the order
     * </returns>
     */
    public List<Product> OrdProducts 
    {
        get => _ordProducts;
        set => _ordProducts = value;
    }

    /**
     * <summary>
     * This is a property for order ID field
     * </summary>
     * 
     * <value>The ID of the order</value>
     * 
     * <returns>
     * An integer value of the order ID
     * </returns>
     */
    public int OrderId 
    {
        get => _orderId;
        set => _orderId = value;
    }

    /**
     * <summary>
     * This is a property for order progress field
     * </summary>
     * 
     * <value>The progess of the order</value>
     * 
     * <returns>
     * Progess enumetration literal of the order progess
     * </returns>
     */
    public Progress OrdProgress 
    {
        get => _ordProgress;
        set => _ordProgress = value;
    }

    /**
     * <summary>
     * This function prints out the order details inclusive of the customer name.
     * To be used when printing for the aadmin so (s)he can identify the order's origin
     * </summary>
     */
    public void AdminPrint()
    {
        Console.WriteLine($"\nCustomer Name: {_customerName}\nOrder ID: {_orderId}\nDate: {_ordDate}\nProgress: {_ordProgress}");
        foreach(Product prod in _ordProducts) Console.WriteLine(prod.PrintInfo());
        Console.WriteLine("=================================\n");
    }

    /**
     * <summary>
     * This function prints out the order details exclusive of the customer name, to be used
     * when printing of the customer details is not necessary
     * </summary>
     */
    public void Print()
    {

        Console.WriteLine($"\nOrder ID: {_orderId}\nDate: {_ordDate}\nProgress: {_ordProgress}");
        foreach(Product prod in _ordProducts) Console.WriteLine(prod.PrintInfo());
        Console.WriteLine("=================================\n");
    }
}

/**
 * <summary>
 * This enumaration enlists literals for the order progess.
 * These are:<br/>
 * ReadyToShip, Shipped, InTransit, Delivered
 * </summary>
 */
public enum Progress
{
    ReadToShip,
    Shipped,
    InTransit,
    Delivered
}
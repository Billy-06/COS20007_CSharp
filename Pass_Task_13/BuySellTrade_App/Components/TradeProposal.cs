using System.Collections.Generic;
namespace BuySellTrade_App.Components;

/**
 * <summary>
 * This is a proposal by the customer who wishes to sele/trade a product
 * with the admin. This object contains the fields listed below;<br/>
 * Proposal ID, Customer Name, Date, List of Products, Proposal Status
 * </summary>
 */
public class TradeProposal
{
    private int _trId;
    private string _customerName;
    private DateTime _trDate;
    private List<Product> _trProducts;

    private TrStatus _status;

    /**
     * <summary>
     * This is a property for the Proposal ID field
     * </summary>
     * 
     * <value>The proposal ID value</value>
     * 
     * <returns>
     * Returns an integer value representative of the Proposal ID
     * when used as a getter
     * </returns>
     */
    public int TrID 
    {
        get => _trId;
        set => _trId = value;
    }

    /**
     * <summary>
     * This is a property for the Customer Name field
     * </summary>
     * 
     * <value>The Customer who sent the proposal value</value>
     * 
     * <returns>
     * Returns an string value representative of the customer name
     * when used as a getter
     * </returns>
     */
    public string CustomerName 
    {
        get => _customerName;
        set => _customerName = value;
    }

    /**
     * <summary>
     * This is a property for the proposal date field
     * </summary>
     * 
     * <value>The date the proposal was created</value>
     * 
     * <returns>
     * Returns an DateTime value indicative of the date the proposal was created
     * </returns>
     */
    public DateTime TrDate 
    {
        get => _trDate;
        set => _trDate = value;
    }

    /**
     * <summary>
     * This is a property for the list of proposed products field
     * </summary>
     * 
     * <value>The list of products in a proposal</value>
     * 
     * <returns>
     * Returns an generic List type of Products when used a getter
     * </returns>
     */
    public List<Product> TrProducts 
    {
        get => _trProducts;
        set => _trProducts = value;
    }

    /**
     * <summary>
     * This is a property for the Proposal Status field
     * </summary>
     * 
     * <value>The Status of the proposal<br/> Pending, Approved, Rejected</value>
     * 
     * <returns>
     * Returns an enumaration showing the proposal status
     * </returns>
     */
    public TrStatus Status 
    {
        get => _status;
        set => _status = value;
    }

    /**
     * <summary>
     * This is a pass by value constructor used in instantiating a trade proposal. 
     * It takes the parameters<br/>
     * List of Products => the list of products proposed<br/>
     * Customer Name => the name of the cutomer who's sending the proposal
     * </summary>
     * <param name="prods">List of products proposed by customer. This has to be an Object of type Generic list or Products</param>
     * <param name="custName">The cutomer's name</param>
     */
    public TradeProposal(List<Product> prods, string custName)
    {
        Random rand = new();
        _trId = rand.Next();

        _trDate = new();
        _trProducts = prods;
        _customerName = custName;
        _status = TrStatus.Pending;

    }

    /**
     * <summary>
     * Used by the admin since it shows the cutomer who sent the proposal.<br/>
     * It prints out the below details:<br/>
     * Customer name, Proposal ID, Date, Status, List of Products Proposed
     * </summary>
     */
    public void AdminPrint()
    {
        Console.WriteLine("\n----------------------------");
        Console.WriteLine($"Customer Name: {_customerName}");
        Console.WriteLine("----------------------------");
        Console.WriteLine($"\nProposal ID: {_trId}\nDate: {_trDate}\nStatus: {_status}");
        foreach(Product item in _trProducts) Console.WriteLine(item.PrintInfo());
        Console.WriteLine("===========================");
    }

    /**
     * <summary>
     * Used by the customer or in cases where the cutomer name doesn't need to be printed
     * <br/>
     * It prints out the below details:<br/>
     * Proposal ID, Date, Status, List of Products Proposed
     * </summary>
     */
    public void Print()
    {
        Console.WriteLine($"\nProposal ID: {_trId}\nDate: {_trDate}\nStatus: {_status}");
        foreach(Product item in _trProducts) Console.WriteLine(item.PrintInfo());
        Console.WriteLine("===========================");
    }

}

/**
 * <summary>
 * Enumeration enlisting the three different trade proposal status<br/>
 * Pending, Approved, Rejected
 * </summary>
 */
public enum TrStatus
{
    Pending,
    Approved,
    Rejected
}
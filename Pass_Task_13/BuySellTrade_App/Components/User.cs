using System;
namespace BuySellTrade_App.Components;

/**
 * <summary>
 * This is an abstract class from which the admin 
 * and the customer inherit<br/>
 * The fields include: <br/> Name, Email, Password, Phone, and Log In Status
 * </summary>
 */
public abstract class User
{
    private string _name;
    private string _email;
    private string _password;
    private int _phone;
    private Boolean _loggedIn;

    public User(string name, string email, string password, int phone)
    {
        _name = name;
        _email = email;
        _password = password;
        _phone = phone;
        
        _loggedIn = false;
    }

    /**
     * <summary>
     * This is a property for the name field
     * </summary>
     * <value>The derived class' Name</value>
     * <returns>A string value when used as a getter</returns>
     */
    public string Name 
    {
        get => _name;
        set => _name = value;
    }

    /**
     * <summary>
     * This is a property for the email field
     * </summary>
     * <value>The derived class' Email</value>
     * <returns>A string value when used as a getter</returns>
     */
    public string Email 
    {
        get => _email;
        set => _email = value;
    }

    /**
     * <summary>
     * This is a property for the password field
     * </summary>
     * <value>The derived class' Password</value>
     * <returns>A string value when used as a getter</returns>
     */
    public string Password 
    {
        get => _password;
        set => _password = value;
    }

    /**
     * <summary>
     * This is a property for the phone field
     * </summary>
     * <value>The derived class' Phone number</value>
     * <returns>An int value when used as a getter</returns>
     */
    public int Phone 
    {
        get => _phone;
        set => _phone = value;
    }

    /**
     * <summary>
     * This is a property for the log in status field
     * </summary>
     * <value>The derived class' log in status</value>
     * <returns>A bolean value when used as a getter</returns>
     */
    public Boolean LoggedIn 
    {
        get => _loggedIn;
        set => _loggedIn = value;
    }

    /**
     * <summary>
     * This Mutator function allows for creating a 
     * new password where needed. It takes a string value parameter 
     * asn replaces the existing password with it.
     * </summary>
     * <param name="newPassword">
     * A string value to represent the intended new password for the derived class
     * </param>
     */
    public void ChangePassword(string newPassword)
    {
        _password = newPassword;
        Console.WriteLine("Password changed successfully");
    }

    /**
     * <summary>
     * This is an abstract string type functions to be overriden
     * by the child class
     * </summary>
     * <returns>
     * Returns the string value implemented,
     * otherwise, it will return a no Implementation error
     * </returns>
     */
    public abstract string PrintInfo();
}
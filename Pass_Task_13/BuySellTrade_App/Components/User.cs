using System;
namespace BuySellTrade_App.Components;

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

    public string Name 
    {
        get => _name;
        set => _name = value;
    }
    public string Email 
    {
        get => _email;
        set => _email = value;
    }
    public string Password 
    {
        get => _password;
        set => _password = value;
    }
    public int Phone 
    {
        get => _phone;
        set => _phone = value;
    }
    public Boolean LoggedIn 
    {
        get => _loggedIn;
        set => _loggedIn = value;
    }

    public void ChangePassword(string newPassword)
    {
        _password = newPassword;
        Console.WriteLine("Password changed successfully");
    }

    public abstract string PrintInfo();
}
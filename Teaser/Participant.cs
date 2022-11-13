using System;

namespace Teaser;

public class Participant : Role
{

    private string _name;
    private string _address;
    private string _email;

    public Participant(Category category, string name, string address, string email) : base(category)
    {
        _name = name;
        _address = address;
        _email = email;
    }

    public override void ViewInfo()
    {
        Console.WriteLine($"Name: {_name}\nAddress: {_address}\nEmail: {_email}\n");
    }
}
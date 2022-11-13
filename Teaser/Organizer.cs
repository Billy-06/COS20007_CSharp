using System;
using System.Collections.Generic;

namespace Teaser;

public class Organizer : Role
{

    private string _companyName;
    private List<Conference> _conferences;

    public Organizer(Category category, string companyName): base(category)
    {
        _companyName = companyName;
        _conferences = new();
    }

    public int ConferenceCount() => _conferences.Count;

    public void AddConference(Conference conference)
    {
        _conferences.Add( conference );
    }

    public void RemoveConference(Conference conference)
    {
        if(_conferences.Count > 0) _conferences.Remove( conference );
    }


    public override void ViewInfo()
    {
        Console.WriteLine($"Company Name: {_companyName}\nNumber of Conferences Held: {_conferences.Count}\n");
        foreach(Conference item in _conferences)
        {
            Console.WriteLine("Conference Details:");
            Console.WriteLine("===================");
            item.PrintDetails();
            Console.WriteLine($"Total Session Charges: {item.CalculateTotalSessionCharges()}"); 
        }
    }
}
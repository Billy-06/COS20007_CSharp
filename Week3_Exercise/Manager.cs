using System;
using System.Collections.Generic;

namespace Week3_Exercise;

public enum Department
{
    Finance,
    Facilities,
    IT
}

public class Manager
{
    private string _name;
    private Department _department;
    private List<Booking> _appointments;

    public Manager(string name, Department department)
    {
        _name = name;
        _department = department;
        _appointments = new List<Booking>();
    }

    public void MadeBooking(Booking booking)
    {
        _appointments.Add( booking );
    }
    public void CancelBooking(Booking booking)
    {
        _appointments.Remove( booking );
    }
    public int AppointmentCount()
    {
        return _appointments.Count;
    }

    public int SearchBooking(string date, string time)
    {
        int count = 0;
        for(int i=0; i < _appointments.Count; i++)
        {
            if (_appointments[i].Date == date && _appointments[i].Time == time) count++;
        }

        return count;
    }

    // Indexer
    public Booking this[int i]
    {
        get { return _appointments[i]; }
    }

    public void PrintDetails()
    {
        Console.WriteLine($"Name: {_name}\nDepartment: {_department}\n");
        foreach(Object item in _appointments) Console.WriteLine($"{item}");
    }
}
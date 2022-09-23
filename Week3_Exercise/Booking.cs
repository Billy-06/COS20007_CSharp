using System;
using System.Collections.Generic;

namespace Week3_Exercise;

public class Booking
{
    private string _date;
    private string _time;

    public Booking(string date, string time)
    {
        _date = date;
        _time = time;
    }
    public string Date { get { return _date; } set { _date = value; } }
    public string Time { get { return _time; } set { _time = value; } }
}
using System;
using Week_Two_Exercise;
public class Program
{
    public static void Main(string[] args)
    {
        AirCond home_air = new AirCond("AS-345", "Samsung", 56, 24.56);
        home_air.PrintDetails();
    }
}
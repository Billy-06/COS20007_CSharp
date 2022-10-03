using System;
using Week4_Tut;
internal class Program
{
    private static void Main(string[] args)
    {
        Car myCar = new Car(4, 2800);
        Truck myTruck = new(22, 22000, 10000);

        Console.WriteLine("Car Info:\n");
        Console.WriteLine(myCar.PrintInfo());
        Console.WriteLine("==================================");

        Console.WriteLine("Truck Info:\n");
        Console.WriteLine(myTruck.PrintInfo());
        Console.WriteLine("==================================");

    }
}
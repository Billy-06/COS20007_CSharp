using NUnit.Framework;
using System;

using Week_Two_Exercise;

[TestFixture]
public class TestAirCond
{
    // [Test]
    // public void TestIncreaseTemp()
    // {
    //     AirCond yourAir = new AirCond("RT45","Sony", 20000, 22.3);
    //     yourAir.IncreaseTemp();
    //     Assert.AreEqual(22.4, yourAir.Temperature);
    // }

    [Test]
    public void TestDecreaseTemp()
    {
        AirCond myAir = new AirCond("RT45","Sony", 20000, 22.3);
        myAir.DecreaseTemp();
        Assert.AreEqual(22.2, myAir.Temperature);
    }
}
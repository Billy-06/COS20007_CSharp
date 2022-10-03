using NUnit.Framework;
namespace Week4_Tut.Tests;

[TestFixture]
public class TruckTests
{
    [Test]
    public void EfficiencyTest()
    {
        Truck myTruck = new(22, 22000, 10000);

        Assert.AreEqual(22000, myTruck.Efficiency());
    }
}
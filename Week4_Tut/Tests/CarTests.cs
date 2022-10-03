using NUnit.Framework;
namespace Week4_Tut.Tests;

[TestFixture]
public class CarTests
{
    [Test]
    public void WheelLoadTest()
    {
        Car myCar = new Car(4, 2800);
        double expected = 2800/4;

        Assert.AreEqual(expected, myCar.WheelLoad());
    }
}
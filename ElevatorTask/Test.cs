using NUnit.Framework;

namespace ElevatorTask;

[TestFixture]
public class ButtonTest
{

    [Test]
    public void TestFloorButtonPressed()
    {
        FloorButton button = new(5, Direction.Up);

        string returnLine = "You are currently on level 5, we're going up to level 6";
        Assert.AreEqual(returnLine, button.Press());
    }
}
using System;
namespace ElevatorTask;

public class FloorButton : Button
{
    private int _currFloorNumber;
    private Direction _direction;

    public FloorButton(int currFloorNumber, Direction direction ) : base()
    {
        _currFloorNumber = currFloorNumber;
        _direction = direction;
    }

    public override string Press()
    {
        if (!base.Illuminate) base.Illuminate = true;
        if (_direction == Direction.Up)
            return $"You are currently on level {_currFloorNumber}, we're going up to level {_currFloorNumber + 1}";
        else if (_direction == Direction.Down)
            return $"You are currently on level {_currFloorNumber}, we're going down to level {_currFloorNumber - 1} ";

        return "Press a button in order to head to another level";
    }
}

public enum Direction
{
    Up,
    Down
}
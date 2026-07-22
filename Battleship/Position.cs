namespace Battleship;

public class Position
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Position(int x, int y)
    {
        if (x < 0)
            throw new ArgumentException("X не может быть отрицательным");

        if (y <0)
            throw new ArgumentException("Y не может быть отрицательным");

        X = x;
        Y = y;
    }
}
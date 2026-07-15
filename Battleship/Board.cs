namespace Battleship;

public class Board
{
    
    public int Rows { get; private set; }
    public int Columns { get; private set; }

    public Ship Ship { get; private set; }

    public Board(int rows, int columns, Ship ship)
    {
        if (rows<=0)
            throw new ArgumentException("Row7" +
                                        "s cannot be negative.");
        if (columns<=0)
            throw new ArgumentException("Columns cannot be negative.");
        if (ship.Position.X + ship.Lenght > columns)
            throw new ArgumentException("Ship position is out of bounds.");
        if (ship.Position.Y >= rows)
            throw new ArgumentException("Ship is outside the board.");

        Rows = rows;
        Columns = columns;
        Ship = ship;
    }

    public bool HasShip(Position shotPosition)
    {
        return shotPosition.Y == Ship.Position.Y &&
               shotPosition.X >= Ship.Position.X &&
               shotPosition.X < Ship.Position.X + Ship.Lenght;
    }
    

    public bool IsInside(Position shotPosition)
    {
        return shotPosition.X >=0 && shotPosition.X < Columns && shotPosition.Y >= 0 && shotPosition.Y < Rows;
    }
}

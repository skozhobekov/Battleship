namespace Battleship;

public class Board
{
    
    public int Rows { get; private set; }
    public int Columns { get; private set; }

    public Ship Ship { get; private set; }

    public Board(int rows, int columns, Ship ship)
    {
        if (rows<=0)
            throw new ArgumentException("кол-во строк не может быть отрицательным, или равным нулю");
        if (columns<=0)
            throw new ArgumentException("кол-во колонок не может быть отрицательным, или равным нулю");
        if (ship.Position.X + ship.Lenght > columns)
            throw new ArgumentException("Позиция корабля за пределами доски.");
        if (ship.Position.Y >= rows)
            throw new ArgumentException("Позиция корабля не вмещается в доску");

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

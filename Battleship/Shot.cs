namespace Battleship;

public class Shot
{
    public Board Board { get; set; }
    public Position Position { get; private set; }
    public Ship? Ship { get; set; }

    public Shot(Board board, Position position, Ship ship)
    {
        Board = board;
        Position = position;
        Ship = ship;
    }

}
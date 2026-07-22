using Battleship;

namespace Battleship;

public class Program
{
    public static void Main(string[] args)
    {
        var shipPosition = new Position(2, 3);
        var ship = new Ship(shipPosition, 2);
        var board = new Board(4, 4, ship);
        var game = new Game();
        
        Console.WriteLine(board);
        game.Play(board);
        
    }
    
}

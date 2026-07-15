using Battleship;

namespace Battleship;

public class Program
{
    public static void Main(string[] args)
    {
        
        var shipPosition = new Position(2, 5);
        var ship = new Ship(shipPosition, 2);
        var board = new Board(5, 5, ship);
        var game = new Game();
        Console.WriteLine(board);
        game.Play(board);
        
        
    }
    
}

namespace Battleship;

public class Game
{
        public int UserHits { get; private set; }

        public int ComputerHits { get; private set; }

        public void Play(Board board)

        {
            Board opponentBoard = GenerateOpponentBoard(board);
            Console.WriteLine("Компьютер создал корабль:");
            Console.WriteLine($"X = {opponentBoard.Ship.Position.X}");
            Console.WriteLine($"Y = {opponentBoard.Ship.Position.Y}");
            Console.WriteLine($"Length = {opponentBoard.Ship.Lenght}");

            Random random = new Random();

            while (true)
            {
                Console.Write("X: ");
                string xInput = Console.ReadLine();

                Console.Write("Y: ");
                string yInput = Console.ReadLine();


                if (!int.TryParse(xInput, out int xPosition))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                if (!int.TryParse(yInput, out int yPosition))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                Position shotPosition = new Position(xPosition, yPosition);
                
                
                if (!board.IsInside(shotPosition))
                {
                    Console.WriteLine("Shot is outside the board.");
                    continue;
                }
                if (opponentBoard.HasShip(shotPosition))
                {
                    Console.WriteLine("Success");
                    UserHits++;
                }
                else
                {
                    Console.WriteLine("failure");
                }


                int computerX = random.Next(0, board.Columns);
                int computerY = random.Next(0, board.Rows);

                Position computerShot = new Position(computerX, computerY);
                
                
                if (!board.IsInside(computerShot))
                {
                    Console.WriteLine("computer's Shot is outside the board.");
                    continue;
                }

                Console.WriteLine($"Computer shot: X = {computerX}, Y = {computerY}");


                if (board.HasShip(computerShot))
                {
                    Console.WriteLine("Computer hit!");
                    ComputerHits++;
                }
                else
                {
                    Console.WriteLine("Computer missed!");
                }

              
                Console.WriteLine("------------------");
                Console.WriteLine($"User hits: {UserHits}");
                Console.WriteLine($"Computer hits: {ComputerHits}");
                Console.WriteLine("------------------");

            }
        }

        private Board GenerateOpponentBoard(Board playerBoard)
        {
            Random random = new Random();
            int length = random.Next(1, playerBoard.Columns + 1);
            int y = random.Next(0, playerBoard.Rows);
            int x = random.Next(0, playerBoard.Columns - length + 1);
            Position position = new Position(x, y);
            Ship ship = new Ship(position, length);
            
            return new Board(playerBoard.Rows, playerBoard.Columns, ship);
        }
        
    }
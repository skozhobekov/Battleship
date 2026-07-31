namespace Battleship;

public class Game
{
        public int UserHits { get; private set; }

        public int ComputerHits { get; private set; }

        public List<Shot> Shots { get; private set; } = new List<Shot>();
    

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
                try
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
                    if (!opponentBoard.IsInside(shotPosition))
                    {
                        Console.WriteLine("Shot is outside the board.");
                        continue;
                    }
                    var opponentShip =  opponentBoard.FindShip(shotPosition);

                    if (Shots.Any(shot => shotPosition.X == shot.Position.X && shotPosition.Y == shot.Position.Y && shot.Board == opponentBoard))
                    {
                        throw new Exception("Already shot. Do it again");
                    }
//При каждом выстреле создавать объект Shot, независимо от того, было попадание или промах                  
                    Shot shot = new Shot(opponentBoard, shotPosition, opponentShip); 
                    
                    
//7. Если игрок пытается выстрелить в клетку, куда уже стреляли, нужно бросать исключение.                    

                    Shots.Add(shot);
                    

                    if (opponentShip != null)
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

                    
                    Position computerShotPosition = new Position(computerX, computerY);
                    if (!board.IsInside(computerShotPosition))
                    {
                        Console.WriteLine("Computer shot is outside the board.");
                        continue;
                    }
                    var playerShip = board.FindShip(computerShotPosition);
                    Shot computerShot = new Shot(board, computerShotPosition, playerShip);
                    
                    Shots.Add(computerShot);
                    
                    Console.WriteLine($"Computer shot: X = {computerX}, Y = {computerY}");


                    if (playerShip != null)
                    {
                        Console.WriteLine("Computer hit!");
                        ComputerHits++;
                    }
                    else
                    {
                        Console.WriteLine("Computer missed!");
                    }
                    PrintStatistics(board);
                    PrintStatistics(opponentBoard);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }
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
  
                   
        public void PrintStatistics(Board board)
        {
            var boardShots = Shots.Where(shot => shot.Board == board);
                   int totalShots  = boardShots.Count();
                   int totalHits = boardShots.Where(shot => shot.Ship != null).Count();
                   int totalMisses = boardShots.Where(shot => shot.Ship == null ).Count();
                   bool isAnyMiss = boardShots.Any(shot => shot.Ship == null);
                   Shot? firstSuccessShot = boardShots.Where(shot => shot.Ship != null).FirstOrDefault(); 
                   List<Position> hitPositions = boardShots.Where(shot => shot.Ship!=null ).Select(shot => shot.Position).ToList();
                   
                   
                   Console.WriteLine(" ");
                   Console.WriteLine("----- Statistics -----");
                   Console.WriteLine($"Total shots: {totalShots}");
                   Console.WriteLine($"Hits: {totalHits}");
                   Console.WriteLine($"Misses: {totalMisses}");
                   Console.WriteLine($"Any miss: {isAnyMiss}");
                   if (firstSuccessShot != null)
                   {
                       Console.WriteLine(
                           $"First success shot: X = {firstSuccessShot.Position.X}, Y = {firstSuccessShot.Position.Y}");
                   }
                   else
                   {
                       Console.WriteLine($"There is no success shot yet");
                   }

                   foreach (var ship in board.Ships)
                   {
                     var shipShots = boardShots.Where(shot => shot.Ship != null && shot.Ship == ship);
                     int hits =  shipShots.Count();
                     
                     Console.WriteLine($"{hits} hits ");
                     
                     bool isSunk = hits == ship.Lenght;
                     if (isSunk)
                     {
                         Console.WriteLine("Ship is Sunk");
                     }
                     else
                     {
                         Console.WriteLine("Ship still Alive");
                     }
                   }
            
        }
        
    }
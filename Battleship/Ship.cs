namespace Battleship;

public class Ship

{
public Position Position { get; private set; }
public int Length { get; private set; }

public Ship(Position position, int lenght)
{
    if (lenght <= 0)

    {
        throw new ArgumentException("Длина не может быть отрицательной или нулевой");
    }    
    Position = position;
    Length = lenght;

    }
}
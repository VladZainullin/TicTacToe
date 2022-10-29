using TicTacToe.Core;
using TicTacToe.Core.Enums;

var players = new[]
{
    new Player("Vlad"),
    new Player("Alex"),
    new Player("Dasha")
};

var game = new Game(players, 3);

while (game.Status != GameStatus.Stop)
{
    Console.WriteLine($"Move \"{game.CurrentPlayer.Name}\". Please, enter the coordinate");

    Console.Write("X: ");
    var x = ReadIntFromConsole("Incorrect coordinate X");

    Console.Write("Y: ");
    var y = ReadIntFromConsole("Incorrect coordinate Y");

    Console.Write("Z: ");
    var z = ReadIntFromConsole("Incorrect coordinate Z");

    var point = new Point(x, y, z);

    game.MakeMove(point);
}

Console.Write($"Player \"{game.CurrentPlayer.Name}\" vin!");

static int ReadIntFromConsole(string incorrectInputMessage)
{
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out var value))
        {
            return value;
        }

        Console.WriteLine(incorrectInputMessage);
    }
}
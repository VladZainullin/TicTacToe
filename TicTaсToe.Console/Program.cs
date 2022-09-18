// See https://aka.ms/new-console-template for more information

using TicTacToe.Core;
using TicTacToe.Core.Enums;

var vlad = new Player("Vlad");
var alex = new Player("Alex");
var dasha = new Player("Dasha");

var players = new[]
{
    vlad,
    alex,
    // dasha,
};

var game = new Game(players, 3);

while (game.Status != GameStatus.Stop)
{
    Console.WriteLine($"Move {game.CurrentPlayer.Name}. Please, enter the coordinate");

    Console.Write("X: ");
    var x = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Ошибка ввода X"));

    Console.Write("Y: ");
    var y = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Ошибка ввода Y"));
    
    Console.Write("Z: ");
    var z = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Ошибка ввода Y"));

    var point = new Point(x, y, z);
    
    game.MakeMove(point);
}

Console.WriteLine($"{game.CurrentPlayer.Name} win!");
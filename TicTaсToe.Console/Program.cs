// See https://aka.ms/new-console-template for more information

using TicTacToe.Core.Enums;
using TicTacToe.Core.Games;
using TicTacToe.Core.Players;
using TicTacToe.Core.Points;

var vlad = new Player("Vlad");
var alex = new Player("Alex");
var dasha = new Player("Dasha");

IPlayer[] players = {
    vlad,
    alex,
    // dasha
};

IGame game = new Game(players, 3);

while (game.Status != GameStatus.Stop)
{
    Console.WriteLine($"Ход {game.CurrentPlayer.Name}");

    Console.Write("Введите X: ");
    var x = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Ошибка ввода X"));

    Console.Write("Введите Y: ");
    var y = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Ошибка ввода Y"));

    IPoint point = new TwoDimensionalPoint(x, y);
    
    game.MakeMove(point);
}

Console.WriteLine($"{game.CurrentPlayer.Name} побеждает!");
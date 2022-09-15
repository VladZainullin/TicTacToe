// See https://aka.ms/new-console-template for more information

using TicTacToe.Core;

var vlad = new Player("Vlad");
var alex = new Player("Alex");

IEnumerable<Player> players = new[]
{
    vlad,
    alex
};

var game = new Game(players);
var endGame = true;

while (endGame)
{
    Console.WriteLine($"Ход {game.CurrentPlayer.Name}");
    
    Console.Write("Введите X: ");
    var x = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Ошибка ввода X"));
    
    Console.Write("Введите Y: ");
    var y = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Ошибка ввода Y"));
    
    game.MadeMove(x, y);

    var result = game.Check();
    endGame = result.EndGame;

    if (!result.EndGame)
    {
        Console.WriteLine($"{result.PlayerName} vin");
    }
}
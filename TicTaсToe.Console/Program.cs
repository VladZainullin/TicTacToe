﻿// See https://aka.ms/new-console-template for more information

using TicTacToe.Core;
using TicTacToe.Core.Enums;

var vlad = new Player("Vlad");
var alex = new Player("Alex");
var dasha = new Player("Dasha");

var players = new[]
{
    vlad,
    alex,
    dasha
};

var game = new Game(players, 3);

while (game.Status != GameStatus.Stop)
{
    Console.WriteLine($"Ход {game.CurrentPlayer.Name}");

    Console.Write("Введите X: ");
    var x = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Ошибка ввода X"));

    Console.Write("Введите Y: ");
    var y = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Ошибка ввода Y"));

    game.MakeMove(x, y);
}

Console.WriteLine($"{game.CurrentPlayer.Name} побеждает!");
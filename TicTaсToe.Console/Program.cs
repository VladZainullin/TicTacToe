﻿using TicTacToe.Core;
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
    var x = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Incorrect coordinate X"));

    Console.Write("Y: ");
    var y = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Incorrect coordinate Y"));

    Console.Write("Z: ");
    var z = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Incorrect coordinate Z"));

    var point = new Point(x, y, z);

    game.MakeMove(point);
}

Console.Write($"Player \"{game.CurrentPlayer.Name}\" win!");
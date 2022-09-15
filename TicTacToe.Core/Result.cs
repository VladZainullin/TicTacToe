namespace TicTacToe.Core;

public sealed class Result
{
    public Result(
        bool endGame,
        string playerName)
    {
        EndGame = endGame;
        PlayerName = playerName;
    }

    public bool EndGame { get; }
    public string PlayerName { get; }
}
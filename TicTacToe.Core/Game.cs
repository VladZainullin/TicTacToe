namespace TicTacToe.Core;

public sealed class Game
{
    private readonly Queue<Player> _players;
    private Player _currentPlayer;

    public Game(IEnumerable<Player> players)
    {
        _players = new Queue<Player>(players);
        _currentPlayer = new Player();
    }

    public void MadeMove(
        int x,
        int y)
    {
        _currentPlayer = _players.Dequeue();
        _currentPlayer.AddCell(x, y);
        _players.Enqueue(_currentPlayer);
    }

    public bool Check()
    {
        var cells = _currentPlayer.Cells;

        foreach (var cell in cells)
        {
            var line = new Line(cell, new Point(cell.X + 1, cell.Y + 1));
            
            var result = cells.Count(c => line.Check(c));

            if (result >= 5) return true;
        }

        return false;
    }
}
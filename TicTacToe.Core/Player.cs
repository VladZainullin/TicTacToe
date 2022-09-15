namespace TicTacToe.Core;

public sealed class Player
{
    internal ICollection<Point> Cells { get; } = new List<Point>();

    public void AddCell(
        int x,
        int y)
    {
        var cell = new Point(x, y);
        
        Cells.Add(cell);
    }
}
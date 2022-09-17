namespace TicTacToe.Core;

public sealed class Player
{
    private readonly ICollection<Point> _points;
    public Player(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        _points = new List<Point>(10);
    }

    public string Name { get; }

    public void AddPoint(Point point)
    {
        if (point == null) throw new ArgumentNullException(nameof(point));
        _points.Add(point);
    }

    public bool ContainsPoint(Point point)
    {
        if (point == null) throw new ArgumentNullException(nameof(point));
        return _points.Contains(point);
    }

    public bool Vin(int pointVinCount)
    {
        if (pointVinCount <= 3) throw new ArgumentOutOfRangeException(nameof(pointVinCount));
        
        return _points
            .Select(point => point
                .GenerateVectors(pointVinCount + 1)
                .Select(v => _points
                    .Count(p =>
                        v.Contains(p)
                        &&
                        !p.Equals(point)))
                .All(count => count < pointVinCount - 1))
            .All(b => !b);
    }
}
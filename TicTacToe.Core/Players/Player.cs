using TicTacToe.Core.Points;

namespace TicTacToe.Core.Players;

public sealed class Player : IPlayer
{
    private readonly ICollection<IPoint> _points;

    public Player(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        _points = new List<IPoint>(10);
    }

    public string Name { get; }

    public void AddPoint(IPoint twoDimensionalVectorPoint)
    {
        if (twoDimensionalVectorPoint == null) throw new ArgumentNullException(nameof(twoDimensionalVectorPoint));
        _points.Add(twoDimensionalVectorPoint);
    }

    public bool ContainsPoint(IPoint twoDimensionalVectorPoint)
    {
        if (twoDimensionalVectorPoint == null) throw new ArgumentNullException(nameof(twoDimensionalVectorPoint));
        return _points.Contains(twoDimensionalVectorPoint);
    }

    public bool Vin(int pointVinCount)
    {
        if (pointVinCount < 3) throw new ArgumentOutOfRangeException(nameof(pointVinCount));

        var vin = _points
            .Select(point => point
                .GenerateVectors(pointVinCount - 1)
                .Select(vector => _points
                    .Count(p =>
                        vector.Contains(p)
                        &&
                        !p.Equals(point)))
                .Any(count => count >= pointVinCount - 1))
            .Any(b => b);

        return vin;
    }
}
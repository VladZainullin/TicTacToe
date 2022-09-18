using TicTacToe.Core;
using Xunit;

namespace TicTacToe.Tests;

public sealed class VectorTests
{
    [Theory]
    [MemberData(nameof(VectorContainsPointData))]
    private void VectorContainsPointTest(
        Vector vector,
        Point point,
        bool result)
    {
        var actual = vector.Contains(point);

        Assert.Equal(result, actual);
    }

    private static IEnumerable<object[]> VectorContainsPointData()
    {
        yield return new object[]
        {
            new Vector(new Point(1, 1), new Point(3, 3)),
            new Point(2, 2),
            true
        };
        yield return new object[]
        {
            new Vector(new Point(-2, -1), new Point(2, 1)),
            new Point(0, 0),
            true
        };
        yield return new object[]
        {
            new Vector(new Point(5, -2), new Point(-4, 4)),
            new Point(2, 3),
            false
        };
        yield return new object[]
        {
            new Vector(new Point(-2, 4), new Point(3, 1)),
            new Point(3, 1),
            true
        };
        yield return new object[]
        {
            new Vector(new Point(-2, 4), new Point(3, 1)),
            new Point(-2, 4),
            true
        };
    }
}
using TicTacToe.Core;
using Xunit;

namespace TicTacToe.Tests;

public class LineTests
{
    [Theory]
    [MemberData(nameof(LineContainsPointData))]
    private void LineContainsPointTest(
        Line line,
        Point point,
        bool result)
    {
        Assert.Equal(result, line.Contains(point));
    }
    
    private static IEnumerable<object[]> LineContainsPointData()
    {
        yield return new object[] {new Line(new Point(1, 1), new Point(3, 3)), new Point(2, 2), true};
        yield return new object[] {new Line(new Point(4, 2), new Point(3, 9)), new Point(1, 15), true};
        yield return new object[] {new Line(new Point(5, -2), new Point(-4, 4)), new Point(2, 3), false};
    }
}
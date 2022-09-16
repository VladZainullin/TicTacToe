using Xunit;
using TicTacToe.Core;

namespace TicTacToe.Tests;

public sealed class PointTests
{
    [Theory]
    [MemberData(nameof(DividePointData))]
    public void DividePointTest(Point first, Point second, int result)
    {
        Assert.Equal(result, first / second);
    }
    public static IEnumerable<object[]> DividePointData()
    {
        yield return new object[] {new Point(3, 5), new Point(2, 4), 1};
        yield return new object[] {new Point(2, 6), new Point(3, 1), -1 / 6};
        yield return new object[] {new Point(-4, 2), new Point(3, -1), -7 / 3};
    }
}
using TicTacToe.Core;
using TicTacToe.Core.Points;
using TicTacToe.Core.Vectors;
using Xunit;

namespace TicTacToe.Tests;

public sealed class VectorTests
{
    [Theory]
    [MemberData(nameof(VectorContainsPointData))]
    private void VectorContainsPointTest(
        TwoDimensionalVector twoDimensionalVector,
        TwoDimensionalPoint twoDimensionalPoint,
        bool result)
    {
        var actual = twoDimensionalVector.Contains(twoDimensionalPoint);

        Assert.Equal(result, actual);
    }

    private static IEnumerable<object[]> VectorContainsPointData()
    {
        yield return new object[]
        {
            new TwoDimensionalVector(new TwoDimensionalPoint(1, 1), new TwoDimensionalPoint(3, 3)),
            new TwoDimensionalPoint(2, 2),
            true
        };
        yield return new object[]
        {
            new TwoDimensionalVector(new TwoDimensionalPoint(-2, -1), new TwoDimensionalPoint(2, 1)),
            new TwoDimensionalPoint(0, 0),
            true
        };
        yield return new object[]
        {
            new TwoDimensionalVector(new TwoDimensionalPoint(5, -2), new TwoDimensionalPoint(-4, 4)),
            new TwoDimensionalPoint(2, 3),
            false
        };
        yield return new object[]
        {
            new TwoDimensionalVector(new TwoDimensionalPoint(-2, 4), new TwoDimensionalPoint(3, 1)),
            new TwoDimensionalPoint(3, 1),
            true
        };
        yield return new object[]
        {
            new TwoDimensionalVector(new TwoDimensionalPoint(-2, 4), new TwoDimensionalPoint(3, 1)),
            new TwoDimensionalPoint(-2, 4),
            true
        };
    }
}
namespace TicTacToe.Core;

public sealed class Line
{
    private readonly Point _start;
    private readonly Point _end;

    public Line(
        Point start,
        Point end)
    {
        _start = start;
        _end = end;
    }

    /// <summary>
    /// Метод проверяет принадлежит ли точка прямой
    /// </summary>
    /// <param name="point">Точка</param>
    /// <returns></returns>
    public bool Check(Point point)
    {
        try
        {
            return point / _start == _end / _start;
        }
        catch (DivideByZeroException)
        {
            return false;
        }
    }
}
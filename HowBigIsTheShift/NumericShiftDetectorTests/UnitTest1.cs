using System.Linq;
using Xunit;
using HowBigIsTheShift;

/// <summary>
/// Unit-����� �� ����� <see cref="NumericShiftDetector"/>
/// </summary>
public class NumericShiftDetectorTests
{
    [Fact]
    public void TestSample1()
    {
        var sample = new[] { 15, 16, 18, 20, 1, 2, 5, 6, 7, 8, 11, 12 };
        var result = new NumericShiftDetector().GetShiftPosition(sample);
        Assert.Equal(expected: 4, actual: result);
    }

    [Fact]
    public void TestSample2()
    {
        var sample = new[] { 5, 6, 7, 8, 11, 12, 15, 16, 18, 20, 1, 2 };
        var result = new NumericShiftDetector().GetShiftPosition(sample);
        Assert.Equal(expected: 10, actual: result);
    }

    [Fact]
    public void TestSampleWithoutShift()
    {
        var sample = new[] { 1, 2, 5, 6, 7, 8, 11, 12, 15, 16, 18, 20 };
        var result = new NumericShiftDetector().GetShiftPosition(sample);
        Assert.Equal(expected: 0, actual: result);
    }

    [Fact]
    public void TestLargeSample()
    {
        var part1 = Enumerable.Range(15_000, 100_000); // 15000, 15001, ... 114998, 114999
        var part2 = Enumerable.Range(0, 14_995); // 0, 1, ... 14993, 14994
        var sample = part1.Concat(part2).ToArray(); // ����������� ���� ������������������� // 15000, 15001, ... 114998, 114999, 0, 1, ... 14993, 14994

        var result = new NumericShiftDetector().GetShiftPosition(sample);

        Assert.Equal(expected: 100_000, actual: result);
    }
}
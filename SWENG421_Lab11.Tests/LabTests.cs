namespace SWENG421_Lab11.Tests;

public class CalculatorTests
{
    private static CalculatorContext Run(string sequence)
    {
        var calc = new CalculatorContext();
        foreach (char ch in sequence)
        {
            if (char.IsWhiteSpace(ch)) continue;
            if (char.IsDigit(ch)) { calc.DigitPressed(ch); continue; }
            switch (ch)
            {
                case '+': calc.OperatorPressed('+'); break;
                case '-': calc.OperatorPressed('-'); break;
                case '*': calc.OperatorPressed('*'); break;
                case '/': calc.OperatorPressed('/'); break;
                case '=': calc.EqualsPressed(); break;
            }
        }
        return calc;
    }

    [Fact]
    public void FivePlusSix_Equals_11() =>
        Assert.Equal("11", Run("5 + 6 =").DisplayValue);

    [Fact]
    public void FivePlusEqualsEquals_Equals_15() =>
        Assert.Equal("15", Run("5 + = =").DisplayValue);

    [Fact]
    public void SixTimesFiveEqualsEquals_Equals_150() =>
        Assert.Equal("150", Run("6 * 5 = =").DisplayValue);

    [Fact]
    public void SixEqualsEquals_Equals_6() =>
        Assert.Equal("6", Run("6 = =").DisplayValue);

    [Fact]
    public void NineMultipleOpsSix_Equals_21() =>
        Assert.Equal("21", Run("9 + + + + 6 = =").DisplayValue);
}

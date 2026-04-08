using System.Globalization;
using SWENG421_Lab11.States;

namespace SWENG421_Lab11;

public class CalculatorContext
{
    private ICalculatorState _state;

    public double Operand1 { get; set; }
    public char? LastOperator { get; set; }
    public double LastOperand2 { get; set; }
    public string DisplayValue { get; set; } = "0";

    private static readonly Dictionary<char, Func<double, double, double>> Operations = new()
    {
        ['+'] = (a, b) => a + b,
        ['-'] = (a, b) => a - b,
        ['*'] = (a, b) => a * b,
        ['/'] = (a, b) => a / b,
    };

    public CalculatorContext()
    {
        _state = new InitialState();
    }

    public void SetState(ICalculatorState state) => _state = state;

    public double Compute(double a, char op, double b)
    {
        if (!Operations.TryGetValue(op, out var fn))
            throw new InvalidOperationException($"Unknown operator: {op}");
        return fn(a, b);
    }

    public void Reset()
    {
        Operand1 = 0;
        LastOperator = null;
        LastOperand2 = 0;
        DisplayValue = "0";
        SetState(new InitialState());
    }

    public void DigitPressed(char digit) => _state.HandleDigit(this, digit);
    public void OperatorPressed(char op) => _state.HandleOperator(this, op);
    public void EqualsPressed() => _state.HandleEquals(this);
    public void ClearPressed() => _state.HandleClear(this);
    public void DecimalPointPressed() => _state.HandleDecimalPoint(this);
    public void NegatePressed() => _state.HandleNegate(this);
    public void BackspacePressed() => _state.HandleBackspace(this);
    public void SqrtPressed() => _state.HandleSqrt(this);
    public void ReciprocalPressed() => _state.HandleReciprocal(this);

    public static double ParseDisplay(string display) =>
        double.TryParse(display, NumberStyles.Any, CultureInfo.InvariantCulture, out var result)
            ? result
            : 0;

    public static string FormatDouble(double value)
    {
        if (double.IsPositiveInfinity(value) || double.IsNegativeInfinity(value))
            return "Cannot divide by zero";
        if (double.IsNaN(value))
            return "Invalid input";
        return value.ToString("G15", CultureInfo.InvariantCulture);
    }
}

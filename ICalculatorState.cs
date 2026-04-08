namespace SWENG421_Lab11;

public interface ICalculatorState
{
    void HandleDigit(CalculatorContext ctx, char digit);
    void HandleOperator(CalculatorContext ctx, char op);
    void HandleEquals(CalculatorContext ctx);
    void HandleClear(CalculatorContext ctx);
    void HandleDecimalPoint(CalculatorContext ctx);
    void HandleNegate(CalculatorContext ctx);
    void HandleBackspace(CalculatorContext ctx);
    void HandleSqrt(CalculatorContext ctx);
    void HandleReciprocal(CalculatorContext ctx);
}

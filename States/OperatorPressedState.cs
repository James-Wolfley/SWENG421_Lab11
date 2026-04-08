namespace SWENG421_Lab11.States;

public class OperatorPressedState : ICalculatorState
{
    public void HandleDigit(CalculatorContext ctx, char digit)
    {
        ctx.DisplayValue = digit.ToString();
        ctx.SetState(new SecondOperandState());
    }

    public void HandleOperator(CalculatorContext ctx, char op)
    {
        ctx.LastOperator = op;
    }

    public void HandleEquals(CalculatorContext ctx)
    {
        double operand2 = ctx.Operand1;
        ctx.LastOperand2 = operand2;
        double result = ctx.Compute(ctx.Operand1, ctx.LastOperator!.Value, operand2);
        ctx.Operand1 = result;
        ctx.DisplayValue = CalculatorContext.FormatDouble(result);
        ctx.SetState(new ResultState());
    }

    public void HandleClear(CalculatorContext ctx) => ctx.Reset();

    public void HandleDecimalPoint(CalculatorContext ctx)
    {
        ctx.DisplayValue = "0.";
        ctx.SetState(new SecondOperandState());
    }

    public void HandleNegate(CalculatorContext ctx)
    {
        ctx.Operand1 = -ctx.Operand1;
        ctx.DisplayValue = CalculatorContext.FormatDouble(ctx.Operand1);
    }

    public void HandleBackspace(CalculatorContext ctx) { }

    public void HandleSqrt(CalculatorContext ctx)
    {
        double result = Math.Sqrt(ctx.Operand1);
        ctx.Operand1 = result;
        ctx.DisplayValue = CalculatorContext.FormatDouble(result);
    }

    public void HandleReciprocal(CalculatorContext ctx)
    {
        double result = 1.0 / ctx.Operand1;
        ctx.Operand1 = result;
        ctx.DisplayValue = CalculatorContext.FormatDouble(result);
    }
}

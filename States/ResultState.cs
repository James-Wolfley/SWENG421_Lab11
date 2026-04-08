namespace SWENG421_Lab11.States;

public class ResultState : ICalculatorState
{
    public void HandleDigit(CalculatorContext ctx, char digit)
    {
        ctx.Operand1 = 0;
        ctx.LastOperator = null;
        ctx.DisplayValue = digit.ToString();
        ctx.SetState(new FirstOperandState());
    }

    public void HandleOperator(CalculatorContext ctx, char op)
    {
        ctx.LastOperator = op;
        ctx.SetState(new OperatorPressedState());
    }

    public void HandleEquals(CalculatorContext ctx)
    {
        if (ctx.LastOperator.HasValue)
        {
            double result = ctx.Compute(ctx.Operand1, ctx.LastOperator.Value, ctx.LastOperand2);
            ctx.Operand1 = result;
            ctx.DisplayValue = CalculatorContext.FormatDouble(result);
        }
    }

    public void HandleClear(CalculatorContext ctx) => ctx.Reset();

    public void HandleDecimalPoint(CalculatorContext ctx)
    {
        ctx.Operand1 = 0;
        ctx.LastOperator = null;
        ctx.DisplayValue = "0.";
        ctx.SetState(new FirstOperandState());
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

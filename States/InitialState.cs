namespace SWENG421_Lab11.States;

public class InitialState : ICalculatorState
{
    public void HandleDigit(CalculatorContext ctx, char digit)
    {
        if (digit != '0')
        {
            ctx.DisplayValue = digit.ToString();
            ctx.SetState(new FirstOperandState());
        }
    }

    public void HandleOperator(CalculatorContext ctx, char op)
    {
        ctx.Operand1 = 0;
        ctx.LastOperator = op;
        ctx.SetState(new OperatorPressedState());
    }

    public void HandleEquals(CalculatorContext ctx) { }

    public void HandleClear(CalculatorContext ctx) => ctx.Reset();

    public void HandleDecimalPoint(CalculatorContext ctx)
    {
        ctx.DisplayValue = "0.";
        ctx.SetState(new FirstOperandState());
    }

    public void HandleNegate(CalculatorContext ctx) { }

    public void HandleBackspace(CalculatorContext ctx) { }

    public void HandleSqrt(CalculatorContext ctx)
    {
        ctx.Operand1 = 0;
        ctx.DisplayValue = "0";
        ctx.SetState(new ResultState());
    }

    public void HandleReciprocal(CalculatorContext ctx)
    {
        ctx.DisplayValue = "Cannot divide by zero";
        ctx.SetState(new ResultState());
    }
}

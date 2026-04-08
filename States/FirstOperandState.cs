namespace SWENG421_Lab11.States;

public class FirstOperandState : ICalculatorState
{
    public void HandleDigit(CalculatorContext ctx, char digit)
    {
        if (ctx.DisplayValue == "0")
        {
            if (digit != '0')
                ctx.DisplayValue = digit.ToString();
        }
        else
        {
            ctx.DisplayValue += digit;
        }
    }

    public void HandleOperator(CalculatorContext ctx, char op)
    {
        ctx.Operand1 = CalculatorContext.ParseDisplay(ctx.DisplayValue);
        ctx.LastOperator = op;
        ctx.SetState(new OperatorPressedState());
    }

    public void HandleEquals(CalculatorContext ctx)
    {
        ctx.Operand1 = CalculatorContext.ParseDisplay(ctx.DisplayValue);
        ctx.LastOperator = null;
        ctx.SetState(new ResultState());
    }

    public void HandleClear(CalculatorContext ctx) => ctx.Reset();

    public void HandleDecimalPoint(CalculatorContext ctx)
    {
        if (!ctx.DisplayValue.Contains('.'))
            ctx.DisplayValue += '.';
    }

    public void HandleNegate(CalculatorContext ctx)
    {
        if (ctx.DisplayValue.StartsWith('-'))
            ctx.DisplayValue = ctx.DisplayValue[1..];
        else if (ctx.DisplayValue != "0")
            ctx.DisplayValue = '-' + ctx.DisplayValue;
    }

    public void HandleBackspace(CalculatorContext ctx)
    {
        if (ctx.DisplayValue.Length > 1)
        {
            ctx.DisplayValue = ctx.DisplayValue[..^1];
            if (ctx.DisplayValue == "-")
                ctx.DisplayValue = "0";
        }
        else
        {
            ctx.DisplayValue = "0";
            ctx.SetState(new InitialState());
        }
    }

    public void HandleSqrt(CalculatorContext ctx)
    {
        double val = CalculatorContext.ParseDisplay(ctx.DisplayValue);
        double result = Math.Sqrt(val);
        ctx.Operand1 = result;
        ctx.DisplayValue = CalculatorContext.FormatDouble(result);
        ctx.SetState(new ResultState());
    }

    public void HandleReciprocal(CalculatorContext ctx)
    {
        double val = CalculatorContext.ParseDisplay(ctx.DisplayValue);
        double result = 1.0 / val;
        ctx.Operand1 = result;
        ctx.DisplayValue = CalculatorContext.FormatDouble(result);
        ctx.SetState(new ResultState());
    }
}

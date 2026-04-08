namespace SWENG421_Lab11;

class Program
{
    static void Main(string[] _)
    {
        var calc = new CalculatorContext();

        Console.WriteLine("Windows Calculator");
        Console.WriteLine("Buttons: 0-9  +  -  *  /  =  .  c(clear)  n(negate)  s(sqrt)  r(1/x)  <(backspace)");
        Console.WriteLine("Type a sequence of button presses and press Enter. Type 'q' to quit.");
        Console.WriteLine();
        Console.WriteLine($"[ {calc.DisplayValue} ]");
        Console.WriteLine();

        while (true)
        {
            Console.Write("> ");
            string? line = Console.ReadLine();

            if (line == null || line.Equals("q", StringComparison.OrdinalIgnoreCase))
                break;

            calc.Reset();

            foreach (char ch in line)
            {
                if (char.IsWhiteSpace(ch)) continue;

                string buttonName;

                if (char.IsDigit(ch))
                {
                    calc.DigitPressed(ch);
                    buttonName = ch.ToString();
                }
                else
                {
                    switch (char.ToLower(ch))
                    {
                        case '+':
                            calc.OperatorPressed('+');
                            buttonName = "+";
                            break;
                        case '-':
                            calc.OperatorPressed('-');
                            buttonName = "-";
                            break;
                        case '*':
                            calc.OperatorPressed('*');
                            buttonName = "*";
                            break;
                        case '/':
                            calc.OperatorPressed('/');
                            buttonName = "/";
                            break;
                        case '=':
                            calc.EqualsPressed();
                            buttonName = "=";
                            break;
                        case '.':
                            calc.DecimalPointPressed();
                            buttonName = ".";
                            break;
                        case 'c':
                            calc.ClearPressed();
                            buttonName = "C";
                            break;
                        case 'n':
                            calc.NegatePressed();
                            buttonName = "(-)";
                            break;
                        case 's':
                            calc.SqrtPressed();
                            buttonName = "square root";
                            break;
                        case 'r':
                            calc.ReciprocalPressed();
                            buttonName = "1/x";
                            break;
                        case '<':
                            calc.BackspacePressed();
                            buttonName = "backspace";
                            break;
                        default:
                            continue;
                    }
                }

                Console.WriteLine($"  [{buttonName}] → {calc.DisplayValue}");
            }

            Console.WriteLine($"\n[ {calc.DisplayValue} ]\n");
        }
    }
}

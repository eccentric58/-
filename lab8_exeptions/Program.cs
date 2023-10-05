xusing System;

public class ExceptionTest
{
    static double SafeConvertionDouble(string s)
    {
        double res;
        if (double.TryParse(s, out res))
        {
            if (Math.Abs(res) >= 1000000)
                throw new ArgumentOutOfRangeException();
            else
                return res;
        }
        else if (s.Length == 0)
            throw new InvalidCastException();
        else
            throw new ArgumentException();
    }
    static double SafeDivision(double x, double y)
    {
        if (y == 0)
            throw new DivideByZeroException();
        return x / y;
    }

    public static void Main()
    {
        double a = 0, b = 0, result;
        Console.WriteLine("Input a:");
        string readStrA = Console.ReadLine();
        Console.WriteLine("Input b:");
        string readStrB = Console.ReadLine();
        try
        {
            a = SafeConvertionDouble(readStrA);
            b = SafeConvertionDouble(readStrB);
            result = SafeDivision(a, b);
            Console.WriteLine("{0} / {1} = {2}", a, b, result);
        }
        catch (InvalidCastException)
        {
            Console.WriteLine("ERROR: Inputed string is empty.");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("ERROR: Inputed number more then +-1 000 000.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("ERROR: Inputed string is not a number.");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("ERROR: Attempted divide by zero.");
        }

        Console.ReadLine();
    }
}

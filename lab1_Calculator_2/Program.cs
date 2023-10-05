using System;

namespace lab1_Calculator_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 'end' to finish OR something else to continue.");
            while (Console.ReadLine() != "end")
            {
                double a = 0.0, b = 0.0;

                Console.WriteLine("Enter first number A:");
                while (!(double.TryParse(Console.ReadLine(), out a)))
                    Console.WriteLine("ERROR: Wrong number. Write 1,6 instead 1.6. Enter A again:");
                
                Console.WriteLine("Enter operation (+, -, *, /):");
                string operation = Console.ReadLine();
                while ((operation != "+") && (operation != "-") && (operation != "*") && (operation != "/"))
                {
                    Console.WriteLine("ERROR: Wrong operation. Enter operation (+, -, *, /) again:");
                    operation = Console.ReadLine();
                }

                Console.WriteLine("Enter second number B:");
                while (!(double.TryParse(Console.ReadLine(), out b)))
                    Console.WriteLine("ERROR: Wrong number. Write 1,6 instead 1.6. Enter B again:");
                
                string result_str = $"RESULT: a {operation} b = {a.ToString()} {operation} {b.ToString()} = ";
                switch (operation)
                {
                    case "+":
                        {
                            Console.WriteLine(result_str + (a + b).ToString());
                            break;
                        }
                    case "-":
                        {
                            Console.WriteLine(result_str + (a - b).ToString());
                            break;
                        }
                    case "*":
                        {
                            Console.WriteLine(result_str + (a * b).ToString());
                            break;
                        }
                    case "/":
                        {
                            if (b == 0.0)
                                Console.WriteLine("ERROR: B = 0. Division by zero is not allowed.");
                            else
                                Console.WriteLine(result_str + (a / b).ToString());
                            break;
                        }
                }
                Console.WriteLine("\nEnter 'end' to finish OR something else to continue.");
            }
        }
    }
}
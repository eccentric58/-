using System;
using System.Collections.Generic;
using System.Linq;

namespace dz1_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = { "1+2*7+15", "(234-11)*34", "6*6+30/6" };
            int[] results = { 30, 7582, 41 };


            for (int i = 0; i < inputs.Length; i++)
            {
                Console.WriteLine(inputs[i] + $" = {results[i]}");
                if (algorithm(inputs[i]) == results[i])
                    Console.WriteLine("### Correct ###");
                else
                    Console.WriteLine("### Fail ###");
            }

            Console.WriteLine("Input example:");
            string example = Console.ReadLine();
            Console.Write("\n\nRESULT: " + example + " = " + algorithm(example).ToString());

            Console.ReadLine();
        }
        static int algorithm(string example)
        {
            char[] separators = new char[] { '+', '-', '(', ')', '/', '*' };
            List<string> literals = example.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<int> num_stack = new List<int>();
            for (int i = 0; i < literals.Count; i++)
            {
                int n = 0;
                int.TryParse(literals[i], out n);
                num_stack.Add(n);
            }

            literals.Sort((a, b) => a.Length.CompareTo(b.Length));
            literals.Reverse();
            for (int i = 0; i < literals.Count; i++)
                example = example.Replace(literals[i], "a");

            example += 'e';
            List<char> op_stack = new List<char>();
            op_stack.Add('b');
            List<char> com_stack = new List<char>();
            for (int i = 0; i < example.Length; i++)
            {
                switch (example[i])
                {
                    case 'a': com_stack.Add('a'); break;
                    case '(': op_stack.Add('('); break;
                    case 'e':
                        {
                            switch (op_stack[op_stack.Count - 1])
                            {
                                case 'b':
                                case '(': break;
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                    {
                                        com_stack.Add(op_stack[op_stack.Count - 1]);
                                        op_stack.RemoveAt(op_stack.Count - 1);
                                        i--;
                                        break;
                                    }
                            }
                            break;
                        }
                    case ')':
                        {
                            switch (op_stack[op_stack.Count - 1])
                            {
                                case 'b': break;
                                case '(': op_stack.RemoveAt(op_stack.Count - 1); break;
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                    {
                                        com_stack.Add(op_stack[op_stack.Count - 1]);
                                        op_stack.RemoveAt(op_stack.Count - 1);
                                        i--;
                                        break;
                                    }
                            }
                            break;
                        }
                    case '+':
                        {
                            switch (op_stack[op_stack.Count - 1])
                            {
                                case 'b':
                                case '(': op_stack.Add('+'); break;
                                case '+': com_stack.Add('+'); break;
                                case '-':
                                    {
                                        op_stack.RemoveAt(op_stack.Count - 1);
                                        op_stack.Add('+');
                                        com_stack.Add('-');
                                        break;
                                    }
                                case '*':
                                case '/':
                                    {
                                        com_stack.Add(op_stack[op_stack.Count - 1]);
                                        op_stack.RemoveAt(op_stack.Count - 1);
                                        i--;
                                        break;
                                    }
                            }
                            break;
                        }
                    case '-':
                        {
                            switch (op_stack[op_stack.Count - 1])
                            {
                                case 'b':
                                case '(': op_stack.Add('-'); break;
                                case '-': com_stack.Add('-'); break;
                                case '+':
                                    {
                                        op_stack.RemoveAt(op_stack.Count - 1);
                                        op_stack.Add('-');
                                        com_stack.Add('+');
                                        break;
                                    }
                                case '*':
                                case '/':
                                    {
                                        com_stack.Add(op_stack[op_stack.Count - 1]);
                                        op_stack.RemoveAt(op_stack.Count - 1);
                                        i--;
                                        break;
                                    }
                            }
                            break;
                        }
                    case '*':
                        {
                            switch (op_stack[op_stack.Count - 1])
                            {
                                case 'b':
                                case '-':
                                case '+':
                                case '(': op_stack.Add('*'); break;
                                case '*': com_stack.Add('*'); break;
                                case '/':
                                    {
                                        op_stack.RemoveAt(op_stack.Count - 1);
                                        op_stack.Add('*');
                                        com_stack.Add('/');
                                        break;
                                    }
                            }
                            break;
                        }
                    case '/':
                        {
                            switch (op_stack[op_stack.Count - 1])
                            {
                                case 'b':
                                case '-':
                                case '+':
                                case '(': op_stack.Add('/'); break;
                                case '/': com_stack.Add('/'); break;
                                case '*':
                                    {
                                        op_stack.RemoveAt(op_stack.Count - 1);
                                        op_stack.Add('/');
                                        com_stack.Add('*');
                                        break;
                                    }
                            }
                            break;
                        }
                }
            }

            List<int> operands = new List<int>();
            for (int i = 0; i < com_stack.Count; i++)
            {
                int t = 0;
                switch (com_stack[i])
                {
                    case 'a':
                        {
                            operands.Add(num_stack[0]);
                            num_stack.RemoveAt(0);
                            break;
                        }
                    case '+': t = operands[operands.Count - 2] + operands[operands.Count - 1]; break;
                    case '-': t = operands[operands.Count - 2] - operands[operands.Count - 1]; break;
                    case '*': t = operands[operands.Count - 2] * operands[operands.Count - 1]; break;
                    case '/': t = operands[operands.Count - 2] / operands[operands.Count - 1]; break;
                }
                if (com_stack[i] != 'a')
                {
                    operands.RemoveAt(operands.Count - 1);
                    operands.RemoveAt(operands.Count - 1);
                    operands.Add(t);
                }
            }

            return operands[0];
        }
    }
}


 /* using System;
using System.Collections.Generic;
using System.Linq;

namespace dz1_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input example:");
            string example = Console.ReadLine();
            Console.Write("\n\nRESULT: " + example);

            char[] separators = new char[] { '+', '-', '(', ')', '/', '*' };
            List<string> literals = example.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<int> num_stack = new List<int>();
            for (int i = 0; i < literals.Count; i++)
            {
                int n = 0;
                int.TryParse(literals[i], out n);
                num_stack.Add(n);
            }

            literals.Sort((a, b) => a.Length.CompareTo(b.Length));
            literals.Reverse();
            for (int i = 0; i< literals.Count;i++)
                example = example.Replace(literals[i], "a");

            example += 'e';
            List<char> op_stack = new List<char>();
            op_stack.Add('b');
            List<char> com_stack = new List<char>();
            for (int i = 0; i< example.Length;i++)
            {
                switch(example[i])
                {
                    case 'a': com_stack.Add('a'); break;
                    case '(': op_stack.Add('('); break;
                    case 'e':
                        {
                            switch (op_stack[op_stack.Count - 1])
                            {
                                case 'b': 
                                case '(': break;
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                    {
                                        com_stack.Add(op_stack[op_stack.Count - 1]);
                                        op_stack.RemoveAt(op_stack.Count - 1);
                                        i--;
                                        break;
                                    }
                            }
                            break;
                        }
                    case ')':
                        {
                            switch (op_stack[op_stack.Count - 1])
                            {
                                case 'b': break;
                                case '(': op_stack.RemoveAt(op_stack.Count - 1); break;
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                    {
                                        com_stack.Add(op_stack[op_stack.Count - 1]);
                                        op_stack.RemoveAt(op_stack.Count - 1);
                                        i--;
                                        break;
                                    }
                            }
                            break;
                        }
                    case '+':
                        {
                            switch(op_stack[op_stack.Count - 1])
                            {
                                case 'b':
                                case '(': op_stack.Add('+'); break;
                                case '+': com_stack.Add('+'); break;
                                case '-':
                                    {
                                        op_stack.RemoveAt(op_stack.Count - 1);
                                        op_stack.Add('+');
                                        com_stack.Add('-');
                                        break;
                                    }
                                case '*':
                                case '/':
                                    {
                                        com_stack.Add(op_stack[op_stack.Count - 1]);
                                        op_stack.RemoveAt(op_stack.Count - 1);
                                        i--;
                                        break;
                                    }
                            }
                            break;
                        }
                    case '-':
                        {
                            switch (op_stack[op_stack.Count - 1])
                            {
                                case 'b':
                                case '(': op_stack.Add('-'); break;
                                case '-': com_stack.Add('-'); break;
                                case '+':
                                    {
                                        op_stack.RemoveAt(op_stack.Count - 1);
                                        op_stack.Add('-');
                                        com_stack.Add('+');
                                        break;
                                    }
                                case '*':
                                case '/':
                                    {
                                        com_stack.Add(op_stack[op_stack.Count - 1]);
                                        op_stack.RemoveAt(op_stack.Count - 1);
                                        i--;
                                        break;
                                    }
                            }
                            break;
                        }
                    case '*':
                        {
                            switch (op_stack[op_stack.Count - 1])
                            {
                                case 'b':
                                case '-':
                                case '+':
                                case '(': op_stack.Add('*'); break;
                                case '*': com_stack.Add('*'); break;
                                case '/':
                                    {
                                        op_stack.RemoveAt(op_stack.Count - 1);
                                        op_stack.Add('*');
                                        com_stack.Add('/');
                                        break;
                                    }
                            }
                            break;
                        }
                    case '/':
                        {
                            switch (op_stack[op_stack.Count - 1])
                            {
                                case 'b':
                                case '-':
                                case '+':
                                case '(': op_stack.Add('/'); break;
                                case '/': com_stack.Add('/'); break;
                                case '*':
                                    {
                                        op_stack.RemoveAt(op_stack.Count - 1);
                                        op_stack.Add('/');
                                        com_stack.Add('*');
                                        break;
                                    }
                            }
                            break;
                        }
                }
            }

            List<int> operands = new List<int>();
            for (int i = 0; i < com_stack.Count;i++)
            {
                int t = 0;
                switch (com_stack[i])
                {
                    case 'a':
                        {
                            operands.Add(num_stack[0]);
                            num_stack.RemoveAt(0);
                            break;
                        }
                    case '+': t = operands[operands.Count - 2] + operands[operands.Count - 1]; break;
                    case '-': t = operands[operands.Count - 2] - operands[operands.Count - 1]; break;
                    case '*': t = operands[operands.Count - 2] * operands[operands.Count - 1]; break;
                    case '/': t = operands[operands.Count - 2] / operands[operands.Count - 1]; break;
                }
                if (com_stack[i] != 'a')
                {
                    operands.RemoveAt(operands.Count - 1);
                    operands.RemoveAt(operands.Count - 1);
                    operands.Add(t);
                }
            }

            Console.WriteLine($" = {operands[0]}");
            Console.ReadLine();
        }
    }
}
 * */



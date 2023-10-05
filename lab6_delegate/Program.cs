using System;

namespace lab6_delegate
{ 
    class Program
    {
        public delegate Object myDelegate(int a, string b);

        static void Main()
        {
            int i = 5;
            myDelegate delegate_1 = new myDelegate(concate_int_string);
            Object obj = delegate_in_parameters(delegate_1, i);
            Console.WriteLine($"Concated int {i} and string.");
            Console.WriteLine(obj);

            obj = delegate_in_parameters((int a, string b) => { return b.Length + a; }, i);
            Console.WriteLine($"\nLength of previous string + {i} - 1");
            Console.WriteLine(obj);

            Func<int, string, Object> func_delegate = (a, b) => b.Length == a;
            myDelegate delegate_2 = new myDelegate(func_delegate);
            obj = delegate_in_parameters(delegate_2, i);
            Console.WriteLine($"\nIs length of previous string == {i}?");
            Console.WriteLine(obj);

            Console.ReadLine();
        }

        private static Object delegate_in_parameters(myDelegate d, int a)
        {
            return d(a, " - string" + a.ToString());
        }

        private static Object concate_int_string(int a, string b)
        {
            return a.ToString() + b;
        }
    }
}
using System;

namespace lab2_array_task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            Console.WriteLine("Enter size of array A:");
            while (true)
            {
                while (!(int.TryParse(Console.ReadLine(), out n)))
                    Console.WriteLine("ERROR: Wrong number. Enter size of array A again:");
                if (n < 0)
                    Console.WriteLine("ERROR: Number less then zero. Enter size of array A again:");
                else
                    break;
            }
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter A[{i}]:");
                while (!(int.TryParse(Console.ReadLine(), out a[i])))
                    Console.WriteLine($"ERROR: Wrong number. Enter A[{i}] again:");
            }

            Console.WriteLine("Enter size of array B:");
            while (true)
            {

                while (!(int.TryParse(Console.ReadLine(), out m)))
                    Console.WriteLine("ERROR: Wrong number. Enter size of array B again:");
                if (m < 0)
                    Console.WriteLine("ERROR: Number less then zero. Enter size of array B again:");
                else
                    break;
            }
            int[] b = new int[m];
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine($"Enter B[{i}]:");
                while (!(int.TryParse(Console.ReadLine(), out b[i])))
                    Console.WriteLine($"ERROR: Wrong number. Enter B[{i}] again:");
            }

            Console.WriteLine("\nArray A: " + String.Join(", ", a));
            Console.WriteLine("Array B: " + String.Join(", ", b));

            Array.Sort(a);
            Array.Sort(b);
            Array.Reverse(b);

            Console.WriteLine("Sorted array A: " + String.Join(", ", a));
            Console.WriteLine("Sorted array B: " + String.Join(", ", b));

            int[] c = new int[n + m];
            a.CopyTo(c, 0);
            b.CopyTo(c, a.Length);

            Console.WriteLine("RESULT - Array C: " + String.Join(", ", c));
            Console.ReadLine();
        }
    }
}

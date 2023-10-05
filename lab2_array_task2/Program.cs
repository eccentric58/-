using System;

namespace lab2_array_task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            Console.WriteLine("Enter number of ROWS n in matrix A[n,m]:");
            while (true)
            {
                while (!(int.TryParse(Console.ReadLine(), out n)))
                    Console.WriteLine("ERROR: Wrong number. Enter number of rows again:");
                if (n < 0)
                    Console.WriteLine("ERROR: Number less then zero. Enter number of rows again:");
                else
                    break;
            }
            Console.WriteLine("Enter number of COLUMNS m in matrix A[n,m]:");
            while (true)
            {
                while (!(int.TryParse(Console.ReadLine(), out m)))
                    Console.WriteLine("ERROR: Wrong number. Enter number of columns again:");
                if (m < 0)
                    Console.WriteLine("ERROR: Number less then zero. Enter number of columns again:");
                else
                    break;
            }

            int[][] a = new int[n][];
            Random rand = new Random();
            Console.WriteLine("\nArray A: ");
            for (int i = 0; i < n; i++)
            {
                a[i] = new int[m];
                for (int j = 0; j < m; j++)
                    a[i][j] = rand.Next(0, 9);
                Console.WriteLine(String.Join("  ", a[i]));
            }

            int[][] b = new int[m][];
            for (int i = 0; i < m; i++)
            {
                b[i] = new int[n];
                for (int j = 0; j < n; j++)
                    b[i][j] = a[j][i];
                Array.Sort(b[i]);
            }

            Console.WriteLine("\nSorted by rows array A: ");
            for (int i = 0; i < n; i++)
            {
                Array.Sort(a[i]);
                Console.WriteLine(String.Join("  ", a[i]));
            }

            Console.WriteLine("\nSorted by columns array A: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    a[i][j] = b[j][i];
                Console.WriteLine(String.Join("  ", a[i]));
            }

            Console.ReadLine();
        }
    }
}


/*
Console.WriteLine("Enter size of matrix A like \"n m\" with space:");
string[] nums = Console.ReadLine().Split(' ');
foreach (string s in nums)
{

}*/
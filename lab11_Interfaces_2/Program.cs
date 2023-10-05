using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace lab11_Interface_2
{
    class Program
    {
        class Point
        {
            protected double x;
            protected double y;
            protected int num;
            public Point(double a, double b, int n)
            {
                x = a;
                y = b;
                num = n;
            }
            public override string ToString()
            {
                return $"{num}. ({Math.Round(x,3)}, {Math.Round(y, 3)})";
            }
            public double X
            {
                get { return x; }
                set { x = value; }
            }
            public double Y
            {
                get { return y; }
                set { y = value; }
            }
        }
        class PointComparer_by_begin : IComparer<Point>
        {
            public int Compare(Point x, Point y)
            {
                double len1 = lengthBetweenPoints(x.X, x.Y, 0.0, 0.0);
                double len2 = lengthBetweenPoints(0.0, 0.0, y.X, y.Y);
                return CompareLengths(len1, len2);
            }
        }
        class PointComparer_by_abscis : IComparer<Point>
        {
            public int Compare(Point x, Point y)
            {
                return CompareLengths(x.Y, y.Y);
            }
        }
        class PointComparer_by_ordinate : IComparer<Point>
        {
            public int Compare(Point x, Point y)
            {
                return CompareLengths(x.X, y.X);
            }
        }
        class PointComparer_by_diagonal : IComparer<Point>
        {
            public int Compare(Point x, Point y)
            {
                double len1 = Math.Abs(x.X - x.Y) / Math.Sqrt(2);
                double len2 = Math.Abs(y.X - y.Y) / Math.Sqrt(2);
                return CompareLengths(len1, len2);
            }
        }
        static double lengthBetweenPoints(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
        static int CompareLengths(double len1, double len2)
        {
            if (len1 == len2) return 0;
            else if (len1 < len2) return -1;
            else return 1;
        }
        static List<Point> generateListOfPoints(int n)
        {
            List<Point> result = new List<Point>();
            Random random = new Random();
            for (int i = 0; i < n; i++) 
                result.Add(new Point(random.NextDouble(), random.NextDouble(),i+1));
            return result;
        }
        static void Main(string[] args)
        {
            List<Point> points = new List<Point>(generateListOfPoints(5));
            Console.WriteLine("Random list of points:");
            for (int i = 0; i < points.Count; i++)
                Console.WriteLine(points[i]);

            Console.WriteLine("\nSorted list by begin (0, 0):");
            points.Sort(new PointComparer_by_begin());
            for (int i = 0; i < points.Count; i++)
            {
                double len = lengthBetweenPoints(points[i].X, points[i].Y, 0.0, 0.0);
                Console.WriteLine($"{points[i]} \t {Math.Round(len, 6)}");
            }

            Console.WriteLine("\nSorted list by abscis y=0:");
            points.Sort(new PointComparer_by_abscis());
            for (int i = 0; i < points.Count; i++)
                Console.WriteLine($"{points[i]} \t {Math.Round(points[i].Y, 6)}");

            Console.WriteLine("\nSorted list by ordinate x=0:");
            points.Sort(new PointComparer_by_ordinate());
            for (int i = 0; i < points.Count; i++)
                Console.WriteLine($"{points[i]} \t {Math.Round(points[i].X, 6)}");

            Console.WriteLine("\nSorted list by diagonal y=x:");
            points.Sort(new PointComparer_by_diagonal());
            for (int i = 0; i < points.Count; i++)
            {
                double len = Math.Abs(points[i].X - points[i].Y) / Math.Sqrt(2);
                Console.WriteLine($"{points[i]} \t {Math.Round(len, 6)}");
            }

            Console.ReadLine();
        }
    }
}

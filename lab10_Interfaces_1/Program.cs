using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace lab10_Interface_1
{
    class Program
    {
        class LeftProduct : IComparable<LeftProduct>
        {
            protected double weight_kg;
            protected string weight_of_product;
            protected string name_of_product;
            public int CompareTo(LeftProduct obj)
            {
                if (obj.weight_kg == this.weight_kg) return 0;
                else if (obj.weight_kg < this.weight_kg) return -1;
                else return 1;
            }
            public LeftProduct(string w, string n)
            {
                weight_of_product = w;
                name_of_product = n;
                try
                {
                    weight_kg = SafeConvertionWeight(w);
                }
                
                catch (ArgumentOutOfRangeException)
                {
                    throw new ArgumentOutOfRangeException();
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException();
                }
            }
            public override string ToString()
            {
                return weight_kg.ToString() + "\t" + weight_of_product + "\t" + name_of_product;
            }
        }
        static double SafeConvertionWeight(string s)
        {
            double res;
            if (s.Length < 2)
                throw new ArgumentException();
            else
            {
                string dim = "  "; //dimension
                double mul_num = 0;
                if (s.Contains("г"))
                    dim = "г";
                if (s.Contains("кг"))
                    dim = "кг";
                if (s.Contains("л"))
                    dim = "л";
                if (s.Contains("т"))
                    dim = "т";

                switch (dim)
                {
                    case "кг": mul_num = 1; break;
                    case "г": mul_num = 0.001; break;
                    case "л": mul_num = 1; break;
                    case "т": mul_num = 1000; break;
                }
                if (mul_num == 0)
                    throw new ArgumentException();
                else
                    s = s.Replace(dim, "");

                if (double.TryParse(s, out res))
                {
                    if (res < 0)
                        throw new ArgumentOutOfRangeException();
                    else
                        return res * mul_num;
                }
                else
                    throw new ArgumentException();
            }
        }
        static void Main(string[] args)
        {
            string read_file;
            List<LeftProduct> list_of_products = new List<LeftProduct>();
            StreamReader f = new StreamReader("C:\\Users\\Игорь\\Desktop\\лабы по c#\\products.txt");
            while ((read_file = f.ReadLine()) != null)
            {
                string weight = "";
                string name = "";

                int index = read_file.IndexOf(' ');
                if (index > 0)
                {
                    weight = read_file.Substring(0, index);
                    name = read_file.Replace(weight, "");
                    try
                    {
                        LeftProduct l = new LeftProduct(weight, name);
                        list_of_products.Add(l);
                        Console.WriteLine(l.ToString());
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("ERROR: Inputed weight less then 0.");
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("ERROR: Inputed string is not a weight.");
                    }
                }
            }
            f.Close();

            Console.WriteLine("\nSorted:");
            list_of_products.Sort();
            for (int i = 0; i< list_of_products.Count;i++)
                Console.WriteLine(list_of_products[i].ToString());

            Console.ReadLine();
        }
    }
}

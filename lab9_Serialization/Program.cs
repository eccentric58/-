using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace lab3_classes
{
    class Client
    {
        protected string name, addres;
        protected int diskont;
        public Client(string n, string a) 
        {
            name = n;
            addres = a;
            Random r = new Random();
            diskont = r.Next(1,20);
        }
        public int Discont
        {
            get { return diskont; }
        }
        public string Name
        {
            get { return name; }
        }
        public string Addres
        {
            get { return addres; }
        }
    }
    class Product
    {
        private string name;
        private decimal cost;
        public Product(string n, decimal c)
        {
            name = n;
            cost = c;
        }
        public string Name  
        {
            get { return name; }
            set { name = value; }
        }
        public decimal Cost
        {
            get { return cost; }
            set { cost = value; }
        }
    }
    class ProductBase
    {
        static int globalNum = 1;
        protected Dictionary<int, Product> dict = new Dictionary<int, Product>();
        public ProductBase() { }
        public Dictionary<int, Product> Base
        {
            get { return dict; }
            set { dict = value; }
        }
        public void addProduct(Product p)
        {
            dict.Add(globalNum, p);
            globalNum++;
        }
        public Product getProduct(int code)
        {
            return dict[code];
        }
        public int maxCode()
        {
            return globalNum - 1;
        }
        public string ToString()
        {
            string result = "";
            for (int i = 0; i<dict.Count;i++)
                result += $"{i+1} - {dict[i+1].Name}:\t{dict[i+1].Cost}\n";
            return result;
        }
    }
    class OrderLine
    {
        private int num;
        private Product prod;
        public OrderLine(int n, Product p)
        {
            num = n;
            prod = p;
        }
        public int Num
        {
            get { return num; }
        }
        public Product Prod
        {
            get { return prod; }
        }
    }
    class Order
    {
        static int globalNum = 1;
        protected int num;
        protected Client client;
        protected double diskont;
        protected decimal all_cost = 0;
        protected List<OrderLine> order_lines = new List<OrderLine>();
        public Order(Client c)
        {
            num = globalNum;
            globalNum++;
            client = c;
            diskont = c.Discont;
        }
        public void addOrderLine(OrderLine l)
        {
            order_lines.Add(l);
            all_cost += l.Num * l.Prod.Cost * (100 - client.Discont ) / 100;
        }
        public int Num
        {
            get { return num; }
        }
        public Client Customer
        {
            get { return client; }
        }
        public double Diskont
        {
            get { return diskont; }
        }
        public List<OrderLine> OrderList
        {
            get { return order_lines; }
        }
        public decimal allCost
        {
            get { return all_cost; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ProductBase Base = new ProductBase();
            Base.addProduct(new Product("Гречка", 56.5m));
            Base.addProduct(new Product("Молоко", 71.99m));
            Base.addProduct(new Product("Макароны", 40.0m));
            Base.addProduct(new Product("Хлеб", 39.99m));

            Console.Write("Создание клиента:\nВведите имя:\t");
            string name = Console.ReadLine();
            Console.Write("Введите адрес:\t");
            string address = Console.ReadLine();
            Client cl = new Client(name, address);
            Console.WriteLine($"Клиент создан. Ему присвоена скадка: {cl.Discont} %.");

            Order or = new Order(cl);
            Console.WriteLine("\nДобавьте в заказ продукт или завершиье заказ:");
            Console.WriteLine($"0 - Закончить\n{Base.ToString()}");
            Console.Write("Введите код:\t");
            int code = 0;
            int.TryParse(Console.ReadLine(), out code);
            while ((code != 0) && (code <= Base.maxCode())) 
            {
                Console.Write("Введите количество:\t");
                int num = 1;
                int.TryParse(Console.ReadLine(), out num);

                or.addOrderLine(new OrderLine(num, Base.getProduct(code)));
                Console.WriteLine("\nДобавьте в заказ продукт или завершите заказ:");
                Console.WriteLine($"0 - Закончить\n{Base.ToString()}");
                Console.Write("Введите код:\t");
                code = 0;
                int.TryParse(Console.ReadLine(), out code);
            }

            string json = JsonConvert.SerializeObject(or, Formatting.Indented);
            File.WriteAllText(@"C:\Users\Игорь\Desktop\лабы по c#\myJson.json", json);
            
            
            Console.WriteLine();
            json = JsonConvert.SerializeObject(Base);
            ProductBase Base2 = JsonConvert.DeserializeObject<ProductBase>(json);
            string json2 = JsonConvert.SerializeObject(Base2, Formatting.Indented);
            Console.WriteLine(json2);

            Console.ReadLine(); 
        }
    }
}


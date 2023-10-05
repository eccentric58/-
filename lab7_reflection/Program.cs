using System;
using System.Reflection;

namespace lab7_reflection
{
    public enum Animal
    {
        None = 0,
        Dog,
        Cat,
        Bird,
    }
    public class AnimalTypeAttribute : Attribute
    {
        protected Animal thePet;
        public AnimalTypeAttribute(Animal pet) { thePet = pet; }
        public Animal Pet
        {
            get { return thePet; }
            set { thePet = value; }
        }
    }

    class AnimalClass
    {
        public string animal_name;
        public AnimalTypeAttribute animal_type;
        public AnimalClass() 
        { 
            animal_name = "-"; 
            animal_type = new AnimalTypeAttribute(Animal.None); 
        }
        public AnimalClass(string name, Animal type) 
        { 
            animal_name = name; 
            animal_type = new AnimalTypeAttribute(type); 
        }
        public string getInfoAboutAnimal() 
        { 
            return animal_type.Pet.ToString() + ": " + animal_name; 
        }
    }
    class Program
    {
        static void Main()
        {
            AnimalClass testClass = new AnimalClass("Kitty", Animal.Cat);

            Console.WriteLine("\n Имя класса:" + testClass.GetType().Name);
            Console.WriteLine("\n Полное имя класса:" + testClass.GetType().FullName);

            Console.WriteLine("\n Конструкторы:");
            foreach (var m in testClass.GetType().GetConstructors())
            {
                Console.WriteLine(m);
            }

            Console.WriteLine("\n Все поля:");
            foreach (var m in testClass.GetType().GetFields())
            {
                Console.WriteLine(m);
            }

            Console.WriteLine("\n Методы:");
            foreach (var m in testClass.GetType().GetMethods())
            {
                Console.WriteLine(m);
            }

            Console.WriteLine("\n Поле типа Attribute:");
            foreach (var m in testClass.GetType().GetFields())
            {
                if (m.FieldType.FullName == typeof(AnimalTypeAttribute).FullName)
                    Console.WriteLine(m);
            }

            Console.WriteLine("\n Вызван метод getAnimalName() через рефлексию :");
            Console.WriteLine(typeof(AnimalClass).GetMethods()[0].Invoke(testClass, null));

            Console.ReadLine();
        }
    }
}
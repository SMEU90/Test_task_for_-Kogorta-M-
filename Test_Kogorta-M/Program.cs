using System;
using System.Collections.Generic;

namespace Test_Kogorta_M
{
    class Human
    { 
        private List<Human> list = new List<Human>();
        private string Name { get; set; }
        public Human()
        {
            bool flag = true;
            do
            {
                flag = false;
                Console.Clear();
                Console.WriteLine("Введите имя человека");
                Name = Console.ReadLine();
                if(Name=="")
                {
                    flag = true;
                    Console.WriteLine("Ошибка! Вы не указали имя человека");
                    Console.ReadKey();
                }
            } while (flag);
        }
        public void DisplayName()
        {
            Console.WriteLine(Name);
        }
        public void Display()
        {   
            Console.Write($"Родитель: {Name}\n");
            if(list.Count!=0)
            Console.WriteLine("Дети: ");
            for(int i=0;i<list.Count;i++)
            {
                list[i].DisplayName();
            }
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Display();
            }
        }
        public void AddChildren() // add child 
        {
            if (list.Count != 3)
            {
                list.Add(new Human());
            }
            else
            {
                Console.WriteLine("Ошибка! У данного родителя уже есть 3 ребенка");
                Console.ReadKey();
            }
        }
        public void Add() // method for the process of adding a child 
        {
            DisplayName();
            if(Console.ReadLine()=="1")
            {
                AddChildren();
                return;
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Add();
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Human user = new Human();
            bool flag = true;
            byte menu = 0;
            while(flag)
            {
                Console.Clear();
                Console.WriteLine("1. Вывести список детей с родителем");
                Console.WriteLine("2. Пересоздать родителя");
                Console.WriteLine("3. Добавить ребенка к родителю");
                Console.WriteLine("4. Выход");
                Console.WriteLine("\nВыберите пункт меню");
                try
                {
                    menu = Byte.Parse(Console.ReadLine());
                    if (menu > 4 || menu < 1)
                    {
                        Console.WriteLine("Ошибка! Введены некорректные данные");
                        Console.ReadKey();
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибка! Введены некорректные данные");
                    Console.ReadKey();
                }

                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        GetChildren(user);
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        user = new Human();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Нажмите 1 если хотите добавить ребенка к данному родителю, иначе другую клавишу");
                        user.Add();
                        break;
                    case 4:
                        flag = false;
                        break;
                }
            }
        }
        public static void GetChildren(Human parent)
        {
            parent.Display();
        }
    }
}


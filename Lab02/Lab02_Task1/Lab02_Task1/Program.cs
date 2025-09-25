// See https://aka.ms/new-console-template for more information

using System;

internal class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Лабораторная работа №2. Выполнил студент Чиканков Михаил.");
            Console.Write("Выберите задачу: \n\n1. Таблица значений функции\n2. Серия выстрелов по мишени\n3. Сумма ряда\n4. Выход");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    Task1();
                    return;
                case 2:
                    Task2();
                    return;
                case 3:
                    Task3();
                    return;
                case 4:
                    return;
                default:
                    Console.WriteLine("Введите другой номер");
                    return;
            }
        }
    }

    static void Task1()
    {
        Console.WriteLine("\n\nЗадание 1");
        double xmin, xmax, dx, y;
        Console.Write("Введите Xmin: ");
        xmin = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите Xmax: ");
        xmax = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите Dx: ");
        dx = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("\tx\t\ty");
        for (double x = xmin; x <= xmax; x += dx)
        {
            if (x >= -7 && x <= 3) {
                if (x < -6)
                {
                    y = 2;
                } else if (x < -2)
                {
                    y = x / 4 + 0.5;
                } else if (x < 0)
                {
                    y = Math.Sqrt(4 - Math.Pow(x+2, 2))-2;
                } else if (x < 2) 
                {
                    y = Math.Sqrt(4-Math.Pow(x, 2));
                } else
                {
                    y = -x + 2;
                }
                Console.WriteLine("\t{0,10:0.00}\t\t{1,16:0.00}", x, y);
            } else
            {
                Console.WriteLine("\t{0,10:0.00}\t\tНе определена", x);
            }
        }
    }

    static void Task2()
    {
        Console.WriteLine("\nЗадание 2");
        while (true)
        {
            Console.Write("Хотите ли вы сделать выстрел? (Да, Нет): ");
            string shoot = Console.ReadLine();
            switch (shoot)
            {
                case "Да":
                    Console.Write("Введите X: ");
                    double x = Convert.ToDouble(Console.ReadLine());
        
                    Console.Write("Введите Y: ");
                    double y = Convert.ToDouble(Console.ReadLine());
        
                    double parabola = Math.Pow(x - 2, 2) - 3;
        
                    bool hit = false;
        
                    if (y >= 0 && x >= y && y >= parabola)
                    {
                        hit = true;
                    }
                    else if (y >= parabola && x <= -y && x >= 0)
                    {
                        hit = true;
                    }

                    if (hit)
                    {
                        Console.WriteLine("Попал");
                    }
                    else
                    {
                        Console.WriteLine("Не попал");
                    }
                    break;
                case "Нет":
                    return;
                default:
                    Console.WriteLine("Введите \"Да\" или \"Нет\"");
                    continue;
            }
        }
    }

    static void Task3()
    {
        Console.WriteLine("В разработке");
    }
}
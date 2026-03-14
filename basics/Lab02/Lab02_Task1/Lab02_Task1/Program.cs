using System;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Лабораторная работа №2. Выполнил студент Чиканков Михаил.");
        while (true)
        {
            Console.Write("Выберите задачу: \n\n1. Таблица значений функции\n2. Серия выстрелов по мишени\n3. Сумма ряда\n4. Выход\n");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    Task1();
                    continue;
                case 2:
                    Task2();
                    continue;
                case 3:
                    Task3();
                    continue;
                case 4:
                    return;
                default:
                    Console.WriteLine("Введите другой номер");
                    continue;
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
        Console.WriteLine("\tx\t\ty\n");
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
                Console.WriteLine("{0,10:0.00}{1,16:0.00}", x, y);
            } else
            {
                Console.WriteLine("{0,10:0.00}{1,16}", x, "Не определена");
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
        Console.WriteLine("\nЗадание 3");

        Console.Write("Введите x (x > 1): ");
        double x = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Введите точность: ");
        double epsilon = Convert.ToDouble(Console.ReadLine());

        if (x <= 1 || epsilon <= 0)
        {
            Console.WriteLine("Ошибка: x должен быть больше 1, а точность положительной"); 
            return;
        }

        double sum = Math.PI / 2;
        int n = 0;
        double term = Math.Pow(-1, n + 1) / ((2 * n + 1) * Math.Pow(x, 2 * n + 1));
        
        while (Math.Abs(term) > epsilon)
        {
            sum += term;
            n++;
            term = Math.Pow(-1, n + 1) / ((2 * n + 1) * Math.Pow(x, 2 * n + 1));
        }
        
        double exactValue = Math.Atan(x);
        
        Console.WriteLine("\nТочное значение arctg(x): {0}", exactValue);
        Console.WriteLine("Сумма ряда: {0}", sum);
        Console.WriteLine("Количество членов: {0}", n + 1);
    }
}
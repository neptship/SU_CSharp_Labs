using System;
namespace Lab04;

internal class Program
{

    public static void Main(string[] args)
    {
        Console.WriteLine("Лабораторная работа №4. Выполнил студент Чиканков Михаил.");
        while (true)
        {
            Console.Write("\nВыберите задачу:\n1. Десятичный счетчик\n2. Многочлен\n3. Выход\n\nВаш выбор: ");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Введите другой номер");
                    break;
            }
        }
    }

    static void Task1()
    {
        Console.Write("Минимум: ");
        int min = Convert.ToInt32(Console.ReadLine());

        Console.Write("Максимум: ");
        int max = Convert.ToInt32(Console.ReadLine());

        Console.Write("Начальное: ");
        int start = Convert.ToInt32(Console.ReadLine());


        var c = new Counter(min, max, start);
        Console.WriteLine("Задание №1");
        while (true)
        {
            Console.Write("\nВыберите задачу:\n1. Уменьшить\n2. Увеличить\n3. Показать значение\n4. Выход\n\nВаш выбор: ");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    c.Dec();
                    break;
                case 2:
                    c.Inc();
                    break;
                case 3:
                    Console.WriteLine(c.Get());
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Введите другой номер");
                    break;
            }
        }
    }

    static void Task2()
    {
        Console.Write("Введите a: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите b: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите c: ");
        double c = Convert.ToDouble(Console.ReadLine());

        Polynomial p = new Polynomial(a, b, c);
        double[] roots = p.Roots();

        if (roots.Length == 0)
        {
            Console.WriteLine("Корней нет.");
        }
        else if (roots.Length == 1)
        {
            Console.WriteLine("Один корень: x = " + roots[0]);
        }
        else
        {
            Console.WriteLine("Два корня: x1 = " + roots[0] + ", x2 = " + roots[1]);
        }
    }
}
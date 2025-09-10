using System;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Введите значение X: ");
        int x = Convert.ToInt32(Console.ReadLine());
        double y = 0;
        bool defined = true;

        if (x >= -7 && x < -6)
        {
            y = 2;
        } else if (x >= -6 && x < -2)
        {
            y = x / 4 + 0.5;
        } else if (x >= -2 && x < 0)
        {
            y = Math.Sqrt(4 - Math.Pow(x+2, 2))-2;
        } else if (x >= 0 && x < 2)
        {
            y = Math.Sqrt(4-Math.Pow(x, 2));
        } else if (x >= 2 && x <= 3)
        {
            y = -x + 2;
        } else
        {
            defined = false;
        }

        if (defined)
        {
            Console.WriteLine("Значение функции в точке " + x + " равно: " + y);
        }
        else
        {
            Console.WriteLine("Функция не определена.");
        }
    }
}
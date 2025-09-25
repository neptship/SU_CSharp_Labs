using System;
using System.Reflection.Metadata;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Введите значение X: ");
        
        int x = Convert.ToInt32(Console.ReadLine());
        double y;
        if (x >= -7 && x <= 11)
        {
            if (x < -3)
            {
                y = 3;
            }
            else if ( x < 3)
            {
                y = -Math.Sqrt(9 - Math.Pow(x, 2)) + 3;
            }
            else if (x < 5)
            {
                y = -x * 2 + 9;
            }
            else
            {
                y = (x * 4) / 3 - 12;
            }
            Console.WriteLine("Значение функции в точке " + x + " равно: " + y);
        } else
        {
            Console.WriteLine("Функция не определена.");
        }
    }
}
using System;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Введите значение X: ");
        int x = Convert.ToInt32(Console.ReadLine());
        double y;
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
            Console.WriteLine("Значение функции в точке " + x + " равно: " + y);
        } else
        {
            Console.WriteLine("Функция не определена.");
        }
    }
}
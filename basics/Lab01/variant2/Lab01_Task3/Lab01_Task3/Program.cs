using System;

internal class Program
{
    public static void Main(string[] args)
    {
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
        
    }
}
using System;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Введите X: ");
        double x = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Введите Y: ");
        double y = Convert.ToDouble(Console.ReadLine());
        
        double circle = Math.Pow(x,2) + Math.Pow(y,2);
        
        bool hit = false;
        
        if (x*y >= 0 && circle <= 4)
        {
            hit = true;
        }
        else if (circle <= 4 && y >= x+2 && y >= 0 && x <= 0)
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
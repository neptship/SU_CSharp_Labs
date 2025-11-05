using System;
namespace Lab01_Task1;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Введите число a: ");
        
        int a = Convert.ToInt32(Console.ReadLine());

        var z1 = Math.Cos(a) + Math.Sin(a) + Math.Sin(3 * a) + Math.Cos(3 * a);
        var z2 = 2 * Math.Sqrt(2) * Math.Cos(a) * Math.Sin(Math.PI/4 + 2*a);
        
        Console.WriteLine("Решение через первую формулу: " + z1);
        Console.WriteLine("Решение через вторую формулу: " + z2);
    }
}
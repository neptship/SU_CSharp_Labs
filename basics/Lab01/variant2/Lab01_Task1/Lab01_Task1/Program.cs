using System;
namespace Lab01_Task1;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Введите число a: ");
        int a = Convert.ToInt32(Console.ReadLine());
        if (2*a + Math.Pow(a, 2) == 0 || 2*a-Math.Pow(a, 2) == 0)
        {
            Console.WriteLine("Нельзя делить на ноль");
        }
        else
        {
            double z1 = Math.Pow((1+a+Math.Pow(a, 2))/(2*a + Math.Pow(a, 2)) + 2 - (1-a+Math.Pow(a, 2))/(2*a-Math.Pow(a, 2)), -1) * (5 - 2 * Math.Pow(a, 2));
            Console.WriteLine("Решение через первую формулу: " + z1);
        }
        double z2 = (4 - Math.Pow(a, 2)) / 2;
        Console.WriteLine("Решение через вторую формулу: " + z2);
    }
}
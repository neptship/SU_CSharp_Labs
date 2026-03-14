using System;

namespace Lab05;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Лабораторная работа №5. Выполнил студент Чиканков Михаил.");
        
        Console.Write("Введите числитель первой дроби: ");  
        int num1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите знаменатель первой дроби: ");
        int den1 = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("\nВведите числитель второй дроби: ");  
        int num2 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите знаменатель второй дроби: ");
        int den2 = Convert.ToInt32(Console.ReadLine());

        Fraction fr1 = new Fraction();
        Fraction fr2 = new Fraction();
        
        fr1.Numerator = num1;
        fr1.Denominator = den1;
        
        fr2.Numerator = num2;
        fr2.Denominator = den2;
        
        Console.WriteLine("\nЗадание №1. Использование перегруженных операторов");
        
        Console.WriteLine("Сложение");
        Fraction f1 = fr1 + fr2;
        Console.WriteLine(f1.ToString());

        Console.WriteLine("Вычитание");
        Fraction f2 = fr1 - fr2;
        Console.WriteLine(f2.ToString());

        Console.WriteLine("Деление");
        Fraction f3 = fr1 / fr2;
        Console.WriteLine(f3.ToString());

        Console.WriteLine("Умножение");
        Fraction f4 = fr1 * fr2;
        Console.WriteLine(f4.ToString());

        Console.WriteLine("\nЗадание №2. Использование статических методов");

        Console.WriteLine("Сложение");
        Fraction f5 = StaticFraction.Add(fr1, fr2);
        Console.WriteLine(f5.ToString());

        Console.WriteLine("Вычитание");
        Fraction f6 = StaticFraction.Subtract(fr1, fr2);
        Console.WriteLine(f6.ToString());
        
        Console.WriteLine("Деление");
        Fraction f7 = StaticFraction.Divide(fr1, fr2);
        Console.WriteLine(f7.ToString());
        
        Console.WriteLine("Умножение");
        Fraction f8 = StaticFraction.Multiply(fr1, fr2);
        Console.WriteLine(f8.ToString());
    }
}
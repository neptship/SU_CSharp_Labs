using System;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Лабораторная работа №3. Выполнил студент Чиканков Михаил.");
        while (true)
        {
            Console.Write("\nВыберите задачу:\n1. Ввод и обработка матриц\n2. Перевод из двоичной системы счисления в десятичную\n3. Выход\n\nВаш выбор: ");
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
                    break;
                default:
                    Console.WriteLine("Введите другой номер");
                    break;
            }
        }
    }

    static void Task1()
    {
        Console.Write("\nВведите размер матрицы (n >= 2): ");
        int n = Convert.ToInt32(Console.ReadLine());

        while (n < 2)
        {
            Console.WriteLine("Размер матрицы не может быть меньше 2");
            Console.Write("\nВведите размер матрицы (n >= 2): ");
            n = Convert.ToInt32(Console.ReadLine());
        }
            
        
        int[,] mat1 = new int[n, n];
        int[,] mat2 = new int[n, n];
        
        Console.WriteLine("\nВведите первую матрицу построчно:");
        for (int i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine().Split(' ');
            while (parts.Length != n)
            {
                Console.WriteLine($"Ошибка: введите {n} элементов");
                parts = Console.ReadLine().Split(' ');
            }
            for (int j = 0; j < n; j++)
            {
                mat1[i, j] = Convert.ToInt32(parts[j]);
            }
        }

        Console.WriteLine("\nВведите вторую матрицу построчно:");
        for (int i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine().Split(' ');
            while (parts.Length != n)
            {
                Console.WriteLine($"Ошибка: введите {n} элементов");
                parts = Console.ReadLine().Split(' ');
            }
            for (int j = 0; j < n; j++)
            {
                mat2[i, j] = Convert.ToInt32(parts[j]);
            }
        }
        
        Console.WriteLine("\nПервая матрица:");
        PrintMatrix(mat1);
        
        Console.WriteLine("\nВторая матрица:");
        PrintMatrix(mat2);
        
        while (true)
        {
            Console.Write("\nВыберите операцию:\n1. Сложение\n2. Вычитание\n3. Умножение\n4. Умножить матрицы на число\n5. Сравнить\n6. Выход\n\nВаш выбор: ");
            int op = Convert.ToInt32(Console.ReadLine());
            
            switch (op)
            {
                case 1:
                    int[,] sum = Addition(mat1, mat2);
                    Console.WriteLine("\nРезультат сложения:");
                    PrintMatrix(sum);
                    break;
                    
                case 2:
                    int[,] diff = Subtract(mat1, mat2);
                    Console.WriteLine("\nРезультат вычитания:");
                    PrintMatrix(diff);
                    break;
                    
                case 3:
                    int[,] mult = Mult(mat1, mat2);
                    Console.WriteLine("\nРезультат умножения:");
                    PrintMatrix(mult);
                    break;
                    
                case 4:
                    Console.Write("\nВведите число: ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    int[,] result1 = MultNum(mat1, num);
                    Console.WriteLine($"\nРезультат умножения первой матрицы на {num}:");
                    PrintMatrix(result1);
                    int[,] result2 = MultNum(mat2, num);
                    Console.WriteLine($"\n\nРезультат умножения второй матрицы на {num}:");
                    PrintMatrix(result2);
                    break;
                    
                case 5:
                    if (Equal(mat1, mat2))
                    {
                        Console.WriteLine("\nМатрицы равны");
                    }
                    else
                    {
                        Console.WriteLine("\nМатрицы не равны");
                    }

                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Неверный выбор");
                    break;
            }
        }
    }

    static void Task2()
    {
        Console.Write("Введите число: ");
        int num = Convert.ToInt32(Console.ReadLine());
    
        while (num < 0)
        {
            Console.WriteLine("Число должно быть положительным");
            Console.Write("Введите число: ");
            num = Convert.ToInt32(Console.ReadLine());
        }
        
        int temp = num;
        string bin = "";
    
        while (temp > 0)
        {
            bin = temp % 2 + bin;
            temp = temp / 2;
        }
    
        if (num == 0)
        {
            bin = "0";
        }
    
        Console.WriteLine("\nДесятичное число: " + num);
        Console.WriteLine("Двоичное число: " + bin);
        
        while (bin.Length < 9)
        {
            bin = "0" + bin;
        }
    
        Console.WriteLine("Дополнено до 9 бит: " + bin);
        
        string triad1 = "";
        string triad2 = "";
        string triad3 = "";
        string extraBits = "";

        for (int i = 0; i < bin.Length; i++)
        {
            if (i < bin.Length - 9)
            {
                extraBits = extraBits + bin[i];
            }
            else if (i < 3 + (bin.Length - 9))
            {
                triad1 = triad1 + bin[i];
            }
            else if (i < 6 + (bin.Length - 9))
            {
                triad2 = triad2 + bin[i];
            }
            else
            {
                triad3 = triad3 + bin[i];
            }
        }
    
        string newBin = extraBits + triad3 + triad2 + triad1;
        
        int newNum = 0;
        int step = 1;
    
        for (int i = newBin.Length - 1; i >= 0; i--)
        {
            if (newBin[i] == '1')
            {
                newNum = newNum + step;
            }
            step = step * 2;
        }
    
        Console.WriteLine("\nПосле обмена первой и третьей триад:");
        Console.WriteLine("Двоичное: " + newBin);
        Console.WriteLine("Десятичное: " + newNum);
    }
    
    static void PrintMatrix(int[,] mat)
    {
        for (int i = 0; i < mat.GetLength(0); i++)
        {
            for (int j = 0; j < mat.GetLength(1); j++)
            {
                Console.Write(mat[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    
    static int[,] Addition(int[,] mat1, int[,] mat2)
    {
        int[,] res = new int[mat1.GetLength(0), mat1.GetLength(1)];
        for (int i = 0; i < mat1.GetLength(0); i++)
        {
            for (int j = 0; j < mat1.GetLength(1); j++)
            {
                res[i, j] = mat1[i, j] + mat2[i, j];
            }
        }
        return res;
    }
    
    static int[,] Subtract(int[,] mat1, int[,] mat2)
    {
        int[,] res = new int[mat1.GetLength(0), mat1.GetLength(1)];
        for (int i = 0; i < mat1.GetLength(0); i++)
        {
            for (int j = 0; j < mat1.GetLength(1); j++)
            {
                res[i, j] = mat1[i, j] - mat2[i, j];
            }
        }
        return res;
    }
    
    static int[,] Mult(int[,] mat1, int[,] mat2)
    {
        int[,] res = new int[mat1.GetLength(0), mat1.GetLength(1)];
        for (int i = 0; i < mat1.GetLength(0); i++)
        {
            for (int j = 0; j < mat1.GetLength(1); j++)
            {
                res[i, j] = 0;
                for (int k = 0; k < mat1.GetLength(0); k++)
                {
                    res[i, j] += mat1[i, k] * mat2[k, j];
                }
            }
        }
        return res;
    }
    
    static int[,] MultNum(int[,] mat, int num)
    {
        int[,] res = new int[mat.GetLength(0), mat.GetLength(1)];
        for (int i = 0; i < mat.GetLength(0); i++)
        {
            for (int j = 0; j < mat.GetLength(1); j++)
            {
                res[i, j] = mat[i, j] * num;
            }
        }
        return res;
    }
    
    static bool Equal(int[,] mat1, int[,] mat2)
    {
        for (int i = 0; i < mat1.GetLength(0); i++)
        {
            for (int j = 0; j < mat1.GetLength(1); j++)
            {
                if (mat1[i, j] != mat2[i, j])
                {
                    return false;
                }
            }
        }
        return true;
    }
}
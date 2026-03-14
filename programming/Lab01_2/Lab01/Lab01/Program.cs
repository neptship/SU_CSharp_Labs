using System;

namespace Lab01;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Лабораторная работа №1. Выполнил студент Чиканков Михаил.");
        while (true) {
            try
            {
                Console.Write("Введите размер вектора 1: ");
                int n1 = Convert.ToInt32(Console.ReadLine());
                ArrayVector vec1;
                if (n1 > 0)
                {
                    vec1 = new ArrayVector(n1);
                }
                else
                {
                    vec1 = new ArrayVector();
                }

                Console.Write("Введите размер вектора 2: ");
                int n2 = Convert.ToInt32(Console.ReadLine());
                ArrayVector vec2 = new ArrayVector(n2);

                while (true)
                {
                    Console.WriteLine("\nМеню:\n1 - Заполнить вектор\n2 - Вывести вектор\n3 - Норма вектора\n4 - Сумма положительных элементов с четным индексом\n5 - Сумма элементов меньше среднего с нечетным индексом\n6 - Произведение четных положительных элементов\n7 - Произведение нечетных элементов не делящихся на 3\n8 - Сортировка по возрастанию\n9 - Сортировка по убыванию\n10 - Сумма векторов\n11 - Скалярное произведение\n12 - Умножение вектора на число\n13 - Получить/установить элемент\n0 - Выход");

                    string choice = Console.ReadLine();
                    try
                    {
                        switch (choice)
                        {
                            case "1":
                                Console.Write("Выберите вектор (1 или 2): ");
                                int numChoose = Convert.ToInt32(Console.ReadLine());
                                switch (numChoose)
                                {
                                    case 1:
                                        FillVector(vec1);
                                        break;
                                    case 2:
                                        FillVector(vec2);
                                        break;
                                    default:
                                        throw new ArgumentException("Неверно указан вектор");
                                }
                                break;
                            case "2":
                                Console.Write("Выберите вектор для вывода (1 или 2): ");
                                numChoose = Convert.ToInt32(Console.ReadLine());
                                switch (numChoose)
                                {
                                    case 1:
                                        vec1.Print();
                                        break;
                                    case 2:
                                        vec2.Print();
                                        break;
                                    default:
                                        throw new ArgumentException("Неверно указан вектор");
                                }
                                break;
                            case "3":
                                Console.Write("Выберите вектор для нормы (1 или 2): ");
                                numChoose = Convert.ToInt32(Console.ReadLine());
                                switch (numChoose)
                                {
                                    case 1:
                                        Console.WriteLine("Норма вектора 1 = {0}", vec1.GetNorm());
                                        break;
                                    case 2:
                                        Console.WriteLine("Норма вектора 2 = {0}", vec2.GetNorm());
                                        break;
                                    default:
                                        throw new ArgumentException("Неверно указан вектор");
                                }
                                break;
                            case "4":
                                Console.Write("Выберите вектор (1 или 2): ");
                                numChoose = Convert.ToInt32(Console.ReadLine());
                                switch (numChoose)
                                {
                                    case 1:
                                        Console.WriteLine("Сумма положительных элементов с четными индексами = {0}", vec1.SumPositivesFromChetIndex());
                                        break;
                                    case 2:
                                        Console.WriteLine("Сумма положительных элементов с четными индексами = {0}", vec2.SumPositivesFromChetIndex());
                                        break;
                                    default:
                                        throw new ArgumentException("Неверно указан вектор");
                                }
                                break;
                            case "5":
                                Console.Write("Выберите вектор (1 или 2): ");
                                numChoose = Convert.ToInt32(Console.ReadLine());
                                switch (numChoose)
                                {
                                    case 1:
                                        Console.WriteLine("Сумма элементов меньше среднего с нечетным индексом = {0}", vec1.SumLessFromNechetIndex());
                                        break;
                                    case 2:
                                        Console.WriteLine("Сумма элементов меньше среднего с нечетным индексом = {0}", vec2.SumLessFromNechetIndex());
                                        break;
                                    default:
                                        throw new ArgumentException("Неверно указан вектор");
                                }
                                break;
                            case "6":
                                Console.Write("Выберите вектор (1 или 2): ");
                                numChoose = Convert.ToInt32(Console.ReadLine());
                                switch (numChoose)
                                {
                                    case 1:
                                        Console.WriteLine("Произведение четных положительных элементов = {0}", vec1.MultChet());
                                        break;
                                    case 2:
                                        Console.WriteLine("Произведение четных положительных элементов = {0}", vec2.MultChet());
                                        break;
                                    default:
                                        throw new ArgumentException("Неверно указан вектор");
                                }
                                break;
                            case "7":
                                Console.WriteLine("Выберите вектор (1 или 2)");
                                numChoose = Convert.ToInt32(Console.ReadLine());
                                switch (numChoose)
                                {
                                    case 1:
                                        Console.WriteLine("Произведение нечетных не делящихся на 3 = {0}", vec1.MultNechet());
                                        break;
                                    case 2:
                                        Console.WriteLine("Произведение нечетных не делящихся на 3 = {0}", vec2.MultNechet());
                                        break;
                                    default:
                                        throw new ArgumentException("Неверно указан вектор");
                                }
                                break;
                            case "8":
                                Console.WriteLine("Выберите вектор для сортировки по возрастанию (1 или 2)");
                                numChoose = Convert.ToInt32(Console.ReadLine());
                                switch (numChoose)
                                {
                                    case 1:
                                        vec1.SortUp();
                                        Console.Write("Отсортирован: ");
                                        vec1.Print();
                                        break;
                                    case 2:
                                        vec2.SortUp();
                                        Console.Write("Отсортирован: ");
                                        vec2.Print();
                                        break;
                                    default:
                                        throw new ArgumentException("Неверно указан вектор");
                                }
                                break;
                            case "9":
                                Console.WriteLine("Выберите вектор для сортировки по убыванию (1 или 2)");
                                numChoose = Convert.ToInt32(Console.ReadLine());
                                switch (numChoose)
                                {
                                    case 1:
                                        vec1.SortDown();
                                        Console.Write("Отсортирован: ");
                                        vec1.Print();
                                        break;
                                    case 2:
                                        vec2.SortDown();
                                        Console.Write("Отсортирован: ");
                                        vec2.Print();
                                        break;
                                    default:
                                        throw new ArgumentException("Неверно указан вектор");
                                }
                                break;
                            case "10":
                                ArrayVector sumVec = Vectors.SumSt(vec1, vec2);
                                Console.Write("Сумма векторов: ");
                                sumVec.Print();
                                break;
                            case "11":
                                Console.WriteLine("Скалярное произведение = {0}", Vectors.ScalarSt(vec1, vec2));
                                break;
                            case "12":
                                Console.WriteLine("Выберите вектор (1 или 2)");
                                numChoose = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Введите число: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                ArrayVector multRes;
                                switch (numChoose)
                                {
                                    case 1:
                                        multRes = Vectors.MultNumberSt(vec1, num);
                                        break;
                                    case 2:
                                        multRes = Vectors.MultNumberSt(vec2, num);
                                        break;
                                    default:
                                        throw new ArgumentException("Неверно указан вектор");
                                }
                                Console.Write("Результат: ");
                                multRes.Print();
                                break;
                            case "13":
                                Console.WriteLine("Выберите вектор (1 или 2)");
                                numChoose = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Введите индекс: ");
                                int idx = Convert.ToInt32(Console.ReadLine());
                                switch (numChoose)
                                {
                                    case 1:
                                        Console.WriteLine("Значение = {0}", vec1.GetElement(idx));
                                        Console.Write("Новое значение: ");
                                        vec1.SetElement(idx, Convert.ToInt32(Console.ReadLine()));
                                        break;
                                    case 2:
                                        Console.WriteLine("Значение = {0}", vec2.GetElement(idx));
                                        Console.Write("Новое значение: ");
                                        vec2.SetElement(idx, Convert.ToInt32(Console.ReadLine()));
                                        break;
                                    default:
                                        throw new ArgumentException("Неверно указан вектор");
                                }
                                break;
                            case "0":
                                return;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    static void FillVector(ArrayVector vec)
    {
        for (int i = 0; i < vec.GetLength(); i++)
        {
            Console.WriteLine("Введите значение элемента:");
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                vec.SetElement(i, value);
            }
            else
            {
                Console.WriteLine("Значение некорректно, будет записан 0");
                vec.SetElement(i, 0);
            }
        }
    }
}
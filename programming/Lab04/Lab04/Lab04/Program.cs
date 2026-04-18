using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab04;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Лабораторная работа №4. Выполнил студент Чиканков Михаил.");
        while (true)
        {
            try
            {
                Console.WriteLine("\nМеню:\n1 - ArrayVector\n2 - LinkedListVector\n3 - Сложить векторы разных типов\n4 - Массив векторов\n0 - Выход");
                
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ArrayVectorMenu();
                        break;
                    case "2":
                        LinkedListVectorMenu();
                        break;
                    case "3":
                        MixedSumMenu();
                        break;
                    case "4":
                        VectorArrayMenu();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Некорректный пункт меню.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    static void MixedSumMenu()
    {
        try
        {
            Console.Write("Введите размер ArrayVector: ");
            int n1 = Convert.ToInt32(Console.ReadLine());
            ArrayVector av;
            if (n1 > 0)
            {
                av = new ArrayVector(n1);
            }
            else
            {
                av = new ArrayVector();
            }

            Console.Write("Введите размер LinkedListVector: ");
            int n2 = Convert.ToInt32(Console.ReadLine());
            LinkedListVector llv;
            if (n2 > 0)
            {
                llv = new LinkedListVector(n2);
            }
            else
            {
                llv = new LinkedListVector();
            }

            Console.WriteLine("Заполните ArrayVector:");
            FillVector(av);
            Console.WriteLine("Заполните LinkedListVector:");
            FillListVector(llv);

            Console.WriteLine("ArrayVector:       " + av.ToString());
            Console.WriteLine("LinkedListVector:  " + llv.ToString());

            IVectorable sum = Vectors.SumSt(av, llv);
            Console.WriteLine("Сумма векторов:    " + sum.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static void ArrayVectorMenu()
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
        ArrayVector vec2;
        if (n2 > 0)
        {
            vec2 = new ArrayVector(n2);
        }
        else
        {
            vec2 = new ArrayVector();
        }

        while (true)
        {
            Console.WriteLine("\nМеню:\n1 - Заполнить вектор\n2 - Вывести вектор\n3 - Норма вектора\n4 - Длина вектора\n5 - Получить/установить элемент\n6 - Сумма векторов\n7 - Скалярное произведение\n8 - Норма вектора (static)\n0 - Назад");

            string choice = Console.ReadLine();
            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Выберите вектор (1/2): ");
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
                        Console.Write("Выберите вектор для вывода (1/2): ");
                        numChoose = Convert.ToInt32(Console.ReadLine());
                        switch (numChoose)
                        {
                            case 1:
                                Console.WriteLine(vec1.ToString());
                                break;
                            case 2:
                                Console.WriteLine(vec2.ToString());
                                break;
                            default:
                                throw new ArgumentException("Неверно указан вектор");
                        }
                        break;
                    case "3":
                        Console.Write("Выберите вектор для нормы (1/2): ");
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
                        Console.Write("Выберите вектор (1/2): ");
                        numChoose = Convert.ToInt32(Console.ReadLine());
                        switch (numChoose)
                        {
                            case 1:
                                Console.WriteLine("Длина вектора 1 = {0}", vec1.Length);
                                break;
                            case 2:
                                Console.WriteLine("Длина вектора 2 = {0}", vec2.Length);
                                break;
                            default:
                                throw new ArgumentException("Неверно указан вектор");
                        }
                        break;
                    case "5":
                        Console.Write("Выберите вектор (1/2): ");
                        numChoose = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите индекс: ");
                        int idx = Convert.ToInt32(Console.ReadLine());
                        switch (numChoose)
                        {
                            case 1:
                                Console.WriteLine("Значение = {0}", vec1[idx]);
                                Console.Write("Новое значение: ");
                                vec1[idx] = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 2:
                                Console.WriteLine("Значение = {0}", vec2[idx]);
                                Console.Write("Новое значение: ");
                                vec2[idx] = Convert.ToInt32(Console.ReadLine());
                                break;
                            default:
                                throw new ArgumentException("Неверно указан вектор");
                        }
                        break;
                    case "6":
                        IVectorable sumVec = Vectors.SumSt(vec1, vec2);
                        Console.WriteLine("Сумма векторов: " + sumVec.ToString());
                        break;
                    case "7":
                        Console.WriteLine("Скалярное произведение = {0}", Vectors.ScalarSt(vec1, vec2));
                        break;
                    case "8":
                        Console.Write("Выберите вектор (1/2): ");
                        numChoose = Convert.ToInt32(Console.ReadLine());
                        switch (numChoose)
                        {
                            case 1:
                                Console.WriteLine("Норма вектора 1 = {0}", Vectors.GetNormSt(vec1));
                                break;
                            case 2:
                                Console.WriteLine("Норма вектора 2 = {0}", Vectors.GetNormSt(vec2));
                                break;
                            default:
                                throw new ArgumentException("Неверно указан вектор");
                        }
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Некорректный пункт меню.");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    static void LinkedListVectorMenu()
    {
        Console.Write("Введите размер LinkedListVector: ");
        int n = Convert.ToInt32(Console.ReadLine());
        LinkedListVector llVec;
        if (n > 0)
        {
            llVec = new LinkedListVector(n);
        }
        else
        {
            llVec = new LinkedListVector();
        }

        while (true)
        {
            Console.WriteLine("\nМеню:\n1  - Заполнить вектор\n2  - Вывести вектор\n3  - Норма вектора\n4  - Длина вектора\n5  - Получить/установить элемент\n6  - Добавить элемент в конец\n7  - Добавить элемент в начало\n8  - Добавить элемент в заданную позицию\n9  - Удалить элемент из конца\n10 - Удалить элемент из начала\n11 - Удалить элемент из заданной позиции\n0  - Назад");

            string choice = Console.ReadLine();
            try
            {
                switch (choice)
                {
                    case "1":
                        FillListVector(llVec);
                        break;
                    case "2":
                        Console.WriteLine(llVec.ToString());
                        break;
                    case "3":
                        Console.WriteLine("Норма = {0}", llVec.GetNorm());
                        break;
                    case "4":
                        Console.WriteLine("Длина = {0}", llVec.Length);
                        break;
                    case "5":
                        Console.Write("Введите позицию: ");
                        int pos = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Значение = {0}", llVec[pos]);
                        Console.Write("Новое значение: ");
                        llVec[pos] = Convert.ToInt32(Console.ReadLine());
                        break;
                    case "6":
                        Console.Write("Введите значение: ");
                        llVec.AddToEnd(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Элемент добавлен в конец.");
                        break;
                    case "7":
                        Console.Write("Введите значение: ");
                        llVec.AddToBeginning(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Элемент добавлен в начало.");
                        break;
                    case "8":
                        Console.Write("Введите позицию: ");
                        int addPos = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите значение: ");
                        int addVal = Convert.ToInt32(Console.ReadLine());
                        llVec.AddAtPosition(addPos, addVal);
                        Console.WriteLine("Элемент добавлен на позицию {0}.", addPos);
                        break;
                    case "9":
                        Console.WriteLine("Удалён элемент из конца: {0}", llVec.RemoveFromEnd());
                        break;
                    case "10":
                        Console.WriteLine("Удалён элемент из начала: {0}", llVec.RemoveFromBeginning());
                        break;
                    case "11":
                        Console.Write("Введите позицию: ");
                        int remPos = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Удалён элемент с позиции {0}: {1}", remPos, llVec.RemoveAtPosition(remPos));
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Некорректный пункт меню.");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    
    static void VectorArrayMenu()
    {
        Console.Write("Сколько векторов создать? ");
        if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
        {
            Console.WriteLine("Ошибка: некорректное количество векторов");
            return;
        }
        IVectorable[] vectors = new IVectorable[count];

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Вектор [{i}] тип (1=Array, 2=LinkedList): ");
            string typeChoice = Console.ReadLine();
            Console.Write("Размер: ");
            if (!int.TryParse(Console.ReadLine(), out int size))
            {
                Console.WriteLine("Ошибка: некорректный размер");
                vectors[i] = new ArrayVector();
                continue;
            }

            switch (typeChoice)
            {
                case "1":
                    if (size > 0)
                        vectors[i] = new ArrayVector(size);
                    else
                        vectors[i] = new ArrayVector();
                    break;
                case "2":
                    if (size > 0)
                        vectors[i] = new LinkedListVector(size);
                    else
                        vectors[i] = new LinkedListVector();
                    break;
                default:
                    Console.WriteLine("Некорректный тип, создан ArrayVector по умолчанию.");
                    vectors[i] = new ArrayVector();
                    break;
            }

            FillIVector(vectors[i]);
        }

        while (true)
        {
            Console.WriteLine("\nМеню:\n1 - Вывести векторы\n2 - Сравнение\n3 - Мин/макс по координатам\n4 - Сортировка по модулю\n5 - Клонировать вектор\n0 - Назад");

            string choice = Console.ReadLine();
            try
            {
                switch (choice)
                {
                    case "1":
                        for (int i = 0; i < vectors.Length; i++)
                            Console.WriteLine($"[{i}] {vectors[i]}");
                        break;
                    case "2":
                        Console.Write("Индекс первого вектора: ");
                        if (!int.TryParse(Console.ReadLine(), out int a))
                        {
                            Console.WriteLine("Ошибка: некорректный ввод индекса");
                            break;
                        }

                        Console.Write("Индекс второго вектора: ");
                        if (!int.TryParse(Console.ReadLine(), out int b))
                        {
                            Console.WriteLine("Ошибка: некорректный ввод индекса");
                            break;
                        }

                        if (a < 0 || a >= vectors.Length || b < 0 || b >= vectors.Length)
                        {
                            Console.WriteLine("Ошибка: индекс выходит за границы массива");
                            break;
                        }

                        if (vectors[a].Equals(vectors[b]))
                        {
                            Console.WriteLine("Векторы равны");
                        }
                        else
                        {
                            Console.WriteLine("Векторы не равны");
                        }
                        
                        break;
                    case "3":
                        IVectorable min = vectors[0];
                        IVectorable max = vectors[0];
                        List<IVectorable> minArr = new List<IVectorable>();
                        List<IVectorable> maxArr = new List<IVectorable>();
                        foreach (var v in vectors)
                        {
                            if (((IComparable)v).CompareTo(min) < 0)
                            {
                                minArr.Clear();
                                min = v;
                                minArr.Add(min);
                            } else if (((IComparable)v).CompareTo(min) == 0)
                            {
                                minArr.Add(v);
                            }

                            if (((IComparable)v).CompareTo(max) > 0)
                            {
                                maxArr.Clear();
                                max = v;
                                maxArr.Add(max);
                            } else if (((IComparable)v).CompareTo(max) == 0)
                            {
                                maxArr.Add(v);
                            }
                        }

                        Console.WriteLine("Мин по числу координат: ");
                        foreach (var v in minArr)
                        {
                            Console.WriteLine(v);
                        }
                        Console.WriteLine("Мин по числу координат: ");
                        foreach (var v in maxArr)
                        {
                            Console.WriteLine(v);
                        }
                        break;
                    case "4":
                        IVectorable[] sorted = (IVectorable[])vectors.Clone();
                        Array.Sort(sorted, new VectorNormComparer());
                        Console.WriteLine("По возрастанию модуля:");
                        for (int i = 0; i < sorted.Length; i++)
                            Console.WriteLine($"[{i}] норма={sorted[i].GetNorm():F4}  {sorted[i]}");
                        break;
                    case "5":
                        Console.Write("Индекс вектора: ");
                        if (!int.TryParse(Console.ReadLine(), out int idx))
                        {
                            Console.WriteLine("Ошибка: некорректный ввод индекса");
                            break;
                        }
                        if (idx < 0 || idx >= vectors.Length)
                        {
                            Console.WriteLine("Ошибка: индекс выходит за границы массива");
                            break;
                        }
                        
                        IVectorable original = vectors[idx];
                        IVectorable clone = (IVectorable)((ICloneable)original).Clone();

                        Console.WriteLine("Оригинал до изменения: " + original);

                        Console.Write("Изменить элемент оригинала, индекс: ");
                        if (!int.TryParse(Console.ReadLine(), out int editIdx))
                        {
                            Console.WriteLine("Ошибка: некорректный ввод индекса");
                            break;
                        }
                        Console.Write("Новое значение: ");
                        if (!int.TryParse(Console.ReadLine(), out int newValue))
                        {
                            Console.WriteLine("Ошибка: некорректное значение");
                            break;
                        }
                        clone[editIdx] = newValue;

                        Console.WriteLine("Оригинал после изменения: " + original);
                        Console.WriteLine("Клон после изменения: " + clone);
                        Console.WriteLine("Equals: " + original.Equals(clone));
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Некорректный пункт меню.");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    static void FillVector(ArrayVector vec)
    {
        for (int i = 0; i < vec.Length; i++)
        {
            Console.Write("a[{0}] = ", i);
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                vec[i] = value;
            }
            else
            {
                Console.WriteLine("Значение некорректно, будет записан 0");
                vec[i] = 0;
            }
        }
    }

    static void FillListVector(LinkedListVector vec)
    {
        for (int i = 0; i < vec.Length; i++)
        {
            Console.Write("a[{0}] = ", i);
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                vec[i] = value;
            }
            else
            {
                Console.WriteLine("Значение некорректно, будет записан 0");
                vec[i] = 0;
            }
        }
    }
    static void FillIVector(IVectorable vec)
    {
        for (int i = 0; i < vec.Length; i++)
        {
            Console.Write($"a[{i}] = ");
            if (int.TryParse(Console.ReadLine(), out int value))
                vec[i] = value;
            else
            {
                Console.WriteLine("Значение некорректно, будет записан 0");
                vec[i] = 0;
            }
        }
    }
}
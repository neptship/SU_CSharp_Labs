using System;

namespace Lab02;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Лабораторная работа №2. Выполнил студент Чиканков Михаил.");
        while (true) {
            try
            {
                Console.WriteLine("\nМеню:\n1 - ArrayVector\n2 - LinkedListVector\n0 - Выход");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ArrayVectorMenu();
                        break;
                    case "2":
                        LinkedListVectorMenu();
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
            Console.WriteLine("\nМеню:\n1 - Заполнить вектор\n2 - Вывести вектор\n3 - Норма вектора\n4 - Длина вектора\n5 - Получить/установить элемент\n6 - Сумма векторов\n7 - Скалярное произведение\n8 - Норма вектора\n0 - Назад");

            string choice = Console.ReadLine();
            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Выберите вектор: ");
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
                        Console.Write("Выберите вектор для вывода: ");
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
                        Console.Write("Выберите вектор для нормы: ");
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
                        Console.Write("Выберите вектор: ");
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
                        Console.Write("Выберите вектор: ");
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
                        ArrayVector sumVec = Vectors.SumSt(vec1, vec2);
                        Console.Write("Сумма векторов: ");
                        sumVec.Print();
                        break;
                    case "7":
                        Console.WriteLine("Скалярное произведение = {0}", Vectors.ScalarSt(vec1, vec2));
                        break;
                    case "8":
                        Console.Write("Выберите вектор: ");
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
                        llVec.Print();
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
            Console.WriteLine("Введите значение элемента:");
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
        for (int i = 1; i <= vec.Length; i++)
        {
            Console.WriteLine("Введите значение элемента:");
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
}
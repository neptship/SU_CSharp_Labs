using System;

namespace Lab06;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("Лабораторная работа №6. Выполнил студент Чиканков Михаил");
        Console.Write("Введите строку: ");
        string s = Console.ReadLine();
        StringLab str = new StringLab(s);
        while (true)
        {
            Console.Write("\nВыберите задачу:\n1. Подсчёт символов в строке\n2. Средняя длина слов в строке\n3. Является ли строка палиндромом\n4. Является ли строка датой\n5. Кол-во определённой подстроки в строке\n6. Замена в строке слова на заданное\n7. Вывести строку\n8. Выход\n\nВаш выбор: ");
            string num = Console.ReadLine();
            switch (num)
            {
                case "1":
                    Console.WriteLine(str.CountSymbols());
                    break;
                case "2":
                    Console.WriteLine(str.CountAverage());
                    break;
                case "3":
                    if (str.CheckIsPalindrom())
                    {
                        Console.WriteLine("Эта строка - палиндром");
                    }
                    else
                    {
                        Console.WriteLine("Эта строка не является палиндромом");
                    }
                    break;
                case "4":
                    if (str.CheckIsDate())
                    { 
                        Console.WriteLine("Да!");
                    }
                    else
                    {
                        Console.WriteLine("Нет");
                    }
                    break;
                case "5":
                    Console.Write("Введите подстроку: ");
                    string sub = Console.ReadLine();
                    Console.WriteLine("Количество вхождений данной подстроки: {0}", str.CountSubStr(sub));
                    break;
                case "6":
                    Console.Write("Введите слово которое хотите заменить: ");
                    string replacement_str = Console.ReadLine();
                    Console.Write("Введите слово на которое хотите заменить: ");
                    string replace_str = Console.ReadLine();
                    str.ReplaceWord(replacement_str, replace_str);
                    break;
                case "7":
                    Console.WriteLine(str.STR);
                    break;
                case "8":
                    return;
                default:
                    Console.WriteLine("Введите другой номер");
                    break;
            }
        }
    }
}
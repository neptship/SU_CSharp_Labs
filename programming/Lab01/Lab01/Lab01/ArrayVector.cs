using System;

namespace Lab01;

class ArrayVector
{
    private int[] arr;

    public ArrayVector()
    {
        arr = new int[5];
    }

    public ArrayVector(int length)
    {
        if (length <= 0)
        {
            throw new ArgumentException("Длина массива должна быть больше 0");
        }
        arr = new int[length];
    }

    public int GetLength()
    {
        return arr.Length;
    }

    public void SetElement(int index, int value)
    {
        if (index < 0 || index >= arr.Length)
        {
            throw new IndexOutOfRangeException("Индекс вне границ массива");
        }
        arr[index] = value;
    }

    public int GetElement(int index)
    {
        if (index < 0 || index >= arr.Length)
        {
            throw new IndexOutOfRangeException("Индекс вне границ массива");
        }
        return arr[index];
    }

    public double GetNorm()
    {
        double sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += (double)arr[i] * arr[i];
        }
        return Math.Sqrt(sum);
    }

    public int SumPositivesFromChetIndex()
    {
        int sum = 0;
        bool found = false;
        for (int i = 0; i < arr.Length; i++)
        {
            int userIndex = i + 1;
            if (userIndex % 2 == 0 && arr[i] > 0)
            {
                sum += arr[i];
                found = true;
            }
        }

        if (!found)
        {
            throw new Exception("Нет положительных элементов c четными номерами");
        }
        return sum;
    }

    public double SumLessFromNechetIndex()
    {
        double sumAbs = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sumAbs += Math.Abs(arr[i]);
        }
        double avg = sumAbs / arr.Length;

        double sum = 0;
        bool found = false;
        for (int i = 0; i < arr.Length; i++)
        {
            int userIndex = i + 1;
            if (userIndex % 2 != 0 && arr[i] < avg)
            {
                sum += arr[i];
                found = true;
            }
        }

        if (!found)
        {
            throw new Exception("Нет элементов, которые имеют нечетные номера и меньше среднего");
        }
        return sum;
    }

    public long MultChet()
    {
        long result = 1;
        bool found = false;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > 0 && arr[i] % 2 == 0)
            {
                result *= arr[i];
                found = true;
            }
        }
        if (!found)
        {
            throw new Exception("Нет четных положительных элементов");
        }
        return result;
    }

    public long MultNechet()
    {
        long result = 1;
        bool found = false;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % 2 != 0 && arr[i] % 3 != 0)
            {
                result *= arr[i];
                found = true;
            }
        }
        if (!found)
        {
            throw new Exception("Нет нечетных элементов, не делящихся на 3");
        }
        return result;
    }

    public void SortUp()
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - 1 - i; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int tmp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = tmp;
                }
            }
        }
    }

    public void SortDown()
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - 1 - i; j++)
            {
                if (arr[j] < arr[j + 1])
                {
                    int tmp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = tmp;
                }
            }
        }
    }

    public void Print()
    {
        Console.Write("[ ");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine("]");
    }
}
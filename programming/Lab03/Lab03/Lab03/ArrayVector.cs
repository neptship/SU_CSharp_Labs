using System;

namespace Lab03;

class ArrayVector : IVectorable
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

    public int Length
    {
        get { return arr.Length; }
    }

    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= arr.Length)
            {
                throw new IndexOutOfRangeException("Индекс вне границ массива");
            }
            return arr[index];
        }
        set
        {
            if (index < 0 || index >= arr.Length)
            {
                throw new IndexOutOfRangeException("Индекс вне границ массива");
            }
            arr[index] = value;
        }
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

    public void Print()
    {
        Console.Write("[ ");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine("]");
    }
    
    public override string ToString()
    {
        string result = Length.ToString();
        for (int i = 0; i < arr.Length; i++)
            result += " " + arr[i];
        return result;
    }
}
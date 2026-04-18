using System;

namespace Lab05;

[Serializable]
class ArrayVector : IVectorable, IComparable, ICloneable
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

    public int CompareTo(object? obj)
    {
        IVectorable other = obj as IVectorable;
        if (other == null)
        {
            throw new ArgumentException("Сравниваемый объект - null");
        }
        return this.Length.CompareTo(other.Length);
    }
    
    public override int GetHashCode()
    {
        return Length;
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false; 
        }
        if (this == obj)
        {
            return true;
        }
        if (obj is not IVectorable other)
        {
            return false;
        }
        if (this.GetHashCode() != obj.GetHashCode())
        {
            return false;
        }
        for (int i = 0; i < Length; i++)
        {
            if (this[i] != other[i])
            {
                return false;
            }
        }
        return true;
    }
    
    public object Clone()
    {
        ArrayVector copy = new ArrayVector(Length);
        for (int i = 0; i < Length; i++)
            copy[i] = this[i];
        return copy;
    }
}
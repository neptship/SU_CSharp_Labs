using System;

namespace Lab04;

class Vectors
{
    public static IVectorable SumSt(IVectorable a, IVectorable b)
    {
        if (a.Length != b.Length)
        {
            throw new FormatException("Длины векторов не совпадают");
        }

        IVectorable result;
        if (a is ArrayVector)
        {
            result = new ArrayVector(a.Length);
        }
        else
        {
            result = new LinkedListVector(a.Length);
        }
        for (int i = 0; i < a.Length; i++)
        {
            result[i] = a[i] + b[i];
        }
        return result;
    }

    public static int ScalarSt(IVectorable a, IVectorable b)
    {
        if (a.Length != b.Length)
        {
            throw new FormatException("Длины векторов не совпадают");
        }

        int result = 0;
        for (int i = 0; i < a.Length; i++)
        {
            result += a[i] * b[i];
        }
        return result;
    }

    public static double GetNormSt(ArrayVector a)
    {
        return a.GetNorm();
    }
}
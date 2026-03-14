using System;

namespace Lab02;

class Vectors
{
    public static ArrayVector SumSt(ArrayVector a, ArrayVector b)
    {
        if (a.Length != b.Length)
        {
            throw new FormatException("Длины векторов не совпадают");
        }

        ArrayVector result = new ArrayVector(a.Length);
        for (int i = 0; i < a.Length; i++)
        {
            result[i] = a[i] + b[i];
        }
        return result;
    }

    public static int ScalarSt(ArrayVector a, ArrayVector b)
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
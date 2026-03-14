using System;

namespace Lab01;

class Vectors
{
    public static ArrayVector SumSt(ArrayVector a, ArrayVector b)
    {
        if (a.GetLength() != b.GetLength())
        {
            throw new FormatException("Длины векторов не совпадают");
        }

        ArrayVector result = new ArrayVector(a.GetLength());
        for (int i = 0; i < a.GetLength(); i++)
        {
            result.SetElement(i, a.GetElement(i) + b.GetElement(i));
        }
        return result;
    }

    public static int ScalarSt(ArrayVector a, ArrayVector b)
    {
        if (a.GetLength() != b.GetLength())
        {
            throw new FormatException("Длины векторов не совпадают");
        }

        int result = 0;
        for (int i = 0; i < a.GetLength(); i++)
        {
            result += a.GetElement(i) * b.GetElement(i);
        }
        return result;
    }

    public static ArrayVector MultNumberSt(ArrayVector a, int number)
    {
        ArrayVector result = new ArrayVector(a.GetLength());
        for (int i = 0; i < a.GetLength(); i++)
        {
            result.SetElement(i, a.GetElement(i) * number);
        }
        return result;
    }

    public static double GetNormSt(ArrayVector a)
    {
        return a.GetNorm();
    }
}
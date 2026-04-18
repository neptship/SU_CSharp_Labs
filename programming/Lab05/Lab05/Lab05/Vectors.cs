using System;
using System.Numerics;

namespace Lab05;

[Serializable]
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

    public static void OutputVector(IVectorable v, Stream stream)
    {
        BinaryWriter writer = new BinaryWriter(stream);
        writer.Write(v.Length);
        for (int i = 0; i < v.Length; i++)
        {
            writer.Write(v[i]);
        }
        writer.Flush();
    }

    public static IVectorable InputVector(Stream stream)
    {
        BinaryReader reader = new BinaryReader(stream);
        int length = reader.ReadInt32();
        ArrayVector v = new ArrayVector(length);
        for (int i = 0; i < length; i++)
        {
            v[i] = reader.ReadInt32();
        }
        return v;
    }
    
    public static void WriteVector(IVectorable v, TextWriter writer)
    {
        writer.WriteLine(v.ToString());
    }

    public static IVectorable ReadVector(TextReader reader)
    {
        string? line = reader.ReadLine();
        string[] parts = line.Split(' ');
        int length = int.Parse(parts[0]);
        ArrayVector v = new ArrayVector(length);
        for (int i = 0; i < length; i++)
        {
            v[i] = int.Parse(parts[i+1]);
        }
        return v;
    }
}
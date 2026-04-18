using System;
using System.Collections;

namespace Lab05;

class VectorNormComparer : IComparer
{
    public int Compare(object? x, object? y)
    {
        if (x == null || y == null)
        {
            throw new ArgumentNullException("Сравнение с null");
        }

        if (x is not IVectorable v1 || y is not IVectorable v2)
        {
            throw new ArgumentException("Сравнимые объекты не IVectorable");
        }

        if (v1.GetNorm() < v2.GetNorm())
        {
            return -1;
        } 
        if (v1.GetNorm() > v2.GetNorm())
        {
            return 1;
        }

        return 0;
    }
}
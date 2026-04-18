using System;
using System.Collections;

namespace Lab17
{
    class VectorNormComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException("Сравнение с null");
            }

            IVectorable v1 = x as IVectorable;
            IVectorable v2 = y as IVectorable;
            
            if (v1 == null || v2 == null)
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
}
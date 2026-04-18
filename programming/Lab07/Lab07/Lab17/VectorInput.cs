using System;

namespace Lab17
{
    internal static class VectorInputHelper
    {
        public static ArrayVector ParseArrayVector(string input)
        {
            string[] t = (input ?? "").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (t.Length == 0) throw new ArgumentException("Введите числа через пробел");

            var v = new ArrayVector(t.Length);
            for (int i = 0; i < t.Length; i++)
                v[i] = int.TryParse(t[i], out int x) ? x : 0;

            return v;
        }

        public static LinkedListVector ParseLinkedListVector(string input)
        {
            string[] t = (input ?? "").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (t.Length == 0) throw new ArgumentException("Введите числа через пробел");

            var v = new LinkedListVector(t.Length);
            for (int i = 0; i < t.Length; i++)
                v[i] = int.TryParse(t[i], out int x) ? x : 0;

            return v;
        }

        public static IVectorable GetByNumber(int n, ArrayVector a1, ArrayVector a2, LinkedListVector l1)
        {
            switch (n)
            {
                case 1: return a1;
                case 2: return a2;
                case 3: return l1;
                default: throw new ArgumentException("Номер вектора должен быть 1, 2 или 3");
            }
        }
    }
}
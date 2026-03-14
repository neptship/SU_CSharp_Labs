namespace Lab05;

public class Fraction
{
    private int numerator;
    private int denominator;
    
    public Fraction()
    {
        Numerator = 0;
        Denominator = 1;
    }

    public Fraction(int num, int den)
    {
        Numerator = num;
        Denominator = den;
    }

    public int Numerator
    {
        get { return numerator; }
        set { numerator = value; }
    }

    public int Denominator
    {
        get { return denominator; }
        set
        {
            if (value == 0)
            {
                denominator = 1;
            }
            else
            {
                denominator = value;
            }
        }
    }

    public Fraction Add(Fraction other)
    {
        int num = this.Numerator * other.Denominator + other.Numerator * this.Denominator;
        int den = this.Denominator * other.Denominator;
        Fraction result = new Fraction();
        result.Numerator = num;
        result.Denominator = den;
        result.Reduce();
        return result;
    }

    public Fraction Subtract(Fraction other)
    {
        int num = this.Numerator * other.Denominator - other.Numerator * this.Denominator;
        int den = this.Denominator * other.Denominator;
        Fraction result = new Fraction();
        result.Numerator = num;
        result.Denominator = den;
        result.Reduce();
        return result;
    }

    public Fraction Multiply(Fraction other)
    {
        int num = Numerator * other.Numerator;
        int den = this.Denominator * other.Denominator;
        Fraction result = new Fraction();
        result.Numerator = num;
        result.Denominator = den;
        result.Reduce();
        return result;
    }
    
    public Fraction Divide(Fraction other)
    {
        int num = this.Numerator * other.Denominator;
        int den = this.Denominator * other.Numerator;
        if (den == 0)
        {
            den = 1;
        }
        Fraction result = new Fraction();
        result.Numerator = num;
        result.Denominator = den;
        result.Reduce();
        return result;
    }

    public void Reduce()
    {
        int nod = GetNOD(Math.Abs(Numerator), Math.Abs(Denominator));
        Numerator = Numerator / nod;
        Denominator = Denominator / nod;

        if (Denominator < 0)
        {
            Numerator = -Numerator;
            Denominator = -Denominator;
        }
    }

    private int GetNOD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }

    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        return f1.Add(f2);
    }

    public static Fraction operator -(Fraction f1, Fraction f2)
    {
        return f1.Subtract(f2);
    }

    public static Fraction operator *(Fraction f1, Fraction f2)
    {
        return f1.Multiply(f2);
    }

    public static Fraction operator /(Fraction f1, Fraction f2)
    {
        return f1.Divide(f2);
    }
}
using System;
namespace Lab04;

public class Polynomial {
    private double a;
    private double b;
    private double c;

    public Polynomial(double a, double b, double c) {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public double[] Roots()
    {
        if (a == 0.0)
        {
            if (b == 0.0)
            {
                return new double[0];
            }
            double[] r1 = new double[1];
            r1[0] = -c / b;
            return r1;
        }

        double d = b * b - 4 * a * c;

        if (d < 0.0)
        {
            return new double[0];
        }
        else if (d == 0.0)
        {
            double[] r1 = new double[1];
            r1[0] = -b / (2 * a);
            return r1;
        }
        else
        {
            double sqrtD = Math.Sqrt(d);
            double[] r2 = new double[2];
            r2[0] = (-b - sqrtD) / (2 * a);
            r2[1] = (-b + sqrtD) / (2 * a);
            return r2;
        }
    }
}
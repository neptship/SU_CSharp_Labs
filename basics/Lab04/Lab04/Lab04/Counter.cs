namespace Lab04;

class Counter
{
    private int min;
    private int max;
    private int cur;

    public Counter(int min, int max, int start)
    {
        if (min > max) { 
            (min, max) = (max, min);
        }
        this.min = min;
        this.max = max;
        if (start < min || start > max)
        {
            cur = min;
        }
        else
        {
            cur = start;
        }
    }

    public void Inc()
    {
        if (cur >= max)
        {
            cur = min;
        }
        else
        {
            cur = cur + 1;
        }
    }

    public void Dec()
    {
        if (cur <= min)
        {
            cur = max;
        }
        else
        {
            cur = cur - 1;
        }
    }

    public int Get()
    {
        return cur;
    }
}
namespace task9_1;

class Support
{
    protected double minimal;
    protected double ratio;

    public Support(double min, double rat)
    {
        minimal = min;
        ratio = rat;
    }

    public void Print() => Console.WriteLine("Мінімальний розмір: {0}, коефіцієнт: {1}",
            minimal, ratio);

    public double Amount() => Math.Round(minimal * ratio, 2);
}

class Disability : Support
{
    protected int group;

    public Disability(double min, double rat, int grp) : base(min, rat) => group = grp;

    public void Print()
    {
        base.Print();
        Console.WriteLine("Група інвалідності: {0}", group);
    }

    public double Amount()
    {
        double amo = base.Amount();
        if (group == 1)
            amo *= 1.3;
        else if (group == 2)
            amo *= 1.2;
        return Math.Round(amo, 2);
    }
}

class MultiChild : Support
{
    protected int count;

    public MultiChild(double min, double rat, int cnt) : base(min, rat) => count = cnt;

    public void Print()
    {
        base.Print();
        Console.WriteLine("Кількість дітей у сімʼї: {0}", count);
    }

    public double Amount()
    {
        double amo = base.Amount();
        if (count > 5)
            amo *= 1.2;
        else if (count >= 3)
            amo *= 1.1;
        return Math.Round(amo, 2);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Support sp = new Support(500, 1.5);
        sp.Print();
        Console.WriteLine("Звичайна виплата: {0}", sp.Amount());

        Console.WriteLine();

        Disability dis1 = new Disability(500, 1.5, 1);
        dis1.Print();
        Console.WriteLine("Виплата за інвалідністю: {0}", dis1.Amount());

        Console.WriteLine();

        Disability dis2 = new Disability(500, 1.5, 2);
        dis2.Print();
        Console.WriteLine("Виплата за інвалідністю: {0}", dis2.Amount());

        Console.WriteLine();

        MultiChild mc4 = new MultiChild(500, 1.5, 4);
        mc4.Print();
        Console.WriteLine("Виплата багатодітним: {0}", mc4.Amount());

        Console.WriteLine();

        MultiChild mc6 = new MultiChild(500, 1.5, 6);
        mc6.Print();
        Console.WriteLine("Виплата багатодітним: {0}", mc6.Amount());
    }
}


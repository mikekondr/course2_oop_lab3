namespace example2;

class Pryam
{
    protected double a;
    protected double b;

    public Pryam()
    { }

    public Pryam(double a, double b)
    {
        this.a = a;
        this.b = b;
    }

    public void Print() => Console.WriteLine("\ba = {0}, b = {1}", a, b);

    public double Sqr() => a * b;

    public double Diag() => Math.Sqrt(a * a + b * b);
}

class Kvadrat : Pryam
{
    public Kvadrat(double x)
    {
        a = x;
        b = x;
    }

    public double Radius() => a / 2;
}

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        for (int i = 1; i <= 5; i++)
        {
            int x = rnd.Next(1, 4);
            int y = rnd.Next(1, 4);

            if (x != y)
            {
                Pryam pr = new Pryam(x, y);
                pr.Print();
                Console.WriteLine("Прямокутник: s = {0}, d = {1:F2}",
                    pr.Sqr(), pr.Diag());
            }
            else
            {
                Kvadrat kv = new Kvadrat(x);
                kv.Print();
                Console.WriteLine("Квадрат: s = {0}, d = {1:F2}, r = {2:F2}",
                    kv.Sqr(), kv.Diag(), kv.Radius());
            }
        }
    }
}


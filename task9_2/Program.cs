namespace task9_2;

class Parallel
{
    protected double a;
    protected double b;
    protected double alfa_grad;
    protected double alfa_rad;

    public Parallel()
    { }

    public Parallel(double a, double b, double grad)
    {
        this.a = a;
        this.b = b;
        this.alfa_grad = grad;
        this.alfa_rad = (Math.PI / 180) * grad;
    }

    public void Print(string name = "Паралелограм")
    {
        Console.WriteLine("{0}:", name);
        Console.WriteLine("- сторона А = {0:F2}", a);
        Console.WriteLine("- сторона В = {0:F2}", b);
        Console.WriteLine("- кут між ними = {0:F2} градусів, {1:F2} радіан", alfa_grad, alfa_rad);
    }

    public double Sqr()
    {
        return a * b * Math.Sin(alfa_rad);
    }

    public void Diag(out double d1, out double d2)
    {
        d1 = Math.Sqrt(a * a + b * b + 2 * a * b * Math.Cos(alfa_rad));
        d2 = Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(alfa_rad));
    }
}

class Rectangle : Parallel
{
    private double circle_rad;

    public Rectangle(double a, double b) : base(a, b, 90)
    {
        circle_rad = Math.Sqrt(a * a + b * b) / 2;
    }

    public double CircleSqr()
    {
        return Math.PI * circle_rad * circle_rad;
    }

    public double CircleLen()
    {
        return 2 * Math.PI * circle_rad;
    }

    public void Print()
    {
        base.Print("Прямокутник");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();

        for (int i = 1; i <=5; i++)
        {
            Console.WriteLine();

            double a = rnd.Next(1, 100);
            double b = rnd.Next(1, 100);
            double alfa = rnd.Next(87, 92);

            if (alfa == 90)
            {
                Rectangle r = new Rectangle(a, b);
                r.Print();
                r.Diag(out double d1, out double d2);
                Console.WriteLine("- діагональ d1 = {0:F2}", d1);
                Console.WriteLine("- діагональ d2 = {0:F2}", d2);
                Console.WriteLine("- площа = {0:F2}", r.Sqr());
                Console.WriteLine("- площа описаного кола = {0:F2}", r.CircleSqr());
                Console.WriteLine("- довжина описаного кола = {0:F2}", r.CircleLen());
            }
            else
            {
                Parallel p = new Parallel(a, b, alfa);
                p.Print();
                p.Diag(out double d1, out double d2);
                Console.WriteLine("- діагональ d1 = {0:F2}", d1);
                Console.WriteLine("- діагональ d2 = {0:F2}", d2);
                Console.WriteLine("- площа = {0:F2}", p.Sqr());
            }
        }
    }
}


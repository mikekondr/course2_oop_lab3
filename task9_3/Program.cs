namespace task9_3;

class Repair
{
    protected double width;
    protected double depth;
    protected double height;

    protected double wall_sqr;
    protected double plaster;

    public Repair()
    { }

    public Repair(double w, double h, double d)
    {
        width = w;
        height = h;
        depth = d;

        wall_sqr = width * height * 2 + depth * height * 2;
        plaster = wall_sqr * 5;
    }

    public void Print(bool child = false)
    {
        Console.WriteLine("Кімната: ширина {0:F2} м, глибина {1:F2} м, висота {2:F2} м", width, depth, height);
        Console.Write("Площа стін: {0:F2} м²", wall_sqr);
        if (!child)
            Console.WriteLine(", кількість штукатурки: {0:F2} кг", plaster);
    }

    public bool Plastering(double amount)
    {
        bool result = false;

        if (amount < plaster)
        {
            result = true;
            plaster -= amount;
        }
        else
            plaster = 0;

        Console.WriteLine("Лишилось штукатурки: {0:F2} кг", plaster);

        return result;
    }
}

class Wallpaper : Repair
{
    protected double roll_width;
    protected double roll_len;
    protected int count;

    public Wallpaper(double w, double h, double d, double rw, double rl) :
        base(w, h, d)
    {
        roll_width = rw;
        roll_len = rl;

        double roll_sqr = roll_width * roll_len;
        count = (int)Math.Round( wall_sqr / roll_sqr, 0);
    }

    public void Print()
    {
        base.Print(true);
        Console.WriteLine(", кількість шпалер: {0} рул.", count);
    }

    public bool Wallpapering(int amount)
    {
        bool result = false;

        if (amount < count)
        {
            result = true;
            count -= amount;
        }
        else
            count = 0;

        Console.WriteLine("Лишилось шпалер: {0} рул.", count);

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\tРемонт кімнати\n");

        Repair rp = new Repair(5, 3, 6);
        rp.Print();

        int day_count = 1;
        while(rp.Plastering(100))
            day_count++;
        Console.WriteLine("Штукатуримо {0} дн по 100 кг в день\n", day_count);

        Wallpaper wp = new Wallpaper(5, 3, 6, 1, 10);
        wp.Print();

        day_count = 1;
        while(wp.Wallpapering(3))
            day_count++;
        Console.WriteLine("Клеїмо шпалери {0} дн по 3 рулони на день", day_count);
    }
}


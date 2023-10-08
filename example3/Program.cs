namespace example3;

class Transport
{
    protected double l;
    protected bool spravka;

    public Transport(double l, bool spravka)
    {
        this.l = l;
        this.spravka = spravka;
    }

    public bool Move(double dl)
    {
        bool result = false;
        if (spravka == true)
        {
            result = true;
            l += dl;
        }
        return result;
    }

    public string ToStr() => "Загальний пробіг: " + l;
}

class Car : Transport
{
    double RT; //витрата палива (л/км)
    double VB; //обʼєм палива у баку (л)

    public Car(double l, bool spravka, double rt, double vb) :
        base(l, spravka)
    {
        this.RT = rt;
        this.VB = vb;
    }

    public bool Change(double l)
    {
        bool result = false;
        double v = RT * l;
        if (VB - v >= 0)
        {
            VB = VB - v;
            result = true;
        }
        return result;
    }

    public string ToStr() => base.ToStr() + ", залишок палива: " + VB;
}

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();

        //для транспортного засобу
        double rast = rnd.Next(100, 500); //відстань
        double pr = rnd.Next(1000, 2000); //початковий пробіг
        double v = rnd.Next(40, 120); //швидкість
        bool sp = (rnd.Next(0, 2) != 0); //наявність довідки

        Console.WriteLine("Для транспортного засобу:\n");
        Console.WriteLine("\tвідстань = {0}", rast);
        Console.WriteLine("\tпочатковий пробіг = {0}", pr);
        Console.WriteLine("\tшвидкість = {0}\n", v);

        Transport t = new Transport(pr, sp);
        bool x;
        if (sp)
        {
            do
            {
                x = t.Move(v);
                rast -= v;
                Console.WriteLine(t.ToStr());
            } while (rast - v >= 0);
            x = t.Move(rast);
            Console.WriteLine(t.ToStr());
        }
        else
            Console.WriteLine("Необхідно пройти тех.огляд");

        //для автомобіля
        rast = rnd.Next(100, 500); //відстань
        pr = rnd.Next(1000, 2000); //початковий пробіг
        double rtop = rnd.Next(1, 3) / 10.0; //витрата палива
        double vben = rnd.Next(50, 80); //кількість палива
        sp = (rnd.Next(0, 2) != 0); //наявність довідки

        Console.WriteLine("\n\nДля автомобіля:\n");
        Console.WriteLine("\tвідстань = {0}", rast);
        Console.WriteLine("\tпочатковий пробіг = {0}", pr);
        Console.WriteLine("\tвитрата палива (л/км) = {0}", rtop);
        Console.WriteLine("\tобʼєм палива в баку (л) = {0}\n", vben);

        Car c = new Car(pr, sp, rtop, vben);
        if (!c.Move(rast))
            Console.WriteLine("Поїздка на можлива: пройдіть тех.огляд!");
        else if (!c.Change(rast))
            Console.WriteLine("Поїздка не можлива: не вистачає палива!");
        else
            Console.WriteLine(c.ToStr());
    }
}


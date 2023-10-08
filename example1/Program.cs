namespace example1;

class Press
{
    protected string name; //назва
    protected int copies; //тираж
    protected double price; //ціна за одиницю

    public Press()
    {}

    public Press(string name, int copies, double price)
    {
        this.name = name;
        this.copies = copies;
        this.price = price;
    }

    public void Print()
    {
        Console.WriteLine("\nНазва: {0}, Тираж: {1}, Базова ціна екземпляра: {2:F2}",
            name, copies, price);
    }

    public double Cost()
    {
        return copies * price;
    }
}

class Magazine : Press
{
    string quality; //якість: low або high

    public Magazine(string name, int copies, double price, string quality) :
        base(name, copies, price)
    {
        this.quality = quality;
    }

    public void Print()
    {
        base.Print();
        Console.WriteLine("Якість паперу: {0}", quality == "low" ? "низька" : "висока");
    }

    public double Cost()
    {
        double sum = base.Cost();
        if (quality == "low")
            return sum * 0.9;
        else if (quality == "high")
            return sum * 1.1;
        else
            return sum;
    }
}

class Book : Press
{
    int pages; //кількість сторінок
    double cover; //вартість обкладинки

    public Book(string name, int copies, double price, int pages, double cover) :
        base(name, copies, price)
    {
        this.pages = pages;
        this.cover = cover;
    }

    public void Print()
    {
        base.Print();
        Console.WriteLine("Кількість сторінок: {0}, Вартість обкладинки: {1:F2}",
            pages, cover);
    }

    public double Cost()
    {
        return (price * pages / 4.0 + cover) * copies;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Press pr = new Press("Преса", 1000, 3.5);
        pr.Print();
        Console.WriteLine("Вартість тиражу: {0:F2}", pr.Cost());

        Magazine mg1 = new Magazine("Журнал 1", 1000, 3.5, "low");
        mg1.Print();
        Console.WriteLine("Вартість тиражу: {0:F2}", mg1.Cost());

        Magazine mg2 = new Magazine("Журнал 2", 1000, 3.5, "high");
        mg2.Print();
        Console.WriteLine("Вартість тиражу: {0:F2}", mg2.Cost());

        Book bk = new Book("Книга", 1000, 3.5, 100, 20.5);
        bk.Print();
        Console.WriteLine("Вартість тиражу: {0:F2}", bk.Cost());
    }
}


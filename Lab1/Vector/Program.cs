using System;

class Vector
{
    //конструктор, принимающий координаты вектора;
    static public int Count = 0;

    private double x;
    private double y;
    private double z;


    public Vector(double x, double y, double z)
    {//копирующий конструктор;
        Count++;
        this.x = x;
        this.y = y;
        this.z = z;
    }

    // Создаем вектор
    public Vector(Vector v)
    {
        new Vector(v.x, v.y, v.z);
    }

    // Вычисляем l - норму вектора
    public double Norma1()
    {
        return Math.Abs(this.x) + Math.Abs(this.y) + Math.Abs(this.z);

    }
    // Вычисляем евклидову норму вектора
    public double Norma2()
    {
        return Math.Sqrt(Math.Pow(this.x, 2) + Math.Pow(this.y, 2) + Math.Pow(this.z, 2));
    }

    // Вычисляем max - норму вектора
    public double Norma3()
    {
        return Math.Max(Math.Abs(this.x), Math.Max(Math.Abs(this.y), Math.Abs(this.z)));

    }

    class Program
    {
        public static void Main(string[] args)
        {
            var v = new Vector(1, 9, 3);

            Console.WriteLine("L - норма вектора = {0}", v.Norma1());
            Console.WriteLine("Евклидова норма вектора = {0}", v.Norma2());
            Console.WriteLine("Max - норма вектора = {0} ", v.Norma3());
        }
    }
}

using System;

class Vector
{
    public double X { get; }
    public double Y { get; }
    public double Z { get; }

    public Vector(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    // Перегрузка операции сравнения ==
    public static bool operator ==(Vector v1, Vector v2)
    {
        return v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;
    }

    // Перегрузка операции сравнения !=
    public static bool operator !=(Vector v1, Vector v2)
    {
        return !(v1 == v2);
    }

    // Перегрузка операции умножения на скаляр (число)
    public static Vector operator *(Vector v, double scalar)
    {
        return new Vector(v.X * scalar, v.Y * scalar, v.Z * scalar);
    }

    // Перегрузка операции умножения на скаляр (число) (обратный порядок)
    public static Vector operator *(double scalar, Vector v)
    {
        return v * scalar;
    }

    // Перегрузка операции скалярного произведения векторов
    public static double operator *(Vector v1, Vector v2)
    {
        return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
    }

    // Перегрузка бинарной операции вычитания векторов
    public static Vector operator -(Vector v1, Vector v2)
    {
        return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Vector v = (Vector)obj;
        return (X == v.X) && (Y == v.Y) && (Z == v.Z);
    }

    public override int GetHashCode()
    {
        return Tuple.Create(X, Y, Z).GetHashCode();
    }

    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }
}

class Program
{
    static void Main()
    {
        // Ввод данных для первого вектора
        Console.WriteLine("Введите координаты первого вектора (x, y, z):");
        double x1 = double.Parse(Console.ReadLine());
        double y1 = double.Parse(Console.ReadLine());
        double z1 = double.Parse(Console.ReadLine());
        Vector v1 = new Vector(x1, y1, z1);

        // Ввод данных для второго вектора
        Console.WriteLine("Введите координаты второго вектора (x, y, z):");
        double x2 = double.Parse(Console.ReadLine());
        double y2 = double.Parse(Console.ReadLine());
        double z2 = double.Parse(Console.ReadLine());
        Vector v2 = new Vector(x2, y2, z2);

        Console.WriteLine("Vector v1: " + v1);
        Console.WriteLine("Vector v2: " + v2);

        // Проверка перегрузки ==
        Console.WriteLine("v1 == v2: " + (v1 == v2));

        // Проверка перегрузки !=
        Console.WriteLine("v1 != v2: " + (v1 != v2));

        // Ввод скаляра для умножения
        Console.WriteLine("Введите скаляр для умножения:");
        double scalar = double.Parse(Console.ReadLine());

        // Проверка умножения на скаляр
        Vector v3 = v1 * scalar;
        Console.WriteLine("v1 * scalar: " + v3);

        // Проверка скалярного произведения
        double dotProduct = v1 * v2;
        Console.WriteLine("v1 * v2 (dot product): " + dotProduct);

        // Проверка вычитания
        Vector v4 = v1 - v2;
        Console.WriteLine("v1 - v2: " + v4);
    }
}

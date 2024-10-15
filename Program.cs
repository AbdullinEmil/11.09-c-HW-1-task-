using System;

public class Program
{
    public static void Main(string[] args)
    {

        int[] A = new int[5];
        double[,] B = new double[3, 4];


        Console.WriteLine("Введите 5 чисел для массива A:");
        for (int i = 0; i < A.Length; i++)
        {
            A[i] = int.Parse(Console.ReadLine());
        }

 
        Random random = new Random();
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                B[i, j] = random.NextDouble() * 100;
            }
        }

 
        Console.WriteLine("\nМассив A:");
        Console.WriteLine(string.Join(" ", A));


        Console.WriteLine("\nМассив B:");
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                Console.Write($"{B[i, j]:F2} ");
            }
            Console.WriteLine();
        }

        double maxElement = FindMax(A, B);
        double minElement = FindMin(A, B);
        double sumAllElements = CalculateSum(A, B);
        double productAllElements = CalculateProduct(A, B);
        int sumEvenElementsA = CalculateSumEven(A);
        double sumOddColumnsB = CalculateSumOddColumns(B);


        Console.WriteLine("\nОбщий максимальный элемент: " + maxElement);
        Console.WriteLine("Общий минимальный элемент: " + minElement);
        Console.WriteLine("Общая сумма элементов: " + sumAllElements);
        Console.WriteLine("Общее произведение элементов: " + productAllElements);
        Console.WriteLine("Сумма четных элементов массива A: " + sumEvenElementsA);
        Console.WriteLine("Сумма нечетных столбцов массива B: " + sumOddColumnsB);
    }

    static double FindMax(int[] A, double[,] B)
    {
        double max = A.Max();
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                if (B[i, j] > max)
                {
                    max = B[i, j];
                }
            }
        }
        return max;
    }


    static double FindMin(int[] A, double[,] B)
    {
        double min = A.Min();
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                if (B[i, j] < min)
                {
                    min = B[i, j];
                }
            }
        }
        return min;
    }


    static double CalculateSum(int[] A, double[,] B)
    {
        double sum = A.Sum();
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                sum += B[i, j];
            }
        }
        return sum;
    }


    static double CalculateProduct(int[] A, double[,] B)
    {
        double product = 1;
        foreach (int element in A)
        {
            product *= element;
        }
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                product *= B[i, j];
            }
        }
        return product;
    }

    static int CalculateSumEven(int[] A)
    {
        int sum = 0;
        foreach (int element in A)
        {
            if (element % 2 == 0)
            {
                sum += element;
            }
        }
        return sum;
    }

    static double CalculateSumOddColumns(double[,] B)
    {
        double sum = 0;
        for (int j = 1; j < B.GetLength(1); j += 2) 
        {
            for (int i = 0; i < B.GetLength(0); i++)
            {
                sum += B[i, j];
            }
        }
        return sum;
    }
}
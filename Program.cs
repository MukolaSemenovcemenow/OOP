using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        // Робота з одномірним масивом
        double[] array1D = { -3.5, 2.0, -1.0, 5.5, -6.0, 4.0, -0.5, 1.5, 3.0 };

        // a) Знаходимо максимальний елемент масиву
        double maxElement = array1D.Max();
        Console.WriteLine($"Максимальний елемент масиву: {maxElement}");

        // б) Знаходимо суму елементів масиву, розташованих до останнього додатнього елемента
        int lastPositiveIndex = Array.FindLastIndex(array1D, x => x > 0);
        double sumBeforeLastPositive = array1D.Take(lastPositiveIndex).Sum();
        Console.WriteLine($"Сума елементів до останнього додатнього елемента: {sumBeforeLastPositive}");

        // Стиснення масиву, видаливши всі елементи, модуль яких знаходиться в інтервалі (-1, 1)
        double[] compressedArray = array1D.Where(x => Math.Abs(x) >= 1).ToArray();
        Array.Resize(ref compressedArray, array1D.Length);
        for (int i = array1D.Length - compressedArray.Length; i < compressedArray.Length; i++)
        {
            compressedArray[i] = 0;
        }

        Console.WriteLine("Стиснутий масив:");
        foreach (var item in compressedArray)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        // Робота з двовимірним масивом
        double[,] array2D = {
            { 5.5, 2.2, 3.3 },
            { 4.4, 1.1, 0.5 },
            { 7.7, 8.8, 9.9 }
        };

        // a) Визначити, який елемент більше: у верхньому лівому чи верхньому правому куті
        double topLeft = array2D[0, 0];
        double topRight = array2D[0, array2D.GetLength(1) - 1];
        Console.WriteLine($"Верхній лівий елемент: {topLeft}");
        Console.WriteLine($"Верхній правий елемент: {topRight}");
        Console.WriteLine($"Більший елемент: {(topLeft > topRight ? "Верхній лівий" : "Верхній правий")}");

        // б) Визначити, який елемент менше: у нижньому правому чи верхньому лівому куті
        double bottomRight = array2D[array2D.GetLength(0) - 1, array2D.GetLength(1) - 1];
        Console.WriteLine($"Нижній правий елемент: {bottomRight}");
        Console.WriteLine($"Менший елемент: {(topLeft < bottomRight ? "Верхній лівий" : "Нижній правий")}");

        // Виведення двовимірного масиву
        Console.WriteLine("Двовимірний масив:");
        for (int i = 0; i < array2D.GetLength(0); i++)
        {
            for (int j = 0; j < array2D.GetLength(1); j++)
            {
                Console.Write(array2D[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

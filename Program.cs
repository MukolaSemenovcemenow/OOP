using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Container
{
    protected List<double> data;

    public Container(IEnumerable<double> initialData)
    {
        data = new List<double>(initialData);
    }

    // Віртуальний метод сортування
    public abstract void Sort();

    // Віртуальний метод поелементної обробки
    public abstract void ForEach();

    // Метод для виведення вмісту контейнера
    public void Display()
    {
        foreach (var item in data)
        {
            Console.WriteLine(item);
        }
    }
}

public class Bubble : Container
{
    public Bubble(IEnumerable<double> initialData) : base(initialData) { }

    // Реалізація бульбашкового сортування
    public override void Sort()
    {
        for (int i = 0; i < data.Count - 1; i++)
        {
            for (int j = 0; j < data.Count - i - 1; j++)
            {
                if (data[j] > data[j + 1])
                {
                    double temp = data[j];
                    data[j] = data[j + 1];
                    data[j + 1] = temp;
                }
            }
        }
    }

    // Реалізація поелементної обробки - добування квадратного кореня
    public override void ForEach()
    {
        for (int i = 0; i < data.Count; i++)
        {
            data[i] = Math.Sqrt(data[i]);
        }
    }
}

public class Choice : Container
{
    public Choice(IEnumerable<double> initialData) : base(initialData) { }

    // Реалізація сортування методом вибору
    public override void Sort()
    {
        for (int i = 0; i < data.Count - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < data.Count; j++)
            {
                if (data[j] < data[minIndex])
                {
                    minIndex = j;
                }
            }
            double temp = data[minIndex];
            data[minIndex] = data[i];
            data[i] = temp;
        }
    }

    // Реалізація поелементної обробки - обчислення логарифма
    public override void ForEach()
    {
        for (int i = 0; i < data.Count; i++)
        {
            data[i] = Math.Log(data[i]);
        }
    }
}

public class Program
{
    public static void Main()
    {
        List<double> initialData = new List<double> { 16, 4, 25, 9, 36 };

        Console.WriteLine("Bubble Sort and Square Root:");
        Bubble bubbleContainer = new Bubble(initialData);
        bubbleContainer.Sort();
        bubbleContainer.ForEach();
        bubbleContainer.Display();

        Console.WriteLine("\nChoice Sort and Logarithm:");
        Choice choiceContainer = new Choice(initialData);
        choiceContainer.Sort();
        choiceContainer.ForEach();
        choiceContainer.Display();
    }
}

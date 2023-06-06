using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24
{
    class Program
    {
        static void Main()
        {
            int[,] arr = new int[5, 5];
            int count = 0;
            Random rand = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next(1, 21);
                }
            }
            Console.WriteLine("Массив:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int minVal = arr[i, 0];
                int minIndex = 0;
                for (int j = 1; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] < minVal)
                    {
                        minVal = arr[i, j];
                        minIndex = j;
                    }
                }

                bool isSaddlePoint = true;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j != minIndex && arr[i, j] == minVal)
                    {
                        isSaddlePoint = false;
                        break;
                    }
                }

                if (isSaddlePoint)
                {
                    int maxVal = arr[0, minIndex];
                    for (int j = 1; j < arr.GetLength(0); j++)
                    {
                        if (arr[j, minIndex] > maxVal) maxVal = arr[j, minIndex];
                    }

                    if (maxVal == minVal)
                    {
                        Console.WriteLine("Седловая точка: ({0}, {1})", i + 1, minIndex + 1);
                        count++;
                    }
                }
            }
            if (count == 0) Console.WriteLine("Седловых точек нет");
            Console.WriteLine("Хотите повторить задачу? Если да, нажмите Enter");
            if (Console.ReadKey().Key == ConsoleKey.Enter) Main();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Генератор случайных чисел для генерации матрицы 
            Random rnd = new Random();
            // Размер матрицы
            ushort N;
            // Флаг правильности ввода
            bool ok;
            do
            {
                Console.WriteLine("Введите размер матрицы: ");
                ok = UInt16.TryParse(Console.ReadLine(), out N) && N > 0;
                if (!ok)
                    Console.WriteLine("Требуется ввести натуральное число.");
            } while (!ok);
            // Матрица
            double[,] Matrix = new double[N, N];
            // Координата середины матрицы
            ushort Mid = (ushort)(N / 2);
            // Максимальный элемент
            double Max = 0;

            // Заполнение матрицы
            for (ushort i = 0; i < N; i++)
                for (ushort j = 0; j < N; j++)
                    Matrix[i, j] = rnd.NextDouble();

            // Проход по заданной области и поиск максимального элемента
            for (ushort i = 0; i < Mid; i++)
                for (ushort j = i; j < N - i; j++)
                    if (Matrix[i, j] > Max)
                        Max = Matrix[i, j];
            for (ushort i = Mid; i < N; i++)
                for (ushort j = (ushort)(N-1-i); j<=i; j++)
                    if (Matrix[i, j] > Max)
                        Max = Matrix[i, j];

            // Вывод результатов
            Console.WriteLine("Наибольший элемент в выделенной области равен {0}.", Max);

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}

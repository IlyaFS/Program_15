using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите первый член прогрессии: ");
            int first = int.Parse(Console.ReadLine());
            Console.Write("Введите шаг прогрессии: ");
            int step = int.Parse(Console.ReadLine());
            Console.Write("Введите количество шагов прогрессии: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.WriteLine("Результат арифметической прогресcии");
            ArithProgression arithProgression = new ArithProgression(step, number);
            arithProgression.SetStart(first);

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine(arithProgression.GetNext());
                arithProgression.Reset();
            }

            Console.WriteLine();

            Console.WriteLine("Результат геометрической прогреcсии");
            GeomProgression geomProgression = new GeomProgression(step, number);
            geomProgression.SetStart(first);

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine(geomProgression.GetNext());
                geomProgression.Reset();
            }

            Console.WriteLine();
            Console.Write("Нажмите на любого клавиша . . .");
            Console.ReadKey();

        }
    }
    interface ISeries
    {
        void SetStart(int x);
        int GetNext();
        void Reset();
    }

    class GeomProgression : ISeries
    {

        int N = 1;
        int B1;
        public int B { get; set; }
        public int Step { get; set; }
        public int Number { get; set; }


        public GeomProgression(int step, int number)
        {
            Step = step;
            Number = number;
        }
        public void SetStart(int x)
        {
            B1 = B = x;
        }
        public int GetNext()
        {
            B = (int)(B * Math.Pow(Step, (N - 1)));
            N++;
            return (int)B;
        }
        public void Reset()
        {
            B = B1;
        }
    }
    class ArithProgression : ISeries
    {

        int N = 1;
        int A1;
        public int A { get; set; }
        public int Step { get; set; }
        public int Number { get; set; }


        public ArithProgression (int step, int number)
        {
            Step = step;
            Number = number;
        }
        public void SetStart(int x)
        {
            A1 = A = x;
        }
        public int GetNext()
        {
            A += (N - 1) * Step;
            N++;
            return A;
        }
        public void Reset()
        {
            A = A1;
        }
    }
}

//Разработать интерфейс ISeries генерации ряда чисел. Интерфейс содержит следующие элементы:

//метод void setStart(int x) -устанавливает начальное значение
//метод int getNext() -возвращает следующее число ряда
//метод void reset() -выполняет сброс к начальному значению
//Разработать классы ArithProgression и GeomProgression, которые реализуют интерфейс ISeries.
//В классах реализовать методы интерфейса в соответствии с логикой арифметической и геометрической прогрессии соответственно.

using System;

namespace Time_TimePeriod
{
    class Program
    {
        static void Main(string[] args)
        {

            Time t1 = new Time();
            Time t2 = new Time("11:02:33");
            Time t3 = new Time(21, 0, 42);
            TimePeriod tp1 = new TimePeriod();
            TimePeriod tp2 = new TimePeriod(6000);
            TimePeriod tp3 = new TimePeriod("6543:12");
            TimePeriod tp4 = new TimePeriod(43, 22, 55);
            TimePeriod tp5 = new TimePeriod(t1, t2);

            Console.WriteLine("Time bez podania argumentów: " + t1);
            Console.WriteLine("Time po podaniu stringa do konstruktora: " + t2);
            Console.WriteLine("Time po podaniu trzech argumentów do konstruktora: " + t3);
            Console.WriteLine("TimePeriod bez podania argumentów: " + tp1);
            Console.WriteLine("TimePeriod po podaniu liczby sekund do konstruktora: " + tp2);
            Console.WriteLine("TimePeriod po podaniu stringa do konstruktora: " + tp3);
            Console.WriteLine("TimePeriod po podaniu trzech argumentów do konstruktora: " + tp4);
            Console.WriteLine("TimePeriod po podaniu argumentów w postaci struktury Time do konstruktora: " + tp5);
            Console.WriteLine("Dodawanie TimePeriod do Time: " + t1.Plus(tp2));
            Console.WriteLine("Dodawanie TimePeriod do TimePeriod: " + tp3.Plus(tp4));
            Console.WriteLine("Odejmowanie TimePeriod od TimePeriod: " + tp3.Minus(tp2));
        }
    }
}
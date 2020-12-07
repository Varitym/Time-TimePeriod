using System;

namespace Time_TimePeriod
{
    class Program
    {
        static void Main(string[] args)
        {
            Time t1 = new Time(12, 0, 59);
            Time t11 = new Time(12);
            Time t2 = new Time(0, 44, 02);
            Time t22 = new Time("00:44:02");

            Console.WriteLine(t1.Hours+" "+t1.Minutes+" "+t1.Seconds);
            Console.WriteLine(t11);
            Console.WriteLine(t2);
            Console.WriteLine(t22.Hours + ":" + t22.Minutes + ":" + t22.Seconds);
        }
    }
}

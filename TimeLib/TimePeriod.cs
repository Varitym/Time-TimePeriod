using System;
namespace Time_TimePeriod
{
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        private long _seconds;
        public readonly long Seconds => _seconds;

        private static long ParseTimeToSeconds(Time t1) => t1.Hours * 3600 + t1.Minutes * 60 + t1.Seconds;

        public static int checkTime(int value, int min, int max)
        {
            if (value >= min && value <= max)
            {
                return value;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!");
            }
        }

        public TimePeriod(int hours=0, int minutes=0, int seconds=0)
        {
            this._seconds = hours * 3600 + checkTime(minutes, 0, 59) * 60 + checkTime(seconds, 0, 59);
        }

        public TimePeriod(Time t1, Time t2)
        {
            var firstTime = ParseTimeToSeconds(t1);
            var secondTime = ParseTimeToSeconds(t2);
            this._seconds = Math.Abs(firstTime - secondTime);
        }

        public TimePeriod(long seconds)
        {
            if (seconds < 0) throw new ArgumentException();
            this._seconds = seconds;
        }

        public TimePeriod(string timePeriod)
        {
            string[] periodArr = timePeriod.Split(":");
            var minutes = 0;
            var seconds = 0;

            var hours = int.Parse(periodArr[0]);
            if (hours < 0) throw new ArgumentException();

            if (periodArr.Length > 1)
            {
                minutes = checkTime(byte.Parse(periodArr[1]), 0, 59);
            }

            if (periodArr.Length > 2)
            {
                seconds = checkTime(byte.Parse(periodArr[2]), 0, 59);
            }

            this._seconds = hours * 3600 + minutes * 60 + seconds;
        }

        public override string ToString()
        {
            return $"{Seconds / 3600}:{(Seconds / 60) % 60:D2}:{Seconds % 60:D2}";
        }

        public bool Equals(TimePeriod other)
        {
            return Seconds == other.Seconds;

        }

        public override bool Equals(object obj)
        {
            if (obj is TimePeriod)
            {
                return Equals((TimePeriod)obj);
            }
            else
                return false;
        }

        public static bool Equals(TimePeriod firstTime, TimePeriod secondTime)
        {
            return firstTime.Equals(secondTime);
        }

        public override int GetHashCode() => Seconds.GetHashCode();

        public int CompareTo(TimePeriod other)
        {
            if (this.Equals(other)) return 0;

            return this.Seconds.CompareTo(other.Seconds);
        }

        public static bool operator <(TimePeriod left, TimePeriod right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(TimePeriod left, TimePeriod right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(TimePeriod left, TimePeriod right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(TimePeriod left, TimePeriod right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static bool operator ==(TimePeriod firstTime, TimePeriod secondTime)
        {
            return Equals(firstTime, secondTime);
        }

        public static bool operator !=(TimePeriod firstTime, TimePeriod secondTime)
        {
            return !(firstTime == secondTime);
        }

        public static Time operator +(Time time, TimePeriod timeStamp)
        {
            var timeInSeconds = time.Hours * 3600 + time.Minutes * 60 + time.Seconds;
            var addedTimeInSeconds = timeStamp.Seconds + timeInSeconds;

            var hours = ((addedTimeInSeconds - (addedTimeInSeconds % 60) - ((addedTimeInSeconds - addedTimeInSeconds % 60) % 3600 / 60)) / 3600);
            var minutes = ((addedTimeInSeconds - addedTimeInSeconds % 60) % 3600 / 60);
            var seconds = addedTimeInSeconds % 60;
            var result = new Time((byte)hours, (byte)minutes, (byte)seconds);

            return result;
        }

        public TimePeriod Plus(TimePeriod otherTimePeriod)
        {
            return new TimePeriod(this.Seconds + otherTimePeriod.Seconds);
        }

        public static TimePeriod Plus(TimePeriod tp1, TimePeriod tp2)
        {
            return new TimePeriod(tp1.Seconds + tp2.Seconds);
        }

        public TimePeriod Minus(TimePeriod othertimePeriod)
        {
            var newSeconds = this.Seconds - othertimePeriod.Seconds;
            if (newSeconds < 0) throw new ArgumentException("Arg 1 < Arg 2!");
            return new TimePeriod(newSeconds);
        }

        public static TimePeriod Minus(TimePeriod firstTimeStamp, TimePeriod secondTimeStamp)
        {
            var subtractionResult = (int)(firstTimeStamp.Seconds - secondTimeStamp.Seconds);

            if (subtractionResult < 0)
                throw new ArgumentException("Invalid arguments order.");

            return new TimePeriod(subtractionResult);
        }

        






    }
}

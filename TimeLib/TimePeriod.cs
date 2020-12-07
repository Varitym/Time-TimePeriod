﻿using System;
namespace Time_TimePeriod
{
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        private long _seconds;
        public readonly long Seconds => _seconds;

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

        public TimePeriod(int hours, int minutes, int seconds)
        {
            this._seconds = hours * 3600 + checkTime(minutes, 0, 59) * 60 + checkTime(seconds, 0, 59);
        }

        public TimePeriod(string periodS)
        {
            string[] periodArr = periodS.Split(":");
            int hours = int.Parse(periodArr[0]);
            int minutes = checkTime(byte.Parse(periodArr[1]), 0, 59);
            int seconds = checkTime(byte.Parse(periodArr[2]), 0, 59);

            if (hours < 0)
            {
                throw new ArgumentException("Incorrect argument!");
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

        public static Time operator -(Time time, TimePeriod timeStamp)
        {
            var timeInSeconds = time.Hours * 3600 + time.Minutes * 60 + time.Seconds;
            var subtractedTimeInSeconds = timeInSeconds - timeStamp.Seconds;

            if (subtractedTimeInSeconds < 0)
                throw new ArgumentException("Invalid arguments order.");

            var hours = ((subtractedTimeInSeconds - (subtractedTimeInSeconds % 60) - ((subtractedTimeInSeconds - subtractedTimeInSeconds % 60) % 3600 / 60)) / 3600);
            var minutes = ((subtractedTimeInSeconds - subtractedTimeInSeconds % 60) % 3600 / 60);
            var seconds = subtractedTimeInSeconds % 60;

            var result = new Time((byte)hours, (byte)minutes, (byte)seconds);

            return result;
        }

        public static Time Plus(Time firstTime, Time secondTime)
        {
            var addedTimeInSeconds = (firstTime.Seconds + secondTime.Seconds) +
                                     (firstTime.Minutes * 60 + secondTime.Minutes * 60) +
                                     (firstTime.Hours * 3600 + secondTime.Hours * 3600);

            var hours = ((addedTimeInSeconds - (addedTimeInSeconds % 60) - ((addedTimeInSeconds - addedTimeInSeconds % 60) % 3600 / 60)) / 3600);
            var minutes = ((addedTimeInSeconds - addedTimeInSeconds % 60) % 3600 / 60);
            var seconds = addedTimeInSeconds % 60;
            var result = new Time((byte)hours, (byte)minutes, (byte)seconds);

            return result;
        }

        public static Time Minus(Time time, TimePeriod timeStamp)
        {
            var timeInSeconds = time.Hours * 3600 + time.Minutes * 60 + time.Seconds;
            var subtractedTimeInSeconds = timeInSeconds - timeStamp.Seconds;

            if (subtractedTimeInSeconds < 0)
                throw new ArgumentException("Invalid arguments order.");

            var hours = ((subtractedTimeInSeconds - (subtractedTimeInSeconds % 60) - ((subtractedTimeInSeconds - subtractedTimeInSeconds % 60) % 3600 / 60)) / 3600);
            var minutes = ((subtractedTimeInSeconds - subtractedTimeInSeconds % 60) % 3600 / 60);
            var seconds = subtractedTimeInSeconds % 60;
            var result = new Time((byte)hours, (byte)minutes, (byte)seconds);

            return result;
        }





    }
}

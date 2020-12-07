using System;

namespace Time_TimePeriod

{
    public struct Time : IEquatable<Time>
    {
        private byte _hours, _minutes, _seconds;
        public readonly byte Hours => _hours;
        public readonly byte Minutes => _minutes;
        public readonly byte Seconds => _seconds;

        public static byte checkTime(byte value, int min, int max)
        {
            if (value >= min && value <= max)
            {
                return value;
            }
            else
            {
                throw new ArgumentException("Wrong argument!");
            }
        }


        public Time(byte hours, byte minutes, byte seconds)
        {
            this._hours = checkTime(hours, 0, 23);
            this._minutes = checkTime(minutes, 0, 59);
            this._seconds = checkTime(seconds, 0, 59);

        }

        public Time(string time)
        {
            string[] timeS = time.Split(":");
            this._hours = checkTime(byte.Parse(timeS[0]), 0, 23);
            this._minutes = checkTime(byte.Parse(timeS[1]), 0, 59);
            this._seconds = checkTime(byte.Parse(timeS[2]), 0, 59);
        }


        public bool Equals(Time other)
        {
            return _hours == other._hours && _minutes == other.Minutes && _seconds == other._seconds;

        }

        public override bool Equals(object obj)
        {
            if (obj is Time)
            {
                return Equals((Time)obj);
            }
            else
                return false;
        }

        public static bool Equals(Time time1, Time time2)
        {
            return time1.Equals(time2);
        }

        public override int GetHashCode() => (Hours, Minutes, Seconds).GetHashCode();

        public int CompareTo(Time other)
        {
            if (this.Equals(other)) return 0;

            if (this.Hours != other.Hours)
                return this.Hours.CompareTo(other.Hours);

            if (this.Minutes != other.Minutes)
                return this.Minutes.CompareTo(other.Minutes);

            return this.Seconds.CompareTo(other.Seconds);
        }

    }




}

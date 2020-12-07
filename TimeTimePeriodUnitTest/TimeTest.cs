using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Time_TimePeriod;


namespace TimeTimePeriodTestProject
{
    [TestClass]
    public class TimeTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Wrong argument format - only numbers and colons allowed.")]
        public void TestStringWithNotAllowedChars()
        {
            var argument = ",abc:4";

            var timeStamp = new Time(argument);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Wrong argument format - there are colons only.")]
        public void TestStringWithColonOnly()
        {
            var argument = ":";

            var timeStamp = new Time(argument);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Wrong argument format - colon cannot be at first position.")]
        public void TestStringWithColonAtTheBegining()
        {
            var argument = ":4:4";

            var timeStamp = new Time(argument);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Wrong argument format - too much colons.")]
        public void TestStringWithTooMuchColons()
        {
            var argument = "4:5:0:4";

            var timeStamp = new Time(argument);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Wrong argument - there is nothing between colons.")]
        public void TestStringWithColonsTogether()
        {
            var argument = "4::4";

            var timeStamp = new Time(argument);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Wrong argument format - colon cannot be at last position.")]
        public void TestStringWithColonAtTheEnd()
        {
            var argument = "25:4:";

            var timeStamp = new Time(argument);
        }

        [TestMethod]
        public void TestStringWithTwoColons1()
        {
            var argument = "05:04:02";
            var expected = 5 * 3600 + 4 * 60 + 2;

            var timeStamp = new Time(argument);

            Assert.AreEqual(expected, timeStamp.Hours * 3600 + timeStamp.Minutes * 60 + timeStamp.Seconds);
        }

        [TestMethod]
        public void TestStringWithTwoColons2()
        {
            var argument = "05:0:2";
            var expected = 5 * 3600 + 2;

            var timeStamp = new Time(argument);

            Assert.AreEqual(expected, timeStamp.Hours * 3600 + timeStamp.Minutes * 60 + timeStamp.Seconds);
        }

        [TestMethod]
        public void TestStringWithTwoColons3()
        {
            var argument = "0:0:0";
            var expected = 0;

            var timeStamp = new Time(argument);

            Assert.AreEqual(expected, timeStamp.Hours * 3600 + timeStamp.Minutes * 60 + timeStamp.Seconds);
        }

        [TestMethod]
        public void TestStringWithTwoColons4()
        {
            var argument = "015:04:00";
            var expected = 15 * 3600 + 4 * 60;

            var timeStamp = new Time(argument);

            Assert.AreEqual(expected, timeStamp.Hours * 3600 + timeStamp.Minutes * 60 + timeStamp.Seconds);
        }

        [TestMethod]
        public void TestStringWithOneColon1()
        {
            var argument = "04:02";
            var expected = 4 * 3600 + 2 * 60;

            var timeStamp = new Time(argument);

            Assert.AreEqual(expected, timeStamp.Hours * 3600 + timeStamp.Minutes * 60);
        }

        [TestMethod]
        public void TestStringWithOneColon2()
        {
            var argument = "04:2";
            var expected = 4 * 3600 + 2 * 60;

            var timeStamp = new Time(argument);

            Assert.AreEqual(expected, timeStamp.Hours * 3600 + timeStamp.Minutes * 60);
        }

        [TestMethod]
        public void TestStringWithOneColon3()
        {
            var argument = "4:02";
            var expected = 4 * 3600 + 2 * 60;

            var timeStamp = new Time(argument);

            Assert.AreEqual(expected, timeStamp.Hours * 3600 + timeStamp.Minutes * 60);
        }

        [TestMethod]
        public void TestStringWithOneColon4()
        {
            var argument = "4:2";
            var expected = 4 * 3600 + 2 * 60;

            var timeStamp = new Time(argument);

            Assert.AreEqual(expected, timeStamp.Hours * 3600 + timeStamp.Minutes * 60);
        }

        [TestMethod]
        public void TestStringWithOneColon5()
        {
            var argument = "0:0";
            var expected = 0;

            var timeStamp = new Time(argument);

            Assert.AreEqual(expected, timeStamp.Hours * 3600 + timeStamp.Minutes * 60);
        }

        [TestMethod]
        public void TestStringWithoutColons1()
        {
            var argument = "0";
            var expected = 0;

            var timeStamp = new Time(argument);

            Assert.AreEqual(expected, timeStamp.Hours);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Incorrect argument.")]
        public void TestStringWithoutColons2()
        {
            var argument = "40";

            var timeStamp = new Time(argument);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Incorrect argument.")]
        public void TestStringWithoutColons3()
        {
            var argument = "120";

            var timeStamp = new Time(argument).ToString();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Incorrect argument.")]
        public void TestStringTimeUnitsRange1()
        {
            var argument = "-4:5:20";

            var timeStamp = new Time(argument);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Incorrect argument.")]
        public void TestStringTimeUnitsRange2()
        {
            var argument = "4:-5:20";

            var timeStamp = new Time(argument);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Incorrect argument.")]
        public void TestStringTimeUnitsRange3()
        {
            var argument = "4:5:-20";

            var timeStamp = new Time(argument);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Incorrect argument.")]
        public void TestStringTimeUnitsRange4()
        {
            var argument = "4:70:20";

            var timeStamp = new Time(argument);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Incorrect argument.")]
        public void TestStringTimeUnitsRange5()
        {
            var argument = "4:5:200";

            var timeStamp = new Time(argument);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Incorrect argument.")]
        public void TestThreeIntArgsTimeUnitsRange1()
        {
            byte hour = 1;
            byte minute = 99;
            byte second = 5;

            var timeStamp = new Time(hour, minute, second);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Incorrect argument.")]
        public void TestThreeIntArgsTimeUnitsRange2()
        {
            byte hour = 1;
            byte minute = 20;
            byte second = 105;

            var timeStamp = new Time(hour, minute, second);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Incorrect argument.")]
        public void TestTwoIntArgsTimeUnitsRange3()
        {
            byte hour = 1;
            byte minute = 90;

            var timeStamp = new Time(hour, minute);
        }

        [TestMethod]
        public void TestGreaterThanOperator()
        {
            var arg1 = "11:50:04";
            var arg2 = "5:10:0";

            var timeStamp1 = new Time(arg1);
            var timeStamp2 = new Time(arg2);

            var expected = true;
            var result = timeStamp1 > timeStamp2;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestLessThanOperator()
        {
            var arg1 = "11:50:04";
            var arg2 = "5:10:0";

            var timeStamp1 = new Time(arg1);
            var timeStamp2 = new Time(arg2);

            var expected = false;
            var result = timeStamp1 < timeStamp2;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGreaterThanOrEqualOperator()
        {
            var arg1 = "11:50:04";
            var arg2 = "1:50:04";

            var timeStamp1 = new Time(arg1);
            var timeStamp2 = new Time(arg2);

            var expected = true;
            var result = timeStamp1 >= timeStamp2;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestLessThanOrEqualOperator()
        {
            var arg1 = "11:50:04";
            var arg2 = "11:50:04";

            var timeStamp1 = new Time(arg1);
            var timeStamp2 = new Time(arg2);

            var expected = true;
            var result = timeStamp1 <= timeStamp2;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestEqualOperator()
        {
            var arg1 = "5:10:0";
            var arg2 = "5:10:0";

            var timeStamp1 = new Time(arg1);
            var timeStamp2 = new Time(arg2);

            var expected = true;
            var result = timeStamp1 == timeStamp2;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestNotEqualThanOperator()
        {
            var arg1 = "11:50:04";
            var arg2 = "5:10:0";

            var timeStamp1 = new Time(arg1);
            var timeStamp2 = new Time(arg2);

            var expected = true;
            var result = timeStamp1 != timeStamp2;

            Assert.AreEqual(expected, result);
        }
        /*
        [TestMethod]
        public void TestAdditionOperator1()
        {
            var arg1 = "0:04:04";
            var arg2 = "10:10:0";

            var timeStamp1 = new Time(arg1);
            var timeStamp2 = new Time(arg2);

            var expected = "10:14:4";
            var result = ToString(timeStamp1 + timeStamp2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestAdditionOperator2()
        {
            var arg1 = "0:04:04";
            var arg2 = "10:10:0";

            var timeStamp1 = new TimePeriod(arg1);
            var timeStamp2 = new Time(arg2);

            var expected = "10:14:4";
            var result = ToString(timeStamp2 + timeStamp1);

            Assert.AreEqual(expected, result);
        }
        */
        [TestMethod]
        public void TestSubtractionOperator1()
        {
            var arg1 = "0:04:04";
            var arg2 = "10:10:0";

            var timeStamp1 = new TimePeriod(arg1);
            var timeStamp2 = new Time(arg2);

            var expected = "10:5:56";
            var result = Convert.ToString(timeStamp2 - timeStamp1);

            Assert.AreEqual(expected, result);
        }
        /*
        [TestMethod]
        public void TestSubtractionOperator2()
        {
            var arg1 = "0:04:04";
            var arg2 = "10:10:0";

            var timeStamp1 = new Time(arg1);
            var timeStamp2 = new Time(arg2);

            var expected = "10:5:56";
            var result = Convert.ToString(timeStamp2 - timeStamp1);

            Assert.AreEqual(expected, result);
        }
        */
        [TestMethod]
        public void TestMinusMethod1()
        {
            var arg1 = "0:04:04";
            var arg2 = "10:10:0";

            var timeStamp1 = new TimePeriod(arg1);
            var timeStamp2 = new Time(arg2);

            var expected = "10:5:56";
            var result = Convert.ToString(Time.Minus(timeStamp2, timeStamp1));

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMinusMethod2()
        {
            var arg1 = "0:04:04";
            var arg2 = "10:10:0";

            var timeStamp1 = new TimePeriod(arg1);
            var timeStamp2 = new Time(arg2);

            var expected = "10:5:56";
            var result = Convert.ToString(timeStamp2.Minus(timeStamp1));

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestPlusMethod1()
        {
            var arg1 = "0:04:04";
            var arg2 = "10:10:0";

            var timeStamp1 = new Time(arg1);
            var timeStamp2 = new Time(arg2);

            var expected = "10:14:4";
            var result = Convert.ToString(Time.Plus(timeStamp1, timeStamp2));

            Assert.AreEqual(expected, result);
        }
        /*
        [TestMethod]
        public void TestPlusMethod2()
        {
            var arg1 = "0:04:04";
            var arg2 = "10:10:0";

            var timeStamp1 = new Time(arg1);
            var timeStamp2 = new TimePeriod(arg2);

            var expected = "10:14:4";
            var result = Convert.ToString(Time.Plus(timeStamp1, timeStamp2));

            Assert.AreEqual(expected, result);
        }
        */
        [TestMethod]
        public void TestPlusMethod3()
        {
            var arg1 = "0:04:04";
            var arg2 = "10:10:0";

            var timeStamp1 = new Time(arg1);
            var timeStamp2 = new TimePeriod(arg2);

            var expected = "10:14:4";
            var result = Convert.ToString(timeStamp1.Plus(timeStamp2));

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestCompareToMethod()
        {
            var arg1 = "10:10:04";
            var arg2 = "10:10:04";

            var timeStamp1 = new Time(arg1);
            var timeStamp2 = new Time(arg2);

            var expected = 0;
            var result = Convert.ToInt32(timeStamp1.CompareTo(timeStamp2));

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestEqualsMethod()
        {
            var arg1 = "10:10:04";
            var arg2 = "10:10:04";

            var timeStamp1 = new Time(arg1);
            var timeStamp2 = new Time(arg2);

            var expected = true;
            var result = timeStamp1.Equals(timeStamp2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestToStringMethod()
        {
            var timeStamp = new Time(20);

            var expected = "20:0:0";

            Assert.AreEqual(expected, timeStamp.ToString());
        }

    }
}

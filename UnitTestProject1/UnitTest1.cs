using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Sessia2Malev;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ErrorInWrongOrder() // проверяет на вывод ошибки при неправильном распорядке записей на прием
        {
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);

            TimeSpan endWorkingTime = new TimeSpan(18, 00, 0);

            TimeSpan timeSpan = new TimeSpan(8, 0, 0);

            TimeSpan timeSpan1 = new TimeSpan(9, 0, 0);

            TimeSpan timeSpan2 = new TimeSpan(16, 0, 0);

            TimeSpan timeSpan3 = new TimeSpan(15, 30, 0);

            TimeSpan timeSpan4 = new TimeSpan(16, 50, 0);

            int[] durations = { 60, 30, 10, 10, 40 };

            int consultationTime = 30;

            TimeSpan[] startTimes = { timeSpan, timeSpan1, timeSpan2, timeSpan3, timeSpan4 };

            string[] mistake = { "ошибка" };

            string[] actual = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            Assert.AreEqual(mistake[0], actual[0]);
        }

        [TestMethod]
        public void ErrorsWhenWritingLaterThanWorking() // проверяет на вывод ошибки при записе позже чем рабочий
        {
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);

            TimeSpan endWorkingTime = new TimeSpan(18, 00, 0);

            TimeSpan timeSpan = new TimeSpan(8, 0, 0);

            TimeSpan timeSpan1 = new TimeSpan(9, 0, 0);

            TimeSpan timeSpan2 = new TimeSpan(15, 0, 0);

            TimeSpan timeSpan3 = new TimeSpan(15, 30, 0);

            TimeSpan timeSpan4 = new TimeSpan(19, 50, 0);

            int[] durations = { 60, 30, 10, 10, 40 };

            int consultationTime = 30;

            TimeSpan[] startTimes = { timeSpan, timeSpan1, timeSpan2, timeSpan3, timeSpan4 };

            string[] mistake = { "ошибка" };

            string[] actual = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            Assert.AreEqual(mistake[0], actual[0]);
        }

        [TestMethod]
        public void EarlyRecordingError() // проверяет на вывод ошибки при записе раньше чем рабочий
        {
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);

            TimeSpan endWorkingTime = new TimeSpan(18, 00, 0);

            TimeSpan timeSpan = new TimeSpan(7, 0, 0);

            TimeSpan timeSpan1 = new TimeSpan(9, 0, 0);

            TimeSpan timeSpan2 = new TimeSpan(15, 0, 0);

            TimeSpan timeSpan3 = new TimeSpan(15, 30, 0);

            TimeSpan timeSpan4 = new TimeSpan(16, 50, 0);

            int[] durations = { 60, 30, 10, 10, 40 };

            int consultationTime = 30;

            TimeSpan[] startTimes = { timeSpan, timeSpan1, timeSpan2, timeSpan3, timeSpan4 };

            string[] mistake = { "ошибка" };

            string[] actual = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            Assert.AreEqual(mistake[0], actual[0]);
        }

        [TestMethod]
        public void ErrorsIfTheEndOfTheWorkingDayIsEarlierThanTheBeginning() // проверяет на вывод ошибки если конец рабочего дня раньше чем начало
        {
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);

            TimeSpan endWorkingTime = new TimeSpan(7, 0, 0);

            TimeSpan timeSpan = new TimeSpan(8, 0, 0);

            TimeSpan timeSpan1 = new TimeSpan(9, 0, 0);

            TimeSpan timeSpan2 = new TimeSpan(15, 20, 0);

            TimeSpan timeSpan3 = new TimeSpan(15, 30, 0);

            TimeSpan timeSpan4 = new TimeSpan(16, 50, 0);

            int[] durations = { 60, 30, 20, 10, 40 };

            int consultationTime = 30;

            TimeSpan[] startTimes = { timeSpan, timeSpan1, timeSpan2, timeSpan3, timeSpan4 };

            string[] mistake = { "ошибка" };

            string[] actual = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            Assert.AreEqual(mistake[0], actual[0]);
        }
    }
}

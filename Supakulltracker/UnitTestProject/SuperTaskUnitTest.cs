using System;
using Supakulltracker;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestServices
{
    [TestClass]
    public class SuperTaskUnitTest
    {
        [TestMethod]
        public void TestValuesAreTheSame()
        {
            string s1, s2, s3, s4;
            s1 = "s1";
            s2 = "s2";
            s3 = "s3";
            s4 = "s4";

            string[] testInput;

            testInput = new string[] { null, s1, s1, null };
            Assert.IsTrue(SuperTask.ValuesAreTheSame(testInput));

            testInput = new string[] { null, null, null, null };
            Assert.IsTrue(SuperTask.ValuesAreTheSame(testInput));

            testInput = new string[] { null, s1 };
            Assert.IsTrue(SuperTask.ValuesAreTheSame(testInput));

            testInput = new string[] { s1 };
            Assert.IsTrue(SuperTask.ValuesAreTheSame(testInput));

            testInput = new string[] { null };
            Assert.IsTrue(SuperTask.ValuesAreTheSame(testInput));


            testInput = new string[] { s1, s1, s2, s3, s4, s1, s2, s3, s4, s1, s1, s3, s4 };
            Assert.IsFalse(SuperTask.ValuesAreTheSame(testInput));

            testInput = new string[] { s2, s1, s1, null };
            Assert.IsFalse(SuperTask.ValuesAreTheSame(testInput));
        }
    }
}

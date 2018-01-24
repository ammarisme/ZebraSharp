using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZebraCSharp;
using System.Text.RegularExpressions;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Testing againt non numeric inputs
        /// </summary>
        [TestMethod]
        public void Add_NonNumericInput_Return0()
        {
            string a = Calculator.Add("e334", "33d3fd");
            StringAssert.StartsWith(a, "0");
        }

        /// <summary>
        ///  Test Assumptions:
        ///  Both numbers are being passed in have same length
        ///  Drawbacks:
        ///  Test will pass if the leftmost number is correct. 
        ///  Notes:
        ///  A reverse engineering of the methodology used in the test subject needs to be developed.
        /// </summary>
        [TestMethod]
        public void Add_SameLengthUpto1000Digits_RightMostDigitIsCorrectWithouConsideringTheCarry()
        {
            bool testStatus = true;
            Random r = new Random();
            string a = "";
            string b = "";
            for(int i=0; i < 1000; i++)
            {
                decimal addA = r.Next(1,9);
                decimal addB = r.Next(1,9);
                a = addA.ToString() + a;
                b = addB.ToString() + b;
                string result = Calculator.Add(a, b);
                bool success = true;
                if (result.Length == a.Length)
                {
                    success = (result.Substring(0, 1) == (addA + addB).ToString()) || (result.Substring(0, 1) == (addA + addB+1).ToString());
                }
                else
                {
                    success = (result.Substring(0, 1) == "1");
                }
                    testStatus = testStatus && success;
            }
            Assert.IsTrue(testStatus);
        }

        [TestMethod]
        public void Add_NullInputs_Return0()
        {
            Assert.IsTrue(Calculator.Add(null, null) == "0" && Calculator.Add(null, "24") == "0" || Calculator.Add("55", null) == "0");
        }
    }
}

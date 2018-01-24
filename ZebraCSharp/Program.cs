using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZebraCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test cases given
            Console.WriteLine(Calculator.Add("12345","4535").ToString());
            Console.Read();
        }
    }

    public class Calculator {

        /// <summary>
        /// This is the primary school method of summing up two numbers
        /// eg:- 
        /// 0124
        /// 1345
        /// -----
        /// 1469
        /// =====
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string Add(string a, string b)
        {
            if(a == null || b == null || !Regex.IsMatch(a, @"^\d+$") || !Regex.IsMatch(b, @"^\d+$") )
            {
                return "0";
            }
            // make sure a.length <= b.length
            if (a.Length > b.Length)
            {
                string temp = b;
                b = a;
                a = temp;
            }
            
            //Convert input strings to char arrays of equal length
            a = new string(a.ToCharArray().Reverse().ToArray());
            b = new string(b.ToCharArray().Reverse().ToArray());
            for (int i = 0; i < b.Length - a.Length; i++)
            {
                a += "0";
            }
            char[] aArray = a.ToCharArray();
            char[] bArray = b.ToCharArray();

            //result will be stored in this array, then will be reversed and converted to a string.
            char[] result = new char[Math.Max(a.Length, b.Length) + 1];

            //Summing up digit by digit from right
            int carry = 0;
            for (int i = 0; i < a.Length; i++)
            {
                char a1 = a.Substring(i, 1).ToCharArray()[0];
                char b1 = b.Substring(i, 1).ToCharArray()[0];
                int value = int.Parse(a1.ToString()) + int.Parse(b1.ToString()) + carry;
                char[] intermediarySum = (value > 9 ? value - 10 : value).ToString().ToCharArray();
                
                result[i] = intermediarySum[0];
                value = (intermediarySum.Length > 1) ? value + intermediarySum[1] : value;
                carry = value > 9 ? 1 : 0;
            }

            if (carry > 0)
            {
                result[b.Length] = carry.ToString().ToCharArray()[0];
            }
            
            string resultString = new string(result.Reverse().ToArray());
            return resultString.TrimStart('\0');
        }
    }
}

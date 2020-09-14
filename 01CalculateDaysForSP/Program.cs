using System;
using System.Xml.Serialization;

namespace _01CalculateDaysForSP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Node A = new Node("A");
            //Node B = new Node("B");
            //Node C = new Node("C");
            //Node D = new Node("D");
            //Node E = new Node("E");

            //A.Left = B;
            //A.Right = C;
            //C.Left = D;
            //C.Right = E;

            //A.Show();

            Console.WriteLine("Hello World!");
        }

        static int CalculateDaysOfTwoYear(int beginYear, int endYear)
        {
            int days = 0;

            for (int i = beginYear + 1; i <= endYear; i++)
            {
                if (IsLeapYear(i))
                {
                    days += 366;
                }
                else
                {
                    days += 365;
                }
            }
            return days;
        }

        /// <summary>
        /// 是否为闰年
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        static bool IsLeapYear(int year)
        {
            if (year % 400 == 0)
            {
                return true;
            }
            if (year % 4 == 0 && year % 100 != 0)
            {
                return true;
            }
            return false;
        }
    }

    class Node
    {

        public Node Left;
        public Node Right;
        private string value;

        public Node(string value)
        {
            this.value = value;
        }

        public void Show()
        {
            Console.WriteLine(this.value);
            if (Left != null)
            {
                Left.Show();
            }
            if (Right != null)
            {
                Right.Show();
            }
        }
    }
}

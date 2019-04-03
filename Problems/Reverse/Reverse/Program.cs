﻿using System;
using System.Collections;
using System.Diagnostics;

//给出一个 32 位的有符号整数，你需要将这个整数中每位上的数字进行反转。

//示例 1:

//输入: 123
//输出: 321
// 示例 2:

//输入: -123
//输出: -321
//示例 3:

//输入: 120
//输出: 21
//注意:

//假设我们的环境只能存储得下 32 位的有符号整数，则其数值范围为 [−2^31,  2^31 − 1]。请根据这个假设，如果反转后整数溢出那么就返回 0。

namespace Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Assert(Reverse(123) == 321);
            Debug.Assert(Reverse(-123) == -321);
            Debug.Assert(Reverse(120) == 21);
            Console.WriteLine("Hello World!");
        }

        public static int Reverse(int x)
        {
            int rev = 0;
            while (x != 0)
            {
                //代替Reverse2中Stack Pop方法
                int pop = x % 10;
                x /= 10;
                //判断值是否溢出，Reverse2用了Double简单直观，但消耗内存大
                //intMax = 2147483647, intMin = -2147483648
                //边界：超出除10范围，或等于除10时，最后一位超出int范围则溢出
                if (rev > int.MaxValue / 10 || (rev == int.MaxValue / 10 && pop > 7)) return 0;
                if (rev < int.MinValue / 10 || (rev == int.MinValue / 10 && pop < -8)) return 0;
                rev = rev * 10 + pop;
            }
            return rev;
        }

        public static int Reverse2(int x)
        {
            string xStr = x.ToString();
            Stack myStack = new Stack();
            foreach (var c in xStr)
            {
                myStack.Push(c);
            }

            double res = 0;
            bool isNav = false;
            while (myStack.Count != 0)
            {
                char c = (char)myStack.Pop();
                if (c != '-')
                {
                    res = res * 10 + Char.GetNumericValue(c);
                    if (res > int.MaxValue || res < int.MinValue)
                    {
                        res = 0;
                        break;
                    }
                }
                else
                {
                    isNav = true;
                }
            }

            if (isNav)
            {
                res = 0 - res;
            }

            return (int)res;
        }
    }
}

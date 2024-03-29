﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PlusOne
{
    //66. 加一
    //给定一个由 整数 组成的 非空 数组所表示的非负整数，在该数的基础上加一。
    //最高位数字存放在数组的首位， 数组中每个元素只存储单个数字。
    //你可以假设除了整数 0 之外，这个整数不会以零开头。

    //示例 1：
    //输入：digits = [1,2,3]
    //输出：[1,2,4]
    //解释：输入数组表示数字 123。

    //示例 2：
    //输入：digits = [4,3,2,1]
    //输出：[4,3,2,2]
    //解释：输入数组表示数字 4321。

    //示例 3：
    //输入：digits = [0]
    //输出：[1]

    //提示：
    //1 <= digits.length <= 100
    //0 <= digits[i] <= 9
    class Program
    {
        static void Main(string[] args)
        {
            var a = PlusOne(new int[] { 1, 2, 3 });
            var a1 = PlusOne(new int[] { 4, 3, 2, 1 });
            var a2 = PlusOne(new int[] { 4, 3, 9, 9 });
            var a3 = PlusOne(new int[] { 9 });
            Console.WriteLine("Hello World!");
        }

        //最后一位加1，取余，判断跳出
        //否则倒数第二位继续加1
        public static int[] PlusOne(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                digits[i]++;
                digits[i] = digits[i] % 10;
                if (digits[i] != 0) return digits;
            }
            //循环结束还没调出，说明都是999
            //扩容，首位为 1 
            digits = new int[digits.Length + 1];
            digits[0] = 1;
            return digits;
        }

        //加 1 后迭代，往List中前插值
        public static int[] PlusOne1(int[] digits)
        {
            var numbers = new List<int>();
            digits[digits.Length - 1] += 1;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] == 10)
                {
                    if (i != 0)
                    {
                        digits[i - 1] += 1;
                        numbers.Insert(0, 0);
                    }
                    else
                    {
                        numbers.Insert(0, 0);
                        numbers.Insert(0, 1);
                    }
                }
                else
                {
                    numbers.Insert(0, digits[i]);
                }
            }

            return numbers.ToArray();
        }
    }
}

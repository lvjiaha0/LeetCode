using System;
using System.Collections;
using System.Diagnostics;
using System.Text;


//判断一个整数是否是回文数。回文数是指正序（从左向右）和倒序（从右向左）读都是一样的整数。

//示例 1:

//输入: 121
//输出: true
//示例 2:

//输入: -121
//输出: false
//解释: 从左向右读, 为 -121 。 从右向左读, 为 121- 。因此它不是一个回文数。
//示例 3:

//输入: 10
//输出: false
//解释: 从右向左读, 为 01 。因此它不是一个回文数。

namespace IsPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Assert(IsPalindrome(121) == true);
            Debug.Assert(IsPalindrome(-121) == false);
            Debug.Assert(IsPalindrome(10) == false);
            Debug.Assert(IsPalindrome(11) == true);
            Console.WriteLine("Hello World!");
        }

        public static bool IsPalindrome(int x)
        {
            if (x < 0)//负数一定不是回文数
            {
                return false;
            }
            else
            {
                var str = x.ToString();

                //两个由外向里移动的对称指针，对比字符是否相等
                for (int i = 0; i < str.Length; i++)
                {
                    int j = str.Length - 1 - i;
                    if (i <= j)//奇数和偶数长度下，不超过中轴线时
                    {
                        if (str[i] != str[j])
                        {
                            return false;
                        }
                    }
                    else//超过中轴线，判断结束
                    {
                        break;
                    }

                }

                return true;
            }
        }
    }
}

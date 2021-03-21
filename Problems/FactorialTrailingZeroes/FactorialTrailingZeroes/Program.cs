using System;

namespace FactorialTrailingZeroes
{
    //172. 阶乘后的零
    //给定一个整数 n，返回 n! 结果尾数中零的数量。

    //示例 1:
    //输入: 3
    //输出: 0
    //解释: 3! = 6, 尾数中没有零。

    //示例 2:
    //输入: 5
    //输出: 1
    //解释: 5! = 120, 尾数中有 1 个零.
    //说明: 你算法的时间复杂度应为 O(log n) 。
    class Program
    {
        static void Main(string[] args)
        {
            //var a = TrailingZeroes(5);//1
            //var b = TrailingZeroes(13);//2
            var b = TrailingZeroes(30);//7
            Console.WriteLine("Hello World!");
        }

        //解题思路
        //尾数中0的数量即乘数因子中10的数量，10=2*5，阶乘中2一定比5多，所以即为乘数因子中5的数量

        //n每多5，数量+1
        //n每多5²，数量再+1
        //n每多5³，数量再+1
        public static int TrailingZeroes(int n)
        {
            var total = 0;
            while (n >= 5)
            {
                n /= 5;
                total += n;
            }
            return total;
        }
        //时间复杂度O(n)
    }
}

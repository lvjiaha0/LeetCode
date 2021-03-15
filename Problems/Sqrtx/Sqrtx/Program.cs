using System;

namespace Sqrtx
{
    //69. x 的平方根
    //实现 int sqrt(int x) 函数。
    //计算并返回 x 的平方根，其中 x 是非负整数。
    //由于返回类型是整数，结果只保留整数的部分，小数部分将被舍去。

    //示例 1:
    //输入: 4
    //输出: 2

    //示例 2:
    //输入: 8
    //输出: 2
    //说明: 8 的平方根是 2.82842..., 
    //由于返回类型是整数，小数部分将被舍去。
    class Program
    {
        static void Main(string[] args)
        {
            var a = MySqrt(8);//2
            Console.WriteLine("Hello World!");
        }

        //二分法查找
        //设置左右边界，当左边界小于等于右边界时，迭代
        //动态调整左右边界
        public static int MySqrt(int x)
        {
            int l = 0, r = x, ans = -1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                //中位乘机小于等于目标值，结果调整为左边界，并且左边界再右移
                if ((long)mid * mid <= x)
                {
                    ans = mid;
                    l = mid + 1;
                }
                //大于目标值，向左移右边界
                else
                {
                    r = mid - 1;
                }
            }
            return ans;
        }

    }
}

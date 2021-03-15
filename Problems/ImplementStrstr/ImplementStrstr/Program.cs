using System;
using System.Linq;

namespace ImplementStrstr
{
    //28. 实现 strStr()
    //实现 strStr() 函数。
    //给定一个 haystack 字符串和一个 needle 字符串，在 haystack 字符串中找出 needle 字符串出现的第一个位置(从0开始)。
    //如果不存在，则返回  -1。

    //示例 1:
    //输入: haystack = "hello", needle = "ll"
    //输出: 2

    //示例 2:
    //输入: haystack = "aaaaa", needle = "bba"
    //输出: -1
    //说明:
    //当 needle 是空字符串时，我们应当返回什么值呢？这是一个在面试中很好的问题。
    //对于本题而言，当 needle 是空字符串时我们应当返回 0 。这与C语言的 strstr() 以及 Java的 indexOf() 定义相符。
    class Program
    {
        static void Main(string[] args)
        {
            var a = StrStr("hello", "ll");//2
            var b = StrStr("aaaaa", "bba");//-1
            var c = StrStr("a", "a");//0
            Console.WriteLine("Hello World!");
        }

        //方法一：子串逐一比较 - 线性时间复杂度
        //最直接的方法 - 沿着字符换逐步移动滑动窗口，将窗口内的子串与 needle 字符串比较。
        public static int StrStr(string haystack, string needle)
        {
            var haystackLength = haystack.Length;
            var needleLength = needle.Length;
            if (needleLength == 0) return 0;

            for (int start = 0; start <= haystackLength - needleLength; start++)
            {
                if (haystack.Substring(start, needleLength) == needle)
                {
                    return start;
                }
            }
            return -1;
        }
        //时间复杂度：O((N - L)L)，其中 N 为 haystack 字符串的长度，L 为 needle 字符串的长度。内循环中比较字符串的复杂度为 L，总共需要比较(N - L) 次。
        //空间复杂度：O(1)。



        //方法二：双指针 - 线性时间复杂度(java源码中indexOf的实现)
        //上一个方法的缺陷是会将 haystack 所有长度为 L 的子串都与 needle 字符串比较，实际上是不需要这么做的。
        public static int StrStr2(string haystack, string needle)
        {
            int m = haystack.Length, n = needle.Length;
            if (n == 0) return 0;
            for (int i = 0; i <= m - n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    //逐个比较字符，不同则继续滑动
                    if (haystack[i + j] != needle[j]) break;
                    //比较到最后都相同，则返回起始index i
                    if (j == n - 1) return i;
                }
            }
            return -1;
        }
        //复杂度分析
        //时间复杂度：最坏时间复杂度为 O((N−L)L)，最优时间复杂度为 O(N)。
        //空间复杂度：O(1)。
    }
}

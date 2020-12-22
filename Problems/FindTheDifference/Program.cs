using System;
using System.Linq;

/// <summary>
/// 给定两个字符串 s 和 t，它们只包含小写字母。

///字符串 t 由字符串 s 随机重排，然后在随机位置添加一个字母。

///请找出在 t 中被添加的字母。



///示例 1：

///输入：s = "abcd", t = "abcde"
///输出："e"
///解释：'e' 是那个被添加的字母。
///示例 2：

///输入：s = "", t = "y"
///输出："y"
///示例 3：

///输入：s = "a", t = "aa"
///输出："a"
///示例 4：

///输入：s = "ae", t = "aea"
///输出："a"

///来源：力扣（LeetCode）
///链接：https://leetcode-cn.com/problems/find-the-difference
///著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
/// </summary>
namespace FindTheDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            var e = FindTheDifference2("abcd", "abcde");
            var y = FindTheDifference2("", "y");
            var a = FindTheDifference2("a", "aa");
            a = FindTheDifference2("ae", "aea");
            Console.WriteLine("Hello World!");
        }

        public static char FindTheDifference(string s, string t)
        {
            int totalS = 0;
            int totalT = 0;
            for (int i = 0; i < s.Length; i++)
            {
                totalS += s[i];
            }

            for (int j = 0; j < t.Length; j++)
            {
                totalT += t[j];
            }

            return Convert.ToChar(totalT - totalS);
        }

        public static char FindTheDifference2(string s, string t)
        {
            int totalS = s.Sum(item => item);
            int totalT = t.Sum(item => item);
            return Convert.ToChar(totalT - totalS);
        }
    }
}
